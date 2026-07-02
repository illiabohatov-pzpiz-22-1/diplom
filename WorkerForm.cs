using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_
{
    public partial class WorkerForm : Form
    {
        private string _login;
        private readonly DatabaseService _database;
        public WorkerForm(string login)
        {
            InitializeComponent();
            _database = new DatabaseService();
            _login = login;

            TableFormat();
        }

        private void TableFormat()
        {
            allTasksGrid.AutoGenerateColumns = true;
            myTasksGrid.AutoGenerateColumns = true;
            allTasksGrid.DataSource = _database.GetTable("Tasks");
            myTasksGrid.DataSource = _database.GetWorkerTasks(_login);
            if (allTasksGrid.Columns.Contains("Id")) allTasksGrid.Columns["Id"].Visible = false;
            if (myTasksGrid.Columns.Contains("Id")) myTasksGrid.Columns["Id"].Visible = false;


            DataGridViewButtonColumn takeButton = new DataGridViewButtonColumn();
            takeButton.Name = "TakeTask";
            takeButton.HeaderText = "";
            takeButton.Text = "Take";
            takeButton.UseColumnTextForButtonValue = true;
            allTasksGrid.Columns.Add(takeButton);

            DataGridViewButtonColumn doneButton = new DataGridViewButtonColumn();
            doneButton.Name = "DoneTask";
            doneButton.Text = "Done";
            doneButton.UseColumnTextForButtonValue = true;
            myTasksGrid.Columns.Add(doneButton);

            FormatColumns(allTasksGrid);
            FormatColumns(myTasksGrid);
        }
        private void FormatColumns(DataGridView grid)
        {
            if (grid.Columns.Contains("TaskDate"))
                grid.Columns["TaskDate"].HeaderText = "Date";

            if (grid.Columns.Contains("TaskTime"))
                grid.Columns["TaskTime"].HeaderText = "Time";

            if (grid.Columns.Contains("CareType"))
                grid.Columns["CareType"].HeaderText = "Procedure";

            if (grid.Columns.Contains("AnimalCount"))
                grid.Columns["AnimalCount"].HeaderText = "Count";

            if (grid.Columns.Contains("IsAdmin"))
                grid.Columns["IsAdmin"].HeaderText = "Admin";

            if (grid.Columns.Contains("TakeTask"))
                grid.Columns["TakeTask"].HeaderText = "";

            if (grid.Columns.Contains("DoneTask"))
                grid.Columns["DoneTask"].HeaderText = "";
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void WorkerForm_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void allTasksGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (allTasksGrid.Columns[e.ColumnIndex].Name == "TakeTask")
            {
                if (Convert.ToInt32(
                    allTasksGrid.Rows[e.RowIndex]
                    .Cells["Status"].Value) != 0)
                {
                    e.Value = "";
                }
            }

            string columnName = allTasksGrid.Columns[e.ColumnIndex].Name;

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
                if (e.Value != null &&
                    DateTime.TryParse(
                        e.Value.ToString(),
                        out DateTime date))
                {
                    e.Value = date.ToString("dd.MM.yyyy");
                    e.FormattingApplied = true;
                }
            }
        }
        private void myTasksGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (myTasksGrid.Columns[e.ColumnIndex].Name == "DoneTask")
            {
                if (Convert.ToInt32(myTasksGrid.Rows[e.RowIndex].Cells["Status"].Value) != 1) e.Value = "";
            }

            string columnName = myTasksGrid.Columns[e.ColumnIndex].Name;
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

        private void allTasksGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (allTasksGrid.Columns[e.ColumnIndex].Name != "TakeTask")
                return;

            int status = Convert.ToInt32(allTasksGrid.Rows[e.RowIndex].Cells["Status"].Value);
            if (status != 0)
                return;

            int id = Convert.ToInt32(allTasksGrid.Rows[e.RowIndex].Cells["Id"].Value);

            _database.TakeTask(id, _login);

            allTasksGrid.DataSource = _database.GetTable("Tasks");
            myTasksGrid.DataSource = _database.GetWorkerTasks(_login);
            FormatColumns(allTasksGrid);
            FormatColumns(myTasksGrid);

        }
        private void myTasksGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (myTasksGrid.Columns[e.ColumnIndex].Name != "DoneTask")
                return;

            int status = Convert.ToInt32(myTasksGrid.Rows[e.RowIndex].Cells["Status"].Value);
            if (status != 1)
                return;

            int id = Convert.ToInt32(myTasksGrid.Rows[e.RowIndex].Cells["Id"].Value);

            _database.CompleteTask(id);

            allTasksGrid.DataSource = _database.GetTable("Tasks");
            myTasksGrid.DataSource = _database.GetWorkerTasks(_login);
            FormatColumns(allTasksGrid);
            FormatColumns(myTasksGrid);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void WorkerForm_Resize(object sender, EventArgs e)
        {
            //splitContainer1.SplitterDistance = (int)(splitContainer1.Height * 0.67);
        }


    }
}
