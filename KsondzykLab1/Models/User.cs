using System;


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
                4 => "Rat",
                5 => "Ox",
                6 => "Tiger",
                7 => "Rabbit",
                8 => "Dragon",
                9 => "Snake",
                10 => "Horse",
                11 => "Goat",
                0 => "Monkey",
                1 => "Rooster",
                2 => "Dog",
                3 => "Pig"
            };
            return result;
        }
        public string CalculateWesternZodiac()
        {
            var day = _birthday.Value.Day;
            var result = _birthday.Value.Month switch
            {
                3 => (day >= 21 ? "Pisces" : "Aries"),
                4 => (day <= 20 ? "Aries" : "Taurus"),
                5 => (day <= 21 ? "Taurus" : "Gemini"),
                6 => (day <= 21 ? "Gemini" : "Cancer"),
                7 => (day <= 22 ? "Cancer" : "Leo"),
                8 => (day <= 23 ? "Leo" : "Virgo"),
                9 => (day <= 23 ? "Virgo" : "Libra"),
                10 => (day <= 23 ? "Libra" : "Scorpio"),
                11 => (day <= 22 ? "Scorpio" : "Sagitarius"),
                12 => (day <= 21 ? "Sagitarius" : "Capricorn"),
                1 => (day <= 20 ? "Capricorn" : "Aquarius"),
                2 => (day <= 18 ? "Aquarius" : "Pisces"),
            };
            return result;
        }
      
    }
}
