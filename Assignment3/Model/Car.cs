using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Model
{
    internal class Car
    {
        private int carId;
        public int CarId
        {
            get { return carId; }
            set { carId = value; }
        }
        private string brand;
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private string year;
        public string Year
        {
            get { return year; }
            set { year = value; }
        }
        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public Car() { }
        public Car(int carId, string brand, string model, string year, double price)
        {
            this.carId = carId;
            this.brand = brand;
            this.model = model;
            this.year = year;
            this.price = price;
        }
        public void SetCarDetails(int carId, string brand, string model, string year, double price)
        {
            this.carId = carId;
            this.brand = brand;
            this.model = model;
            this.year = year;
            this.price = price;
            Console.WriteLine("Receiving Car Information");
        }
        public void DisplayCarDetails()
        {
            Console.WriteLine("Presenting Car Information");
            Console.WriteLine("CarId : " + carId);
            Console.WriteLine("Brand : " + brand);
            Console.WriteLine("Model : " + model);
            Console.WriteLine("Year : " + year);
            Console.WriteLine("Price : " + price);
        }
    }
}
