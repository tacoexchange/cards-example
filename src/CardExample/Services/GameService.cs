using System;

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
        do
        {
            Player nextPlayer = _playerService.GetNextPlayer();

            // Get a target at random for demonstration purposes.
            // This can be any player, including the sender.
            // Normally the player would select a target directly.
            Player target = _playerService.GetRandomTarget();

            // Pick one of the player's cards at random.
            // This is only random for the example.
            Card card = nextPlayer.Hand[_random.Next(0, nextPlayer.Hand.Count)];

            // Be sure to remove the card from the player's hand as we play it.
            nextPlayer.Hand.Remove(card);

            // Apply any behaviors associated with the card.
            foreach (CardBehavior behavior in card.Behaviors)
                behavior.Apply(card, target);

            // Apply the immediate impact of the card.
            target.Health -= card.Value;

            // Continue iterating until only one player stands.
        } while (_playerService.GetRemainingPlayerCount() > 1);
    }
}