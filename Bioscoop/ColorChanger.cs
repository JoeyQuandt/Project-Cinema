using System;
using System.Collections.Generic;
using System.Text;

public static class ColorChanger
{
    //Change textcolor
    public static void TextColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }
    // Change backgroundcolor 
    public static void BackgroundColor(ConsoleColor color)
    {
        Console.BackgroundColor = color;
    }
}
