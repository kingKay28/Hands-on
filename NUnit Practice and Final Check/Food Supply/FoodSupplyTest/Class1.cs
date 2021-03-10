using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFoodSupply;
using NUnit.Framework;

namespace FoodSupplyTest
{
    [TestFixture]
    public class Class1
    {
        Program progObj = null;
        FoodDetail food = null;


        [SetUp]
        public void Setup()
        {
            progObj = new Program();
            food = progObj.CreateFoodDetail("food_name1", 2, DateTime.Parse("2/22/2035"), 50);

       
        }

        [Test]
        [TestCase("Sandwich",1,"12/20/2022",50)]
        public void FoodDetailObjCreateTest(string name, int dishType, DateTime expiryDate, double price)
        {
            FoodDetail food = progObj.CreateFoodDetail(name, dishType, expiryDate, price);
            var category = (FoodDetail.Category)dishType;

            Assert.That(food.Name, Is.EqualTo(name));
            Assert.That(food.DishType, Is.EqualTo(category));
            Assert.That(food.ExpiryDate, Is.EqualTo(expiryDate));
            Assert.That(food.Price, Is.EqualTo(price));
        }

        [Test]
        [TestCase(null,2,"2/22/2022",40)]
        public void FoodDetailNameExceptionTest(string name, int dishType, DateTime expiryDate, double price)
        {
            Assert.Throws<Exception>(() => progObj.CreateFoodDetail(name, dishType, expiryDate, price));

            //try
            //{
            //    FoodDetail food = progObj.CreateFoodDetail(name, dishType, expiryDate, price);
            //}
            //catch(Exception ex) 
            //{
            //    Assert.That(ex.Message, Is.EqualTo("Dish name cannot be empty. Please provide valid value"));
            //}
        }

        [Test]
        [TestCase("Fries", 2, "2/22/2022", -40)]
        public void FoodDetailPriceExceptionTest(string name, int dishType, DateTime expiryDate, double price)
        {
            Assert.Throws<Exception>(() => progObj.CreateFoodDetail(name, dishType, expiryDate, price));
        }

        [Test]
        [TestCase("Fries", 2, "2/22/2020", 40)]
        public void FoodDetailDateExceptionTest(string name, int dishType, DateTime expiryDate, double price)
        {
            Assert.Throws<Exception>(() => progObj.CreateFoodDetail(name, dishType, expiryDate, price));
        }

        [Test]
        [TestCase(4,"2/20/2022","sellerAB",70.0)]
        public void SupplyDetailCreateTest(int foodItemCount, DateTime requestDate, string sellerName, double packingCharge)
        {
            SupplyDetail supply = progObj.CreateSupplyDetail(foodItemCount, requestDate, sellerName, packingCharge,this.food);
            Assert.That(supply.Count, Is.EqualTo(foodItemCount));
            Assert.That(supply.RequestDate, Is.EqualTo(requestDate));
            Assert.That(supply.SellerName, Is.EqualTo(sellerName));
            //double total = foodItemCount * food.Price + packingCharge;
            Assert.That(supply.TotalCost, Is.EqualTo(food.Price * foodItemCount + packingCharge));
            Assert.That(supply.FoodItem, Is.EqualTo(food));
        }

        [Test]
        [TestCase(-2,"2/10/2024","sellerAB",80)]
        //[TestCase(2, "2/10/2024", "sellerAB", 80)]
        public void SupplyCountTest(int foodItemCount, DateTime requestDate, string sellerName, double packingCharge)
        {
            Assert.Throws<Exception>(() => progObj.CreateSupplyDetail(foodItemCount, requestDate, sellerName, packingCharge, food));
        }

        [Test]
        [TestCase(2, "2/10/2020", "sellerAB", 80)]
        public void SupplyDateTest(int foodItemCount, DateTime requestDate, string sellerName, double packingCharge)
        {
            Assert.Throws<Exception>(() => progObj.CreateSupplyDetail(foodItemCount, requestDate, sellerName, packingCharge, food));
        }

        [Test]
        [TestCase(2, "2/10/2020", "sellerAB", 80, null)]
        public void SupplyNullFoodTest(int foodItemCount, DateTime requestDate, string sellerName, double packingCharge, FoodDetail food)
        {
            
                SupplyDetail supply = progObj.CreateSupplyDetail(foodItemCount, requestDate, sellerName, packingCharge, food);
                Assert.That(supply, Is.EqualTo(null));
        }
    }
}
