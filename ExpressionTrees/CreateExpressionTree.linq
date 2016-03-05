<Query Kind="Program" />

void Main()
{
	string code = "distanceToDestination * travelModifier + travelModifier * travelModifier";
	var output = Code.ParseStatement(code.Split(' '), null);
	
	Console.Write("Expected: ");
	Console.WriteLine(2 * 2 + 2 * 2);
    
	var fn = Code.CreateStatement(code);
	Console.Write("Actual: ");
	Console.WriteLine(fn(2,2));
	
	Console.WriteLine(output);
}


enum OperatorType
{
	Variable, 
	Operand
}

class Operator
{
	public Operator LeftOperand;
	public Operator RightOperand;
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
		};
	}

	public static Operator ParseStatement
		(IEnumerable<string> statement, Operator tree)
	{
		if (!statement.Any()) { return tree; }

		var part = statement.First();
		switch (OperandPrecedence(part))
		{
			case 2:
				{
					var op = new Operator
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
					return new Operator
					{
						Name = part,
						OType = OperatorType.Operand,
						LeftOperand = tree,
						RightOperand = ParseStatement(statement.Skip(1), null)
					};
				}
			default:
				{
					return ParseStatement(statement.Skip(1), new Operator
					{
						Name = part,
						OType = OperatorType.Variable
					});
				}
		}
	}
	
	public static Func<double, int, double> CreateStatement (string statement) {
		var statementParts = statement.Split(' ');
		
		var tree = ParseStatement(statementParts, null);
		
		var travelParm = Expression.Parameter(typeof(int), "distanceToDestination");
		var travelModifier = Expression.Parameter(typeof(int), "travelModifier");
		
		var parameterExpression = new ParameterExpression[] { travelParm, travelModifier};
		
		var body = MakeBody(tree, travelParm, travelModifier);
		
		return Expression.Lambda<Func<double, int, double>> (body, parameterExpression).Compile();
	}

	public static Expression MakeBody
	(Operator tree, ParameterExpression travel, ParameterExpression travelModifier)
	{
		if (tree.OType == OperatorType.Operand)
		{
			var leftAction = MakeBody(tree.LeftOperand, travel, travelModifier);
			var rightAction = MakeBody(tree.RightOperand, travel, travelModifier);
			var action = Code.GetModifier(tree.Name)(leftAction, rightAction);
			
			return action;
		}
		
		return (tree.Name == travel.Name) ? travel : travelModifier;
	}

}