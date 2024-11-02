using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class Product
    {
        private decimal price;
        public decimal Price { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                bool OnlyLetters = true;
                // ключ. слово value - это то, что хотят свойству присвоить
                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }

                //условие проверяет на то что в перемнной буквы и она не пустая
                if (OnlyLetters && value != "")
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine($"{value} - неправильное имя!!!");
                }
            }
        }


        public string GetInfo()
        {
            return $"Наименование: {Name}; Цена: {Price} руб."; 
        }
        public Product(string Name, decimal Price)
        {
            name = Name;
            price = Price;
            
        }




    }
}
