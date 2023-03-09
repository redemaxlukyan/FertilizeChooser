using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Програма
{
    internal class Program
    {
        static double DoseOfMineralFertilizerSeparate(in double recommendedRate, in double contentOfEl) 
        {
            // доза мінерального добрива = рекомендована норма внесення елемента живлення / процентний вміст елемента живлення у добривах
            double result = (recommendedRate / contentOfEl) * 100; 
            return result; 
        }

        static void NutrientsRemainder(double Nitrogenium, double Phosphorus, double Kalium, double enteredNitrogenium, double enteredPhosphorus, double enteredKalium, out double nitrogeniumRemainder, out double phosphorusRemainder, out double kaliumRemainder)
        {
            nitrogeniumRemainder = phosphorusRemainder = kaliumRemainder = 0;

            nitrogeniumRemainder = enteredNitrogenium - Nitrogenium;
            phosphorusRemainder = enteredPhosphorus - Phosphorus;
            kaliumRemainder = enteredKalium - Kalium;
        }

        static double MeasureTheRequiredAmountOfMineralFertilizers(double mass, double volumetricMass)
        {
            double requiredVolume;
            requiredVolume = mass / volumetricMass;
            return requiredVolume;
        }

        static void DoseOfMineralFertilizerSeparateMaxContent(string userChoose1, string userChoose2, string[] typesOfCultures, double contentOfEl1, double contentOfEl2, double contentOfEl3, double Nitrogenium, double Phosphorus, double Kalium, string[] nitrogeniumFertilizers, double[] percentageOfNitrogenium, double[] bulkMassOfNitrogeniumFertilizers, string[] phosphorusFertilizers, double[] percentageOfPhosphorus, double[] bulkMassOfPhosphorusFertilizers, string[] kaliumFertilizers, double[] percentageOfKalium, double[] bulkMassOfKaliumFertilizers)
        {
            double max, doseOfFertilizer, enteredNitrogenium, enteredPhosphorus, enteredKalium;
            max = doseOfFertilizer = enteredNitrogenium = enteredPhosphorus = enteredKalium = 0;

            if (contentOfEl1 >= contentOfEl2 && contentOfEl1 >= contentOfEl3)
            {
                max = contentOfEl1;
                enteredNitrogenium = Nitrogenium;
                doseOfFertilizer = DoseOfMineralFertilizerSeparate(enteredNitrogenium, max);
                enteredPhosphorus = (doseOfFertilizer * contentOfEl2) / 100;
                enteredKalium = (doseOfFertilizer * contentOfEl3) / 100;
                NutrientsRemainder(Nitrogenium, Phosphorus, Kalium, enteredNitrogenium, enteredPhosphorus, enteredKalium, out double nitrogeniumRemainder, out double phosphorusRemainder, out double kaliumRemainder);

                Console.WriteLine(Math.Round(doseOfFertilizer, 1) + "\tг - необхідна маса добрива.");
                Console.WriteLine("Добриво може компенсувати:  \nАзот: {0}г Фосфор: {1}г Калій: {2}г.", Math.Round(enteredNitrogenium, 2), Math.Round(enteredPhosphorus, 2), Math.Round(enteredKalium, 2));
                Console.WriteLine("Профіцит/Дефіцит поживних елементів: \nАзот: {0}г Фосфор: {1}г Калій: {2}г.", Math.Round(nitrogeniumRemainder, 2), Math.Round(phosphorusRemainder, 2), Math.Round(kaliumRemainder, 2));
                Console.WriteLine();

                CompareAndPrintDeficitOfNutrients(userChoose1, userChoose2, typesOfCultures, nitrogeniumRemainder, phosphorusRemainder, kaliumRemainder, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);

            }
            else if (contentOfEl2 >= contentOfEl1 && contentOfEl2 >= contentOfEl3)
            {
                max = contentOfEl2;
                enteredPhosphorus = Phosphorus;
                doseOfFertilizer = DoseOfMineralFertilizerSeparate(enteredPhosphorus, max);
                enteredNitrogenium = (doseOfFertilizer * contentOfEl1) / 100;
                enteredKalium = (doseOfFertilizer * contentOfEl3) / 100;
                NutrientsRemainder(Nitrogenium, Phosphorus, Kalium, enteredNitrogenium, enteredPhosphorus, enteredKalium, out double nitrogeniumRemainder, out double phosphorusRemainder, out double kaliumRemainder);

                Console.WriteLine(Math.Round(doseOfFertilizer, 1) + "\tг - необхідна маса добрива.");
                Console.WriteLine("Добриво може компенсувати:  \nАзот: {0}г Фосфор: {1}г Калій: {2}г.", Math.Round(enteredNitrogenium, 2), Math.Round(enteredPhosphorus, 2), Math.Round(enteredKalium, 2));
                Console.WriteLine("Профіцит/Дефіцит поживних елементів: \nАзот: {0}г Фосфор: {1}г Калій: {2}г.", Math.Round(nitrogeniumRemainder, 2), Math.Round(phosphorusRemainder, 2), Math.Round(kaliumRemainder, 2));
                Console.WriteLine();

                CompareAndPrintDeficitOfNutrients(userChoose1, userChoose2, typesOfCultures, nitrogeniumRemainder, phosphorusRemainder, kaliumRemainder, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);

            }
            else if (contentOfEl3 >= contentOfEl1 && contentOfEl3 >= contentOfEl2)
            {
                max = contentOfEl3;
                enteredKalium = Kalium;
                doseOfFertilizer = DoseOfMineralFertilizerSeparate(enteredKalium, max);
                enteredNitrogenium = (doseOfFertilizer * contentOfEl1) / 100;
                enteredPhosphorus = (doseOfFertilizer * contentOfEl2) / 100;
                NutrientsRemainder(Nitrogenium, Phosphorus, Kalium, enteredNitrogenium, enteredPhosphorus, enteredKalium, out double nitrogeniumRemainder, out double phosphorusRemainder, out double kaliumRemainder);

                Console.WriteLine(Math.Round(doseOfFertilizer, 1) + "\tг - необхідна маса добрива.");
                Console.WriteLine("Добриво може компенсувати:  \nАзот: {0}г Фосфор: {1}г Калій: {2}г.", Math.Round(enteredNitrogenium, 2), Math.Round(enteredPhosphorus, 2), Math.Round(enteredKalium, 2));
                Console.WriteLine("Профіцит/Дефіцит поживних елементів: \nАзот: {0}г Фосфор: {1}г Калій: {2}г.", Math.Round(nitrogeniumRemainder, 2), Math.Round(phosphorusRemainder, 2), Math.Round(kaliumRemainder, 2));
                Console.WriteLine();

                CompareAndPrintDeficitOfNutrients(userChoose1, userChoose2, typesOfCultures, nitrogeniumRemainder, phosphorusRemainder, kaliumRemainder, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);
            }
        }

        static void DoseOfMineralFertilizerSeparateMinRate(string userChoose1, string userChoose2, string[] typesOfCultures, double contentOfEl1, double contentOfEl2, double contentOfEl3, double Nitrogenium, double Phosphorus, double Kalium, string[] nitrogeniumFertilizers, double[] percentageOfNitrogenium, double[] bulkMassOfNitrogeniumFertilizers, string[] phosphorusFertilizers, double[] percentageOfPhosphorus, double[] bulkMassOfPhosphorusFertilizers, string[] kaliumFertilizers, double[] percentageOfKalium, double[] bulkMassOfKaliumFertilizers)
        {
            double doseOfFertilizer, enteredNitrogenium, enteredPhosphorus, enteredKalium;
            doseOfFertilizer = enteredNitrogenium = enteredPhosphorus = enteredKalium = 0;
            
            if (Nitrogenium < Phosphorus && Nitrogenium < Kalium)
            {
                enteredNitrogenium = Nitrogenium;
                doseOfFertilizer = DoseOfMineralFertilizerSeparate(enteredNitrogenium, contentOfEl1);
                enteredPhosphorus = (doseOfFertilizer * contentOfEl2) / 100;
                enteredKalium = (doseOfFertilizer * contentOfEl3) / 100;
                NutrientsRemainder(Nitrogenium, Phosphorus, Kalium, enteredNitrogenium, enteredPhosphorus, enteredKalium, out double nitrogeniumRemainder, out double phosphorusRemainder, out double kaliumRemainder);

                Console.WriteLine(Math.Round(doseOfFertilizer, 1) + "\tг - необхідна маса добрива.");
                Console.WriteLine("Добриво може компенсувати:  \nАзот: {0}г Фосфор: {1}г Калій: {2}г.", Math.Round(enteredNitrogenium, 2), Math.Round(enteredPhosphorus, 2), Math.Round(enteredKalium, 2));
                Console.WriteLine("Профіцит/Дефіцит поживних елементів: \nАзот: {0}г Фосфор: {1}г Калій: {2}г.", Math.Round(nitrogeniumRemainder, 2), Math.Round(phosphorusRemainder, 2), Math.Round(kaliumRemainder, 2));
                Console.WriteLine();

                CompareAndPrintDeficitOfNutrients(userChoose1, userChoose2, typesOfCultures, nitrogeniumRemainder, phosphorusRemainder, kaliumRemainder, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);
            }
            else if (Phosphorus < Nitrogenium && Phosphorus < Kalium)
            {
                enteredPhosphorus = Phosphorus;
                doseOfFertilizer = DoseOfMineralFertilizerSeparate(enteredPhosphorus, contentOfEl2);
                enteredNitrogenium = (doseOfFertilizer * contentOfEl1) / 100;
                enteredKalium = (doseOfFertilizer * contentOfEl3) / 100;
                NutrientsRemainder(Nitrogenium, Phosphorus, Kalium, enteredNitrogenium, enteredPhosphorus, enteredKalium, out double nitrogeniumRemainder, out double phosphorusRemainder, out double kaliumRemainder);

                Console.WriteLine(Math.Round(doseOfFertilizer, 1) + "\tг - необхідна маса добрива.");
                Console.WriteLine("Добриво може компенсувати:  \nАзот: {0}г Фосфор: {1}г Калій: {2}г.", Math.Round(enteredNitrogenium, 2), Math.Round(enteredPhosphorus, 2), Math.Round(enteredKalium, 2));
                Console.WriteLine("Профіцит/Дефіцит поживних елементів: \nАзот: {0}г Фосфор: {1}г Калій: {2}г.", Math.Round(nitrogeniumRemainder, 2), Math.Round(phosphorusRemainder, 2), Math.Round(kaliumRemainder, 2));
                Console.WriteLine();

                CompareAndPrintDeficitOfNutrients(userChoose1, userChoose2, typesOfCultures, nitrogeniumRemainder, phosphorusRemainder, kaliumRemainder, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);
            }
            else if (Kalium < Nitrogenium && Kalium < Phosphorus)
            {
                enteredKalium = Kalium;
                doseOfFertilizer = DoseOfMineralFertilizerSeparate(enteredKalium, contentOfEl3);
                enteredNitrogenium = (doseOfFertilizer * contentOfEl1) / 100;
                enteredPhosphorus = (doseOfFertilizer * contentOfEl2) / 100;
                NutrientsRemainder(Nitrogenium, Phosphorus, Kalium, enteredNitrogenium, enteredPhosphorus, enteredKalium, out double nitrogeniumRemainder, out double phosphorusRemainder, out double kaliumRemainder);

                Console.WriteLine(Math.Round(doseOfFertilizer, 1) + "\tг - необхідна маса добрива.");
                Console.WriteLine("Добриво може компенсувати:  \nАзот: {0}г Фосфор: {1}г Калій: {2}г.", Math.Round(enteredNitrogenium, 2), Math.Round(enteredPhosphorus, 2), Math.Round(enteredKalium, 2));
                Console.WriteLine("Профіцит/Дефіцит поживних елементів: \nАзот: {0}г Фосфор: {1}г Калій: {2}г.", Math.Round(nitrogeniumRemainder, 2), Math.Round(phosphorusRemainder, 2), Math.Round(kaliumRemainder, 2));
                Console.WriteLine();

                CompareAndPrintDeficitOfNutrients(userChoose1, userChoose2, typesOfCultures, nitrogeniumRemainder, phosphorusRemainder, kaliumRemainder, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);
            }

        }

        static void CompareAndPrintDeficitOfNutrients(string userChoose1, string userChoose2, string[] typesOfCultures, double nitrogeniumRemainder, double phosphorusRemainder, double kaliumRemainder, string[] nitrogeniumFertilizers, double[] percentageOfNitrogenium, double[] bulkMassOfNitrogeniumFertilizers, string[] phosphorusFertilizers, double[] percentageOfPhosphorus, double[] bulkMassOfPhosphorusFertilizers, string[] kaliumFertilizers, double[] percentageOfKalium, double[] bulkMassOfKaliumFertilizers)
        {
            if (nitrogeniumRemainder < 0 || phosphorusRemainder < 0 || kaliumRemainder < 0)
            {
                if (nitrogeniumRemainder < 0)
                {
                    Console.WriteLine("Дефіцит {0}г Азоту може компенсувати:", Math.Round(nitrogeniumRemainder, 2));
                    for (int i = 0; i < nitrogeniumFertilizers.Length; i++)
                    {
                        if (userChoose1 == typesOfCultures[0])
                        {
                            if (nitrogeniumFertilizers[i] == "аміачна селітра" || nitrogeniumFertilizers[i] == "карбамід")
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine($"Азотне добриво: {nitrogeniumFertilizers[i]}");
                                Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Math.Abs(nitrogeniumRemainder), percentageOfNitrogenium[i]), 2)+ "\tг - необхідна маса добрива.");
                                Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Math.Abs(nitrogeniumRemainder), percentageOfNitrogenium[i]), bulkMassOfNitrogeniumFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Азотне добриво: {nitrogeniumFertilizers[i]}");
                            Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Math.Abs(nitrogeniumRemainder), percentageOfNitrogenium[i]), 2)+ "\tг - необхідна маса добрива.");
                            Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Math.Abs(nitrogeniumRemainder), percentageOfNitrogenium[i]), bulkMassOfNitrogeniumFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                        }
                    }
                    Console.WriteLine();
                }

                if (phosphorusRemainder < 0)
                {
                    Console.WriteLine("Дефіцит {0}г Фосфору може компенсувати:", Math.Round(phosphorusRemainder, 2));
                    for (int i = 0; i < phosphorusFertilizers.Length; i++)
                    {
                        if (phosphorusFertilizers[i] == "фосфоритне борошно")
                        {
                            if (userChoose2 == "гірчиця" || userChoose2 == "люпин" || userChoose2 == "гречка")
                            {
                                Console.WriteLine($"Фосфорне добриво: {phosphorusFertilizers[i]}");
                                Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Math.Abs(phosphorusRemainder), percentageOfPhosphorus[i]), 2) + "\tг - необхідна маса добрива.");
                                Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Math.Abs(phosphorusRemainder), percentageOfPhosphorus[i]), bulkMassOfPhosphorusFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Фосфорне добриво: {phosphorusFertilizers[i]}");
                            Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Math.Abs(phosphorusRemainder), percentageOfPhosphorus[i]), 2) + "\tг - необхідна маса добрива.");
                            Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Math.Abs(phosphorusRemainder), percentageOfPhosphorus[i]), bulkMassOfPhosphorusFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                        }
                    }
                    Console.WriteLine();
                }

                if (kaliumRemainder < 0)
                {
                    Console.WriteLine("Дефіцит {0}г Калію може компенсувати:", Math.Round(kaliumRemainder, 2));
                    for (int i = 0; i < kaliumFertilizers.Length; i++)
                    {
                        if (kaliumFertilizers[i] == "калійна сіль" || kaliumFertilizers[i] == "хлорид калію")
                        {
                            if (userChoose2 == "картопля" || userChoose2 == "перець" || userChoose2 == "помідор" || userChoose2 == "льон" || userChoose2 == "виноград" || userChoose2 == "лимон" || userChoose2 == "апельсин" || userChoose2 == "мандарин" || userChoose2 == "грейпфрут")
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine($"Калійне добриво: {kaliumFertilizers[i]}");
                                Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Math.Abs(kaliumRemainder), percentageOfKalium[i]), 2) + "\tг - необхідна маса добрива.");
                                Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Math.Abs(kaliumRemainder), percentageOfKalium[i]), bulkMassOfKaliumFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                            }
                        }
                        else if (kaliumFertilizers[i] == "калійна сіль")
                        {
                            if (userChoose2 == "буряк" || userChoose2 == "гречка" || userChoose2 == "просо" || userChoose2 == "рис" || userChoose2 == "овес" || userChoose2 == "сорго" || userChoose2 == "ячмінь" || userChoose2 == "тритикале" || userChoose2 == "жито" || userChoose2 == "пшениця" || userChoose2 == "кукурудза")
                            {
                                Console.WriteLine($"Калійне добриво: {kaliumFertilizers[i]}");
                                Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Math.Abs(kaliumRemainder), percentageOfKalium[i]), 2) + "\tг - необхідна маса добрива.");
                                Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Math.Abs(kaliumRemainder), percentageOfKalium[i]), bulkMassOfKaliumFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Калійне добриво: {kaliumFertilizers[i]}");
                            Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Math.Abs(kaliumRemainder), percentageOfKalium[i]), 2) + "\tг - необхідна маса добрива.");
                            Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Math.Abs(kaliumRemainder), percentageOfKalium[i]), bulkMassOfKaliumFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        static void PrintOrganic(in string userChoose1, in string userChoose2, in double Nitrogenium, in double Phosphorus, in double Kalium, in string typesOfOrganic, in double organicNitrogenium, in double organicPhosphorus, in double organicKalium, in string[] typesOfCultures, in string[] nitrogeniumFertilizers, in string[] phosphorusFertilizers, in string[] kaliumFertilizers, in double[] percentageOfNitrogenium, in double[] percentageOfPhosphorus, in double[] percentageOfKalium, in double[] bulkMassOfNitrogeniumFertilizers, in double[] bulkMassOfPhosphorusFertilizers, in double[] bulkMassOfKaliumFertilizers)
        {
            NutrientsRemainder(Nitrogenium, Phosphorus, Kalium, organicNitrogenium, organicPhosphorus, organicKalium, out double nitrogeniumRemainder, out double phosphorusRemainder, out double kaliumRemainder);

            Console.WriteLine($"{userChoose2} потребує нутрієнти: \nАзот: {Nitrogenium}г Фосфор: {Phosphorus}г Калій: {Kalium}г.");
            Console.WriteLine("{0} може компенсувати:  \nАзот: {1}г Фосфор: {2}г Калій: {3}г.", typesOfOrganic, Math.Round(organicNitrogenium, 2), Math.Round(organicPhosphorus, 2), Math.Round(organicKalium, 2));
            Console.WriteLine("Профіцит/Дефіцит поживних елементів: \nАзот: {0}г Фосфор: {1}г Калій: {2}г.", Math.Round(nitrogeniumRemainder, 2), Math.Round(phosphorusRemainder, 2), Math.Round(kaliumRemainder, 2));
            Console.WriteLine();

            CompareAndPrintDeficitOfNutrients(userChoose1, userChoose2, typesOfCultures, nitrogeniumRemainder, phosphorusRemainder, kaliumRemainder, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);
        }

        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            string[] typesOfCultures = { "садова", "городна" }; // типи культур

            // садові плоди
            string[][] garden =
            {
                new string[] { "яблуня", "груша", "айва" },
                new string[] { "вишня", "черешня", "слива", "абрикос", "персик", "алича" },
                new string[] { "волоський горіх", "ліщина", "фундук" },
                new string[] { "суниця", "малина", "смородина", "агрус", "порічка" },
                new string[] { "виноград" },
                new string[] { "лимон", "апельсин", "мандарин", "грейпфрут" },
            };

            // городні плоди
            string[][] olitory =
            {
                new string[] { "редис", "ріпа", "брюква", "морква", "картопля", "буряк", "редька", "дайкон", "селера", "пастернак", "петрушка", "скорцонера", "цикорій" },
                new string[] { "салат", "шпинат", "м'ята", "материнка", "мангольд", "базилік", "меліса", "естрагон", "щавель", "любисток", "фенхель", "кріп" },
                new string[] { "кавун", "диня", "гарбуз", "кабачок", "патіссон" },
                new string[] { "квасоля", "горох", "боби", "нут", "сочевиця", "арахіс", "соя" },
                new string[] { "кольрабі", "брюсельська", "пекінська", "цвітна", "білокачанна", "краснокачанна" },
                new string[] { "цибуля", "часник", "шалот", "спаржа", "буряк", "огірок", "помідор", "перець" },
                new string[] { "кукурудза", "овес", "пшениця", "жито", "сорго", "тритикале", "ячмінь" },
                new string[] { "горох", "нут", "соя" },
                new string[] { "гречка", "просо", "рис" },
                new string[] { "соняшник", "ріпак", "гірчиця" },
                new string[] { "льон", "бавовник", "хміль" },
                new string[] { "еспарцет", "конюшина", "люпин", "люцерна" },
            };

            string[] typesOfFertilizers = { "органичне", "минеральне", "комплексне", "бактериальне", "микродобриво" };  // типи добрив
            string[] typesOfOrganic = { "Гній", "Перегній", "Куриний послід", "Компост", "Зола" };                      // типи органічних добрив
            string[] typesOfMineral = { "Азотні", "Фосфорні", "Калійні", "Комплексні" };                                // типи мінеральних добрив

            // Основні елементи живлення
            double Nitrogenium = 0;// Азот
            double Phosphorus = 0; // Фосфор
            double Kalium = 0;     // Калій

            // Органічні добрива кг/м2 - норма добрива
            double manure = 4;      // Гній
            double humus = 2;       // Перегній
            double placenta = 1;    // Послід курячий
            double compost = 3;     // Компост
            double ash = 0.1;       // Зола

            // Дані щодо вмісту основних елементів живлення рослин для різних видів органічних добрив
            // Добриво гній
            double[] averageNutrientsFromManure = { 5.0, 2.5, 6.0 };            // середні дані щодо вмісту основних елементів живлення (г/кг)
            double[] useOfNutrientsFromManureFirstYear = { 0.3, 0.3, 0.5 };     // використання поживних речовин з органічних добрив у перший рік після їх внесення, %

            double manureNitrogenium = manure * averageNutrientsFromManure[0];  // скільки грамів Азоту в 4 кг гною (4кг/м2 доза гною)
            double manurePhosphorus = manure * averageNutrientsFromManure[1];   // скільки грамів Фосфору в 4 кг гною (4кг/м2 доза гною)
            double manureKalium = manure * averageNutrientsFromManure[2];       // скільки грамів Калію в 4 кг гною (4кг/м2 доза гною)

            double useOfNitrogeniumFromManureFirstYear = manureNitrogenium * useOfNutrientsFromManureFirstYear[0];  // використання Азоту з гною у перший рік
            double useOfPhosphorusFromManureFirstYear = manurePhosphorus * useOfNutrientsFromManureFirstYear[1];    // використання Фосфору з гною у перший рік
            double useOfKaliumFromManureFirstYear = manureKalium * useOfNutrientsFromManureFirstYear[2];            // використання Калію з гною у перший рік

            // Добриво перегній
            double[] averageNutrientsFromHumus = { 7.5, 4.0, 6.0 };             // середні дані щодо вмісту основних елементів живлення (г/кг)
            double[] useOfNutrientsFromHumusFirstYear = { 0.2, 0.5, 0.7 };      // використання поживних речовин з органічних добрив у перший рік після їх внесення, %

            double humusNitrogenium = humus * averageNutrientsFromHumus[0];     // скільки грамів Азоту в 3 кг перегною (3кг/м2 доза перегною)
            double humusPhosphorus = humus * averageNutrientsFromHumus[1];      // скільки грамів Фосфору в 3 кг перегною (3кг/м2 доза перегною)
            double humusKalium = humus * averageNutrientsFromHumus[2];          // скільки грамів Калію в 3 кг перегною (3кг/м2 доза перегною)

            double useOfNitrogeniumFromHumusFirstYear = humusNitrogenium * useOfNutrientsFromHumusFirstYear[0];     // використання Азоту з перегною у перший рік
            double useOfPhosphorusFromHumusFirstYear = humusPhosphorus * useOfNutrientsFromHumusFirstYear[1];       // використання Фосфору з перегною у перший рік
            double useOfKaliumFromHumusFirstYear = humusKalium * useOfNutrientsFromHumusFirstYear[2];               // використання Калію з перегною у перший рік

            // Добриво послід курячий
            double[] averageNutrientsFromPlacenta = { 16.5, 15.5, 8.5 };        // середні дані щодо вмісту основних елементів живлення (г/кг)
            double[] useOfNutrientsFromPlacentaFirstYear = { 0.3, 0.4, 0.8 };   // використання поживних речовин з органічних добрив у перший рік після їх внесення, %

            double placentaNitrogenium = placenta * averageNutrientsFromPlacenta[0];// скільки грамів Азоту в 2 кг посліду курячого (2кг/м2 доза посліду)
            double placentaPhosphorus = placenta * averageNutrientsFromPlacenta[1]; // скільки грамів Фосфору в 2 кг посліду курячого (2кг/м2 доза посліду)
            double placentaKalium = placenta * averageNutrientsFromPlacenta[2];     // скільки грамів Калію в 2 кг посліду курячого (2кг/м2 доза посліду)

            double useOfNitrogeniumFromPlacentaFirstYear = placentaNitrogenium * useOfNutrientsFromPlacentaFirstYear[0];// використання Азоту з посліду у перший рік
            double useOfPhosphorusFromPlacentaFirstYear = placentaPhosphorus * useOfNutrientsFromPlacentaFirstYear[1];  // використання Фосфору з посліду у перший рік
            double useOfKaliumFromPlacentaFirstYear = placentaKalium * useOfNutrientsFromPlacentaFirstYear[2];          // використання Калію з посліду у перший рік

            // Добриво компост
            double[] averageNutrientsFromCompost = { 5.0, 2.0, 3.0 };           // середні дані щодо вмісту основних елементів живлення (г/кг)
            double[] useOfNutrientsFromCompostFirstYear = { 0.4, 0.35, 0.6 };   // використання поживних речовин з органічних добрив у перший рік після їх внесення, %

            double compostNitrogenium = compost * averageNutrientsFromCompost[0];   // скільки грамів Азоту в 4 кг компосту (4кг/м2 доза компосту)
            double compostPhosphorus = compost * averageNutrientsFromCompost[1];    // скільки грамів Фосфору в 4 кг компосту (4кг/м2 доза компосту)
            double compostKalium = compost * averageNutrientsFromCompost[2];        // скільки грамів Калію в 4 кг компосту (4кг/м2 доза компосту)

            double useOfNitrogeniumFromCompostFirstYear = compostNitrogenium * useOfNutrientsFromCompostFirstYear[0];   // використання Азоту з компосту у перший рік
            double useOfPhosphorusFromCompostFirstYear = compostPhosphorus * useOfNutrientsFromCompostFirstYear[1];     // використання Фосфору з компосту у перший рік
            double useOfKaliumFromCompostFirstYear = compostKalium * useOfNutrientsFromCompostFirstYear[2];             // використання Калію з компосту у перший рік

            // Добриво зола
            double[] averageNutrientsFromAsh = { 0, 45.0, 70.0 };               // середні дані щодо вмісту основних елементів живлення (г/кг)
            double[] useOfNutrientsFromAshFirstYear = { 0, 0.3, 0.6 };          // використання поживних речовин з органічних добрив у перший рік після їх внесення, %

            double ashNitrogenium = ash * averageNutrientsFromAsh[0];               // скільки грамів Азоту в 0.1 кг золи (0.1кг/м2 доза золи)
            double ashPhosphorus = ash * averageNutrientsFromAsh[1];                // скільки грамів Фосфору в 0.1 кг золи (0.1кг/м2 доза золи)
            double ashKalium = ash * averageNutrientsFromAsh[2];                    // скільки грамів Калію в 0.1 кг золи (0.1кг/м2 доза золи)

            double useOfNitrogeniumFromAshFirstYear = ashNitrogenium * useOfNutrientsFromAshFirstYear[0];               // використання Азоту з золи у перший рік
            double useOfPhosphorusFromAshFirstYear = ashPhosphorus * useOfNutrientsFromAshFirstYear[1];                 // використання Фосфору з золи у перший рік
            double useOfKaliumFromAshFirstYear = ashKalium * useOfNutrientsFromAshFirstYear[2];                         // використання Калію з золи у перший рік

            // Прості мінеральні
            // Азотні добрива
            string[] nitrogeniumFertilizers = { "аміачна селітра", "сульфат амонію", "кальцієва селітра", "карбамід" }; // назва добрива
            double[] percentageOfNitrogenium = { 35, 21, 15, 46 };                 // відсотковий вміст Азоту в добриві
            double[] bulkMassOfNitrogeniumFertilizers = { 0.84, 0.8, 1.00, 0.65 }; // об’ємна маса азотних мінеральних добрив, г/см3

            // Фосфорні добрива
            string[] phosphorusFertilizers = { "суперфосфат порошкоподібний", "суперфосфат гранульований", "фосфоритне борошно" }; // назва добрива
            double[] percentageOfPhosphorus = { 20, 20, 10 };                   // відсотковий вміст Фосфору в добриві
            double[] bulkMassOfPhosphorusFertilizers = { 1.20, 1.10, 1.60 };    // об’ємна маса фосфорних мінеральних добрив, г/см3

            // Калійні добрива
            string[] kaliumFertilizers = { "калійна сіль", "хлорид калію", "сульфат калію", "калімагнезія" }; // назва добрива
            double[] percentageOfKalium = { 40, 60, 51, 28 };                   // відсотковий вміст Калію в добриві
            double[] bulkMassOfKaliumFertilizers = { 0.95, 0.95, 1.30, 1.50 };   // об’ємна маса калійних мінеральних добрив, г/см3

            // Комплексні мінеральні добрива
            string[] complexMineralFertilizers = { "нітроамофоска", "діамофоска", "любофоска", "поліфоска" }; // назва добрива
            double[,] percentageOfComplex =
            {
                { 16, 16, 16 },                         // відсотковий вміст Азоту, Фосфору і Калію в добриві
                { 10, 26, 26 },                         // відсотковий вміст Азоту, Фосфору і Калію в добриві
                { 4, 12, 12 },                          // відсотковий вміст Азоту, Фосфору і Калію в добриві
                { 6, 20, 30 }                           // відсотковий вміст Азоту, Фосфору і Калію в добриві
            };
            double[] bulkMassOfComplexMineralFertilizers = { 0.95, 1.10, 0.95, 0.90 };

            // Комплексні добрива (органічно-мінеральні)
            string[] complexOrganicMineralFertilizers = { "енергія", "добрі добрива", "універсальні", "органічні" };
            double[,] percentageOfComplexOrganicMineral =
            {
                { 0.88, 2.4, 0.88 },                    // відсотковий вміст Азоту, Фосфору і Калію в добриві
                { 4.3, 4.5, 4 },                        // відсотковий вміст Азоту, Фосфору і Калію в добриві
                { 13, 10, 12},                          // відсотковий вміст Азоту, Фосфору і Калію в добриві
                { 4, 3, 2.5 }                           // відсотковий вміст Азоту, Фосфору і Калію в добриві
            };

            // Бактеріальні
            string[] typesOfBacterial = { "нітрагін", "азотобактерин", "фосфобактерин", "АМБ" };    // назва добрива
            double[] doseOfBacterial = { 0.02, 0.01, 0.008, 0.1 };  // норма внесення добрива

            // Мікродобрива
            string[] typesOfMicro = { "молібден", "мідь", "бор", "цинк" };                          // назва добрива
            double[] doseOfMicro = { 0.02, 1.0, 40, 0.2 };          // норма внесення добрива


            Console.Write("Оберіть тип культури для якої підбиратимемо добрива(садова, городна): ");
            string userChoose1 = Console.ReadLine();
            string userChoose2 = "";
            string userChoose3 = "";

            bool userChoose2CheckGarden, userChoose2CheckOlitory;
            userChoose2CheckGarden = userChoose2CheckOlitory = false;

            Console.WriteLine();

            if (userChoose1 != typesOfCultures[0] && userChoose1 != typesOfCultures[1])
            {
                Console.WriteLine("Введіть коректне значення назви культури!");
            }
            else
            {
                if (userChoose1 == typesOfCultures[0])
                {
                    for (int i = 0; i < garden.Length; i++)
                    {
                        for (int j = 0; j < garden[i].Length; j++)
                        {
                            Console.Write($"{garden[i][j]} ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();

                    Console.Write("Введіть назву бажаного плоду для якого обиратимемо добриво: ");
                    userChoose2 = Console.ReadLine();

                    for (int i = 0; i < garden.Length; i++)
                    {
                        for (int j = 0; j < garden[i].Length; j++)
                        {
                            userChoose2CheckGarden = userChoose2 == garden[i][j] ? true : false;
                            
                            if (userChoose2CheckGarden == true)
                            {
                                goto finishUserChoose2CheckGarden;
                            }
                        }
                    }

finishUserChoose2CheckGarden:

                    switch (userChoose2)
                    {
                        case "яблуня":
                        case "груша":
                        case "слива":
                        case "абрикос":
                        case "персик":
                        case "вишня":
                        case "черешня":
                            Nitrogenium = 9;
                            Phosphorus = 6;
                            Kalium = 9;
                            manure = 2;
                            break;

                        case "смородина":
                        case "агрус":
                            Nitrogenium = 9;
                            Phosphorus = 9;
                            Kalium = 6;
                            manure = 1;
                            break;

                        case "малина":
                            Nitrogenium = 10;
                            Phosphorus = 10;
                            Kalium = 8;
                            manure = 1;
                            break;

                        case "суниця":
                            Nitrogenium = 5;
                            Phosphorus = 4;
                            Kalium = 5;
                            manure = 0.5;
                            break;

                        default:
                            Nitrogenium = 9;
                            Phosphorus = 9;
                            Kalium = 9;
                            break;
                    }
                }
                else if (userChoose1 == typesOfCultures[1])
                {
                    for (int i = 0; i < olitory.Length; i++)
                    {
                        for (int j = 0; j < olitory[i].Length; j++)
                        {
                            Console.Write($"{olitory[i][j]} ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();

                    Console.Write("Введіть назву бажаного плоду для якого обиратимемо добриво: ");
                    userChoose2 = Console.ReadLine();

                    for (int i = 0; i < olitory.Length; i++)
                    {
                        for (int j = 0; j < olitory[i].Length; j++)
                        {
                            userChoose2CheckOlitory = userChoose2 == olitory[i][j] ? true : false;

                            if (userChoose2CheckOlitory == true)
                            {
                                goto finishUserChoose2CheckOlitory;
                            }
                        }
                    }

finishUserChoose2CheckOlitory:

                    switch (userChoose2)
                    {
                        case "редис":
                        case "салат":
                        case "кріп":
                            Nitrogenium = 6;
                            Phosphorus = 6;
                            Kalium = 6;
                            break;

                        case "картопля":
                        case "капуста":
                        case "морква":
                            Nitrogenium = 12;
                            Phosphorus = 12;
                            Kalium = 12;
                            break;

                        default:
                            Nitrogenium = 9;
                            Phosphorus = 9;
                            Kalium = 9;
                            break;
                    }
                }

                if (userChoose2CheckGarden || userChoose2CheckOlitory)
                {
                    Console.Write("Оберіть бажаний тип добрива: ");
                    userChoose3 = Console.ReadLine();

                    if (userChoose3 == typesOfFertilizers[0])   // органічне
                    {
                        if (userChoose2 == "морква" || userChoose2 == "помідор")
                        {
                            Console.WriteLine($"{userChoose2}: негативна до органіки!");
                        }
                        else
                        {
                            Console.WriteLine($"\n{typesOfOrganic[0]} вносять під осіннє перекопування ґрунту, щоб за зиму він частково розклався, «перегорів».");
                            Console.WriteLine($"\nПід перекопування свіжий гній вносять раз на 3-4 роки в дозі {manure}кг/м2.");

                            if (userChoose2 == "огірок" || userChoose2 == "гарбуз" || userChoose2 == "кабачок" || userChoose2 == "патіссон" || userChoose2 == "білокачанна" || userChoose2 == "картопля")
                            {
                                Console.WriteLine($"Культура: {userChoose2}, зазнає позитивного впливу при внесенні навесні. Весняне внесення гною допускається.\n");

                                // гній
                                PrintOrganic(userChoose1, userChoose2, Nitrogenium, Phosphorus, Kalium, typesOfOrganic[0], useOfNitrogeniumFromManureFirstYear, useOfPhosphorusFromManureFirstYear, useOfKaliumFromManureFirstYear, typesOfCultures, nitrogeniumFertilizers, phosphorusFertilizers, kaliumFertilizers, percentageOfNitrogenium, percentageOfPhosphorus, percentageOfKalium, bulkMassOfNitrogeniumFertilizers, bulkMassOfPhosphorusFertilizers, bulkMassOfKaliumFertilizers);
                            }
                            else
                            {
                                Console.WriteLine($"Культура: {userChoose2}, зазнає негативного впливу при внесенні навесні. Буде викликано надмірний ріст.");
                                Console.WriteLine("Це може зашкодити формуванню врожаю, відсунути термін дозрівання.\n");

                                PrintOrganic(userChoose1, userChoose2, Nitrogenium, Phosphorus, Kalium, typesOfOrganic[0], useOfNitrogeniumFromManureFirstYear, useOfPhosphorusFromManureFirstYear, useOfKaliumFromManureFirstYear, typesOfCultures, nitrogeniumFertilizers, phosphorusFertilizers, kaliumFertilizers, percentageOfNitrogenium, percentageOfPhosphorus, percentageOfKalium, bulkMassOfNitrogeniumFertilizers, bulkMassOfPhosphorusFertilizers, bulkMassOfKaliumFertilizers);
                            }

                            // перегній
                            Console.WriteLine($"{typesOfOrganic[1]} вносять у дозі {humus}кг/м2 раз на 2-3 роки або частіше.");
                            Console.WriteLine($"Культура: {userChoose2}, зазнає позитивного впливу при внесенні як восени, так і навесні.\n");
                            PrintOrganic(userChoose1, userChoose2, Nitrogenium, Phosphorus, Kalium, typesOfOrganic[1], useOfNitrogeniumFromHumusFirstYear, useOfPhosphorusFromHumusFirstYear, useOfKaliumFromHumusFirstYear, typesOfCultures, nitrogeniumFertilizers, phosphorusFertilizers, kaliumFertilizers, percentageOfNitrogenium, percentageOfPhosphorus, percentageOfKalium, bulkMassOfNitrogeniumFertilizers, bulkMassOfPhosphorusFertilizers, bulkMassOfKaliumFertilizers);

                            // послід
                            Console.WriteLine($"{typesOfOrganic[2]} вносять у малих дозах {placenta}кг/м2 раз на 2-3 роки або частіше.\n");
                            PrintOrganic(userChoose1, userChoose2, Nitrogenium, Phosphorus, Kalium, typesOfOrganic[2], useOfNitrogeniumFromPlacentaFirstYear, useOfPhosphorusFromPlacentaFirstYear, useOfKaliumFromPlacentaFirstYear, typesOfCultures, nitrogeniumFertilizers, phosphorusFertilizers, kaliumFertilizers, percentageOfNitrogenium, percentageOfPhosphorus, percentageOfKalium, bulkMassOfNitrogeniumFertilizers, bulkMassOfPhosphorusFertilizers, bulkMassOfKaliumFertilizers);

                            // компост
                            Console.WriteLine($"{typesOfOrganic[3]} вносять раз на 2-4 роки або частіше. Норма внесення – {compost}кг/м2.\n");
                            PrintOrganic(userChoose1, userChoose2, Nitrogenium, Phosphorus, Kalium, typesOfOrganic[3], useOfNitrogeniumFromCompostFirstYear, useOfPhosphorusFromCompostFirstYear, useOfKaliumFromCompostFirstYear, typesOfCultures, nitrogeniumFertilizers, phosphorusFertilizers, kaliumFertilizers, percentageOfNitrogenium, percentageOfPhosphorus, percentageOfKalium, bulkMassOfNitrogeniumFertilizers, bulkMassOfPhosphorusFertilizers, bulkMassOfKaliumFertilizers);

                            // зола
                            Console.WriteLine($"{typesOfOrganic[4]} вноситься щорічно, під осіннє перекопування, або навесні. Норма внесення золи – {ash}кг/м2.\n");
                            PrintOrganic(userChoose1, userChoose2, Nitrogenium, Phosphorus, Kalium, typesOfOrganic[4], useOfNitrogeniumFromAshFirstYear, useOfPhosphorusFromAshFirstYear, useOfKaliumFromAshFirstYear, typesOfCultures, nitrogeniumFertilizers, phosphorusFertilizers, kaliumFertilizers, percentageOfNitrogenium, percentageOfPhosphorus, percentageOfKalium, bulkMassOfNitrogeniumFertilizers, bulkMassOfPhosphorusFertilizers, bulkMassOfKaliumFertilizers);
                        }
                    }
                    else if (userChoose3 == typesOfFertilizers[1])  // мінеральне
                    {
                        // прості мінеральні
                        // азотні добрива
                        Console.WriteLine($"\n{userChoose2} потребує нутрієнти: \nАзот: {Nitrogenium}г Фосфор: {Phosphorus}г Калій: {Kalium}г.\n");

                        Console.WriteLine($"{typesOfMineral[0]} добрива бажано використовувати при весняному внесенні.\n");
                        Console.WriteLine($"Для покриття {Nitrogenium}г Азоту, нам необхідно внести(одне з нижче перерахованих):");

                        for (int i = 0; i < nitrogeniumFertilizers.Length; i++)
                        {
                            if (userChoose1 == typesOfCultures[0])
                            {
                                if (nitrogeniumFertilizers[i] == "аміачна селітра" || nitrogeniumFertilizers[i] == "карбамід")
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine($"Мінеральне добриво: {nitrogeniumFertilizers[i]}");
                                    Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Nitrogenium, percentageOfNitrogenium[i]), 1) + "\tг - необхідна маса добрива.");
                                    Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Nitrogenium, percentageOfNitrogenium[i]), bulkMassOfNitrogeniumFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Мінеральне добриво: {nitrogeniumFertilizers[i]}");
                                Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Nitrogenium, percentageOfNitrogenium[i]), 1) + "\tг - необхідна маса добрива.");
                                Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Nitrogenium, percentageOfNitrogenium[i]), bulkMassOfNitrogeniumFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                            }
                        }
                        Console.WriteLine();

                        // фосфорні добрива
                        Console.WriteLine($"{typesOfMineral[1]} добрива вносяться як восени, так і навесні.\n");

                        Console.WriteLine($"Для покриття {Phosphorus}г Фосфору, нам необхідно внести(одне з нижче перерахованих): ");
                        for (int i = 0; i < phosphorusFertilizers.Length; i++)
                        {
                            if (phosphorusFertilizers[i] == "фосфоритне борошно")
                            {
                                if (userChoose2 == "гірчиця" || userChoose2 == "люпин" || userChoose2 == "гречка")
                                {
                                    Console.WriteLine($"Мінеральне добриво: {phosphorusFertilizers[i]}");
                                    Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Phosphorus, percentageOfPhosphorus[i]), 1) + "\tг - необхідна маса добрива.");
                                    Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Phosphorus, percentageOfPhosphorus[i]), bulkMassOfPhosphorusFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Мінеральне добриво: {phosphorusFertilizers[i]}");
                                Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Phosphorus, percentageOfPhosphorus[i]), 1) + "\tг - необхідна маса добрива.");
                                Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Phosphorus, percentageOfPhosphorus[i]), bulkMassOfPhosphorusFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                            }
                        }
                        Console.WriteLine();

                        // калійні добрива
                        Console.WriteLine($"{typesOfMineral[2]} добрива краще вносити восени.\n");

                        Console.WriteLine($"Для покриття {Kalium}г Калію, нам необхідно внести(одне з нижче перерахованих): ");

                        for (int i = 0; i < kaliumFertilizers.Length; i++)
                        {
                            if (kaliumFertilizers[i] == "калійна сіль" || kaliumFertilizers[i] == "хлорид калію")
                            {
                                if (userChoose2 == "картопля" || userChoose2 == "перець" || userChoose2 == "помідор" || userChoose2 == "льон" || userChoose2 == "виноград" || userChoose2 == "лимон" || userChoose2 == "апельсин" || userChoose2 == "мандарин" || userChoose2 == "грейпфрут")
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine($"Мінеральне добриво: {kaliumFertilizers[i]}");
                                    Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Kalium, percentageOfKalium[i]), 1) + "\tг - необхідна маса добрива.");
                                    Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Kalium, percentageOfKalium[i]), bulkMassOfKaliumFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                                }
                            }
                            else if (kaliumFertilizers[i] == "калійна сіль")
                            {
                                if (userChoose2 == "буряк" || userChoose2 == "гречка" || userChoose2 == "просо" || userChoose2 == "рис" || userChoose2 == "овес" || userChoose2 == "сорго" || userChoose2 == "ячмінь" || userChoose2 == "тритикале" || userChoose2 == "жито" || userChoose2 == "пшениця" || userChoose2 == "кукурудза")
                                {
                                    Console.WriteLine($"Мінеральне добриво: {kaliumFertilizers[i]}");
                                    Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Kalium, percentageOfKalium[i]), 1) + "\tг - необхідна маса добрива.");
                                    Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Kalium, percentageOfKalium[i]), bulkMassOfKaliumFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Мінеральне добриво: {kaliumFertilizers[i]}");
                                Console.WriteLine(Math.Round(DoseOfMineralFertilizerSeparate(Kalium, percentageOfKalium[i]), 1) + "\tг - необхідна маса добрива.");
                                Console.WriteLine(Math.Round(MeasureTheRequiredAmountOfMineralFertilizers(DoseOfMineralFertilizerSeparate(Kalium, percentageOfKalium[i]), bulkMassOfKaliumFertilizers[i]), 1) + "\tсм3 - необхідний об'єм добрива.");
                            }
                        }
                        Console.WriteLine();

                        Console.WriteLine($"{userChoose2} потребує нутрієнти: \nАзот: {Nitrogenium}г Фосфор: {Phosphorus}г Калій: {Kalium}г.");

                        for (int i = 0; i <= percentageOfComplex.GetUpperBound(0); i++) // комплексні мінеральні добрива
                        {
                            for (int j = 0; j < 1; j++)
                            {
                                if (Nitrogenium == Phosphorus && Nitrogenium == Kalium) // якщо рекомендована норма внесення однакова
                                {
                                    if (percentageOfComplex[i, j] == percentageOfComplex[i, j+1] && percentageOfComplex[i, j] == percentageOfComplex[i, j+2]) // якщо процентний вміст елемента живлення однаковий
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Комплексне добриво: {complexMineralFertilizers[i]}");
                                        DoseOfMineralFertilizerSeparateMaxContent(userChoose1, userChoose2, typesOfCultures, percentageOfComplex[i, j], percentageOfComplex[i, j+1], percentageOfComplex[i, j+2], Nitrogenium, Phosphorus, Kalium, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);

                                    }
                                    else // якщо процентний вміст елемента живлення різний
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Комплексне добриво: {complexMineralFertilizers[i]}");
                                        DoseOfMineralFertilizerSeparateMaxContent(userChoose1, userChoose2, typesOfCultures, percentageOfComplex[i, j], percentageOfComplex[i, j+1], percentageOfComplex[i, j+2], Nitrogenium, Phosphorus, Kalium, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);
                                    }
                                }
                                else // якщо рекомендована норма внесення різна
                                {
                                    if (percentageOfComplex[i, j] == percentageOfComplex[i, j+1] && percentageOfComplex[i, j] == percentageOfComplex[i, j+2]) // якщо процентний вміст елемента живлення однаковий
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Комплексне добриво: {complexMineralFertilizers[i]}");
                                        DoseOfMineralFertilizerSeparateMinRate(userChoose1, userChoose2, typesOfCultures, percentageOfComplex[i, j], percentageOfComplex[i, j+1], percentageOfComplex[i, j+2], Nitrogenium, Phosphorus, Kalium, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);
                                    }
                                    else // якщо процентний вміст елемента живлення різний
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Комплексне добриво: {complexMineralFertilizers[i]}");
                                        DoseOfMineralFertilizerSeparateMinRate(userChoose1, userChoose2, typesOfCultures, percentageOfComplex[i, j], percentageOfComplex[i, j+1], percentageOfComplex[i, j+2], Nitrogenium, Phosphorus, Kalium, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);
                                    }
                                }
                            }
                        }


                    }
                    else if (userChoose3 == typesOfFertilizers[2])  // комплексні
                    {

                        for (int i = 0; i <= percentageOfComplexOrganicMineral.GetUpperBound(0); i++)
                        {
                            for (int j = 0; j < 1; j++)
                            {
                                if (Nitrogenium == Phosphorus && Nitrogenium == Kalium) // якщо рекомендована норма внесення однакова
                                {
                                    if (percentageOfComplexOrganicMineral[i, j] == percentageOfComplexOrganicMineral[i, j+1] && percentageOfComplexOrganicMineral[i, j] == percentageOfComplexOrganicMineral[i, j+2]) // якщо процентний вміст елемента живлення однаковий
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Комплексне добриво: {complexOrganicMineralFertilizers[i]}");
                                        DoseOfMineralFertilizerSeparateMaxContent(userChoose1, userChoose2, typesOfCultures, percentageOfComplexOrganicMineral[i, j], percentageOfComplexOrganicMineral[i, j+1], percentageOfComplexOrganicMineral[i, j+2], Nitrogenium, Phosphorus, Kalium, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);
                                    }
                                    else // якщо процентний вміст елемента живлення різний
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Комплексне добриво: {complexOrganicMineralFertilizers[i]}");
                                        DoseOfMineralFertilizerSeparateMaxContent(userChoose1, userChoose2, typesOfCultures, percentageOfComplexOrganicMineral[i, j], percentageOfComplexOrganicMineral[i, j+1], percentageOfComplexOrganicMineral[i, j+2], Nitrogenium, Phosphorus, Kalium, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);
                                    }
                                }
                                else // якщо рекомендована норма внесення різна
                                {
                                    if (percentageOfComplexOrganicMineral[i, j] == percentageOfComplexOrganicMineral[i, j+1] && percentageOfComplexOrganicMineral[i, j] == percentageOfComplexOrganicMineral[i, j+2]) // якщо процентний вміст елемента живлення однаковий
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Комплексне добриво: {complexOrganicMineralFertilizers[i]}");
                                        DoseOfMineralFertilizerSeparateMinRate(userChoose1, userChoose2, typesOfCultures, percentageOfComplexOrganicMineral[i, j], percentageOfComplexOrganicMineral[i, j+1], percentageOfComplexOrganicMineral[i, j+2], Nitrogenium, Phosphorus, Kalium, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);
                                    }
                                    else // якщо процентний вміст елемента живлення різний
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Комплексне добриво: {complexOrganicMineralFertilizers[i]}");
                                        DoseOfMineralFertilizerSeparateMinRate(userChoose1, userChoose2, typesOfCultures, percentageOfComplexOrganicMineral[i, j], percentageOfComplexOrganicMineral[i, j+1], percentageOfComplexOrganicMineral[i, j+2], Nitrogenium, Phosphorus, Kalium, nitrogeniumFertilizers, percentageOfNitrogenium, bulkMassOfNitrogeniumFertilizers, phosphorusFertilizers, percentageOfPhosphorus, bulkMassOfPhosphorusFertilizers, kaliumFertilizers, percentageOfKalium, bulkMassOfKaliumFertilizers);
                                    }
                                }
                            }
                        }

                    }
                    else if (userChoose3 == typesOfFertilizers[3])  // бактеріальне
                    {
                        Console.WriteLine();

                        for (int i = 0; i < typesOfBacterial.Length; i++)
                        {
                            Console.WriteLine($"Бактеріальне добриво: {typesOfBacterial[i]}");
                            Console.WriteLine(doseOfBacterial[i] + "г - доза.");
                        }
                    }
                    else if (userChoose3 == typesOfFertilizers[4])  // мікродобриво
                    {
                        Console.WriteLine();

                        for (int i = 0; i < typesOfMicro.Length; i++)
                        {
                            Console.WriteLine($"Мікродобриво: {typesOfMicro[i]}");
                            Console.WriteLine(doseOfMicro[i] + "г - доза.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введіть коректне значення назви добрива!");
                    }
                }
                else
                {
                    Console.WriteLine("Введіть коректне значення назви плоду!");
                }
            }

            Console.ReadKey();

        }
    }
}
