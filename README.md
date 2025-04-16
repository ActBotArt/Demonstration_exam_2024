# Демонстрационный экзамен 2024

Информационная система для производственной компании "Мастер пол", разработанная в рамках демонстрационного экзамена 2024 года. Система предназначена для управления партнерами, продукцией и продажами компании.

### 📋 Основная информация
- **Специальность:** 09.02.07 Информационные системы и программирование
- **Год:** 2024
- **Компетенция:** Разработка программного обеспечения
- **Разработчик:** [ActBotArt](https://github.com/ActBotArt)

## 📸 Скриншоты интерфейса

<div align="center">
  <img src="https://github.com/user-attachments/assets/0beffee1-b8da-4209-98ff-49f6099429ff" width="400px">
  <img src="https://github.com/user-attachments/assets/25a3cd6e-6e2e-46a3-821c-7151008a5d1a" width="400px">
  <img src="https://github.com/user-attachments/assets/9e489428-a3d0-4ff4-99fd-0e653540a6ad" width="400px">
  <img src="https://github.com/user-attachments/assets/2e4cd269-313d-4453-abec-dd33ec1b3884" width="400px">
  <img src="https://github.com/user-attachments/assets/91af31ed-720d-44bb-b1a3-8251460a619c" width="400px">
  <img src="https://github.com/user-attachments/assets/51f26335-f393-4ce7-aaed-dea61c001525" width="400px">
  <img src="https://github.com/user-attachments/assets/fafc8100-8daa-4cb1-a886-ad88b818e991" width="400px">
  <img src="https://github.com/user-attachments/assets/e92c0ed2-0588-4926-83ed-a90c003d2c06" width="400px">
  <img src="https://github.com/user-attachments/assets/1882357f-e17c-4a6e-8bde-6c9ad484b848" width="400px">
  <img src="https://github.com/user-attachments/assets/93d2e0e9-7440-4313-9c45-6d31c7c11868" width="400px">
  <img src="https://github.com/user-attachments/assets/8c23f89c-4bd3-4c24-8ca4-b441b08dbb43" width="600px">
</div>

### 🛠️ Технологический стек
- **Платформа:** .NET Framework
- **Интерфейс:** Windows Forms
- **База данных:** Microsoft SQL Server
- **ORM:** Entity Framework
- **Язык программирования:** C# (100%)

### 🎨 Фирменный стиль
- **Цветовая схема:**
  - Основной фон: `#FFFFFF` (белый)
  - Дополнительный фон: `#F4E8D3` (бежевый)
  - Акцент: `#67BA80` (зеленый)
- **Шрифт:** Segoe UI
- **Фирменная символика:** Логотип и иконка компании

## 🔥 Основной функционал

### 👥 Управление партнерами
- Добавление, редактирование и удаление партнеров
- Просмотр истории продаж по каждому партнеру
- Поиск партнеров по различным параметрам
- Система расчета скидок

### 📦 Управление продукцией
- Каталог продукции компании
- Управление ценами и характеристиками
- Отслеживание наличия на складе

### 💰 Управление продажами
- Оформление продаж
- История продаж
- Экспорт данных в Excel
- Расчет итоговых сумм с учетом скидок

## 📝 Структура проекта

### 📂 Основные модули
```plaintext
Demonstration_exam_2024/
├── Forms/                 # Формы пользовательского интерфейса
├── Models/               # Модели данных
├── Utils/               # Вспомогательные классы
└── Resources/           # Ресурсы приложения
```

### 🗃️ Структура базы данных
- **Users** - Пользователи системы
- **Partners** - Партнеры компании
- **Products** - Каталог продукции
- **Sales** - История продаж

## 🚀 Установка и запуск

### Требования
- Visual Studio 2022
- .NET Framework 4.8
- Microsoft SQL Server 2019 или новее
- [ClosedXML](https://github.com/ClosedXML/ClosedXML) (для работы с Excel)

### Пошаговая инструкция
1. Клонируйте репозиторий:
```bash
git clone https://github.com/ActBotArt/Demonstration_exam_2024.git
```

2. Откройте решение в Visual Studio:
```
Demonstration_exam_2024.sln
```

3. Восстановите пакеты NuGet:
```
Tools -> NuGet Package Manager -> Restore NuGet Packages
```

4. Настройте строку подключения к базе данных в `App.config`

5. Запустите приложение:
```
F5 или Debug -> Start Debugging
```

## ⚙️ Дополнительные возможности
- Система авторизации с разделением прав
- Поиск по всем основным сущностям
- Экспорт данных в Excel
- Расчет скидок для партнеров
- Удобный пользовательский интерфейс

