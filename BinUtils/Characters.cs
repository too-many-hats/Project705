namespace BinUtils;

public static class Characters
{
    public static readonly List<Character> All =
        [
            new('&', 0, 0b11_0000),
            new('A', 1, 0b11_0001),
            new('B', 1, 0b11_0010),
            new('C', 0, 0b11_0011),
            new('D', 1, 0b11_0100),
            new('E', 0, 0b11_0101),
            new('F', 0, 0b11_0110),
            new('G', 1, 0b11_0111),
            new('H', 1, 0b11_1000),
            new('I', 0, 0b11_1001),
            new('p', 0, 0b11_1010),//positive 0
            new('.', 1, 0b11_1011),
            new('l', 0, 0b11_1100),//lozenge
            new('g', 0, 0b11_1111),//group mark
            new('-', 1, 0b10_0000),
            new('J', 0, 0b10_0001),
            new('K', 0, 0b10_0010),
            new('L', 1, 0b10_0011),
            new('M', 0, 0b10_0100),
            new('N', 1, 0b10_0101),
            new('O', 1, 0b10_0110),
            new('P', 0, 0b10_0111),
            new('Q', 0, 0b10_1000),
            new('R', 1, 0b10_1001),
            new('m', 1, 0b10_1010),//minus 0
            new('$', 0, 0b10_1011),
            new('*', 1, 0b10_1100),
            new(' ', 1, 0b01_0000),//blank
            new('/', 0, 0b01_0001),
            new('S', 0, 0b01_0010),
            new('T', 1, 0b01_0011),
            new('U', 0, 0b01_0100),
            new('V', 1, 0b01_0101),
            new('W', 1, 0b01_0110),
            new('X', 0, 0b01_0111),
            new('Y', 0, 0b01_1000),
            new('Z', 1, 0b01_1001),
            new('r', 1, 0b01_1010),//record mark
            new(',', 0, 0b01_1011),
            new('%', 1, 0b01_1100),
            new('a', 0, 0b00_0000),//storage and drum mark. Referred to as 'a' for Accumulator mark in manuals.
            new('1', 1, 0b00_0001),
            new('2', 1, 0b00_0010),
            new('3', 0, 0b00_0011),
            new('4', 1, 0b00_0100),
            new('5', 0, 0b00_0101),
            new('6', 0, 0b00_0110),
            new('7', 1, 0b00_0111),
            new('8', 1, 0b00_1000),
            new('9', 0, 0b00_1001),
            new('0', 0, 0b00_1010),//record mark
            new('#', 1, 0b00_1011),
            new('@', 0, 0b00_1100),
            new('t', 1, 0b00_1111),//tape mark
        ];

    public static bool TryGet(char c, out Character character)
    {
        character = All.FirstOrDefault(x => x.Char == c) ?? new Character(' ', 0, 0);

        return character is null;
    }

    public static bool TryGet(byte val, out Character character)
    {
        character = All.FirstOrDefault(x => x.Value == val) ?? new Character(' ', 0, 0);

        return character is null;
    }

    /// <summary>
    /// Get the character whose value matches val. Throws if val is not valid.
    /// </summary>
    /// <param name="val">The character value to find.</param>
    /// <returns>The matching character.</returns>
    public static Character Get(byte val)
    {
        return All.First(x => x.Value == val);
    }
}

