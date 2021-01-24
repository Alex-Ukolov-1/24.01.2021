using System;
using System.Collections.Generic;
using System.Text;

namespace fabric_method_cinema
{
    public class TelegramMessanger : MessangerBase
    {
        public TelegramMessanger(string name, string password) : base(name, password)
        {

        }

       
        public override bool Authorize()
        {
            Console.WriteLine($"подтверждение в кинотеатре для {UserName} и языком {Password}");
            return true;
        }

        public override IMessage CreateMessage(string text, string source, string target)
        {
            var message = new TelegramMessage(text, source, target);
            return message;
        }

    }
}
