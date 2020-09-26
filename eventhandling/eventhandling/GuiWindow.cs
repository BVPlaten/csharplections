using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace eventhandling
{
    class GuiWindow
    {
        public void Show()
        {
            VideoMode mode = new VideoMode(450, 450);
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

            var recShp = new RectangleShape();
            recShp.Size = new Vector2f(100, 50);
            recShp.OutlineColor = new Color(90, 90, 255);
            recShp.FillColor = new Color(130, 130, 255);
            recShp.OutlineThickness = 5;
            recShp.Position = new Vector2f(200, 100);

            window.Draw(recShp);
            window.Display();

            while(window.IsOpen)
            {
                // Druecken des Escape-Buttons zum Beenden auswerten
                window.DispatchEvents();
                System.Threading.Thread.Sleep(200);
            }
        }

    }
}
