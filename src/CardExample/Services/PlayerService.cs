using System;
using System.Collections.Generic;
using System.Linq;

namespace CardExample.Services;

/// <summary>
/// Represents a service for managing players.
/// </summary>
public sealed class PlayerService
{
    private int _currentPlayerIndex;
    private readonly Random _random;
    private readonly List<Player> _players;

    /// <summary>
    /// Creates a new <see cref="PlayerService"/> instance.
    /// </summary>
    public PlayerService()
    {
        _random = new Random();
        _players = new List<Player>();
    }

    /// <summary>
    /// Adds the specified player to the game.
    /// </summary>
    /// <param name="player">The player to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="player"/> is <see langword="null"/>.</exception>
    public void AddPlayer(IEnumerable<Card> initialHand)
    {
        if (initialHand is null)
            throw new ArgumentNullException(nameof(initialHand));

        var player = new Player
        {
            Id = _players.Count + 1,
            Health = 100,
            Mana = 100,
            Hand = new List<Card>(initialHand)
        };

        _players.Add(player);
    }

    /// <summary>
    /// Gets the next player in the game.
    /// </summary>
    public Player GetNextPlayer()
    {
        int index = _currentPlayerIndex++;
        if (_currentPlayerIndex >= _players.Count)
            _currentPlayerIndex = 0;

        return _players[index];
    }

    /// <summary>
    /// Gets a random target from the game.
    /// </summary>
    /// <remarks>The target in this example can also be the sender.</remarks>
    public Player GetRandomTarget()
    {
        int index = _random.Next(0, _players.Count);
        return _players[index];
    }

    /// <summary>
    /// Gets the number of players remaining alive.
    /// </summary>
    public int GetRemainingPlayerCount() =>
        _players.Count(player => player.Health > 0);
}