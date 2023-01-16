using System;
using System.Data.SqlClient;
using UserAccess;
using System.Configuration;
using Domain.Models;
using Domain.Controllers;

namespace TestApp
{
    class Programm
    {
        private static UserController _userController;
        private static ProductController _productController;
        private static TotalController _totalController;
        private static DeleteController _deleteController;
        static void Main(string[] args) //Здесь прописано меню для взаимодействия с пользователем
        {
            string connect = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
            _userController = new UserController(new UserChanger(connect));
            _productController = new ProductController(new ProductChanger(connect));
            _totalController = new TotalController(new TotalChanger(connect));
            Menu();
        }
        static int Randomazzo()
        {
            int TrueRandom = 0;
            Random r = new Random();
            TrueRandom = r.Next(1, 100);
            return TrueRandom;
        }
        static void Menu()
        {
            bool exit = false;
            int point = 0;
            Console.WriteLine("Добро пожаловать в тестовую сборку консольного приложения для работы с базами данных v1.0.");
            Console.WriteLine("Навигация происходит путем ввода чисел, указанных в начале пунктов меню. Приятного пользования!");
            do
            {
                Console.WriteLine("*******************************************************");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Работа с данными пользователей");
                Console.WriteLine("2. Работа с данными товаров");
                Console.WriteLine("3. Работа с товарооборотом");
                Console.WriteLine("0. Покинуть меню");
                try
                {
                    point = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    point = 0;
                    Console.WriteLine("Введено недопустимое значение. Выход на предыдущее меню!");
                }
                switch (point)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        Console.WriteLine("*******************************************************");
                        Console.WriteLine("В данном разделе можно вносить изменения в базу данных пользователей.");
                        do
                        {
                            Console.WriteLine("Выберите пункт меню:");
                            Console.WriteLine("1. Добавить пользователя");
                            Console.WriteLine("2. Изменить пользователя");
                            Console.WriteLine("3. Удалить пользователя");
                            Console.WriteLine("4. Отобразить базу пользователей");
                            Console.WriteLine("0. Покинуть меню");
                            int pointUser = 0;
                            try
                            {
                                pointUser = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                pointUser = 0;
                                Console.WriteLine("Введено недопустимое значение. Выход на предыдущее меню!");
                            }
                            switch (pointUser)
                            {
                                case 0:
                                    exit = true;
                                    break;
                                case 1:
                                    int ID = 0;
                                    do
                                    {
                                        Console.Write("Введите логин:");
                                        string login = Console.ReadLine();

                                        Console.Write("Введите email:");
                                        string email = Console.ReadLine();

                                        Console.Write("Введите имя:");
                                        string name = Console.ReadLine();

                                        _userController.AddUser(login, email, name);
                                        Console.WriteLine();

                                        Console.WriteLine("Продолжить?");
                                        int a = 0;
                                        try
                                        {
                                            a = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            a = 0;
                                            Console.WriteLine("Введено недопустимое значение. Выход на предыдущее меню!");
                                        }
                                        if (a == 0)
                                            exit = true;
                                    } while (exit == false);
                                    exit = false;
                                    break;
                                case 2:
                                    do
                                    {
                                        Console.WriteLine("Введите ID записи, которую хотите изменить:");
                                        ID = Convert.ToInt32(Console.ReadLine());

                                        Console.WriteLine("Введите логин:");
                                        string login = Console.ReadLine();

                                        Console.WriteLine("Введите email:");
                                        string email = Console.ReadLine();

                                        Console.WriteLine("Введите имя:");
                                        string name = Console.ReadLine();

                                        _userController.UpdUser(ID, login, email, name);
                                        Console.WriteLine();

                                        Console.WriteLine("Продолжить?");
                                        int a = 0;
                                        try
                                        {
                                            a = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            a = 0;
                                            Console.WriteLine("Введено недопустимое значение. Выход на предыдущее меню!");
                                        }
                                        if (a == 0)
                                            exit = true;
                                    } while (exit == false);
                                    exit = false;
                                    break;
                                case 3:
                                    do
                                    {
                                        Console.WriteLine("Введите ID записи, которую хотите удалить:");
                                        ID = Convert.ToInt32(Console.ReadLine());

                                        _userController.DelUser(ID);
                                        Console.WriteLine();

                                        Console.WriteLine("Продолжить?");
                                        int a = 0;
                                        try
                                        { 
                                            a = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            a = 0;
                                            Console.WriteLine("Введено недопустимое значение. Выход на предыдущее меню!");
                                        }
                                        if (a == 0)
                                            exit = true;
                                    } while (exit == false);
                                    exit = false;
                                    break;
                                case 4:
                                    List<User> user = _userController.GetUsers();
                                    ShowUsers(user);
                                    exit = false;
                                    break; 
                                default:
                                    Console.WriteLine("Неверный пункт меню. Попробуйте еще раз!");
                                    break;
                            }
                        } while (exit == false);
                        exit = false;
                        break;
                    case 2:
                        Console.WriteLine("*******************************************************");
                        Console.WriteLine("В данном разделе можно вносить изменения в базу данных товаров.");
                        do
                        {
                            Console.WriteLine("Выберите пункт меню:");
                            Console.WriteLine("1. Добавить товар");
                            Console.WriteLine("2. Изменить товар");
                            Console.WriteLine("3. Удалить товар");
                            Console.WriteLine("4. Отобразить базу товаров");
                            Console.WriteLine("0. Покинуть меню");
                            int pointProd = 0;
                            try
                            {
                                pointProd = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                pointProd = 0;
                                Console.WriteLine("Введено недопустимое значение. Выход на предыдущее меню!");
                            }
                            switch (pointProd)
                            {
                                case 0:
                                    exit = true;
                                    break;
                                case 1:
                                    do
                                    {
                                        Console.WriteLine("Введите название товара:");
                                        string Pname = Console.ReadLine();
                                        Console.WriteLine("Цена сгенерирована.");
                                        int price = Randomazzo();
                                        Console.WriteLine("Введите количество товара на складе:");
                                        int instock = Convert.ToInt32(Console.ReadLine());

                                        _productController.AddProduct(Pname, price, instock);
                                        Console.WriteLine();
                                        //GetUsers();

                                        Console.WriteLine("Продолжить?");
                                        int a = 0;
                                        try
                                        {
                                            a = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            a = 0;
                                            Console.WriteLine("Введено недопустимое значение. Выход на предыдущее меню!");
                                        }
                                        if (a == 0)
                                            exit = true;
                                    } while (exit == false);
                                    exit = false;
                                    break;
                                case 2:
                                    do
                                    {
                                        Console.WriteLine("Введите ID товара:");
                                        int ID = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введите новое название товара:");
                                        string Pname = Console.ReadLine();
                                        Console.WriteLine("Введите новую цену товара:");
                                        int price = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введите новое количество товара на складе:");
                                        int instock = 0;
                                        try
                                        {
                                            instock = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            instock = 0;
                                        }

                                        _productController.UpdProduct(ID, Pname, price, instock);
                                        Console.WriteLine();

                                        Console.WriteLine("Продолжить?");
                                        int a = 0;
                                        try
                                        {
                                            a = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            a = 0;
                                            Console.WriteLine("Введено недопустимое значение. Выход на предыдущее меню!");
                                        }
                                        if (a == 0)
                                            exit = true;
                                    } while (exit == false);
                                    exit = false;
                                    break;
                                case 3:
                                    do
                                    {
                                        Console.Write("Введите ID товара:");
                                        int ID = Convert.ToInt32(Console.ReadLine());

                                        _productController.DelProduct(ID);
                                        Console.WriteLine();

                                        Console.WriteLine("Продолжить?");
                                        int a = 0;
                                        try
                                        {
                                            a = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            a = 0;
                                            Console.WriteLine("Введено недопустимое значение. Выход на предыдущее меню!");
                                        }
                                        if (a == 0)
                                            exit = true;
                                    } while (exit == false);
                                    exit = false;
                                    break;
                                case 4:
                                    //ProductChanges.ShowTable();
                                    exit = false;
                                    break;
                                default:
                                    Console.WriteLine("Неверный пункт меню. Попробуйте еще раз!");
                                    break;
                            }
                        } while (exit == false);
                        exit = false;
                        break;
                    case 3:
                        Console.WriteLine("*******************************************************");
                        Console.WriteLine("В данном разделе можно вносить изменения в базу данных продаж.");
                        do
                        {
                            Console.WriteLine("Выберите пункт меню:");
                            Console.WriteLine("1. Добавить сделку");
                            Console.WriteLine("2. Изменить сделку");
                            Console.WriteLine("3. Удалить сделку");
                            Console.WriteLine("4. Отобразить базу продаж");
                            Console.WriteLine("5. Очистить базу по заданным параметрам");
                            Console.WriteLine("0. Покинуть меню");
                            int pointTot = 0;
                            try
                            {
                                pointTot = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                pointTot = 0;
                                Console.WriteLine("Введено недопустимое значение. Выход на предыдущее меню!");
                            }
                            switch (pointTot)
                            {
                                case 0:
                                    exit = true;
                                    break;
                                case 1:
                                    do
                                    {
                                        Console.WriteLine("Введите ID покупателя:");
                                        int ID = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введите ID товара:");
                                        int prodid = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Количество товара сгенерировано.");
                                        int sum = Randomazzo();

                                        _totalController.AddTotal(ID, prodid, sum);
                                        Console.WriteLine();
                                        //GetUsers();

                                        Console.WriteLine("Продолжить?");
                                        int a = 0;
                                        try
                                        {
                                            a = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            a = 0;
                                            Console.WriteLine("Введено недопустимое значение. Выход на предыдущее меню!");
                                        }
                                        if (a == 0)
                                            exit = true;
                                    } while (exit == false);
                                    exit = false;
                                    break;
                                case 2:
                                    do
                                    {
                                        Console.WriteLine("Введите ID сделки:");
                                        int ID = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введите ID нового покупателя:");
                                        int userID = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введите ID товара:");
                                        int prodID = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введите новое количество купленного товара:");
                                        int totprod = Convert.ToInt32(Console.ReadLine());

                                        _totalController.UpdTotal(ID, userID, prodID, totprod);
                                        Console.WriteLine();

                                        Console.WriteLine("Продолжить?");
                                        int a = 0;
                                        try
                                        {
                                            a = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            a = 0;
                                            Console.WriteLine("Введено недопустимое значение. Выход на предыдущее меню!");
                                        }
                                        if (a == 0)
                                            exit = true;
                                    } while (exit == false);
                                    exit = false;
                                    break;
                                case 3:
                                    do
                                    {
                                        Console.Write("Введите ID сделки:");
                                        int ID = Convert.ToInt32(Console.ReadLine());

                                        _totalController.DelTotal(ID);
                                        Console.WriteLine();

                                        Console.WriteLine("Продолжить?");
                                        int a = 0;
                                        try
                                        {
                                            a = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            a = 0;
                                            Console.WriteLine("Введено недопустимое значение. Выход на предыдущее меню!");
                                        }
                                        if (a == 0)
                                            exit = true;
                                    } while (exit == false);
                                    exit = false;
                                    break;
                                case 4:
                                    //TotalsChanges.ShowTable();
                                    exit = false;
                                    break;
                                case 5:
                                    Console.Write("Эта операция может привести к удалению ВСЕЙ базы сделок. Введите 1 для продолжения. Продолжить?:");
                                    int agree = Convert.ToInt32(Console.ReadLine());
                                    if (agree == 1)
                                    {
                                        Console.Write("Введите минимальное количество купленной продукции:");
                                        int prodsum = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Введите минимальную сумму сделки:");
                                        int totalsum = Convert.ToInt32(Console.ReadLine());

                                        _deleteController.DeleteByParameter(prodsum, totalsum);
                                        Console.WriteLine();

                                        Console.WriteLine("База очищена по указанному параметру.");
                                    }
                                    else
                                    {
                                        Console.Write("Введено число, отличное от 1. Операция отменена.");
                                        exit = true;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Неверный пункт меню. Попробуйте еще раз!");
                                    break;
                            }
                        } while (exit == false);
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Неверный пункт меню. Попробуйте еще раз!");
                        break;
                }
            } while (exit == false);
        }
        private static void PrintUser(User user)
        {
            Console.WriteLine($"{user.ID.ToString().PadLeft(7)} {user.Login.PadLeft(15)} {user.Email.PadLeft(50)} {user.Name.PadLeft(25)} {user.CreationDate.ToString()}");
        }
        public static void ShowUsers(List<User> users)
        {
            foreach (User user in users)
                PrintUser(user);
        }
        public static void ShowProducts(List<Product> prods)
        {

        }
        public static void ShowTotals(List<Total> totals)
        {

        }
    }
}