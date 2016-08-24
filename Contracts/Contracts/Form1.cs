using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Contracts.Objects;
using Word = Microsoft.Office.Interop.Word;

namespace Contracts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitTable();
        }

        public void InitTable()
        {
            dataGridView1.ColumnCount = 32;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].Width = 200;
            dataGridView1.Columns[12].Width = 150;
            dataGridView1.Columns[13].Width = 150;
            dataGridView1.Columns[14].Width = 150;
            dataGridView1.Columns[15].Width = 150;
            dataGridView1.Columns[16].Width = 100;
            dataGridView1.Columns[17].Width = 200;
            dataGridView1.Columns[18].Width = 100;
            dataGridView1.Columns[19].Width = 100;
            dataGridView1.Columns[20].Width = 100;
            dataGridView1.Columns[21].Width = 100;
            dataGridView1.Columns[22].Width = 100;
            dataGridView1.Columns[23].Width = 100;
            dataGridView1.Columns[24].Width = 100;
            dataGridView1.Columns[25].Width = 100;
            dataGridView1.Columns[26].Width = 250;
            dataGridView1.Columns[27].Width = 100;
            dataGridView1.Columns[28].Width = 100;
            dataGridView1.Columns[29].Width = 100;
            dataGridView1.Columns[30].Width = 100;
            dataGridView1.Columns[31].Width = 100;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Name = "Номер договора";
            dataGridView1.Columns[2].Name = "Признак договора";
            dataGridView1.Columns[3].Name = "ФИО(И.П)";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Name = "ФИО (Р.П)";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Name = "Должность (И.П)";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Name = "Должность (Р.П)";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Name = "Действ. на осн.";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Name = "Номер";
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Name = "Дата";
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Name = "Финаннсирование";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Name = "Работы на объекте";
            dataGridView1.Columns[12].Name = "Дата начало работ";
            dataGridView1.Columns[13].Name = "Дата окончания работ";
            dataGridView1.Columns[14].Name = "Стоимость услуг";
            dataGridView1.Columns[15].Name = "Аванс";
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Name = "Сумма аванс";
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Name = "Учереждение";
            dataGridView1.Columns[18].Name = "ФИО(И.П)";
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Name = "ФИО(Р.П)";
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Name = "Должность (И.П)";
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Name = "Должность (Р.П)";
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Name = "Действ. на осн.";
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Name = "Номер";
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Name = "Дата";
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Name = "Юр. Адресс";
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Name = "Адресс Работ";
            dataGridView1.Columns[27].Name = "Банк";
            dataGridView1.Columns[27].Visible = false;
            dataGridView1.Columns[28].Name = "Р/С";
            dataGridView1.Columns[28].Visible = false;
            dataGridView1.Columns[29].Name = "УНП";
            dataGridView1.Columns[29].Visible = false;
            dataGridView1.Columns[30].Name = "УНП";
            dataGridView1.Columns[30].Visible = false;
            dataGridView1.Columns[31].Name = "ОКПО";
            dataGridView1.Columns[31].Visible = false;
        }

        public void OutputTable(List<ViewContracts> viewContracts)
        {
            dataGridView1.RowCount = viewContracts.Count;
            for (int i = 0; i < viewContracts.Count; i++)
            {
                dataGridView1[0, i].Value = viewContracts[i].IdContrects;
                dataGridView1[1, i].Value = viewContracts[i].NumberContrects;
                dataGridView1[2, i].Value = viewContracts[i].SignWork;
                dataGridView1[3, i].Value = viewContracts[i].NameExecutor;
                dataGridView1[4, i].Value = viewContracts[i].NameExecutors;
                dataGridView1[5, i].Value = viewContracts[i].PositionExecutor;
                dataGridView1[6, i].Value = viewContracts[i].PositionExecutors;
                dataGridView1[7, i].Value = viewContracts[i].ActingOnTheBasis;
                dataGridView1[8, i].Value = viewContracts[i].Number;
                dataGridView1[9, i].Value = viewContracts[i].Date;
                dataGridView1[10, i].Value = viewContracts[i].Financing;
                dataGridView1[11, i].Value = viewContracts[i].WorksType;
                dataGridView1[12, i].Value = viewContracts[i].DateStart;
                dataGridView1[13, i].Value = viewContracts[i].DateFinish;
                dataGridView1[14, i].Value = viewContracts[i].CostServices;
                dataGridView1[15, i].Value = viewContracts[i].Prepayment;
                dataGridView1[16, i].Value = viewContracts[i].SumPrepayment;
                dataGridView1[17, i].Value = viewContracts[i].NameInstitution;
                dataGridView1[18, i].Value = viewContracts[i].NameNameCustomer;
                dataGridView1[19, i].Value = viewContracts[i].NameNameCustomers;
                dataGridView1[20, i].Value = viewContracts[i].PositionNameCustomer;
                dataGridView1[21, i].Value = viewContracts[i].PositionNameCustomers;
                dataGridView1[22, i].Value = viewContracts[i].ActingOnTheBasisCustomer;
                dataGridView1[23, i].Value = viewContracts[i].NumberCustomer;
                dataGridView1[24, i].Value = viewContracts[i].DateCustomer;
                dataGridView1[25, i].Value = viewContracts[i].LegalAddress;
                dataGridView1[26, i].Value = viewContracts[i].AddressWork;
                dataGridView1[27, i].Value = viewContracts[i].CheckingAccount;
                dataGridView1[28, i].Value = viewContracts[i].NameBank;
                dataGridView1[29, i].Value = viewContracts[i].Mfo;
                dataGridView1[30, i].Value = viewContracts[i].Unp;
                dataGridView1[31, i].Value = viewContracts[i].Okpo;
            }
            dataGridView1.ClearSelection();
        }

        int flagButton = 0;

        private void Menu_Click(object sender, EventArgs e)
        {
            flagButton++;
            if (flagButton == 1)
            {
                panelMenu.Visible = true;
                flagButton++;
                this.Menu.Cursor = System.Windows.Forms.Cursors.PanWest;
            }
            else
            {
                this.Menu.Cursor = System.Windows.Forms.Cursors.PanEast;
                panelMenu.Visible = false;
                flagButton = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            treeView1.Visible = false;
            flagButton = 0;
            flagTree = 0;
        }

        int flagTree = 0;

        private void treeButton_Click(object sender, EventArgs e)
        {
            flagTree++;
            if (flagTree == 1)
            {
                treeView1.Visible = true;
                flagTree++;
                this.treeButton.Cursor = System.Windows.Forms.Cursors.PanEast;
            }
            else
            {
                this.treeButton.Cursor = System.Windows.Forms.Cursors.PanWest;
                treeView1.Visible = false;
                flagTree = 0;
            }
        }

        Connects connect = new Connects();

        private void connectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                    System.IO.StreamReader(openFileDialog1.FileName);
                MessageBox.Show(sr.ReadToEnd());

                connect.ConnectsSQL(openFileDialog1.FileName);
                sr.Close();
            }
            Menu.Enabled = true;
            treeButton.Enabled = true;
            comboBox2.Enabled = true;
            comboBox5.Enabled = true;
            comboBox1.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox6.Enabled = true;
            comboBox7.Enabled = true;
            comboBox8.Enabled = true;
            comboBox9.Enabled = true;
            Insert.Enabled = true;
            Update.Enabled = true;
            Delete.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = true;

            connect.ViewContractses.Clear();
            connect.ShowFieldsViewContractses();
            OutputTable(connect.ViewContractses);
        }

        FormExecutor formExecutor = new FormExecutor();

        private void buttonExecutor_Click(object sender, EventArgs e)
        {
            connect.Executors.Clear();
            connect.ShowFieldsExecutors();
            formExecutor.OutputTable(connect.Executors);
            formExecutor.ShowDialog();
        }

        FormWorks formWorks = new FormWorks();

        private void buttonWorkType_Click(object sender, EventArgs e)
        {
            connect.Works.Clear();
            connect.ShowFieldsWorks();
            formWorks.OutputTable(connect.Works);
            formWorks.ShowDialog();
        }

        FormCustomers formCustomers = new FormCustomers();

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            connect.Customerses.Clear();
            connect.ShowFieldsCustomerses();
            formCustomers.OutputTable(connect.Customerses);
            formCustomers.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    label16.Text = row.Cells[0].Value.ToString();
                if (row.Cells[1].Value != null)
                    textBox1.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value != null)
                    comboBox1.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value != null)
                    comboBox2.Text = row.Cells[3].Value.ToString();
                if (row.Cells[4].Value != null)
                    textBox3.Text = row.Cells[4].Value.ToString();
                if (row.Cells[5].Value != null)
                    textBox4.Text = row.Cells[5].Value.ToString();
                if (row.Cells[6].Value != null)
                    textBox5.Text = row.Cells[6].Value.ToString();
                if (row.Cells[7].Value != null)
                    textBox6.Text = row.Cells[7].Value.ToString();
                if (row.Cells[8].Value != null)
                    textBox7.Text = row.Cells[8].Value.ToString();
                if (row.Cells[9].Value != null)
                    textBox8.Text = row.Cells[9].Value.ToString();
                if (row.Cells[10].Value != null)
                    comboBox3.Text = row.Cells[10].Value.ToString();
                if (row.Cells[11].Value != null)
                    comboBox4.Text = row.Cells[11].Value.ToString();
                if (row.Cells[12].Value != null)
                    textBox9.Text = row.Cells[12].Value.ToString();
                if (row.Cells[13].Value != null)
                    comboBox10.Text = row.Cells[13].Value.ToString();
                if (row.Cells[14].Value != null)
                    textBox11.Text = row.Cells[14].Value.ToString();
                if (row.Cells[15].Value != null)
                    comboBox6.Text = row.Cells[15].Value.ToString();
                if (row.Cells[16].Value != null)
                    textBox13.Text = row.Cells[16].Value.ToString();
                if (row.Cells[17].Value != null)
                    comboBox5.Text = row.Cells[17].Value.ToString();
                if (row.Cells[18].Value != null)
                    comboBox7.Text = row.Cells[18].Value.ToString();
                if (row.Cells[19].Value != null)
                    textBox19.Text = row.Cells[19].Value.ToString();
                if (row.Cells[20].Value != null)
                    comboBox8.Text = row.Cells[20].Value.ToString();
                if (row.Cells[21].Value != null)
                    textBox17.Text = row.Cells[21].Value.ToString();
                if (row.Cells[22].Value != null)
                    textBox16.Text = row.Cells[22].Value.ToString();
                if (row.Cells[23].Value != null)
                    textBox15.Text = row.Cells[23].Value.ToString();
                if (row.Cells[24].Value != null)
                    textBox14.Text = row.Cells[24].Value.ToString();
                if (row.Cells[25].Value != null)
                    comboBox9.Text = row.Cells[25].Value.ToString();
                if (row.Cells[26].Value != null)
                    textBox23.Text = row.Cells[26].Value.ToString();
                if (row.Cells[27].Value != null)
                    textBox24.Text = row.Cells[27].Value.ToString();
                if (row.Cells[28].Value != null)
                    textBox25.Text = row.Cells[28].Value.ToString();
                if (row.Cells[29].Value != null)
                    textBox26.Text = row.Cells[29].Value.ToString();
                if (row.Cells[30].Value != null)
                    textBox27.Text = row.Cells[30].Value.ToString();
                if (row.Cells[31].Value != null)
                    textBox2.Text = row.Cells[31].Value.ToString();
            }
        }

        private int executorid, customersId, IdnameCustomer, worksId, numberContrects, id;
        string signWork, financing, dateStart, dateFinish, costServices, prepayment, sumPrepayment, addressWork;

        #region combobox2

        private void comboBox2_Selected(object sender, EventArgs e)
        {
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            Executor executor = (Executor) comboBox2.SelectedItem;
            try
            {
                executorid = executor.IdExecutor;
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
            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
            connect.Executors.Clear();
            connect.ShowFieldsExecutors();
            Executors(connect.Executors);
        }

        private void Executors(List<Executor> executors)
        {
            comboBox2.DataSource = executors;
            comboBox2.ValueMember = "IdExecutor";
            comboBox2.DisplayMember = "NameExecutor";
        }

        #endregion

        #region combobox4

        private void comboBox4_Selected(object sender, EventArgs e)
        {
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            Works works = (Works) comboBox4.SelectedItem;
            try
            {
                worksId = works.IdWorks;
            }
            catch
            {
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox4_DropDownOpened(object sender, EventArgs e)
        {
            comboBox4.DataSource = null;
            comboBox4.Items.Clear();
            connect.Works.Clear();
            connect.ShowFieldsWorks();
            Work(connect.Works);
        }

        private void Work(List<Works> workses)
        {
            comboBox4.DataSource = workses;
            comboBox4.ValueMember = "IdWorks";
            comboBox4.DisplayMember = "WorksType";
        }

        #endregion

        #region combobox5

        private int name;

        private void comboBox5_Selected(object sender, EventArgs e)
        {
            this.comboBox5.Location = new System.Drawing.Point(694, 399);
            this.comboBox5.Size = new System.Drawing.Size(483, 24);
            comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            Customers customers = (Customers) comboBox5.SelectedItem;
            try
            {
                customersId = customers.IdCustomer;
                name = customers.IdCustomer;
                comboBox9.Text = customers.LegalAddress;
                textBox23.Text = customers.AddressWork;
            }
            catch
            {
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox5_DropDownOpened(object sender, EventArgs e)
        {
            string s = comboBox5.Text;
            this.comboBox5.Location = new System.Drawing.Point(426, 399);
            this.comboBox5.Size = new System.Drawing.Size(751, 24);
            comboBox5.DataSource = null;
            comboBox5.Items.Clear();
            connect.Customerses.Clear();
            connect.ShowFieldsCustomersesSerch(s);
            Custom(connect.Customerses);
        }

        private void Custom(List<Customers> customerses)
        {
            comboBox5.DataSource = customerses;
            comboBox5.ValueMember = "IdCustomer";
            comboBox5.DisplayMember = "NameInstitution";
        }

        #endregion

        #region combobox7

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_Selected(object sender, EventArgs e)
        {
            comboBox7.SelectedIndexChanged += comboBox7_SelectedIndexChanged;
            NameCustomerSelect nameCustomerSelect = (NameCustomerSelect) comboBox7.SelectedItem;
            try
            {
                IdnameCustomer = nameCustomerSelect.Id;
                comboBox8.Text = nameCustomerSelect.PositionNameCustomer;
            }
            catch
            {
            }
        }

        private void comboBox7_DropDownOpened(object sender, EventArgs e)
        {
            comboBox7.DataSource = null;
            comboBox7.Items.Clear();
            connect.NameCustomerSelectses.Clear();
            connect.ShowFieldsNameCustomerSelect(name);
            NameCustom(connect.NameCustomerSelectses);
        }

        private void NameCustom(List<NameCustomerSelect> nameCustomerSelects)
        {
            comboBox7.DataSource = nameCustomerSelects;
            comboBox7.ValueMember = "Id";
            comboBox7.DisplayMember = "Name";
        }

        #endregion

        #region combobox8

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_Selected(object sender, EventArgs e)
        {
            comboBox8.SelectedIndexChanged += comboBox8_SelectedIndexChanged;
            NameCustomerSelect nameCustomerSelect = (NameCustomerSelect) comboBox8.SelectedItem;
            try
            {
                IdnameCustomer = nameCustomerSelect.Id;
                comboBox7.Text = nameCustomerSelect.Name;
            }
            catch
            {
            }
        }

        private void comboBox8_DropDownOpened(object sender, EventArgs e)
        {
            comboBox8.DataSource = null;
            comboBox8.Items.Clear();
            connect.NameCustomerSelectses.Clear();
            connect.ShowFieldsNameCustomerSelect(name);
            PositionCustom(connect.NameCustomerSelectses);
        }

        private void PositionCustom(List<NameCustomerSelect> positionNameCustomer)
        {
            comboBox8.DataSource = positionNameCustomer;
            comboBox8.ValueMember = "Id";
            comboBox8.DisplayMember = "PositionNameCustomer";
        }

        #endregion

        #region combobox9

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_Selected(object sender, EventArgs e)
        {
            comboBox9.SelectedIndexChanged += comboBox9_SelectedIndexChanged;
            Customers customers = (Customers) comboBox9.SelectedItem;
            try
            {
                customersId = customers.IdCustomer;
                name = customers.IdCustomer;
                comboBox5.Text = customers.NameInstitution;
                textBox23.Text = customers.AddressWork;
            }
            catch
            {
            }
        }

        private void comboBox9_DropDownOpened(object sender, EventArgs e)
        {
            comboBox9.DataSource = null;
            comboBox9.Items.Clear();
            connect.Customerses.Clear();
            connect.ShowFieldsCustomerses();
            CustomAddress(connect.Customerses);
        }

        private void CustomAddress(List<Customers> CustomAddress)
        {
            comboBox9.DataSource = CustomAddress;
            comboBox9.ValueMember = "IdCustomer";
            comboBox9.DisplayMember = "LegalAddress";
        }


        #endregion

        int flag = 0;

        private void button1_Click(object sender, EventArgs e)
        {

            flag++;
            if (flag == 1)
            {
                this.textBox23.Size = new System.Drawing.Size(1020, 545);
                this.textBox23.Location = new System.Drawing.Point(120, 2);
                flag++;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanSouth;
            }
            else
            {
                this.textBox23.Location = new System.Drawing.Point(118, 518);
                this.textBox23.Size = new System.Drawing.Size(1021, 24);
                flag = 0;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanNorth;
            }

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            connect.ViewContractses.Clear();
            Clor();
            signWork = comboBox1.Text;
            financing = comboBox3.Text;
            dateStart = textBox9.Text;
            dateFinish = comboBox10.Text;
            costServices = textBox11.Text;
            prepayment = comboBox6.Text;
            sumPrepayment = textBox13.Text;
            addressWork = textBox23.Text;
            connect.InsertToTableViewContractses(numberContrects, signWork, executorid, customersId, IdnameCustomer,
                financing, worksId,
                dateStart, dateFinish, costServices, prepayment, sumPrepayment, addressWork);

            connect.ShowFieldsViewContractses();
            OutputTable(connect.ViewContractses);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (label16.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                Clor();
                connect.Executors.Clear();
                id = Convert.ToInt32(label16.Text);
                connect.ViewContractses.Clear();
                numberContrects = Convert.ToInt32(textBox1.Text);
                signWork = comboBox1.Text;
                financing = comboBox3.Text;
                dateStart = textBox9.Text;
                dateFinish = comboBox10.Text;
                costServices = textBox11.Text;
                prepayment = comboBox6.Text;
                sumPrepayment = textBox13.Text;
                addressWork = textBox23.Text;
                connect.UpdateFromTableViewContractses(id, numberContrects, signWork, executorid, customersId,
                    IdnameCustomer, financing, worksId,
                    dateStart, dateFinish, costServices, prepayment, sumPrepayment, addressWork);

                connect.ShowFieldsViewContractses();
                OutputTable(connect.ViewContractses);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (label16.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                connect.ViewContractses.Clear();
                id = Convert.ToInt32(label16.Text);
                connect.DeleteFromTableViewContractses(id);
                connect.ShowFieldsViewContractses();
                OutputTable(connect.ViewContractses);
            }
        }

        private void Clor()
        {
            if (textBox1.Text != "")
            {
                numberContrects = Convert.ToInt32(textBox1.Text);
                textBox1.BackColor = Color.White;
            }
            else
            {
                textBox1.BackColor = Color.Brown;
            }
            if (Convert.ToString(executorid) != "0")
            {
                comboBox2.BackColor = Color.White;
            }
            else
            {
                comboBox2.BackColor = Color.Brown;
            }
            if (Convert.ToString(customersId) != "0")
            {
                comboBox5.BackColor = Color.White;
            }
            else
            {
                comboBox5.BackColor = Color.Brown;
            }
            if (Convert.ToString(IdnameCustomer) != "0")
            {
                comboBox7.BackColor = Color.White;
            }
            else
            {
                comboBox7.BackColor = Color.Brown;
            }
            if (Convert.ToString(worksId) != "0")
            {
                comboBox4.BackColor = Color.White;
            }
            else
            {
                comboBox4.BackColor = Color.Brown;
            }
        }

        int flag1 = 0, flag2 = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            flag1++;
            if (flag1 == 1)
            {
                monthCalendar1.Visible = true;
            }
            else
            {
                flag1 = 0;
                monthCalendar1.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag2++;
            if (flag2 == 1)
            {
                monthCalendar2.Visible = true;
            }
            else
            {
                flag2 = 0;
                monthCalendar2.Visible = false;
            }
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            comboBox10.Text = monthCalendar2.SelectionStart.ToLongDateString();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox9.Text = monthCalendar1.SelectionStart.ToLongDateString();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text == "от стоимости услуг")
            {
                textBox13.Text = "50% ";
            }
            else
            {
                textBox13.Text = "";
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            flag2 = 0;
            flag1 = 0;
            monthCalendar2.Visible = false;
            monthCalendar1.Visible = false;
            this.textBox23.Location = new System.Drawing.Point(118, 518);
            this.textBox23.Size = new System.Drawing.Size(1021, 24);
            flag = 0;

            this.button1.Cursor = System.Windows.Forms.Cursors.PanNorth;
        }

        private int val, cop;

        private string vall, copp;

        private void BelRub(int val)
        {
            if (val%100 > 10 && val%100 < 21)
            {
                vall = Money.Str(val) + "белорусских рублей";
            }
            else if (val%10 > 1)
            {
                if (val%10 < 5)
                {
                    vall = Money.Str(val) + "белорусских рубля";
                }
                else
                {
                    vall = Money.Str(val) + "белорусских рублей";
                }
            }
            else if (val%10 == 1)
            {
                vall = Money.Str(val) + "белорусский рубль";
            }
            else 
            {
                vall = Money.Str(val) + "белорусских рублей";
            }
        }

        private void BelRubCop(int cop)
        {
            if (cop % 100 > 10 && cop % 100 < 21)
            {
                copp = cop + " копеек";
            }
            else if (cop % 10 > 1)
            {
                if (cop % 10 < 5)
                {
                    copp = cop + " копейки";
                }
                else
                {
                    copp = cop + " копеек";
                }
            }
            else if (cop % 10 == 1)
            {
                copp = cop + " копейка";
            }
            else
            {
                copp = cop + " копеек";
            }
        }
   
        void PerevodCost()
        {
            if (textBox11.Text.Length == 0) return;
            string[] sepa = { "," };
            string value = textBox11.Text;
            if (value.Contains(","))
            {
                string[] wordsStrings = value.Split(sepa, StringSplitOptions.RemoveEmptyEntries);
                val = int.Parse(wordsStrings[0]);
                cop = int.Parse(wordsStrings[1]);
                BelRubCop(cop);
                BelRub(val);
            }
            else
            {
                int val = int.Parse(value);
                BelRub(val);
            }
        }

        private double avans;
        void PerevodAvans()
        {
            if (comboBox6.Text == "от стоимости услуг")
            {
                if (textBox13.Text.Length == 0) return;
                double cost = Convert.ToDouble(textBox11.Text);
                string[] sepas = { "%" };
                string values = textBox13.Text;
                int valu = 0;
                if (values.Contains("%"))
                {
                    string[] wordsStrings = values.Split(sepas, StringSplitOptions.RemoveEmptyEntries);
                    valu = int.Parse(wordsStrings[0]);
                }
                avans = Money.Round((cost * valu * 0.01),2);
                string[] sepa = {","};
                string value = avans.ToString();
                if (value.Contains(","))
                {
                    string[] wordsStrings = value.Split(sepa, StringSplitOptions.RemoveEmptyEntries);
                    val = int.Parse(wordsStrings[0]);
                    cop = int.Parse(wordsStrings[1]);
                    BelRubCop(cop);
                    BelRub(val);
                }
                else
                {
                    int val = int.Parse(value);
                    BelRub(val);
                }
            }
            else
            {
                if (textBox13.Text.Length == 0) return;
                string[] sepa = { "," };
                string value = textBox13.Text;
                avans = Convert.ToDouble(textBox13.Text);
                if (value.Contains(","))
                {
                    string[] wordsStrings = value.Split(sepa, StringSplitOptions.RemoveEmptyEntries);
                    val = int.Parse(wordsStrings[0]);
                    cop = int.Parse(wordsStrings[1]);
                    BelRubCop(cop);
                    BelRub(val);
                }
                else
                {
                    int val = int.Parse(value);
                    BelRub(val);
                }
            }
        }

        ScoreForm scoreForm = new ScoreForm();
        private void button4_Click(object sender, EventArgs e)
        {
            scoreForm.ShowDialog();
        }

        FormDevicesAccounting formDevices = new FormDevicesAccounting();
        private void button5_Click(object sender, EventArgs e)
        {
            connect.DevaisesMaterialses.Clear();
            connect.ShowFieldsDevaisesMaterialses();
            formDevices.OutputTable(connect.DevaisesMaterialses);
            formDevices.ShowDialog(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connect.ViewContractses.Clear();
          connect.ShowFieldsViewContractses();
            OutputTable(connect.ViewContractses);
        }

        Word._Application oWord; // создаем новый экземпляр ворда

        private bool chek, chek1, chek2, chek3;
        private void оказанияУслугToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chek = true;
            oWord = new Word.Application();
            oWord.Visible = true;
            Word._Document oDoc =
                    GetDoc("d:\\GomelEnergyAlliance\\Shablon\\1 договор оказания услуг поверка.docx");
            
        }

        private Word._Document GetDoc(string path)
        {
            Word._Document oDoc = oWord.Documents.Add(path);
            SetTemplate(oDoc);
            return oDoc;
        }

        // Замена закладки SECONDNAME на данные введенные в textBox
        private void SetTemplate(Word._Document oDoc)
        {
            oDoc.Bookmarks["НомерДоговора"].Range.Text = textBox1.Text;
            oDoc.Bookmarks["ПризнакРабот"].Range.Text = comboBox1.Text;
            oDoc.Bookmarks["ДатаВерхнийПравый"].Range.Text = textBox9.Text;
            oDoc.Bookmarks["ДолжностьИсполнителяРп"].Range.Text = textBox5.Text;
            oDoc.Bookmarks["ФИОИсполнителяРп"].Range.Text = textBox3.Text;
            oDoc.Bookmarks["ДействующегоИсполнитель"].Range.Text = textBox6.Text;
            if (textBox7.Text != "")
            {
                oDoc.Bookmarks["ДействующегоИсполнительНомер"].Range.Text = "№ " + textBox7.Text;
                oDoc.Bookmarks["ДействующегоИсполнительДата"].Range.Text = "от " + textBox8.Text + "г.";
            }
            else
            {
                oDoc.Bookmarks["ДействующегоИсполнительНомер"].Range.Text = "";
                oDoc.Bookmarks["ДействующегоИсполнительДата"].Range.Text = "";
            }
            oDoc.Bookmarks["Учреждение"].Range.Text = comboBox5.Text;
            oDoc.Bookmarks["ДолжностьЗаказчикаРп"].Range.Text = textBox17.Text;
            oDoc.Bookmarks["ФИОЗаказчикаРп"].Range.Text = textBox19.Text;
            oDoc.Bookmarks["ДействующегоЗаказчик"].Range.Text = textBox16.Text;
            if (textBox15.Text != "")
            {
                oDoc.Bookmarks["ДействующегоЗаказчикНомер"].Range.Text = "№ " + textBox15.Text;
                oDoc.Bookmarks["ДействующегоЗаказчикДата"].Range.Text = "от " + textBox14.Text + "г.";
            }
            else
            {
                oDoc.Bookmarks["ДействующегоЗаказчикНомер"].Range.Text = "";
                oDoc.Bookmarks["ДействующегоЗаказчикДата"].Range.Text = "";
            }
            oDoc.Bookmarks["Работа"].Range.Text = comboBox4.Text;
            if (textBox23.Text != "")
            {
                oDoc.Bookmarks["АдресРабота"].Range.Text = textBox23.Text;
            }
            else
            {
                oDoc.Bookmarks["АдресРабота"].Range.Text = "";
            }
            oDoc.Bookmarks["Финансирование"].Range.Text = comboBox3.Text;
            oDoc.Bookmarks["ДатаНачалоРабот"].Range.Text = textBox9.Text;
            oDoc.Bookmarks["ДатаОкончанияРабот"].Range.Text = comboBox10.Text;
            PerevodCost();
            oDoc.Bookmarks["СтоимостьУслуг"].Range.Text = textBox11.Text;
            oDoc.Bookmarks["СтоимостьУслугБуквами"].Range.Text = vall + " " + copp;
            if (chek == true || chek1 == true || chek2 == true || chek3 == true)
            {     
                oDoc.Bookmarks["Аванс"].Range.Text = comboBox6.Text;
                PerevodAvans();
                oDoc.Bookmarks["АвансСумма"].Range.Text = avans.ToString();
                oDoc.Bookmarks["ПроцентАванса"].Range.Text = textBox13.Text;
                oDoc.Bookmarks["АвансСуммаБуква"].Range.Text = vall + " " + copp;
            }
            oDoc.Bookmarks["УчереждениеЗаказчик"].Range.Text = comboBox5.Text;
            oDoc.Bookmarks["ЮрАдрес"].Range.Text = comboBox9.Text;
            oDoc.Bookmarks["РС"].Range.Text = textBox24.Text;
            oDoc.Bookmarks["Банк"].Range.Text = textBox25.Text;
            oDoc.Bookmarks["МФО"].Range.Text = textBox26.Text;
            oDoc.Bookmarks["УНП"].Range.Text = textBox27.Text;
            if (textBox2.Text != "")
            {
                oDoc.Bookmarks["ОКПО"].Range.Text = "ОКПО" + textBox2.Text;
            }
            else
            { 
                oDoc.Bookmarks["ОКПО"].Range.Text = "";
            }
            oDoc.Bookmarks["ДолжностьИсполнителяИп"].Range.Text = textBox4.Text;
            oDoc.Bookmarks["ФИОИсполнителяИп"].Range.Text = comboBox2.Text;
            oDoc.Bookmarks["ДолжностьЗаказчикИп"].Range.Text = comboBox8.Text;
            oDoc.Bookmarks["ФИОЗаказчикаИп"].Range.Text = comboBox7.Text;
        }

        private void оказанияУслугБюджетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oWord = new Word.Application();
            oWord.Visible = true;
            Word._Document oDoc =
                    GetDoc("d:\\GomelEnergyAlliance\\Shablon\\2 договор оказания услуг поверка бюджет.docx");
        }
        
        FormEquipment formEquipment = new FormEquipment();
        private void button7_Click(object sender, EventArgs e)
        {
            connect.Equipment.Clear();
            connect.ShowFieldsEquipment();
            formEquipment.OutputTable(connect.Equipment);
            formEquipment.ShowDialog();
        }

        private void оказанияУслугToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            chek1 = true;
            oWord = new Word.Application();
            oWord.Visible = true;
            Word._Document oDoc =
                    GetDoc("d:\\GomelEnergyAlliance\\Shablon\\3 договор оказания услуг промывка.docx");
        }

        private void оказанияУслугБюджетToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            oWord = new Word.Application();
            oWord.Visible = true;
            Word._Document oDoc =
                    GetDoc("d:\\GomelEnergyAlliance\\Shablon\\4 договор оказания услуг промывка бюджет.docx");
        }

        private void оказанияУслугToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            chek2 = true;
            oWord = new Word.Application();
            oWord.Visible = true;
            Word._Document oDoc =
                    GetDoc("d:\\GomelEnergyAlliance\\Shablon\\5 договор оказания услуг наладка регулятора.docx");
        }

        private void оказанияУслугБюджетToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            oWord = new Word.Application();
            oWord.Visible = true;
            Word._Document oDoc =
                    GetDoc("d:\\GomelEnergyAlliance\\Shablon\\6 договор оказания услуг наладка регулятора бюджет.docx");
        }

        private void оказанияУслугToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            chek3 = true;
            oWord = new Word.Application();
            oWord.Visible = true;
            Word._Document oDoc =
                    GetDoc("d:\\GomelEnergyAlliance\\Shablon\\8 договор оказания услуг сантехника.docx");
        }

        private void оказанияУслугБюджетToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            oWord = new Word.Application();
            oWord.Visible = true;
            Word._Document oDoc =
                    GetDoc("d:\\GomelEnergyAlliance\\Shablon\\7 договор оказания услуг сантехника бюджет.docx");
        }
    }
}


