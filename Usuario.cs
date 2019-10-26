using System;

namespace Aed1
{
    class Usuario
    {
        public Usuario(string nome = null, string email = null, string senha = null)
        {
            _nome = nome ?? throw new ArgumentNullException(nameof(nome));
            _email = email ?? throw new ArgumentNullException(nameof(email));
            _senha = senha ?? throw new ArgumentNullException(nameof(senha));
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

        private string _nome;
        private string _email;
        private string _senha;

    }
}