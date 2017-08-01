using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BlackJack
{
    //Тип колоды
    enum DeckType
    {
        Standar36 = 36,
    }

    //Для определения старшинства карт
    enum CardValue
    {
        Jack = 2,
        Lady,
        King,
        card6 = 6,
        card7,
        card8,
        card9,
        card10,
        Ace,
    }

    //Для масти карты
    enum CardSuit
    {
        Spades,
        Diamond,
        Clubs,
        Hearts,
    }

    //Карта
    struct Card
    {
        public CardValue Value;
        public CardSuit Suit;
    }

    //Базовый класс для набора карт
    abstract class CardsSet
    {
        protected Card[] Cards;

        public CardsSet() { }
        

        //Показать карты из колоды, начиная со start и length кол-во 
        public void ShowDeck(int start, int length)
        {
            if (length > (this.Cards.Length - start))
            {
                Console.WriteLine("Can't show deck: out of range");
            }
            for (int i = start; i < length; i++)
            {
                Console.WriteLine(this.Cards[i].Value + " " + this.Cards[i].Suit);
            }
        }
    }

    //Описание колоды карт
    class Deck : CardsSet
    {
        private int numOfCards;

        //Создать определённый тип колоды
        public Deck(DeckType type) 
        {
            if (type == DeckType.Standar36)
            {
                numOfCards = 36;
                Cards = new Card[numOfCards];
                for(int suit = 0,counter = 0; suit < 4; suit++)
                {
                    for (int value = 2; value < 12; value++)
                    {
                        if(value == 5)
                        {
                            value++;
                        }
                        Cards[counter] = new Card
                        {
                            Value = (CardValue)value,
                            Suit = (CardSuit)suit
                        };
                        counter++;
                    }
                }
            }
        }


        //Перетасовать колоду
        public void Shuffle(Random rand)
        {
            Console.WriteLine("Shuffling ...");
            Thread.Sleep(500);
            Console.WriteLine("Shuffling ..");
            Thread.Sleep(500);
            Console.WriteLine("Shuffling ..");
            Thread.Sleep(500);
            Console.WriteLine("Shuffling ..");

            for (int i = 0; i < this.Cards.Length; i++)
            {
                int j = rand.Next(0, numOfCards - 1);
                var temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
        }



        //Выдать верхнюю карту и положить её под низ
        public Card GiveCard()
        {
            Card temp = this.Cards[this.Cards.Length - 1];

            for(int i = this.Cards.Length - 1; i > 1; i--)
            {
                this.Cards[i] = this.Cards[i - 1];
            }
            this.Cards[0] = temp;
            return temp;
        }
    }

    //Описание набора карт для BJ у игрока
    class BlackJackSet : CardsSet
    {
        //Считает количество карт в наборе
        public int NumOfCArds { get; private set; }

        //Выделить место дл набора карт у игрока
        public BlackJackSet(int cardNum)
        {
            this.Cards = new Card[cardNum]; 
            NumOfCArds = 0;
        }

        //Посчитать очки для текущего количества карт
        public int CalcPoints
        {
            get
            {
                if (this.NumOfCArds == 0)
                    return 0;
                int result = 0;
                for (int i = 0; i < NumOfCArds; i++)
                {
                    result += (int)this.Cards[i].Value;
                }
                return result;

            }
        }


        //Сбрасывает набор карт
        public void Reset()
        {
            NumOfCArds = 0;
            for(int i = 0; i < NumOfCArds; i++)
            {
                this.Cards[i] = new Card();
            }
        }

        //Взять карту в набор
        public void TakeCard(Card takenCard)
        {
            this.Cards[NumOfCArds++] = takenCard;
        }
    }

    class Player
    {
        public BlackJackSet BJSet { get; private set; }
        public int NumOfBJVictories { get; set; }

        public Player()
        {
            BJSet = new BlackJackSet(34);
            NumOfBJVictories = 0;
        }
    }

    class BlackJackGame
    {
        private Deck GameDeck;
        private BlackJackSet UserSet;
        private BlackJackSet CompSet;
        private Random Rand;

        public BlackJackGame(BlackJackSet Computer, BlackJackSet User)
        {
            Rand = new Random();
            GameDeck = new Deck(DeckType.Standar36);
            CompSet = Computer;
            UserSet = User;
        }

        private void DistributionOfCards(string Choice)
        {
            BlackJackSet[] sets;
            if (Choice == "1")
            {
               sets = new BlackJackSet[2] { UserSet, CompSet };
            }
            else //if (Choice == "2")
            {
                sets = new BlackJackSet[2] { CompSet, UserSet };
            }
            for (int i = 1; i <= 4; i++)
            {
                sets[i % 2].TakeCard(GameDeck.GiveCard());
            }
        }

        private void UserGame()
        {
            string userChoise = null;
            int userCounter = 0;
            do
            {
                if (userCounter != 0)
                {
                    if (userChoise != "y")
                    {
                        Console.Clear();
                        Console.Beep(500, 200);
                        Console.Write("I don't understand ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(userChoise);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("!!!");
                        Console.WriteLine();
                        Console.WriteLine("You have: ");
                        UserSet.ShowDeck(0, UserSet.NumOfCArds);
                        Console.WriteLine();
                        Console.WriteLine("It's: " + UserSet.CalcPoints + " points");
                        Console.WriteLine("Take one more card? y/n");
                        userChoise = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        UserSet.TakeCard(GameDeck.GiveCard());
                    }
                }
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("You have: ");
                UserSet.ShowDeck(0, UserSet.NumOfCArds);
                Console.WriteLine();
                Console.WriteLine("It's: " + UserSet.CalcPoints + " points");
                Console.WriteLine("Take one more card? y/n");
                userChoise = Console.ReadLine();

                userCounter++;
            }
            while (userChoise != "n");
        }

        private void CompGame()
        {
            Console.Clear();
            Console.WriteLine("My turn");
            Thread.Sleep(600);
            bool compTake = true;        //Флаг для решения компьютера брать ли ещё карту 
            int compCounter = 0;         //Счётчик количества циклов компьтера для принятия решения
            do
            {
                int decision = Rand.Next(3, 10);
                if ((CompSet.CalcPoints + decision) > 21)
                {
                    compTake = false;
                }
                else
                {
                    Console.WriteLine("I take one more");
                    Thread.Sleep(400);
                    compTake = true;
                    CompSet.TakeCard(GameDeck.GiveCard());
                }

                compCounter++;
            }
            while (compTake);  //Компьтер принял решение
        }

        private bool ShowResults()
        {
            Console.Clear();
            Console.WriteLine("You have");
            Console.WriteLine();
            UserSet.ShowDeck(0, UserSet.NumOfCArds);
            Console.WriteLine();
            Console.WriteLine("It's " + UserSet.CalcPoints + " points");
            Console.WriteLine();
            Console.WriteLine("I have");
            Console.WriteLine();
            CompSet.ShowDeck(0, CompSet.NumOfCArds);
            Console.WriteLine();
            Console.WriteLine("It's " + CompSet.CalcPoints + " points");

            Console.WriteLine();

            //Флаги переполнения
            bool userOverflow = UserSet.CalcPoints > 21;
            bool compOverflow = CompSet.CalcPoints > 21;
            //Флаги выигрыша
            bool userWin = false;
            bool compWin = false;

            //Сравниваем результаты и подводим итоги игры
            if (userOverflow && !compOverflow)
            {
                compWin = true;
                userWin = false;
            }
            else if (!userOverflow && compOverflow)
            {
                compWin = false;
                userWin = true;
            }
            else if (!userOverflow && !compOverflow)
            {
                if (UserSet.CalcPoints > CompSet.CalcPoints)
                {
                    userWin = true;
                    compWin = false;
                }
                else if (UserSet.CalcPoints < CompSet.CalcPoints)
                {
                    compWin = true;
                    userWin = false;
                }
            }
            else
            {
                if (UserSet.CalcPoints < CompSet.CalcPoints)
                {
                    userWin = true;
                    compWin = false;
                }
                else if (UserSet.CalcPoints > CompSet.CalcPoints)
                {
                    compWin = true;
                    userWin = false;
                }
            }
            if (compWin)
            {
                Console.WriteLine("I won");
                return false;
            }
            else if (userWin)
            {
                Console.WriteLine("You won");
                return true;
            }
            else
            {
                Console.WriteLine("It's draw");
                return false;
            }
        }

        public bool PlayGame()
        {
            GameDeck = new Deck(DeckType.Standar36);
            CompSet.Reset();
            UserSet.Reset();
            Console.WriteLine("Game starts ...");
            Console.WriteLine();
            //Перемешивание колоды
            GameDeck.Shuffle(Rand);

            string choiseFirst = "";
            do
            {
                Console.Clear();
                Console.Beep(500, 200);
                Console.WriteLine("Who will take firt card?");
                Console.WriteLine("1 - You");
                Console.WriteLine("2 - Computer");
                choiseFirst = Console.ReadLine();
                if ((choiseFirst == "1") || (choiseFirst == "2"))
                    break;
            }
            while (true);

            DistributionOfCards(choiseFirst);

            if (choiseFirst == "1")
            {
                UserGame();
                CompGame();
            }
            else
            {
                CompGame();
                UserGame();
            }
            return ShowResults();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Black Jack";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            //Цикл в которос происходит игра
            Player user = new Player();
            Player comp = new Player();
            BlackJackGame BlackJack = new BlackJackGame(comp.BJSet, user.BJSet);
            string gameChoise = "y";
            int gameCounter = 0;
            do
            {
                Console.Clear();
                if(gameChoise != "y")
                {
                    Console.Beep(500, 200);
                    Console.Write("I don't understand ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(gameChoise);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("!!!");
                    Console.WriteLine("More game? y/n");
                    gameChoise = Console.ReadLine();
                    continue;
                }
                bool whoWin;
                whoWin = BlackJack.PlayGame();
                if(whoWin)
                {
                    user.NumOfBJVictories++;
                }
                else
                {
                    comp.NumOfBJVictories++;
                }
                gameCounter++;

                Console.WriteLine("More game? y/n");
                gameChoise = Console.ReadLine();
            }
            while (gameChoise != "n");

            Console.Clear();
            Console.WriteLine("Your victories:" + user.NumOfBJVictories);
            Console.WriteLine("Comp victories:" + comp.NumOfBJVictories);

            Console.ReadLine();
        }
    }
}
