namespace Emulator;

public static class InflationUtils
{
    public static decimal Adjust1958ToToday(decimal amount)
    {
        const decimal inflationChangeSince1958 = 9.6461M;

        return amount + amount * inflationChangeSince1958;
    }
}