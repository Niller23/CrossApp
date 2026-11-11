using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

Console.OutputEncoding = Encoding.UTF8;

const string Domain = "Замовлення (клієнти, товари, замовлення, рядки замовлення)";

var info = new EnvironmentInfo(
    Student: "Мельник Назарій, група ФЕІ-34",
    OsDescription: RuntimeInformation.OSDescription,
    OsVersion: Environment.OSVersion.ToString(),
    ProcessArchitecture: RuntimeInformation.ProcessArchitecture.ToString(),
    ClrVersion: Environment.Version.ToString(),
    Runtime: RuntimeInformation.FrameworkDescription,
    RuntimeIdentifier: RuntimeInformation.RuntimeIdentifier,
    BaseDirectory: AppContext.BaseDirectory,
    CurrentDirectory: Environment.CurrentDirectory,
    Domain: Domain);

if (args.Contains("--json"))
{
    Console.WriteLine(JsonSerializer.Serialize(info, new JsonSerializerOptions
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    }));
    return;
}

Console.WriteLine("CrossApp – практикум з крос-платформного програмування");
Console.WriteLine($"Студент: {info.Student}");
Console.WriteLine(new string('-', 52));

Console.WriteLine($"ОС (OSDescription)  : {info.OsDescription}");
Console.WriteLine($"ОС (Environment)    : {info.OsVersion}");
Console.WriteLine($"Архітектура процесу : {info.ProcessArchitecture}");
Console.WriteLine($"Версія .NET (CLR)   : {info.ClrVersion}");
Console.WriteLine($"Runtime             : {info.Runtime}");
Console.WriteLine($"RID                 : {info.RuntimeIdentifier}");
Console.WriteLine($"Каталог застосунку  : {info.BaseDirectory}");
Console.WriteLine($"Поточний каталог    : {info.CurrentDirectory}");

Console.WriteLine(new string('-', 52));
Console.WriteLine($"Предметна область: {info.Domain}");

record EnvironmentInfo(
    string Student,
    string OsDescription,
    string OsVersion,
    string ProcessArchitecture,
    string ClrVersion,
    string Runtime,
    string RuntimeIdentifier,
    string BaseDirectory,
    string CurrentDirectory,
    string Domain);
