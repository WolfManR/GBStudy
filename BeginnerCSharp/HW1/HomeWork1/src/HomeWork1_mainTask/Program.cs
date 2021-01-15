using System;
using static System.Console;


#region Program Body

Write("Пожалуйста представьтесь: ");
var userName = ReadLine();
var name = (userName?[0].ToString().ToUpperInvariant() + userName?[1..].ToLowerInvariant()).Trim();

WriteLine($"\r\nПривет, {(name is {Length: > 0} user ? user : "Noname")}, сегодня {DateTime.Now:dd.MM.yyyy}");

#endregion

// Program stop
ReadLine();