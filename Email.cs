using System;

namespace Aed1
{
    //sleep = Thread.Sleep(2000);

    class Email
    {
        public int Id
        {
            get => _id;
        }

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

        public Email(int id, string remetente = null, string destinatario = null, string assunto = null, string mensagem = null)
        {
            _id = id;
            _remetente = remetente;
            _destinatario = destinatario;
            _assunto = assunto;
            _mensagem = mensagem;
            _dateTime = DateTime.Now;
        }

        private int _id;
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