using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ngamming
{
	class Program
	{
		private string Encode(string input, string keyword)
		{
			int nomer; // Номер в алфавите
			int d; // Смещение
			string s; //Результат
			int j, f; // Переменная для циклов
			int t = 0; // Преременная для нумерации символов ключа.

			char[] massage = input.ToCharArray(); // Превращаем сообщение в массив символов.
			char[] key = keyword.ToCharArray(); // Превращаем ключ в массив символов.

			char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

			// Перебираем каждый символ сообщения
			for (int i = 0; i < massage.Length; i++)
			{
				// Ищем индекс буквы
				for (j = 0; j < alfavit.Length; j++)
				{
					if (massage[i] == alfavit[j])
					{
						break;
					}
				}

				if (j != 33) // Если j равно 33, значит символ не из алфавита
				{
					nomer = j; // Индекс буквы

					// Ключ закончился - начинаем сначала.
					if (t > key.Length - 1) { t = 0; }
					// Ищем индекс буквы ключа
					for (f = 0; f < alfavit.Length; f++)
					{
						if (key[t] == alfavit[f])
						{
							break;
						}
					}
					t++;
					if (f != 33) // Если f равно 33, значит символ не из алфавита
					{
						d = nomer + f;
					}
					else
					{
						d = nomer;
					}
					// Проверяем, чтобы не вышли за пределы алфавита
					if (d > 32)
					{
						d = d - 33;
					}
					massage[i] = alfavit[d]; // Меняем букву
				}
				var table = new int[5, input.Length];

			
			}
			s = new string(massage);
			return s;
		}


		static void Main(string[] args)
		{

			Program pr = new Program();
			Console.WriteLine("Гаммирования по модулю N");
			Console.WriteLine("Введите словосочетание для гаммирования:");
			string inp = Console.ReadLine();
			Console.WriteLine("Введите гамму:");
			string gam = Console.ReadLine();

			Console.WriteLine("Зашифрованное сообщение: " + pr.Encode(inp, gam));
			Console.WriteLine("Расшифрованное сообщение: " + inp);
			Console.ReadKey();

		}

	}

}
