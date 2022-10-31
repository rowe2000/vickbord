namespace TicLib
{
    public enum OperationState
    {
        Reset = 0,
        Deenergized = 2,
        SoftError = 4,
        WaitingForErrLine = 6,
        StartingUp = 8,
        Normal = 10,
    }
}