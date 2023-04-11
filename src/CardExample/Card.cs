namespace CardExample;

/// <summary>
/// Represents a basic card for gameplay.
/// </summary>
public class Card {
    /// <summary>
    /// The name of the card.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The value of the card.
    /// </summary>
    public double Value { get; set; }
    /// <summary>
    /// The effects of the card.
    /// </summary>
    public List<Effect> Effects { get; set; }
    /// <summary>
    /// The behaviors of the card.
    /// </summary>
    public List<CardBehavior> Behaviors { get; set; }
}