namespace BinUtils;

public class InstructionDefs
{
    public static InstructionDef ADD = new() { Opcode = Characters.Get('G').Value, };
    public static InstructionDef ADM = new() { Opcode = Characters.Get('@').Value, };
    public static InstructionDef CMP = new() { Opcode = Characters.Get('4').Value, };
    public static InstructionDef IOF = new() { Opcode = Characters.Get('3').Value, AddressConstant = 0 };
    public static InstructionDef WTM = new() { Opcode = Characters.Get('3').Value, AddressConstant = 1 };
    public static InstructionDef RWD = new() { Opcode = Characters.Get('3').Value, AddressConstant = 2 };
    public static InstructionDef ION = new() { Opcode = Characters.Get('3').Value, AddressConstant = 3 };
    public static InstructionDef BSP = new() { Opcode = Characters.Get('3').Value, AddressConstant = 4 };
    public static InstructionDef SUP = new() { Opcode = Characters.Get('3').Value, AddressConstant = 5 };
    public static InstructionDef DIV = new() { Opcode = Characters.Get('W').Value, };
    public static InstructionDef LNG = new() { Opcode = Characters.Get('D').Value, };
    public static InstructionDef LOD = new() { Opcode = Characters.Get('8').Value, };
    public static InstructionDef MPY = new() { Opcode = Characters.Get('V').Value, };
    public static InstructionDef NOP = new() { Opcode = Characters.Get('A').Value, };
    public static InstructionDef NTR = new() { Opcode = Characters.Get('X').Value, };
    public static InstructionDef RD = new() { Opcode = Characters.Get('Y').Value, };
    public static InstructionDef FSP = new() { Opcode = Characters.Get('Y').Value, Asu = 1 };
    public static InstructionDef RMA = new() { Opcode = Characters.Get('Y').Value, Asu = 2 };
    public static InstructionDef RWW = new() { Opcode = Characters.Get('S').Value, };
    public static InstructionDef RCV = new() { Opcode = Characters.Get('U').Value, };
    public static InstructionDef RAD = new() { Opcode = Characters.Get('H').Value, };
    public static InstructionDef RSU = new() { Opcode = Characters.Get('Q').Value, };
    public static InstructionDef RND = new() { Opcode = Characters.Get('E').Value, };
    public static InstructionDef SEL = new() { Opcode = Characters.Get('2').Value, };
    public static InstructionDef SET = new() { Opcode = Characters.Get('B').Value, };
    public static InstructionDef SHR = new() { Opcode = Characters.Get('C').Value, };
    public static InstructionDef SGN = new() { Opcode = Characters.Get('T').Value, };
    public static InstructionDef HLT = new() { Opcode = Characters.Get('J').Value, };
    public static InstructionDef ST = new() { Opcode = Characters.Get('F').Value, };
    public static InstructionDef SPR = new() { Opcode = Characters.Get('5').Value, };
    public static InstructionDef SUB = new() { Opcode = Characters.Get('P').Value, };
    public static InstructionDef TR = new() { Opcode = Characters.Get('1').Value, };
    public static InstructionDef TRA = new() { Opcode = Characters.Get('I').Value, };
    public static InstructionDef TRE = new() { Opcode = Characters.Get('L').Value, };
    public static InstructionDef TRH = new() { Opcode = Characters.Get('K').Value, };
    public static InstructionDef TRP = new() { Opcode = Characters.Get('M').Value, };
    public static InstructionDef TRS = new() { Opcode = Characters.Get('O').Value, };
    public static InstructionDef TRZ = new() { Opcode = Characters.Get('N').Value, };
    public static InstructionDef TMT = new() { Opcode = Characters.Get('9').Value, };
    public static InstructionDef UNL = new() { Opcode = Characters.Get('7').Value, };
    public static InstructionDef WR = new() { Opcode = Characters.Get('R').Value, };
    public static InstructionDef DMP = new() { Opcode = Characters.Get('R').Value, Asu = 1 };
    public static InstructionDef WRE = new() { Opcode = Characters.Get('L').Value, };
    public static InstructionDef WRE2 = new() { Opcode = Characters.Get('L').Value, Asu = 1 };

    public static readonly List<InstructionDef> All =
    [
        ADD,
        ADM,
        CMP,
        IOF,
        WTM,
        RWD,
        ION,
        BSP,
        SUP,
        DIV,
        LNG,
        LOD,
        MPY,
        NOP,
        NTR,
        RD,
        FSP,
        RMA,
        RWW,
        RCV,
        RAD,
        RSU,
        RND,
        SEL,
        SET,
        SHR,
        SGN,
        HLT,
        ST,
        SPR,
        SUB,
        TR,
        TRA,
        TRE,
        TRH,
        TRP,
        TRS,
        TRZ,
        TMT,
        UNL,
        WR,
        DMP,
        WRE,
        WRE2,
    ];
}