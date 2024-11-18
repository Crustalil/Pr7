using ParaChisel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Пр7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Обьявление денежных сумм
        private Money _money1;
        private Money _money2;

        // Конструктор 
        public MainWindow()
        {
            InitializeComponent();
            _money1 = new Money(50, 50);
            _money2 = new Money(50, 50);
            InitializeTextBoxes();
        }

        // Метод инициализвции TextBox-ов
        private void InitializeTextBoxes()
        {
            Para1First.Text = _money1.Firstnumber.ToString();
            Para1Second.Text = _money2.Secondnumber.ToString();

            Para2First.Text = _money2.Firstnumber.ToString();
            Para2Second.Text = _money2.Secondnumber.ToString();
        }

        // Кнопка выхода
        private void btnExit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Кнопка информации
        private void btnInfo_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчи: КузнецовМ.Н. ИСП-31 2 Вариант  \nИспользовать класс Pair (пара чисел). Определить класс-наследник Money с характеристиками: рубли и копейки. Переопределить операцию сложения и определить методы вычитания и деления денежных сумм. ");
        }

        // Метод обновления денежных сумм
        private bool UpdatePair()
        {
            bool isValid = true;

            isValid &= int.TryParse(Para1First.Text, out int para1First);
            isValid &= int.TryParse(Para1Second.Text, out int para1Second);

            isValid &= int.TryParse(Para2First.Text, out int para2First);
            isValid &= int.TryParse(Para2Second.Text, out int para2Second);

            if (!isValid)
            {
                MessageBox.Show("Введите корректные числа для трех пар.", "Ошибка ввода");
                return false;
            }

            _money1.Firstnumber = para1First;
            _money1.Secondnumber = para1Second;

            _money2.Firstnumber = para2First;
            _money2.Secondnumber = para2Second;

            return true;
        }

        // Метод обновления денежной суммы1
        private bool UpdatePair1()
        {
            bool isValid = true;

            isValid &= int.TryParse(Para1First.Text, out int para1First);
            isValid &= int.TryParse(Para1Second.Text, out int para1Second);

            if (!isValid)
            {
                MessageBox.Show("Введите корректные числа для пары.", "Ошибка ввода");
                return false;
            }

            _money1.Firstnumber = para1First;
            _money1.Secondnumber = para1Second;

            return true;
        }

        // Метод обновления TextBoxov 1 денежной суммы
        private void UpdateTextBoxesForPair1()
        {
            Para1First.Text = _money1.Firstnumber.ToString();
            Para1Second.Text = _money1.Secondnumber.ToString();
        }

        // Метод обновления TextBoxov 
        private void UpdateTextBoxesForPair()
        {
            Para1First.Text = _money1.Firstnumber.ToString();
            Para1Second.Text = _money1.Secondnumber.ToString();

            Para2First.Text = _money2.Firstnumber.ToString();
            Para2Second.Text = _money2.Secondnumber.ToString();

           
        }


        // Кнопка сложения двух денежных сумм
        private void btnSum2pair_Click(object sender, RoutedEventArgs e)
        {
            if (UpdatePair() )
            {
                tbRez.Text = Convert.ToString(_money1 + _money2);
            }
            UpdateTextBoxesForPair1();
        }

        // Кнопка увеличения полей на 1
        private void btnPolIncrease1_Click(object sender, RoutedEventArgs e)
        {
            if (UpdatePair())
            {
                _money1++;
                
                _money2++;

            }
            UpdateTextBoxesForPair();
        }

        // Вычитание денежных сумм
        private void btnPolDecrease1_Click(object sender, RoutedEventArgs e)
        {
            if (UpdatePair())
            {
                tbRez.Text = Convert.ToString(_money1 - _money2);
            }   
        }

        // Деление первой денежной суммы на число
        private void btnPolDivision_Click(object sender, RoutedEventArgs e)
        { 
            bool f = int.TryParse(tbDivider.Text, out int divider) ;
            if (UpdatePair1() &&f)
            {
                try
                {
                    
                    tbRez.Text = Convert.ToString(_money1.Division(divider));
                    UpdateTextBoxesForPair1();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else { MessageBox.Show("Введите число"); }; 
        }
    }
}