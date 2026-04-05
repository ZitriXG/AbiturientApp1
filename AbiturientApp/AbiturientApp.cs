using System;

namespace AbiturientApp
{
    /// <summary>
    /// Класс, представляющий данные об абитуриенте
    /// </summary>
    public class Abiturient
    {
        // Поля класса
        private string fullName;
        private int birthYear;
        private int schoolNumber;
        private double averageScore;

        // Свойства для доступа к полям
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public int BirthYear
        {
            get { return birthYear; }
            set { birthYear = value; }
        }

        public int SchoolNumber
        {
            get { return schoolNumber; }
            set { schoolNumber = value; }
        }

        public double AverageScore
        {
            get { return averageScore; }
            set { averageScore = value; }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Abiturient()
        {
            fullName = "";
            birthYear = 0;
            schoolNumber = 0;
            averageScore = 0;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public Abiturient(string fullName, int birthYear, int schoolNumber, double averageScore)
        {
            this.fullName = fullName;
            this.birthYear = birthYear;
            this.schoolNumber = schoolNumber;
            this.averageScore = averageScore;
        }

        /// <summary>
        /// Создание объекта из строки файла
        /// Формат строки: ФИО;Год рождения;Школа;Средний балл
        /// </summary>
        public static Abiturient ParseFromString(string line)
        {
            string[] parts = line.Split(';');
            if (parts.Length != 4)
                throw new FormatException("Некорректный формат строки");

            return new Abiturient(
                parts[0].Trim(),
                int.Parse(parts[1]),
                int.Parse(parts[2]),
                double.Parse(parts[3])
            );
        }

        /// <summary>
        /// Преобразование объекта в строку для сохранения в файл
        /// </summary>
        public override string ToString()
        {
            return $"{fullName};{birthYear};{schoolNumber};{averageScore}";
        }
    }
}