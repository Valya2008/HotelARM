using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PPR; // ОЧЕНЬ ВАЖНО, чтобы здесь было PPR, а не HotelARM

namespace HotelARM.Tests
{
    [TestClass]
    public class BookingTests
    {
        [TestMethod]
        public void Test_CalculateTotalCost_CorrectStay()
        {
            // Настройка (Arrange) - подготовка данных
            var logic = new HotelLogic();
            decimal price = 2000;
            DateTime start = new DateTime(2026, 03, 01);
            DateTime end = new DateTime(2026, 03, 04); // 3 ночи (с 1 по 2, со 2 по 3, с 3 по 4)

            // Действие (Act) - вызов тестируемого метода
            decimal result = logic.CalculateTotalCost(price, start, end);

            // Проверка (Assert) - сравнение ожидаемого и фактического результата
            Assert.AreEqual(6000, result); // Ожидаем 2000 * 3 = 6000
        }

        [TestMethod]
        public void Test_Status_ErrorWhenDatesInvalid()
        {
            // Настройка
            var logic = new HotelLogic();
            DateTime start = new DateTime(2026, 03, 10);
            DateTime end = new DateTime(2026, 03, 05); // Ошибка: выезд раньше заезда

            // Действие
            string status = logic.GetBookingStatus(start, end);

            // Проверка
            Assert.AreEqual("Ошибка: Дата выезда раньше заезда", status);
        }

        [TestMethod]
        public void Test_Status_OneDayStay()
        {
            // Настройка
            var logic = new HotelLogic();
            DateTime start = new DateTime(2026, 03, 15);
            DateTime end = new DateTime(2026, 03, 15); // Заезд и выезд в один день

            // Действие
            string status = logic.GetBookingStatus(start, end);

            // Проверка
            Assert.AreEqual("Внимание: Заезд на один день", status);
        }
    }
}