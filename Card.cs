using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDontKnowCs {
    public class Card {
        public string Value { get; set; }
        /// <summary>
        /// Setting show will cause the card to be shown next time the gameboard is displayed
        /// </summary>
        public bool Show { get; private set; }
        public bool IsMatched { get; private set; }

        public static int ShownCards = 0;
        public static int MatchedCards = 0;
        public static int MatchedPairs = 0;

        public Card(string value) { 
            Value = value;
        }

        public void MarkToShow() {
            Show = true;
            ShownCards++;
        }

        public void MarkToHide() {
            Show = false;
        }

        public void SetIsMatched(bool v) {
            IsMatched = v;
            MatchedCards++;
            MatchedPairs = MatchedCards / 2;
        }
    }
}
