using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using KsondzykLab1.Annotations;
using KsondzykLab1.Models;
using KsondzykLab1.Tools.MVVM;

namespace KsondzykLab1.ViewModels
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private RelayCommand<object> _dateChosenCommand;
        private User _user;
        private bool _filled;

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


        public RelayCommand<object> DateCommand
        {
            get
            {
                return _dateChosenCommand ??= new RelayCommand<object>(o =>
                    {
                        _user.CalculateAge();
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
