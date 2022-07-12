// See https://aka.ms/new-console-template for more information

using ConsoleAppReadXMLFiltering;

Translations tra = new Translations();
var fileContent = tra.generateTranslationFiles();
Console.WriteLine("Hello, World!:" + fileContent.ToString());
