using System;
using System.Threading;
/*
 Финальная версия ргр
 */
namespace Rgr_v2
{
    class INF
    {
        public long minvalue;
        public long maxvalue;
        public byte Byte;
        static INF()
        {
            Console.WriteLine("Раздел №3 «Внутренние форматы данных»\nЦелочисленные типы Object Pascal");
            Console.WriteLine("Текст задания:");
            Console.WriteLine("Спроектируйте и реализуйте приложение, выполняющее вывод на экран\nвнутреннего побитового представления заданных типов данных\n");
            Console.WriteLine("\n");
        }
        static string str = "ShortInt SmallInt Integer LongInt Int64 Byte Word Cardinal LongWord";
        public string[] ss = str.Split(' ');
        public void PrintTypes(string[]ss, int i = 0)
        {
            while (i < ss.Length)
            {
                Console.WriteLine(i + 1 + " " + ss[i]);
                Thread.Sleep(100);
                i++;
            }
        }
        public void TaskText()
        {
            Console.WriteLine("================================================================");
            Console.WriteLine("                   Перевод во внутренний формат                 ");
            Console.WriteLine("================================================================");
        }
        public void StartRender(int i = 0)
        {
            Console.WriteLine("================================================================");
            Console.WriteLine("              Начинаем перевод во внутренний формат             ");
            Console.WriteLine("================================================================");
            while (i < 3)
            {
                Console.Write('.');
                i++;
                Thread.Sleep(400);
            }
            Console.WriteLine();
        }
        public void PrintOnlySep()
        {
            Console.WriteLine("================================================================\n");
        }
        public void PrintOnlyStartSep()
        {
            Console.WriteLine("================================================================");
        }
        //public void PrintSep()
        //{
        //    Console.WriteLine("================================================================");
        //    Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
        //    Console.WriteLine("================================================================");
        //}
        //public void PrintSep(string Input)
        //{
        //    Console.WriteLine("================================================================");
        //    Console.WriteLine("{0,60}", Input);
        //    Console.WriteLine("================================================================");
        //}
        public void PrintStartSep(string Input)
        {
            Console.WriteLine("================================================================");
            if(Input.Length<=50) Console.Write("{0,56}" , Input);
            else Console.Write("{0,60}", Input);
        }
        public void PrintInfoOf(char number)
        {
            string strarray =
            "1-128 ... 1271_" +
            "2-32768 ... 327672_" +
            "4-2147483648 ... 21474836473_" +
            "4-2147483648 ... 21474836474_" +
            "8-9223372036854775808 ... 92233720368547758075_" +
            "10 ... 2556_" +
            "20 ... 655357_" +
            "40 ... 42949672958_" +
            "40 ... 42949672959";
            string[] newstring = strarray.Split("_");
            int i = 0;
            while (i<=newstring.Length)
            {
                strarray = newstring[i];
                if (strarray[^1] == number)
                {
                    char[] NewStringArray = strarray.ToCharArray();

                    NewStringArray[0] = ' ';
                    NewStringArray[^1] = ' ';

                    string newstr = new string(NewStringArray);

                    string[] strarr = newstr.Split(" ... ");

                    minvalue = long.Parse(strarr[0]);
                    maxvalue = long.Parse(strarr[1]);

                    Console.WriteLine("Длина(байт): {0} \n",strarray[0]);
                    Thread.Sleep(100);
                    char[] arr = strarray.ToCharArray();
                    arr[0] -= '0';
                    Byte = (byte)arr[0];
                    arr[0] = ' ';
                    arr[arr.Length-1] = ' ';
                    strarray = new string(arr);
                    Console.WriteLine("Диапазон значений: {0} \n", strarray);
                    break;
                }
                i++;
            }
        }
        public bool IsNumber(string str, ref int index)
        {
            if (str.Length == index) return false;
            if (str[0] == '-') index++;
            while (str.Length > index)
            {
                char c = str[index];
                if(Char.IsDigit(c)==false) return false;
                index++;
            }
            return true;
        }
        public string NumberSystem2(long value)
        {
            string ValueP2 = "";
            while (value > 0)
            {
                long bit = 1;
                bit &= value;
                ValueP2 += bit;
                value = value >> 1;
            }
            char[] CharArray = ValueP2.ToCharArray();
            Array.Reverse(CharArray);
            string ValueP2V2 = new string(CharArray);
            return ValueP2V2;
        }
        //public static void InvertedNumber(ref long value,string values)
        //{
        //    int i = 0;
        //    while (i<values.Length)
        //    {
        //        int x = 1;

        //        x <<= i;

        //        value ^= x;
        //        i++;
        //    }
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                INF format = new INF(); // вывод текста задания
                Console.WriteLine("\n");

                format.TaskText(); // вывод краткого текста задания

                format.PrintTypes(format.ss);
                Thread.Sleep(200);

                format.PrintStartSep("Выберете номер типа, который вы хотите использовать: ");
                char NumberOfType;
                while (true)
                {
                    string symvol = Console.ReadLine();
                    format.PrintOnlySep();
                    Thread.Sleep(200);
                    if (char.TryParse(symvol, out NumberOfType) == false)
                    {
                        format.PrintStartSep("Введен недопустимый символ, попробуйте ещё раз: ");
                        continue;
                    }

                    if (NumberOfType >= '1' && NumberOfType <= '9')
                    {
                        Console.WriteLine("Вы выбрали тип: {0}. Информация о типе {0}:\n", format.ss[NumberOfType-'1']);
                        break;
                    }
                    else format.PrintStartSep("Введен недопустимый символ, попробуйте ещё раз: ");
                }
                Thread.Sleep(100);
                format.PrintInfoOf(NumberOfType);
                Thread.Sleep(100);

                format.PrintStartSep("Введите значение попадающее в данный диапазон: ");
                long userinput;
                while (true)
                {
                    while (true)
                    {
                        int index = 0;
                        string userinputv1 = Console.ReadLine();
                        format.PrintOnlySep();
                        Thread.Sleep(100);
                        if (format.IsNumber(userinputv1,ref index) == true)
                        {
                            try
                            {
                                userinput = long.Parse(userinputv1);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("ЧЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁЁ??????????????");
                                continue;
                            }
                            break;
                        }
                        format.PrintOnlyStartSep();
                        Console.Write("\tЭто не число, ошибка в {0} символе, попробуйте еще раз: ", index+1);
                    }
                    if (userinput > format.maxvalue)
                    {
                        format.PrintStartSep("Число больше допустимого значения,попробуйте еще раз: ");
                        continue;
                    }
                    else if (userinput < format.minvalue)
                    {
                        format.PrintStartSep("Число меньше допустимого значения,попробуйте еще раз: ");
                        continue;
                    }
                    break;
                }

                if (userinput >= 0)
                {
                    string ValueP2V2 = format.NumberSystem2(userinput);
                    string notation2 = ValueP2V2.PadLeft(format.Byte * 8, '0');
                    Thread.Sleep(600);
                    format.StartRender();
                    format.PrintOnlyStartSep();
                    Console.WriteLine("Число {0} во внутреннем формате выглядит так: {1}", userinput, notation2);
                    format.PrintOnlyStartSep();
                }

                else
                {
                    long userinputABS = Math.Abs(userinput) - 1;

                    string ValueP2 = format.NumberSystem2(userinputABS);

                    char[] array = ValueP2.ToCharArray();
                    int i = 0;
                    while(i < array.Length)
                    {
                        if (array[i] == '0') array[i] = '1';
                        else if (array[i] == '1') array[i] = '0';
                        i++;
                    }

                    ValueP2 = new string(array);

                    string notation2 = ValueP2.PadLeft(format.Byte * 8, '1');
                    Thread.Sleep(600);
                    format.StartRender();
                    format.PrintOnlyStartSep();
                    Console.WriteLine("Число {0} во внутреннем формате выглядит так: {1}", userinput, notation2);
                    format.PrintOnlyStartSep();
                }
                Thread.Sleep(1000);
                Console.WriteLine("\n\n");
                Console.Write("Конец! Чтобы начать с начала, нажмите любую клавишу:   ");
                Console.ReadKey();
            }
        }
    }
}
