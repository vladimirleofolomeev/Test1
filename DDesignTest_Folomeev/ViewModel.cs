using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Diagnostics;

namespace DDesignTest_Folomeev
{
    public class ViewModel : INotifyPropertyChanged
    {

        Model model = new Model(); // Инициализируем класс модели
       
        public ObservableCollection<ColorViewModel> ColorList { get; set; } // Переменная для коллекции цветов

        public Command AppExit { get; set; }                    // Команда Выход
        public Command WindowMaximize { get; set; }             // Развернуть окно
        public Command WindowMinimize { get; set; }             // Свернуть окно 
        public Command buttonTest1 { get; set; }                // Нажатие кнопки в шапке
        public Command buttonTest2 { get; set; }                // Нажатие кнопки в шапке
        public Command deepThreadStartCommand { get; set; }     // Запуск потока в глубине модели

        /// <summary>
        /// Список значений для наполнения контролов
        /// </summary>
        public List<string> itemsList
        {
            get
            {
                var items = new List<string>();
                for (var i = 0; i < 150; ++i)
                {
                    items.Add((i*1000).ToString());
                }
                return items;
            }
        }

        /// <summary>
        /// Переменная информации о потоке
        /// </summary>
        private string _threadStatusString;
        public string threadStatusString
        {
            get { return _threadStatusString; }
            set
            {
                if (value != _threadStatusString)
                {
                    _threadStatusString = value;
                    NotifyPropertyChanged("threadStatusString");
                }                
            }
        }

        /// <summary>
        /// Переменная выбранного цвета
        /// </summary>
        private SolidColorBrush _color;
        public SolidColorBrush SelectedColor
        {
            get { return _color; }
            set
            {
                _color = value;
                NotifyPropertyChanged("SelectedColor");
            }
        }


        public ViewModel()
        {
            //---Наполняем коллекцию цветов---
            ColorList = new ObservableCollection<ColorViewModel>();
            ColorList.Add(new ColorViewModel("По умолчанию", Colors.White));
            ColorList.Add(new ColorViewModel("Красный", Colors.Red));
            ColorList.Add(new ColorViewModel("Синий", Colors.Blue));
            ColorList.Add(new ColorViewModel("Зеленый", Colors.Green));
            SelectedColor = ColorList[0].ColorBrush;
            //---Конец наполнения---

            //Инициализируем команды
            AppExit = new Command(Exit) { IsExecutable = true };
            WindowMaximize = new Command(WinMax) { IsExecutable = true };
            WindowMinimize = new Command(WinMin) { IsExecutable = true };            
            buttonTest1 = new Command(but1_test) { IsExecutable = true };
            buttonTest2 = new Command(but2_test) { IsExecutable = true };
            deepThreadStartCommand = new Command(deepThreadStart) { IsExecutable = true };
            threadStatusString = "Ожидание запуска потока в глубине модели";                        
            
        }

        /// <summary>
        /// Методы нажатия кнопок в шапке
        /// </summary>
        private void but1_test() { MessageBox.Show("Нажата кнопка с молнией"); }
        private void but2_test() { MessageBox.Show("Нажата кнопка с бокалом"); }

        /// <summary>
        /// Метод асинхронного запуска функции в модели
        /// </summary>
        private async void deepThreadStart()
        {
            Stopwatch stopWatch = new Stopwatch(); // Создаем наблюдателя за временем выполнения потока
            stopWatch.Start(); // Запускаем измерение времени выполнения метода
            threadStatusString = "Запущен поток. Ожидается результат...";

            Task deepThread = new Task(model.deepWait);
            deepThread.Start();            
            await deepThread;

            stopWatch.Stop(); // Заканчиваем считать время выполнения
            threadStatusString = "Поток завершен. Время выполнения " + stopWatch.ElapsedMilliseconds + " мСек";
        }
        
        /// <summary>
        /// Выход
        /// </summary>
        private void Exit()
        {
            Application.Current.MainWindow.Close();
        }

        /// <summary>
        /// Развернуть окно
        /// </summary>
        private void WinMax()
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            else
            {Application.Current.MainWindow.WindowState = WindowState.Maximized;}
        }

        /// <summary>
        /// Свернуть окно
        /// </summary>
        private void WinMin() {Application.Current.MainWindow.WindowState = WindowState.Minimized;}



        protected virtual void NotifyPropertyChanged(string propertyName)
        {

            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
