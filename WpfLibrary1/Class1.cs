using System.Data;
using System.Windows;

namespace ParaChisel
{
    /// <summary>
    /// ����� �������������� ���� �����
    /// </summary>
    public class Pair
    {
        // ������ ����� ����
        public int Firstnumber { get; set; }

        // ������ ����� ����
        public int Secondnumber { get; set; }


        /// <summary>
        /// ����������� ��� ������������� ����
        /// </summary>
        /// <param name="firstnumber">������ ����� ����</param>
        /// <param name="secondnumber">������ ����� ����</param>
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
        /// ����� ��� �������� ����� ����
        /// </summary>
        /// <param name="rez">����� �����</param>
        public void Sum(out int rez)
        {
            rez = Firstnumber += Secondnumber;
        }

        /// <summary>
        /// ����� ��� �������� ���� ���
        /// </summary>
        /// <param name="value">������ ����</param>
        public void Sum(Pair value)
        {
            if (value != null)
            {
                Firstnumber += value.Firstnumber;
                Secondnumber += value.Secondnumber;
            }
        }


        /// <summary>
        /// ����� ��� ���������� ����� ���� �� 1
        /// </summary>
        public void Increase()
        {
            Firstnumber += 1;
            Secondnumber += 1;
        }

        /// <summary>
        /// ����� ��� �������� ���� ��� 
        /// </summary>
        /// <param name="value">������ ����</param>
        /// <param name="other">������ ����</param>
        public void Sum(Pair value, Pair other)
        {
            if (value != null && other != null)
            {
                Secondnumber += value.Secondnumber += other.Secondnumber;
                Firstnumber += value.Firstnumber += other.Firstnumber;
            }
        }

        /// <summary>
        /// ��������������� ������ ToString ��� �������� ����������� ����
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({Firstnumber}, {Secondnumber})";
        }

        /// <summary>
        /// ������������� �������� --
        /// </summary>
        /// <param name="a">������� ����</param>
        /// <returns>���� -1</returns>
        public static Pair operator --(Pair a)
        {
            return new Pair() { Firstnumber = a.Firstnumber - 1, Secondnumber = a.Secondnumber - 1 };
        }

        /// <summary>
        /// ������������� �������� +
        /// </summary>
        /// <param name="a">���� 1</param>
        /// <param name="b">���� 2</param>
        /// <returns>����� ���� ���</returns>
        public static Pair operator +(Pair a, Pair b)
        {
            return new Pair() { Firstnumber = a.Firstnumber + b.Firstnumber, Secondnumber = a.Secondnumber + b.Secondnumber };
        }
    }

    public class Money : Pair
    {
        /// <summary>
        /// ����������� ��� ������������� �������� �����
        /// </summary>
        /// <param name="firstnumber">�����</param>
        /// <param name="secondnumber">�������</param>
        public Money(int firstnumber, int secondnumber) : base(firstnumber, secondnumber)
        {
            Firstnumber = firstnumber + secondnumber/100;
            Secondnumber = secondnumber%100;
        }


        /// <summary>
        /// ������������� �������� +
        /// </summary>
        /// <param name="m1">�������� ����� 1</param>
        /// <param name="m2">�������� ����� 2</param>
        /// <returns>����� ���� �������� ����</returns>
        public static Money operator +(Money m1, Money m2)
        {
            int totalKopecks = (m1.Firstnumber * 100 + m1.Secondnumber) + (m2.Firstnumber * 100 + m2.Secondnumber);
            return new Money(totalKopecks / 100, totalKopecks % 100);
        }

        /// <summary>
        /// ������������� �������� ++
        /// </summary>
        /// <param name="m">�������� �����</param>
        /// <returns>����������� �������� ����� �� 1���. � 1���.</returns>
        public static Money operator ++ (Money m)
        {
            int totalKopecks = (m.Firstnumber * 100) + m.Secondnumber ;
            return new Money(totalKopecks / 100+1, totalKopecks % 100+1);
        }

        /// <summary>
        /// ������������� �������� -
        /// </summary>
        /// <param name="m1">������ �������� �����</param>
        /// <param name="m2">������ �������� �����</param>
        /// <returns>������� �������� ����</returns>
        public static Money operator -(Money m1, Money m2)
        {
            int totalKopecks = (m1.Firstnumber * 100 + m1.Secondnumber) - (m2.Firstnumber * 100 + m2.Secondnumber);
            return new Money(totalKopecks / 100, totalKopecks % 100);
        }

        /// <summary>
        /// ����� ������� �������� ����� �� �����
        /// </summary>
        /// <param name="divisor">��������</param>
        /// <returns>����������� �������� �����</returns>
        /// <exception cref="ArgumentException">����������</exception>
        public Money Division(int divisor)
        {
            if (divisor <= 0)
                throw new ArgumentException("�������� ������ ���� �������������.");

            // ����� ���������� ������
            int totalKopecks = Firstnumber * 100 + Secondnumber;

            // ����� �� ��������
            int dividedKopecks = totalKopecks / divisor;

            // �������� ����� � �������
            Firstnumber = (int)(dividedKopecks / 100);
            Secondnumber = (int)(dividedKopecks % 100);

            return new Money(Firstnumber, Secondnumber);
        }

        /// <summary>
        /// ��������������� ����� ToString()
        /// </summary>
        /// <returns>���. ���.</returns>
        public override string ToString()
        {
            return $"{Firstnumber} ���. {Secondnumber} ���.";
        }
    }
}
