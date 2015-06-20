using System;
using Diablo.Items;
using Diablo.Items.Enums;

namespace Diablo
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Diablo())
                game.Run();
        }
    }
#endif
}
