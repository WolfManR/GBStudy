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
    private static void Main(string[] args) => new ConsolePrinter( new CharConsoleColor[]
    {
      new('H', ConsoleColor.Cyan),
      new('l', ConsoleColor.DarkBlue),
      new('W', ConsoleColor.Red),
      new('d', ConsoleColor.DarkYellow)
    }).Print("Hello World!");
  }
}
