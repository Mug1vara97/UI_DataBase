using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=StudentGrades;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";
        private DataTable dataTable;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await ExecuteSqlQueryAsync(textBoxInput.Text);
        }

        private async Task ExecuteSqlQueryAsync(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);
                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;

                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка выполнения SQL запроса: " + ex.Message);
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await SaveChangesAsync();
        }

        private async Task SaveChangesAsync()
        {
            if (dataTable != null && dataTable.GetChanges() != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(textBoxInput.Text, connection);
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                        int rowsAffected = dataAdapter.Update(dataTable);
                        MessageBox.Show($"{rowsAffected} строк(и) успешно обновлены.");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ошибка сохранения данных: " + ex.Message);
                    }
                }
            }
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }

        private void DeleteSelectedRow()
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in dataGridView.SelectedRows)
                {
                    if (!selectedRow.IsNewRow)
                    {
                        dataGridView.Rows.Remove(selectedRow);
                    }
                }
                SaveChangesAsync().ConfigureAwait(false);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }
        }


        private async void buttonGetAverageGrade_Click(object sender, EventArgs e)
        {
            await GetAverageGradeAsync(textBoxInput.Text);
        }

        private async Task GetAverageGradeAsync(string fullName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand cmd = new SqlCommand("GetAverageGradeByFullName", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FullName", fullName);

                    SqlParameter outputParam = new SqlParameter("@AverageGrade", SqlDbType.Float)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    await cmd.ExecuteNonQueryAsync();

                    double averageGrade = (double)outputParam.Value;

                    MessageBox.Show($"Средняя оценка для {fullName}: {averageGrade}");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка получения средней оценки: " + ex.Message);
                }
            }
        }
    }
}
