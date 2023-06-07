using KnuthMorrisPrattAlgorithm;
using System.Globalization;

var pattern = "text";
var text = "texttexttexandtext";
var kmp = new KMP();
kmp.FastPi(pattern);
var result = kmp.SearchEntry(text, pattern);
Console.WriteLine($"Найдены вхождения на позициях {string.Join(", ", result.ToArray())}");