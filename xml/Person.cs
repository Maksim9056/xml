using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace xml
{
    public class Person
    {
            public string Name { get; set; } = "Undefined";
            public DateTime DateofBirthder { get; set; } = DateTime.UtcNow;
            public string Gender { get; set; } = "Мужской";
            //-public DataTable колеги { get; set; } = new DataTable();
            public char UserSelector { get; set; } = 'Y';
            public CheckUserWin PlayerChoice { get; set; } = CheckUserWin.Да;
            public enum CheckUserWin { Да = 1, Нет, };

            public string NameFile { get; set; } = "person";

            public Person() { }
            public Person(string name, DateTime dateofBirthder, string gender)
            {
                Name = name;
                DateofBirthder = dateofBirthder;
                Gender = gender;
            }
            private bool validateSelection()
            {

                char value = Char.ToUpper(UserSelector);
                if (value != 'S' && value != 'Z')

                    return false;
                return true;
            }
            public bool validateRespomse(char responsE)
            {
                if (Char.ToUpper(responsE) != 'Y' && Char.ToUpper(responsE) != 'y')
                    return true;
                return false;
            }
            private void Screen()
            {
                Console.WriteLine("S=Start");
                Console.WriteLine("Z- record");
                Console.WriteLine("n-");
                Console.WriteLine("Пожалуйста, сделайте свой выбор:");
            }

            public void Person2(Person[] p2)
            {
                //using(FileStream fs = new FileStream ("person1.xml" ,FileMode.));
                // { ReadState  PERSON =    ReadState.EndOfFile;

                //     Console.WriteLine(PERSON);
                //     Console.WriteLine();
                //     XmlWriter.Create("person1.xml");
                //     Console.WriteLine(Console.Out);


                // }
                Screen();
                UserSelector = Convert.ToChar(Console.ReadLine());

                if (UserSelector == 'S' || UserSelector == 'Z')
                {



                    while (validateSelection())


                    {

                        switch (Char.ToUpper(UserSelector))
                        {
                            case 'S':
                                Start(p2);
                                break;
                            case 'Z':
                                Считываем();
                                break;
                                Console.Clear();
                                Console.WriteLine("До свидания");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("До свидания");
                }

            }
            public void Считываем()
            {
                Person[] person2 = new Person[2];
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person[]));
                char responseE;
                using (FileStream fs = new FileStream(NameFile + ".xml", FileMode.Open))
                {
                    person2 = xmlSerializer.Deserialize(fs) as Person[];
                    Console.WriteLine();
                    Console.WriteLine("Файл из xml считывает ");



                    foreach (Person tr in person2)
                    {
                        Console.WriteLine($"Name: {tr.Name}");
                        Console.WriteLine($"ADate of birth:{tr.DateofBirthder}");
                        Console.WriteLine($"Gender: {tr.Gender}");

                    }
                }
                Console.WriteLine(" Желайте ввести данные повторно сотрудника нажмите на y ");
                responseE = Convert.ToChar(Console.ReadLine());
                if (responseE == 'Y' || responseE == 'y')
                {
                    Person2(person2);
                }
                else
                {
                    Console.Clear();
                }

            }

            public void Start(Person[] p2)
            {
                //Person[] person = p2;
                Person[] person = new Person[]
                {
             new Person(),
             new Person(),
                };

                char responseE;
                var rand = new Random();

                {
                    try
                    {
                        foreach (Person tr in person)
                        {

                            Console.WriteLine("Ввидите имя");
                            tr.Name = Console.ReadLine();
                            Console.WriteLine("Введите дату рождения в формате  (День.Месяц.Год):");

                            tr.DateofBirthder = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Ввидите Пол : или ");

                            Console.WriteLine("Мужской или Женский");
                            tr.Gender = Console.ReadLine();
                            if (tr.Gender == "Мужской" || tr.Gender == "Женский")
                            {

                            }
                            else
                            {
                                Console.WriteLine($"{tr.Gender} не выбран повторите снова");
                                tr.Gender = Console.ReadLine();
                            }

                        }

                    if (p2 == null)
                    {

                    }
                    else
                    {
                        person = person.Concat(p2).ToArray();

                    }

                      XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person[]));
                        if (File.Exists(NameFile + ".xml"))
                        {
                            NameFile = NameFile + rand.Next(101) as String;
                        }

                        using (FileStream fs1 = new FileStream(NameFile + ".xml", FileMode.OpenOrCreate))
                        {
                            //File.Replace("person.xml", NameFile + ".xml", NameFile + ".xml");
                            xmlSerializer.Serialize(fs1, person);

                            Console.WriteLine();
                            Console.WriteLine("Файл из xml сохраняет ");

                            foreach (Person tr in person)
                            {
                                Console.WriteLine($"Name: {tr.Name}");
                                Console.WriteLine($"Date of birth: {tr.DateofBirthder}");
                                Console.WriteLine($"Gender: {tr.Gender}");

                            }

                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ошибка !");
                    }
                    finally
                    {

                    }

                    Console.Clear();
                    Console.WriteLine(" Желайте ввести данные повторно сотрудника нажмите на y или n ");
                    responseE = Convert.ToChar(Console.ReadLine());
                    if (responseE == 'Y' || responseE == 'y')
                    {
                        Start(null);
                    }
                    else
                    {
                        Person2(null);
                    }

                }
            }
    }
 }


