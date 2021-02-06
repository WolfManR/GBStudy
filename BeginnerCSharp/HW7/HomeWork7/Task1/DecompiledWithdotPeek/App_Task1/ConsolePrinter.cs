// Decompiled with JetBrains decompiler
// Type: AppFor_Task1_Task2.ConsolePrinter
// Assembly: AppFor_Task1_Task2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7C441126-F631-4792-8FD5-C6E9D2B261ED
// Assembly location: D:\Projects\Programming\CSharp\Studi\GeekBrains\GBStudy\BeginnerCSharp\HW7\HomeWork7\AppFor_Task1_Task2\bin\Debug\net5.0\AppFor_Task1_Task2.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace AppFor_Task1_Task2
{
  public class ConsolePrinter
  {
    private readonly List<CharConsoleColor> _colors;
    private const ConsoleColor DefaultColor = ConsoleColor.White;

    public ConsolePrinter(IEnumerable<CharConsoleColor> colors) => this._colors = colors.ToList<CharConsoleColor>();

    public void Print(string toPrint)
    {
      int length = toPrint.Length;
      for (int i = 0; i < length; i++)
      {
        CharConsoleColor charConsoleColor = this._colors.Find((Predicate<CharConsoleColor>) (c => (int) (char) c == (int) toPrint[i]));
        if (charConsoleColor == null)
          Console.Write(toPrint[i]);
        else
          ConsolePrinter.PrintWithColor(toPrint[i], (ConsoleColor) charConsoleColor);
      }
    }

    private static void PrintWithColor(char character, ConsoleColor color)
    {
      Console.ForegroundColor = color;
      Console.Write(character);
      Console.ForegroundColor = ConsoleColor.White;
    }
  }
}
