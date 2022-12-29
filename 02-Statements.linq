<Query Kind="Statements" />

var dt = DateTime.Now;

dt = dt.AddDays(5);

dt.Dump();

DateTime.Now.Next(DayOfWeek.Monday).Dump();

Util.Dif("Some long string I came up with to prove a point","Some short string I came up with to prove the point").Dump();