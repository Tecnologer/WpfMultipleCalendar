using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalendarTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<MyCalendar> MyCalendars { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyCalendars = new ObservableCollection<MyCalendar>();

            for (var i = 1; i < 13; i++)
            {
                MyCalendars.Add(new MyCalendar(i, 2019));
            }
        }

        private void Calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            Calendar calObj = sender as Calendar;

            calObj.DisplayMode = CalendarMode.Month;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MyCalendar:INotifyPropertyChanged
    {
        private int month;
        private int year;
        private DateTime startDate;
        private DateTime endDate;

        public MyCalendar(int month, int year)
        {
            this.month = month;
            this.year = year;
            UpdateDates();
        }

        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                if (month == value) return;
                month = value;
                OnPropertyChanged("Month");
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (year == value) return;
                year = value;
                OnPropertyChanged("Year");
            }
        }


        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public void UpdateDates()
        {
            int lastDay = DateTime.DaysInMonth(year, month);
            StartDate = new DateTime(year, month, 1);
            EndDate = new DateTime(year, month, lastDay);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
