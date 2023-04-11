using System.Collections.Generic;

namespace CardExample;

/// <summary>
/// Represents a player.
/// </summary>
public sealed class Player
{
    /// <summary>
    /// Gets or sets the player's unique identifier.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the player's health.
    /// </summary>
    public double Health { get; set; }
    /// <summary>
    /// Gets or sets the player's mana.
    /// </summary>
    public double Mana { get; set; }
    /// <summary>
    /// Gets or sets the player's hand.
    /// </summary>
    public List<Card> Hand { get; set; }
}