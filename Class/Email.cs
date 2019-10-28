using System;

namespace Aed1.Class
{
    class Email
    {
        public string Remetente
        {
            get => _remetente;
        }

        public string Destinatario
        {
            get => _destinatario;
            set => _destinatario = value;
        }

        public string Assunto
        {
            get => _assunto;
            set => _assunto = value;
        }

        public string Mensagem
        {
            get => _mensagem;
            set => _mensagem = value;
        }

        public DateTime DateTime
        {
            get => _dateTime;
        }

        public Email(string remetente = null, string destinatario = null, string assunto = null, string mensagem = null)
        {
            _remetente = remetente;
            _destinatario = destinatario;
            _assunto = assunto;
            _mensagem = mensagem;
            _dateTime = DateTime.Now;
        }

        private string _remetente;
        private string _destinatario;
        private string _assunto;
        private string _mensagem;
        private DateTime _dateTime;
        
        

        public static string ReadMail()
        {
            //FUNCAO 
            return "hello";
        }
    }
}