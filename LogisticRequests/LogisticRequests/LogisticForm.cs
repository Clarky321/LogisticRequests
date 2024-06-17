using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using Guna.UI2.WinForms.Enums;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using Microsoft.Office.Interop.Word;

namespace LogisticRequests
{
    //переменные RowState для функций
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class LogisticForm : Form
    {
        private readonly checkUser _user;

        DataBase dataBase = new DataBase();

        int SelectedRow;

        public LogisticForm(checkUser user)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            _user = user;
        }

        private void LogisticForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            CreateColumns2();
            RefreshDataGrid(dataGridView1);
            RefreshDataGrid2(dataGridView2);

            IsAdmin();
            toolStripLabel1.Text = $"{_user.Login}: {_user.Status}";

        }

        private void IsAdmin()
        {
            управлениеToolStripMenuItem.Enabled = _user.IsAdmin;
            Pages1.Enabled = _user.IsAdmin;
            экспорт1ТаблицаToolStripMenuItem.Enabled = _user.IsAdmin;
            отчётТаблицы1ToolStripMenuItem.Enabled = _user.IsAdmin;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_enterprises", "ID");
            dataGridView1.Columns.Add("enterprises", "Предприятия");
            dataGridView1.Columns.Add("cargo_type", "Тип груза");
            dataGridView1.Columns.Add("tonnage", "Тоннаж");
            dataGridView1.Columns.Add("weight_per_load", "Вес одной загрузки");
            dataGridView1.Columns.Add("load_city", "Город загрузки");
            dataGridView1.Columns.Add("unloading_city", "Город выгрузки");
            dataGridView1.Columns.Add("shipping_cost", "Цена доставки");
            dataGridView1.Columns.Add("timing", "Срок");
            dataGridView1.Columns.Add("status", "Статус");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetDecimal(7), record.GetString(8), record.GetString(9), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string querystring = $"SELECT * FROM Enterprises";

            using (var conn = dataBase.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(querystring, conn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReadSingleRow(dgw, reader);
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[SelectedRow];

                TextBox_ID.Text = row.Cells[0].Value.ToString();
                TextBox_Enterprasis.Text = row.Cells[1].Value.ToString();
                TextBox_Cargo_type.Text = row.Cells[2].Value.ToString();
                TextBox_Tonnage.Text = row.Cells[3].Value.ToString();
                TextBox_Weight_per_load.Text = row.Cells[4].Value.ToString();
                TextBox_Load_city.Text = row.Cells[5].Value.ToString();
                TextBox_Unloading_city.Text = row.Cells[6].Value.ToString();
                TextBox_Cost.Text = row.Cells[7].Value.ToString();
                TextBox_Timing.Text = row.Cells[8].Value.ToString();
                ComboBox_Status.Text = row.Cells[9].Value.ToString();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string querystring = "SELECT * FROM Enterprises WHERE " +
                                 "(id_enterprises || ' ' || enterprises || ' ' || cargo_type || ' ' || " +
                                 "tonnage || ' ' || weight_per_load || ' ' || load_city || ' ' || " +
                                 "unloading_city || ' ' || shipping_cost || ' ' || timing) LIKE '%" + TextBox_Search.Text + "%'";

            using (var conn = dataBase.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(querystring, conn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReadSingleRow(dgw, reader);
                        }
                    }
                }
            }
        }

        private void TextBox_Search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Add_Form1 addfrm = new Add_Form1();
            addfrm.Show();
        }

        private void DeleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[9].Value = RowState.Deleted;

                return;
            }

            dataGridView1.Rows[index].Cells[9].Value = RowState.Deleted;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        private void SaveData()
        {
            using (var conn = dataBase.GetConnection())
            {
                for (int index = 0; index < dataGridView1.Rows.Count; index++)
                {
                    var rowState = (RowState)dataGridView1.Rows[index].Cells[9].Value;

                    if (rowState == RowState.Existed)
                        continue;

                    if (rowState == RowState.Deleted)
                    {
                        var identity = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);

                        var deleteQuery = $"DELETE FROM Enterprises WHERE id_enterprises = {identity}";

                        using (SQLiteCommand command = new SQLiteCommand(deleteQuery, conn))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    if (rowState == RowState.Modified)
                    {
                        var id_enterprises = dataGridView1.Rows[index].Cells[0].Value.ToString();
                        var enterprises = dataGridView1.Rows[index].Cells[1].Value.ToString();
                        var cargo_type = dataGridView1.Rows[index].Cells[2].Value.ToString();
                        var tonnage = dataGridView1.Rows[index].Cells[3].Value.ToString();
                        var weight_per_load = dataGridView1.Rows[index].Cells[4].Value.ToString();
                        var load_city = dataGridView1.Rows[index].Cells[5].Value.ToString();
                        var unloading_city = dataGridView1.Rows[index].Cells[6].Value.ToString();
                        var shipping_cost = dataGridView1.Rows[index].Cells[7].Value.ToString();
                        var timing = dataGridView1.Rows[index].Cells[8].Value.ToString();
                        var status = dataGridView1.Rows[index].Cells[9].Value.ToString();

                        var changeQuery = $"UPDATE Enterprises SET enterprises = '{enterprises}', cargo_type = '{cargo_type}', tonnage = '{tonnage}', weight_per_load = '{weight_per_load}', load_city = '{load_city}', unloading_city = '{unloading_city}', shipping_cost = '{shipping_cost}', timing = '{timing}' WHERE id_enterprises = '{id_enterprises}'";

                        using (SQLiteCommand command = new SQLiteCommand(changeQuery, conn))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void Change()
        {
            var SelectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id_enterprises = TextBox_ID.Text;
            var enterprises = TextBox_Enterprasis.Text;
            var cargo_type = TextBox_Cargo_type.Text;
            var tonnage = TextBox_Tonnage.Text;
            var weight_per_load = TextBox_Weight_per_load.Text;
            var load_city = TextBox_Load_city.Text;
            var unloading_city = TextBox_Unloading_city.Text;
            int shipping_cost;
            var timing = TextBox_Timing.Text;
            var status = ComboBox_Status.Text;

            if (dataGridView1.Rows[SelectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(TextBox_Cost.Text, out shipping_cost))
                {
                    dataGridView1.Rows[SelectedRowIndex].SetValues(id_enterprises, enterprises, cargo_type, tonnage, weight_per_load, load_city, unloading_city, shipping_cost, timing, status);
                    dataGridView1.Rows[SelectedRowIndex].Cells[9].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Цена должна иметь числовой формат");
                }
            }
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void управлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_Panel adminPanel = new Admin_Panel();
            adminPanel.Show();
        }

        private void авторизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log_in logIn = new log_in();
            logIn.Show();
            this.Hide();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Выход из приложения
            System.Windows.Forms.Application.Exit();
        }

        private void CreateColumns2()
        {
            dataGridView2.Columns.Add("id_driver", "ID");
            dataGridView2.Columns.Add("FIO", "ФИО");
            dataGridView2.Columns.Add("Series_Pass", "Серия\\номер паспорта");
            dataGridView2.Columns.Add("Pass_issued", "Паспорт выдан");
            dataGridView2.Columns.Add("Date_issued", "Дата выдачи");
            dataGridView2.Columns.Add("Phone", "Телефон");
            dataGridView2.Columns.Add("Name_auto", "Наименование автомобиля");
            dataGridView2.Columns.Add("Tractor", "Тягач");
            dataGridView2.Columns.Add("Trailer", "Прицеп");
            dataGridView2.Columns.Add("Сarrying", "Грузоподъёмность");
            dataGridView2.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow2(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetDateTime(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), record.GetInt32(9), RowState.ModifiedNew);
        }

        private void RefreshDataGrid2(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string querystring = $"SELECT * FROM Driver";

            using (var conn = dataBase.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(querystring, conn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReadSingleRow2(dgw, reader);
                        }
                    }
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[SelectedRow];

                TextBox2_ID.Text = row.Cells[0].Value.ToString();
                TextBox_FIO.Text = row.Cells[1].Value.ToString();
                TextBox_Series_Pass.Text = row.Cells[2].Value.ToString();
                TextBox_Pass_issued.Text = row.Cells[3].Value.ToString();
                TextBox_Date_issued.Text = row.Cells[4].Value.ToString();
                TextBox_Phone.Text = row.Cells[5].Value.ToString();
                TextBox_Name_auto.Text = row.Cells[6].Value.ToString();
                TextBox_Tractor.Text = row.Cells[7].Value.ToString();
                TextBox_Trailer.Text = row.Cells[8].Value.ToString();
                TextBox_Сarrying.Text = row.Cells[9].Value.ToString();
            }
        }

        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid2(dataGridView2);
        }

        private void Search2(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string querystring = $"SELECT * FROM Driver WHERE CONCAT (id_driver, FIO, Series_Pass, Pass_issued, Date_issued, Phone, Name_auto, Tractor, Trailer, Сarrying) like '%" + TextBox_Search2.Text + "%'";

            using (var conn = dataBase.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(querystring, conn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReadSingleRow2(dgw, reader);
                        }
                    }
                }
            }
        }

        private void TextBox_Search2_TextChanged(object sender, EventArgs e)
        {
            Search2(dataGridView2);
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            Add_Form2 addfrm2 = new Add_Form2();
            addfrm2.Show();
        }

        private void DeleteRow2()
        {
            int index = dataGridView2.CurrentCell.RowIndex;

            dataGridView2.Rows[index].Visible = false;

            if (dataGridView2.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView2.Rows[index].Cells[10].Value = RowState.Deleted;

                return;
            }

            dataGridView2.Rows[index].Cells[10].Value = RowState.Deleted;
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            DeleteRow2();
        }

        private void SaveData2()
        {
            using (var conn = dataBase.GetConnection())
            {
                for (int index = 0; index < dataGridView2.Rows.Count; index++)
                {
                    var rowState = (RowState)dataGridView2.Rows[index].Cells[10].Value;

                    if (rowState == RowState.Existed)
                        continue;

                    if (rowState == RowState.Deleted)
                    {
                        var identity = Convert.ToInt32(dataGridView2.Rows[index].Cells[0].Value);

                        var deleteQuery = $"DELETE FROM Driver WHERE id_driver = {identity}";

                        using (SQLiteCommand command = new SQLiteCommand(deleteQuery, conn))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    if (rowState == RowState.Modified)
                    {
                        var id_driver = dataGridView2.Rows[index].Cells[0].Value.ToString();
                        var FIO = dataGridView2.Rows[index].Cells[1].Value.ToString();
                        var Series_Pass = dataGridView2.Rows[index].Cells[2].Value.ToString();
                        var Pass_issued = dataGridView2.Rows[index].Cells[3].Value.ToString();
                        var Date_issued = dataGridView2.Rows[index].Cells[4].Value.ToString();
                        var Phone = dataGridView2.Rows[index].Cells[5].Value.ToString();
                        var Name_auto = dataGridView2.Rows[index].Cells[6].Value.ToString();
                        var Tractor = dataGridView2.Rows[index].Cells[7].Value.ToString();
                        var Trailer = dataGridView2.Rows[index].Cells[8].Value.ToString();
                        var Сarrying = dataGridView2.Rows[index].Cells[9].Value.ToString();

                        var changeQuery = $"UPDATE Driver SET FIO = '{FIO}', Series_Pass = '{Series_Pass}', Pass_issued = '{Pass_issued}', Date_issued = '{Date_issued}', Phone = '{Phone}', Name_auto = '{Name_auto}', Tractor = '{Tractor}', Trailer = '{Trailer}', Сarrying = '{Сarrying}' WHERE id_driver = '{id_driver}'";

                        using (SQLiteCommand command = new SQLiteCommand(changeQuery, conn))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void btnSaveData2_Click(object sender, EventArgs e)
        {
            SaveData2();
        }

        private void Change2()
        {
            var SelectedRowIndex = dataGridView2.CurrentCell.RowIndex;

            var id_driver = TextBox2_ID.Text;
            var FIO = TextBox_FIO.Text;
            var Series_Pass = TextBox_Series_Pass.Text;
            var Pass_issued = TextBox_Pass_issued.Text;
            var Date_issued = TextBox_Date_issued.Text;
            var Phone = TextBox_Phone.Text;
            var Name_auto = TextBox_Name_auto.Text;
            var Tractor = TextBox_Tractor.Text;
            var Trailer = TextBox_Trailer.Text;
            int Сarrying;

            if (dataGridView2.Rows[SelectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(TextBox_Сarrying.Text, out Сarrying))
                {
                    dataGridView2.Rows[SelectedRowIndex].SetValues(id_driver, FIO, Series_Pass, Pass_issued, Date_issued, Phone, Name_auto, Tractor, Trailer, Сarrying);
                    dataGridView2.Rows[SelectedRowIndex].Cells[10].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Грузоподъёмность должна иметь числовой формат");
                }
            }
        }

        private void btnChange2_Click(object sender, EventArgs e)
        {
            Change2();
        }

        private void ExportToExcel()
        {
            try
            {
                using (var conn = dataBase.GetConnection())
                {
                    string SqlExport = "SELECT * FROM Enterprises";

                    using (SQLiteCommand command = new SQLiteCommand(SqlExport, conn))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // Создаем новый документ Excel
                            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                            ExcelPackage excelPackage = new ExcelPackage();
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                            // Записываем заголовки столбцов
                            int column = 1;
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                worksheet.Cells[1, column].Value = reader.GetName(i);
                                column++;
                            }

                            // Записываем данные
                            int row = 2;
                            while (reader.Read())
                            {
                                column = 1;
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    worksheet.Cells[row, column].Value = reader[i];
                                    column++;
                                }
                                row++;
                            }

                            // Форматируем данные как таблицу
                            ExcelRange dataRange = worksheet.Cells[1, 1, row - 1, reader.FieldCount];
                            ExcelTable table = worksheet.Tables.Add(dataRange, "Table1");
                            table.TableStyle = TableStyles.Light1;

                            // Сохраняем документ Excel
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "Excel Files|*.xlsx";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                excelPackage.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                                MessageBox.Show("Данные успешно экспортированы в Excel");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void экспорт1ТаблицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel2()
        {
            try
            {
                using (var conn = dataBase.GetConnection())
                {
                    string SqlExport = "SELECT * FROM Driver";

                    using (SQLiteCommand command = new SQLiteCommand(SqlExport, conn))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // Создаем новый документ Excel
                            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                            ExcelPackage excelPackage = new ExcelPackage();
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                            // Записываем заголовки столбцов
                            int column = 1;
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                worksheet.Cells[1, column].Value = reader.GetName(i);
                                column++;
                            }

                            // Записываем данные
                            int row = 2;
                            while (reader.Read())
                            {
                                column = 1;
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    worksheet.Cells[row, column].Value = reader[i];
                                    column++;
                                }
                                row++;
                            }

                            // Форматируем данные как таблицу
                            ExcelRange dataRange = worksheet.Cells[1, 1, row - 1, reader.FieldCount];
                            ExcelTable table = worksheet.Tables.Add(dataRange, "Table1");
                            table.TableStyle = TableStyles.Light1;

                            // Сохраняем документ Excel
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "Excel Files|*.xlsx";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                excelPackage.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                                MessageBox.Show("Данные успешно экспортированы в Excel");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void экспрт2ТаблицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToExcel2();
        }

        private void ExportToWord()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word документ (*.docx)|*.docx";
            saveFileDialog.Title = "Сохранить отчет как...";
            saveFileDialog.ShowDialog();

            // Если пользователь выбрал файл, сохраняем документ
            if (saveFileDialog.FileName != "")
            {
                // Создаем новый Word-документ
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = word.Documents.Add();

                Microsoft.Office.Interop.Word.Range range = doc.Range();

                // Создаем таблицу с нужным количеством строк и столбцов
                int rowsCount = dataGridView1.Rows.Count + 1;
                int colsCount = dataGridView1.Columns.Count;
                Microsoft.Office.Interop.Word.Table table = doc.Tables.Add(range, rowsCount, colsCount);

                // Заполняем документ данными из DataGridView
                for (int i = 1; i <= colsCount; i++)
                {
                    table.Cell(1, i).Range.Text = dataGridView1.Columns[i - 1].HeaderText;
                }

                // Заполняем таблицу данными из DataGridView
                for (int i = 2; i <= rowsCount; i++)
                {
                    for (int j = 1; j <= colsCount; j++)
                    {
                        table.Cell(i, j).Range.Text = dataGridView1.Rows[i - 2].Cells[j - 1].Value.ToString();
                    }
                }

                // Сохраняем документ в выбранное место
                object filename = saveFileDialog.FileName;
                doc.SaveAs2(ref filename);
                MessageBox.Show("Данные успешно экспортированы в Word");
                doc.Close();
                word.Quit();
            }
        }

        private void отчётТаблицы1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToWord();
        }

        private void ExportToWord2()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word документ (*.docx)|*.docx";
            saveFileDialog.Title = "Сохранить отчет как...";
            saveFileDialog.ShowDialog();

            // Если пользователь выбрал файл, сохраняем документ
            if (saveFileDialog.FileName != "")
            {
                // Создаем новый Word-документ
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = word.Documents.Add();

                Microsoft.Office.Interop.Word.Range range = doc.Range();

                // Создаем таблицу с нужным количеством строк и столбцов
                int rowsCount = dataGridView2.Rows.Count + 1;
                int colsCount = dataGridView2.Columns.Count;
                Microsoft.Office.Interop.Word.Table table = doc.Tables.Add(range, rowsCount, colsCount);

                // Заполняем документ данными из DataGridView
                for (int i = 1; i <= colsCount; i++)
                {
                    table.Cell(1, i).Range.Text = dataGridView2.Columns[i - 1].HeaderText;
                }

                // Заполняем таблицу данными из DataGridView
                for (int i = 2; i <= rowsCount; i++)
                {
                    for (int j = 1; j <= colsCount; j++)
                    {
                        table.Cell(i, j).Range.Text = dataGridView2.Rows[i - 2].Cells[j - 1].Value.ToString();
                    }
                }

                // Сохраняем документ в выбранное место
                object filename = saveFileDialog.FileName;
                doc.SaveAs2(ref filename);
                MessageBox.Show("Данные успешно экспортированы в Word");
                doc.Close();
                word.Quit();
            }
        }

        private void отчётТаблицы2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToWord2();
        }

        private void заявкиводительToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Form3 add_Form3 = new Add_Form3();
            add_Form3.Show();
        }
    }
}