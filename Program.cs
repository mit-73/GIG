using System;

namespace GIG
{
    internal class Program
    {
        static Generator generator = new Generator();
        static Api api = new Api();
        
        public static void Main(string[] args)
        {

            Console.WriteLine("Git Ignore Generator");

            if (args.Length == 0)
            {
                Run(generator);
            }
            else
            {
                RunWithArgs(generator, args);
            }

            Console.ReadLine();
        }
        
        private static void Run(Generator generator)
        {
            
        }
        
        private static void RunWithArgs(Generator generator, string[] args)
        {
            
        }
    }
}