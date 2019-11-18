using System;
using System.Linq;

namespace GIG
{
    public class Generator
    {
        public static void ShowTableIgnores()
        {
            const int width = -30;
            var ignores = Api.GetIgnores();
            int quarter = ignores.Count / 4;
            
            for (int a = 0, b = quarter, c = quarter * 2, d = quarter * 3;
                a < quarter | b < quarter * 2 | c < quarter * 3 | d < quarter * 4;
                a++, b++, c++, d++)
            {
                Console.WriteLine($"| {ignores[a],width}{ignores[b],width}{ignores[c],width}{ignores[d],width} |");
            }
        }

        public static void ShowIgnore(string types)
        {
            string ingnore = Api.GetIgnore(types.Replace(" ", "").ToLower());
            if (ingnore != "")
            {
                Console.WriteLine(ingnore);
                ClipboardHelper.SetText(ingnore);
                Console.WriteLine("This .gitignore is written in a clipboard.");
            }
        }
    }
}