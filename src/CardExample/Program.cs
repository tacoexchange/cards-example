using System;
using System.Collections.Generic;
using System.Linq;
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
        Console.WriteLine("Starting simulation.");
        
        // Create a random for generating sample data.
        _random = new Random();

        // Create a new deck service and load a dummy deck
        var deckService = new DeckService();
        deckService.Load();

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
}
