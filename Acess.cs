using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace Aed1
{
    static class Acesso
    {
        public static void Cadastro()
        {
            int id;
            string nome;
            string email;
            string senha;

            C.Cls();

            id = LastId("/home/sylon/RiderProjects/Aed1/Usuario.csv") + 1;
            nome = C.Input("Digite seu nome: ");
            email = C.Input("Digite seu email: ");
            email = email.Contains('@') ? email : email + "@mailbox.ideal";
            senha = C.Input("Digite sua senha: ");

            var usuario = new Usuario(id, nome, email, senha);
            Salvar(usuario);
            C.W(usuario.Nome + " cadastrado(a) com sucesso");
        }

        public static List<string[]> GetUsuarios()
        {
            return ReadInCsv("/home/sylon/RiderProjects/Aed1/Usuario.csv");
        }

        public static bool entrar(string email, string senha)
        {
            var usuarios = GetUsuarios();
            foreach (string[] usuario in usuarios)
            {
                if (usuario[2] == email && usuario[3] == senha)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool GetLogin()
        {
            string email;
            string senha;

            email = C.Input("Digite seu mailbox: ");
            senha = C.Input("Digite sua senha: ");

            return entrar(email, senha);
        }

        


        public static List<string[]> ReadInCsv(string absolutePath) //List<string>
        {
            C.Cls();
            var collumns = new String[4];
            List<string[]> allValues = new List<string[]>();
            using (var reader = new StreamReader(absolutePath))
            {
                var header = reader.ReadLine();
                string row;
                while (!reader.EndOfStream)
                {
                    row = reader.ReadLine();
                    collumns = row.Split(';');
                    allValues.Add(collumns);
                }
            }

            return allValues;
        }

        public static int LastId(string absolutePath) //List<string>
        {
            var id = new int();
            var collumns = new String[4];
            using (var reader = new StreamReader(absolutePath))
            {
                string row;
                var header = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    row = reader.ReadLine();
                    collumns = row.Split(';');
                    id = int.Parse(collumns[0]);
                }
            }
            return id;
        }

        public static int CountLinesCsv(string file)
        {
            var count = 0;
            using (var reader = new StreamReader(file))
            {
                string row;
                while (!reader.EndOfStream)
                {
                    row = reader.ReadLine();
                    count++;
                }
            }
            return count;
        }

        public static void Salvar(Object objeto)
        {
            var filename = objeto.ToString().Replace('.', '/');
            var file = "/home/sylon/RiderProjects/" + filename + ".csv";
            var header = CountLinesCsv(file) == 0;
            using (var writer = new StreamWriter(file, true, Encoding.UTF8))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.HasHeaderRecord = true;
                csvWriter.Configuration.AutoMap(objeto.GetType());
                if (header)
                {
                    csvWriter.WriteHeader(objeto.GetType());
                    csvWriter.NextRecord();
                }
                csvWriter.WriteRecord(objeto);
                csvWriter.NextRecord();
                writer.Flush();
            }
        }
    }
}