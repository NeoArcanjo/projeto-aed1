using Aed1.Extras;
using Aed1.Static_Class;

namespace Aed1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool status = true;
            while (status)
            {
                string action =C.InputFrame("----- Menu MailBOX IDEAL -----\n"+"1. Entrar\n2. Cadastrar\n3. Sair");
                switch (action)
                {
                    case "1":
                    {
                        var sessao = SendMail.GetLogin();
                        SendMail.Menu(sessao.Nome);
                    }
                        C.E();
                        break;

                    case "2":
                        Acesso.Cadastro();
                        C.E();
                        break;

                    case "3":
                        status = false;
                        C.Cls();
                        C.W("Até logo!");
                        break;
                }
            }
        }
    }
}