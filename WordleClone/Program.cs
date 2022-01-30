// See https://aka.ms/new-console-template for more information
using WordleClone.Helpers;

Console.WriteLine("======================================");
Console.WriteLine("======================================");

Console.WriteLine("Wordle clone.");

Console.WriteLine("======================================");
Console.WriteLine("======================================");

Console.WriteLine("Correct letters that match will show as {a}.");
Console.WriteLine("Letters that are correct but in the wrong place will show as <a>");
Console.WriteLine("E.g. if the word is ROUND and you guess SOUND, the output will be S{O}{U}{N}{D}");
Console.WriteLine("If the word is TRUNK and you guess OUNCE, the output will be <O>UNCE.");

Console.WriteLine("======================================");
Console.WriteLine("======================================");

var file = File.ReadAllLines("wordfiles/6letterwords.txt");

var randomLine = new Random().Next(0, file.Length - 1);
var chosenWord = file[randomLine].ToUpper();

var guesser = new GuessHelper(chosenWord);

Console.WriteLine("6 letter word");
Console.WriteLine("You have 7 attempts.");

while (guesser.NumberOfGuesses <= 7)
{
    if (guesser.NumberOfGuesses == 0)
        Console.WriteLine("Enter your word and press enter.");

    var word = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(word)) continue;

    word = word.ToUpper();

    if (!file.Any(x => x.ToUpper() == word))
    {
        Console.WriteLine("Not in the list!");
        continue;
    }

    var guessword = guesser.GuessWord(word);

    Console.WriteLine(guessword);

    if (guesser.CorrectMatches == word.Length)
        break;
}


switch (guesser.NumberOfGuesses)
{
    case 1:
        Console.WriteLine("Amazing!");
        break;
    case 2:
        Console.WriteLine("Good job!");
        break;
    case 3:
        Console.WriteLine("Nice!");
        break;
    case 4:
        Console.WriteLine("Average!");
        break;
    case 5:
        Console.WriteLine("Amazing!");
        break;
    case 6:
        Console.WriteLine("oof!");
        break;
    case 7:
        Console.WriteLine("Phew!");
        break;
    default:
        Console.WriteLine("Too bad!");
        break;
}

Console.WriteLine($"The word was {chosenWord}");