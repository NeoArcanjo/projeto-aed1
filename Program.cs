namespace Aed1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool status = true;
            while (status)
            {
                C.Cls();
                C.W("----- Menu MailBOX IDEAL -----");
                C.W("1. Entrar\n2. Cadastrar\n3. Sair");

                string action = C.R();
                C.Cls();

                switch (action)
                {
                    case "1":
                        C.W("ENTRAR");
                        C.E();
                        break;

                    case "2":
                        Acesso.Cadastro();
                        C.W("Cadastrado com sucesso");
                        C.E();
                        break;

                    case "3":
                        C.W("SAIR");
                        C.E();
                        status = false;
                        C.Cls();
                        break;
                }
            }
        }
    }
}