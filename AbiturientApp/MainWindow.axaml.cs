using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AbiturientApp;

public partial class MainWindow : Window
{
    private List<Abiturient> _allAbiturients = new();
    private readonly ObservableCollection<Abiturient> _displayItems = new();
    private readonly DatabaseManager _dbManager;
    private const string DataFilePath = "abiturients.txt";

    public MainWindow()
    {
        InitializeComponent();
        _dbManager = new DatabaseManager(DataFilePath);
        DataGrid.ItemsSource = _displayItems;
        LoadData();
        CbSearchField.SelectedIndex = 0;
    }

    private void LoadData()
    {
        _allAbiturients = _dbManager.LoadData();
        RefreshGrid();
    }

    private void RefreshGrid(List<Abiturient>? source = null)
    {
        _displayItems.Clear();
        foreach (var a in source ?? _allAbiturients)
            _displayItems.Add(a);
    }

    private async void BtnAdd_Click(object? sender, RoutedEventArgs e)
    {
        var dialog = new InputDialog();
        var result = await dialog.ShowDialog<Abiturient?>(this);
        if (result != null)
        {
            _dbManager.AddRecord(_allAbiturients, result);
            RefreshGrid();
        }
    }

    private async void BtnEdit_Click(object? sender, RoutedEventArgs e)
    {
        if (DataGrid.SelectedItem is not Abiturient selected)
        {
            await MessageHelper.ShowInfoAsync(this, "Информация", "Выберите запись для редактирования!");
            return;
        }

        int selectedIndex = _allAbiturients.IndexOf(selected);
        var dialog = new InputDialog(selected);
        var result = await dialog.ShowDialog<Abiturient?>(this);
        if (result != null)
        {
            _dbManager.UpdateRecord(_allAbiturients, selectedIndex, result);
            RefreshGrid();
        }
    }

    private async void BtnDelete_Click(object? sender, RoutedEventArgs e)
    {
        if (DataGrid.SelectedItem is not Abiturient selected)
        {
            await MessageHelper.ShowInfoAsync(this, "Информация", "Выберите запись для удаления!");
            return;
        }

        bool confirmed = await MessageHelper.ShowConfirmAsync(
            this,
            "Подтверждение удаления",
            "Вы уверены, что хотите удалить выбранную запись?");

        if (confirmed)
        {
            int selectedIndex = _allAbiturients.IndexOf(selected);
            _dbManager.DeleteRecord(_allAbiturients, selectedIndex);
            RefreshGrid();
        }
    }

    private async void BtnAnalyze_Click(object? sender, RoutedEventArgs e)
    {
        List<int> bestSchools = _dbManager.FindBestSchool(_allAbiturients);

        if (bestSchools.Count == 0)
        {
            await MessageHelper.ShowInfoAsync(this, "Результат анализа",
                "Нет абитуриентов со средним баллом выше 4.");
        }
        else
        {
            string message = "Школа(ы) с максимальным количеством абитуриентов (средний балл > 4):\n"
                           + string.Join(", ", bestSchools);
            await MessageHelper.ShowInfoAsync(this, "Результат анализа", message);
        }
    }

    private async void BtnSearch_Click(object? sender, RoutedEventArgs e)
    {
        if (CbSearchField.SelectedItem is not ComboBoxItem fieldItem)
        {
            await MessageHelper.ShowInfoAsync(this, "Информация", "Выберите поле для поиска!");
            return;
        }

        string field = fieldItem.Content?.ToString() ?? string.Empty;
        string value = TbSearchValue.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(value))
        {
            await MessageHelper.ShowInfoAsync(this, "Информация", "Введите значение для поиска!");
            return;
        }

        List<Abiturient> searchResults = _dbManager.Search(_allAbiturients, field, value);

        if (searchResults.Count == 0)
        {
            await MessageHelper.ShowInfoAsync(this, "Результат поиска",
                "Записи, соответствующие критерию поиска, не найдены.");
        }
        else
        {
            RefreshGrid(searchResults);
        }
    }
}
