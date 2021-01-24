using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace fabric_method_cinema
{
    public class InstagramMessage:MessageBase
    {
        public InstagramMessage(string text, string source, string target) : base(text, source, target)
        {
            if (File.Exists(text))
            {
                var imageBytes = File.ReadAllBytes(text);
                var base64String = Convert.ToBase64String(imageBytes);
                Text = base64String;
            }
        }
        public override void Send()
        {
            Console.WriteLine($"Compilier: кинолента для {Source} и фото '{Target}': {Text}");
        }
    }
}
