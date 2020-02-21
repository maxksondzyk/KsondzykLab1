using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using KsondzykLab1.Annotations;
using KsondzykLab1.Models;
using KsondzykLab1.Tools.MVVM;

namespace KsondzykLab1.ViewModels
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private RelayCommand<object> _startCommand;
        private User _user;
        private bool _filled;
        private string _age;
        private string _easternZodiac;
        private string _westernZodiac;

        public DateTime Birthday
        {
            get
            {
                return _user.Birthday;
            }
            set
            {
                _user.Birthday = value;
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }
        public string EasternZodiac
        {
            get => _easternZodiac;
            set
            {
                _easternZodiac = value;
                OnPropertyChanged();
            }
        }
        public string WesternZodiac
        {
            get => _westernZodiac;
            set
            {
                _westernZodiac = value;
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
                return _startCommand ??= new RelayCommand<object>(o =>
                    {
                       Age = _user.CalculateAge();
                    }
                );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
