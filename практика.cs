using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp27
{
    public class CashRegister
    {
        private List<Product> _cart;
        private bool _hasMembershipCard;
        private const string MembershipCardCode = "MEMBER2024";

        public CashRegister()
        {
            _cart = new List<Product>();
            _hasMembershipCard = false;
        }

        // Метод за добавяне на продукт в количката
        public void AddToCart(Product product)
        {
            _cart.Add(product);
        }

        // Метод за премахване на продукт от количката
        public void RemoveFromCart(Product product)
        {
            _cart.Remove(product);
        }

        // Метод за активиране на членска карта(20%)
        public void ApplyMembershipCard(string cardCode)
        {
            if (cardCode == MembershipCardCode)
            {
                _hasMembershipCard = true;
            }
            else
            {
                Console.WriteLine("Invalid code for a member code");
            }
        }

        // Метод за пресмятане на сметката
        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var product in _cart)
            {
                total += product.Price;
            }
            if (_hasMembershipCard)
            {
                total *= 0.80m; // Прилагане на 20% отстъпка
            }
            return total;
        }

        // Метод за издаване на касова бележка
        public void PrintReceipt()
        {
            Console.WriteLine("----- BON -----");
            foreach (var product in _cart)
            {
                Console.WriteLine($"{product.Name}: {product.Price:C}");
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine($"SUM: {CalculateTotal():C}");
            if (_hasMembershipCard)
            {
                Console.WriteLine("Membercard 20% off");
            }
            Console.WriteLine("-------------------------");
        }
    }
}
