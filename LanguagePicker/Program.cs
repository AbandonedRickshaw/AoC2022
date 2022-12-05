using System;
using System.Collections.Generic;
using System.Text.Json;

var AllLanguageChoiceFile = "AoC.Language.Choices.json";
var PreviousChoiceFile = "AoC2022.Language.Choices.json";

var AllLanguages = System.Text.Json.JsonSerializer.Deserialize<List<string>>(File.ReadAllText(AllLanguageChoiceFile))!;

var PreviousChoices = File.Exists(PreviousChoiceFile)
    ? System.Text.Json.JsonSerializer.Deserialize<List<string>>(File.ReadAllText(PreviousChoiceFile))!
    : new List<string>();

var languages = AllLanguages.Except(PreviousChoices).ToList();
var random = new Random();

var fg = Console.ForegroundColor;
while (true)
{
    var language = languages[random.Next(languages.Count)];
    Console.Clear();
    Console.Write("Today your language is: ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(language);
    Console.ForegroundColor = fg;
    Console.WriteLine();
    Console.Write("Accept this language? [Y]es or [N]o? [Yes]: ");
    var response = Console.ReadKey().Key;
    switch (response)
    {
        case ConsoleKey.Y:
        case ConsoleKey.Enter:
            Console.WriteLine($"\nSelecting and removing {language} from future choices");
            PreviousChoices.Add(language);
            File.WriteAllText(PreviousChoiceFile, JsonSerializer.Serialize(PreviousChoices));
            return;
    }
}
