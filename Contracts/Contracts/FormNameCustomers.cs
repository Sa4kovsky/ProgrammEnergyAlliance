using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Contracts.Objects;

namespace Contracts
{
    public partial class FormNameCustomers : Form
    {
        public FormNameCustomers()
        {
            InitializeComponent();
            InitTable();
        }

        public void InitTable()
        {
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[7].Width = 96;
            dataGridView1.Columns[8].Width = 96;


            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[1].Name = "Учреждение";
            dataGridView1.Columns[2].Name = "ФИО (И.П)";
            dataGridView1.Columns[3].Name = "ФИО (Р.П)";
            dataGridView1.Columns[4].Name = "Должность (И.П)";
            dataGridView1.Columns[5].Name = "Должность (Р.П)";
            dataGridView1.Columns[6].Name = "Действ на осн";
            dataGridView1.Columns[7].Name = "Номер";
            dataGridView1.Columns[8].Name = "Дата";

            dataGridView1.Columns[0].Visible = false;
        }

        public void OutputTable(List<NameCustomers> executors)
        {
            dataGridView1.RowCount = executors.Count;
            for (int i = 0; i < executors.Count; i++)
            {
                dataGridView1[0, i].Value = executors[i].IdCustomer;
               
                dataGridView1[1, i].Value = executors[i].NameInstitution;
                dataGridView1[2, i].Value = executors[i].NameCustomer;
                dataGridView1[3, i].Value = executors[i].NameCustomerss;
                dataGridView1[4, i].Value = executors[i].PositionCustomer;
                dataGridView1[5, i].Value = executors[i].PositionCustomers;
                dataGridView1[6, i].Value = executors[i].ActingOnTheBasis;
                dataGridView1[7, i].Value = executors[i].Number;
                dataGridView1[8, i].Value = executors[i].Date;
            }
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    Id.Text = row.Cells[0].Value.ToString();
                if (row.Cells[1].Value != null)
                    comboBox3.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value != null)
                    textBox2.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value != null)
                    textBox3.Text = row.Cells[3].Value.ToString();
                if (row.Cells[4].Value != null)
                    comboBox2.Text = row.Cells[4].Value.ToString();
                if (row.Cells[5].Value != null)
                    textBox5.Text = row.Cells[5].Value.ToString();
                if (row.Cells[6].Value != null)
                    comboBox1.Text = row.Cells[6].Value.ToString();
                if (row.Cells[7].Value != null)
                    textBox6.Text = row.Cells[7].Value.ToString();
                if (row.Cells[8].Value != null)
                    textBox7.Text = row.Cells[8].Value.ToString();
            }
        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            textBox7.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private int flag = 0;

        private void button1_Click_1(object sender, EventArgs e)
        {
            flag++;
            if (flag == 1)
            {
                monthCalendar1.Visible = true;
            }
            else
            {
                flag = 0;
                monthCalendar1.Visible = false;
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Если в текстовом поле, отвечающем за поиск, что-то есть
                if (textSearch.TextLength > 0)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Selected = false;
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)

                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                                if (
                                    dataGridView1.Rows[i].Cells[j].Value.ToString()
                                        .ToLower()
                                        .Contains(textSearch.Text.ToLower()))
                                {
                                    dataGridView1.Rows[i].Selected = true;
                                    break;
                                }
                    }
                }
                else
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Selected = false;
                    }
                }
            }
        }

        private void FormNameCustomers_Load(object sender, EventArgs e)
        {
            flag = 0;
            monthCalendar1.Visible = false;
        }

        Connects connect = new Connects();

        private string  nameNameCustomer, nameNameCustomers, 
            positionNameCustomer, positionNameCustomers, actingOnTheBasis, number,date;

        private int id, idCustomers;

        private void InsertCustomer_Click(object sender, EventArgs e)
        {
            connect.NameCustomerses.Clear();
            nameNameCustomer = textBox2.Text;
            nameNameCustomers = textBox3.Text;
            positionNameCustomer = comboBox2.Text;
            positionNameCustomers = textBox5.Text;
            actingOnTheBasis = comboBox1.Text;
            number = textBox6.Text;
            date = textBox7.Text;
            connect.InsertToTableNameCustomer(idCustomers, nameNameCustomer,
                nameNameCustomers, positionNameCustomer, positionNameCustomers, actingOnTheBasis, number, date);
            connect.ShowFieldsNameCustomer();
            OutputTable(connect.NameCustomerses);
        }

        private void UpdateCustomer_Click(object sender, EventArgs e)
        {
            if (Id.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                id = Convert.ToInt32(Id.Text);
                connect.NameCustomerses.Clear();
                nameNameCustomer = textBox2.Text;
                nameNameCustomers = textBox3.Text;
                positionNameCustomer = comboBox2.Text;
                positionNameCustomers = textBox5.Text;
                actingOnTheBasis = comboBox1.Text;
                number = textBox6.Text;
                date = textBox7.Text;
                connect.UpdateFromTableNameCustomer(id, idCustomers, nameNameCustomer,
                    nameNameCustomers, positionNameCustomer, positionNameCustomers, actingOnTheBasis, number, date);
                connect.ShowFieldsNameCustomer();
                OutputTable(connect.NameCustomerses);
            }
        }

        private void DeleteCustomer_Click(object sender, EventArgs e)
        {
            if (Id.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                connect.NameCustomerses.Clear();
                id = Convert.ToInt32(Id.Text);
                connect.DeleteFromTableNameCustomer(id);
                connect.ShowFieldsNameCustomer();
                OutputTable(connect.NameCustomerses);
            }
        }

        private void comboBox3_Selected(object sender, EventArgs e)
        {
            this.comboBox3.Location = new System.Drawing.Point(991, 100);
            this.comboBox3.Size = new System.Drawing.Size(164, 24);
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            Customers customers = (Customers)comboBox3.SelectedItem;
            try
            {
                 idCustomers = customers.IdCustomer;
            }
            catch
            {
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox3_DropDownOpened(object sender, EventArgs e)
        {
            string s = comboBox3.Text;
            this.comboBox3.Location = new System.Drawing.Point(691, 100);
            this.comboBox3.Size = new System.Drawing.Size(464, 24);
            comboBox3.DataSource = null;
            comboBox3.Items.Clear();
            connect.Customerses.Clear();
            connect.ShowFieldsCustomersesSerch(s);
            Customer(connect.Customerses);
        }

        private void Customer(List<Customers> customers)
        {
            comboBox3.DataSource = customers;
            comboBox3.ValueMember = "IdCustomer";
            comboBox3.DisplayMember = "NameInstitution";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string[] sepa = { " " };
            string value = textBox2.Text;
            string[] wordsStrings = value.Split(sepa, StringSplitOptions.RemoveEmptyEntries);
            textBox3.Text = wordsStrings[1] + " " + wordsStrings[0];
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = comboBox2.Text.ToLower();
        }
    }
}
