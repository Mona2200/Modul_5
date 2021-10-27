using System;

namespace Modul_5
{
   class Program
   {
      static void Main(string[] args)
      {
         var user = EnterUser();
         ShowUser(user);
      }

      static (string Name, string LastName, int Age, string[] NamesPets, string[] FavColors) EnterUser()
      {
         (string Name, string LastName, int Age, string[] NamesPets, string[] FavColors) User;

         Console.Write("Введите ваше имя ");
         User.Name = Console.ReadLine();

         Console.Write("Введите вашу фамилию ");
         User.LastName = Console.ReadLine();

         string age;
         int intage;
         do
         {
            Console.Write("Введите ваш возраст цифрами ");
            age = Console.ReadLine();
         } while (!CheckNum(age, out intage));

         User.Age = intage;

         string answer = "";
         while (answer != "Да" && answer != "Нет")
         {
            Console.Write("Есть ли у вас питомец? Введите 'Да' или 'Нет' ");
            answer = Console.ReadLine();
         }

         string numpets;
         int intnumpets = 0;
         if (answer == "Да")
         {
            do
            {
               Console.Write("Введите количество ваших питомцев цифрами ");
               numpets = Console.ReadLine();
            } while (!CheckNum(numpets, out intnumpets));
         }

         User.NamesPets = CreateArrayPets(intnumpets);

         string numcolors;
         int intnumcolors;
         do
         {
            Console.Write("Введите количество ваших любимых цветов цифрами ");
            numcolors = Console.ReadLine();
         } while (!CheckNum(numcolors, out intnumcolors));

         User.FavColors = CreateArrayFavColors(intnumcolors);

         return User;
      }

      static string[] CreateArrayPets(int num)
      {
         var result = new string[num];
         for (int i = 0; i < result.Length; i++)
         {
            Console.Write("Введите кличку вашего питомца номер {0} ", i + 1);
            result[i] = Console.ReadLine();
         }
         return result;
      }

      static string[] CreateArrayFavColors(int num)
      {
         var result = new string[num];
         for (int i = 0; i < result.Length; i++)
         {
            Console.Write("Введите ваш любимый цвет номер {0} ", i + 1);
            result[i] = Console.ReadLine();
         }
         return result;
      }

      static bool CheckNum(string number, out int corrnumber)
      {
         if (int.TryParse(number, out int intnum))
         {
            if (intnum > 0)
            {
               corrnumber = intnum;
               return true;
            }
         }
         corrnumber = 0;
         Console.WriteLine("Введено некорректное число");
         return false;
      }

      static void ShowUser((string Name, string LastName, int Age, string[] NamesPets, string[] FavColors) User)
      {
         Console.WriteLine("Ваше имя: {0}", User.Name);

         Console.WriteLine("Ваша фамилия: {0}", User.LastName);

         Console.WriteLine("Ваш возраст: {0}", User.Age);

         Console.WriteLine("Имена ваших питомцев: ");
         foreach (var item in User.NamesPets)
         {
            Console.WriteLine(item);
         }

         Console.WriteLine("Ваши любимые цвета: ");
         foreach (var item in User.FavColors)
         {
            Console.WriteLine(item);
         }
      }
   }
}
