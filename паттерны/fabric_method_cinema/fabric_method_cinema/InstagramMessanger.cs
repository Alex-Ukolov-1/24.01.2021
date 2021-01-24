using System;
using System.Collections.Generic;
using System.Text;

namespace fabric_method_cinema
{
    public class InstagramMessanger : MessangerBase
    {
      
        public InstagramMessanger(string name, string password) : base(name, password)
        {
        }

        public override bool Authorize()
        {
            Console.WriteLine($"Авторизация в onlineluxor пользователя с именем {UserName} и паролем {Password}");
            return true;
        }

        public override IMessage CreateMessage(string text, string source, string target)
        {
            var message = new InstagramMessage(text, source, target);
            return message;
        }
    }
}
