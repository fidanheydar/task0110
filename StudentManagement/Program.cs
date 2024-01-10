using System;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Fidan", "Ceyhun", "Lamiya" };
            byte[] ages = { 20, 22, 20 };

            string opt;

            do
            {
                ShowMainMenu();
                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        ShowAllStudents(names,ages);
                        break;
                    case "2":
                        AddStudent(ref names, ref ages);
                        break;
                        case "3":
                        SearchStudents(names);
                        break;
                    case "4":
                        ShowStudentsWithIndex(names,ages);
                        break;
                        case "5":
                        DeleteStudent(names, ref ages);
                        break;
                        case "0":
                        Console.WriteLine("Chixish olunur...");
                        break;
                        default: Console.WriteLine("Yalnish Emeliyyat !");
                        break;


                }



            } while (opt != "0");

            static void ShowMainMenu()
            {
                Console.WriteLine("1. Butun telebelere bax");
                Console.WriteLine("2. Telebe elave et");
                Console.WriteLine("3. Telebeler uzerinde axtarish et");
                Console.WriteLine("4. Sechilmish nomreli telebeni goster");
                Console.WriteLine("5. Sechilmish nomreli telebeni sil");
                Console.WriteLine("o. Chix");

                Console.Write("Emeliyyat sechin:");
            }
            static void ShowAllStudents(string[] names, byte[] ages)
            {
                Console.WriteLine("Butun telebelerin siyahisi:");
                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine($"Name: {names[i]}, Age: {ages[i]}");
                }
            }
            static bool HasOnlyLetter(string str)
            {
                if (String.IsNullOrWhiteSpace(str)) return false;

                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsLetter(str[i])) return false;
                }

                return true;
            }
            static bool CheckAge(string ageInput, out byte age)
            {
                if (byte.TryParse(ageInput, out age) && age >= 15 && age <= 60)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Duzgun bir yash daxil edin!");
                    return false;
                }
            }
            static bool CheckName(string name)
            {
                if (string.IsNullOrWhiteSpace(name))
                    return false;
                if (name.Length >= 3 && name.Length <= 20 && HasOnlyLetter(name)) return true;
                return false;
            }
            static void AddStudent(ref string[] names , ref byte[] ages)
            {
                string studentName;
                byte studentAge;
                bool hasOnlyLetter = true;
                do
                {
                    Console.WriteLine("Telebe adini daxil edin:");
                    studentName = Console.ReadLine();
                }
                while (!CheckName(studentName));
                studentName = FormatName(studentName);
                do
                {
                    Console.WriteLine("Telebenin yasini daxil edin:");
                } while (!CheckAge(Console.ReadLine(), out studentAge));
                Array.Resize(ref names, names.Length + 1);
                Array.Resize(ref ages, ages.Length + 1);
                names[names.Length - 1] = studentName;
                ages[ages.Length - 1] = studentAge;
            }
        }
            static string FormatName(string name)
            {
                return char.ToUpper(name[0]) + name.Substring(1).ToLower();
            }
            static void SearchStudents(string[] names)

            {
            Console.WriteLine("Axtarish deyerini daxil edin:");
            string searchValue = Console.ReadLine();

            bool foundSearch = false;

                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i].Contains(searchValue))
                    {
                        Console.WriteLine(names[i]);
                        foundSearch = true;
                    }
                }
                if (!foundSearch)
                  Console.WriteLine("Axtarish deyerine uygun telebe tapilmadi :/");
                }
            static void ShowStudentsWithIndex(string[] names, byte[] ages)
            {
            Console.WriteLine("Telebelerin siyahisi:");

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"Index: {i}, Name: {names[i]}, Age: {ages[i]}");
            }
            int selectedIndex;
            bool isValidIndex;
            do
            {
                Console.Write("Zehmet olmasa bir index sechin: ");

                if (int.TryParse(Console.ReadLine(), out selectedIndex) && selectedIndex >= 0 && selectedIndex < names.Length)
                {
                    isValidIndex = true;
                }
                else
                {
                    Console.WriteLine("Duzgun bir index daxil edin!!");
                    isValidIndex = false;
                }

            } while (!isValidIndex);
            Console.WriteLine($"Sechilen telebe: Index: {selectedIndex}, Name: {names[selectedIndex]}, Age: {ages[selectedIndex]}");
        }
            static void DeleteStudentAtIndex(ref string[] array, int index)
            {
                for (int i = index; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                Array.Resize(ref array, array.Length - 1);
            }
            static void DeleteStudentAtIndex(ref byte[] array, int index)
            {
               for (int i = index; i < array.Length - 1; i++)
                array[i] = array[i + 1];
            Array.Resize(ref array, array.Length - 1);
            }
            static void DeleteStudent(string[] names, ref byte[] ages)
            {
            Console.WriteLine("Telebelerin siyahisi:");

                for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"Index: {i}, Name: {names[i]}, Age: {ages[i]}");
            }
            Console.Write("Zehmet olmasa bir index secin: ");
            if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex >= 0 && selectedIndex < names.Length)
            {
                Console.WriteLine($"Sechilen telebe: Index: {selectedIndex}, Name: {names[selectedIndex]}, Age: {ages[selectedIndex]}");

                DeleteStudentAtIndex(ref names, selectedIndex);
                DeleteStudentAtIndex(ref ages, selectedIndex);

                Console.WriteLine("Telebe ugurla silindi.");
            }
            else
                Console.WriteLine("Duzgun bir index daxil edin!!");
        }




    }
}

