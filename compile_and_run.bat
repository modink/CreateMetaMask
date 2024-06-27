@echo off

REM Проверка, что .NET SDK установлен
dotnet --version >nul 2>&1
IF %ERRORLEVEL% NEQ 0 (
    echo .NET SDK не установлен. Пожалуйста, установите .NET SDK с https://dotnet.microsoft.com/download
    pause
    exit /b 1
)

echo .NET SDK установлен.



REM Компиляция проекта
dotnet build
IF %ERRORLEVEL% NEQ 0 (
    echo Ошибка компиляции проекта.
    pause
    exit /b 1
)

REM Запуск проекта
dotnet run
IF %ERRORLEVEL% NEQ 0 (
    echo Ошибка выполнения проекта.
    pause
    exit /b 1
)

pause
