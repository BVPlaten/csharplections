using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Reflection;

namespace eventhandling
{
    public delegate void RectanglePressedEventHandler(string msgText);

    class RectWindow
    {
        public event RectanglePressedEventHandler RectanglePressed;
        protected RenderWindow window;

        public void Show()
        {
            DrawRects();
            while (window.IsOpen)
            {
                window.DispatchEvents();
                System.Threading.Thread.Sleep(200);
            }
        }

        public void DrawRects()
        {
            if (window != null)
                window.Close();

            VideoMode mode = new VideoMode(650, 600);
            window = new RenderWindow(mode, "Press on a Button");
            window.Closed += (obj, e) => { window.Close(); };
            window.KeyPressed +=
                (sender, e) =>
                {
                    Window window = (Window)sender;
                    if (e.Code == Keyboard.Key.Escape)
                    {
                        window.Close();
                    }
                };

            window.Draw(createRect(window, 25, 25, creatColor(), creatColor(), "Dieter"));
            window.Draw(createRect(window, 150, 25, creatColor(), creatColor(), "Hugo"));
            window.Draw(createRect(window, 275, 25, creatColor(), creatColor(), "Nina"));
            window.Display();
        }

        private SFML.Graphics.Color creatColor()
        {
            Random rnd = new Random();
            byte red = (byte) rnd.Next(0, 255);
            byte green = (byte)rnd.Next(0, 255);
            byte blue = (byte)rnd.Next(0, 255);
            return new SFML.Graphics.Color(red, green, blue);
        }

        protected virtual RectangleShape createRect(RenderWindow window, int x, int y, SFML.Graphics.Color brdrClr, SFML.Graphics.Color fillClr, string rectName = "")
        {
            var recShp = new RectangleShape();
            recShp.Size = new Vector2f(100, 90);
            recShp.OutlineColor = brdrClr;
            recShp.FillColor = fillClr;
            recShp.OutlineThickness = 5;
            recShp.Position = new Vector2f(x, y);

            window.MouseButtonPressed += (sender, e) =>
            {
                if (recShp.GetGlobalBounds().Contains(e.X, e.Y))
                    RectanglePressed.Invoke($"{ rectName }--:--X-POS {e.X}; Y-POS {e.Y}");
            };
            return recShp;
        }
    }
}
