using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProject
{
    public class Product
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public float ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public override string ToString()
        {
            return "ID: " + ProductId + "   Name: " + ProductName + " " + 
                "Price: " + ProductPrice + " " + "Quantity: " + ProductQuantity;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Product objAsProduct = obj as Product;
            if (objAsProduct == null) return false;
            else return Equals(objAsProduct);
        }
        public override int GetHashCode()
        {
            return ProductId;
        }
        public bool Equals(Product other)
        {
            if (other == null) return false;
            return (this.ProductId.Equals(other.ProductId));
        }
    }
    public class Inventory: Product
    {
        public static void Main()
        {
            List<Product> products = new List<Product>();

            string n;
            float sum = 0f;
            float sumtotal = 0f;

            do
            {
                Console.WriteLine("Нажмите 1, что бы добавить новый продукт: ");
                Console.WriteLine("Нажмите 2, что бы вывести сумму продуктов: ");
                Console.WriteLine("Нажмите 3, что бы удалить продукт: ");
                Console.WriteLine("Нажмите 4, что бы показать весь список и выйти");
                n = Console.ReadLine();
                

                switch (n)
                {
                    case "1":
                        Console.WriteLine("ID: \t");
                        int id1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Название: \t");
                        string name = Console.ReadLine();
                        Console.WriteLine("Цена: \t");
                        string price1 = Console.ReadLine();
                        float price = float.Parse(price1);
                        Console.WriteLine("Количество: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        

                       sumtotal +=  Addproduct(name, quantity, price, id1);
                       
                        DisplayInfo();

                        break;

                    case "2":

                        Console.WriteLine($"Сумма продуктов равна: {sumtotal}");

                        break;

                    case "3":
                        Console.WriteLine("Введите ID \t");
                        int id = Convert.ToInt32(Console.ReadLine());
                       
                       Removeproduct(id);
                        
                        DisplayInfo();

                        break;

                    case "4":

                        DisplayInfo();

                        break;
                }
            }
            while (n != "4");

            float Addproduct(string name, int quantity, float price, int id1)
            {
                products.Add(new Product()
                {
                    ProductId = id1,
                    ProductName = name,
                    ProductQuantity = quantity,
                    ProductPrice = price,
                });
                sum =+ price;
                    return sum;
            }
        
            float Removeproduct(int id)
            {
                products.Remove(new Product() 
                {
                    ProductId = id,
                });
                Product pro = new Product();
                float price = pro.ProductPrice;
                sum =- price;
                return sum ;
            }

             void DisplayInfo()
            {
                foreach (Product pr in products)
                {
                    Console.WriteLine($"Наименование:\n {pr}\n");
                }
            }
            Console.ReadKey();
        }
    }
}
