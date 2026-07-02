namespace DIPLOM_
{
    partial class LogIn
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
            loginText = new TextBox();
            passText = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            loginEnter = new Button();
            SuspendLayout();
            // 
            // loginText
            // 
            loginText.Location = new Point(54, 46);
            loginText.Name = "loginText";
            loginText.Size = new Size(239, 27);
            loginText.TabIndex = 0;
            loginText.TextChanged += loginText_TextChanged;
            // 
            // passText
            // 
            passText.Location = new Point(54, 113);
            passText.Name = "passText";
            passText.Size = new Size(239, 27);
            passText.TabIndex = 1;
            passText.TextChanged += passText_TextChanged;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 23);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 2;
            label2.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 90);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // loginEnter
            // 
            loginEnter.Location = new Point(123, 160);
            loginEnter.Name = "loginEnter";
            loginEnter.Size = new Size(94, 29);
            loginEnter.TabIndex = 4;
            loginEnter.Text = "Enter";
            loginEnter.UseVisualStyleBackColor = true;
            loginEnter.Click += loginEnter_Click;
            // 
            // LogIn
            // 
            AcceptButton = loginEnter;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 210);
            Controls.Add(loginEnter);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passText);
            Controls.Add(loginText);
            Name = "LogIn";
            Text = "LogIn";
            KeyDown += LogIn_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginText;
        private TextBox passText;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button loginEnter;
    }
}