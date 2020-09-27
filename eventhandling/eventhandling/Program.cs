﻿using System;


namespace eventhandling
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC key to close window");
            // RotatingWindow window = new RotatingWindow();
            RectWindow window = new RectWindow();
            window.RectanglePressed += Window_RectanglePressed;
            window.Show();
            
            Console.WriteLine("All done");
        }

        private static void Window_RectanglePressed(string textMsg)
        {
            Console.WriteLine(textMsg);
        }
    }


}