namespace CardExample;

/// <summary>
/// Represents a behavior that causes the target to draw cards.
/// </summary>
public sealed class DrawCardsBehavior : CardBehavior {
    private readonly Player _target;
    private readonly DeckService _deckService;

    /// <summary>
    /// Creates a new <see cref="DrawCardsBehavior"/> instance.
    /// </summary>
    /// <param name="deckService">The deck service to use.</param>
    /// <param name="target">The target to draw cards for.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="deckService"/> or <paramref name="target"/> is <see langword="null"/>.</exception>
    public DrawCardsBehavior(DeckService deckService, Player target) {
        if (deckService is null)
            throw new ArgumentNullException(nameof(deckService));

        if (target is null)
            throw new ArgumentNullException(nameof(target));

        _deckService = deckService;
        _target = target;
    }

    /// <summary>
    /// Draws cards for the target based on the value specified by the card.
    /// </summary>
    /// <param name="card">The card to apply the behavior with.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="card"/> is <see langword="null"/>.</exception>
    public override void Apply(Card card) {
        if (card is null)
            throw new ArgumentNullException(nameof(card));

        IEnumerable<Card> cards = _deckService.Draw((int)card.Value);
        _target.Hand.AddRange(cards);
    }
}