using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ISmsProvider smsProvider = new ProviderD();
            smsProvider.Send("LoLaksdhgfsjdhgfjsdhgfhjc");
        }
    }

    interface ISmsProvider
    {
        void Send(string messageTest);
    }

    class ProviderA : ISmsProvider
    {
        public void Send(string messageTest)
        {
            //Send SMS
        }

        //ksjahdjasdjhagsjdgajsdgajsgjhgsdajdgbj
    }

    class ProviderB : ISmsProvider
    {
        public void Send(string messageTest)
        {
            throw new NotImplementedException();
        }
    }

    class ProviderD : ISmsProvider
    {
        public void Send(string messageTest)
        {
            throw new NotImplementedException();
        }
    }
}

namespace ConsoleApp2
{
    using ConsoleApp1;
    class ProviderD : ISmsProvider
    {
        public void Send(string messageTest)
        {
            throw new NotImplementedException();
        }
    }
}
