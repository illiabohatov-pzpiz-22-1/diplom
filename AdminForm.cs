using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DIPLOM_
{
    public enum TableType
    {
        Employees,
        CareTypes,
        Tasks,
        AnimalCount
    }
    public partial class AdminForm : Form
    {
        private string _login;
        private readonly DatabaseService _database;
        private TableType _currentTable = TableType.Employees;
        public AdminForm(string login)
        {
            InitializeComponent();
            _database = new DatabaseService();

            _currentTable = TableType.Tasks;
            _login = login;
            ConfigurePanel();
            LoadCurrentTable();
            //Activate();
        }
        //private void ChangeMode(TableType mode)
        //{
        //    _currentMode = mode;

        //    fixPanelCheckBox.Checked = false;
        //    panel1.Visible = false;

        //    LoadCurrentTable();
        //}

        private bool _isUpdating = false;
        private string GetTableName()
        {
            return _currentTable switch
            {
                TableType.Employees => "Employees",
                TableType.CareTypes => "CareTypes",
                TableType.Tasks => "Tasks",
                TableType.AnimalCount => "AnimalCount",
                _ => throw new Exception()
            };
        }
        private void LoadCurrentTable()
        {
            DBGrid.AutoGenerateColumns = true;
            _isUpdating = true;
            DBGrid.DataSource = _database.GetTable(GetTableName());
            _isUpdating = false;
            FormatColumns();
            if (DBGrid.Columns.Contains("Id")) DBGrid.Columns["Id"].Visible = false;
            //if (_currentTable == TableType.Employees)
            //{
            //    DBGrid.Columns["IsAdmin"].HeaderText = "Admin";
            //}
            //if (_currentTable == TableType.AnimalCount)
            //{
            //    DBGrid.Columns["AnimalCount"].HeaderText = "Animal count";
            //}
        }
        private void DeleteCurrentRow()
        {
            int id = Convert.ToInt32(
                DBGrid.SelectedRows[0]
                .Cells["Id"].Value);

            _database.DeleteRow(
                _currentTable.ToString(),
                id);

            LoadCurrentTable();
        }
        private void AddCurrentRow()
        {
            
            switch (_currentTable)
            {
                case TableType.Tasks:
                    int status = workerComboBox.Text == "None" ? 0 : 1;
                    string? worker = workerComboBox.Text;
                    if (worker == "None") worker = "";
                    _database.InsertRow(
                        "Tasks",
                        new Dictionary<string, object>
                        {
                            ["TaskDate"] = datePicker.Value.Date,
                            ["TaskTime"] = timePicker.Value.ToString("HH:mm"),
                            ["CareType"] = Field3.Text,
                            ["Animal"] = Field4.Text,
                            ["Place"] = Field5.Text,
                            ["Description"] = Field6.Text,
                            ["Worker"] = worker!,
                            ["Status"] = status,
                        });
                    break;
                case TableType.Employees:
                    _database.InsertRow(
                        "Employees",
                        new Dictionary<string, object>
                        {
                            ["Name"] = Field1.Text,
                            ["Login"] = Field2.Text,
                            ["Password"] = Field3.Text,
                            ["IsAdmin"] = isAdminCheckBox.Checked ? 1 : 0
                        });
                    break;
                case TableType.CareTypes:
                    _database.InsertRow(
                        "CareTypes",
                        new Dictionary<string, object>
                        {
                            ["Name"] = Field1.Text,
                            ["Animal"] = Field2.Text,
                            ["Description"] = Field3.Text,
                        });
                    break;
                case TableType.AnimalCount:
                    _database.InsertRow(
                        "AnimalCount",
                        new Dictionary<string, object>
                        {
                            ["Animal"] = Field1.Text,
                            ["Place"] = Field2.Text,
                            ["AnimalCount"] = Field3.Text,
                            ["Description"] = Field4.Text,
                        });
                    break;

            }


            //_database.InsertRow(
            //    "Employees",
            //    new Dictionary<string, object>
            //    {
            //        ["Name"] = Field1.Text,
            //        ["Login"] = Field2.Text,
            //        ["Password"] = Field3.Text,
            //        ["IsAdmin"] = isAdminCheckBox.Checked ? 1 : 0
            //    });
        }


        private void ConfigurePanel()
        {
            Label[] labels =
            {
                label1,
                label2,
                label3,
                label4,
                label5,
                label6,
                label7
            };

            TextBox[] fields =
            {
                Field1,
                Field2,
                Field3,
                Field4,
                Field5,
                Field6
            };

            foreach (var label in labels)
                label.Visible = false;

            foreach (var field in fields)
            {
                field.Visible = false;
                field.Clear();
            }
            datePicker.Visible = false;
            timePicker.Visible = false;

            isAdminCheckBox.Visible = false;
            workerComboBox.Visible = false;

            switch (_currentTable)
            {
                case TableType.Tasks:

                    label1.Text = "Date";
                    label2.Text = "Time";
                    label3.Text = "Care Type";
                    label4.Text = "Animal";
                    label5.Text = "Place";
                    label6.Text = "Description";
                    label7.Text = "Employee";

                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;

                    datePicker.Visible = true;
                    timePicker.Visible = true;
                    Field3.Visible = true;
                    Field4.Visible = true;
                    Field5.Visible = true;
                    Field6.Visible = true;
                    workerComboBox.Visible = true;

                    break;

                case TableType.Employees:

                    label1.Text = "Name";
                    label2.Text = "Login";
                    label3.Text = "Password";

                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;

                    Field1.Visible = true;
                    Field2.Visible = true;
                    Field3.Visible = true;

                    isAdminCheckBox.Visible = true;

                    break;

                case TableType.CareTypes:

                    label1.Text = "Name";
                    label2.Text = "Animal";
                    label3.Text = "Description";

                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;

                    Field1.Visible = true;
                    Field2.Visible = true;
                    Field3.Visible = true;

                    break;

                case TableType.AnimalCount:

                    label1.Text = "Animal";
                    label2.Text = "Place";
                    label3.Text = "Animal count";
                    label4.Text = "Description";

                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;

                    Field1.Visible = true;
                    Field2.Visible = true;
                    Field3.Visible = true;
                    Field4.Visible = true;

                    break;
            }
        }
        private bool ValidateFields()
        {
            foreach (Control control in panel1.Controls)
            {
                if (control is not TextBox textBox)
                    continue;

                if (!textBox.Visible)
                    continue;

                if (textBox == Field5) // Description
                    continue;

                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    statusLabel.Text = "Fill all required fields";
                    return false;
                }
            }

            statusLabel.Text = "";
            return true;
        }
        private void FormatColumns()
        {
            if (DBGrid.Columns.Contains("TaskDate"))
                DBGrid.Columns["TaskDate"].HeaderText = "Date";

            if (DBGrid.Columns.Contains("CareType"))
                DBGrid.Columns["CareType"].HeaderText = "Procedure";

            if (DBGrid.Columns.Contains("AnimalCount"))
                DBGrid.Columns["AnimalCount"].HeaderText = "Count";

            if (DBGrid.Columns.Contains("IsAdmin"))
                DBGrid.Columns["IsAdmin"].HeaderText = "Admin";
        }



        private void employeesGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                DBGrid.ClearSelection();
                DBGrid.Rows[e.RowIndex].Selected = true;

                //DBGrid.CurrentCell = DBGrid.Rows[e.RowIndex].Cells[0];
            }

        }

        private int GetSelectedEmployeeId()
        {
            if (DBGrid.SelectedRows.Count == 0)
                return -1;

            return Convert.ToInt32(
                DBGrid.SelectedRows[0]
                    .Cells["Id"].Value);
        }
        private int _selectedEmployeeId;

        private void employeesGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (DBGrid.SelectedRows.Count == 0)
                return;

            var row = DBGrid.SelectedRows[0];

            _selectedEmployeeId =
                Convert.ToInt32(row.Cells["Id"].Value);

        }
        private void employeesGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = DBGrid.Rows[e.RowIndex];

            if (row.Cells["Id"].Value == null || row.Cells["Id"].Value == DBNull.Value) return;

            var values = new Dictionary<string, object>();

            foreach (DataGridViewColumn col in DBGrid.Columns)
            {
                string name = col.Name;
                values[name] = row.Cells[name].Value ?? "";
            }

            _database.UpdateRow(GetTableName(), values);
        }

        private void acceptAddButton_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            try
            {
                AddCurrentRow();

                LoadCurrentTable();

                if (!fixPanelCheckBox.Checked) panel1.Visible = false;
            }
            catch (SqliteException ex)
            {
                if (ex.SqliteErrorCode == 19)
                {
                    statusLabel.Text = "This login exists";
                    statusLabel.Visible = true;
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {

            if (panel1.Visible == false) panel1.Visible = true;
            else if (panel1.Visible == true)
            {
                if (!fixPanelCheckBox.Checked) panel1.Visible = false;
            }
            //ShowCurrentPanel();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            Field1.Focus();
            statusLabel.Visible = false;
        }
        //private void nameField_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        Field2.Focus();
        //        e.SuppressKeyPress = true;
        //    }
        //}
        //private void loginField_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        Field3.Focus();
        //        e.SuppressKeyPress = true;
        //    }
        //}
        private void Field_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            var controls = panel1.Controls
                .Cast<Control>()
                .Where(c => c.Visible && (c is TextBox || c is DateTimePicker))
                .OrderBy(c => c.TabIndex)
                .ToList();

            int currentIndex = controls.IndexOf((Control)sender);

            if (currentIndex == controls.Count - 1)
            {
                acceptAddButton.PerformClick();
            }
            else
            {
                controls[currentIndex + 1].Focus();
            }

            e.SuppressKeyPress = true;
        }
        private void datePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timePicker.Focus();
                e.SuppressKeyPress = true;
            }
        }
        private void timePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Field3.Focus(); // следующее поле после времени
                e.SuppressKeyPress = true;
            }
        }
        private void passwordField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                acceptAddButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
        private void AnyField_TextChanged(object sender, EventArgs e)
        {
            statusLabel.Visible = false;
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DBGrid.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(DBGrid.SelectedRows[0].Cells["Id"].Value);

            //_database.DeleteRow(TableType, id);
            _database.DeleteRow(GetTableName(), id);
            LoadCurrentTable();
        }

        private void employeesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void employeesGrid_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = DBGrid.Rows[e.RowIndex];

            if (row.IsNewRow) return;
            if (_isUpdating) return;
            string name;
            string animal;

            switch (_currentTable)
            {
                case TableType.Tasks:
                    string time = row.Cells["TaskTime"].Value?.ToString() ?? "";
                    string date = row.Cells["TaskDate"].Value?.ToString() ?? "";
                    string caretype = row.Cells["CareType"].Value?.ToString() ?? "";
                    string status = row.Cells["Status"].Value?.ToString() ?? "";

                    if (string.IsNullOrWhiteSpace(time))
                    {
                        statusLabel.Text = "Time cant be empty";
                        statusLabel.Visible = true;
                        e.Cancel = true;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(date))
                    {
                        statusLabel.Text = "Date cant be empty";
                        statusLabel.Visible = true;
                        e.Cancel = true;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(caretype))
                    {
                        statusLabel.Text = "Care type cant be empty";
                        statusLabel.Visible = true;
                        e.Cancel = true;
                        return;
                    }

                    //if (string.IsNullOrWhiteSpace(status))
                    //{
                    //    _database.InsertRow("Tasks", 
                    //        new Dictionary<string, object>
                    //        {
                    //           ["Status"] = "0",
                    //        });
                    //    e.Cancel = true;
                    //    return;
                    //}
                    break;

                case TableType.Employees:
                    string password = row.Cells["Password"].Value?.ToString() ?? "";
                    string isadmin = row.Cells["ISAdmin"].Value?.ToString() ?? "";
                    string login = row.Cells["Login"].Value?.ToString() ?? "";
                    name = row.Cells["Name"].Value?.ToString() ?? "";

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        statusLabel.Text = "Name cant be empty";
                        statusLabel.Visible = true;
                        e.Cancel = true;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(login))
                    {
                        statusLabel.Text = "Login cant be empty";
                        statusLabel.Visible = true;
                        e.Cancel = true;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(password))
                    {
                        statusLabel.Text = "Password cant be empty";
                        statusLabel.Visible = true;
                        e.Cancel = true;
                        return;
                    }
                    break;

                case TableType.CareTypes:
                    name = row.Cells["Name"].Value?.ToString() ?? "";
                    animal = row.Cells["Animal"].Value?.ToString() ?? "";

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        statusLabel.Text = "Name cant be empty";
                        statusLabel.Visible = true;
                        e.Cancel = true;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(animal))
                    {
                        statusLabel.Text = "Animal cant be empty";
                        statusLabel.Visible = true;
                        e.Cancel = true;
                        return;
                    }
                    break;

                case TableType.AnimalCount:
                    animal = row.Cells["Animal"].Value?.ToString() ?? "";
                    string place = row.Cells["Place"].Value?.ToString() ?? "";
                    string animalcount = row.Cells["AnimalCount"].Value?.ToString() ?? "";
                    if (string.IsNullOrWhiteSpace(animal))
                    {
                        statusLabel.Text = "Animal cant be empty";
                        statusLabel.Visible = true;
                        e.Cancel = true;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(place))
                    {
                        statusLabel.Text = "Place cant be empty";
                        statusLabel.Visible = true;
                        e.Cancel = true;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(animalcount))
                    {
                        statusLabel.Text = "Count cant be empty";
                        statusLabel.Visible = true;
                        e.Cancel = true;
                        return;
                    }

                    break;
            }

        }
        private void DBGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = DBGrid.Columns[e.ColumnIndex].Name;
            //MessageBox.Show("Formatting");
            if (columnName == "IsAdmin")
            {
                int value = Convert.ToInt32(e.Value);
                e.Value = value == 0 ? "" : "+";
                e.FormattingApplied = true;
            }
            if (columnName == "Status")
            {
                int value = Convert.ToInt32(e.Value);

                e.Value = value switch
                {
                    0 => "Undone",
                    1 => "In Progress",
                    2 => "Done",
                    _ => "Unknown"
                };

                e.FormattingApplied = true;
            }
            if (columnName == "Date")
            {
                DateTime date = Convert.ToDateTime(e.Value);

                e.Value = date.ToString("dd.MM.yyyy");

                e.FormattingApplied = true;
            }
            if (columnName == "Time")
            {
                TimeSpan time;

                if (TimeSpan.TryParse(
                    e.Value?.ToString(),
                    out time))
                {
                    e.Value = time.ToString(@"hh\:mm");

                    e.FormattingApplied = true;
                }
            }
            if (columnName == "TaskDate")
            {
                DateTime date = Convert.ToDateTime(e.Value);

                e.Value = date.ToString("dd.MM.yyyy");
                e.FormattingApplied = true;
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fixPanelCheckBox.Checked = false;
            if (!fixPanelCheckBox.Checked) panel1.Visible = false;

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    _currentTable = TableType.Tasks;
                    workerComboBox.Items.Clear();
                    workerComboBox.Items.Add("None");
                    workerComboBox.SelectedIndex = 0;
                    foreach (var employee in _database.GetEmployees())
                    {
                        workerComboBox.Items.Add(employee);
                    }
                    break;

                case 1:
                    _currentTable = TableType.CareTypes;
                    break;

                case 2:
                    _currentTable = TableType.AnimalCount;
                    break;

                case 3:
                    _currentTable = TableType.Employees;
                    break;
            }

            ConfigurePanel();
            LoadCurrentTable();
        }

        private void AdminForm_Shown(object sender, EventArgs e)
        {
            //BeginInvoke(() => DBGrid.Focus());
        }

        //private void ShowCurrentPanel()
        //{
        //    //employeePanel.Visible = false;
        //    //careTypePanel.Visible = false;
        //    //taskPanel.Visible = false;

        //    //switch (_currentTable)
        //    //{
        //    //    case TableType.Employees:
        //    //        employeePanel.Visible = true;
        //    //        break;

        //    //    case TableType.CareTypes:
        //    //        careTypePanel.Visible = true;
        //    //        break;

        //    //    case TableType.Tasks:
        //    //        taskPanel.Visible = true;
        //    //        break;
        //    //}

        //}
    }
}
