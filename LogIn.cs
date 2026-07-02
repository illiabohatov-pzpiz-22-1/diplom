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
    public partial class LogIn : Form
    {
        private readonly DatabaseService _database;
        public LogIn()
        {
            InitializeComponent();
            _database = new DatabaseService();
        }

        private void loginEnter_Click(object sender, EventArgs e)
        {
            var user = _database.Authenticate(
            loginText.Text,
            passText.Text);

            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }

            bool isAdmin = Convert.ToInt32(user["IsAdmin"]) == 1;

            Hide();

            if (isAdmin)
            {
                new AdminForm(loginText.Text).ShowDialog();
            }
            else
            {
                new WorkerForm(loginText.Text).ShowDialog();
            }

            Close();
        }


        //private void Field_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode != Keys.Enter)
        //        return;

        //    var controls = panel1.Controls
        //        .Cast<Control>()
        //        .Where(c => c.Visible && (c is TextBox || c is DateTimePicker))
        //        .OrderBy(c => c.TabIndex)
        //        .ToList();

        //    int currentIndex = controls.IndexOf((Control)sender);

        //    if (currentIndex == controls.Count - 1)
        //    {
        //        acceptAddButton.PerformClick();
        //    }
        //    else
        //    {
        //        controls[currentIndex + 1].Focus();
        //    }

        //    e.SuppressKeyPress = true;
        //}

        private void loginText_TextChanged(object sender, EventArgs e)
        {

        }
        private void passText_TextChanged(object sender, EventArgs e)
        {

        }
        private void LogIn_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
