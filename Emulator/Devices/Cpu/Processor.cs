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
                    FourOrNineCheck = true;
                    return;
                }

                var instruction = new Instruction(new Span<byte>(Memory, InstructionCounter - 4, 5));
                OperationRegister = instruction.Opcode;

                StorageSelectRegister = instruction.Asu;

                if (InstructionDefs.All.Any(x => x.Opcode == OperationRegister))
                {
                    OperationCheck = true;
                    return;
                }


            }
            else if (CycleType == CycleType.Execution)
            {

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
}

