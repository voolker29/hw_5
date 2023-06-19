Console.WriteLine("Введите текст:");
var inputString = Console.ReadLine();
var menu =
    "1. Найти слова, содержащие максимальное количество цифр.\n" +
    "2. Найти самое длинное слово и определить, сколько раз оно встретилось в тексте\n" +
    "3.Заменить цифры от 0 до 9 на слова «ноль», «один», …, «девять»\n" +
    "4.Вывести на экран сначала вопросительные, а затем восклицательные предложения\n" +
    "5.Вывести на экран только предложения, не содержащие запятых\n" +
    "6.Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву\n"+
    "Выберите номер действия.\n";


var exempleString = "0123456789";

while (true)
{
    Console.WriteLine(new string('-', 50));
    Console.WriteLine(menu);
    var action = Console.ReadLine();
    Console.WriteLine(new string('-', 50));

    switch (action)
    {
        case "1":
            var splitText = inputString.Split(' ');
            var countNumber = new int[splitText.Length];
   
            for (int i = 0; i < splitText.Length; i++)
            {
                var count = 0;
                foreach (var item in splitText[i])
                {

                    if (exempleString.IndexOf(item) != -1)
                    {
                        count += 1;

                    }


                }
                countNumber[i] = count;
            }
            var index = Array.IndexOf(countNumber, countNumber.Max());

            if (index != -1 & countNumber.Max() != 0)
            {
                Console.WriteLine($"Результат = {splitText[index]}");
            }
            else
            {
                Console.WriteLine("Результат = Не нашли слов с числами");
            }

            break;

        case "2":
            splitText = inputString.Split(' ');
            countNumber = new int[splitText.Length];
            for (int i = 0; i < splitText.Length; i++)
            {
                countNumber[i] = splitText[i].Length;
            }

            var maxLenghWord = Convert.ToString(splitText.GetValue(Array.IndexOf(countNumber, countNumber.Max())));

            var countWoord = 0;
            foreach (var item in splitText)
            {
                if (item == maxLenghWord)
                {
                    countWoord += 1;
                }

            }
            Console.WriteLine($"Самое длиное слово = {maxLenghWord} ,встретилось {countWoord} раз");
            break;

        case "3":
            var stringNumbers = new string[10] {
                                                "Ноль","Один","Два","Три",
                                                "Четыре","Пять","Шесть",
                                                "Семь","Восемь","Девять"};



            var str = inputString;
            for (int i = 0; i < stringNumbers.Length; i++)
            {
                str = str.Replace(Convert.ToString(i), stringNumbers[i]);

            }
           
            Console.WriteLine($"Результат = {str}"); 
            break;

        case "4":

            str = inputString;
            str = str.Replace(".", ".~~");
            str = str.Replace("!", "!~~");
            str = str.Replace("?", "?~~");
            splitText = str.Split("~~");
            var questionString = new string[splitText.Length];
            var exclamationString = new string[splitText.Length];
            var cou = 0;
            foreach (var item in splitText)
            {
                if (item == "")
                {
                    continue;
                }
                if ('!' == item[item.Length - 1])
                {
                    exclamationString[cou] = item;
                }
                else if ('?' == item[item.Length - 1])
                {
                    questionString[cou] = item;
                }
                cou++;
            }

            foreach (var item in exclamationString)
            {
                if (item != null) 
                { 
                Console.WriteLine(item);
                }
            }

            foreach (var item in questionString)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                }
            }

            break;

        case "5":
            str = inputString;
            str = str.Replace(".", ".~~");
            str = str.Replace("!", "!~~");
            str = str.Replace("?", "?~~");
            splitText = str.Split("~~");
            foreach (var item in splitText)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (!item.Contains(","))
                    {
                        Console.WriteLine(item);                       
                    }
                
                }
            }
            break;
        case "6":

            var chars = new char[] { '.', ' ', '!', '?' , ',' };
            splitText = inputString.Split(chars);
            var @char = ' ';

            foreach (var item in splitText)
            {
                if (item =="")
                {
                    continue;
                }
                @char = item[0];
                if (item.StartsWith(@char) & item.EndsWith(@char))
                {
                    Console.WriteLine(item);

                }

            }
            break;
        default:
        Console.WriteLine("Номер действия не распознан");
        break;
}
};