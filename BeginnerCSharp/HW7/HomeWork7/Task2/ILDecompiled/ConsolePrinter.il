
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0




// Metadata version: v4.0.30319
.assembly extern System.Runtime
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 5:0:0:0
}
.assembly extern System.Collections
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 5:0:0:0
}
.assembly extern System.Console
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 5:0:0:0
}
.assembly extern System.Linq
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 5:0:0:0
}
.assembly AppFor_Task1_Task2
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                   63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- Следующий настраиваемый атрибут добавлен автоматически, не следует отменять преобразование в комментарий -------
  //  .custom instance void [System.Runtime]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [System.Runtime]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 18 2E 4E 45 54 43 6F 72 65 41 70 70 2C 56   // ....NETCoreApp,V
                                                                                                              65 72 73 69 6F 6E 3D 76 35 2E 30 01 00 54 0E 14   // ersion=v5.0..T..
                                                                                                              46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C 61 79   // FrameworkDisplay
                                                                                                              4E 61 6D 65 00 )                                  // Name.
  .custom instance void [System.Runtime]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 12 41 70 70 46 6F 72 5F 54 61 73 6B 31 5F   // ...AppFor_Task1_
                                                                                                      54 61 73 6B 32 00 00 )                            // Task2..
  .custom instance void [System.Runtime]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 05 44 65 62 75 67 00 00 )                   // ...Debug..
  .custom instance void [System.Runtime]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [System.Runtime]System.Reflection.AssemblyInformationalVersionAttribute::.ctor(string) = ( 01 00 05 31 2E 30 2E 30 00 00 )                   // ...1.0.0..
  .custom instance void [System.Runtime]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 12 41 70 70 46 6F 72 5F 54 61 73 6B 31 5F   // ...AppFor_Task1_
                                                                                                      54 61 73 6B 32 00 00 )                            // Task2..
  .custom instance void [System.Runtime]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 12 41 70 70 46 6F 72 5F 54 61 73 6B 31 5F   // ...AppFor_Task1_
                                                                                                    54 61 73 6B 32 00 00 )                            // Task2..
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module AppFor_Task1_Task2.dll
// MVID: {7C441126-F631-4792-8FD5-C6E9D2B261ED}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x09040000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit AppFor_Task1_Task2.Program
       extends [System.Runtime]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Размер кода:       74 (0x4a)
    .maxstack  5
    .locals init (class AppFor_Task1_Task2.ConsolePrinter V_0)
    IL_0000:  nop
    IL_0001:  ldc.i4.4
    IL_0002:  newarr     AppFor_Task1_Task2.CharConsoleColor
    IL_0007:  dup
    IL_0008:  ldc.i4.0
    IL_0009:  ldc.i4.s   72
    IL_000b:  ldc.i4.s   11
    IL_000d:  newobj     instance void AppFor_Task1_Task2.CharConsoleColor::.ctor(char,
                                                                                  valuetype [System.Console]System.ConsoleColor)
    IL_0012:  stelem.ref
    IL_0013:  dup
    IL_0014:  ldc.i4.1
    IL_0015:  ldc.i4.s   108
    IL_0017:  ldc.i4.s   14
    IL_0019:  newobj     instance void AppFor_Task1_Task2.CharConsoleColor::.ctor(char,
                                                                                  valuetype [System.Console]System.ConsoleColor)
    IL_001e:  stelem.ref
    IL_001f:  dup
    IL_0020:  ldc.i4.2
    IL_0021:  ldc.i4.s   87
    IL_0023:  ldc.i4.s   12
    IL_0025:  newobj     instance void AppFor_Task1_Task2.CharConsoleColor::.ctor(char,
                                                                                  valuetype [System.Console]System.ConsoleColor)
    IL_002a:  stelem.ref
    IL_002b:  dup
    IL_002c:  ldc.i4.3
    IL_002d:  ldc.i4.s   100
    IL_002f:  ldc.i4.s   13
    IL_0031:  newobj     instance void AppFor_Task1_Task2.CharConsoleColor::.ctor(char,
                                                                                  valuetype [System.Console]System.ConsoleColor)
    IL_0036:  stelem.ref
    IL_0037:  newobj     instance void AppFor_Task1_Task2.ConsolePrinter::.ctor(class [System.Runtime]System.Collections.Generic.IEnumerable`1<class AppFor_Task1_Task2.CharConsoleColor>)
    IL_003c:  stloc.0
    IL_003d:  ldloc.0
    IL_003e:  ldstr      "Hello World!"
    IL_0043:  callvirt   instance void AppFor_Task1_Task2.ConsolePrinter::Print(string)
    IL_0048:  nop
    IL_0049:  ret
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program::.ctor

} // end of class AppFor_Task1_Task2.Program

.class public auto ansi beforefieldinit AppFor_Task1_Task2.ConsolePrinter
       extends [System.Runtime]System.Object
{
  .class auto ansi sealed nested private beforefieldinit '<>c__DisplayClass3_0'
         extends [System.Runtime]System.Object
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public string toPrint
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // Размер кода:       8 (0x8)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [System.Runtime]System.Object::.ctor()
      IL_0006:  nop
      IL_0007:  ret
    } // end of method '<>c__DisplayClass3_0'::.ctor

  } // end of class '<>c__DisplayClass3_0'

  .class auto ansi sealed nested private beforefieldinit '<>c__DisplayClass3_1'
         extends [System.Runtime]System.Object
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public int32 i
    .field public class AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_0' 'CS$<>8__locals1'
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // Размер кода:       8 (0x8)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [System.Runtime]System.Object::.ctor()
      IL_0006:  nop
      IL_0007:  ret
    } // end of method '<>c__DisplayClass3_1'::.ctor

    .method assembly hidebysig instance bool 
            '<Print>b__0'(class AppFor_Task1_Task2.CharConsoleColor c) cil managed
    {
      // Размер кода:       31 (0x1f)
      .maxstack  8
      IL_0000:  ldarg.1
      IL_0001:  call       char AppFor_Task1_Task2.CharConsoleColor::op_Implicit(class AppFor_Task1_Task2.CharConsoleColor)
      IL_0006:  ldarg.0
      IL_0007:  ldfld      class AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_0' AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1'::'CS$<>8__locals1'
      IL_000c:  ldfld      string AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_0'::toPrint
      IL_0011:  ldarg.0
      IL_0012:  ldfld      int32 AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1'::i
      IL_0017:  callvirt   instance char [System.Runtime]System.String::get_Chars(int32)
      IL_001c:  ceq
      IL_001e:  ret
    } // end of method '<>c__DisplayClass3_1'::'<Print>b__0'

  } // end of class '<>c__DisplayClass3_1'

  .field private initonly class [System.Collections]System.Collections.Generic.List`1<class AppFor_Task1_Task2.CharConsoleColor> _colors
  .field private static literal valuetype [System.Console]System.ConsoleColor DefaultColor = int32(0x0000000F)
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class [System.Runtime]System.Collections.Generic.IEnumerable`1<class AppFor_Task1_Task2.CharConsoleColor> colors) cil managed
  {
    // Размер кода:       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  call       class [System.Collections]System.Collections.Generic.List`1<!!0> [System.Linq]System.Linq.Enumerable::ToList<class AppFor_Task1_Task2.CharConsoleColor>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0>)
    IL_000e:  stfld      class [System.Collections]System.Collections.Generic.List`1<class AppFor_Task1_Task2.CharConsoleColor> AppFor_Task1_Task2.ConsolePrinter::_colors
    IL_0013:  ret
  } // end of method ConsolePrinter::.ctor

  .method public hidebysig instance void 
          Print(string toPrint) cil managed
  {
    // Размер кода:       185 (0xb9)
    .maxstack  3
    .locals init (class AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_0' V_0,
             int32 V_1,
             class AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1' V_2,
             class AppFor_Task1_Task2.CharConsoleColor V_3,
             bool V_4,
             int32 V_5,
             bool V_6)
    IL_0000:  newobj     instance void AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_0'::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  ldarg.1
    IL_0008:  stfld      string AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_0'::toPrint
    IL_000d:  nop
    IL_000e:  ldloc.0
    IL_000f:  ldfld      string AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_0'::toPrint
    IL_0014:  callvirt   instance int32 [System.Runtime]System.String::get_Length()
    IL_0019:  stloc.1
    IL_001a:  newobj     instance void AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1'::.ctor()
    IL_001f:  stloc.2
    IL_0020:  ldloc.2
    IL_0021:  ldloc.0
    IL_0022:  stfld      class AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_0' AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1'::'CS$<>8__locals1'
    IL_0027:  ldloc.2
    IL_0028:  ldc.i4.0
    IL_0029:  stfld      int32 AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1'::i
    IL_002e:  br.s       IL_00a6

    IL_0030:  nop
    IL_0031:  ldarg.0
    IL_0032:  ldfld      class [System.Collections]System.Collections.Generic.List`1<class AppFor_Task1_Task2.CharConsoleColor> AppFor_Task1_Task2.ConsolePrinter::_colors
    IL_0037:  ldloc.2
    IL_0038:  ldftn      instance bool AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1'::'<Print>b__0'(class AppFor_Task1_Task2.CharConsoleColor)
    IL_003e:  newobj     instance void class [System.Runtime]System.Predicate`1<class AppFor_Task1_Task2.CharConsoleColor>::.ctor(object,
                                                                                                                                  native int)
    IL_0043:  callvirt   instance !0 class [System.Collections]System.Collections.Generic.List`1<class AppFor_Task1_Task2.CharConsoleColor>::Find(class [System.Runtime]System.Predicate`1<!0>)
    IL_0048:  stloc.3
    IL_0049:  ldloc.3
    IL_004a:  ldnull
    IL_004b:  ceq
    IL_004d:  stloc.s    V_4
    IL_004f:  ldloc.s    V_4
    IL_0051:  brfalse.s  IL_0071

    IL_0053:  ldloc.2
    IL_0054:  ldfld      class AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_0' AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1'::'CS$<>8__locals1'
    IL_0059:  ldfld      string AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_0'::toPrint
    IL_005e:  ldloc.2
    IL_005f:  ldfld      int32 AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1'::i
    IL_0064:  callvirt   instance char [System.Runtime]System.String::get_Chars(int32)
    IL_0069:  call       void [System.Console]System.Console::Write(char)
    IL_006e:  nop
    IL_006f:  br.s       IL_0093

    IL_0071:  ldloc.2
    IL_0072:  ldfld      class AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_0' AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1'::'CS$<>8__locals1'
    IL_0077:  ldfld      string AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_0'::toPrint
    IL_007c:  ldloc.2
    IL_007d:  ldfld      int32 AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1'::i
    IL_0082:  callvirt   instance char [System.Runtime]System.String::get_Chars(int32)
    IL_0087:  ldloc.3
    IL_0088:  call       valuetype [System.Console]System.ConsoleColor AppFor_Task1_Task2.CharConsoleColor::op_Implicit(class AppFor_Task1_Task2.CharConsoleColor)
    IL_008d:  call       void AppFor_Task1_Task2.ConsolePrinter::PrintWithColor(char,
                                                                                valuetype [System.Console]System.ConsoleColor)
    IL_0092:  nop
    IL_0093:  nop
    IL_0094:  ldloc.2
    IL_0095:  ldfld      int32 AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1'::i
    IL_009a:  stloc.s    V_5
    IL_009c:  ldloc.2
    IL_009d:  ldloc.s    V_5
    IL_009f:  ldc.i4.1
    IL_00a0:  add
    IL_00a1:  stfld      int32 AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1'::i
    IL_00a6:  ldloc.2
    IL_00a7:  ldfld      int32 AppFor_Task1_Task2.ConsolePrinter/'<>c__DisplayClass3_1'::i
    IL_00ac:  ldloc.1
    IL_00ad:  clt
    IL_00af:  stloc.s    V_6
    IL_00b1:  ldloc.s    V_6
    IL_00b3:  brtrue     IL_0030

    IL_00b8:  ret
  } // end of method ConsolePrinter::Print

  .method private hidebysig static void  PrintWithColor(char character,
                                                        valuetype [System.Console]System.ConsoleColor color) cil managed
  {
    // Размер кода:       24 (0x18)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldarg.1
    IL_0002:  call       void [System.Console]System.Console::set_ForegroundColor(valuetype [System.Console]System.ConsoleColor)
    IL_0007:  nop
    IL_0008:  ldarg.0
    IL_0009:  call       void [System.Console]System.Console::Write(char)
    IL_000e:  nop
    IL_000f:  ldc.i4.s   15
    IL_0011:  call       void [System.Console]System.Console::set_ForegroundColor(valuetype [System.Console]System.ConsoleColor)
    IL_0016:  nop
    IL_0017:  ret
  } // end of method ConsolePrinter::PrintWithColor

} // end of class AppFor_Task1_Task2.ConsolePrinter

.class public auto ansi beforefieldinit AppFor_Task1_Task2.CharConsoleColor
       extends [System.Runtime]System.Object
{
  .field private initonly char '<Character>k__BackingField'
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [System.Runtime]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field private initonly valuetype [System.Console]System.ConsoleColor '<Color>k__BackingField'
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [System.Runtime]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .method public hidebysig specialname instance char 
          get_Character() cil managed
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Размер кода:       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      char AppFor_Task1_Task2.CharConsoleColor::'<Character>k__BackingField'
    IL_0006:  ret
  } // end of method CharConsoleColor::get_Character

  .method public hidebysig specialname instance void modreq([System.Runtime]System.Runtime.CompilerServices.IsExternalInit) 
          set_Character(char 'value') cil managed
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Размер кода:       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      char AppFor_Task1_Task2.CharConsoleColor::'<Character>k__BackingField'
    IL_0007:  ret
  } // end of method CharConsoleColor::set_Character

  .method public hidebysig specialname instance valuetype [System.Console]System.ConsoleColor 
          get_Color() cil managed
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Размер кода:       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      valuetype [System.Console]System.ConsoleColor AppFor_Task1_Task2.CharConsoleColor::'<Color>k__BackingField'
    IL_0006:  ret
  } // end of method CharConsoleColor::get_Color

  .method public hidebysig specialname instance void modreq([System.Runtime]System.Runtime.CompilerServices.IsExternalInit) 
          set_Color(valuetype [System.Console]System.ConsoleColor 'value') cil managed
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Размер кода:       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      valuetype [System.Console]System.ConsoleColor AppFor_Task1_Task2.CharConsoleColor::'<Color>k__BackingField'
    IL_0007:  ret
  } // end of method CharConsoleColor::set_Color

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(char character,
                               valuetype [System.Console]System.ConsoleColor color) cil managed
  {
    // Размер кода:       25 (0x19)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ldarg.0
    IL_0009:  ldarg.1
    IL_000a:  call       instance void modreq([System.Runtime]System.Runtime.CompilerServices.IsExternalInit) AppFor_Task1_Task2.CharConsoleColor::set_Character(char)
    IL_000f:  nop
    IL_0010:  ldarg.0
    IL_0011:  ldarg.2
    IL_0012:  call       instance void modreq([System.Runtime]System.Runtime.CompilerServices.IsExternalInit) AppFor_Task1_Task2.CharConsoleColor::set_Color(valuetype [System.Console]System.ConsoleColor)
    IL_0017:  nop
    IL_0018:  ret
  } // end of method CharConsoleColor::.ctor

  .method public hidebysig specialname static 
          char  op_Implicit(class AppFor_Task1_Task2.CharConsoleColor toParse) cil managed
  {
    // Размер кода:       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance char AppFor_Task1_Task2.CharConsoleColor::get_Character()
    IL_0006:  ret
  } // end of method CharConsoleColor::op_Implicit

  .method public hidebysig specialname static 
          valuetype [System.Console]System.ConsoleColor 
          op_Implicit(class AppFor_Task1_Task2.CharConsoleColor toParse) cil managed
  {
    // Размер кода:       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance valuetype [System.Console]System.ConsoleColor AppFor_Task1_Task2.CharConsoleColor::get_Color()
    IL_0006:  ret
  } // end of method CharConsoleColor::op_Implicit

  .property instance char Character()
  {
    .get instance char AppFor_Task1_Task2.CharConsoleColor::get_Character()
    .set instance void modreq([System.Runtime]System.Runtime.CompilerServices.IsExternalInit) AppFor_Task1_Task2.CharConsoleColor::set_Character(char)
  } // end of property CharConsoleColor::Character
  .property instance valuetype [System.Console]System.ConsoleColor
          Color()
  {
    .get instance valuetype [System.Console]System.ConsoleColor AppFor_Task1_Task2.CharConsoleColor::get_Color()
    .set instance void modreq([System.Runtime]System.Runtime.CompilerServices.IsExternalInit) AppFor_Task1_Task2.CharConsoleColor::set_Color(valuetype [System.Console]System.ConsoleColor)
  } // end of property CharConsoleColor::Color
} // end of class AppFor_Task1_Task2.CharConsoleColor


// =============================================================

// *********** ДИЗАССЕМБЛИРОВАНИЕ ЗАВЕРШЕНО ***********************
// ВНИМАНИЕ: создан файл ресурсов Win32 D:\Projects\Programming\CSharp\Studi\GeekBrains\GBStudy\BeginnerCSharp\HW7\HomeWork7\Task2\ILDecompiled\ConsolePrinter.res
