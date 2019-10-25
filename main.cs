using System; // classes fundamentais.
using System.IO; // biblioteca que permite ler e gravar arquivos.
using System.Text; // conversão de caracteres ACSII.
using System.Runtime.Serialization; // converte objetos para bytes para armazenamento.
using System.Runtime.Serialization.Formatters.Binary; // serializar e deserializar objetos.



class MainClass {

  public static void Main (string[] args) {
   bool flag = true;
   while (flag == true){
     Console.Clear();
     Util.write("1. Logar \n2. Cadastrar \n3. Sair");
     string action = Util.read();
     
     switch (action){
      case "1":
       Conta.login();
        
        break;

      case "2":
        Conta.cadastro();
        
        break;
      case "3":
        Util.write("Menu Encerrado");
        flag = false;
        break;
     }
   }
  }
}