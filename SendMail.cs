using System;
using System.Collections.Generic;

namespace Aed1
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
                        //FUNCAO LER MENSAGENS PROCURANDO PELO PROPRIO EMAIL
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
                        flag = false;
                        break;
                    }
                }

                C.E();
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
                    Frame("Mailbox ou senha inválidos.\nTente novamente!");
                }
                else
                {
                    usuario = login.Item2;
                    Frame(usuario.Nome + " logado(a) com sucesso!");
                }
            }
            
            return usuario;
        }

        static void Frame(string texto)
        {
            C.Cls();
            C.W(texto);
            C.E();
            C.Cls();
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