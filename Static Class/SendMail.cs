using System.Collections.Generic;
using Aed1.Class;
using Aed1.Extras;

namespace Aed1.Static_Class
{
    static class SendMail
    {
        public static void Menu(string usermail)
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
                        C.Cls();
                        var flag2 = true;
                        var resp = "";
                        while (flag2)
                        {
                            var contato = C.Input("Destinatário: ");
                            if (ValidateDestination(contato))
                            {
                                flag2 = false;
                                var assunto = C.Input(("Assunto: "));
                                C.W("");
                                var mensagem = C.Input("Mensagem: ");
                                WriteMail(usermail, contato, assunto, mensagem);
                                C.Frame("Email enviado com sucesso!");
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

        public static void SalvarEmail(Email email, int idRem, int idDest)
        {
            var filename = email.Assunto;
            var file1 = "/home/sylon/RiderProjects/Aed1/Files/" + idRem + "/Enviados/" + filename + ".csv";
            C.Touch(file1);
            Acesso.Salvar(email, file1);
            var file2 = "/home/sylon/RiderProjects/Aed1/Files/" + idDest + "/Recebidos/" + filename + ".csv";
            C.Touch(file2);
            Acesso.Salvar(email, file2);
        }

        public static int IdUserMail(string email)
        {
            var users = Acesso.GetUsuarios();
            foreach (var user in users)
            {
                if (user[2] == email)
                {
                    return int.Parse(user[0]);
                }
            }
            return 0;
        }
        
        public static void WriteMail(
            string remetente, string destinatario, string assunto = null, string mensagem = null)
        {
            var idRem = IdUserMail(remetente);
            var idDest = IdUserMail(destinatario);
            var email = new Email(remetente, destinatario, assunto, mensagem);
            SalvarEmail(email, idRem, idDest);
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