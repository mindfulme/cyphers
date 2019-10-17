using System;

public class VigenereCipher
{
    const string defaultAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    readonly string letters;

    public VigenereCipher(string alphabet = null)
    {
        letters = string.IsNullOrEmpty(alphabet) ? defaultAlphabet : alphabet;
    }

    //генерация повторяющегося пароля
    private string GetRepeatKey(string s, int n)
    {
        var p = s;
        while (p.Length < n)
        {
            p += p;
        }

        return p.Substring(0, n);
    }

    private string Vigenere(string text, string password, bool encrypting = true)
    {
        var gamma = GetRepeatKey(password, text.Length);
        var retValue = "";
        var q = letters.Length;

        for (int i = 0; i < text.Length; i++)
        {
            var letterIndex = letters.IndexOf(text[i]);
            var codeIndex = letters.IndexOf(gamma[i]);
            if (letterIndex < 0)
            {
                //если буква не найдена, добавляем её в исходном виде
                retValue += text[i].ToString();
            }
            else
            {
                retValue += letters[(q + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % q].ToString();
            }
        }

        return retValue;
    }

    //шифрование текста
    public string Encrypt(string plainMessage, string password)
        => Vigenere(plainMessage, password);

    //дешифрование текста
    public string Decrypt(string encryptedMessage, string password)
        => Vigenere(encryptedMessage, password, false);
}

class Program
{
    static void Main(string[] args)
    {
        //передаем в конструктор класса буквы алфавита
        var cipher = new VigenereCipher("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ");
        Console.Write("Введите текст: ");
        var inputText = Console.ReadLine().ToUpper();
        Console.Write("Введите ключ: ");
        var password = Console.ReadLine().ToUpper();
        var encryptedText = cipher.Encrypt(inputText, password);
        Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
        Console.WriteLine("Расшифрованное сообщение: {0}", cipher.Decrypt(encryptedText, password));
        Console.ReadLine();
    }
}