using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AbiturientApp
{
    /// <summary>
    /// Класс для управления базой данных абитуриентов
    /// </summary>
    public class DatabaseManager
    {
        private string filePath;

        /// <summary>
        /// Конструктор с указанием пути к файлу
        /// </summary>
        public DatabaseManager(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Загрузка всех записей из файла
        /// </summary>
        public List<Abiturient> LoadData()
        {
            List<Abiturient> list = new List<Abiturient>();

            if (!File.Exists(filePath))
            {
                // Если файл не существует, создаём пустой
                return list;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        try
                        {
                            Abiturient a = Abiturient.ParseFromString(line);
                            list.Add(a);
                        }
                        catch (FormatException)
                        {
                            // Пропускаем некорректные строки
                            continue;
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Сохранение всех записей в файл
        /// </summary>
        public void SaveData(List<Abiturient> list)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Abiturient a in list)
                {
                    writer.WriteLine(a.ToString());
                }
            }
        }

        /// <summary>
        /// Добавление записи
        /// </summary>
        public void AddRecord(List<Abiturient> list, Abiturient record)
        {
            list.Add(record);
            SaveData(list);
        }

        /// <summary>
        /// Обновление записи по индексу
        /// </summary>
        public void UpdateRecord(List<Abiturient> list, int index, Abiturient record)
        {
            if (index >= 0 && index < list.Count)
            {
                list[index] = record;
                SaveData(list);
            }
        }

        /// <summary>
        /// Удаление записи по индексу
        /// </summary>
        public void DeleteRecord(List<Abiturient> list, int index)
        {
            if (index >= 0 && index < list.Count)
            {
                list.RemoveAt(index);
                SaveData(list);
            }
        }

        /// <summary>
        /// Поиск записей по значению поля
        /// </summary>
        public List<Abiturient> Search(List<Abiturient> list, string fieldName, string searchValue)
        {
            List<Abiturient> results = new List<Abiturient>();

            foreach (Abiturient a in list)
            {
                bool match = false;

                switch (fieldName.ToLower())
                {
                    case "фио":
                        match = a.FullName.ToLower().Contains(searchValue.ToLower());
                        break;
                    case "год рождения":
                        if (int.TryParse(searchValue, out int year))
                            match = a.BirthYear == year;
                        break;
                    case "школа":
                        if (int.TryParse(searchValue, out int school))
                            match = a.SchoolNumber == school;
                        break;
                    case "средний балл":
                        if (double.TryParse(searchValue, out double score))
                            match = Math.Abs(a.AverageScore - score) < 0.001;
                        break;
                }

                if (match)
                    results.Add(a);
            }

            return results;
        }

        /// <summary>
        /// Поиск школы с максимальным количеством абитуриентов со средним баллом > 4
        /// </summary>
        public List<int> FindBestSchool(List<Abiturient> list)
        {
            // Словарь для подсчёта количества абитуриентов с баллом > 4 по школам
            Dictionary<int, int> schoolCount = new Dictionary<int, int>();

            foreach (Abiturient a in list)
            {
                if (a.AverageScore > 4)
                {
                    if (schoolCount.ContainsKey(a.SchoolNumber))
                        schoolCount[a.SchoolNumber]++;
                    else
                        schoolCount[a.SchoolNumber] = 1;
                }
            }

            // Если нет абитуриентов с баллом > 4
            if (schoolCount.Count == 0)
                return new List<int>();

            // Находим максимальное количество
            int maxCount = schoolCount.Values.Max();

            // Собираем все школы с максимальным количеством
            List<int> bestSchools = new List<int>();
            foreach (var kvp in schoolCount)
            {
                if (kvp.Value == maxCount)
                    bestSchools.Add(kvp.Key);
            }

            return bestSchools;
        }
    }
}