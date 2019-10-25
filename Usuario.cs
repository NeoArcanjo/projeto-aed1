using System;

[Serializable]
class Usuario{

public string nome;
public string email;
public string senha;

public void setNome(string nome){
  this.nome = nome;
}

public string getNome(){
  return nome;
}

public void setEmail(string email){
  this.email = email;
}

public string getEmail(){
  return email;
}

public void setSenha(string senha){
  this.senha =senha;
}

public string getSenha(){
  return senha;
}

}