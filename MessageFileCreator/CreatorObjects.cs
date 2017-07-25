namespace MessageFileCreator
{
    internal sealed class Account
    {
        public string Login
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }

        public Account(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
    internal sealed class Message
    {
        public string Sender
        {
            get;
            set;
        }
        public string Reciever
        {
            get;
            set;
        }
        public string MessageText
        {
            get;
            set;
        }

        public Message(string sender, string reciever, string text)
        {
            Sender = sender;
            Reciever = reciever;
            MessageText = text;
        }
        public override string ToString()
        {
            return string.Format("{0};{1};{2}",
                Sender, Reciever, MessageText);
        }
    }
}