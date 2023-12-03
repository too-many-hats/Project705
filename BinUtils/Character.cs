namespace BinUtils;

public record Character(char Char, byte CheckBit, int Value)
{
    public int Value { get; set; } = Value;
    public char Char { get; set; } = Char;
    public byte CheckBit { get; init; } = CheckBit;
}
