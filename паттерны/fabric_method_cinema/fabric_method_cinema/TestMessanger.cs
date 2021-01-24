using System;
using System.Collections.Generic;
using System.Text;

namespace fabric_method_cinema
{
    public class TestMessanger
    {
        public string UserName { get; }

        public string Password { get; }

        public bool Connected { get; }

        public TestMessanger(string name, string password)
        {
            if (!(string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(password)))
            {
                UserName = name;
                Password = password;
                Connected = ConnertToTwitter();
            }
            else
            {
                Connected = false;
            }
        }

        public void SendMessage(string text, string source, string target)
        {
            #region Проверяем входные аргументы на корректность
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text), "Текст сообщения не может быть пустым.");
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source), "Имя отправителя не может быть пустым.");
            }

            if (string.IsNullOrWhiteSpace(target))
            {
                throw new ArgumentNullException(nameof(target), "Имя получателя не может быть пустым.");
            }

            if (text.Length > 140)
            {
                throw new ArgumentException("Текст сообщения не может быть больше 140 символов.", nameof(text));
            }
            #endregion

            var message = new TestMessage(text, source, target);
            SendMessageToTwitter(message);
        }

        private void SendMessageToTwitter(TestMessage message)
        {
            Console.WriteLine($"автозагрузка: {message.Text}");
        }

        private bool ConnertToTwitter()
        {
            Console.WriteLine($"вы выбрали фильм {UserName} с языком {Password}");
            return true;
        }
    }
}
