using System;
using System.Collections.Generic;
using System.Linq;

namespace CardExample;

/// <summary>
/// Represents a service for managing the deck.
/// </summary>
public sealed class DeckService
{
    private Queue<Card> _cards;
    private readonly Random _random;

    /// <summary>
    /// Creates a new <see cref="DeckService"/> instance.
    /// </summary>
    public DeckService() =>
        _random = new Random();

    /// <summary>
    /// Loads a dummy deck.
    /// </summary>
    public void Load()
    {
        _cards = new Queue<Card>();
        for (int i = 0; i < 250; i++)
        {
            var card = new Card
            {
                Name = $"Card {i}",
                Value = _random.Next(1, 10),
                Behaviors = new List<CardBehavior>()
            };

            // Add a draw cards behavior to every 30th card.
            if (i % 15 == 0)
                card.Behaviors.Add(new DrawCardsBehavior(this));

            _cards.Enqueue(card);
        }
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