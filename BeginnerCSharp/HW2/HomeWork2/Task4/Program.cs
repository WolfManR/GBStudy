using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new ()
            {
                Name = "ООО 'ПЕТЕР-СЕРВИС Спецтехнологии'",
                INN = 7841465198,
                Address = "115280, г.Москва, ул.Ленинская Слобода, 19",
                Phone = 88005509911,
                FN = 8712000100052999,
                RNKKT = 1615844055214,
                ZNKKT = 495002881,
                FD = 17058,
                FPD = 2074315309,
                
                ShortName = "ООО 'ПС СТ'",
                Site = "ofd.ru"
            };

            Product product1 = new()
            {
                Name = "Брендирование электронных чеков для отправки \nпокупателям на e-mail",
                Price = 500,
                NDS = 0.2m
            };
            
            Product product2 = new()
            {
                Name = "Мягкая игрушка 'Фискальный накопитель'",
                Price = 2,
                NDS = 0.1m
            };

            Order order = new()
            {
                BuyTime = new (2019,1,1,17,46,0),
                SellerName = "Иванова И. И.",
                CheckNumber = 144,
                Shift = 123,
                
                Products = new ()
                {
                    [product1] = 3,
                    [product2] = 500
                }
            };
            var orderTime = order.BuyTime.ToString("dd.MM.yy  hh:mm");

            var product1TotalPrice = product1.Price * order.Products[product1];
            var product2TotalPrice = product2.Price * order.Products[product2];
            
            var checkPattern = $@"
                Кассовый чек
Приход

{company.Name}
ИНН {company.INN}
{company.Address}
{company.Phone:# ### ###-##-##}

{orderTime}                    Чек No     {order.CheckNumber:d5}
Кассир: {order.SellerName}              Смена No   {order.Shift:d5}

ФН                                 {company.FN:d16}
РН ККТ                             {company.RNKKT:d16}
ЗН ККТ                                   {company.ZNKKT:d10}
ФД                                       {company.FD:d10}
ФПД                                      {company.FPD:d10}
---------------------------------------------------

{product1.Name}
                            {product1.Price} X {order.Products[product1]:f}    = {product1TotalPrice:f}
                            НДС {product1.NDS:P0}       = {product1TotalPrice * product1.NDS :f}

{product2.Name}
                            {product2.Price} X {order.Products[product2]:f}    = {product2TotalPrice:f}
                            НДС {product2.NDS:P0}       = {product2TotalPrice * product2.NDS :f}

---------------------------------------------------

ИТОГ                                      = {product1TotalPrice + product2TotalPrice :f}

НАЛИЧНЫМИ                                    = 0.00
БЕЗНАЛИЧНЫМИ                               = {product1TotalPrice + product2TotalPrice :f1}
ОБМЕН                                        = 0.00
ПРЕДОПЛАТА (АВАНС)                           = 0.00
ПОСТОПЛАТА (КРЕДИТ)                          = 0.00

НАЛОГООБЛАЖЕНИЕ                                 ОСН

Сумма НДС {product1.NDS:P0}                             = {product1TotalPrice * product1.NDS :f}
Сумма НДС {product2.NDS:P0}                             = {product2TotalPrice * product2.NDS :f}

---------------------------------------------------

Сайт ФНС: nalog.ru
ОФД: {company.ShortName}, {company.Site}
";
            
            WriteLine(checkPattern);

            // Program Stop
            ReadLine();
        }

        record Company
        {
            public string Name { get; init; }
            public string ShortName { get; init; }
            public string Site { get; init; }
            public long INN { get; init; }
            public string Address { get; init; }
            public long Phone { get; init; }
            public long FN { get; init; }
            public long RNKKT { get; init; }
            public int ZNKKT { get; init; }
            public int FD { get; init; }
            public int FPD { get; init; }
        }

        record Order
        {
            public DateTime BuyTime { get; init; }
            public string SellerName { get; init; }
            public short CheckNumber { get; init; }
            public short Shift { get; init; }
            public Dictionary<Product, int> Products { get; init; }
        }

        record Product
        {
            public string Name { get; init; }
            public decimal Price { get; init; }
            public decimal NDS { get; init; }
        }
    }
}