using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Aed1.Class;
using Aed1.Extras;
using CsvHelper;

namespace Aed1.Static_Class
{
    static class Acesso
    {
        public static string userfile = "/home/sylon/RiderProjects/Aed1/Files/Usuario.csv";
        public static void Cadastro()
        {
            int id;
            string nome;
            string email;
            string senha;

            C.Cls();

            id = LastId(Path.GetDirectoryName("/home/sylon/RiderProjects/Aed1/Files/Usuario.csv")) + 1;
            C.W(id.ToString());
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
            return ReadInCsv(userfile);
        }

        public static (bool, Usuario) Entrar(string email, string senha)
        {
            var usuarios = GetUsuarios();
            foreach (string[] usuario in usuarios)
            {
                if (usuario[2] == email && usuario[3] == senha)
                {
                    return (true, new Usuario(int.Parse(usuario[0]),usuario[1],usuario[2],usuario[3]));
                }
            }
            return (false, new Usuario(0, "", "", ""));
        }
        
        public static List<string[]> ReadInCsv(string absolutePath) //Limst<string>
        {
            C.Cls();
            List<string[]> allValues = new List<string[]>();
            using (var reader = new StreamReader(absolutePath))
            {
                while (!reader.EndOfStream)
                {
                    var row = reader.ReadLine();
                    if (row != null)
                    {
                        var columns = row.Split(';');
                        allValues.Add(columns);
                    }
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
                reader.ReadLine();
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
                while (reader.ReadLine()!="")
                {
                    count++;
                }
            }
            return count;
        }

        public static void Salvar(Object objeto)
        {
            var filename = objeto.ToString().Replace('.', '/').Replace("Class","Files");
            var file = "/home/sylon/RiderProjects/" + filename + ".csv";
            C.W(file);
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