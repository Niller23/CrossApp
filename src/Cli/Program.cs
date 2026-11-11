using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Core;

Console.OutputEncoding = Encoding.UTF8;

EnvironmentReport report = EnvironmentInfo.Collect();

if (args.Contains("--json"))
{
    Console.WriteLine(JsonSerializer.Serialize(report, new JsonSerializerOptions
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    }));
    return;
}

Console.WriteLine("CrossApp – інформація про середовище");
Console.WriteLine("Студент: Мельник Назарій, група ФЕІ-34");
Console.WriteLine(new string('-', 52));
Console.WriteLine($"ОС (OSDescription)  : {report.OsDescription}");
Console.WriteLine($"ОС (Environment)    : {report.OsVersion}");
Console.WriteLine($"Runtime             : {report.FrameworkDescription}");
Console.WriteLine($"Версія .NET (CLR)   : {report.ClrVersion}");
Console.WriteLine($"Архітектура         : {report.ProcessArchitecture}");
Console.WriteLine($"RID (визначено)     : {report.DetectedRid}");
Console.WriteLine($"RID (від .NET)      : {report.ReportedRid}");
Console.WriteLine($"Каталог застосунку  : {report.BaseDirectory}");
Console.WriteLine($"Поточний каталог    : {report.CurrentDirectory}");
Console.WriteLine($"Core                : {report.BuildNote}");
Console.WriteLine(new string('-', 52));
Console.WriteLine("Предметна область: Замовлення (клієнти, товари, замовлення, рядки замовлення)");
