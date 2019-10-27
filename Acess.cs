using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace Aed1
{
    class Acesso
    {
        public static void Cadastro()
        {
            string nome;
            string email;
            string senha;

            C.Cls();
            nome = C.Input("Digite seu nome: ");
            email = C.Input("Digite seu email: ");
            email = email.Contains('@') ? email : email + "@mailbox.ideal";
            senha = C.Input("Digite sua senha: ");

            var usuario = new Usuario(0, nome, email, senha);
            Salvar(usuario);
            C.W(usuario.Nome);
            C.W("Cadastrado com sucesso");
        }

        public static string[,] GetUsuarios()
        {
            var vetor = new string[] { };
            var matrix = new string[,] { };
            /*
             * 
             */
            return matrix;
        }


        public static bool entrar(string email, string senha)
        {
            /*
            var usuarios = GetUsuarios();
            foreach (Array usuario in usuarios)
            {
                if (usuario[1] == email && usuario[2] == senha)
                {
                    return true;
                }
            }

            C.W("");
            */
            return false;
        }

        public static bool GetLogin()
        {
            string email;
            string senha;

            email = C.Input("Digite seu mailBOX: ");
            senha = C.Input("Digite sua senha: ");

            return entrar(email, senha);
        }

        public static void Contato()
        {
            var usuarios = new string[] { }; //GetUsuarios();
            bool flag2 = false;
            while (flag2 == false)
            {
                string amigo = C.Input("Digite o email do destinatário: ");
                if (usuarios.Contains(amigo) == false)
                {
                    string resp = C.Input("Email do destinatário inválido.\nDigite novamente ou digite 3 para sair.");
                    if (resp == "3") flag2 = true;
                }
                else
                {
                    //FUNCAO PARA PEGAR ESTE Usuario.
                    //FUNCAO PARA ENVIAR MENSAGEM PARA ESTE USUARIO.
                }
            }
        }


        public static void ReadInCsv(string absolutePath)  //List<string>
        {
            C.Cls();
            var arrIn = new String[4];
            List<string> allValues;
            using (var reader = new StreamReader(absolutePath))
            {
                var header = reader.ReadLine();
                var row = reader.ReadLine();
                var collumns=row.Split(';');
                foreach (var VARIABLE in collumns)
                {
                    C.W(VARIABLE);
                }
            }
            //return allValues.ToList<string>();
        }

        public static void Salvar(Object objeto)
        {
            bool header;
            var data = new[]
            {
                objeto,
            };
            var filename = objeto.ToString().Replace('.', '/');
            var file = "/home/sylon/RiderProjects/" + filename + ".csv";
            using (var reader = new StreamReader(file))
            {
                var row = reader.Read();
                C.W(row.ToString());
                header = row <= 0;
            }

            using (var writer = new StreamWriter(file, true, Encoding.UTF8))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.HasHeaderRecord = header;
                csvWriter.Configuration.AutoMap(objeto.GetType());
                csvWriter.WriteRecords(data);
                writer.Flush();
                Console.WriteLine(file);
            }
        }
    }
}