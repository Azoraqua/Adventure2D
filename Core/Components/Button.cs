namespace Adventure2D.Core.Components
{
    public interface IButtonClickCallback
    {
        void Handle();
    }
    
    public class Button
    {
        public float X { get; protected set; }
        public float Y { get; protected set; }
        public string Text { get; protected set; }

        public Button(float x, float y, string text)
        {
            X = x;
            Y = y;
            Text = text;
        }

        public void Click(IButtonClickCallback cb)
        {
            cb.Handle();
        }
    }
}