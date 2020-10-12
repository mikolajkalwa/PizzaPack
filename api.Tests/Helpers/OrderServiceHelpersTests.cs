using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;
using api.Services;
using NSubstitute;
using NUnit.Framework;

namespace api.Tests.Helpers
{
    public class OrderServiceHelpersTests
    {
        private IMenuService _menuService;
        [SetUp]
        public void SetUp()
        {
            _menuService = Substitute.For<IMenuService>();
            _menuService.GetMenu().Returns(new Menu()
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
        public async Task GetDishById_WhenCalledWithEmptyString_ThrowsArgumentException()
        {
            var helper = new OrdersServiceHelpers(_menuService);

            try
            {
                await helper.GetDishById(string.Empty);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public async Task GetDishById_WhenCalledWithNonExistingDishId_ThrowsArgumentException()
        {
            var helper = new OrdersServiceHelpers(_menuService);

            try
            {
                await helper.GetDishById("qwerty");

                Assert.Fail();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public async Task GetExtrasById_WhenCalledWithEmptyString_ThrowsArgumentException()
        {
            var helper = new OrdersServiceHelpers(_menuService);

            try
            {
                await helper.GetExtrasById(string.Empty);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public async Task GetExtrasById_WhenCalledWithNonExistingExtrasId_ThrowsArgumentException()
        {
            var helper = new OrdersServiceHelpers(_menuService);

            try
            {
                await helper.GetExtrasById("qwerty");

                Assert.Fail();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [TestCase(1, 20)]
        [TestCase(2, 40)]
        [TestCase(1337, 26740)]
        public async Task CalculateOrderValue_WhenOrderedDishWithoutExtras_ReturnsCorrectPrice(int quantity, decimal totalPrice)
        {
            var helper = new OrdersServiceHelpers(_menuService);

            var result = await helper.CalculateOrderValue(new List<DishOrder>
            {
                new DishOrder()
                {
                    DishIdentifier = "5f80c7de5508d7198e6e4821",
                    Quantity = quantity
                }
            });

            Assert.AreEqual(result, totalPrice);
        }

        [TestCase("5f80c7de5508d7198e6e4821", "5f80cbf010115a2c8058a1e1", 3, 66)]
        [TestCase("5f80cb3310115a2c8058a1db", "5f80cbf010115a2c8058a1e5", 1, 32)]
        [TestCase("5f80cb3310115a2c8058a1db", "5f80cbf010115a2c8058a1e6", 1, 33)]
        [TestCase("5f80cb3310115a2c8058a1db", "5f80cbf010115a2c8058a1e5", 4, 128)]
        [TestCase("5f80cb3310115a2c8058a1db", "5f80cbf010115a2c8058a1e6", 10, 330)]
        public async Task CalculateOrderValue_WhenOrderedDishWithExtra_ReturnsCorrectPrice(string dishIdentifier, string extrasId, int dishQuantity, decimal totalPrice)
        {
            var helper = new OrdersServiceHelpers(_menuService);

            var result = await helper.CalculateOrderValue(new List<DishOrder>
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
