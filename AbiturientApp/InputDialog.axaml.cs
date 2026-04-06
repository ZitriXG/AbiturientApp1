using System;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AbiturientApp;

public partial class InputDialog : Window
{
    private const double MinAverageScore = 0;
    private const double MaxAverageScore = 5;

    public InputDialog()
    {
        InitializeComponent();
    }

    public InputDialog(Abiturient existing) : this()
    {
        ArgumentNullException.ThrowIfNull(existing);
        TbFullName.Text = existing.FullName;
        TbBirthYear.Text = existing.BirthYear.ToString();
        TbSchool.Text = existing.SchoolNumber.ToString();
        TbAverageScore.Text = existing.AverageScore.ToString(CultureInfo.InvariantCulture);
    }

    private async void BtnOk_Click(object? sender, RoutedEventArgs e)
    {
        string fullName = TbFullName.Text?.Trim() ?? string.Empty;
        string birthYearText = TbBirthYear.Text?.Trim() ?? string.Empty;
        string schoolText = TbSchool.Text?.Trim() ?? string.Empty;
        string averageScoreText = (TbAverageScore.Text?.Trim() ?? string.Empty).Replace(',', '.');

        if (string.IsNullOrWhiteSpace(fullName))
        {
            await MessageHelper.ShowInfoAsync(this, "Ошибка ввода", "Введите ФИО.");
            return;
        }

        if (!int.TryParse(birthYearText, out int birthYear))
        {
            await MessageHelper.ShowInfoAsync(this, "Ошибка ввода", "Введите корректный год рождения.");
            return;
        }

        if (!int.TryParse(schoolText, out int schoolNumber))
        {
            await MessageHelper.ShowInfoAsync(this, "Ошибка ввода", "Введите корректный номер школы.");
            return;
        }

        if (!double.TryParse(averageScoreText, NumberStyles.Float, CultureInfo.InvariantCulture, out double averageScore))
        {
            await MessageHelper.ShowInfoAsync(this, "Ошибка ввода", "Введите корректный средний балл.");
            return;
        }

        if (averageScore < MinAverageScore || averageScore > MaxAverageScore)
        {
            await MessageHelper.ShowInfoAsync(this, "Ошибка ввода",
                $"Средний балл должен быть в диапазоне от {MinAverageScore} до {MaxAverageScore}.");
            return;
        }

        Close(new Abiturient(fullName, birthYear, schoolNumber, averageScore));
    }

    private void BtnCancel_Click(object? sender, RoutedEventArgs e)
    {
        Close(null);
    }
}
