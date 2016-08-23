using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Contracts.Objects;

namespace Contracts
{
    public partial class FormCustomers : Form
    {
        public FormCustomers()
        {
            InitializeComponent();
            InitTable();
        }

        public void InitTable()
        {
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[7].Width = 90;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Name = "Учреждение";
            dataGridView1.Columns[2].Name = "Юр. Адрес";
            dataGridView1.Columns[3].Name = "Адрес где производятся работы";
            dataGridView1.Columns[4].Name = "Расчетный Счет";
            dataGridView1.Columns[5].Name = "Банк";
            dataGridView1.Columns[6].Name = "УНП";
            dataGridView1.Columns[7].Name = "ОКПО";
        }

        public void OutputTable(List<Customers> customerses)
        {
            dataGridView1.RowCount = customerses.Count;
            for (int i = 0; i < customerses.Count; i++)
            {
                dataGridView1[0, i].Value = customerses[i].IdCustomer;
                dataGridView1[1, i].Value = customerses[i].NameInstitution;
                dataGridView1[2, i].Value = customerses[i].LegalAddress;
                dataGridView1[3, i].Value = customerses[i].AddressWork;
                dataGridView1[4, i].Value = customerses[i].CheckingAccount;
                dataGridView1[5, i].Value = customerses[i].NameBank;
                dataGridView1[6, i].Value = customerses[i].Unp;
                dataGridView1[7, i].Value = customerses[i].Okpo;
            }
            dataGridView1.ClearSelection();
        }

        int flagButton = 0;

        private void button1_Click_1(object sender, EventArgs e)
        {
            flagButton++;
            if (flagButton == 1)
            {
                panel1.Visible = true;
                flagButton++;
                this.button1.Cursor = System.Windows.Forms.Cursors.PanSouth;            
            }
            else
            {
                panel1.Visible = false;
                flagButton = 0;
                this.button1.Cursor = System.Windows.Forms.Cursors.PanNorth;
            }
        }

        Connects connects = new Connects();

        FormNameCustomers formNameCustomers = new FormNameCustomers();
        private void buttonExecutor_Click(object sender, EventArgs e)
        {
            connects.NameCustomerses.Clear();
            connects.ShowFieldsNameCustomer();
            formNameCustomers.OutputTable(connects.NameCustomerses);
            formNameCustomers.ShowDialog();
        }

        FormBanks formBanks = new FormBanks();
        private void button2_Click(object sender, EventArgs e)
        {
            connects.Bankses.Clear();
            connects.ShowFieldsBank();
            formBanks.OutputTable(connects.Bankses);
            formBanks.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    Id.Text = row.Cells[0].Value.ToString();
                if (row.Cells[1].Value != null)
                    textBox1.Text = row.Cells[1].Value.ToString(); 
                if (row.Cells[2].Value != null)
                    textBox3.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value != null)
                    textBox4.Text = row.Cells[3].Value.ToString();
                if (row.Cells[4].Value != null)
                    textBox5.Text = row.Cells[4].Value.ToString();
                if (row.Cells[5].Value != null)
                    comboBox2.Text = row.Cells[5].Value.ToString();
                if (row.Cells[6].Value != null)
                    textBox2.Text = row.Cells[6].Value.ToString();
                if (row.Cells[7].Value != null)
                    textBox7.Text = row.Cells[7].Value.ToString();
            }
        }

        #region comboBox2
        private void comboBox2_Selected(object sender, EventArgs e)
        {
            this.comboBox2.Location = new System.Drawing.Point(992, 217);
            this.comboBox2.Size = new System.Drawing.Size(255, 24);

            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            Banks banks = (Banks)comboBox2.SelectedItem;           
            try
            {
                idBank = banks.IdBank;
            }
            catch
            {
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_DropDownOpened(object sender, EventArgs e)
        {
            string s = comboBox2.Text;
            comboBox2.SelectedItem = null;
            comboBox2.SelectedText = null;  
            this.comboBox2.Location = new System.Drawing.Point(605, 217);
            this.comboBox2.Size = new System.Drawing.Size(642, 24);
            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
            connects.Bankses.Clear();
            connects.ShowFieldsBankSearch(s);
            Financing(connects.Bankses);
        }

        private void Financing(List<Banks> bankses)
        {
            comboBox2.DataSource = bankses;
            comboBox2.ValueMember = "IdBank";
            comboBox2.DisplayMember = "NameBank";
        }
#endregion

        #region comboBox1
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Selected(object sender, EventArgs e)
        {
       /*     comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            NameCustomerSelect nameCustomer = (NameCustomerSelect)comboBox1.SelectedItem;
            try
                {
                    idNameCustomer = nameCustomer.Id;
                }
                catch
                {    
                }         */
        }

        private void comboBox1_DropDownOpened(object sender, EventArgs e)
        {
         /*   string nameInstitution;
            nameInstitution = textBox1.Text;
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();           
            connects.NameCustomerSelectses.Clear();
            connects.ShowFieldsNameCustomerSelect(nameInstitution);
            NameCustomerSelect(connects.NameCustomerSelectses);*/
        }

        private void NameCustomerSelect(List<NameCustomerSelect> nameCustomerSelects)
        {
          /*  comboBox1.DataSource = nameCustomerSelects;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";*/
        }
#endregion

        Connects connect = new Connects();

        private int id, idBank;
        private string nameInstitution;
        private string LegalAddress;
        private string addressWork;
        private string checkingAccount;
        private string unp;
        private string okpo;
        private void InsertExecutor_Click(object sender, EventArgs e)
        {
            connect.Customerses.Clear();
            nameInstitution = textBox1.Text;   
            LegalAddress = textBox3.Text;
            addressWork = textBox4.Text;
            checkingAccount = textBox5.Text;
            unp = textBox2.Text;
            okpo = textBox7.Text;
            connect.InsertToTableCustomerses(nameInstitution, LegalAddress, addressWork,
                checkingAccount, idBank, unp, okpo);
            connect.ShowFieldsCustomerses();
            OutputTable(connect.Customerses);
        }

        private void UpdateExecutor_Click(object sender, EventArgs e)
        {
            if (Id.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                id = Convert.ToInt32(Id.Text);
                connect.Customerses.Clear();
                nameInstitution = textBox1.Text;
                LegalAddress = textBox3.Text;
                addressWork = textBox4.Text;
                checkingAccount = textBox5.Text;
                unp = textBox2.Text;
                okpo = textBox7.Text;
                connect.UpdateFromTableCustomerses(id,nameInstitution, LegalAddress, addressWork,
                    checkingAccount, idBank, unp, okpo);
                connect.ShowFieldsCustomerses();
                OutputTable(connect.Customerses);
            }
        }

        private void DeleteExecutor_Click(object sender, EventArgs e)
        {
            if (Id.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                connect.Customerses.Clear();
                id = Convert.ToInt32(Id.Text);
                connect.DeleteFromTableCustomerses(id);
                connect.ShowFieldsCustomerses();
                OutputTable(connect.Customerses);
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
            }
        }

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            flagButton = 0;
            this.button1.Cursor = System.Windows.Forms.Cursors.PanNorth;
        }

        private int flag;
        private void button3_Click(object sender, EventArgs e)
        {
            flag++;
            if (flag == 1)
            {
                this.textBox4.Size = new System.Drawing.Size(417, 123);
                this.textBox4.Location = new System.Drawing.Point(792, 59);
                flag++;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanSouth;
            }
            else
            {
                this.textBox4.Size = new System.Drawing.Size(217, 23);
                this.textBox4.Location = new System.Drawing.Point(992, 159);
                flag = 0;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanNorth;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 9)
            {
                MessageBox.Show("А по рукам!!! Объяснительную мигом !!! Не больше 9 знаков, пожалуйста.");
                textBox2.BackColor = Color.DarkRed;
            }
            else
            {
                textBox2.BackColor = Color.White;
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.TextLength > 13)
            {
                MessageBox.Show("А по рукам!!! Объяснительную мигом !!! Не больше 9 знаков, пожалуйста.");
                textBox5.BackColor = Color.DarkRed;
            }
            else
            {
                textBox5.BackColor = Color.White;
            }
        }
    }
}
