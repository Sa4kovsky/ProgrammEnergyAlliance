using System;
using System.Collections.Generic;

using System.Windows.Forms;
using Contracts.Objects;

namespace Contracts
{
    public partial class FormEquipment : Form
    {
        public FormEquipment()
        {
            InitializeComponent();
            InitTable();
        }

        public void InitTable()
        {
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 150;
            dataGridView1.Columns[8].Width = 150;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Name = "Учреждение";
            dataGridView1.Columns[2].Name = "Адрес";
            dataGridView1.Columns[3].Name = "Вид оборуд";
            dataGridView1.Columns[4].Name = "Тип учета";
            dataGridView1.Columns[5].Name = "Марка оборуд";
            dataGridView1.Columns[6].Name = "Д/У";
            dataGridView1.Columns[7].Name = "Марка клапана";
            dataGridView1.Columns[8].Name = "Примечание";
        }

        public void OutputTable(List<Equipment> equipments)
        {
            dataGridView1.RowCount = equipments.Count;
            for (int i = 0; i < equipments.Count; i++)
            {
                dataGridView1[0, i].Value = equipments[i].IdEquipment;
                dataGridView1[1, i].Value = equipments[i].IdCustomer;
                dataGridView1[2, i].Value = equipments[i].Address;
                dataGridView1[3, i].Value = equipments[i].TypeEquipment;
                dataGridView1[4, i].Value = equipments[i].TypeAccount;
                dataGridView1[5, i].Value = equipments[i].BrandEquipment;
                dataGridView1[6, i].Value = equipments[i].Du;
                dataGridView1[7, i].Value = equipments[i].BrandValves;
                dataGridView1[8, i].Value = equipments[i].Note;
            }
            dataGridView1.ClearSelection();
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "регулятор")
            {
                textBox5.Visible = true;
                label9.Visible = true;
            }
            else
            {
                textBox5.Visible = false;
                label9.Visible = false;
            }
        }

        private int flag = 0;
        private int flag1 = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            flag++;
            if (flag == 1)
            {
                this.textBox1.Size = new System.Drawing.Size(463, 423);
                this.textBox1.Location = new System.Drawing.Point(151, 83);
                flag++;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanSouth;
            }
            else
            {
                this.textBox1.Size = new System.Drawing.Size(463, 23);
                this.textBox1.Location = new System.Drawing.Point(151, 483);
                flag = 0;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanNorth;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag1++;
            if (flag1 == 1)
            {
                this.textBox4.Size = new System.Drawing.Size(463, 423);
                this.textBox4.Location = new System.Drawing.Point(151, 230);
                flag1++;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanSouth;
            }
            else
            {
                this.textBox4.Size = new System.Drawing.Size(463, 23);
                this.textBox4.Location = new System.Drawing.Point(151, 630);
                flag1 = 0;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanNorth;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    label10.Text = row.Cells[0].Value.ToString();
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
                    textBox5.Text = row.Cells[7].Value.ToString();
                if (row.Cells[8].Value != null)
                    textBox4.Text = row.Cells[8].Value.ToString();
            }

        }

        Connects connect = new Connects();

        private int customersId, idEquipment;
        private string address, typeEquipment, typeAccount,
            brandEquipment, du, brandValves, note;

        #region comboBox1 
        private void comboBox1_Selected(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            Customers customers = (Customers)comboBox1.SelectedItem;
            try
            {
                customersId = customers.IdCustomer;
                textBox1.Text = customers.LegalAddress;
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
            address = textBox1.Text;
            typeEquipment = comboBox2.Text;
            typeAccount = comboBox3.Text;
            brandEquipment = textBox5.Text;
            du = textBox3.Text;
            brandValves = textBox4.Text;
            note = textBox2.Text;
  
            connect.Equipment.Clear();
            connect.InsertToTableEquipment(customersId, address, typeEquipment, typeAccount, brandEquipment, du, brandValves, note);
            connect.ShowFieldsEquipment();
            OutputTable(connect.Equipment);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (label10.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                connect.Equipment.Clear();
                idEquipment = Convert.ToInt32(label10.Text);
                address = textBox1.Text;
                typeEquipment = comboBox2.Text;
                typeAccount = comboBox3.Text;
                brandEquipment = textBox5.Text;
                du = textBox3.Text;
                brandValves = textBox4.Text;
                note = textBox2.Text;
  
                connect.UpdateFromEquipment(idEquipment, customersId, address, typeEquipment, typeAccount, brandEquipment, du, brandValves, note);
                connect.ShowFieldsEquipment();
                OutputTable(connect.Equipment);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (label10.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                connect.Equipment.Clear();
                idEquipment = Convert.ToInt32(label10.Text);
                connect.DeleteFromTableEquipment(idEquipment);
                connect.ShowFieldsEquipment();
                OutputTable(connect.Equipment);
            }
        }


    }
}
