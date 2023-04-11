namespace CardExample;

/// <summary>
/// Represents a behavior to be applied by a card.
/// </summary>
public abstract class CardBehavior
{
    /// <summary>
    /// Applies the behavior using the given card to the specified target.
    /// </summary>
    /// <param name="card">The <see cref="Card"/> to apply the behavior with.</param>
    /// <param name="target">The <see cref="Player"/> the behavior should be applied to.</param>
    public abstract void Apply(Card card, Player target);
}