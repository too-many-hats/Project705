using System.Numerics;

namespace BinUtils;

public static class Data
{
    public const int PositiveZoneBits = 0b11_0000;
    public const int NegativeZoneBits = 0b10_0000;

    public static byte[] Encode(string data)
    {
        var result = new byte[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            if (Characters.TryGet(data[i], out var c) == false)
            {
                throw new Exception($"Character {data[i]} is not part of the IBM 705 character set.");
            }

            result[i] = c.Value;
        }

        return result;
    }

    /// <summary>
    /// Encode a number of unlimited decimal digits. Number is padded with zeros to if it has less decimal digits than the length parameter. Number is truncated if it has more decimal digits than the length parameter.
    /// </summary>
    /// <param name="data">The number to encode, unlimited number of digits.</param>
    /// <param name="length">The field length of the number, padded with zeros to the left if required.</param>
    /// <param name="isSigned">Determines if the number is signed or not. This should normally be left true.</param>
    /// <returns>The result characters.</returns>
    public static byte[] Encode(BigInteger data, int length, bool isSigned = true)
    {
        var isPositive = data > -1;// 705 encodes "0" as a positive number.
        var result = new List<byte>();

        var dataUnsigned = isPositive ? data : data * -1;

        while (result.Count < length)
        {
            var digit = dataUnsigned % 10;
            result.Add(Characters.Get(digit.ToString()[0]).Value);
            dataUnsigned = dataUnsigned / 10;
        }

        result.Reverse();

        if (isSigned)
        {
            var signZoneBits = isPositive ? PositiveZoneBits : NegativeZoneBits;

            result[^1] = (byte)(result[^1] | signZoneBits);
        }

        return result.ToArray();
    }
}
