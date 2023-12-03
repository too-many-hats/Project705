namespace BinUtils;

public static class Characters
{
    public static readonly List<Character> All =
        [
            new Character('&', 0, 0b11_0000),
            new Character('A', 1, 0b11_0001),
            new Character('B', 1, 0b11_0010),
            new Character('C', 0, 0b11_0011),
            new Character('D', 1, 0b11_0100),
            new Character('E', 0, 0b11_0101),
            new Character('F', 0, 0b11_0110),
            new Character('G', 1, 0b11_0111),
            new Character('H', 1, 0b11_1000),
            new Character('I', 0, 0b11_1001),
            new Character('p', 0, 0b11_1010),//positive 0
            new Character('.', 1, 0b11_1011),
            new Character('l', 0, 0b11_1100),//lozenge
            new Character('g', 0, 0b11_1111),//group mark
            new Character('-', 1, 0b10_0000),
            new Character('J', 0, 0b10_0001),
            new Character('K', 0, 0b10_0010),
            new Character('L', 1, 0b10_0011),
            new Character('M', 0, 0b10_0100),
            new Character('N', 1, 0b10_0101),
            new Character('O', 1, 0b10_0110),
            new Character('P', 0, 0b10_0111),
            new Character('Q', 0, 0b10_1000),
            new Character('R', 1, 0b10_1001),
            new Character('m', 1, 0b10_1010),//minus 0
            new Character('$', 0, 0b10_1011),
            new Character('*', 1, 0b10_1100),
            new Character(' ', 1, 0b01_0000),//blank
            new Character('/', 0, 0b01_0001),
            new Character('S', 0, 0b01_0010),
            new Character('T', 1, 0b01_0011),
            new Character('U', 0, 0b01_0100),
            new Character('V', 1, 0b01_0101),
            new Character('W', 1, 0b01_0110),
            new Character('X', 0, 0b01_0111),
            new Character('Y', 0, 0b01_1000),
            new Character('Z', 1, 0b01_1001),
            new Character('r', 1, 0b01_1010),//record mark
            new Character(',', 0, 0b01_1011),
            new Character('%', 1, 0b01_1100),
            new Character('a', 0, 0b00_0000),//storage and drum mark. Referred to as 'a' for Accumulator mark in manuals.
            new Character('1', 1, 0b00_0001),
            new Character('2', 1, 0b00_0010),
            new Character('3', 0, 0b00_0011),
            new Character('4', 1, 0b00_0100),
            new Character('5', 0, 0b00_0101),
            new Character('6', 0, 0b00_0110),
            new Character('7', 1, 0b00_0111),
            new Character('8', 1, 0b00_1000),
            new Character('9', 0, 0b00_1001),
            new Character('0', 0, 0b00_1010),//record mark
            new Character('#', 1, 0b00_1011),
            new Character('@', 0, 0b00_1100),
            new Character('t', 1, 0b00_1111),//tape mark
        ];
}

