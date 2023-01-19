using System;

namespace ConsoleApp7
{
    struct Worker
    {


        #region Конструкторы


        public Worker(int id, DateTime RecordingDate, string Fio, string Age,
            string Growth, DateTime DateOfBirth, string PlaceOfBirth)
        {
            this.id = id;
            this.RecordingDate = RecordingDate;
            this.Fio = Fio;
            this.Age = Age;
            this.Growth = Growth;
            this.DateOfBirth = DateOfBirth;
            this.PlaceOfBirth = PlaceOfBirth;
        }

        #endregion

        #region Методы

        public string Print()
        {
            return $"{this.id}#{this.RecordingDate:dd.MM.yyyy HH:mm}#" +
                   $"{this.Fio}#{this.Age}#{this.Growth}#{this.DateOfBirth:dd.MM.yyyy}#{this.PlaceOfBirth}";
        }
        
        #endregion

        #region Свойства


        /// <summary>
        /// "Айди"
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// "Дата записи"
        /// </summary>
        public DateTime RecordingDate { get; set; }

        /// <summary>
        /// "Фио"
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// "Возраст"
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// "Рост"
        /// </summary>
        public string Growth { get; set; }

        /// <summary>
        /// "Дата рождения"
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// "Место роджения"
        /// </summary>
        public string PlaceOfBirth { get; set; }

        #endregion


    }
}
