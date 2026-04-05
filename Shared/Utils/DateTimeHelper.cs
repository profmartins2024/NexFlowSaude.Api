namespace NexFlowSaude.Api.Shared.Utils;

public static class DateTimeHelper
{
    public static DateTime AgoraBrasil()
    {
        return DateTime.UtcNow.AddHours(-3);
    }
}
