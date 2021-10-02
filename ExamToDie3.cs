using System;
using System.Collections.Generic;

namespace MidTerm_FlowerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string decide = "y";

            FlowerStore flowerStore = new FlowerStore();
            SelectFlower(decide, flowerStore);

            Console.ReadLine();
        }

        private static void SelectFlower(string decide, FlowerStore flowerStore)
        {   
            string selectFlower;

            Console.WriteLine("Select number for buy flower :");
            foreach (string i in flowerStore.flowerList)
            {   Console.Write((flowerStore.flowerList.IndexOf(i) + 1) + " ");
                Console.WriteLine(i);   }

            selectFlower = Console.ReadLine();
            AddFlowerToCart(selectFlower, flowerStore);
            ContinueOrExit(decide, flowerStore);

        }

        private static void AddFlowerToCart(string selectFlower, FlowerStore flowerStore)
        {
            switch (selectFlower)
            {
                case "1":
                    flowerStore.addToCart(flowerStore.flowerList[0]);
                    Console.WriteLine("Added " + flowerStore.flowerList[0]);
                    break;

                case "2":
                    flowerStore.addToCart(flowerStore.flowerList[1]);
                    Console.WriteLine("Added " + flowerStore.flowerList[1]);
                    break;

                default:
                    Console.WriteLine("Not Added to cart. found select number of flower");
                    break;
            }
        }

        private static void ContinueOrExit(string decide, FlowerStore flowerStore)
        {
            Console.WriteLine("You can stop this progress ? exit for >> exit << progress and press any key for continue");
            decide = Console.ReadLine();

            if (decide == "exit")
            {   Console.Write("Current my cart");
                flowerStore.showCart();   }
            else
            {    SelectFlower(decide, flowerStore);    }
            while (decide != "exit") ;
        }
    }
    

    class FlowerStore
    {
        public List<string> flowerList = new List<string>();
        List<string> cart = new List<string>();
        public FlowerStore()
        { flowerList.Add("Rose"); flowerList.Add("Lotus"); }
        public void addToCart(string name)
        { cart.Add(name); }

        public void showCart()
        {
            if (cart.Count == 0)
            {   Console.WriteLine("Cart is empty");   }
            else
            {   Console.WriteLine("My Cart :");
                foreach (string i in cart)
                { Console.WriteLine(i); }
            }

        }
    }
}
