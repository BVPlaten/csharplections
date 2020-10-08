using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Reflection;
using System.Collections.Generic;

namespace eventhandling
{
    public delegate void RectanglePressedEventHandler(string msgText);

    class RectWindow
    {
        public event RectanglePressedEventHandler rectanglePressed;
        protected RenderWindow window;
        private List<RectangleShape> shapeList;

        /// <summary>
        /// erzeugt das fenster und fügt die rechtecke hinzu :-)
        /// </summary>
        public RectWindow()
        {
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

            // drei Fenster einer Liste erzeugen
            shapeList = new List<RectangleShape>();
            shapeList.Add(createRect(window, 25, 25, creatColor(), creatColor(), "Dieter"));
            shapeList.Add(createRect(window, 150, 25, creatColor(), creatColor(), "Hugo"));
            shapeList.Add(createRect(window, 275, 25, creatColor(), creatColor(), "Nina"));
        }
                
        /// <summary>
        /// zeigt den bildschirm an
        /// </summary>
        public void Show()
        {
            DrawRects();
            while (window.IsOpen)
            {
                window.DispatchEvents();
                System.Threading.Thread.Sleep(200);
            }
        }

        /// <summary>
        /// ändert die farben der rechtecke in der liste
        /// </summary>
        public void DrawRects()
        {
            foreach (var item in shapeList)
            {
                item.OutlineColor = creatColor();
                item.FillColor = creatColor();
                window.Draw(item);
            }
            window.Display();
        }

        /// <summary>
        /// erzeugt eine zufaellige rgb farbe
        /// </summary>
        /// <returns></returns>
        private SFML.Graphics.Color creatColor()
        {
            Random rnd = new Random();
            byte red = (byte) rnd.Next(0, 255);
            byte green = (byte)rnd.Next(0, 255);
            byte blue = (byte)rnd.Next(0, 255);
            return new SFML.Graphics.Color(red, green, blue);
        }

        /// <summary>
        /// erzeugt ein rechteck mit den settings aus den methoden-attributen
        /// </summary>
        /// <param name="window"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="brdrClr"></param>
        /// <param name="fillClr"></param>
        /// <param name="rectName"></param>
        /// <returns></returns>
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
                    rectanglePressed.Invoke($"{ rectName }--:--X-POS {e.X}; Y-POS {e.Y}");
            };
            return recShp;
        }
    }
}
