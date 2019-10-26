namespace Aed1
{
    class Usuario
    {
        private string nome;
        private string email;
        private string senha;
        
        public Usuario(string n, string e, string s)
        {
            nome = n;
            email = e;
            senha = s;
        }

        public string getNome()
        {
            return nome;
        }

        public string getEmail()
        {
            return email;
        }

        public string getSenha()
        {
            return senha;
        }
    }
}