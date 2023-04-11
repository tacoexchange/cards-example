namespace CardExample;

/// <summary>
/// Represents a service for managing the deck.
/// </summary>
public sealed class DeckService {
    private readonly Queue<Card> _cards;
    
    /// <summary>
    /// Creates a new <see cref="DeckService"/> instance.
    /// </summary>
    /// <param name="cards">The cards to use.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="cards"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="cards"/> is empty.</exception>
    public DeckService(IEnumerable<Card> cards) {
        if (cards is null)
            throw new ArgumentNullException(nameof(cards));
        if (!cards.Any())
            throw new ArgumentException("The deck must contain at least one card.", nameof(cards));

        _cards = new Queue<Card>(cards);
    }

    /// <summary>
    /// Draws the specified number of cards from the deck.
    /// </summary>
    /// <param name="count">The number of cards to draw.</param>
    /// <returns>The drawn cards.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count"/> is less than zero.</exception>
    public IEnumerable<Card> Draw(int count) {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "The number of cards to draw must be greater than or equal to zero.");

        List<Card> newCards = new();
        for (var i = 0; i < count && _cards.Count; i++)
            newCards.Add(_cards.Dequeue());

        return newCards;
    }
}