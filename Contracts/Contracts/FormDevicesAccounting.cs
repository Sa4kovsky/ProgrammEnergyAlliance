using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Contracts.Objects;

namespace Contracts
{
    public partial class FormDevicesAccounting : Form
    {
        public FormDevicesAccounting()
        {
            InitializeComponent();
            InitTable();
        }

        public void InitTable()
        {
            dataGridView1.ColumnCount = 13;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].Width = 250;
            dataGridView1.Columns[12].Width = 100;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Name = "Заказчик";
            dataGridView1.Columns[2].Name = "Адрес";
            dataGridView1.Columns[3].Name = "Тип прибора";
            dataGridView1.Columns[4].Name = "Тип учета";
            dataGridView1.Columns[5].Name = "Марка счетчика";
            dataGridView1.Columns[6].Name = "Д/У";
            dataGridView1.Columns[7].Name = "ТВ";
            dataGridView1.Columns[8].Name = "ИПП";
            dataGridView1.Columns[9].Name = "ППР";
            dataGridView1.Columns[10].Name = "ТСП";
            dataGridView1.Columns[11].Name = "Примечание";
            dataGridView1.Columns[12].Name = "Дата поверки";

        }

        public void OutputTable(List<DevaisesMaterials> devaisesMaterialses)
        {
            dataGridView1.RowCount = devaisesMaterialses.Count;
            for (int i = 0; i < devaisesMaterialses.Count; i++)
            {
                dataGridView1[0, i].Value = devaisesMaterialses[i].IdMaterials;
                dataGridView1[1, i].Value = devaisesMaterialses[i].Customer;
                dataGridView1[2, i].Value = devaisesMaterialses[i].Address;
                dataGridView1[3, i].Value = devaisesMaterialses[i].TypeCounter;
                dataGridView1[4, i].Value = devaisesMaterialses[i].TypeAccount;
                dataGridView1[5, i].Value = devaisesMaterialses[i].BrandEnergyMeter;
                dataGridView1[6, i].Value = devaisesMaterialses[i].Du;
                dataGridView1[7, i].Value = devaisesMaterialses[i].Tb;
                dataGridView1[8, i].Value = devaisesMaterialses[i].Ipp;
                dataGridView1[9, i].Value = devaisesMaterialses[i].Ppr;
                dataGridView1[10, i].Value = devaisesMaterialses[i].Tsp;
                dataGridView1[11, i].Value = devaisesMaterialses[i].Note;
                dataGridView1[12, i].Value = devaisesMaterialses[i].Date;
            }
            dataGridView1.ClearSelection();
        }

        private int flag, flag1, flag2;

        private void button1_Click(object sender, EventArgs e)
        {
            flag++;
            if (flag == 1)
            {
                this.textBox1.Size = new System.Drawing.Size(578, 484);
                this.textBox1.Location = new System.Drawing.Point(22, 22);
                flag++;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanSouth;
            }
            else
            {
                this.textBox1.Size = new System.Drawing.Size(228, 22);
                this.textBox1.Location = new System.Drawing.Point(372, 483);
                flag = 0;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanNorth;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag1++;
            if (flag1 == 1)
            {
                this.textBox8.Size = new System.Drawing.Size(1020, 537);
                this.textBox8.Location = new System.Drawing.Point(22, 22);
                flag1++;

                this.button2.Cursor = System.Windows.Forms.Cursors.PanSouth;
            }
            else
            {
                this.textBox8.Location = new System.Drawing.Point(426, 537);
                this.textBox8.Size = new System.Drawing.Size(614, 22);
                flag1 = 0;

                this.button2.Cursor = System.Windows.Forms.Cursors.PanNorth;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag2++;
            if (flag2 == 1)
            {
                monthCalendar1.Visible = true;
            }
            else
            {
                flag2 = 0;
                monthCalendar1.Visible = false;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox9.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void FormDevicesAccounting_Load(object sender, EventArgs e)
        {
            this.textBox8.Location = new System.Drawing.Point(426, 537);
            this.textBox8.Size = new System.Drawing.Size(614, 22);
            flag1 = 0;
            this.button2.Cursor = System.Windows.Forms.Cursors.PanNorth;
            flag2 = 0;
            monthCalendar1.Visible = false;
            this.textBox1.Size = new System.Drawing.Size(228, 22);
            this.textBox1.Location = new System.Drawing.Point(372, 483);
            flag = 0;
            this.button1.Cursor = System.Windows.Forms.Cursors.PanNorth;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    Id.Text = row.Cells[0].Value.ToString();
                if (row.Cells[1].Value != null)
                    comboBox1.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value != null)
                    textBox1.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value != null)
                    comboBox2.Text = row.Cells[3].Value.ToString();
                if (row.Cells[4].Value != null)
                    comboBox3.Text = row.Cells[4].Value.ToString();
                if (row.Cells[5].Value != null)
                    textBox2.Text = row.Cells[5].Value.ToString();
                if (row.Cells[6].Value != null)
                    textBox3.Text = row.Cells[6].Value.ToString();
                if (row.Cells[7].Value != null)
                    textBox4.Text = row.Cells[7].Value.ToString();
                if (row.Cells[8].Value != null)
                    textBox5.Text = row.Cells[8].Value.ToString();
                if (row.Cells[9].Value != null)
                    textBox6.Text = row.Cells[9].Value.ToString();
                if (row.Cells[10].Value != null)
                    textBox7.Text = row.Cells[10].Value.ToString();
                if (row.Cells[11].Value != null)
                    textBox8.Text = row.Cells[11].Value.ToString();
                if (row.Cells[12].Value != null)
                    textBox9.Text = row.Cells[12].Value.ToString();
            }
        }

        Connects connect = new Connects();

        private int customersId;

        #region comboBox1

        private void comboBox1_Selected(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            Customers customers = (Customers) comboBox1.SelectedItem;
            try
            {
                customersId = customers.IdCustomer;
                textBox1.Text = customers.AddressWork;
            }
            catch
            {
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_DropDownOpened(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            connect.Customerses.Clear();
            connect.ShowFieldsCustomerses();
            Custom(connect.Customerses);
        }

        private void Custom(List<Customers> customerses)
        {
            comboBox1.DataSource = customerses;
            comboBox1.ValueMember = "IdCustomer";
            comboBox1.DisplayMember = "NameInstitution";
        }

        #endregion

        private void Insert_Click(object sender, EventArgs e)
        {
            connect.DevaisesMaterialses.Clear();

            connect.InsertToTableDevaisesMaterialses(customersId, textBox1.Text, comboBox2.Text, comboBox3.Text, textBox2.Text,
                textBox3.Text, textBox4.Text,
                textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);

            connect.ShowFieldsDevaisesMaterialses();
            OutputTable(connect.DevaisesMaterialses);
            Close();
        }

        private int id;
        private void Update_Click(object sender, EventArgs e)
        {
            if (Id.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else

            {
                id = Convert.ToInt32(Id.Text);
                connect.DevaisesMaterialses.Clear();

                connect.UpdateFromTableDevaisesMaterialses(id, customersId, textBox1.Text,
                    comboBox2.Text, comboBox3.Text, textBox2.Text,
                    textBox3.Text, textBox4.Text,
                    textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);

                connect.ShowFieldsDevaisesMaterialses();
                OutputTable(connect.DevaisesMaterialses);
                Close();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Id.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                id = Convert.ToInt32(Id.Text);
                connect.DevaisesMaterialses.Clear();

                connect.DeleteFromTableDevaisesMaterialses(id);

                connect.ShowFieldsDevaisesMaterialses();
                OutputTable(connect.DevaisesMaterialses);
            }
        }
    }
}
