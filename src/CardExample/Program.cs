using System;
using System.Collections.Generic;
using System.Text;

namespace CardExample;

/// <summary>
/// Represents the entry point of the application.
/// </summary>
internal class Program
{
    private readonly static Random _random;

    /// <summary>
    /// The entry point of the application.
    /// </summary>
    internal static void Main()
    {
        // Create a random for generating sample data.
        _random = new Random();

        // Create a new deck service with a dummy deck.
        IEnumerable<Card> dummyDeck = GetDeck();
        var deckService = new DeckService(dummyDeck);

        // Create a new player service and add four new players with 10 cards each.
        var playerService = new PlayerService();
        for (int i = 0; i < 4; i++) {
            IEnumerable<Card> initialHand = deckService.Draw(10);
            playerService.AddPlayer(initialHand);
        }

        // Create a new game service and run it to completion.
        // This effectively emulates your game loop in Unity.
        var gameService = new GameService(deckService, playerService);
        gameService.Run();

        Console.WriteLine("Press any key to exit.");
        _ = Console.ReadKey();
    }

    /// <summary>
    /// Generates a dummy deck of 250 cards.
    /// </summary>
    internal static IEnumerable<Card> GetDeck() {
        var cards = new List<Card>();
        for (int i = 0; i < 250; i++)
        {
            var card = new Card
            {
                Id = i,
                Name = $"Card {i}",
                Value = random.Next(1, 10)
            };
            cards.Add(card);
        }
    }
}
