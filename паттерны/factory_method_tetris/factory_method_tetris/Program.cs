using System;

namespace factory_method_tetris
{
    public class Star
    {
        public int x;
       
        int[,,] array3D = new int[7,4,4]
   {
    {//O
        { 1, 1, 0, 0 },
        { 1, 1, 0, 0 },
        { 0, 0, 0, 0 },
        { 0, 0, 0, 0 }
    },
    {//I
        { 1, 0, 0, 0 },
        { 1, 0, 0, 0 },
        { 1, 0, 0, 0 },
        { 0, 0, 0, 0 }
    },
    {//L
        { 0, 0, 1, 0 },
        { 1, 1, 1, 0 },
        { 0, 0, 0, 0 },
        { 0, 0, 0, 0 }
    },
    {//J
        { 1, 1, 1, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 0 },
        { 0, 0, 0, 0 }
    },
    {//S
        { 0, 0, 0, 0 },
        { 1, 1, 1, 0 },
        { 0, 0, 1, 1 },
        { 0, 0, 0, 0 }
    },
    {//Z
        { 1, 1, 1, 1 },
        { 0, 1, 0, 1 },
        { 1, 0, 0, 1 },
        { 0, 0, 0, 0 }
    },
    {//T
        { 0, 0, 0, 0 },
        { 1, 1, 1, 1 },
        { 1, 0, 0, 1 },
        { 1, 0, 0, 1 }
    }
};
        public void show()
        {

            int x = 1;
            Random RandomNumber1 = new Random();
            int fer = RandomNumber1.Next(4, 4);

            int wer = RandomNumber1.Next(0, 3);

            int zed = RandomNumber1.Next(7, 7);

            int zebra = RandomNumber1.Next(wer, zed);

            for (int i=wer;i<zebra+1;i++)
            {
                for (int j = 0; j < fer; j++)
                {
                    for (int b = 0; b < fer; b++)
                    {

                        if (array3D[i, j, b] == x) Console.Write("*");
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine(" ");
                }
            }    
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("если проект ничего не вывел , попробуйте ещё раз запустить его");
            Console.WriteLine(" ");

            Star star1;
            star1 = new Star();
            do
            {
                star1.show();

                System.Threading.Thread.Sleep(10000);
            }
            while (!Console.KeyAvailable);
            Console.ReadKey();
        }
    }
}
