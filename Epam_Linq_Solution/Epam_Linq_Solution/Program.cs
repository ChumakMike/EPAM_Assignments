using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Linq_Solution {

    class Student {
        public int School { get; set; } 
        public int Year { get; set; }
        public string Surname { get; set; }
    }

    class Program {
        static void Main(string[] args) {
           
            Console.WriteLine($"\nCompleted Tasks : ");

            #region Tasks
            {
                //LinqBegin6. Дана строковая последовательность.
                //Найти сумму длин всех строк, входящих в данную последовательность.
                //TODO
                List<string> str = new List<string> { "aBc", "qwerty", "wowow" };
                int len = str.Aggregate((x, y) => x + y).Length;
                Console.WriteLine($"\nLinqBegin6 -> {len}");
            }

            {
                //LinqBegin11. Дана последовательность непустых строк. 
                //Получить строку, состоящую из начальных символов всех строк исходной последовательности.
                //TODO
                List<string> str = new List<string> { "aBc", "qwerty", "arw" , "wowow" };
                string res = new string(str.Select(s => s[0]).ToArray());
                Console.WriteLine($"\nLinqBegin11 -> {res}");

            }

            {
                //LinqBegin22. Дано целое число K (> 0) и строковая последовательность A.
                //Строки последовательности содержат только цифры и заглавные буквы латинского алфавита.
                //Извлечь из A все строки длины K, оканчивающиеся цифрой, отсортировав их по возрастанию.
                //TODO
                int k = 3;
                List<string> str = new List<string> { "AD1CWER3", "QE5", "SD7", "AA2", "WWD22ADA1" };
                //var res = str.Where(x => x.EndsWith())
                var res = str.Where(x => (x.Length == k) && Char.IsDigit(x[k-1])).OrderBy(s => s);
                Console.Write("\nLinqBegin22 -> ");
                foreach (var r in res) {
                    Console.Write($"{r} ");
                }
            }

            {
                //LinqBegin29. Даны целые числа D и K (K > 0) и целочисленная последовательность A.
                //Найти теоретико - множественное объединение двух фрагментов A: первый содержит все элементы до первого элемента, 
                //большего D(не включая его), а второй — все элементы, начиная с элемента с порядковым номером K.
                //Полученную последовательность(не содержащую одинаковых элементов) отсортировать по убыванию.
                //TODO
                int k = 3;
                int d = 6;
                IEnumerable<int> n = new int[] { 1, 3, 5, 4, 6, 6, 2, 70, 8, 9, 0, 90 };
                var res = n.TakeWhile(x => x < d).Union(n.Skip(k)).OrderByDescending(x => x);
                Console.Write("\n\nLinqBegin29 -> ");
                foreach(var r in res) {
                    Console.Write($"{r} ");
                }
            }

            {
                //LinqBegin36. Дана последовательность непустых строк. 
                //Получить последовательность символов, которая определяется следующим образом: 
                //если соответствующая строка исходной последовательности имеет нечетную длину, то в качестве
                //символа берется первый символ этой строки; в противном случае берется последний символ строки.
                //Отсортировать полученные символы по убыванию их кодов.
                //TODO
                List<string> str = new List<string> { "aBc", "qwerty", "bbarw", "wowow" };
                var res = str.Select(s => {
                    if (s.Length % 2 != 0) return s[0];
                    return s[s.Length-1];
                }).OrderByDescending(x => x);
                
                Console.Write("\n\nLinqBegin36 ->");
                foreach(var r in res) 
                    Console.Write($" {r} ");
            }

            {
                //LinqBegin44. Даны целые числа K1 и K2 и целочисленные последовательности A и B.
                //Получить последовательность, содержащую все числа из A, большие K1, и все числа из B, меньшие K2. 
                //Отсортировать полученную последовательность по возрастанию.
                //TODO
                int k1 = 4;
                int k2 = 8;
                IEnumerable<int> A = new int[] { 1, 3, 5, 10, 2, 8, 3};
                IEnumerable<int> B = new int[] { 1, 2, 12, 10, 22, 8, 3 };

                var res = A.Where(x => x > k1).Union(B.Where(n => n < k2).Select(n => n)).OrderBy(s => s);
                Console.Write("\n\nLinqBegin44 ->");
                foreach (var r in res)
                    Console.Write($" {r} ");
            }

            {
                //LinqBegin48.Даны строковые последовательности A и B; все строки в каждой последовательности различны, 
                //имеют ненулевую длину и содержат только цифры и заглавные буквы латинского алфавита. 
                //Найти внутреннее объединение A и B, каждая пара которого должна содержать строки одинаковой длины.
                //Представить найденное объединение в виде последовательности строк, содержащих первый и второй элементы пары, 
                //разделенные двоеточием, например, «AB: CD». Порядок следования пар должен определяться порядком 
                //первых элементов пар(по возрастанию), а для равных первых элементов — порядком вторых элементов пар(по убыванию).
                //TODO
                List<string> str1 = new List<string> { "ABC3", "QWERTY", "ADARW", "WAW" };
                List<string> str2 = new List<string> { "FFW1ER", "UHNKH", "GTH", "1ASD", "AAAA" };
                var res = str1.Join(str2, x => x.Length, y => y.Length, (x, y) => x.ToString() + " : " + y.ToString()).OrderBy(x => x[0]).ThenByDescending(s=>s[1]);
                Console.Write("\n\nLinqBegin48 ->");
                foreach (var r in res)
                    Console.Write($" {r} ");
            }



            {
                //LinqObj17. Исходная последовательность содержит сведения об абитуриентах. Каждый элемент последовательности
                //включает следующие поля: < Номер школы > < Год поступления > < Фамилия >
                //Для каждого года, присутствующего в исходных данных, вывести число различных школ, которые окончили абитуриенты, 
                //поступившие в этом году (вначале указывать число школ, затем год). 
                //Сведения о каждом годе выводить на новой строке и упорядочивать по возрастанию числа школ, 
                //а для совпадающих чисел — по возрастанию номера года.
                //TODO
                var students = new List<Student> {
                    new Student { Surname = "Chumak", School = 1, Year = 2017},
                    new Student { Surname = "Lemeshenko", School = 54, Year = 2008},
                    new Student { Surname = "Murashko", School = 37, Year = 2016},
                    new Student { Surname = "Lomaka", School = 11, Year = 2015},
                    new Student { Surname = "Kobrin", School = 2, Year = 2015},
                    new Student { Surname = "Kobr", School = 2, Year = 2016}
                };

                var result = students.GroupBy(x => x.Year).Select(group => 
                    new {
                        Schools = group.Count(),
                        Year = group.Key
                    })
                    .OrderBy(x => x.Schools).ThenBy(y => y.Year);

                Console.Write("\n\nLinqObj17 ->");
                foreach (var r in result)
                    Console.WriteLine($" {r} ");


            }
            #endregion
            Console.ReadKey();
        }
    }
}
