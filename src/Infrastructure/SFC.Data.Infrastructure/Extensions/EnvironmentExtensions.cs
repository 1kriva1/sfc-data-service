using SFC.Data.Infrastructure.Constants;

namespace SFC.Data.Infrastructure.Extensions;
public static class EnvironmentExtensions
{
    public static bool IsRunningInContainer => Environment.GetEnvironmentVariable(EnvironmentConstants.RunningInContainer) == "true";
}