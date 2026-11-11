namespace Core;

// Дані про середовище виконання. Лише значення, без поведінки: друкує їх Cli.
public sealed record EnvironmentReport(
    string OsDescription,
    string OsVersion,
    string FrameworkDescription,
    string ClrVersion,
    string ProcessArchitecture,
    string DetectedRid,
    string ReportedRid,
    string BaseDirectory,
    string CurrentDirectory,
    string BuildNote);
