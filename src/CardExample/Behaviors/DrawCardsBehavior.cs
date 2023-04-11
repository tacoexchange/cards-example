namespace CardExample;

/// <summary>
/// Represents a behavior that causes the target to draw cards.
/// </summary>
public sealed class DrawCardsBehavior : CardBehavior {
    private readonly DeckService _deckService;

    /// <summary>
    /// Creates a new <see cref="DrawCardsBehavior"/> instance.
    /// </summary>
    /// <param name="deckService">The deck service to use.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="deckService"/> is <see langword="null"/>.</exception>
    public DrawCardsBehavior(DeckService deckService) {
        if (deckService is null)
            throw new ArgumentNullException(nameof(deckService));

        _deckService = deckService;
    }

    /// <summary>
    /// Draws cards for the target based on the value specified by the card.
    /// </summary>
    /// <param name="card">The card to apply the behavior with.</param>
    /// <param name="target">The target to apply the behavior to.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="card"/> is <see langword="null"/>.</exception>
    public override void Apply(Card card, Player target) {
        if (card is null)
            throw new ArgumentNullException(nameof(card));

        IEnumerable<Card> cards = _deckService.Draw((int)card.Value);
        target.Hand.AddRange(cards);
    }
}