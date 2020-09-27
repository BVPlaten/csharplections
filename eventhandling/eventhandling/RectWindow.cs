using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Drawing;

namespace eventhandling
{
    public delegate void RectanglePressedEventHandler(string msgText);

    class RectWindow
    {
        public event RectanglePressedEventHandler RectanglePressed;

        public void Show()
        {
            VideoMode mode = new VideoMode(650, 600);
            RenderWindow window = new RenderWindow(mode, "Press on a Button");
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

            var brdrClr1 = new SFML.Graphics.Color(90, 90, 255);
            var fillClr1 = new SFML.Graphics.Color(130, 130, 255);
            RectangleShape recShp1 = createRect(window, 25, 25, brdrClr1, fillClr1,"Dieter");
            window.Draw(recShp1);

            var brdrClr2 = new SFML.Graphics.Color(130, 130, 55);
            var fillClr2 = new SFML.Graphics.Color(200, 200, 120);
            RectangleShape recShp2 = createRect(window, 25, 175, brdrClr2, fillClr2, "Hugo");
            window.Draw(recShp2);

            var brdrClr3 = new SFML.Graphics.Color(130, 30, 55);
            var fillClr3 = new SFML.Graphics.Color(255, 10, 80);
            RectangleShape recShp3 = createRect(window, 25, 325, brdrClr3, fillClr3, "Nina");
            window.Draw(recShp3);

            window.Display();
            while (window.IsOpen)
            {
                // Druecken des Escape-Buttons zum Beenden auswerten
                window.DispatchEvents();
                System.Threading.Thread.Sleep(200);
            }
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
                var myHelperRect = recShp.GetGlobalBounds();
                if (myHelperRect.Contains(e.X, e.Y))
                    RectanglePressed.Invoke($"{ rectName }--:--X - POS { e.X}; Y - POS { e.Y}");
            };
            return recShp;
        }
    }
}
