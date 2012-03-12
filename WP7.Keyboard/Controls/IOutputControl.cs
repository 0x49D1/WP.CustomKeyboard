namespace WP7.Keyboard.Controls
{
    public interface IOutputControl
    {
        string Text
        {
            get;
        }

        void AppendToText(string symbol);
        void RemoveLast();
        void Clear();
    }
}
