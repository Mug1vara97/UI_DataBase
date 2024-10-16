namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox textBoxInput;
        private Button button1;
        private Button button2;
        private Button buttonGetAverageGrade;
        private DataGridView dataGridView;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxInput = new TextBox();
            button1 = new Button();
            button2 = new Button();
            buttonGetAverageGrade = new Button();
            buttonDelete = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(14, 12);
            textBoxInput.Margin = new Padding(2);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(675, 23);
            textBoxInput.TabIndex = 0;
            textBoxInput.TextChanged += textBoxInput_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(14, 42);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(99, 28);
            button1.TabIndex = 1;
            button1.Text = "Fill";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(128, 42);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(98, 28);
            button2.TabIndex = 2;
            button2.Text = "Upgrade";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(590, 42);
            buttonDelete.Margin = new Padding(2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(99, 28);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;

            buttonGetAverageGrade = new Button();
            buttonGetAverageGrade.Location = new Point(240, 42);
            buttonGetAverageGrade.Margin = new Padding(2);
            buttonGetAverageGrade.Name = "buttonGetAverageGrade";
            buttonGetAverageGrade.Size = new Size(120, 28);
            buttonGetAverageGrade.TabIndex = 4;
            buttonGetAverageGrade.Text = "Get Average Grade";
            buttonGetAverageGrade.UseVisualStyleBackColor = true;
            buttonGetAverageGrade.Click += buttonGetAverageGrade_Click;
            Controls.Add(buttonGetAverageGrade);

            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(15, 85);
            dataGridView.Margin = new Padding(2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(674, 294);
            dataGridView.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 390);
            Controls.Add(textBoxInput);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(buttonDelete);
            Controls.Add(dataGridView);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button buttonDelete;
    }
}