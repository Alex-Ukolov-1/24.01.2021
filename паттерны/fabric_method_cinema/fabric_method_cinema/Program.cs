using System;

namespace fabric_method_cinema
{
    class Program
    {
        public string run2(string c)
        {

            switch (c)
            {
                case "1":
                    {
                        c = ("французский");
                        break;
                    }
                case "2":
                    {
                        c = ("английский");
                        break;
                    }
                case "3":
                    {
                        c = ("русский"); ;
                        break;
                    }
            }
            return (c);
        }


        public string run(string c)
        {
           
            switch (c)
            {
                case "1":
                    {
                        c = ("Дюнкерк");
                        break;
                    }
                case "2":
                    {
                        c = ("турецкий гамбит");
                        break;
                    }
                case "3":
                    {
                        c = ("восточный_экспресс"); ;
                        break;
                    }
            }
            return (c);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("выберите один из фильмов(введите цифру)! 1-Дюнкерк,2-Турецкий_гамбит,3-Восточный_экспресс");
            Program star1;
            star1 = new Program();
            string number;
            number = Console.ReadLine();
            Console.WriteLine(star1.run(number));

            Console.WriteLine(" ");

            Console.WriteLine("выберите один из языков(введите цифру)! 1-французский,2-английский,3-русский");
            Program star2;
            star2 = new Program();
            string number2;
            number2 = Console.ReadLine();
            Console.WriteLine(star2.run2(number2));

            Console.WriteLine(" ");

            var messanger = new TestMessanger(star1.run(number), star2.run2(number2)); 
            messanger.SendMessage("4 минуты!", star1.run(number), star2.run2(number2));

            Console.WriteLine(" ");

            var twitter = new TwitterMessanger(star1.run(number), star2.run2(number2));
            var twit = twitter.CreateMessage("длительность:90 минут!", star1.run(number), "Джаник Файзиев");
            twit.Send();

            Console.WriteLine(" ");

            var instagram = new InstagramMessanger("AlexceyUkolov", "reloadkeys");
            var photo = instagram.CreateMessage("win.jpg", star1.run(number), "Winderton");
            photo.Send();

            Console.WriteLine(" ");
            

            Console.WriteLine("Хотите поменять файл языка?! нажмите клавишу 'enter', если нет, то нажмите клавишу 'escape'");
            while (true)
            {
                if (Console.ReadKey(false).Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("Enter pressed");


                    Console.WriteLine("выберите файл языка для фильма(введите цифру)! 1-французский,2-английский,3-русский");
                    Program star3;
                    star3 = new Program();
                    string number3;
                    number3 = Console.ReadLine();
                    Console.WriteLine(star3.run2(number3));

                    Console.WriteLine(" ");


                    var qqq = new TelegramMessanger(star1.run(number), star3.run2(number3));
                    var text= qqq.CreateMessage("!", star1.run(number), star3.run2(number3));
                    text.Send();

                    Console.WriteLine(" ");

                    return;
                }
            }
            Console.Read();
        }
    }
}
