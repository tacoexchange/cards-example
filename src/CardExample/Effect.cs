namespace CardExample;

/// <summary>
/// Represents an effect capable of being applied to any entity.
/// </summary>
public abstract class Effect {
    /// <summary>
    /// Gets or sets the name of the effect.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the value of the effect.
    /// </summary>
    public double Value { get; set; }
    /// <summary>
    /// Gets or sets the lifetime of the effect.
    /// </summary>
    public uint Lifetime { get; set; }
}