using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerList
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ComputerModel computer1 = new ComputerModel("Артикул1", "Марка1", "ТипПроцессора1", 2.1, 2, 256, 2, 500, 32);
                ComputerModel computer2 = new ComputerModel("Артикул2", "Марка2", "ТипПроцессора1", 2.1, 4, 512, 2, 700, 36);
                ComputerModel computer3 = new ComputerModel("Артикул3", "Марка3", "ТипПроцессора2", 2.4, 4, 1024, 4, 900, 25);
                ComputerModel computer4 = new ComputerModel("Артикул4", "Марка4", "ТипПроцессора3", 2.8, 8, 1024, 4, 12500, 10);
                ComputerModel computer5 = new ComputerModel("Артикул5", "Марка5", "ТипПроцессора3", 2.8, 16, 2048, 6, 15500, 8);
                ComputerModel computer6 = new ComputerModel("Артикул6", "Марка6", "ТипПроцессора4", 3.8, 32, 2048, 8, 25555, 5);
                ComputerModel computer7 = new ComputerModel("Артикул7", "Марка7", "ТипПроцессора5", 3.5, 32, 1024, 4, 11000, 10);
                ComputerModel computer8 = new ComputerModel("Артикул8", "Марка8", "ТипПроцессора6", 4.0, 16, 1024, 4, 15000, 17);
                ComputerModel computer9 = new ComputerModel("Артикул9", "Марка9", "ТипПроцессора6", 4.0, 32, 2048, 8, 25280, 3);
                List<ComputerModel> listComputers = new List<ComputerModel>() { computer1,computer2,computer3,computer4,computer5,computer6,
                                                                                computer7,computer8,computer9};

                //Первая часть задачи с выводом компьютеров с определенным процессором
                Console.WriteLine("Введите тип процессора (от \"ТипПроцессора1\" до \"ТипПроцессора6\"");
                string typeProcUser = Console.ReadLine();

                IEnumerable<ComputerModel> proccessorsListUser = listComputers
                    .Where(p => p.TypeProcessor == typeProcUser);

                foreach (ComputerModel p in proccessorsListUser)
                {
                    Console.WriteLine($"{p.ArticleComputer}\t{p.MarkComputer}\t{p.PriceComputer} у.е.");
                }
                Console.WriteLine("");

                //Вторая задача с выводом компьютеров с минимальными требованиями ОЗУ
                Console.WriteLine("Введите минимальное значение ОЗУ в Гб (представлены компьютеры с ОЗУ 2,4,8,16,32)");
                int minRam = Convert.ToInt32(Console.ReadLine());

                IEnumerable<ComputerModel> RAMListUser = listComputers
                    .Where(r => r.RAMComputer >= minRam);

                foreach (ComputerModel r in RAMListUser)
                {
                    Console.WriteLine($"{r.ArticleComputer}\t{r.MarkComputer}\t{r.RAMComputer} Гб\t{r.PriceComputer} у.е.");
                }
                Console.WriteLine("");

                //Третья задача, выводит список сортированный по возрастанию цены
                Console.WriteLine("Список, сортированный по возрастанию цены:");

                IEnumerable<ComputerModel> ascendingList= listComputers
                    .OrderBy(c=>c.PriceComputer);

                foreach (ComputerModel a in ascendingList)
                {
                    Console.WriteLine($"{a.ArticleComputer}\t{a.MarkComputer}\t{a.PriceComputer} у.е.");
                }
                Console.WriteLine("");

                //Четвертая задача - Вывести список, сгруппированный по типу процессора
                Console.WriteLine("Список, сгруппированный по типу процессора:");

                var procGroupList = listComputers
                    .GroupBy(pr => pr.TypeProcessor);

                foreach (IGrouping<string,ComputerModel> pr in procGroupList)
                {
                    Console.WriteLine(pr.Key);
                    foreach (var el in pr)
                    {
                        Console.WriteLine($"\t{el.ArticleComputer}\t{el.MarkComputer}\t{el.FrequencyProcessor}\t{el.PriceComputer}");
                    }
                }
                Console.WriteLine("");

                //Найти самый дорогой и самый бюджетный компьютер

                double maxPrice = listComputers.Max(mx => mx.PriceComputer);
                Console.WriteLine("Стоимость самого дорого компьютера составляет {0:f2}",maxPrice);
                IEnumerable<ComputerModel> maxPriceList = listComputers
                   .Where(max => max.PriceComputer == maxPrice);

                foreach (ComputerModel max in maxPriceList)
                {
                    Console.WriteLine($"{max.ArticleComputer}\t{max.MarkComputer}");
                }
                Console.WriteLine("");


                double minPrice = listComputers.Min(mn => mn.PriceComputer);
                Console.WriteLine("Стоимость самого дешевого компьютера составляет {0:f2}", minPrice);
                IEnumerable<ComputerModel> minPriceList = listComputers
                   .Where(min => min.PriceComputer == minPrice);

                foreach (ComputerModel min in minPriceList)
                {
                    Console.WriteLine($"{min.ArticleComputer}\t{min.MarkComputer}");
                }
                Console.WriteLine("");

                //Проверить, есть ли хоть один компьютер в количестве более 30 штук?
                int moreThan30Computers = 0;
                Console.WriteLine("Есть ли хоть один компьютер в количестве больше 30?");

                /*Самый простой вариант:
                 * moreThan30Computers = false;
                 * foreach (ComputerModel co in listComputers)
                {
                    if (co.QuantityComputer>30)
                    {
                        moreThan30Computers = true;
                    }
                }*/
                IEnumerable<ComputerModel> quantityList = listComputers
                  .Where(q => q.QuantityComputer > 30);
                moreThan30Computers = quantityList.Count();
                
                if (moreThan30Computers>0)
                {
                    Console.WriteLine("Есть компьютер(ы), количество которого(ых) больше 30");
                    foreach (ComputerModel q in quantityList)
                    {
                        Console.WriteLine($"{q.ArticleComputer}\t{q.MarkComputer}\t{q.QuantityComputer}"); ;
                    }
                }
                else
                {
                    Console.WriteLine("Таких компьютеров нет.");
                }

            }
            catch (Exception)
            {

                throw;
            }

            Console.ReadKey();
        }
    }
    class ComputerModel
    {
        #region Поля и свойства
        public string ArticleComputer { get; set; }
        public string MarkComputer { get; set; }
        public string TypeProcessor { get; set; }

        private double _frequencyProcessor;
        private int _RAMComputer;
        private int _hardDiskCapacity;
        private int _VRAMComputer;
        private double _priceComputer;
        private int _quantityComputer;

        public double FrequencyProcessor
        {
            set
            {
                if (value>0)
                {
                    _frequencyProcessor = value;
                }
                else
                {
                    Console.WriteLine("Частота должна быть больше нуля.");
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return _frequencyProcessor;
            }
        }
        public int RAMComputer
        {
            set
            {
                if (value > 0)
                {
                    _RAMComputer = value;
                }
                else
                {
                    Console.WriteLine("RAM должна быть больше нуля.");
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return _RAMComputer;
            }
        }
        public int HardDiskCapasity
        {
            set
            {
                if (value > 0)
                {
                    _hardDiskCapacity = value;
                }
                else
                {
                    Console.WriteLine("Объем жесткого диска должна быть больше нуля.");
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return _hardDiskCapacity;
            }
        }
        public int VRAMComputer
        {
            set
            {
                if (value > 0)
                {
                    _VRAMComputer = value;
                }
                else
                {
                    Console.WriteLine("Память видеокарты должна быть больше нуля.");
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return _VRAMComputer;
            }
        }
        public double PriceComputer
        {
            set
            {
                if (value > 0)
                {
                    _priceComputer = value;
                }
                else
                {
                    Console.WriteLine("Стоимость должна быть больше нуля.");
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return _priceComputer;
            }
        }
        public int QuantityComputer
        {
            set
            {
                if (value>=0)
                {
                    _quantityComputer = value;
                }
                else
                {
                    Console.WriteLine("Количество компьютеров не меньше нуля.");
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return _quantityComputer;
            }
        }
        #endregion
        public ComputerModel (string article, string mark, string procType, double frequencyProc, int RAM, int HDD, int VRAM, double price, int quantity)
        {
            ArticleComputer = article;
            MarkComputer = mark;
            TypeProcessor = procType;
            FrequencyProcessor = frequencyProc;
            RAMComputer = RAM;
            HardDiskCapasity = HDD;
            VRAMComputer = VRAM;
            PriceComputer = price;
            QuantityComputer = quantity;
        }
    }
}
