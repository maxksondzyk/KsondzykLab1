using System;
using System.Windows;

namespace KsondzykLab1.Models
{
    internal class User
    {
        private string _age;
        private DateTime? _birthday;
        private string _easternZodiac;
        private string _westernZodiac;

        public DateTime? Birthday
        {
            get => this._birthday;
            set => this._birthday = value;
        }

        public string Age
        {
            get => this._age;
            set => this._age = value;
        }
        public string EasternZodiac
        {
            get => this._easternZodiac;
            set => this._easternZodiac = value;
        }
        public string WesternZodiac
        {
            get => this._westernZodiac;
            set => this._westernZodiac = value;
        }
        public string CalculateAge()
        {
            var leapYears = (DateTime.Now.Year - this._birthday.Value.Year) / 4;
            var leapDays = leapYears * 366;
            var timeSpan = (DateTime.Today - _birthday.Value.Date);
            var totalDays = timeSpan.Days;
            totalDays -= leapDays;
            var years = leapYears + totalDays / 365;
            //if (DateTime.Today.DayOfYear.Equals(_birthday.DayOfYear))
            //{
            //    MessageBox.Show("З днем народження!");
            //}
            //if (years > 135 || res.Days < 0)
            //{
            //    MessageBox.Show("Некоректна дата!");
            //}
            if (years > 135 || timeSpan.Days < 0)
            {
                return "n";
            }
            this._age = years.ToString();
            return years.ToString();
        }
        public string CalculateEasternZodiac()
        {
            var result = (_birthday.Value.Year % 12) switch
            {
                4 => "Щур",
                5 => "Бик",
                6 => "Тигр",
                7 => "Кролик",
                8 => "Дракон",
                9 => "Змія",
                10 => "Кінь",
                11 => "Вівця",
                0 => "Мавпа",
                1 => "Півень",
                2 => "Собака",
                3 => "Свиня"
            };
            return result;
        }
        public string CalculateWesternZodiac()
        {
            var day = _birthday.Value.Day;
            var Result = _birthday.Value.Month switch
            {
                3 => (day >= 21 ? "Овен" : "Риби"),
                4 => (day <= 20 ? "Овен" : "Телець"),
                5 => (day <= 21 ? "Телець" : "Близнюки"),
                6 => (day <= 21 ? "Близнюки" : "Рак"),
                7 => (day <= 22 ? "Рак" : "Лев"),
                8 => (day <= 23 ? "Лев" : "Діва"),
                9 => (day <= 23 ? "Діва" : "Терези"),
                10 => (day <= 23 ? "Терези" : "Скорпіон"),
                11 => (day <= 22 ? "Скорпіон" : "Стрілець"),
                12 => (day <= 21 ? "Стрілець" : "Козеріг"),
                1 => (day <= 20 ? "Козеріг" : "Водолій"),
                2 => (day <= 18 ? "Водолій" : "Риби"),
            };
            return Result;
        }
      
    }
}
