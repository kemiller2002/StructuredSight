[CompilerGenerated]
private sealed class <EnumerateWithStrings>d__2 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IDisposable, IEnumerator
{
    // Fields
    private int <>1__state;
    private string <>2__current;
    private int <>l__initialThreadId;
    private SqlCommand<command>5__2;
    private SqlConnection<connection>5__3;
    private SqlDataReader<reader>5__1;

    // Methods
    [DebuggerHidden]
public <EnumerateWithStrings>d__2(int <>1__state)
{
    this.<> 1__state = <> 1__state;
    this.<> l__initialThreadId = Environment.CurrentManagedThreadId;
}

private void <>m__Finally1()
{
    this.<> 1__state = -1;
    if (this.< connection > 5__3 != null)
        {
        this.< connection > 5__3.Dispose();
    }
}

private void <>m__Finally2()
{
    this.<> 1__state = -3;
    if (this.< command > 5__2 != null)
        {
        this.< command > 5__2.Dispose();
    }
}

private bool MoveNext()
{
    try
    {
        int num = this.<> 1__state;
        if (num == 0)
        {
            this.<> 1__state = -1;
            this.< connection > 5__3 = new SqlConnection("Data Source=localhost;Initial Catalog=AdventureWorks2014;Integrated Security=SSPI");
            this.<> 1__state = -3;
            this.< command > 5__2 = this.< connection > 5__3.CreateCommand();
            this.<> 1__state = -4;
            this.< connection > 5__3.Open();
            this.< command > 5__2.CommandText = "SELECT FirstName FROM Person.Person";
            this.< reader > 5__1 = this.< command > 5__2.ExecuteReader();
            while (this.< reader > 5__1.Read())
                {
                this.<> 2__current = this.< reader > 5__1["FirstName"].ToString();
                this.<> 1__state = 1;
                return true;
                Label_00A4:
                this.<> 1__state = -4;
            }
            this.< reader > 5__1 = null;
            this.<> m__Finally2();
            this.< command > 5__2 = null;
            this.<> m__Finally1();
            this.< connection > 5__3 = null;
            return false;
        }
        if (num != 1)
        {
            return false;
        }
        goto Label_00A4;
    }
        fault
        {
        this.System.IDisposable.Dispose();
    }
}

[DebuggerHidden]
IEnumerator<string> IEnumerable<string>.GetEnumerator()
{
    if ((this.<> 1__state == -2) && (this.<> l__initialThreadId == Environment.CurrentManagedThreadId))
        {
        this.<> 1__state = 0;
        return this;
    }
    return new EnumerationController.< EnumerateWithStrings > d__2(0);
}

[DebuggerHidden]
IEnumerator IEnumerable.GetEnumerator() =>
    this.System.Collections.Generic.IEnumerable<System.String>.GetEnumerator();

[DebuggerHidden]
void IEnumerator.Reset()
{
    throw new NotSupportedException();
}

[DebuggerHidden]
void IDisposable.Dispose()
{
    int num = this.<> 1__state;
    switch (num)
    {
        case -4:
        case -3:
        case 1:
            try
            {
                switch (num)
                {
                    case -4:
                    case 1:
                        try
                        {
                        }
                        finally
                        {
                            this.<> m__Finally2();
                        }
                        break;
                }
            }
            finally
            {
                this.<> m__Finally1();
            }
            break;
    }
}

// Properties
string IEnumerator<string>.Current =>
    this.<> 2__current;

    object IEnumerator.Current =>
        this.<> 2__current;
}

