namespace BinUtils;

/// <summary>
/// The lowest level instruction encode/decode functionality.
/// This class performs little to no validation and is only concerned with translating to and from binary representations of instructions.
/// 
/// </summary>
public class Instruction
{
    private const int OpcodeCharacter = 0;
    private const int ThousandsDigit = 1;
    private const int HundredsDigit = 2;
    private const int TensDigit = 3;
    private const int OnesDigit = 4;
    private const int ZoneBitsMask = 0b11_0000;
    private const int ValueBitsMask = 0b00_1111;

    private readonly byte[] _instruction = [10, 10, 10, 10, 10];// all zeros

    public Instruction()
    {

    }

    public Instruction(Span<byte> data)
    {
        if (data.Length != 5)
        {
            throw new ArgumentException("Data is not 5 characters long. Instructions must be 5 characters long to interpret.");
        }

        for (var i = 0; i < data.Length; i++)
        {
            _instruction[i] = data[i];
        }
    }

    public byte Opcode
    {
        get
        {
            return _instruction[OpcodeCharacter];
        }
        set
        {
            _instruction[OpcodeCharacter] = value;
        }
    }

    //See reference manual pages 10 and 11 for full details on ASU encoding in instructions.
    public int Asu
    {
        get
        {
            var hundredsDigitBits = (_instruction[HundredsDigit] & ZoneBitsMask) >> 2;
            var tensDigitBits = (_instruction[TensDigit] & ZoneBitsMask) >> 4;

            return hundredsDigitBits | tensDigitBits;
        }
        set
        {
            var tensDigitZoneBits = value & 0b0011;
            var hundredsDigitZoneBits = value & 0b1100;

            _instruction[TensDigit] = ReplaceZoneBits(_instruction[TensDigit], tensDigitZoneBits << 4);
            _instruction[HundredsDigit] = ReplaceZoneBits(_instruction[HundredsDigit], hundredsDigitZoneBits << 2);
        }
    }

    //instruction addresses are a mix of binary and decimal, the low order 4 digits are decimal and the 5th high order digit
    // is encoded in binary as zone bits over the thousands digit. See reference manual pages 9 and 10 for full details
    public int Address
    {
        get
        {
            var result = 0;

            var zoneBitsValue = (_instruction[ThousandsDigit] & ZoneBitsMask) >> 4;

            var ordersOfMagnitude = new int[] { 1000, 100, 10, 1 };
            for (var i = 0; i < 4; i++)
            {
                var value = _instruction[i + 1] & ValueBitsMask;
                if (value == 0b1010) // the 705 encodes decimal 0 as the binary value 10, so we need to convert to binary 0 so our arithmetic is correct.
                {
                    value = 0;
                }

                result = result + (value * ordersOfMagnitude[i]);
            }

            return result + zoneBitsValue * 10000;
        }
        set
        {
            var address = 0;
            var zoneBitsValue = 0;

            if (value is >= 30000 and < 40000)
            {
                address = value - 30000;
                zoneBitsValue = 3;
            }
            else if (value is >= 20000 and < 30000)
            {
                address = value - 20000;
                zoneBitsValue = 2;
            }
            else if (value is >= 10000 and < 20000)
            {
                address = value - 10000;
                zoneBitsValue = 1;
            }

            var addressCharacters = new Character[4];

            for (var i = 0; i < addressCharacters.Length; i++)
            {
                var digit = address % 10;
                addressCharacters[i] = Characters.Get(digit.ToString()[0]);
                address = address / 10;
            }

            for (var i = 0; i < addressCharacters.Length; i++)
            {
                _instruction[i + 1] = addressCharacters[4 - i].Value;
            }

            _instruction[ThousandsDigit] = ReplaceZoneBits(_instruction[ThousandsDigit], zoneBitsValue << 4);
        }
    }

    public byte[] GetAsBytes()
    {
        return _instruction;
    }

    private static byte ReplaceZoneBits(byte character, int zoneBits)
    {
        character = (byte)(character & ValueBitsMask);
        character = (byte)(character | zoneBits);

        return character;
    }
}
