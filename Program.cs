namespace Aed1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool status = true;
            while (status == true)
            {
                C.c();
                C.w("----- Menu MailBOX IDEAL -----");
                C.w("1. Entrar\n2. Cadastrar\n3. Sair");

                string action = C.r();
                C.c();

                switch (action)
                {
                    case "1":
                        C.w("ENTRAR");
                        C.e();
                        break;

                    case "2":
                        Acesso.cadastro();
                        C.w("Cadastrado com sucesso");
                        C.e();
                        break;

                    case "3":
                        C.w("SAIR");
                        C.e();
                        status = false;
                        C.c();
                        break;
                }
            }
        }
    }
}