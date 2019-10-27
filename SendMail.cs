using System.Collections.Generic;

namespace Aed1
{
    static class SendMail
    {
        static void Menu()
        {
            var option = C.Input("1. Ler\n2. Enviar\n3. Apagar\n4. Sair");
            switch (option)
            {
                case "1":
                    //FUNCAO LER MENSAGENS PROCURANDO PELO PROPRIO EMAIL
                    break;

                case "2":
                    var flag = true;
                    var resp = "";
                    while (flag)
                    {
                        var contato = C.Input("Destinatário: ");
                        if (ValidateDestination(contato))
                        {
                            Email.WriteMail(contato);
                            C.W("Email enviado com sucesso!");
                        }
                        else
                        {
                            resp = C.Input("Email do destinatário inválido.\nDigite novamente ou digite 3 para sair.");
                            flag = (resp != "3");
                        }
                    }

                    break;
            }

            C.E();
        }
        
        public static void WriteMail(string remetcontato)
        {
            
            assunto = C.Input("Digite o assunto da mensagem: ");
            mensagem = C.Input("Digite sua mensagem: ");
            // FUNCAO PARA ENVIAR MENSAGEM.
        }
        static public bool ValidateDestination(string contato)
        {
            var usuarios = AllEmails();
            return usuarios.Contains(contato);
        }

        static List<string> AllEmails()
        {
            var bd = Acesso.GetUsuarios();
            List<string> emails = new List<string>();
            foreach (var row in bd)
            {
                emails.Add(row[2]);
            }

            return emails;
        }
        public static string MsgBody()
        {
            

            return new string();
        }
    }
}