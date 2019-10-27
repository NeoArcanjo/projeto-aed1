using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using CsvHelper;
using Vanara.Extensions;

namespace Aed1
{
    class Acesso
    {
        public static void Cadastro()
        {
            string nome;
            string email;
            string senha;

            Console.Clear();
            nome = C.Input("Digite seu nome: ");
            email = C.Input("Digite seu email: ");
            email = email.Contains('@') ? email : email + "@mailbox.ideal";
            senha = C.Input("Digite sua senha: ");

            var usuario = new Usuario(0, nome, email, senha);
            Salvar(usuario);
            C.W(usuario.Nome);
        }

        /*
        public static string[] Type(string objeto)
        {
            string pattern = @"[.]\w+";
            var str = new String[2];
            foreach (Match m in Regex.Matches(objeto, pattern))
            {
                str[m.Index] = m.Value;
            }
            return str;
        }
        */

        public static void Salvar(Object objeto)
        {
            bool header;
            var data = new[]
            {
                objeto,
            };
            var filename = objeto.ToString().Replace('.', '/');
            var file = "/home/sylon/RiderProjects/"+filename+".csv";
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
                //if (header)
                //{
                //    csvWriter.WriteHeader<Usuario>();
                //   csvWriter.NextRecord();
                //}
                csvWriter.WriteRecords(data);

                writer.Flush();
                Console.WriteLine(file);
            }
        }
    }
}