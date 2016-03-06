<Query Kind="Program" />

void Main()
{
	string code = "distanceToDestination * 4 + 2 * 2";
	var output = Code.ParseStatement(code.Split(' '), null);
	
	Console.Write("Expected: ");
	Console.WriteLine(2 * 4 + 2 * 2);
    
	var fn = Code.CreateStatement(code);
	Console.Write("Actual: ");
	Console.WriteLine(fn(2));
	
	Console.WriteLine(output);

}


enum OperatorType
{
	Variable, 
	Operand,
	Constant
}

class EquationPart
{
	public EquationPart LeftOperand;
	public EquationPart RightOperand;
	public String Name;
	public OperatorType OType;

	public override string ToString() => ToString(0);

	private string ToString(int indent)
	{
		return $@"{Name} : {OType}
			{LeftOperand.ToString(indent + 1)}
			{RightOperand.ToString(indent + 1)}
		";
	}
	
	
}

class Code
{


	public static Func<Expression, Expression, BinaryExpression> GetModifier(string op)
	{
		switch (op)
		{
			case "*":
				return Expression.Multiply;
			case "+":
				return Expression.Add;
			case "-":
				return Expression.Subtract;
			case "/":
				return Expression.Divide;
		}

		throw new Exception("Operator not recognized");
	}

	public static int OperandPrecedence(string item)
	{
		switch (item)
		{
			case "+":
			case "-": return 1;
			case "*":
			case "/": return 2;
			default: return 0;
		}
	}

	public static EquationPart ParseStatement
		(IEnumerable<string> statement, EquationPart tree)
	{
		if (!statement.Any()) { return tree; }

		var part = statement.First();
		switch (OperandPrecedence(part))
		{
			case 2:
				{
					var op = new EquationPart
					{
						Name = part, 
						OType = OperatorType.Operand,
						LeftOperand = tree, 
						RightOperand = ParseStatement(statement.Skip(1).Take(1),tree) 
					};
					return ParseStatement(statement.Skip(2), op);
				}
			case 1:
				{
					return new EquationPart
					{
						Name = part,
						OType = OperatorType.Operand,
						LeftOperand = tree,
						RightOperand = ParseStatement(statement.Skip(1), null)
					};
				}
			default:
				{
				    int result;
					return ParseStatement(statement.Skip(1), new EquationPart
					{
						Name = part,
						OType = (int.TryParse(part, out result))? 
							OperatorType.Constant : OperatorType.Variable
					});
				}
		}
	}

	public static Func<int, double> CreateStatement(string statement)
	{
		var statementParts = statement.Split(' ');

		var tree = ParseStatement(statementParts, null);

		var travelParm = Expression.Parameter(typeof(int), "distanceToDestination");
		var parameterExpression = new ParameterExpression[] { travelParm };

		var body = MakeBody(tree, travelParm);

		var result = Expression.Variable(typeof(double), "result");
        
		var assign = Expression.Assign(result, body);
		var write = Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[1]{typeof(double)}), 
		   result);

		var block = Expression.Block(new ParameterExpression[] {result},assign,write,result);
		
		return Expression.Lambda<Func<int, double>> (block, parameterExpression).Compile();
	}

	public static Expression MakeBody
	(EquationPart tree, ParameterExpression distance)
	{
		if (tree.OType == OperatorType.Operand)
		{
			var leftAction = MakeBody(tree.LeftOperand, distance);
			var rightAction = MakeBody(tree.RightOperand, distance);
			var action = Code.GetModifier(tree.Name)(Expression.Convert(leftAction, typeof(double)), 
				Expression.Convert(rightAction, typeof(double)));
			
			return action;
		}
		
		return (tree.Name == distance.Name) ? 
			(Expression)distance : Expression.Constant(int.Parse(tree.Name), typeof(int));
	}

}