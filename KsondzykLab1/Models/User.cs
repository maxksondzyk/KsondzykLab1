using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace KsondzykLab1.Models
{
    internal class User
    {
        private string _age { get; set; }
        private DateTime _birthday { get; }
        private string _easternZodiac { get; set; }
        private string _westernZodiac { get; set; }

        public User(DateTime birthday)
        {
            _birthday = birthday;
        }

        public string CalculateAge()
        {
            var leapYears = (DateTime.Now.Year - this._birthday.Year) / 4;
            var leapDays = leapYears * 366;
            var timeSpan = (DateTime.Today - _birthday.Date);
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

            this._age = years.ToString();
            return years.ToString();
        }
        public string CalculateEasternZodiac()
        {
            var result = (_birthday.Year % 12) switch
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
            var day = _birthday.Day;
            var Result = _birthday.Month switch
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
