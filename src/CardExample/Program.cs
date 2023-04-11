using System;
using System.Collections.Generic;
using System.Text;

using CardExample.Services;

namespace CardExample;

/// <summary>
/// Represents the entry point of the application.
/// </summary>
internal class Program
{
    private static Random _random;

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
        for (int i = 0; i < 4; i++)
            if (deckService.TryDraw(10, out IEnumerable<Card> initialHand))
                playerService.AddPlayer(initialHand);

        // Create a new game service and run it to completion.
        // This effectively emulates your game loop in Unity.
        var gameService = new GameService(playerService, deckService);
        gameService.Run();

        Console.WriteLine("Press any key to exit.");
        _ = Console.ReadKey();
    }

    /// <summary>
    /// Generates a dummy deck of 250 cards.
    /// </summary>
    internal static IEnumerable<Card> GetDeck()
    {
        var cards = new List<Card>();
        for (int i = 0; i < 250; i++)
        {
            var card = new Card
            {
                Name = $"Card {i}",
                Value = _random.Next(1, 10)
            };
            cards.Add(card);
        }

        return cards;
    }
}
