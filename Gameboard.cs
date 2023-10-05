using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDontKnowCs {
    public static class Gameboard {
        private const int COLUMNS = 3;
        private const int ROWS = 4;
        private static string[] _CARD_VALUES = new string[] { 
            "Jello", "Pop", "Apple", "Milk", "ASSembly", ":)"
        }; //6
        private static List<string> CardValues = Enumerable.Repeat(_CARD_VALUES, 2).SelectMany(x => x).ToList();

        private static Card[,] _Cards = new Card[COLUMNS, ROWS];

        public static void Init() {
            for (int y = 0; y < ROWS; y++) {
                for (int x = 0; x < COLUMNS; x++) {
                    _Cards[x, y] = new("EMPTY");
                }
            }

        }
        public static void Populate() {
            Random random = new();
            int randomColumn = random.Next(COLUMNS);
            int randomRow = random.Next(ROWS);
            if (CardValues.Count == 0)
                return;
            string val = CardValues[random.Next(CardValues.Count)];

            Card selectedCard = _Cards[randomColumn, randomRow];
            if (selectedCard.Value == "EMPTY")
                _Cards[randomColumn, randomRow].Value = val;
            else
                Populate();
            if (_Cards.Cast<Card>().Any(c => c.Value == "EMPTY")) {
                CardValues.Remove(val);
                Populate();
            }
        }

        public static void Display(bool revealAll = false) {
            Console.Clear();
            Console.WriteLine($"Matches: {Card.MatchedPairs}");
            for (int y = 0; y < ROWS; y++) {
                for (int x = 0; x < COLUMNS; x++) {
                    var card = _Cards[x, y];
                    if (card.IsMatched)
                        Console.Write("  *  " + "\t");
                    else if (card.Show) 
                        Console.Write(card.Value + "\t");
                    else
                        Console.Write("-----" + "\t");

                    if (revealAll)
                        Console.Write("<-- " + card.Value + "\t");
                }
                Console.WriteLine();
            }
            if (Card.ShownCards == 2) {
                foreach (Card card in _Cards) {
                    card.MarkToHide();
                    Card.ShownCards = 0;
                }
            }
        }

        public static void SetCard(int col, int row, string value) {
            _Cards[col, row].Value = value;
        }

        public static Card GetCard(int col, int row) {
            return _Cards[col, row];
        }
    }
}
