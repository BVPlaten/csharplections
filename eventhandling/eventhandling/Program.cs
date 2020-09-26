using System;


namespace eventhandling
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC key to close window");
            // RotatingWindow window = new RotatingWindow();
            GuiWindow window = new GuiWindow();

            window.Show();
            
            Console.WriteLine("All done");
        }
    }


}