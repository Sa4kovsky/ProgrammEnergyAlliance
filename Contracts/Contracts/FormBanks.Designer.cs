namespace Contracts
{
    partial class FormBanks
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBanks));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.DeleteExecutor = new System.Windows.Forms.Button();
            this.UpdateExecutor = new System.Windows.Forms.Button();
            this.InsertExecutor = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(909, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Поиск");
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(692, 12);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(211, 23);
            this.textSearch.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textSearch, "Поиск");
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged_1);
            // 
            // DeleteExecutor
            // 
            this.DeleteExecutor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteExecutor.BackgroundImage")));
            this.DeleteExecutor.FlatAppearance.BorderSize = 0;
            this.DeleteExecutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteExecutor.Location = new System.Drawing.Point(893, 190);
            this.DeleteExecutor.Name = "DeleteExecutor";
            this.DeleteExecutor.Size = new System.Drawing.Size(48, 48);
            this.DeleteExecutor.TabIndex = 6;
            this.toolTip1.SetToolTip(this.DeleteExecutor, "Удалить");
            this.DeleteExecutor.UseVisualStyleBackColor = true;
            this.DeleteExecutor.Click += new System.EventHandler(this.DeleteExecutor_Click);
            // 
            // UpdateExecutor
            // 
            this.UpdateExecutor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UpdateExecutor.BackgroundImage")));
            this.UpdateExecutor.FlatAppearance.BorderSize = 0;
            this.UpdateExecutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateExecutor.Location = new System.Drawing.Point(837, 190);
            this.UpdateExecutor.Margin = new System.Windows.Forms.Padding(3, 3, 5, 5);
            this.UpdateExecutor.Name = "UpdateExecutor";
            this.UpdateExecutor.Size = new System.Drawing.Size(48, 48);
            this.UpdateExecutor.TabIndex = 5;
            this.toolTip1.SetToolTip(this.UpdateExecutor, "Изменить");
            this.UpdateExecutor.UseVisualStyleBackColor = true;
            this.UpdateExecutor.Click += new System.EventHandler(this.UpdateExecutor_Click);
            // 
            // InsertExecutor
            // 
            this.InsertExecutor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("InsertExecutor.BackgroundImage")));
            this.InsertExecutor.FlatAppearance.BorderSize = 0;
            this.InsertExecutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InsertExecutor.Location = new System.Drawing.Point(777, 190);
            this.InsertExecutor.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.InsertExecutor.Name = "InsertExecutor";
            this.InsertExecutor.Size = new System.Drawing.Size(48, 48);
            this.InsertExecutor.TabIndex = 4;
            this.toolTip1.SetToolTip(this.InsertExecutor, "Добавить");
            this.InsertExecutor.UseVisualStyleBackColor = true;
            this.InsertExecutor.Click += new System.EventHandler(this.InsertExecutor_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(524, 96);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(379, 23);
            this.textBox1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 57;
            this.label4.Text = "Название банка";
            // 
            // Id
            // 
            this.Id.AutoSize = true;
            this.Id.Location = new System.Drawing.Point(527, 77);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(0, 16);
            this.Id.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 54;
            this.label2.Text = "№";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(605, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 53;
            this.label1.Text = "Просмотр";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(387, 250);
            this.dataGridView1.TabIndex = 51;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 20;
            this.toolTip1.AutoPopDelay = 2000;
            this.toolTip1.InitialDelay = 20;
            this.toolTip1.ReshowDelay = 4;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Подсказка";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(524, 125);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(417, 23);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 63;
            this.label3.Text = "МФО";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Cursor = System.Windows.Forms.Cursors.PanNorth;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(909, 91);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 265;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormBanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 250);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.DeleteExecutor);
            this.Controls.Add(this.UpdateExecutor);
            this.Controls.Add(this.InsertExecutor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormBanks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Банки";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Button DeleteExecutor;
        private System.Windows.Forms.Button UpdateExecutor;
        private System.Windows.Forms.Button InsertExecutor;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}