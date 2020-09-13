using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace eventhandling
{
    /// <summary>
    /// Eine rotirende Schrift
    /// </summary>
    /// <remarks>
    /// Beispiel stammt von https://www.gamedev.net/blogs/entry/2269532-sfml-c-net-core-rotating-hello-world/
    /// SFML.net https://www.nuget.org/packages/SFML.Net/
    /// 
    /// </remarks>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC key to close window");
            MyWindow window = new MyWindow();
            window.Show();
            Console.WriteLine("All done");
        }
    }

    class MyWindow
    {
        public void Show()
        {
            VideoMode mode = new VideoMode(450, 450);
            RenderWindow window = new RenderWindow(mode, "SFML.NET");

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

            // ------------ bernd probiert 
            SFML.System.Vector2i size = new Vector2i();
            size.X = 100;
            size.Y = 50;

            RectangleShape rectangle = new RectangleShape();
            rectangle.Size = new Vector2f(100, 50);
            rectangle.OutlineColor = new Color(90, 90, 255);
            rectangle.FillColor = new Color(130, 130, 255);
            rectangle.OutlineThickness = 5;
            rectangle.Position = new Vector2f(200, 100);
            // ------------

            Font font = new Font("C:/Windows/Fonts/arial.ttf");
            Text text = new Text("Hallo Bernd !", font);
            text.CharacterSize = 64;
            float textWidth = text.GetLocalBounds().Width;
            float textHeight = text.GetLocalBounds().Height;
            float xOffset = text.GetLocalBounds().Left;
            float yOffset = text.GetLocalBounds().Top;
            text.Origin = new Vector2f(textWidth / 2f + xOffset, textHeight / 2f + yOffset);
            text.Position = new Vector2f(window.Size.X / 2f, window.Size.Y / 2f);

            Clock clock = new Clock();
            float delta = 0f;
            float angle = 0f;
            float angleSpeed = 90f;

            while (window.IsOpen)
            {
                delta = clock.Restart().AsSeconds();
                angle += angleSpeed * delta;
                window.DispatchEvents();
                window.Clear();
                text.Rotation = angle;
                rectangle.Rotation = -angle;
                window.Draw(rectangle);
                window.Draw(text);

                window.Display();
            }
        }
    }
}