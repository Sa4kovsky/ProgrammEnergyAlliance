using System.Windows.Forms;

namespace Contracts
{
    partial class FormCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomers));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.Label();
            this.InsertExecutor = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.UpdateExecutor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DeleteExecutor = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonExecutor = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.Size = new System.Drawing.Size(595, 388);
            this.dataGridView1.TabIndex = 26;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1215, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Поиск");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(600, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 16);
            this.label7.TabIndex = 40;
            this.label7.Text = "Адрес работ";
            // 
            // Id
            // 
            this.Id.AutoSize = true;
            this.Id.Location = new System.Drawing.Point(729, 79);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(0, 16);
            this.Id.TabIndex = 32;
            // 
            // InsertExecutor
            // 
            this.InsertExecutor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("InsertExecutor.BackgroundImage")));
            this.InsertExecutor.FlatAppearance.BorderSize = 0;
            this.InsertExecutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InsertExecutor.Location = new System.Drawing.Point(996, 305);
            this.InsertExecutor.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.InsertExecutor.Name = "InsertExecutor";
            this.InsertExecutor.Size = new System.Drawing.Size(48, 48);
            this.InsertExecutor.TabIndex = 12;
            this.toolTip1.SetToolTip(this.InsertExecutor, "Добавить");
            this.InsertExecutor.UseVisualStyleBackColor = true;
            this.InsertExecutor.Click += new System.EventHandler(this.InsertExecutor_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(732, 127);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(515, 23);
            this.textBox3.TabIndex = 4;
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(1052, 16);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(157, 23);
            this.textSearch.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textSearch, "Поиск");
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox5.Location = new System.Drawing.Point(732, 185);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(515, 23);
            this.textBox5.TabIndex = 6;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // UpdateExecutor
            // 
            this.UpdateExecutor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UpdateExecutor.BackgroundImage")));
            this.UpdateExecutor.FlatAppearance.BorderSize = 0;
            this.UpdateExecutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateExecutor.Location = new System.Drawing.Point(1052, 305);
            this.UpdateExecutor.Margin = new System.Windows.Forms.Padding(3, 3, 5, 5);
            this.UpdateExecutor.Name = "UpdateExecutor";
            this.UpdateExecutor.Size = new System.Drawing.Size(48, 48);
            this.UpdateExecutor.TabIndex = 13;
            this.toolTip1.SetToolTip(this.UpdateExecutor, "Изменить");
            this.UpdateExecutor.UseVisualStyleBackColor = true;
            this.UpdateExecutor.Click += new System.EventHandler(this.UpdateExecutor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(652, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "№";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(599, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 45;
            this.label10.Text = "Банк";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(732, 98);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(515, 23);
            this.textBox1.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(732, 156);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(477, 23);
            this.textBox4.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(696, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 28;
            this.label1.Text = "Просмотр";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(599, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 37;
            this.label6.Text = "Юр. адрес";
            // 
            // DeleteExecutor
            // 
            this.DeleteExecutor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteExecutor.BackgroundImage")));
            this.DeleteExecutor.FlatAppearance.BorderSize = 0;
            this.DeleteExecutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteExecutor.Location = new System.Drawing.Point(1107, 305);
            this.DeleteExecutor.Name = "DeleteExecutor";
            this.DeleteExecutor.Size = new System.Drawing.Size(48, 48);
            this.DeleteExecutor.TabIndex = 14;
            this.toolTip1.SetToolTip(this.DeleteExecutor, "Удалить");
            this.DeleteExecutor.UseVisualStyleBackColor = true;
            this.DeleteExecutor.Click += new System.EventHandler(this.DeleteExecutor_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(600, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 16);
            this.label9.TabIndex = 44;
            this.label9.Text = "Р/С";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(599, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Учреждение";
            // 
            // comboBox2
            // 
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(732, 214);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(515, 24);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.DropDown += new System.EventHandler(this.comboBox2_DropDownOpened);
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.DropDownClosed += new System.EventHandler(this.comboBox2_Selected);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(599, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 16);
            this.label8.TabIndex = 53;
            this.label8.Text = "УНП";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(599, 276);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 16);
            this.label11.TabIndex = 54;
            this.label11.Text = "ОКПО";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Location = new System.Drawing.Point(732, 244);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(515, 23);
            this.textBox2.TabIndex = 9;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox7.Location = new System.Drawing.Point(732, 273);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(515, 23);
            this.textBox7.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.PanNorth;
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(595, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(664, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Добавить Имя Заказчика или Банк";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.buttonExecutor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(595, 303);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 62);
            this.panel1.TabIndex = 55;
            this.panel1.Visible = false;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(353, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(308, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "Банк";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonExecutor
            // 
            this.buttonExecutor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonExecutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExecutor.Location = new System.Drawing.Point(4, 0);
            this.buttonExecutor.Name = "buttonExecutor";
            this.buttonExecutor.Size = new System.Drawing.Size(346, 46);
            this.buttonExecutor.TabIndex = 1;
            this.buttonExecutor.Text = "Имя Заказчика";
            this.buttonExecutor.UseVisualStyleBackColor = true;
            this.buttonExecutor.Click += new System.EventHandler(this.buttonExecutor_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.Cursor = System.Windows.Forms.Cursors.PanNorth;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(1215, 151);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 32);
            this.button3.TabIndex = 266;
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 388);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.DeleteExecutor);
            this.Controls.Add(this.UpdateExecutor);
            this.Controls.Add(this.InsertExecutor);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заказы";
            this.Click += new System.EventHandler(this.FormCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Id;
        private System.Windows.Forms.Button InsertExecutor;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button UpdateExecutor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button DeleteExecutor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonExecutor;
        private System.Windows.Forms.Button button3;

    }
}