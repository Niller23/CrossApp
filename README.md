# CrossApp

Кросплатформний застосунок на .NET 8 (лабораторні роботи з кросплатформного програмування).

## Структура

```
CrossApp.sln
src/Cli/        консольний застосунок (інформація про платформу)
```

## Запуск

```bash
dotnet run --project src/Cli            # текстовий вивід
dotnet run --project src/Cli -- --json  # вивід у JSON
```

## Self-contained публікація

```bash
dotnet publish src/Cli -c Release -r osx-arm64 --self-contained true
./src/Cli/bin/Release/net8.0/osx-arm64/publish/Cli
```

Розмір каталогу publish (osx-arm64): ~76 МБ.

## Вибір домену

**Домен:** _TODO: вказати обраний домен_

**Обґрунтування:** _TODO_
