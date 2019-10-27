using System;
using System.Collections.Generic;

namespace Aed1.Class
{
    class Usuario
    {
        public Usuario(int id = default, string nome = null, string email = null, string senha = null)
        {
            _id = id;
            _nome = nome ?? throw new ArgumentNullException(nameof(nome));
            _email = email ?? throw new ArgumentNullException(nameof(email));
            _senha = senha ?? throw new ArgumentNullException(nameof(senha));
        }
        public int Id
        {
            get => _id;
        }
        
        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Senha
        {
            get => _senha;
            set => _senha = value;
        }

        public void AddContato(string Nome)
        {
            _contatos.Add(Nome);
        }
        
        private int _id;
        private string _nome;
        private string _email;
        private string _senha;
        private List<string> _contatos;

        public List<string> Contatos => _contatos;
    }
}