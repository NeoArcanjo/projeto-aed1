using System.Collections.Generic;
using Aed1.Class;
using Aed1.Extras;

namespace Aed1.Static_Class
{
    static class SendMail
    {
        public static void Menu(string username)
        {
            var flag = true;
            while (flag)
            {
                var option = C.Input("1. Ler\n2. Enviar\n3. Apagar\n4. Sair");
                switch (option)
                {
                    case "1":
                    {
                        C.Frame("Em desenvolvimento");
                        break;
                    }
                    case "2":
                    {
                        var flag2 = true;
                        var resp = "";
                        while (flag2)
                        {
                            var contato = C.Input("Destinatário: ");
                            if (ValidateDestination(contato))
                            {
                                WriteMail(username, contato, "", "");
                                C.W("Email enviado com sucesso!");
                            }
                            else
                            {
                                resp = C.Input(
                                    "Email do destinatário inválido.\nDigite novamente ou digite 3 para sair.");
                                flag2 = (resp != "3");
                            }
                        }
                        break;
                    }
                    
                    case "3":
                    {
                        C.Frame("Em desenvolvimento");
                        break;
                    }
                    case "4":
                    {
                        C.Cls();
                        C.W("Pressione ENTER para retornar ao Menu!!");
                        flag = false;
                        break;
                    }
                }
            }
        }

        public static Usuario GetLogin()
        {
            string email;
            string senha;
            (bool, Usuario) login;
            var flag = true;
            var usuario = new Usuario(0, "", "", "");

            while (flag)
            {
                email = C.Input("Digite seu mailbox: ");
                senha = C.Input("Digite sua senha: ");
                login = Acesso.Entrar(email, senha);
                flag = !login.Item1;
                if (flag)
                {
                    C.Frame("Mailbox ou senha inválidos.\nTente novamente!");
                }
                else
                {
                    usuario = login.Item2;
                    C.Frame(usuario.Nome + " logado(a) com sucesso!");
                }
            }
            
            return usuario;
        }

      
        public static void WriteMail(
            string remetente, string destinatario, string assunto = null, string mensagem = null)
        {
            assunto = C.Input("Digite o assunto da mensagem: ");
            mensagem = C.Input("Digite sua mensagem: ");
            // FUNCAO PARA ENVIAR MENSAGEM.
        }

        static public bool ValidateDestination(string contato)
        {
            var usuarios = AllAccountEmails();
            return usuarios.Contains(contato);
        }

        static List<string> AllAccountEmails()
        {
            var bd = Acesso.GetUsuarios();
            List<string> emails = new List<string>();
            foreach (var row in bd)
            {
                emails.Add(row[2]);
            }
            return emails;
        }

//        public static string MsgBody()
//        {
//            
//
//            return new string();
//        }
    }
}