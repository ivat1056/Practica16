using Practica16.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Practica16.VieweModels
{

    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; // событие. которое реагирует на изменение свойст
        // класс, который реализазует интерфейс ICommand
        public RoutedCommand Command { get; set; } = new RoutedCommand();

        public CommandBinding bind; // создание объекта для привязки команды
        public string FirstT // cвойство для заполнение первого поля
        {
            set
            {
                Model.first = value;
            }
        }
        public string SecondT // cвойство для заполнение второго поля
        {
            set
            {
                Model.second = value;
            }
        }

        public string ResultT // cвойство для отображения результата вычисления в TextBlock
        {
            get
            {
                return Model.result.ToString();
            }
        }
         int cbIndex = -1;
        public int IndexSelected // cвойство для нахождения индекса выбранного в Combobox элемента
        {
            set
            {
                Model.indexComboBox = value;
                cbIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CBIndex"));
            }
        }
        public List<String> ComboChange  // cвойство для заполнения Combobox
        {
            get
            {
                return Model.dataList;
            }
        }

        public ViewModel()
        {
            bind = new CommandBinding(Command);  // инициализация объекта для привязки данных
            bind.Executed += Command_Executed;  // добавление обработчика событий
        }
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            double numberFirst  = Convert.ToDouble(Model.first); ; 
            double numberSecondly = Convert.ToDouble(Model.second); 
            switch (Model.indexComboBox)
            {
                case -1:
                    MessageBox.Show("Выберите арифметическое действие");
                    return;
                case 0:
                    Model.result = Convert.ToString(numberFirst + numberSecondly);
                    break;
                case 1:
                    Model.result = Convert.ToString(numberFirst - numberSecondly);
                    break;
                case 2:
                    Model.result = Convert.ToString(numberFirst * numberSecondly);
                    break;
                case 3:
                    if (numberSecondly == 0)
                    {
                        Model.result = "Делить на ноль нельзя";
                    }
                    else
                    {
                        Model.result = Convert.ToString(numberFirst / numberSecondly);
                    }
                    break;
                default:
                    MessageBox.Show("Возникла ошибка");
                    return;
            }
            PropertyChanged(this, new PropertyChangedEventArgs("ResultT"));
        }
    }
}

