using System;

namespace PPR // ОЧЕНЬ ВАЖНО, чтобы здесь было PPR
{
    // Этот класс содержит логику, которую мы будем проверять
    public class HotelLogic
    {
        // Метод для расчета общей стоимости проживания
        public decimal CalculateTotalCost(decimal pricePerNight, DateTime checkIn, DateTime checkOut)
        {
            // Проверка на отрицательную цену
            if (pricePerNight < 0) throw new ArgumentException("Цена не может быть отрицательной");

            // Считаем количество ночей
            int nights = (checkOut - checkIn).Days;

            // Если заехали и уехали в один день, или выезд раньше заезда, платим за 1 ночь
            // Это логика для отелей: заезд и выезд в один день = оплата за 1 ночь.
            if (nights <= 0)
            {
                return pricePerNight;
            }

            return pricePerNight * nights;
        }

        // Метод для проверки корректности дат и статуса бронирования
        public string GetBookingStatus(DateTime checkIn, DateTime checkOut)
        {
            if (checkOut < checkIn)
            {
                return "Ошибка: Дата выезда раньше заезда";
            }
            if (checkOut == checkIn)
            {
                return "Внимание: Заезд на один день";
            }
            return "Бронирование доступно";
        }
    }
}