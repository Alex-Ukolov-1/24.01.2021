using System;
using System.Collections.Generic;
using System.Text;

namespace fabric_method_cinema
{
    public class TwitterMessanger: MessangerBase
    {
        public TwitterMessanger(string name, string password) : base(name, password)
        {

        }
        public override bool Authorize()
        {
            Console.WriteLine($"закачка 30.10.2020 {UserName} и просмотр в {(DateTime.Now)} файл языка {Password}");
            return true;
        }

        public override IMessage CreateMessage(string text, string source, string target)
        {
            var message = new TwitterMessage(text, source, target);
            return message;
        }
    }
}
