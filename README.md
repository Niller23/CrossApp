# CrossApp

Наскрізний проєкт з крос-платформного програмування.

Студент: Мельник Назарій, група ФЕІ-34.

## Предметна область

**Замовлення.** Сутності: `Customer` (клієнт), `Product` (товар), `Order` (замовлення), `OrderLine` (рядок замовлення).

Призначення: оформлення замовлень клієнтів і підрахунок їхніх сум.

## Структура solution

```
CrossApp.sln
src/
  Core/                    бібліотека класів (net8.0;net10.0), уся логіка
    Core.csproj
    EnvironmentInfo.cs     збирає інформацію про середовище
    EnvironmentReport.cs   record з даними про середовище
  Cli/                     консольний застосунок (net10.0), лише вивід
    Cli.csproj             ProjectReference -> Core
    Program.cs
```

Залежність одностороння: `Cli -> Core`. Core не знає про Cli, тому його зможуть використати Api (тиждень 10) і Blazor (тиждень 12).

Домовленість про каталоги в Core на весь семестр:

| Каталог         | Вміст                                              | Тиждень |
|-----------------|----------------------------------------------------|---------|
| `Core/Dto/`     | record-типи формату даних (`OrderDto` тощо)        | 3       |
| `Core/Domain/`  | сутності з поведінкою та інваріантами              | 4       |
| `Core/Storage/` | реалізації сховищ                                  | 5       |

## Збірка і запуск

```bash
dotnet build
dotnet build src/Core/Core.csproj           # бібліотека збирається окремо (net8.0 і net10.0)
dotnet run --project src/Cli                # таблиця
dotnet run --project src/Cli -- --json      # той самий вивід одним JSON-рядком
dotnet run --project src/Cli -p:CliTfm=net8.0   # Cli під net8.0 -> Core бере варіант net8.0
```

## Середовище

.NET SDK 10.0.402 (також встановлено 8.0.428), macOS 27 arm64, RID `osx-arm64`.

## Публікація

```bash
# self-contained: код + копія .NET runtime, runtime на машині не потрібен
dotnet publish src/Cli -c Release -r osx-arm64 --self-contained true
./src/Cli/bin/Release/net10.0/osx-arm64/publish/Cli

# framework-dependent: лише код, на машині має бути .NET 10 runtime
dotnet publish src/Cli -c Release -r osx-arm64 --self-contained false
./src/Cli/bin/Release/net10.0/osx-arm64/publish/Cli
```

**Self-contained** публікація несе власну копію .NET runtime, тому запускається на машині без встановленого .NET, але важить десятки мегабайт і прив'язана до однієї RID.
**Framework-dependent** публікація містить лише код застосунку (сотні кілобайт), але вимагає встановленого сумісного .NET runtime на машині користувача.

| RID        | Режим                                | Розмір publish | Файлів | Потрібен runtime |
|------------|--------------------------------------|----------------|--------|------------------|
| osx-arm64  | self-contained                       | 83 МБ          | 193    | ні               |
| osx-arm64  | framework-dependent                  | 180 КБ         | 7      | так (.NET 10)    |
| linux-x64  | self-contained                       | 79 МБ          | 194    | ні               |
| win-x64    | self-contained                       | 77 МБ          | 194    | ні               |
| win-x64    | framework-dependent                  | 216 КБ         | 7      | так (.NET 10)    |
| osx-arm64  | self-contained + SingleFile          | 76 МБ          | 3      | ні               |
| osx-arm64  | self-contained + Trimmed             | 20 МБ          | 35     | ні               |
| osx-arm64  | self-contained + SingleFile + Trimmed| 13 МБ          | 3      | ні               |

`PublishTrimmed=true` видаляє код, який аналізатор вважає невикористаним. Збірка дає попередження `IL2026` для `JsonSerializer.Serialize`, і trimmed-версія справді падає на `--json` з `InvalidOperationException: Reflection-based serialization has been disabled`. Серіалізація через рефлексію звертається до типів у runtime, тож trimmer не може це передбачити.

## Запуск у контейнері

```bash
docker run --rm -v ${PWD}:/src -w /src mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/Cli
```

`OSDescription` у контейнері: `Ubuntu 24.04.5 LTS`, runtime `.NET 10.0.15`, RID `linux-arm64`.
