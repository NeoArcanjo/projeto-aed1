namespace Aed1
{
    static class SendMail
    {

switch (menu1){
        case "1":
        
        
        bool flag1 = false;
        while(flag1 == false){
          bool login = Acesso.GetLogin();
          if (login == false){
            
          }
          else{
            
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
 
    }
}