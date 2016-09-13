using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Contracts.Objects;
using Excel = Microsoft.Office.Interop.Excel;

namespace Contracts
{
    public partial class ScoreForm : Form
    {
        public ScoreForm()
        {

            InitializeComponent();
            InitTable();
        }

        public void InitTable()
        {
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 275;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[6].Width = 90;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Name = "Учреждение";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Name = "Адрес";
            dataGridView1.Columns[3].Name = "Однопоточ";
            dataGridView1.Columns[4].Name = "Двухпоточ";
            dataGridView1.Columns[5].Name = "Трехпоточ";
            dataGridView1.Columns[6].Name = "Манометры";
        }

        public void OutputTable(List<Score> scores)
        {
            dataGridView1.RowCount = scores.Count;
            for (int i = 0; i < scores.Count; i++)
            {
                dataGridView1[0, i].Value = scores[i].IdScore;
                dataGridView1[1, i].Value = scores[i].IdContrects;
                dataGridView1[2, i].Value = scores[i].Address;
                dataGridView1[3, i].Value = scores[i].OneFlow;
                dataGridView1[4, i].Value = scores[i].TwoFlow;
                dataGridView1[5, i].Value = scores[i].ThreeFlow;
                dataGridView1[6, i].Value = scores[i].Manometer;
            }
            dataGridView1.ClearSelection();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    IDContracts.Text = row.Cells[0].Value.ToString();
                if (row.Cells[1].Value != null)
                 //   comboBox1.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value != null)
                    textBoxAddress.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value != null)
                    numericUpDown3.Text = row.Cells[3].Value.ToString();
                if (row.Cells[4].Value != null)
                    numericUpDown4.Text = row.Cells[4].Value.ToString();
                if (row.Cells[5].Value != null)
                    numericUpDown5.Text = row.Cells[5].Value.ToString();
                if (row.Cells[6].Value != null)
                    numericUpDown6.Text = row.Cells[6].Value.ToString();
            }
        }

        Connects connect = new Connects();


        #region combobox2

        private int name, id;

        private void comboBox2_Selected(object sender, EventArgs e)
        {
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            SelectDateView selecteDateView = (SelectDateView) comboBox2.SelectedItem;
            try
            {
                id = selecteDateView.Id;
                label4.Text = "№ " + Convert.ToString(selecteDateView.Number) + selecteDateView.SignWork;
                label112.Text = selecteDateView.DateStart;
                label113.Text = selecteDateView.LLegalAddress;
                label114.Text = selecteDateView.Unp;
                label115.Text = selecteDateView.CheckingAccount;
                label116.Text = selecteDateView.NameBank;
                label117.Text = selecteDateView.AddressBank;
                label118.Text = selecteDateView.NameNameCustomer;
                label119.Text = selecteDateView.PositionNameCustomer;
                label120.Text = selecteDateView.NameExecutor;
                label121.Text = selecteDateView.PositionExecutor;
                label122.Text = selecteDateView.Okpo;
                connect.Scores.Clear();
                connect.ShowFieldsScore(id);
                OutputTable(connect.Scores);
                int f = 0, z = 0;
                int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    sum2 += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                    sum3 += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                    sum4 += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                }
                numericUpDown3.Value = sum1;
                numericUpDown4.Value = sum2;
                numericUpDown5.Value = sum3;
                numericUpDown6.Value = sum4;
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
            name = Convert.ToInt32(numericUpDown1.Text);
            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
            connect.SelectDateViewse.Clear();
            connect.ShowFieldsSelectDate(name,s);
            SelectViewDate(connect.SelectDateViewse);
        }

        private void SelectViewDate(List<SelectDateView> selectDateViews)
        {
            comboBox2.DataSource = selectDateViews;
            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "Name";
        }

        #endregion

        #region combobox1

        private int name1;

    /*    private void comboBox1_Selected(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            SelectDateView selecteDateView = (SelectDateView) comboBox1.SelectedItem;
            try
            {
                label10.Text = "Договор № " + Convert.ToString(selecteDateView.Number) + selecteDateView.SignWork;
                textBoxAddress.Text = selecteDateView.Address;
                idContrects = selecteDateView.Id;
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
            string s = comboBox1.Text;
            name1 = Convert.ToInt32(numericUpDown2.Text);
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            connect.SelectDateViewse.Clear();
            connect.ShowFieldsSelectDate(name1,s);
            SelectViewDate2(connect.SelectDateViewse);
        }

        private void SelectViewDate2(List<SelectDateView> selectDateViews)
        {
            comboBox1.DataSource = selectDateViews;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
        }*/      
        #endregion

        private int flag;

        private void button1_Click(object sender, EventArgs e)
        {
            flag++;
            if (flag == 1)
            {

                textBoxAddress.Text = AddressLable.Text;

                this.textBoxAddress.Size = new System.Drawing.Size(585, 320);
                this.textBoxAddress.Location = new System.Drawing.Point(32, 181);
                flag++;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanSouth;
            }
            else
            {
                this.textBoxAddress.Size = new System.Drawing.Size(485, 20);
                this.textBoxAddress.Location = new System.Drawing.Point(132, 481);

                flag = 0;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanNorth;
            }
        }

        private string address;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            address = textBoxAddress.Text;
            name1 = Convert.ToInt32(DataLable.Text);
            connect.TypeCounter.Clear();
            connect.TypeCounterTwo.Clear();
            connect.TypeCounterThree.Clear();
            connect.Manometr.Clear();
            connect.ShowFieldsTypeCounterOne(address, name1);
            connect.ShowFieldsTypeCounterTwo(address, name1);
            connect.ShowFieldsTypeCounterThree(address, name1);
            connect.ShowFieldsManometr(address, name1);
            Type1(connect.TypeCounter);
            Type2(connect.TypeCounterTwo);
            Type3(connect.TypeCounterThree);
            Type4(connect.Manometr);
        }

        public void Type1(List<TypeCounterOne> typeCounterOne)
        {
            for (int i = 0; i < typeCounterOne.Count; i++)
            {
                numericUpDown3.Value = typeCounterOne[i].TypeCounter;
            }
        }

        public void Type2(List<TypeCounterTwo> typeCounterTwo)
        {
            for (int i = 0; i < typeCounterTwo.Count; i++)
            {
                numericUpDown4.Value = typeCounterTwo[i].TypeCounter;
            }
        }

        public void Type3(List<TypeCounterThree> typeCounterThree)
        {
            for (int i = 0; i < typeCounterThree.Count; i++)
            {
                numericUpDown5.Value = typeCounterThree[i].TypeCounter;
            }
        }

        public void Type4(List<Manometr> manometrs)
        {
            for (int i = 0; i < manometrs.Count; i++)
            {
                numericUpDown6.Value = manometrs[i].TypeCounter;
            }
        }

        private int idContrects, oneFlow, twoFlow, threeFlow, manometer;
        private string addresss;

        private void Insert_Click(object sender, EventArgs e)
        {
            id = Int32.Parse(IDContracts.Text);
            addresss = textBoxAddress.Text;
            idContrects = Int32.Parse(IDContracts.Text);
            oneFlow = Convert.ToInt32(numericUpDown3.Text);
            twoFlow = Convert.ToInt32(numericUpDown4.Text);
            threeFlow = Convert.ToInt32(numericUpDown5.Text);
            manometer = Convert.ToInt32(numericUpDown6.Text);

            connect.InsertToTableScore(idContrects, addresss, oneFlow, twoFlow, threeFlow, manometer);
            connect.Scores.Clear();
            connect.ShowFieldsScore(id);
            OutputTable(connect.Scores);

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (IDContracts.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                id = Convert.ToInt32(IDContracts.Text);
                connect.DeleteFromTableScore(id);
                connect.Scores.Clear();
                connect.ShowFieldsScore(id);
                OutputTable(connect.Scores);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (IDContracts.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                id = Convert.ToInt32(IDContracts.Text);
                idContrects = Int32.Parse(IDContracts.Text);
                addresss = textBoxAddress.Text;
                oneFlow = Convert.ToInt32(numericUpDown3.Text);
                twoFlow = Convert.ToInt32(numericUpDown4.Text);
                threeFlow = Convert.ToInt32(numericUpDown5.Text);
                manometer = Convert.ToInt32(numericUpDown6.Text);

                connect.UpdateFromTableScore(id, idContrects, addresss, oneFlow, twoFlow, threeFlow, manometer);
                connect.Scores.Clear();
                connect.ShowFieldsScore(id);
                OutputTable(connect.Scores);
            }
        }

        private double normTime,poverca,rentab,kofNalog,kofRashod,mater,kofOtchisl,kofstrahVznos,kofPrem,kofZatrat,vsegosNalog,
            strahVznos,proverkaprib,sumnalogYSN,kofOsnZarplata,osnZp,pribl,sebestoim,polnSebestoim,zatrats,premia,otchisl,strahov,
            nakladn,vsego,itogOdnpot;

        public double itogOdnpot4;

        private int kol;

        private void button2_Click(object sender, EventArgs e)
        {
            Decision();
        }

        private double normTime1,poverca1,rentab1,kofNalog1,kofRashod1,mater1,kofOtchisl1,kofstrahVznos1,kofPrem1,kofZatrat1,vsegosNalog1,
            strahVznos1,proverkaprib1,sumnalogYSN1,kofOsnZarplata1,osnZp1,pribl1,sebestoim1,polnSebestoim1,zatrats1,premia1,otchisl1,strahov1,
            nakladn1,vsego1,itogOdnpot1;

        private int kol1;

        private void button3_Click(object sender, EventArgs e)
        {
            Decision();
        }

        private double normTime2,poverca2,rentab2,kofNalog2,kofRashod2,mater2,kofOtchisl2,kofstrahVznos2,kofPrem2,kofZatrat2,vsegosNalog2,
            strahVznos2,proverkaprib2,sumnalogYSN2,kofOsnZarplata2,osnZp2,pribl2,sebestoim2,polnSebestoim2,zatrats2,premia2,otchisl2,strahov2,
            nakladn2,vsego2,itogOdnpot2;

        private int kol2;

        private void button4_Click(object sender, EventArgs e)
        {
            Decision();
        }

        private double normTime3,poverca3,rentab3,kofNalog3,kofRashod3,mater3,kofOtchisl3,kofstrahVznos3,kofPrem3,kofZatrat3,vsegosNalog3,
            strahVznos3,proverkaprib3,sumnalogYSN3,kofOsnZarplata3,osnZp3,pribl3,sebestoim3,polnSebestoim3,zatrats3,premia3,otchisl3,strahov3,
            nakladn3,vsego3,itogOdnpot3;

        private int kol3;

        private void button5_Click(object sender, EventArgs e)
        {
            Decision();
        }

        private void Decision()
        {
            id = Int32.Parse(IDContracts.Text);
            normTime = Convert.ToDouble(textBox2.Text);
            poverca = Convert.ToDouble(textBox3.Text);
            rentab = Convert.ToDouble(textBox4.Text);
            kofNalog = Convert.ToDouble(textBox5.Text);
            kofRashod = Convert.ToDouble(textBox6.Text);
            mater = Convert.ToDouble(textBox7.Text);
            kofOtchisl = Convert.ToDouble(textBox8.Text);
            kofstrahVznos = Convert.ToDouble(textBox9.Text);
            kofPrem = Convert.ToDouble(textBox10.Text);
            kofZatrat = Convert.ToDouble(textBox11.Text);
            kofOsnZarplata = Convert.ToDouble(textBox24.Text);

            osnZp = Money.Round((kofOsnZarplata*normTime), 2);
            textBox12.Text = osnZp.ToString();
            zatrats = Money.Round((osnZp*kofZatrat*0.01), 2);
            textBox16.Text = zatrats.ToString();
            premia = Money.Round((osnZp*kofPrem*0.01), 2);
            textBox17.Text = premia.ToString();
            otchisl = Money.Round(((osnZp + zatrats + premia)*kofOtchisl*0.01), 2);
            textBox18.Text = otchisl.ToString();
            strahVznos = Money.Round(((osnZp + zatrats + premia)*kofstrahVznos), 2);
            textBox19.Text = strahVznos.ToString();
            nakladn = Money.Round((osnZp*kofRashod), 2);
            textBox20.Text = nakladn.ToString();
            polnSebestoim = Money.Round(((osnZp + zatrats + premia + otchisl + strahVznos + nakladn) + mater), 2);
            textBox15.Text = polnSebestoim.ToString();
            sebestoim = Money.Round((polnSebestoim - mater), 2);
            textBox14.Text = sebestoim.ToString();
            pribl = Money.Round((sebestoim*rentab/100), 2);
            textBox13.Text = pribl.ToString();
            vsego = Money.Round((polnSebestoim + pribl + poverca), 2);
            textBox21.Text = vsego.ToString();
            sumnalogYSN = Money.Round(((vsego*kofNalog)/(100 - kofNalog)), 2);
            textBox22.Text = sumnalogYSN.ToString();
            vsegosNalog = Money.Round((vsego + sumnalogYSN), 2);
            textBox23.Text = vsegosNalog.ToString();
            kol = Convert.ToInt32(numericUpDown3.Text);
            itogOdnpot = vsegosNalog*kol;
            label38.Text = "Сумма = " + vsegosNalog + " * " + kol + " = " + itogOdnpot;

            normTime1 = Convert.ToDouble(textBox47.Text);
            poverca1 = Convert.ToDouble(textBox46.Text);
            rentab1 = Convert.ToDouble(textBox45.Text);
            kofNalog1 = Convert.ToDouble(textBox44.Text);
            kofRashod1 = Convert.ToDouble(textBox43.Text);
            mater1 = Convert.ToDouble(textBox42.Text);
            kofOtchisl1 = Convert.ToDouble(textBox41.Text);
            kofstrahVznos1 = Convert.ToDouble(textBox40.Text);
            kofPrem1 = Convert.ToDouble(textBox39.Text);
            kofZatrat1 = Convert.ToDouble(textBox38.Text);
            kofOsnZarplata1 = Convert.ToDouble(textBox25.Text);

            osnZp1 = Money.Round((kofOsnZarplata1*normTime1), 2);
            textBox37.Text = osnZp1.ToString();
            zatrats1 = Money.Round((osnZp1*kofZatrat1*0.01), 2);
            textBox33.Text = zatrats1.ToString();
            premia1 = Money.Round((osnZp1*kofPrem1*0.01), 2);
            textBox32.Text = premia1.ToString();
            otchisl1 = Money.Round(((osnZp1 + zatrats1 + premia1)*kofOtchisl1*0.01), 2);
            textBox31.Text = otchisl1.ToString();
            strahVznos1 = Money.Round(((osnZp1 + zatrats1 + premia1)*kofstrahVznos1), 2);
            textBox30.Text = strahVznos1.ToString();
            nakladn1 = Money.Round((osnZp1*kofRashod1), 2);
            textBox29.Text = nakladn1.ToString();
            polnSebestoim1 = Money.Round(((osnZp1 + zatrats1 + premia1 + otchisl1 + strahVznos1 + nakladn1) + mater1), 2);
            textBox34.Text = polnSebestoim1.ToString();
            sebestoim1 = Money.Round((polnSebestoim1 - mater1), 2);
            textBox35.Text = sebestoim1.ToString();
            pribl1 = Money.Round((sebestoim1*rentab1/100), 2);
            textBox36.Text = pribl1.ToString();
            vsego1 = Money.Round((polnSebestoim1 + pribl1 + poverca1), 2);
            textBox28.Text = vsego1.ToString();
            sumnalogYSN1 = Money.Round(((vsego1*kofNalog1)/(100 - kofNalog1)), 2);
            textBox27.Text = sumnalogYSN1.ToString();
            vsegosNalog1 = Money.Round((vsego1 + sumnalogYSN1), 2);
            textBox26.Text = vsegosNalog1.ToString();
            kol1 = Convert.ToInt32(numericUpDown4.Text);
            itogOdnpot1 = vsegosNalog1*kol1;
            label39.Text = "Сумма = " + vsegosNalog1 + " * " + kol1 + " = " + itogOdnpot1;

            normTime2 = Convert.ToDouble(textBox70.Text);
            poverca2 = Convert.ToDouble(textBox69.Text);
            rentab2 = Convert.ToDouble(textBox68.Text);
            kofNalog2 = Convert.ToDouble(textBox67.Text);
            kofRashod2 = Convert.ToDouble(textBox66.Text);
            mater2 = Convert.ToDouble(textBox65.Text);
            kofOtchisl2 = Convert.ToDouble(textBox64.Text);
            kofstrahVznos2 = Convert.ToDouble(textBox63.Text);
            kofPrem2 = Convert.ToDouble(textBox62.Text);
            kofZatrat2 = Convert.ToDouble(textBox61.Text);
            kofOsnZarplata2 = Convert.ToDouble(textBox48.Text);

            osnZp2 = Money.Round((kofOsnZarplata2*normTime2), 2);
            textBox60.Text = osnZp2.ToString();
            zatrats2 = Money.Round((osnZp2*kofZatrat2*0.01), 2);
            textBox56.Text = zatrats2.ToString();
            premia2 = Money.Round((osnZp2*kofPrem2*0.01), 2);
            textBox55.Text = premia2.ToString();
            otchisl2 = Money.Round(((osnZp2 + zatrats2 + premia2)*kofOtchisl2*0.01), 2);
            textBox54.Text = otchisl2.ToString();
            strahVznos2 = Money.Round(((osnZp2 + zatrats2 + premia2)*kofstrahVznos2), 2);
            textBox53.Text = strahVznos2.ToString();
            nakladn2 = Money.Round((osnZp2*kofRashod2), 2);
            textBox52.Text = nakladn2.ToString();
            polnSebestoim2 = Money.Round(((osnZp2 + zatrats2 + premia2 + otchisl2 + strahVznos2 + nakladn2) + mater2), 2);
            textBox57.Text = polnSebestoim2.ToString();
            sebestoim2 = Money.Round((polnSebestoim2 - mater2), 2);
            textBox58.Text = sebestoim2.ToString();
            pribl2 = Money.Round((sebestoim2*rentab2/100), 2);
            textBox59.Text = pribl2.ToString();
            vsego2 = Money.Round((polnSebestoim2 + pribl2 + poverca2), 2);
            textBox51.Text = vsego2.ToString();
            sumnalogYSN2 = Money.Round(((vsego2*kofNalog2)/(100 - kofNalog2)), 2);
            textBox50.Text = sumnalogYSN2.ToString();
            vsegosNalog2 = Money.Round((vsego2 + sumnalogYSN2), 2);
            textBox49.Text = vsegosNalog2.ToString();
            kol2 = Convert.ToInt32(numericUpDown5.Text);
            itogOdnpot2 = vsegosNalog2*kol2;
            label63.Text = "Сумма = " + vsegosNalog2 + " * " + kol2 + " = " + itogOdnpot2;

            normTime3 = Convert.ToDouble(textBox93.Text);
            poverca3 = Convert.ToDouble(textBox92.Text);
            rentab3 = Convert.ToDouble(textBox91.Text);
            kofNalog3 = Convert.ToDouble(textBox90.Text);
            kofRashod3 = Convert.ToDouble(textBox89.Text);
            mater3 = Convert.ToDouble(textBox88.Text);
            kofOtchisl3 = Convert.ToDouble(textBox87.Text);
            kofstrahVznos3 = Convert.ToDouble(textBox86.Text);
            kofPrem3 = Convert.ToDouble(textBox85.Text);
            kofZatrat3 = Convert.ToDouble(textBox84.Text);
            kofOsnZarplata3 = Convert.ToDouble(textBox71.Text);

            osnZp3 = Money.Round((kofOsnZarplata3*normTime3), 2);
            textBox83.Text = osnZp3.ToString();
            zatrats3 = Money.Round((osnZp3*kofZatrat3*0.01), 2);
            textBox79.Text = zatrats3.ToString();
            premia3 = Money.Round((osnZp3*kofPrem3*0.01), 2);
            textBox78.Text = premia3.ToString();
            otchisl3 = Money.Round(((osnZp3 + zatrats3 + premia3)*kofOtchisl3*0.01), 2);
            textBox77.Text = otchisl3.ToString();
            strahVznos3 = Money.Round(((osnZp3 + zatrats3 + premia3)*kofstrahVznos3), 2);
            textBox76.Text = strahVznos3.ToString();
            nakladn3 = Money.Round((osnZp3*kofRashod3), 2);
            textBox75.Text = nakladn3.ToString();
            polnSebestoim3 = Money.Round(((osnZp3 + zatrats3 + premia3 + otchisl3 + strahVznos3 + nakladn3) + mater3), 2);
            textBox80.Text = polnSebestoim3.ToString();
            sebestoim3 = Money.Round((polnSebestoim3 - mater3), 2);
            textBox81.Text = sebestoim3.ToString();
            pribl3 = Money.Round((sebestoim3*rentab3/100), 2);
            textBox82.Text = pribl3.ToString();
            vsego3 = Money.Round((polnSebestoim3 + pribl3 + poverca3), 2);
            textBox74.Text = vsego3.ToString();
            sumnalogYSN3 = Money.Round(((vsego3*kofNalog3)/(100 - kofNalog3)), 2);
            textBox73.Text = sumnalogYSN3.ToString();
            vsegosNalog3 = Money.Round((vsego3 + sumnalogYSN3), 2);
            textBox72.Text = vsegosNalog3.ToString();
            kol3 = Convert.ToInt32(numericUpDown6.Text);
            itogOdnpot3 = vsegosNalog3*kol3;
            label87.Text = "Сумма = " + vsegosNalog3 + " * " + kol3 + " = " + itogOdnpot3;
            itogOdnpot4 = itogOdnpot3 + itogOdnpot2 + itogOdnpot1 + itogOdnpot;
            label111.Text = "Итог = " + itogOdnpot + " + " + itogOdnpot1 + " + " + itogOdnpot2 + " + " + itogOdnpot3 +
                            " = " + itogOdnpot4;

            connect.UpdateFromSum(itogOdnpot4.ToString(), id);
        }

        private int val;
        int cop;

        private string vall;
        string copp;

        private void BelRub(int val)
        {
            if (val % 100 > 10 && val % 100 < 21)
            {
                vall = Money.Str(val) + "белорусских рублей";
            }
            else if (val % 10 > 1)
            {
                if (val % 10 < 5)
                {
                    vall = Money.Str(val) + "белорусских рубля";
                }
                else
                {
                    vall = Money.Str(val) + "белорусских рублей";
                }
            }
            else if (val % 10 == 1)
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
            string value = itogOdnpot4.ToString();
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

        private Excel.Application excelapp;
        private Excel.Window excelWindow;
        private Excel.Sheets excelsheets;
        private Excel.Worksheet excelworksheet;
        private Excel.Range excelcells;
        private Excel.Workbook excelappworkbook;
        private void конвертироватьEXELToolStripMenuItem_Click(object sender, EventArgs e)
        {
          excelapp = new Excel.Application();
          excelapp.Visible = true;
          excelappworkbook = excelapp.Workbooks.Open("d:\\GomelEnergyAlliance\\Shablon\\СФ и акт оказания услуг.xls");

            excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
            excelcells = excelworksheet.get_Range("D1");
            excelcells.Value2 = label4.Text + " от";
            excelcells = excelworksheet.get_Range("D2");
            excelcells.Value2 = "договору " + label4.Text + " от " + label112.Text; 
            excelcells = excelworksheet.get_Range("F1");
            excelcells.Value2 = label112.Text;
            excelcells = excelworksheet.get_Range("A10");
            excelcells.Value2 = "Заказчик: " + comboBox2.Text;
            excelcells = excelworksheet.get_Range("A11");
            excelcells.Value2 = label113.Text;
            excelcells = excelworksheet.get_Range("F11");
            excelcells.Value2 = "УНП " + label114.Text;
            excelcells = excelworksheet.get_Range("H11");
            excelcells.Value2 = "ОКПО " + label122.Text;
            excelcells = excelworksheet.get_Range("A12");
            excelcells.Value2 = "р/с" + label115.Text +" "+ label116.Text + "; МФО "+ label117.Text;
            excelcells = excelworksheet.get_Range("H11");
            excelcells.Value2 = "ОКПО " + label122.Text;
            excelcells = excelworksheet.get_Range("E15");
            excelcells.Value2 = numericUpDown3.Text;
            excelcells = excelworksheet.get_Range("E16");
            excelcells.Value2 = numericUpDown4.Text;
            excelcells = excelworksheet.get_Range("E17");
            excelcells.Value2 = numericUpDown5.Text;
            excelcells = excelworksheet.get_Range("E18");
            excelcells.Value2 = numericUpDown6.Text;
            excelcells = excelworksheet.get_Range("B35");
            excelcells.Value2 = label121.Text + "__________________";
            excelcells = excelworksheet.get_Range("C35");
            excelcells.Value2 = label120.Text;
            excelcells = excelworksheet.get_Range("E35");
            excelcells.Value2 = label119.Text + "__________________" + label118.Text;
            PerevodCost();
            excelcells = excelworksheet.get_Range("D21");
            excelcells.Value2 = vall + " " +copp;


            excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(2);
            excelcells = excelworksheet.get_Range("A12");
            excelcells.Value2 = "Мы, нижеподписавшиеся: Исполнитель - " +  label121.Text + " " + label120.Text + "и";
            excelcells = excelworksheet.get_Range("A13");
            excelcells.Value2 = "Заказчик - " + label119.Text + " " + label118.Text;


            excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(3);
            excelcells = excelworksheet.get_Range("A8");
            excelcells.Value2 = "по адресу: " + label113.Text;
            excelcells = excelworksheet.get_Range("G12");
            excelcells.Value2 = Convert.ToDouble(textBox2.Text);
            excelcells = excelworksheet.get_Range("G23");
            excelcells.Value2 = Convert.ToDouble(textBox3.Text);
            excelcells = excelworksheet.get_Range("G21");
            excelcells.Value2 = Convert.ToDouble(textBox4.Text);
            excelcells = excelworksheet.get_Range("G25");
            excelcells.Value2 = Convert.ToDouble(textBox5.Text);
            excelcells = excelworksheet.get_Range("I18");
            excelcells.Value2 = Convert.ToDouble(textBox6.Text);
            excelcells = excelworksheet.get_Range("I17");
            excelcells.Value2 = Convert.ToDouble(textBox9.Text);
            excelcells = excelworksheet.get_Range("I16");
            excelcells.Value2 = Convert.ToDouble(textBox8.Text)*0.01;
            excelcells = excelworksheet.get_Range("I14");
            excelcells.Value2 = Convert.ToDouble(textBox11.Text) * 0.01;
            excelcells = excelworksheet.get_Range("I15");
            excelcells.Value2 = Convert.ToDouble(textBox10.Text) * 0.01;
            excelcells = excelworksheet.get_Range("I13");
            excelcells.Value2 = Convert.ToDouble(textBox24.Text);

            excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(4);
            excelcells = excelworksheet.get_Range("A8");
            excelcells.Value2 = "по адресу: " + label113.Text;
            excelcells = excelworksheet.get_Range("G12");
            excelcells.Value2 = Convert.ToDouble(textBox2.Text);
            excelcells = excelworksheet.get_Range("G23");
            excelcells.Value2 = Convert.ToDouble(textBox3.Text);
            excelcells = excelworksheet.get_Range("G21");
            excelcells.Value2 = Convert.ToDouble(textBox4.Text);
            excelcells = excelworksheet.get_Range("G25");
            excelcells.Value2 = Convert.ToDouble(textBox5.Text);
            excelcells = excelworksheet.get_Range("I18");
            excelcells.Value2 = Convert.ToDouble(textBox6.Text);
            excelcells = excelworksheet.get_Range("I17");
            excelcells.Value2 = Convert.ToDouble(textBox9.Text);
            excelcells = excelworksheet.get_Range("I16");
            excelcells.Value2 = Convert.ToDouble(textBox8.Text) * 0.01;
            excelcells = excelworksheet.get_Range("I14");
            excelcells.Value2 = Convert.ToDouble(textBox11.Text) * 0.01;
            excelcells = excelworksheet.get_Range("I15");
            excelcells.Value2 = Convert.ToDouble(textBox10.Text) * 0.01;
            excelcells = excelworksheet.get_Range("I13");
            excelcells.Value2 = Convert.ToDouble(textBox24.Text);

            excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(5);
            excelcells = excelworksheet.get_Range("A8");
            excelcells.Value2 = "по адресу: " + label113.Text;
            excelcells = excelworksheet.get_Range("G12");
            excelcells.Value2 = Convert.ToDouble(textBox2.Text);
            excelcells = excelworksheet.get_Range("G23");
            excelcells.Value2 = Convert.ToDouble(textBox3.Text);
            excelcells = excelworksheet.get_Range("G21");
            excelcells.Value2 = Convert.ToDouble(textBox4.Text);
            excelcells = excelworksheet.get_Range("G25");
            excelcells.Value2 = Convert.ToDouble(textBox5.Text);
            excelcells = excelworksheet.get_Range("I18");
            excelcells.Value2 = Convert.ToDouble(textBox6.Text);
            excelcells = excelworksheet.get_Range("I17");
            excelcells.Value2 = Convert.ToDouble(textBox9.Text);
            excelcells = excelworksheet.get_Range("I16");
            excelcells.Value2 = Convert.ToDouble(textBox8.Text) * 0.01;
            excelcells = excelworksheet.get_Range("I14");
            excelcells.Value2 = Convert.ToDouble(textBox11.Text) * 0.01;
            excelcells = excelworksheet.get_Range("I15");
            excelcells.Value2 = Convert.ToDouble(textBox10.Text) * 0.01;
            excelcells = excelworksheet.get_Range("I13");
            excelcells.Value2 = Convert.ToDouble(textBox24.Text);

            excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(6);
            excelcells = excelworksheet.get_Range("A8");
            excelcells.Value2 = "по адресу: " + label113.Text;
            excelcells = excelworksheet.get_Range("G12");
            excelcells.Value2 = Convert.ToDouble(textBox2.Text);
            excelcells = excelworksheet.get_Range("G23");
            excelcells.Value2 = Convert.ToDouble(textBox3.Text);
            excelcells = excelworksheet.get_Range("G21");
            excelcells.Value2 = Convert.ToDouble(textBox4.Text);
            excelcells = excelworksheet.get_Range("G25");
            excelcells.Value2 = Convert.ToDouble(textBox5.Text);
            excelcells = excelworksheet.get_Range("I18");
            excelcells.Value2 = Convert.ToDouble(textBox6.Text);
            excelcells = excelworksheet.get_Range("I17");
            excelcells.Value2 = Convert.ToDouble(textBox9.Text);
            excelcells = excelworksheet.get_Range("I16");
            excelcells.Value2 = Convert.ToDouble(textBox8.Text) * 0.01;
            excelcells = excelworksheet.get_Range("I14");
            excelcells.Value2 = Convert.ToDouble(textBox11.Text) * 0.01;
            excelcells = excelworksheet.get_Range("I15");
            excelcells.Value2 = Convert.ToDouble(textBox10.Text) * 0.01;
            excelcells = excelworksheet.get_Range("I13");
            excelcells.Value2 = Convert.ToDouble(textBox24.Text);
        }

        private double normTime4, poverca4, rentab4, kofNalog4, kofRashod4, mater4, kofOtchisl4, kofstrahVznos4, kofPrem4, kofZatrat4, vsegosNalog4,
       strahVznos4, proverkaprib4, sumnalogYSN4, kofOsnZarplata4, osnZp4, pribl4, sebestoim4, polnSebestoim4, zatrats4, premia4, otchisl4, strahov4,
       nakladn4, vsego4, itogOdnpot5;
        private void button6_Click(object sender, EventArgs e)
        {
            id = Int32.Parse(IDContracts.Text);
            normTime4 = Convert.ToDouble(textBox116.Text);
            poverca4 = Convert.ToDouble(textBox115.Text);
            rentab4 = Convert.ToDouble(textBox114.Text);
            kofNalog4 = Convert.ToDouble(textBox113.Text);
            kofRashod4 = Convert.ToDouble(textBox112.Text);
            mater4 = Convert.ToDouble(textBox111.Text);
            kofOtchisl4 = Convert.ToDouble(textBox110.Text);
            kofstrahVznos4 = Convert.ToDouble(textBox109.Text);
            kofPrem4 = Convert.ToDouble(textBox108.Text);
            kofZatrat4 = Convert.ToDouble(textBox107.Text);
            kofOsnZarplata4 = Convert.ToDouble(textBox94.Text);

            osnZp4 = Money.Round((kofOsnZarplata4 * normTime4), 2);
            textBox83.Text = osnZp4.ToString();
            zatrats4 = Money.Round((osnZp4 * kofZatrat4 * 0.01), 2);
            textBox79.Text = zatrats4.ToString();
            premia4 = Money.Round((osnZp4 * kofPrem4 * 0.01), 2);
            textBox78.Text = premia4.ToString();
            otchisl4 = Money.Round(((osnZp4 + zatrats4 + premia4) * kofOtchisl4 * 0.01), 2);
            textBox77.Text = otchisl4.ToString();
            strahVznos4 = Money.Round(((osnZp4 + zatrats4 + premia4) * kofstrahVznos4), 2);
            textBox76.Text = strahVznos4.ToString();
            nakladn4 = Money.Round((osnZp4 * kofRashod4), 2);
            textBox75.Text = nakladn4.ToString();
            polnSebestoim4 = Money.Round(((osnZp4 + zatrats4 + premia4 + otchisl4 + strahVznos4 + nakladn4) + mater4), 2);
            textBox80.Text = polnSebestoim4.ToString();
            sebestoim4 = Money.Round((polnSebestoim4 - mater4), 2);
            textBox81.Text = sebestoim4.ToString();
            pribl4 = Money.Round((sebestoim4 * rentab4 / 100), 2);
            textBox82.Text = pribl4.ToString();
            vsego4 = Money.Round((polnSebestoim4 + pribl4 + poverca4), 2);
            textBox74.Text = vsego4.ToString();
            sumnalogYSN4 = Money.Round(((vsego4 * kofNalog4) / (100 - kofNalog4)), 2);
            textBox73.Text = sumnalogYSN4.ToString();
            vsegosNalog4 = Money.Round((vsego4 + sumnalogYSN4), 2);
            textBox72.Text = vsegosNalog4.ToString();

            int kol4 = 1;
            itogOdnpot5 = vsegosNalog4 * kol4;
            label123.Text = "Сумма = " + vsegosNalog4 + " * " + kol4 + " = " + itogOdnpot5;

            connect.UpdateFromSum(itogOdnpot5.ToString(), id);
        }

    }
}
