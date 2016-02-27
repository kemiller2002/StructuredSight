[CompilerGenerated]
private sealed class <GetNamesWithConnection>d__1 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IDisposable, IEnumerator
{
    // Fields
    private int <>1__state;
    private string <>2__current;
    public SqlConnection<>3__connection;
    private int <>l__initialThreadId;
    private SqlCommand<command>5__2;
    private SqlDataReader<reader>5__1;
    private SqlConnection connection;

// Methods
[DebuggerHidden]
public <GetNamesWithConnection>d__1(int <>1__state)
{
    this.<> 1__state = <> 1__state;
    this.<> l__initialThreadId = Environment.CurrentManagedThreadId;
}

private void <>m__Finally1()
{
    this.<> 1__state = -1;
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
            this.< command > 5__2 = this.connection.CreateCommand();
            this.<> 1__state = -3;
            this.< command > 5__2.CommandText = "SELECT FirstName FROM Person.Person";
            this.< reader > 5__1 = this.< command > 5__2.ExecuteReader();
            while (this.< reader > 5__1.Read())
                {
                this.<> 2__current = this.< reader > 5__1["FirstName"].ToString();
                this.<> 1__state = 1;
                return true;
                Label_007E:
                this.<> 1__state = -3;
            }
            this.< reader > 5__1 = null;
            this.<> m__Finally1();
            this.< command > 5__2 = null;
            return false;
        }
        if (num != 1)
        {
            return false;
        }
        goto Label_007E;
    }
        fault
        {
        this.System.IDisposable.Dispose();
    }
}

[DebuggerHidden]
IEnumerator<string> IEnumerable<string>.GetEnumerator()
{
    EnumerationController.< GetNamesWithConnection > d__1 d__;
    if ((this.<> 1__state == -2) && (this.<> l__initialThreadId == Environment.CurrentManagedThreadId))
        {
        this.<> 1__state = 0;
        d__ = this;
    }
        else
        {
        d__ = new EnumerationController.< GetNamesWithConnection > d__1(0);
    }
    d__.connection = this.<> 3__connection;
    return d__;
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
    switch (this.<> 1__state)
        {
            case -3:
            case 1:
                try
        {
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

 
Collapse Methods

