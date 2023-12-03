namespace BinUtils;

public record Character(char Char, byte CheckBit, byte Value)
{
    public byte Value { get; set; } = Value;
    public char Char { get; set; } = Char;
    public byte CheckBit { get; init; } = CheckBit;
}
