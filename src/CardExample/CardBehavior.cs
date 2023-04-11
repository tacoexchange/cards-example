namespace CardExample;

/// <summary>
/// Represents a behavior to be applied by a card.
/// </summary>
public abstract class CardBehavior {
    /// <summary>
    /// Applies the behavior using the given card.
    /// </summary>
    /// <param name="card">The card to apply the behavior with.</param>
    public abstract void Apply(Card card);
}