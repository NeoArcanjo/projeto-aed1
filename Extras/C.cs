using System;

namespace Aed1.Extras
{
    class C
    {
        public static void W(string texto)
        {
            Console.WriteLine(texto);
        }

        public static string R()
        {
            return Console.ReadLine();
        }
        
        public static string Input(string texto = "")
        {
            Console.WriteLine(texto);
            return Console.ReadLine();
        }

        public static void Cls()
        {
            Console.Clear();
        }

        public static void E()
        {
            Console.ReadKey();
        }
        
        public static void Frame(string texto)
        {
            Cls();
            W(texto);
            E();
            Cls();
        }
        
        public static string InputFrame(string texto)
        {
            Cls();
            var output = Input(texto);
            Cls();
            return output;
        }
    }
}