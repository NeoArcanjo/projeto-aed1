using System;
using System.IO;
using System.Text;
using CsvHelper;

namespace Aed1
{
    class Acesso
    {
        public static void cadastro()
        {
            string nome;
            string email;
            string senha;

            Console.Clear();
            C.w("Digite seu nome: ");
            nome = C.r();
            C.w("Digite seu email: ");
            email = C.r();
            C.w("Digite sua senha: ");
            senha = C.r();

            var usuario = new Usuario(nome, email, senha);
            salvar(usuario);
            C.w(usuario.getNome());
        }

        public static void salvar(Usuario usuario)
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
