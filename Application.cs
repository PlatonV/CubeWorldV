using CubeWorldV.Command;
using CubeWorldV.ScreenManager;
using CubeWorldV.ScreenManager.Screens;
using Render;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV
{
    static class Application
    {
        public static RenderWindow Window;

        private static Renderer renderer;

        // For focus bug..
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        /// <summary>
        /// Application initalization
        /// </summary>
        internal static void Init()
        {
            // Initialize window
            ContextSettings settings = new ContextSettings();
            settings.AntialiasingLevel = 8;

            Window = new RenderWindow(new VideoMode(1280, 780, 32), "Cube World", Styles.Default, settings);
            Window.SetFramerateLimit(60);
            Window.SetVerticalSyncEnabled(true);
            Window.SetMouseCursorVisible(false);
            Window.KeyPressed += Window_KeyPressed;
            Window.KeyReleased += Window_KeyReleased;

            // Initialize renderer
            renderer = new Renderer(Window);

            // Load some resources
            GlobalResources.Load();

            GlobalResources.ScreenWidth = Window.Size.X;
            GlobalResources.ScreenHeight = Window.Size.Y;

            // Initialize screens
            ScreenManager.ScreenManager.AddScreen(new StartupScreen());
            ScreenManager.ScreenManager.AddScreen(new MainMenuScreen());

            ScreenManager.ScreenManager.GoToScreen("MainMenuScreen");

            // Initialize user
            User.Name = "Platon";
            User.Highscore = 0;

            // Focus application window
            SwitchToThisWindow(Window.SystemHandle, true);
        }

        static void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            // Tell event dispatcher to alert it's listeners about the event.
            EventDispatcher.DispatchKeyPressedEvent(e);

            ScreenManager.ScreenManager.AlertKeyPressed(e);
        }

        private static void Window_KeyReleased(object sender, KeyEventArgs e)
        {
            // Tell event dispatcher to alert it's listeners about the event.
            EventDispatcher.DIspatchKeyReleasedEvent(e);

            // If the key is [Escape], then exit.
            if (e.Code == Keyboard.Key.Escape)
            {
                (new ExitCommand(Window)).Execute();
            }
        }

        /// <summary>
        /// Function that enters main application loop.
        /// </summary>
        internal static void Run()
        {
            Stopwatch clock = new Stopwatch();

            // Main game loop
            while (Window.IsOpen())
            {
                Window.DispatchEvents();

                ScreenManager.ScreenManager.Update(clock.ElapsedMilliseconds);

                Console.Clear();
                Console.WriteLine(clock.ElapsedTicks);
                clock.Reset();
                clock.Start();

                Window.Clear(SFML.Graphics.Color.Black);

                ScreenManager.ScreenManager.Draw(renderer);

                Window.Display();
            }
        }
    }
}
