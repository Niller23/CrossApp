# CrossApp

Наскрізний проєкт з крос-платформного програмування.

Студент: Мельник Назарій, група ФЕІ-34.

## Предметна область

**Замовлення.** Сутності: `Customer` (клієнт), `Product` (товар), `Order` (замовлення), `OrderLine` (рядок замовлення).

Призначення: оформлення замовлень клієнтів і підрахунок їхніх сум.

## Структура

```
CrossApp.sln
src/Cli/        консольний застосунок: інформація про середовище
```

## Запуск

```bash
dotnet build
dotnet run --project src/Cli            # таблиця
dotnet run --project src/Cli -- --json  # той самий вивід одним JSON-рядком
```

## Середовище

.NET SDK 8.0, macOS (Darwin 27) arm64, RID `osx-arm64`.

## Self-contained публікація

```bash
dotnet publish src/Cli -c Release -r osx-arm64 --self-contained true
./src/Cli/bin/Release/net8.0/osx-arm64/publish/Cli
```

Розмір каталогу publish для різних RID:

| RID        | Розмір |
|------------|--------|
| osx-arm64  | 76 МБ  |
| linux-x64  | 71 МБ  |
| win-x64    | 71 МБ  |

## Запуск у контейнері

```bash
docker run --rm -v ${PWD}:/src -w /src mcr.microsoft.com/dotnet/sdk:8.0 \
  dotnet run --project src/Cli
```

`OSDescription` у контейнері: `Debian GNU/Linux 12 (bookworm)`, RID `linux-arm64`.
Локально: `Darwin 27.0.0 ...`, RID `osx-arm64`. Збірка та сама, змінюються лише дані про ОС.
