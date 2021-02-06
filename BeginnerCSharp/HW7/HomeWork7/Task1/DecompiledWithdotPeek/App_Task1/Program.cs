// Decompiled with JetBrains decompiler
// Type: AppFor_Task1_Task2.Program
// Assembly: AppFor_Task1_Task2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7C441126-F631-4792-8FD5-C6E9D2B261ED
// Assembly location: D:\Projects\Programming\CSharp\Studi\GeekBrains\GBStudy\BeginnerCSharp\HW7\HomeWork7\AppFor_Task1_Task2\bin\Debug\net5.0\AppFor_Task1_Task2.dll

using System;
using System.Collections.Generic;

namespace AppFor_Task1_Task2
{
  internal class Program
  {
    private static void Main(string[] args) => new ConsolePrinter((IEnumerable<CharConsoleColor>) new CharConsoleColor[4]
    {
      new CharConsoleColor('H', ConsoleColor.Cyan),
      new CharConsoleColor('l', ConsoleColor.Yellow),
      new CharConsoleColor('W', ConsoleColor.Red),
      new CharConsoleColor('d', ConsoleColor.Magenta)
    }).Print("Hello World!");
  }
}
