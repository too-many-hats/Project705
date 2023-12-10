using BinUtils;
using System.Numerics;

namespace DebugAssembler;

/// <summary>
/// The Debug Assembler is temporary, just for debugging the emulator until a proper assembler is developed. This is very low level, just enough to not need to input raw binary.
/// </summary>
public class Dasm
{
    private readonly List<byte> _data = [];

    public Dasm Num(BigInteger number, int length, bool isSigned = true)
    {
        _data.AddRange(Data.Encode(number, length, isSigned));

        return this;
    }

    public Dasm Str(string str)
    {
        _data.AddRange(Data.Encode(str));

        return this;
    }

    public Dasm Ins(InstructionDef instruction, int address, int asu = 0)
    {
        // prefer the instruction's definition of ASU and address if defined
        asu = instruction.Asu ?? asu;
        address = instruction.AddressConstant ?? address;

        var inst = new Instruction
        {
            Address = address,
            Asu = asu, 
            Opcode = instruction.Opcode,
        };

        _data.AddRange(inst.GetAsBytes());

        return this;
    }

    public byte[] GetCharacters()
    {
        return _data.ToArray();
    }
}
