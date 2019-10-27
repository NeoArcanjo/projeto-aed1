using System;

namespace Aed1
{
    //sleep = Thread.Sleep(2000);

    class Email
    {
        public Email(string remetente = null, string destinatario = null, string assunto = null, string mensagem = null, DateTime dateTime = default)
        {
            _remetente = remetente;
            _destinatario = destinatario;
            _assunto = assunto;
            _mensagem = mensagem;
            _dateTime = dateTime;
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