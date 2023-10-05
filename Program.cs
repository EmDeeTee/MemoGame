using IDontKnowCs;

Gameboard.Init();
Gameboard.Populate();

Card? prevCard = null;

while (true) {
    Gameboard.Display(true);
    Console.Write("Column: ");
    _ = int.TryParse(Console.ReadLine(), out int col);
    Console.Write("Row: ");
    _ = int.TryParse(Console.ReadLine(), out int row);
        

    try {
        var card = Gameboard.GetCard(col - 1, row - 1);
        if (prevCard != null && card != prevCard) {
            if (prevCard.Value == card.Value) {
                card.SetIsMatched(true);
                prevCard.SetIsMatched(true);
            }
        }
        card.MarkToShow();
        prevCard = card;
    } catch {
        continue;
    }
}

