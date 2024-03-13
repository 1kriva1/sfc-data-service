namespace SFC.Data.Infrastructure.Settings;
public class HangfireSettings
{
    public const string SECTION_KEY = "Hangfire";

    public string SchemaNamePrefix { get; set; } = null!;

    public HangfireAutomaticRetrySettings Retry { get; set; } = default!;

    public HangfireDashboardSettings Dashboard { get; set; } = default!;
}

public class HangfireAutomaticRetrySettings
{
    public int Attempts { get; set; }

    public int[] DelaysInSeconds { get; set; } = Array.Empty<int>();
}

public class HangfireDashboardSettings
{
    public string Title { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
