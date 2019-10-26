using System;
using System.IO;
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

            Console.Clear();
            C.W("Digite seu nome: ");
            nome = C.R();
            C.W("Digite seu email: ");
            email = C.R();
            C.W("Digite sua senha: ");
            senha = C.R();

            var usuario = new Usuario(nome, email, senha);
            Salvar(usuario);
            C.W(usuario.Nome);
        }

        public static void Salvar(Usuario usuario)
        {
            var data = new[]
            {
                usuario
            };
            using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(mem))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.HasHeaderRecord = true;
                csvWriter.Configuration.AutoMap<Usuario>();

                csvWriter.WriteHeader<Usuario>();
                csvWriter.WriteRecords(data);

                writer.Flush();
                var result = Encoding.UTF8.GetString(mem.ToArray());
                Console.WriteLine(result);
            }
        }
    }
}
