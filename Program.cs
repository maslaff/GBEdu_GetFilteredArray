string[] fillArray = { "hello", "2", "world", ":-)" };
string[] sourceArray;
string[] newArray;
int maxWordLength = 3;
int maxArrayLength = 30;

if (!GetArray(out sourceArray, maxArrayLength)) sourceArray = fillArray;
PrintArray(sourceArray);

int lenNewArr = GetFilteredArray(sourceArray, out newArray, maxWordLength);
if (lenNewArr > 0)
    PrintArray(newArray);
else
    Console.WriteLine("Нет подходящих значений в массиве");

int GetFilteredArray(string[] srcArr, out string[] newArr, int maxLen)
{
    int count = 0;

    foreach (var el in srcArr)
        if (el.Length <= maxLen) count++;

    newArr = new string[count];

    for (int i = 0, j = 0; i < srcArr.Length; i++)
        if (srcArr[i].Length <= maxLen) newArr[j++] = srcArr[i];

    return count;
}

bool GetArray(out string[] arr, int max)
{
    arr = new string[max];
    int len = 0;

    Console.WriteLine($"Для автозаполнения нажмите Enter, иначе введите строку.\nНажимайте Enter для ввода следующей (Max {max}).\nДля завершения оставьте строку пустой и нажмите Enter.");

    for (int i = 0; i < arr.Length; i++)
    {
        string? str = Console.ReadLine();
        if (str == null || str == "") { len = i; break; }
        arr[i] = str;
    }

    if (len == 0)
    {
        arr = new string[0];
        return false;
    }

    if (len == arr.Length)
        Console.WriteLine($"Достигнут предел заполнения {max}");
    else Array.Resize(ref arr, len);

    return true;
}

void PrintArray(string[] arr, string sep = ", ")
{
    Console.Write($"[\"{arr[0]}\"");
    for (int i = 1; i < arr.Length; i++)
        Console.Write($"{sep}\"{arr[i]}\"");
    Console.WriteLine("]");
}