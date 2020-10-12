using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Xml.Linq;
using FluentValidation;
using gui.ApiClient;
using gui.ApiClient.Models;
using NSubstitute;
using NUnit.Framework;

namespace gui.Tests
{
    [TestFixture]
    public class OrderHelpersTests
    {
        private IPizzeriaApiClient _apiClient;

        [SetUp]
        public void SetUp()
        {
            _apiClient = Substitute.For<IPizzeriaApiClient>();
            _apiClient.GetMenu().Returns(new Menu()
            {
                Extras = new List<Extras>
                {
                    new Extras() {
                        ExtrasIdentifier = "5f80cbf010115a2c8058a1e1",
                        ExtrasName =  "Podwójny ser",
                        ExtrasPrice = 2,
                        DishCategory =  "Pizza"
                    },
                    new Extras() {
                        ExtrasIdentifier = "5f80cbf010115a2c8058a1e2",
                        ExtrasName =  "Salami",
                        ExtrasPrice = 2,
                        DishCategory =  "Pizza"
                    },
                    new Extras() {
                        ExtrasIdentifier = "5f80cbf010115a2c8058a1e3",
                        ExtrasName =  "Szynka",
                        ExtrasPrice = 2,
                        DishCategory =  "Pizza"
                    },
                    new Extras() {
                        ExtrasIdentifier = "5f80cbf010115a2c8058a1e4",
                        ExtrasName =  "Pieczarki",
                        ExtrasPrice = 2,
                        DishCategory =  "Pizza"
                    },
                    new Extras() {
                        ExtrasIdentifier = "5f80cbf010115a2c8058a1e5",
                        ExtrasName =  "Bar sałatkowy",
                        ExtrasPrice = 5,
                        DishCategory =  "MainCourse"
                    },
                    new Extras() {
                        ExtrasIdentifier = "5f80cbf010115a2c8058a1e6",
                        ExtrasName =  "Zestaw sosów",
                        ExtrasPrice = 6,
                        DishCategory =  "MainCourse"
                    }
                },

                Dishes = new List<Dish>
                {
                    new Dish()
                    {
                        DishIdentifier = "5f80c7de5508d7198e6e4821",
                        DishName = "Margheritta",
                        DishPrice =  20,
                        DishCategory = "Pizza"
                    },
                    new Dish()
                    {
                        DishIdentifier = "5f80c8035508d7198e6e4822",
                        DishName = "Vegetariana",
                        DishPrice =  22,
                        DishCategory = "Pizza"
                    },
                    new Dish()
                    {
                        DishIdentifier = "5f80ca6c10115a2c8058a1d5",
                        DishName = "Tosca",
                        DishPrice =  25,
                        DishCategory = "Pizza"
                    },
                    new Dish()
                    {
                        DishIdentifier = "5f80ca6c10115a2c8058a1d6",
                        DishName = "Venecia",
                        DishPrice =  25,
                        DishCategory = "Pizza"
                    },
                    new Dish()
                    {
                        DishIdentifier = "5f80cb3310115a2c8058a1d7",
                        DishName = "Schabowy z frytkami",
                        DishPrice =  30,
                        DishCategory = "MainCourse"
                    },
                    new Dish()
                    {
                        DishIdentifier = "5f80cb3310115a2c8058a1d8",
                        DishName = "Schabowy z ryżem",
                        DishPrice =  30,
                        DishCategory = "MainCourse"
                    },
                    new Dish()
                    {
                        DishIdentifier = "5f80cb3310115a2c8058a1d9",
                        DishName = "Schabowy z ziemniakami",
                        DishPrice =  30,
                        DishCategory = "MainCourse"
                    },
                    new Dish()
                    {
                        DishIdentifier = "5f80cb3310115a2c8058a1da",
                        DishName = "Ryba z frytkami",
                        DishPrice =  28,
                        DishCategory = "MainCourse"
                    },
                    new Dish()
                    {
                        DishIdentifier = "5f80cb3310115a2c8058a1db",
                        DishName = "Placek po węgiersku",
                        DishPrice =  27,
                        DishCategory = "MainCourse"
                    },
                    new Dish()
                    {
                        DishIdentifier = "5f80cb3310115a2c8058a1dc",
                        DishName = "Pomidorowa",
                        DishPrice =  12,
                        DishCategory = "Soup"
                    },
                    new Dish()
                    {
                        DishIdentifier = "5f80cb3310115a2c8058a1dd",
                        DishName = "Rosół",
                        DishPrice =  10,
                        DishCategory = "Soup"
                    },
                    new Dish()
                    {
                        DishIdentifier = "5f80cb3310115a2c8058a1de",
                        DishName = "Kawa",
                        DishPrice =  5,
                        DishCategory = "Drink"
                    },
                    new Dish()
                    {
                        DishIdentifier = "5f80cb3310115a2c8058a1df",
                        DishName = "Cola",
                        DishPrice =  5,
                        DishCategory = "Drink"
                    },
                    new Dish()
                    {
                        DishIdentifier = "5f80cb3310115a2c8058a1e0",
                        DishName = "Herbata",
                        DishPrice =  5,
                        DishCategory = "Drink"
                    }
                }
            });
        }

        [Test]
        public void GetAvailableExtrasForCategory_WhenCalledWithEmptyString_ReturnsEmptyList()
        {
            var helper = new OrderHelpers(_apiClient);

            var availableExtras = helper.GetAvailableExtrasForCategory(string.Empty);

            Assert.IsEmpty(availableExtras);
        }

        [Test]
        public void GetAvailableExtrasForCategory_WhenCalledWithNonExistingCategory_ReturnsEmptyList()
        {
            var helper = new OrderHelpers(_apiClient);

            var availableExtras = helper.GetAvailableExtrasForCategory("dessert");

            Assert.IsEmpty(availableExtras);
        }

        [Test]
        public void GetAvailableExtrasForCategory_WhenPizzaExtrasRequested_ReturnsListWith4Elements()
        {
            var helper = new OrderHelpers(_apiClient);

            var availableExtras = helper.GetAvailableExtrasForCategory("Pizza");

            Assert.That(availableExtras.Count(), Is.EqualTo(4));
        }

        [Test]
        public void GetAvailableExtrasForCategory_WhenPizzaExtrasRequested_ReturnedListContainsOnlyPizzaExtras()
        {
            var helper = new OrderHelpers(_apiClient);

            var availableExtras = helper.GetAvailableExtrasForCategory("Pizza");

            foreach (var availableExtra in availableExtras)
            {
                if (availableExtra.DishCategory != "Pizza")
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }

        [Test]
        public void CalculateOrderValue_WhenCalledWithNull_ThrowsAnException()
        {
            var helper = new OrderHelpers(_apiClient);

            try
            {
                helper.CalculateOrderValue(null);
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void CalculateOrderValue_WhenCalledWithEmptyList_ReturnsZero()
        {
            var helper = new OrderHelpers(_apiClient);

            var result = helper.CalculateOrderValue(new List<DishOrder>());

            Assert.AreEqual(0, result);
        }


        [TestCase(1, 20)]
        [TestCase(2, 40)]
        [TestCase(1337, 26740)]
        public void CalculateOrderValue_WhenOrderedDishWithoutExtras_ReturnsCorrectPrice(int quantity, decimal totalPrice)
        {
            var helper = new OrderHelpers(_apiClient);

            var result = helper.CalculateOrderValue(new List<DishOrder>
            {
                new DishOrder()
                {
                    DishIdentifier = "5f80c7de5508d7198e6e4821",
                    Quantity = quantity
                }
            });

            Assert.AreEqual(result, totalPrice);
        }

        [TestCase("5f80c7de5508d7198e6e4821", "5f80cbf010115a2c8058a1e1", 3, 66 )]
        [TestCase("5f80cb3310115a2c8058a1db", "5f80cbf010115a2c8058a1e5", 1, 32)]
        [TestCase("5f80cb3310115a2c8058a1db", "5f80cbf010115a2c8058a1e6", 1, 33)]
        [TestCase("5f80cb3310115a2c8058a1db", "5f80cbf010115a2c8058a1e5", 4, 128)]
        [TestCase("5f80cb3310115a2c8058a1db", "5f80cbf010115a2c8058a1e6", 10, 330)]
        public void CalculateOrderValue_WhenOrderedDishWithExtra_ReturnsCorrectPrice(string dishIdentifier, string extrasId, int dishQuantity, decimal totalPrice)
        {
            var helper = new OrderHelpers(_apiClient);

            var result = helper.CalculateOrderValue(new List<DishOrder>
            {
                new DishOrder()
                {
                    DishIdentifier = dishIdentifier,
                    Quantity = dishQuantity,
                    Extras = new List<string> {extrasId}
                }
            });

            Assert.AreEqual(totalPrice, result);
        }

    }
}
