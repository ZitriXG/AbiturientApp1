using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AbiturientApp
{
    public partial class Form1 : Form
    {
        private List<Abiturient> abiturientsList;
        private readonly DatabaseManager dbManager;
        private readonly string dataFilePath = "abiturients.txt";

        public Form1()
        {
            InitializeComponent();
            dbManager = new DatabaseManager(dataFilePath);
            LoadData();

            if (cbSearchField.Items.Count > 0)
            {
                cbSearchField.SelectedIndex = 0;
            }
        }

        private void LoadData()
        {
            abiturientsList = dbManager.LoadData();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = abiturientsList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (InputForm inputForm = new InputForm())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    dbManager.AddRecord(abiturientsList, inputForm.AbiturientData);
                    RefreshGrid();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись для редактирования!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = dataGridView1.SelectedRows[0].Index;
            Abiturient selected = abiturientsList[selectedIndex];

            using (InputForm inputForm = new InputForm(selected))
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    dbManager.UpdateRecord(abiturientsList, selectedIndex, inputForm.AbiturientData);
                    RefreshGrid();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись для удаления!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                dbManager.DeleteRecord(abiturientsList, selectedIndex);
                RefreshGrid();
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            List<int> bestSchools = dbManager.FindBestSchool(abiturientsList);

            if (bestSchools.Count == 0)
            {
                MessageBox.Show("Нет абитуриентов со средним баллом выше 4.", "Результат анализа",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string message = "Школа(ы) с максимальным количеством абитуриентов (средний балл > 4):\n";
                message += string.Join(", ", bestSchools);
                MessageBox.Show(message, "Результат анализа",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbSearchField.SelectedItem == null)
            {
                MessageBox.Show("Выберите поле для поиска!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string field = cbSearchField.SelectedItem.ToString();
            string value = tbSearchValue.Text.Trim();

            if (string.IsNullOrEmpty(value))
            {
                RefreshGrid();
                return;
            }

            List<Abiturient> searchResults = dbManager.Search(abiturientsList, field, value);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = searchResults;
        }

    }
}
