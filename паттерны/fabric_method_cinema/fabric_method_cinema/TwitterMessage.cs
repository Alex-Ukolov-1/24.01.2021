using System;
using System.Collections.Generic;
using System.Text;

namespace fabric_method_cinema
{
    public class TwitterMessage : MessageBase
    {
        public TwitterMessage(string text, string source, string target) : base(text, source, target)
        {
            if (text.Length <= 140)
            {
                Text = text;
            }
            else
            {
                Text = text.Substring(0, 140);
            }
        }

        public override void Send()
        {
            Console.WriteLine($"Люксор: Фильм {Source} от режисера {Target}: {Text}");
        }
    }
}
