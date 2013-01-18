namespace WP7.Keyboard.Interpreter
{
    public sealed class DefaultExpression : Expression
    {
        public override string Interpret( string symbol )
        {
            return symbol;
        }
    }
}
