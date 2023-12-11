using BinUtils;

namespace Emulator.Devices.Cpu;

public class Processor : IDevice
{
    public string Name => "705 II CPU";
    public decimal MonthlyRental1958 => 14150;
    public decimal PurchaseCost1958 => 590000;
    public List<IDevice> AttachedDevices { get; init; } = [];

    public byte[] Memory = new byte[40000]; // 40,000 appears to have been the only available memory size on the 705.
    public byte[,] Accumulators = new byte[2, 256]; // ACC and ASU, each with 256 characters
    public int[] AccumulatorSigns = new int[2]; // One sign for ACC and another for ASU, all sub-accumulators in ASU share the same sign.
    public int[] StartingPointCounters = new int[16]; //one starting point counter for each of ACC and ASU. ASU has 15 sub-counters.
    public int InstructionCounter = 0;
    public bool[] CheckIndicators = new bool[6]; // the state of each of the 6 check indicators
    public readonly int[] CheckIndicatorAddresses = [900, 901, 902, 903, 904, 905]; // the COMPONENT addresses of check indicators NOT memory addresses.
    public bool[] AlterationSwitches = new bool[6]; // the state of each of the 6 alteration switches
    public readonly int[] AlterationSwitchesAddresses = [900, 901, 902, 903, 904, 905]; // the COMPONENT addresses of alteration switches NOT memory addresses.
    public int SelectRegister = 0;
    public int StorageSelectRegister = 0;
    public int OperationRegister = 0;
    public bool IoReadNoResponse = false;
    public bool IoWriteNoResponse = false;
    public int MemoryAddressRegister = 0;
    public int MemoryAddressCounter1 = 0;
    public int MemoryAddressCounter2 = 0;
    public bool FourOrNineCheck = false;
    public bool OperationCheck = false;

    // we don't emulate electrical errors, so the below three indicators are never activated.
    public readonly bool MachCr1CodeCheck = false;
    public readonly bool InstCr1CodeCheck = false;
    public readonly bool Cr2CodeCheck = false;
    
    public CycleType CycleType = CycleType.Instruction;
    public ExecutionMode ExecutionMode = ExecutionMode.Manual;
    public ulong ExecutionTime = 0;

    public bool IsPoweredOn = false;

    private readonly byte STORAGE_MARK = Characters.Get('a').Value; // storage mark is used frequently, so cache it on initialisation.

    public void Cycle(ulong targetMicroseconds, bool isStep)
    {
        var executionTimeAtStart = ExecutionTime;

        if (IsPoweredOn is false)
        {
            return;
        }

        // in manual mode, only physically pressing the start button can step the machine forward, one half cycle at a time.
        if (ExecutionMode == ExecutionMode.Manual && isStep is false)
        {
            return;
        }


        // do not attempt to execute instructions if a fault has occurred.
        if (FourOrNineCheck || OperationCheck)
        {
            return;
        }

        while (ExecutionTime < targetMicroseconds + executionTimeAtStart)
        {
            if (CycleType == CycleType.Instruction)
            {
                if (InstructionCounter % 10 != 4 && InstructionCounter % 10 != 9)
                {
                    SetFourOrNineCheck(true);
                    return;
                }

                var instruction = new Instruction(new Span<byte>(Memory, InstructionCounter - 4, 5));
                SetOperationRegister(instruction.Opcode);
                SetStorageSelectRegister(instruction.Asu);
                SetMemoryAddressRegister(instruction.Address);

                if (InstructionDefs.All.Any(x => x.Opcode == OperationRegister) == false)
                {
                    SetOperationCheck(true);
                    return;
                }

                // ACCURACY: The manual doesn't define when or if a CTRL instruction can trigger an opcode check if an invalid address portion is used.
                // The emulator does trigger an invalid operation check.
                if (OperationRegister == 0b00_0011 && (instruction.Address > 5 || instruction.Address is 26 or 27 or 28 or 29)) // '3' CTRL instruction.
                {
                    SetOperationCheck(true);
                    return;
                }
            }
            else if (CycleType == CycleType.Execution)
            {
                if (OperationRegister == 0b11_0111) // 'G' ADD instruction
                {

                }
                else if (OperationRegister == 0b00_0110) // '6' ADM instruction
                {

                }
                else if (OperationRegister == 0b00_0100) // '4' CMP instruction
                {

                }
                else if (OperationRegister == 0b00_0011) // '3' IOF instruction
                {
                    if (MemoryAddressRegister == 0) // IOF instruction
                    {

                    }
                    else if (MemoryAddressRegister == 1) // WTM instruction
                    {

                    }
                    else if (MemoryAddressRegister == 2) // RWD instruction
                    {

                    }
                    else if (MemoryAddressRegister == 3) // ION instruction
                    {

                    }
                    else if (MemoryAddressRegister == 4) // BSP instruction
                    {

                    }
                    else if (MemoryAddressRegister == 5) // SUP instruction
                    {

                    }
                    else if (MemoryAddressRegister == 26) // RWS instruction
                    {

                    }
                    else if (MemoryAddressRegister == 27) // RWT instruction
                    {

                    }
                    else if (MemoryAddressRegister == 28) // RST instruction
                    {

                    }
                    else if (MemoryAddressRegister == 29) // PTW instruction
                    {

                    }
                }
                else if (OperationRegister == 0b01_0110) // 'W' DIV instruction
                {

                }
                else if (OperationRegister == 0b11_0100) // 'D' LNG instruction
                {

                }
                else if (OperationRegister == 0b00_1000) // '8' LOD instruction
                {

                }
                else if (OperationRegister == 0b01_0101) // 'V' MPY instruction
                {

                }
                else if (OperationRegister == 0b11_0001) // 'A' NOP instruction
                {

                }
                else if (OperationRegister == 0b01_0111) // 'X' NTR instruction
                {

                }
                else if (OperationRegister == 0b01_1000) // 'Y' RD instruction
                {
                    if (StorageSelectRegister == 1) // FSP instruction
                    {

                    }
                    else // RD (0) instruction
                    {

                    }
                }
                else if (OperationRegister == 0b01_0010) // 'S' RWW instruction
                {

                }
                else if (OperationRegister == 0b01_0100) // 'U' RCV instruction
                {

                }
                else if (OperationRegister == 0b11_1000) // 'H' RAD instruction
                {

                }
                else if (OperationRegister == 0b10_1000) // 'Q' RSU instruction
                {

                }
                else if (OperationRegister == 0b11_0101) // 'E' RND instruction
                {

                }
                else if (OperationRegister == 0b00_0010) // '2' SEL instruction
                {

                }
                else if (OperationRegister == 0b10_1001) // 'R' SET instruction
                {

                }
                else if (OperationRegister == 0b11_0011) // 'C' SHR instruction
                {

                }
                else if (OperationRegister == 0b01_0011) // 'T' SGN instruction
                {

                }
                else if (OperationRegister == 0b10_0001) // 'J' HLT instruction
                {

                }
                else if (OperationRegister == 0b11_0110) // 'F' ST instruction
                {

                }
                else if (OperationRegister == 0b00_0101) // '5' SPR instruction
                {

                }
                else if (OperationRegister == 0b10_0111) // 'P' SUB instruction
                {

                }
                else if (OperationRegister == 0b00_0001) // '1' TR instruction
                {

                }
                else if (OperationRegister == 0b11_1001) // 'I' TRA instruction
                {

                }
                else if (OperationRegister == 0b10_0011) // 'L' TRE instruction
                {

                }
                else if (OperationRegister == 0b10_0010) // 'K' TRH instruction
                {

                }
                else if (OperationRegister == 0b10_0100) // 'M' TRP instruction
                {

                }
                else if (OperationRegister == 0b10_0110) // 'O' TRS instruction
                {

                }
                else if (OperationRegister == 0b10_0101) // 'N' TRZ instruction
                {

                }
                else if (OperationRegister == 0b00_1001) // '9' TMT instruction
                {

                }
                else if (OperationRegister == 0b00_0111) // '7' UNL instruction
                {

                }
                else if (OperationRegister == 0b10_1001) // 'R' WR instruction
                {
                    if (StorageSelectRegister == 1) // DMP instruction
                    {

                    }
                    else if (StorageSelectRegister == 2) // DMP instruction
                    {

                    }
                    else // WR (0) instruction
                    {

                    }
                }
                else if (OperationRegister == 0b01_1001) // 'Z' WR instruction
                {
                    if (StorageSelectRegister == 1) // WRE (1) instruction
                    {

                    }
                    else // WRE (0) instruction
                    {

                    }
                }
                else
                {
                    throw new NotImplementedException("OperationCheck failed, invalid instructions should be detected and handled during I-time.");
                }
            }

            if (ExecutionMode is ExecutionMode.Manual)
            {
                return;
            }
        }
    }

    public void Cycle(ulong targetMicroseconds)
    {
        Cycle(targetMicroseconds, false);
    }

    public void ResetToPowerOnState()
    {
        Accumulators = new byte[2, 256];
        Memory = new byte[40000];
        AccumulatorSigns = new int[2];
        StartingPointCounters = new int[16];
        InstructionCounter = 4;
        CheckIndicators = new bool[6];
        AlterationSwitches = new bool[6];
        SelectRegister = 0;
        StorageSelectRegister = 0;
        OperationRegister = 0;
        IoReadNoResponse = false;
        IoWriteNoResponse = false;
        MemoryAddressRegister = 0;
        MemoryAddressCounter1 = 0;
        MemoryAddressCounter2 = 0;
        FourOrNineCheck = false;
        OperationCheck = false;
        CycleType = CycleType.Instruction;
        ExecutionMode = ExecutionMode.Manual;
        ExecutionTime = 0;
        IsPoweredOn = true;
    }

    private void SetOperationRegister(int value)
    {
        OperationRegister = value;
    }

    private void SetStorageSelectRegister(int value)
    {
        StorageSelectRegister = value;
    }

    private void SetFourOrNineCheck(bool value)
    {
        FourOrNineCheck = value;
    }

    private void SetOperationCheck(bool value)
    {
        OperationCheck = value;
    }

    private void SetMemoryAddressCounter1(int value)
    {
        MemoryAddressCounter1 = value;
    }

    private void SetMemoryAddressCounter2(int value)
    {
        MemoryAddressCounter2 = value;
    }

    private void SetMemoryAddressRegister(int value)
    {
        MemoryAddressCounter2 = value;
    }
}

