namespace DIPLOM_
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            SchedulePage = new TabPage();
            ProceduresPage = new TabPage();
            ManagementPage = new TabPage();
            WorkersPage = new TabPage();
            addButton = new Button();
            panel1 = new Panel();
            label7 = new Label();
            workerComboBox = new ComboBox();
            datePicker = new DateTimePicker();
            label6 = new Label();
            timePicker = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            Field6 = new TextBox();
            Field5 = new TextBox();
            Field4 = new TextBox();
            fixPanelCheckBox = new CheckBox();
            statusLabel = new Label();
            isAdminCheckBox = new CheckBox();
            Field3 = new TextBox();
            Field2 = new TextBox();
            Field1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            acceptAddButton = new Button();
            DBGrid = new DataGridView();
            employeesMenu = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            addToolStripMenuItem = new ToolStripMenuItem();
            databaseServiceBindingSource = new BindingSource(components);
            tabControl1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DBGrid).BeginInit();
            employeesMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)databaseServiceBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(SchedulePage);
            tabControl1.Controls.Add(ProceduresPage);
            tabControl1.Controls.Add(ManagementPage);
            tabControl1.Controls.Add(WorkersPage);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(801, 30);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // SchedulePage
            // 
            SchedulePage.Location = new Point(4, 29);
            SchedulePage.Name = "SchedulePage";
            SchedulePage.Padding = new Padding(3);
            SchedulePage.Size = new Size(793, 0);
            SchedulePage.TabIndex = 0;
            SchedulePage.Text = "Schedule";
            SchedulePage.UseVisualStyleBackColor = true;
            // 
            // ProceduresPage
            // 
            ProceduresPage.Location = new Point(4, 29);
            ProceduresPage.Name = "ProceduresPage";
            ProceduresPage.Padding = new Padding(3);
            ProceduresPage.Size = new Size(793, 0);
            ProceduresPage.TabIndex = 1;
            ProceduresPage.Text = "Procedures";
            ProceduresPage.UseVisualStyleBackColor = true;
            // 
            // ManagementPage
            // 
            ManagementPage.Location = new Point(4, 29);
            ManagementPage.Name = "ManagementPage";
            ManagementPage.Size = new Size(793, 0);
            ManagementPage.TabIndex = 2;
            ManagementPage.Text = "Management";
            ManagementPage.UseVisualStyleBackColor = true;
            // 
            // WorkersPage
            // 
            WorkersPage.Location = new Point(4, 29);
            WorkersPage.Name = "WorkersPage";
            WorkersPage.Size = new Size(793, 0);
            WorkersPage.TabIndex = 3;
            WorkersPage.Text = "Employees";
            WorkersPage.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addButton.Location = new Point(1123, 1);
            addButton.Name = "addButton";
            addButton.Size = new Size(94, 29);
            addButton.TabIndex = 2;
            addButton.Text = "Add...";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label7);
            panel1.Controls.Add(workerComboBox);
            panel1.Controls.Add(datePicker);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(timePicker);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(Field6);
            panel1.Controls.Add(Field5);
            panel1.Controls.Add(Field4);
            panel1.Controls.Add(fixPanelCheckBox);
            panel1.Controls.Add(statusLabel);
            panel1.Controls.Add(isAdminCheckBox);
            panel1.Controls.Add(Field3);
            panel1.Controls.Add(Field2);
            panel1.Controls.Add(Field1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(acceptAddButton);
            panel1.Location = new Point(1042, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(195, 540);
            panel1.TabIndex = 1;
            panel1.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 339);
            label7.Name = "label7";
            label7.Size = new Size(50, 20);
            label7.TabIndex = 18;
            label7.Text = "label7";
            // 
            // workerComboBox
            // 
            workerComboBox.FormattingEnabled = true;
            workerComboBox.Location = new Point(9, 364);
            workerComboBox.Name = "workerComboBox";
            workerComboBox.Size = new Size(151, 28);
            workerComboBox.TabIndex = 11;
            // 
            // datePicker
            // 
            datePicker.CustomFormat = "dd.MM.yyyy";
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.Location = new Point(9, 31);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(181, 27);
            datePicker.TabIndex = 3;
            datePicker.Visible = false;
            datePicker.KeyDown += datePicker_KeyDown;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 286);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 16;
            label6.Text = "label6";
            // 
            // timePicker
            // 
            timePicker.CustomFormat = "HH:mm";
            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.Location = new Point(9, 88);
            timePicker.Name = "timePicker";
            timePicker.ShowUpDown = true;
            timePicker.Size = new Size(181, 27);
            timePicker.TabIndex = 4;
            timePicker.Visible = false;
            timePicker.KeyDown += timePicker_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 233);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 15;
            label5.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 177);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 14;
            label4.Text = "label4";
            // 
            // Field6
            // 
            Field6.Location = new Point(9, 309);
            Field6.Name = "Field6";
            Field6.Size = new Size(125, 27);
            Field6.TabIndex = 10;
            Field6.KeyDown += Field_KeyDown;
            // 
            // Field5
            // 
            Field5.Location = new Point(9, 256);
            Field5.Name = "Field5";
            Field5.Size = new Size(125, 27);
            Field5.TabIndex = 9;
            Field5.KeyDown += Field_KeyDown;
            // 
            // Field4
            // 
            Field4.Location = new Point(9, 200);
            Field4.Name = "Field4";
            Field4.Size = new Size(125, 27);
            Field4.TabIndex = 8;
            Field4.KeyDown += Field_KeyDown;
            // 
            // fixPanelCheckBox
            // 
            fixPanelCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            fixPanelCheckBox.AutoSize = true;
            fixPanelCheckBox.Location = new Point(3, 511);
            fixPanelCheckBox.Name = "fixPanelCheckBox";
            fixPanelCheckBox.Size = new Size(90, 24);
            fixPanelCheckBox.TabIndex = 14;
            fixPanelCheckBox.Text = "Fix panel";
            fixPanelCheckBox.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Bottom;
            statusLabel.ForeColor = Color.Red;
            statusLabel.Location = new Point(34, 438);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(131, 35);
            statusLabel.TabIndex = 9;
            statusLabel.Text = "123456";
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            statusLabel.Visible = false;
            // 
            // isAdminCheckBox
            // 
            isAdminCheckBox.AutoSize = true;
            isAdminCheckBox.Location = new Point(3, 411);
            isAdminCheckBox.Name = "isAdminCheckBox";
            isAdminCheckBox.Size = new Size(82, 24);
            isAdminCheckBox.TabIndex = 13;
            isAdminCheckBox.Text = "Admin?";
            isAdminCheckBox.UseVisualStyleBackColor = true;
            // 
            // Field3
            // 
            Field3.Location = new Point(9, 145);
            Field3.Name = "Field3";
            Field3.Size = new Size(125, 27);
            Field3.TabIndex = 7;
            Field3.TextChanged += AnyField_TextChanged;
            Field3.KeyDown += Field_KeyDown;
            // 
            // Field2
            // 
            Field2.Location = new Point(9, 88);
            Field2.Name = "Field2";
            Field2.Size = new Size(125, 27);
            Field2.TabIndex = 6;
            Field2.TextChanged += AnyField_TextChanged;
            Field2.KeyDown += Field_KeyDown;
            // 
            // Field1
            // 
            Field1.Location = new Point(9, 31);
            Field1.Name = "Field1";
            Field1.Size = new Size(125, 27);
            Field1.TabIndex = 5;
            Field1.TextChanged += AnyField_TextChanged;
            Field1.KeyDown += Field_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 122);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 3;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 65);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 8);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // acceptAddButton
            // 
            acceptAddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            acceptAddButton.Location = new Point(50, 476);
            acceptAddButton.Name = "acceptAddButton";
            acceptAddButton.Size = new Size(94, 29);
            acceptAddButton.TabIndex = 12;
            acceptAddButton.Text = "Accept";
            acceptAddButton.UseVisualStyleBackColor = true;
            acceptAddButton.Click += acceptAddButton_Click;
            // 
            // DBGrid
            // 
            DBGrid.AllowUserToAddRows = false;
            DBGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DBGrid.AutoGenerateColumns = false;
            DBGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DBGrid.ContextMenuStrip = employeesMenu;
            DBGrid.DataSource = databaseServiceBindingSource;
            DBGrid.Location = new Point(4, 36);
            DBGrid.Name = "DBGrid";
            DBGrid.RowHeadersWidth = 51;
            DBGrid.Size = new Size(1233, 542);
            DBGrid.TabIndex = 0;
            DBGrid.CellContentClick += employeesGrid_CellContentClick;
            DBGrid.CellEndEdit += employeesGrid_CellEndEdit;
            DBGrid.CellFormatting += DBGrid_CellFormatting;
            DBGrid.CellMouseDown += employeesGrid_CellMouseDown;
            DBGrid.RowValidating += employeesGrid_RowValidating;
            DBGrid.SelectionChanged += employeesGrid_SelectionChanged;
            // 
            // employeesMenu
            // 
            employeesMenu.ImageScalingSize = new Size(20, 20);
            employeesMenu.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem, addToolStripMenuItem });
            employeesMenu.Name = "employeesMenu";
            employeesMenu.Size = new Size(123, 52);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(122, 24);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(122, 24);
            addToolStripMenuItem.Text = "Add";
            addToolStripMenuItem.Click += addToolStripMenuItem_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1246, 588);
            Controls.Add(addButton);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            Controls.Add(DBGrid);
            MinimumSize = new Size(1200, 635);
            Name = "AdminForm";
            Text = "Admin";
            Shown += AdminForm_Shown;
            tabControl1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DBGrid).EndInit();
            employeesMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)databaseServiceBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage SchedulePage;
        private TabPage ProceduresPage;
        private TabPage ManagementPage;
        private TabPage WorkersPage;
        private DataGridView DBGrid;
        private BindingSource databaseServiceBindingSource;
        private ContextMenuStrip employeesMenu;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private Button addButton;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button acceptAddButton;
        private TextBox Field3;
        private TextBox Field2;
        private TextBox Field1;
        private CheckBox isAdminCheckBox;
        private Label statusLabel;
        private CheckBox fixPanelCheckBox;
        private TextBox Field4;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox Field6;
        private TextBox Field5;
        private DateTimePicker datePicker;
        private DateTimePicker timePicker;
        private Label label7;
        private ComboBox workerComboBox;
    }
}