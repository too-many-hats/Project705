namespace BinUtils;

public record Character(int Value, char Char, bool CheckBit)
{
    public int Value { get; set; } = Value;
    public char Char { get; set; } = Char;
    public bool CheckBit { get; init; } = CheckBit;
}
