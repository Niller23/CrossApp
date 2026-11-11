using System.Runtime.InteropServices;
using System.Text.Json;

var info = new PlatformInfo(
    App: "CrossApp.Cli",
    Os: RuntimeInformation.OSDescription,
    OsPlatform: GetPlatformName(),
    OsArchitecture: RuntimeInformation.OSArchitecture.ToString(),
    ProcessArchitecture: RuntimeInformation.ProcessArchitecture.ToString(),
    Framework: RuntimeInformation.FrameworkDescription,
    RuntimeIdentifier: RuntimeInformation.RuntimeIdentifier,
    MachineName: Environment.MachineName,
    ProcessorCount: Environment.ProcessorCount,
    CurrentDirectory: Environment.CurrentDirectory,
    Timestamp: DateTimeOffset.Now);

if (args.Contains("--json"))
{
    Console.WriteLine(JsonSerializer.Serialize(info, new JsonSerializerOptions { WriteIndented = true }));
}
else
{
    Console.WriteLine("=== CrossApp: інформація про платформу ===");
    Console.WriteLine($"ОС:                  {info.Os} ({info.OsPlatform})");
    Console.WriteLine($"Архітектура ОС:      {info.OsArchitecture}");
    Console.WriteLine($"Архітектура процесу: {info.ProcessArchitecture}");
    Console.WriteLine($".NET:                {info.Framework}");
    Console.WriteLine($"RID:                 {info.RuntimeIdentifier}");
    Console.WriteLine($"Машина:              {info.MachineName}");
    Console.WriteLine($"Ядер CPU:            {info.ProcessorCount}");
    Console.WriteLine($"Каталог:             {info.CurrentDirectory}");
    Console.WriteLine($"Час:                 {info.Timestamp:yyyy-MM-dd HH:mm:ss zzz}");
}

static string GetPlatformName()
{
    if (OperatingSystem.IsWindows()) return "Windows";
    if (OperatingSystem.IsMacOS()) return "macOS";
    if (OperatingSystem.IsLinux()) return "Linux";
    return "Unknown";
}

record PlatformInfo(
    string App,
    string Os,
    string OsPlatform,
    string OsArchitecture,
    string ProcessArchitecture,
    string Framework,
    string RuntimeIdentifier,
    string MachineName,
    int ProcessorCount,
    string CurrentDirectory,
    DateTimeOffset Timestamp);
