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
        //Создать определённый тип колоды
        public Deck(DeckType type) 
        {
            if (type == DeckType.Standar36)
            {
                this.Cards = new Card[36]
                {
                    new Card
                    {
                        Value = CardValue.card6,
                        Suit = CardSuit.Clubs
                    },
                    new Card
                    {
                        Value = CardValue.card7,
                        Suit = CardSuit.Clubs
                    },
                    new Card
                    {
                        Value = CardValue.card8,
                        Suit = CardSuit.Clubs
                    },
                    new Card
                    {
                        Value = CardValue.card9,
                        Suit = CardSuit.Clubs
                    },
                    new Card
                    {
                        Value = CardValue.card10,
                        Suit = CardSuit.Clubs
                    },
                    new Card
                    {
                        Value = CardValue.Jack,
                        Suit = CardSuit.Clubs
                    },
                    new Card
                    {
                        Value = CardValue.Lady,
                        Suit = CardSuit.Clubs
                    },
                    new Card
                    {
                        Value = CardValue.King,
                        Suit = CardSuit.Clubs
                    },
                    new Card
                    {
                        Value = CardValue.Ace,
                        Suit = CardSuit.Clubs
                    },

                    new Card
                    {
                        Value = CardValue.card6,
                        Suit = CardSuit.Hearts
                    },
                    new Card
                    {
                        Value = CardValue.card7,
                        Suit = CardSuit.Hearts
                    },
                    new Card
                    {
                        Value = CardValue.card8,
                        Suit = CardSuit.Hearts
                    },
                    new Card
                    {
                        Value = CardValue.card9,
                        Suit = CardSuit.Hearts
                    },
                    new Card
                    {
                        Value = CardValue.card10,
                        Suit = CardSuit.Hearts
                    },
                    new Card
                    {
                        Value = CardValue.Jack,
                        Suit = CardSuit.Hearts
                    },
                    new Card
                    {
                        Value = CardValue.Lady,
                        Suit = CardSuit.Hearts
                    },
                    new Card
                    {
                        Value = CardValue.King,
                        Suit = CardSuit.Hearts
                    },
                    new Card
                    {
                        Value = CardValue.Ace,
                        Suit = CardSuit.Hearts
                    },

                    new Card
                    {
                        Value = CardValue.card6,
                        Suit = CardSuit.Diamond
                    },
                    new Card
                    {
                        Value = CardValue.card7,
                        Suit = CardSuit.Diamond
                    },
                    new Card
                    {
                        Value = CardValue.card8,
                        Suit = CardSuit.Diamond
                    },
                    new Card
                    {
                        Value = CardValue.card9,
                        Suit = CardSuit.Diamond
                    },
                    new Card
                    {
                        Value = CardValue.card10,
                        Suit = CardSuit.Diamond
                    },
                    new Card
                    {
                        Value = CardValue.Jack,
                        Suit = CardSuit.Diamond
                    },
                    new Card
                    {
                        Value = CardValue.Lady,
                        Suit = CardSuit.Diamond
                    },
                    new Card
                    {
                        Value = CardValue.King,
                        Suit = CardSuit.Diamond
                    },

                    new Card
                    {
                        Value = CardValue.Ace,
                        Suit = CardSuit.Diamond
                    },

                    new Card
                    {
                        Value = CardValue.card6,
                        Suit = CardSuit.Spades
                    },
                    new Card
                    {
                        Value = CardValue.card7,
                        Suit = CardSuit.Spades
                    },
                    new Card
                    {
                        Value = CardValue.card8,
                        Suit = CardSuit.Spades
                    },
                    new Card
                    {
                        Value = CardValue.card9,
                        Suit = CardSuit.Spades
                    },
                    new Card
                    {
                        Value = CardValue.card10,
                        Suit = CardSuit.Spades
                    },
                    new Card
                    {
                        Value = CardValue.Jack,
                        Suit = CardSuit.Spades
                    },
                    new Card
                    {
                        Value = CardValue.Lady,
                        Suit = CardSuit.Spades
                    },
                    new Card
                    {
                        Value = CardValue.King,
                        Suit = CardSuit.Spades
                    },

                    new Card
                    {
                        Value = CardValue.Ace,
                        Suit = CardSuit.Spades
                    }
                };
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
                int j = rand.Next(0, 35);
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

    //Описание набора карт у игрока
    class PlayerSet : CardsSet
    {
        //Считает количество карт в наборе
        public int numOfCArds { get; private set; }

        //Выделить место дл набора карт у игрока
        public PlayerSet(int cardNum)
        {
            this.Cards = new Card[cardNum]; 
            numOfCArds = 0;
        }

        //Посчитать очки для текущего количества карт
        public int CalcPoints()
        {
            if (this.numOfCArds == 0)
                return 0;
            int result = 0;
            for (int i = 0; i < numOfCArds; i++)
            {
                result += (int)this.Cards[i].Value;
            }
            return result;
        }

        //Сбрасывает набор карт
        public void Reset()
        {
            numOfCArds = 0;
            for(int i = 0; i < numOfCArds; i++)
            {
                this.Cards[i] = new Card();
            }
        }

        //Взять карту в набор
        public void takeCard(Card takenCard)
        {
            this.Cards[numOfCArds++] = takenCard;
        }
    }

    //Игра BlackJack
    class BlackJackGame
    {
        private Deck GameDeck;
        private PlayerSet UserSet;
        private PlayerSet CompSet;
        private Random rand;

        public BlackJackGame()
        {
            rand = new Random();
            GameDeck = new Deck(DeckType.Standar36);
            UserSet = new PlayerSet(34);
            CompSet = new PlayerSet(34);
        }

        private void DistributionOfCards(string Choice)
        {
            if (Choice == "1")
            {
                UserSet.takeCard(GameDeck.GiveCard());
                CompSet.takeCard(GameDeck.GiveCard());
                UserSet.takeCard(GameDeck.GiveCard());
                CompSet.takeCard(GameDeck.GiveCard());
            }
            else if (Choice == "2")
            {
                CompSet.takeCard(GameDeck.GiveCard());
                UserSet.takeCard(GameDeck.GiveCard());
                CompSet.takeCard(GameDeck.GiveCard());
                UserSet.takeCard(GameDeck.GiveCard());
            }
        }

        private void UserGame()
        {
            string UserChoise = null;
            int UserCounter = 0;
            do
            {
                if (UserCounter != 0)
                {
                    if (UserChoise != "y")
                    {
                        Console.Clear();
                        Console.Beep(500, 200);
                        Console.Write("I don't understand ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(UserChoise);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("!!!");
                        Console.WriteLine();
                        Console.WriteLine("You have: ");
                        UserSet.ShowDeck(0, UserSet.numOfCArds);
                        Console.WriteLine();
                        Console.WriteLine("It's: " + UserSet.CalcPoints() + " points");
                        Console.WriteLine("Take one more card? y/n");
                        UserChoise = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        UserSet.takeCard(GameDeck.GiveCard());
                    }
                }
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("You have: ");
                UserSet.ShowDeck(0, UserSet.numOfCArds);
                Console.WriteLine();
                Console.WriteLine("It's: " + UserSet.CalcPoints() + " points");
                Console.WriteLine("Take one more card? y/n");
                UserChoise = Console.ReadLine();

                UserCounter++;
            }
            while (UserChoise != "n");
        }

        private void CompGame()
        {
            Console.Clear();
            Console.WriteLine("My turn");
            Thread.Sleep(600);
            bool CompTake = true;        //Флаг для решения компьютера брать ли ещё карту 
            int CompCounter = 0;         //Счётчик количества циклов компьтера для принятия решения
            do
            {
                int Decision = rand.Next(3, 10);
                if ((CompSet.CalcPoints() + Decision) > 21)
                {
                    CompTake = false;
                }
                else
                {
                    Console.WriteLine("I take one more");
                    Thread.Sleep(400);
                    CompTake = true;
                    CompSet.takeCard(GameDeck.GiveCard());
                }

                CompCounter++;
            }
            while (CompTake);  //Компьтер принял решение
        }

        private bool ShowResults()
        {
            Console.Clear();
            Console.WriteLine("You have");
            Console.WriteLine();
            UserSet.ShowDeck(0, UserSet.numOfCArds);
            Console.WriteLine();
            Console.WriteLine("It's " + UserSet.CalcPoints() + " points");
            Console.WriteLine();
            Console.WriteLine("I have");
            Console.WriteLine();
            CompSet.ShowDeck(0, CompSet.numOfCArds);
            Console.WriteLine();
            Console.WriteLine("It's " + CompSet.CalcPoints() + " points");

            Console.WriteLine();

            //Флаги переполнения
            bool UserOverflow = UserSet.CalcPoints() > 21;
            bool CompOverflow = CompSet.CalcPoints() > 21;
            //Флаги выигрыша
            bool UserWin = false;
            bool CompWin = false;

            //Сравниваем результаты и подводим итоги игры
            if (UserOverflow && !CompOverflow)
            {
                CompWin = true;
                UserWin = false;
            }
            else if (!UserOverflow && CompOverflow)
            {
                CompWin = false;
                UserWin = true;
            }
            else if (!UserOverflow && !CompOverflow)
            {
                if (UserSet.CalcPoints() > CompSet.CalcPoints())
                {
                    UserWin = true;
                    CompWin = false;
                }
                else if (UserSet.CalcPoints() < CompSet.CalcPoints())
                {
                    CompWin = true;
                    UserWin = false;
                }
            }
            else
            {
                if (UserSet.CalcPoints() < CompSet.CalcPoints())
                {
                    UserWin = true;
                    CompWin = false;
                }
                else if (UserSet.CalcPoints() > CompSet.CalcPoints())
                {
                    CompWin = true;
                    UserWin = false;
                }
            }
            if (CompWin)
            {
                Console.WriteLine("I won");
                return false;
            }
            else if (UserWin)
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
            Console.WriteLine("Game starts ...");
            Console.WriteLine();
            //Перемешивание колоды
            GameDeck.Shuffle(rand);

            string ChoiseFirst = "";
            do
            {
                Console.Clear();
                Console.Beep(500, 200);
                Console.WriteLine("Who will take firt card?");
                Console.WriteLine("1 - You");
                Console.WriteLine("2 - Computer");
                ChoiseFirst = Console.ReadLine();
                if ((ChoiseFirst == "1") || (ChoiseFirst == "2"))
                    break;
            }
            while (true);

            DistributionOfCards(ChoiseFirst);

            if (ChoiseFirst == "1")
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
            string GameChoise = "y";
            int GameCounter = 0;
            int UserVictories = 0;
            int CompVictories = 0;
            do
            {
                Console.Clear();
                if(GameChoise != "y")
                {
                    Console.Beep(500, 200);
                    Console.Write("I don't understand ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(GameChoise);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("!!!");
                    Console.WriteLine("More game? y/n");
                    GameChoise = Console.ReadLine();
                    continue;
                }
                bool WhoWin;
                BlackJackGame BlackJack = new BlackJackGame();
                WhoWin = BlackJack.PlayGame();
                if(WhoWin)
                {
                    UserVictories++;
                }
                else
                {
                    CompVictories++;
                }
                GameCounter++;

                Console.WriteLine("More game? y/n");
                GameChoise = Console.ReadLine();
            }
            while (GameChoise != "n");

            Console.Clear();
            Console.WriteLine("Your victories:" + UserVictories);
            Console.WriteLine("Comp victories:" + CompVictories);

            Console.ReadLine();
        }
    }
}
