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
/*
 *class MainClass {
  public static void Main (string[] args) {
    bool status = true;
    while (status == true){
      C.c();
      C.w("----- Menu MailBOX IDEAL -----");
      C.w("1. Entrar\n2. Cadastrar\n3. Sair");

      string menu1 = C.r();
      C.c();

 *         
        
switch (menu1){
        case "1":
        
        
        bool flag1 = false;
        while(flag1 == false){
          bool login = Acesso.GetLogin();
          if (login == false){
            C.W("mailBOX ou senha inválidos.\nTente novamente!")
            C.E();
          }
          else{
            C.W("Usuario logado com sucesso!")
            flag1 true
        
        C.w("1. Ler\n2. Enviar\n3. Apagar\n4. Sair");

        string menu2 = C.R();

        switch (menu2){
          case "1":
            //FUNCAO LER MENSAGENS PROCURANDO PELO PROPRIO EMAIL
          
          case "2":
            bool flag3 = false;
            while(flag3 == false){
              var contato = Acesso.Contato();
              Email.WriteMail(contato);
              C.W("Email enviado com sucesso!")


            }
            
              }
            }
            C.e();
            break;
 */
                switch (action)
                {
                    case "1":
                        C.W("ENTRAR");
                        Acesso.ReadInCsv("/home/sylon/RiderProjects/Aed1/Usuario.csv");
                        /*
                         * var list =
                          
                        foreach (var row in list)
                        {
                            C.W(row);
                        }
                        */ 
                        C.E();
                        break;

                    case "2":
                        Acesso.Cadastro();
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