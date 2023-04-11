namespace CardExample.Services;

/// <summary>
/// Represents a service for managing players.
/// </summary>
public sealed class PlayerService
{
    private int _currentPlayerIndex;
    private readonly List<Player> _players;

    /// <summary>
    /// Creates a new <see cref="PlayerService"/> instance.
    /// </summary>
    public PlayerService() =>
        _players = new List<Player>();

    /// <summary>
    /// Adds the specified player to the game.
    /// </summary>
    /// <param name="player">The player to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="player"/> is <see langword="null"/>.</exception>
    public void AddPlayer(IEnumerable<Card> initialHand) {
        if (initialHand is null)
            throw new ArgumentNullException(nameof(initialHand));

        var player = new Player {
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
    public Player GetNextPlayer() {
        int index = _currentPlayerIndex++;
        if (_currentPlayerIndex >= _players.Count)
            _currentPlayerIndex = 0;

        return _players[index];
    }
}