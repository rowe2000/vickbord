namespace TicLib
{
    public enum Errors
    {
        IntentionallyDeenergized = 0,
        MotorDriverError = 1,
        LowVin = 2,
        KillSwitch = 3,
        RequiredInputInvalid = 4,
        SerialError = 5,
        CommandTimeout = 6,
        SafeStartViolation = 7,
        ErrLineHigh = 8,
        SerialFraming = 16,
        SerialRxOverrun = 17,
        SerialFormat = 18,
        SerialCrc = 19,
        EncoderSkip = 20,
    }
}