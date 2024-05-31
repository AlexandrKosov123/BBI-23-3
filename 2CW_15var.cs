// TASK 1

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();

        int count = CountConjunctionsAndPrepositions(input);

        Console.WriteLine($"Количество предлогов и союзов без гласных: {count}");
    }

    static int CountConjunctionsAndPrepositions(string text)
    {
        int count = 0;
        bool isVowel(char c)
        {
            return "aeiouAEIOUаеёиоуыэюяАЕЁИОУЫЭЮЯ".Contains(c);
        }

        bool isConjunctionOrPreposition(string word)
        {
            string[] conjunctionsAndPrepositions = { "и", "а", "но", "да", "или", "если", "лишь", "чтобы", "пока", "также", "как", "чем", "что", "чтоб", "когда", "ли", "пусть", "тоже", "то", "точно", "для", "с", "в", "на", "за", "по", "о", "об", "от", "при", "под", "перед", "к", "ко", "со", "над", "до", "из", "или", "нет", "ну", "так", "тож", "у", "же", "как", "и", "и", "же" };

            foreach (string wordInList in conjunctionsAndPrepositions)
            {
                if (word.Equals(wordInList, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            bool hasVowel = false;
            foreach (char c in word)
            {
                if (isVowel(c))
                {
                    hasVowel = true;
                    break;
                }
            }

            if (!hasVowel && isConjunctionOrPreposition(word))
            {
                count++;
            }
        }

        return count;
    }
}


//TASK 2

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();

        double ratio = CalculateRatio(input);

        Console.WriteLine($"Отношение различных букв к различным символам и цифрам: {ratio:F2}");
    }

    static double CalculateRatio(string text)
    {
        int uniqueLetters = 0;
        int uniqueDigitsAndPunctuation = 0;

        bool[] letters = new bool[128];
        bool[] digitsAndPunctuation = new bool[128];

        foreach (char c in text)
        {
            if (c != ' ')
            {
                if (char.IsLetter(c) && !letters[c])
                {
                    letters[c] = true;
                    uniqueLetters++;
                }
                else if ((char.IsDigit(c) || char.IsPunctuation(c)) && !digitsAndPunctuation[c])
                {
                    digitsAndPunctuation[c] = true;
                    uniqueDigitsAndPunctuation++;
                }
            }
        }

        double ratio = (double)uniqueLetters / uniqueDigitsAndPunctuation;
        return ratio;
    }
}


// TASK 3

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string testFolderPath = Path.Combine(desktopPath, "Test");


        if (!Directory.Exists(testFolderPath))
        {
            // Если не существует, создаем 
            Directory.CreateDirectory(testFolderPath);
        }

        // Создаем путь к первому файлу
        string file1Path = Path.Combine(testFolderPath, "cw2_1.json");

        if (!File.Exists(file1Path))
        {
            // Если не существует, создаем его
            File.Create(file1Path).Close(); 
        }

        // Создаем путь ко второму файлу
        string file2Path = Path.Combine(testFolderPath, "cw2_2.json");

        if (!File.Exists(file2Path))
        {
            // Если не существует, создаем его
            File.Create(file2Path).Close();
        }

        Console.WriteLine("Файлы успешно созданы.");
    }
}


// TASK 4

using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string testFolderPath = Path.Combine(desktopPath, "Test");

        if (!Directory.Exists(testFolderPath))
        {
            Directory.CreateDirectory(testFolderPath);
        }

        // Задание 1: входные данные
        TaskInput task1Input = new TaskInput
        {
            //Тут должны быть входные данные первой задачи
        };


        string task1InputFilePath = Path.Combine(testFolderPath, "task1_input.json");
        SaveOrDisplayJson(task1InputFilePath, task1Input);

        // Задание 2: входные данные
        TaskInput task2Input = new TaskInput
        {
            //А тут - второй.
        };

        string task2InputFilePath = Path.Combine(testFolderPath, "task2_input.json");
        SaveOrDisplayJson(task2InputFilePath, task2Input);

        Console.WriteLine("Данные успешно сохранены или выведены на консоль.");
    }

    // Метод для сохранения объекта в JSON файл или вывода на консоль, если файл уже существует
    static void SaveOrDisplayJson<T>(string filePath, T data)
    {
        if (File.Exists(filePath))
        {
            // Если файл существует, читаем его содержимое и выводим на консоль
            string json = File.ReadAllText(filePath);
            Console.WriteLine($"Содержимое файла {Path.GetFileName(filePath)}:");
            Console.WriteLine(json);
        }
        else
        {
            // Если файл не существует, сохраняем данные в JSON файл
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Данные сохранены в файле: {Path.GetFileName(filePath)}");
        }
    }
}


class TaskInput
{

}




