using Lab19WpfApp1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab19WpfApp1.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private double radius;
        public double Radius
        {
            get { return radius; }
            set 
            {
                radius = value;
                OnPropertyChanged();
                
            }
        }
        private double diameter;
        public double Diameter
        {
            get { return diameter; }
            set
            {
                diameter = value;
                OnPropertyChanged();
            }
        }
        private double circumference;
        public double Circumference
        {
            get { return circumference; }
            set
            {
                circumference = value;
                OnPropertyChanged();
                Radius = CircleOperations.GetRadiusFromCircumference(circumference);
            }
        }
        private double area;
        public double Area
        {
            get { return area; }
            set
            {
                area = value;
                OnPropertyChanged();
                Radius = CircleOperations.GetRadiusFromArea(Area);
            }
        }

        public ICommand Refresh {  get; }
        private void OnRefreshExecute(object sender)
        {
            Area = CircleOperations.GetAreaFromRadius(radius);
            Circumference = CircleOperations.GetCircumferenceFromRadius(radius);
            Diameter = CircleOperations.GetDiameterFromRadius(radius);
        }

        private bool OnRefreshCanExecuted(object sender)
        {
            if (radius > 0)
                return true;
            else return false;
        }

        public MainWindowViewModel()
        {
            Refresh = new RelayCommand(OnRefreshExecute, OnRefreshCanExecuted);
        }

    }
}
