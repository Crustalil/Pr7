using System.Data;
using System.Windows;

namespace ParaChisel
{
    /// <summary>
    /// Класс представляющий пару чисел
    /// </summary>
    public class Pair
    {
        // Первое число пары
        public int Firstnumber { get; set; }

        // Второе число пары
        public int Secondnumber { get; set; }


        /// <summary>
        /// Конструктор для инициализации пары
        /// </summary>
        /// <param name="firstnumber">первое число пары</param>
        /// <param name="secondnumber">второе число пары</param>
        public Pair(int firstnumber, int secondnumber)
        {
            Firstnumber = firstnumber;
            Secondnumber = secondnumber;
        }

        public Pair()
        {
            Firstnumber = 1;
            Secondnumber = 1;
        }
        /// <summary>
        /// Метод для сложения полей пары
        /// </summary>
        /// <param name="rez">Сумма полей</param>
        public void Sum(out int rez)
        {
            rez = Firstnumber += Secondnumber;
        }

        /// <summary>
        /// Метод для слажение двух пар
        /// </summary>
        /// <param name="value">Вторая пара</param>
        public void Sum(Pair value)
        {
            if (value != null)
            {
                Firstnumber += value.Firstnumber;
                Secondnumber += value.Secondnumber;
            }
        }


        /// <summary>
        /// Метод для увеличения полей пары на 1
        /// </summary>
        public void Increase()
        {
            Firstnumber += 1;
            Secondnumber += 1;
        }

        /// <summary>
        /// Метод для сложения трех пар 
        /// </summary>
        /// <param name="value">Вторая пара</param>
        /// <param name="other">Третья пара</param>
        public void Sum(Pair value, Pair other)
        {
            if (value != null && other != null)
            {
                Secondnumber += value.Secondnumber += other.Secondnumber;
                Firstnumber += value.Firstnumber += other.Firstnumber;
            }
        }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения пары
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({Firstnumber}, {Secondnumber})";
        }

        /// <summary>
        /// Перегруженный оператор --
        /// </summary>
        /// <param name="a">Входная пара</param>
        /// <returns>Поля -1</returns>
        public static Pair operator --(Pair a)
        {
            return new Pair() { Firstnumber = a.Firstnumber - 1, Secondnumber = a.Secondnumber - 1 };
        }

        /// <summary>
        /// Перегруженный оператор +
        /// </summary>
        /// <param name="a">Пара 1</param>
        /// <param name="b">Пара 2</param>
        /// <returns>Сумма двух пар</returns>
        public static Pair operator +(Pair a, Pair b)
        {
            return new Pair() { Firstnumber = a.Firstnumber + b.Firstnumber, Secondnumber = a.Secondnumber + b.Secondnumber };
        }
    }

    public class Money : Pair
    {
        /// <summary>
        /// Конструктор для инийиализации денежной суммы
        /// </summary>
        /// <param name="firstnumber">Рубли</param>
        /// <param name="secondnumber">Копейки</param>
        public Money(int firstnumber, int secondnumber) : base(firstnumber, secondnumber)
        {
            Firstnumber = firstnumber + secondnumber/100;
            Secondnumber = secondnumber%100;
        }


        /// <summary>
        /// Перегруженный оператор +
        /// </summary>
        /// <param name="m1">Денежная сумма 1</param>
        /// <param name="m2">Денежная сумма 2</param>
        /// <returns>Сумма двух денежных сумм</returns>
        public static Money operator +(Money m1, Money m2)
        {
            int totalKopecks = (m1.Firstnumber * 100 + m1.Secondnumber) + (m2.Firstnumber * 100 + m2.Secondnumber);
            return new Money(totalKopecks / 100, totalKopecks % 100);
        }

        /// <summary>
        /// Перегруженный оператор ++
        /// </summary>
        /// <param name="m">Денежная сумма</param>
        /// <returns>Увеличенная денежная сумма на 1руб. и 1коп.</returns>
        public static Money operator ++ (Money m)
        {
            int totalKopecks = (m.Firstnumber * 100) + m.Secondnumber ;
            return new Money(totalKopecks / 100+1, totalKopecks % 100+1);
        }

        /// <summary>
        /// Перегруженный оператор -
        /// </summary>
        /// <param name="m1">Первая денежная сумма</param>
        /// <param name="m2">Вторая денежная сумма</param>
        /// <returns>Разница денежных сумм</returns>
        public static Money operator -(Money m1, Money m2)
        {
            int totalKopecks = (m1.Firstnumber * 100 + m1.Secondnumber) - (m2.Firstnumber * 100 + m2.Secondnumber);
            return new Money(totalKopecks / 100, totalKopecks % 100);
        }

        /// <summary>
        /// Метод деления денежной суммы на число
        /// </summary>
        /// <param name="divisor">Делитель</param>
        /// <returns>Разделенная денежная сумма</returns>
        /// <exception cref="ArgumentException">Исключение</exception>
        public Money Division(int divisor)
        {
            if (divisor <= 0)
                throw new ArgumentException("Делитель должен быть положительным.");

            // Общее количество копеек
            int totalKopecks = Firstnumber * 100 + Secondnumber;

            // Делим на делитель
            int dividedKopecks = totalKopecks / divisor;

            // Получаем рубли и копейки
            Firstnumber = (int)(dividedKopecks / 100);
            Secondnumber = (int)(dividedKopecks % 100);

            return new Money(Firstnumber, Secondnumber);
        }

        /// <summary>
        /// Переопределнный метод ToString()
        /// </summary>
        /// <returns>руб. коп.</returns>
        public override string ToString()
        {
            return $"{Firstnumber} руб. {Secondnumber} коп.";
        }
    }
}
