using System;

namespace Shuttles
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
            	Console.WriteLine("Hello World. #weshuttlesnow");
                game.Run();
            }
        }
    }
#endif
}
