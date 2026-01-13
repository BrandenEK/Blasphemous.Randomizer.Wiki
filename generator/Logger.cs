using System;

namespace blas1wikigen;

public static class Logger
{
    public static void Info(object? message) => Print(message, ConsoleColor.White);

    public static void Warn(object? message) => Print(message, ConsoleColor.Yellow);

    public static void Error(object? message) => Print(message, ConsoleColor.Red);

    public static void Fatal(object? message) => Print(message, ConsoleColor.DarkRed);

    private static void Print(object? message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
    }
}
