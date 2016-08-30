using System;
using System.Collections.Generic;

using System.Windows.Forms;
using Contracts.Objects;

namespace Contracts
{
    public partial class FormExecutor : Form
    {
        public FormExecutor()
        {
            InitializeComponent();
            InitTable();
        }

        public void InitTable()
        {
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[7].Width = 96;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[1].Name = "ФИО (И.П)";
            dataGridView1.Columns[2].Name = "ФИО (Р.П)";
            dataGridView1.Columns[3].Name = "Должность (И.П)";
            dataGridView1.Columns[4].Name = "Должность (Р.П)";
            dataGridView1.Columns[5].Name = "Действ на осн";
            dataGridView1.Columns[6].Name = "Номер";
            dataGridView1.Columns[7].Name = "Дата";
        }

        public void OutputTable(List<Executor> executors)
        {
            dataGridView1.RowCount = executors.Count;
            for (int i = 0; i < executors.Count; i++)
            {
                dataGridView1[0, i].Value = executors[i].IdExecutor;
                dataGridView1[1, i].Value = executors[i].NameExecutor;
                dataGridView1[2, i].Value = executors[i].NameExecutors;
                dataGridView1[3, i].Value = executors[i].PositionExecutor;
                dataGridView1[4, i].Value = executors[i].PositionExecutors;
                dataGridView1[5, i].Value = executors[i].ActingOnTheBasis;
                dataGridView1[6, i].Value = executors[i].Number;
                dataGridView1[7, i].Value = executors[i].Date;
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
                    textBox1.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value != null)
                    textBox2.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value != null)
                    comboBox2.Text = row.Cells[3].Value.ToString();
                if (row.Cells[4].Value != null)
                    textBox4.Text = row.Cells[4].Value.ToString();
                if (row.Cells[5].Value != null)
                    comboBox1.Text = row.Cells[5].Value.ToString();
                if (row.Cells[6].Value != null)
                    textBox5.Text = row.Cells[6].Value.ToString();
                if (row.Cells[7].Value != null)
                    textBox6.Text = row.Cells[7].Value.ToString();
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox6.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private int flag = 0;

        private void button1_Click(object sender, EventArgs e)
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

        private void FormExecutor_Load(object sender, EventArgs e)
        {
            flag = 0;
            monthCalendar1.Visible = false;
        }

        Connects connect = new Connects();

        private int id;
        private string nameExecutor, nameExecutors, positionExecutor, positionExecutors, actingOnTheBasis, number, date;

        private void InsertExecutor_Click(object sender, EventArgs e)
        {
            connect.Executors.Clear();
            nameExecutor = textBox1.Text;
            nameExecutors = textBox2.Text;
            positionExecutor = comboBox2.Text;
            positionExecutors = textBox4.Text;
            actingOnTheBasis = comboBox1.Text;
            number = textBox5.Text;
            date = textBox6.Text;
            connect.InsertToTableExecutors(nameExecutor, nameExecutors, positionExecutor, positionExecutors,
                actingOnTheBasis, number, date);
            connect.ShowFieldsExecutors();
            OutputTable(connect.Executors);
            Close();
        }

        private void UpdateExecutor_Click(object sender, EventArgs e)
        {
            if (Id.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                connect.Executors.Clear();
                id = Convert.ToInt32(Id.Text);
                nameExecutor = textBox1.Text;
                nameExecutors = textBox2.Text;
                positionExecutor = comboBox1.Text;
                positionExecutors = textBox4.Text;
                actingOnTheBasis = comboBox1.Text;
                number = textBox5.Text;
                date = textBox6.Text;
                connect.UpdateFromTableExecutors(id, nameExecutor, nameExecutors, positionExecutor, positionExecutors,
                    actingOnTheBasis, number, date);
                connect.ShowFieldsExecutors();
                OutputTable(connect.Executors);
                Close();
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
                connect.Executors.Clear();
                id = Convert.ToInt32(Id.Text);
                connect.DeleteFromTableExecutors(id);
                connect.ShowFieldsExecutors();
                OutputTable(connect.Executors);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] sepa = { " " };
            string value = textBox1.Text;
            string[] wordsStrings = value.Split(sepa, StringSplitOptions.RemoveEmptyEntries);
            textBox2.Text = wordsStrings[1] + " " + wordsStrings[0];
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = comboBox2.Text.ToLower();
        }
    }
}
