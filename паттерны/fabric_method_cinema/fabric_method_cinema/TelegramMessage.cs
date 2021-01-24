using System;
using System.Collections.Generic;
using System.Text;

namespace fabric_method_cinema
{
    public class TelegramMessage : MessageBase
    {
        public TelegramMessage(string text, string source, string target) : base(text, source, target) { }
        public override void Send()
        {
            Console.WriteLine($"кинотеатр: Фильм {Source} и языком {Target}: {Text}");
        }
    }
}

