namespace DIPLOM_
{
    partial class WorkerForm
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
            allTasksGrid = new DataGridView();
            databaseServiceBindingSource = new BindingSource(components);
            myTasksGrid = new DataGridView();
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)allTasksGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseServiceBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myTasksGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // allTasksGrid
            // 
            allTasksGrid.AllowUserToAddRows = false;
            allTasksGrid.AutoGenerateColumns = false;
            allTasksGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            allTasksGrid.DataSource = databaseServiceBindingSource;
            allTasksGrid.Dock = DockStyle.Fill;
            allTasksGrid.Location = new Point(0, 0);
            allTasksGrid.Name = "allTasksGrid";
            allTasksGrid.RowHeadersWidth = 51;
            allTasksGrid.Size = new Size(1222, 337);
            allTasksGrid.TabIndex = 0;
            allTasksGrid.CellContentClick += allTasksGrid_CellContentClick;
            allTasksGrid.CellFormatting += allTasksGrid_CellFormatting;
            // 
            // databaseServiceBindingSource
            // 
            databaseServiceBindingSource.DataSource = typeof(DatabaseService);
            // 
            // myTasksGrid
            // 
            myTasksGrid.AllowUserToAddRows = false;
            myTasksGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            myTasksGrid.AutoGenerateColumns = false;
            myTasksGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            myTasksGrid.DataSource = databaseServiceBindingSource;
            myTasksGrid.Location = new Point(0, 27);
            myTasksGrid.Name = "myTasksGrid";
            myTasksGrid.RowHeadersWidth = 51;
            myTasksGrid.Size = new Size(1225, 152);
            myTasksGrid.TabIndex = 1;
            myTasksGrid.CellContentClick += myTasksGrid_CellContentClick;
            myTasksGrid.CellFormatting += myTasksGrid_CellFormatting;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel3);
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Panel2.Controls.Add(myTasksGrid);
            splitContainer1.Size = new Size(1228, 553);
            splitContainer1.SplitterDistance = 366;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1228, 26);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 3);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 1;
            label1.Text = "All tasks";
            label1.Click += label1_Click_1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1228, 26);
            panel2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 4);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 2;
            label2.Text = "My tasks";
            label2.Click += label2_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(allTasksGrid);
            panel3.Location = new Point(3, 26);
            panel3.Name = "panel3";
            panel3.Size = new Size(1222, 337);
            panel3.TabIndex = 3;
            // 
            // WorkerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1228, 553);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(1200, 600);
            Name = "WorkerForm";
            Text = "Worker";
            Load += WorkerForm_Load;
            Resize += WorkerForm_Resize;
            ((System.ComponentModel.ISupportInitialize)allTasksGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseServiceBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)myTasksGrid).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView allTasksGrid;
        private BindingSource databaseServiceBindingSource;
        private DataGridView myTasksGrid;
        private SplitContainer splitContainer1;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}