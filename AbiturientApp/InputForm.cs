using System;
using System.Globalization;
using System.Windows.Forms;

namespace AbiturientApp
{
    public partial class InputForm : Form
    {
        public Abiturient AbiturientData { get; private set; }

        public InputForm()
        {
            InitializeComponent();
        }

        public InputForm(Abiturient existing) : this()
        {
            if (existing == null)
            {
                return;
            }

            tbFullName.Text = existing.FullName;
            tbBirthYear.Text = existing.BirthYear.ToString();
            tbSchool.Text = existing.SchoolNumber.ToString();
            tbAverageScore.Text = existing.AverageScore.ToString(CultureInfo.InvariantCulture);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string fullName = tbFullName.Text.Trim();
            string birthYearText = tbBirthYear.Text.Trim();
            string schoolText = tbSchool.Text.Trim();
            string averageScoreText = tbAverageScore.Text.Trim().Replace(',', '.');

            if (string.IsNullOrWhiteSpace(fullName))
            {
                ShowValidationError("Введите ФИО.");
                return;
            }

            if (!int.TryParse(birthYearText, out int birthYear))
            {
                ShowValidationError("Введите корректный год рождения.");
                return;
            }

            if (!int.TryParse(schoolText, out int schoolNumber))
            {
                ShowValidationError("Введите корректный номер школы.");
                return;
            }

            if (!double.TryParse(averageScoreText, NumberStyles.Float, CultureInfo.InvariantCulture, out double averageScore))
            {
                ShowValidationError("Введите корректный средний балл.");
                return;
            }

            if (averageScore < 0 || averageScore > 5)
            {
                ShowValidationError("Средний балл должен быть в диапазоне от 0 до 5.");
                return;
            }

            AbiturientData = new Abiturient(fullName, birthYear, schoolNumber, averageScore);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ShowValidationError(string message)
        {
            MessageBox.Show(message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
