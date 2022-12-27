<Query Kind="Statements" />

var dt = DateTime.Now;

dt = dt.AddDays(5);

dt.Dump();

DateTime.Now.Next(DayOfWeek.Monday).Dump();