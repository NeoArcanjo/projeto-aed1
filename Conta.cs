using System; // classes fundamentais.
using System.IO; // biblioteca que permite ler e gravar arquivos.
using System.Text; // conversão de caracteres ACSII.
using System.Runtime.Serialization; // converte objetos para bytes para armazenamento.
using System.Runtime.Serialization.Formatters.Binary; // serializar e deserializar objetos.



class Conta{

    public static void cadastro (){
    string nome;
    string email;
    string senha;

    Console.Clear();
    Util.write("Digite seu nome: ");
    nome = Util.read();
    Util.write("Digite seu email: ");
    email = Util.read();
    Util.write("Digite sua senha: ");
    senha = Util.read();

    Usuario usuario = new Usuario();

    usuario.setNome(nome);
    usuario.setEmail(email);
    usuario.setSenha(senha);

    IFormatter formatter = new BinaryFormatter();
    Stream stream = new FileStream("cadastro.txt", FileMode.Create, FileAccess.Write);
    formatter.Serialize(stream,usuario);
    stream.Close();

    stream = new FileStream("cadastro.txt",FileMode.Open,FileAccess.Read);
    Usuario savedUser = (Usuario)formatter.Deserialize(stream);
    Util.write("\n"+savedUser.nome+" cadastrado com sucesso.");
    stream.Close();
    Console.ReadKey();

  }

  public static bool login (){
    string email;
    string senha;
  

    Util.write("Digite seu email:\n");
    email = Util.read();
    Util.write("Digite sua senha:\n");
    senha = Util.read();

    IFormatter formatter = new BinaryFormatter();

    Stream stream = new FileStream("cadastro.txt",FileMode.Open,FileAccess.Read);
    Usuario saveUser = (Usuario)formatter.Deserialize(stream);
    Util.write("\n"+saveUser.nome+" logado com sucesso.");
    stream.Close();

    return true;
   
  }
}