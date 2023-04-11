using System;
using System.Collections;
using System.Collections.Generic;

namespace CardExample.Services;

/// <summary>
/// Represents a service for managing the game.
/// </summary>
public sealed class GameService
{
    private readonly Random _random;
    private readonly PlayerService _playerService;
    private readonly DeckService _deckService;

    public GameService(PlayerService playerService, DeckService deckService)
    {
        _random = new Random();
        _playerService = playerService;
        _deckService = deckService;
    }

    /// <summary>
    /// Runs the game to completion.
    /// </summary>
    public void Run()
    {
        int turn = 0;
        bool behaviorsApplied = false;

        do
        {
            turn++;
            Player nextPlayer = _playerService.GetNextPlayer();

            // Get a target at random for demonstration purposes.
            // This can be any player, including the sender.
            // Normally the player would select a target directly.
            Player target = _playerService.GetRandomTarget();

            // Pick one of the player's cards at random.
            // This is only random for the example.
            Card card = nextPlayer.Hand[_random.Next(0, nextPlayer.Hand.Count)];

            // Display what card is being played, by who, and targeting who.
            Console.WriteLine($"Player `{nextPlayer.Id}` uses `{card.Name}` against player `{target.Id}`.");
            Console.WriteLine($"    Player Details: {nextPlayer.Health}H, {nextPlayer.Mana}M, {nextPlayer.Hand.Count}C");
            Console.WriteLine($"    Target Details: {target.Health}H, {target.Mana}M, {target.Hand.Count}C");

            // Be sure to remove the card from the player's hand as we play it.
            _ = nextPlayer.Hand.Remove(card);

            // Apply any behaviors associated with the card.
            foreach (CardBehavior behavior in card.Behaviors)
            {
                behaviorsApplied = true;
                Console.WriteLine($"    Behavior: {card.Name} -> {card.Value}");
                behavior.Apply(card, target);
            }

            // Apply the immediate impact of the card.
            target.Health -= card.Value;

            // Make the player draw a new card.
            if (_deckService.TryDraw(1, out IEnumerable<Card> newCards))
                nextPlayer.Hand.AddRange(newCards);

            Console.WriteLine($"    Result:");
            Console.WriteLine($"        Player Details: {nextPlayer.Health}H, {nextPlayer.Mana}M, {nextPlayer.Hand.Count}C");
            Console.WriteLine($"        Target Details: {target.Health}H, {target.Mana}M, {target.Hand.Count}C");
            Console.WriteLine();

            // Continue iterating until only one player stands.
        } while (_playerService.GetRemainingPlayerCount() > 1);

        Console.WriteLine($"Game completed in {turn} turns.");
        if (behaviorsApplied)
            Console.WriteLine("Behaviors were applied during this simulation.");

        Console.WriteLine($"Player {_playerService.GetWinner()?.Id ?? -1} wins.");
    }
}