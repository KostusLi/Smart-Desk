# SmartDesk API

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-336791?style=for-the-badge&logo=postgresql&logoColor=white)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean_Architecture-success?style=for-the-badge)

REST API для системы бронирования переговорных комнат. Проект написан в качестве пет-проекта для демонстрации навыков backend-разработки на платформе .NET с использованием современных архитектурных практик.

## Стек технологий

* **Платформа:** C#, ASP.NET Core Web API
* **Архитектура:** Clean Architecture
* **База данных:** PostgreSQL
* **Безопасность:** JWT, BCrypt
* **Валидация:** FluentValidation
* **Интеграции:** IHttpClientFactory, Polly

## Особенности реализации

В проекте применены стандартные практики разработки:

* **Структура проекта:** Разделение на слои Domain, Application, Infrastructure и API. Зависимости направлены внутрь.
* **CQRS и MediatR:** Контроллеры выступают только в роли маршрутизаторов. Бизнес-логика вынесена в отдельные обработчики команд и запросов.
* **Сквозная валидация:** Проверка входящих данных вынесена на уровень Pipeline Behavior в MediatR. Это позволило избавиться от проверок внутри хэндлеров.
* **Обработка ошибок:** Кастомный обработчик ошибок.
* **Работа с EF Core:** Конфигурация БД выполнена через Fluent API (`IEntityTypeConfiguration`). В запросах на чтение используется `AsNoTracking` для экономии памяти, решена проблема N+1.
* **Интеграция со сторонними API:** Настроен типизированный `HttpClient` для отправки уведомлений. Для защиты от кратковременных сетевых сбоев добавлена политика повторных попыток (Retry) с помощью Polly.
* **Бизнес-логика:** Реализована проверка пересечений временных интервалов (Overlap check), чтобы не допустить двойного бронирования одной и той же комнаты.

## Как запустить локально

1. Склонируйте репозиторий:
   ```bash
   git clone https://github.com/Your_User_Name/SmartDesk.git
   ```
2. В файле `Api/appsettings.Development.json` укажите свои данные для подключения к PostgreSQL и секретный ключ для JWT.
3. Примените миграции:
   ```bash
   dotnet ef database update --project Infrastructure --startup-project Api
   ```
4. Запустите проект:
   ```bash
   dotnet run --project Api
   ```
5. Swagger UI будет доступен по адресу: `https://localhost:5001/swagger` (порт может отличаться).

## Конечные точки

| Метод | Маршрут | Описание | Авторизация |
| :--- | :--- | :--- | :--- |
| `POST` | `/api/auth/Register` | Регистрация пользователя | Нет |
| `POST` | `/api/auth/Login` | Получение JWT токена | Нет |
| `GET` | `/api/Rooms` | Получение списка комнат | Нет |
| `POST` | `/api/Rooms` | Создание комнаты | **Admin** |
| `POST` | `/api/Bookings` | Бронирование комнаты | **User / Admin** |
