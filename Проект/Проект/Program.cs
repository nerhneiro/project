using System;

namespace Проект
{
    enum mast
    {
        Пики = 1,
        Буби,
        Черви,
        Крести
    }
    class Program
    {
        static Random md = new Random();
        class Card
        {
            int number;
            mast a;
            public Card()
            {
                number = 1;
                a = (mast)1;
            }
            public Card(int a, int n)
            {
                this.a = (mast)a;
                number = n;
            }
            public int nu
            {
                get { return number; }
                set { number = value; }
            }
            public mast ma
            {
                get { return a; }
                set { a = value; }
            }
        }
        class Coloda
        {
            Card[] cards = new Card[52];
            public Coloda()
            { 
                for(int i = 0; i < cards.Length; i ++)
                {
                    cards[i] = new Card();
                }
                for (int i = 0; i < cards.Length; i++)
                {
                    if (i < 13) { cards[i].nu = i + 2; cards[i].ma = (mast)1; }
                    if (i < 26 && i > 12) { cards[i].nu = i - 11 ; cards[i].ma = (mast)2; }
                    if(i>25 && i < 39) { cards[i].nu = i - 24; cards[i].ma = (mast)3; }
                    if(i>38) { cards[i].nu = i - 37; cards[i].ma = (mast)4; }
                }
            }
            public bool output(int j)
            {
                string m = "1", n = "1";
                int b=0, c=0, ch=0, p=0;
                for(int i = j; i < j + 5 ; i++)
                {
                    /*if ((int)cards[i].ma == 1) { m = "ПИКИ"; p++; }
                    else if ((int)cards[i].ma == 2) { m = "БУБИ"; b++; }
                    else if ((int)cards[i].ma == 3) { m = "ЧЕРВИ"; ch++; }
                    else if ((int)cards[i].ma == 4) { m = "КРЕСТИ"; c++; }*/
                    if (cards[i].nu > 1 && cards[i].nu < 11) n = Convert.ToString(cards[i].nu);
                    else if (cards[i].nu == 11) n = "Валет";
                    else if (cards[i].nu == 12) n = "Дама";
                    else if (cards[i].nu == 13) n = "Король";
                    else if (cards[i].nu == 14) n = "Туз";
                    Console.WriteLine("{0} карта: {1} масть <<{2}>>", i + 1 - j, n, (mast)cards[i].ma);
                }
                if(ch == 5 || c == 5 || p == 5|| b == 5)
                {
                    Console.WriteLine(@"__________________________________
Флэш на раздаче номер {0} ! Игра окончена.
__________________________________", j/5 + 1);
                    return true;
                }
                return false;
            }
            public void change()
            {
                int j;
                Card temp;
                for (int i = 0; i < cards.Length; i++)
                {
                    j = md.Next(cards.Length - 1);
                    temp = cards[j];
                    cards[j] = cards[i];
                    cards[i] = temp;
                }
            }
        }
        static void Main(string[] args)
        {
            Coloda coloda = new Coloda();
            int answer = 1;
            bool win;
            while (answer == 1)
            {
                coloda.change();
                int j = 0, i = 0;
                for (i = 0; i < 10; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("{0} раздача:", j / 5+1);
                    win = coloda.output(j);
                    j += 5;
                    if (win == true) break;
                }
                if (i == 9) Console.WriteLine(@"__________________________________
Карты кончились. Флэша не было. Хотите сыграть еще раз --> напишите 1, иначе игра закончится
__________________________________");
                else Console.WriteLine("Хочешь еще раз попытать свою удачу и сыграть во Флеш? Тогда жми 1, иначе игра закончится");
                try
                {
                    answer = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Спасибо за игру! До свидания.");
                    answer = 0;
                }
            }
        }
    }
}
