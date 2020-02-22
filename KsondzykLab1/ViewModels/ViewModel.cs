using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using KsondzykLab1.Annotations;
using KsondzykLab1.Models;
using KsondzykLab1.Tools.MVVM;

namespace KsondzykLab1.ViewModels
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private RelayCommand<object> _startCommand;
        private User _user = new User();
        private bool _filled = false;

        public DateTime? Birthday
        {
            get => _user.Birthday;
            set
            {
                _user.Birthday = value;
                if (value != null)
                    _filled = true;
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get => _user.Age;
            set
            {
                _user.Age = value;
                OnPropertyChanged();
            }
        }
        public string EasternZodiac
        {
            get => _user.EasternZodiac;
            set
            {
                _user.EasternZodiac = value;
                OnPropertyChanged();
            }
        }
        public string WesternZodiac
        {
            get => _user.WesternZodiac;
            set
            {
                _user.WesternZodiac = value;
                OnPropertyChanged();
            }
        }

        private bool CanExecute()
        {
            return _filled;
        }


        public RelayCommand<object> StartCommand
        {
            get
            {
                return _startCommand ??= new RelayCommand<object>(Calculate, o => CanExecute());
            }

        }

        private async void Calculate(object obj)
        {
            Age = "";
            WesternZodiac = "";
            EasternZodiac = "";
            await Task.Run(() =>
            {
                 Thread.Sleep(700);
                // var user = new User();
                if (_user.CalculateAge().Equals("n"))
                {
                    MessageBox.Show("Incorrect date!");
                    Age = "";
                    WesternZodiac = "";
                    EasternZodiac = "";
                }

                else
                {
                    Age = $"Your age: {_user.Age}";

                    WesternZodiac = $"Your western zodiac: {_user.CalculateWesternZodiac()}";
                    EasternZodiac = $"Your eastern zodiac: {_user.CalculateEasternZodiac()}";
                    Thread.Sleep(500);

                    if (_user.Birthday.Value.DayOfYear.Equals(DateTime.Today.DayOfYear))
                    {
                        MessageBox.Show("Happy Birthday!");
                    }

                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
