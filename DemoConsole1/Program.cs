using System;

namespace DemoConsole1;
internal class Program
{
    public static void Main(string[] args)
    {
        //OhMyOS.Mouse.Click(100, 150);

        int X = 0;
        int Y = OhMyOS.Screen.Height / 2;
        while (true)
        {
            if (Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.Backspace)
                {
                    break;
                }
            }

            OhMyOS.Mouse.Move(X, Y);

            X++;
            Thread.Sleep(10);
        }
    }
}