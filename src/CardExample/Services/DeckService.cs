using System;
using System.Collections.Generic;
using System.Linq;

namespace CardExample;

/// <summary>
/// Represents a service for managing the deck.
/// </summary>
public sealed class DeckService
{
    private readonly Queue<Card> _cards;

    /// <summary>
    /// Creates a new <see cref="DeckService"/> instance.
    /// </summary>
    /// <param name="cards">The cards to use.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="cards"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="cards"/> is empty.</exception>
    public DeckService(IEnumerable<Card> cards)
    {
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
    /// <param name="cards">The cards that were drawn.</param>
    /// <returns><see langword="true"/> if cards were successfully drawn, otherwise <see langword="false"/>.</returns>
    public bool TryDraw(int count, out IEnumerable<Card> cards)
    {
        cards = Enumerable.Empty<Card>();
        if (count < 0)
            return false;

        List<Card> newCards = new();
        for (int i = 0; i < count && i < _cards.Count; i++)
            newCards.Add(_cards.Dequeue());

        cards = newCards;
        return newCards.Count > 0;
    }
}