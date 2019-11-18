using System;

namespace GIG
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("Git Ignore Generator \n");

            if (args.Length == 0)
            {
                Run();
            }
            else
            {
                RunWithArgs(args);
            }
        }

        private static void Run()
        {
            Console.WriteLine("\'list\' - lists the operating systems, programming languages and IDE input types.");
            Console.WriteLine(
                ":types: - creates .gitignore files for types of operating systems, programming languages or IDEs." +
                "\n(Example: \'c++\'. If several types are to be used, they should be entered separated by commas. Example: \'c++, ada\')");
            Console.WriteLine("exit - command to exit the application.");
            while (true)
            {
                Console.Write("\nEnter the command: ");
                string key = Console.ReadLine();
                Console.WriteLine();
                switch (key?.ToLower())
                {
                    case "list":
                    {
                        Generator.ShowTableIgnores();
                        break;
                    }
                    case "exit":
                    {
                        return;
                    }
                    case "":
                    {
                        Console.WriteLine("Error");
                        break;
                    }
                    default:
                    {
                        Generator.ShowIgnore(key);
                        break;
                    }
                }
            }
        }

        private static void RunWithArgs(string[] args)
        {
            string key = null;

            if (args[0] == "-key" || args[0] == "-k")
            {
                for (int i = 1; i < args.Length; i++)
                {
                    key += args[i];
                }
            }

            if (args[0] == "-list" || args[0] == "-l")
            {
                Generator.ShowTableIgnores();
            }

            if (key != null) Generator.ShowIgnore(key);
            if (key == "") Console.WriteLine($"Error");
        }
    }
}