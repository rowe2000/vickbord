using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TicLib;

namespace TicCmd
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            PrintHelp();

            var tic = new Tic();
            bool success = tic.StartInDefaultMode(ProductId.T834);
            if (!success)
                return;

            Console.WriteLine($@"Connected to {tic.ProductId}");

            while (true)
            {
                Console.Write(">");

                var command = Console
                    .ReadLine()?
                    .Trim()
                    .ToLowerInvariant()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (command?.FirstOrDefault())
                {
                    case "quit":
                        tic.Close();
                        return;

                    case "at":
                        tic.HaltAndSetPosition(GetInt(command, 1));
                        break;

                    case "abs":
                        tic.SetTargetPosition(GetInt(command, 1));
                        break;

                    case "rel":
                        tic.SetTargetPosition(GetInt(command, 1) + tic.Vars.CurrentPosition);
                        break;

                    case "pos":
                        Console.WriteLine($@"CurrentPosition = {tic.Vars.CurrentPosition}");
                        break;

                    case "vars":
                        Console.WriteLine(tic.Vars);
                        break;

                    case "status":
                        Console.WriteLine(tic.StatusVars);
                        break;

                    case "help":
                    case "?":
                        PrintHelp();
                        break;
                }
            }
        }

        private static int GetInt(IReadOnlyList<string> param, int i) => param.Count > i && int.TryParse(param[i], out var v) ? v : 0;

        private static void PrintHelp()
        {
            const string readMePath = "README.TXT";

            if (File.Exists(readMePath))
                Console.WriteLine(File.ReadAllText(readMePath));
        }
    }
}