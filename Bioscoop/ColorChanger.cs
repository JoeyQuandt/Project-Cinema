using System;
using System.Collections.Generic;
using System.Text;

public static class ColorChanger
{
    public static void TextColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }
    public static void BackgroundColor(ConsoleColor color)
    {
        Console.BackgroundColor = color;
    }
}
