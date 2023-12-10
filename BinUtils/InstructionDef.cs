namespace BinUtils;

public class InstructionDef
{
    public required byte Opcode { get; init; }
    public int? Asu { get; init; } = null;
    public int? AddressConstant { get; init; } = null;
}