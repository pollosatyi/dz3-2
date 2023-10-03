using System;
using System.Linq;
using System.Net;

namespace dz_3_2
{
    public class Program
    {
        public delegate List<int[]> SumSevenDelegate(List<int> list);
        public delegate int CountStrDelegate(List<string>list);
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            SumSevenDelegate sum7 = new SumSevenDelegate(SumSeven);
            foreach (int[] ints in sum7(list))
            {
                foreach (int i in ints)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Задание 2");
            List<string> listStr = new List<string>() { "qq", "qq", "wwww", "e", "wwww", "t", "y", "zzz" };
            CountStrDelegate strDelegate = new CountStrDelegate(CountStr);
            Console.WriteLine(strDelegate(listStr));

            Console.WriteLine("Задание 3");
            List<int> list100 = new List<int>(Enumerable.Range(1, 100));
            foreach(int i in NumbersOfSquare(list100))
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("Задание 4");
            string s = "aeiouy";
            List<string> listStr1 = new List<string>() { "aeiouy", "aeriouy", "aerrrr", "errrrfgsdfgh" };
            var countStr = listStr1.Where(x => x.Intersect(s).Count() == s.Length);
            foreach (string str in countStr)
            {
                Console.WriteLine($"{str}");
            }

            Console.WriteLine("Задание 5");
            string s1 = "fhfhgaabbcvvn";
            List<string> unStr1 = new List<string>();
            var unStr = s1.GroupBy(x => x).Where(x => x.Count() == 1);

            foreach (var i in unStr)
            {
                foreach (char j in i)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();

            }

            Console.WriteLine("Задание 6");
            List<Person> persons = new List<Person>
                        {
                new Person { Id = 1, Name = "John" },
                new Person { Id = 2, Name = "Jane" },
                        };
            List<Address> addresses = new List<Address>
                        {
                new Address { PersonId = 1, City = "New York" },
                new Address { PersonId = 2, City = "London" },
            };
            var query = persons.Join(addresses, p => p.Id, a => a.PersonId, (p, a) => new { p.Name, a.City });
            Console.WriteLine("Соединенные данные из двух коллекций:");
            foreach (var result in query)
            {
                Console.WriteLine($"{result.Name} - {result.City}");
            }


        }


        public static List<int> NumbersOfSquare(List<int> list)
        {
            List<int> result = new List<int>();
            foreach (int i in list)
            {
                if (i * i <= 100)
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public static int CountStr(List<string> list)
        {
            int count = list.Count;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++) {
                    if (i == j) { continue; }
                    if (list[i] != list[j])
                    {
                        continue;
                    }
                    count--;
                }   
            }
            
            return count;
        }

        public static List<int[]> SumSeven (List<int> list)
            {
            List<int[]> newList = new List<int[]>();
            for(int i = 0; i < list.Count; i++)
            {
                for(int j = i+1;j< list.Count; j++)
                {
                    if (list[i] + list[j] == 7)
                    {
                        int[] newInt = new int[2] { list[i], list[j] };

                        newList.Add(newInt);
                    }
                }
            }

            return newList;

            }
    }
}