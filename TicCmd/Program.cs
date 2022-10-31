using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using TicLib;

namespace TicCmd
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            PrintHelp();

            var tic = new Tic();
            tic.Open();

            if (!tic.IsConnected)
                return;
            
            Console.WriteLine($@"Connected to {tic.ProductId}");

            tic.Reinitialize();
            tic.Energize();
            tic.ClearDriverError();

            tic.SetMaxAccel(100000);
            tic.SetMaxDecel(100000);
            tic.SetMaxSpeed(1000000);
            tic.SetStartingSpeed(1000000);
            tic.ExitSafeStart();
            tic.WaitForDeviceReady();

            tic.SetTargetPosition(100);
            Thread.Sleep(1000);

            tic.SetTargetPosition(0);
            Thread.Sleep(1000);


            while (true)
            {
                var param = Console
                    .ReadLine()?
                    .Trim()
                    .ToLowerInvariant()
                    .Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);

                switch (param?.FirstOrDefault())
                {
                    case "quit":
                        tic.Close();
                        return;
                
                    case "at":
                        tic.HaltAndSetPosition(GetInt(param, 1));
                        break;

                    case "abs":
                        tic.SetTargetPosition(GetInt(param, 1));
                        break;
                    
                    case "rel":
                        tic.SetTargetPosition(GetInt(param, 1) + tic.Vars.CurrentPosition);
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

        private static int GetInt(IReadOnlyList<string> param, int i) => param.Count > i && int.TryParse(param[i], out var  v) ? v : 0;

        private static void PrintHelp()
        {
            const string readMePath = "README.TXT";

            if (File.Exists(readMePath)) 
                Console.WriteLine(File.ReadAllText(readMePath));
        }
    }
}