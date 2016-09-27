using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;
using Contracts.Objects;

namespace Contracts
{
    public partial class Acct : Form
    {
        public Acct()
        {
            InitializeComponent();
            initTableWork();
        }

        public void initTableWork()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 880;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[1].Name = "Наименование работ";
            dataGridView1.Columns[2].Name = "Стоимость работы";
            dataGridView1.Columns[3].Name = "Стоимость материалов";

            dataGridView2.ColumnCount = 6;
            dataGridView2.Columns[0].Width = 70;
            dataGridView2.Columns[1].Width = 710;
            dataGridView2.Columns[2].Width = 150;
            dataGridView2.Columns[3].Width = 150;
            dataGridView2.Columns[4].Width = 150;
            dataGridView2.Columns[5].Width = 150;

            dataGridView2.RowHeadersVisible = false;

            dataGridView2.Columns[0].Name = "№";
            dataGridView2.Columns[1].Name = "Материалы";
            dataGridView2.Columns[2].Name = "Ед.изм.";
            dataGridView2.Columns[3].Name = "Кол-во";
            dataGridView2.Columns[4].Name = "Стоимость материала за ед.";
            dataGridView2.Columns[5].Name = "Итоговая стоимость материалов";

            dataGridView3.ColumnCount = 4;
            dataGridView3.Columns[0].Width = 610;
            dataGridView3.Columns[1].Width = 80;
            dataGridView3.Columns[2].Width = 80;
            dataGridView3.Columns[3].Width = 115;

            dataGridView3.RowHeadersVisible = false;

            dataGridView3.Columns[0].Name = "Материалы";
            dataGridView3.Columns[1].Name = "Ед.изм.";
            dataGridView3.Columns[2].Name = "Кол-во";
            dataGridView3.Columns[3].Name = "Стоимость материалов";
        }

        public void OutputTable(List<Material> materials)
        {
            dataGridView3.RowCount = materials.Count;
            for (int i = 0; i < materials.Count; i++)
            {
                dataGridView3[0, i].Value = materials[i].Materials;
                dataGridView3[1, i].Value = materials[i].Units;
                dataGridView3[2, i].Value = materials[i].Count;
                dataGridView3[3, i].Value = materials[i].Price;
            }
            dataGridView3.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int select = 0;
                if (row.Cells[0].Value != null)
                    select = Convert.ToInt32(row.Cells[0].Value);
                    textBox3.Text = row.Cells[0].Value.ToString();
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if (Convert.ToInt32(dataGridView2[0, i].Value) != select)
                    {
                        dataGridView2.Rows[i].Visible = false;
                    }
                    else
                    {
                        dataGridView2.Rows[i].Visible = true;
                    }
                }
            }
        }

        private int number = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            number++;
            dataGridView1.Rows.Add(number, nameWork.Text, adrressWorks.Text);
            textBox3.Text = number.ToString();
            for (int i = number - 1; i < dataGridView1.RowCount; i++)
            {
                 dataGridView1.ClearSelection();
                 dataGridView1.Rows[i].Selected = true;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private int flag;

        Connects connect = new Connects();
        private void button4_Click_1(object sender, EventArgs e)
        {
            connect.Materials.Clear();
            connect.ShowFieldsMaerial();
            OutputTable(connect.Materials);
            flag++;
            if (flag == 1)
            {
                panel1.Visible = true;
                flag++;
            }
            else
            {
                panel1.Visible = false;
                flag = 0;
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    textBox4.Text = row.Cells[0].Value.ToString();
                if (row.Cells[1].Value != null)
                    textBox5.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value != null)
                    textBox7.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value != null)
                    textBox6.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double maters = Convert.ToDouble(textBox6.Text) * Convert.ToDouble(textBox7.Text);
            dataGridView2.Rows.Add(textBox3.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text, maters.ToString());
            for (int i = 0; i < dataGridView2.RowCount; i++)
                if (i < 1)
                {
                    dataGridView1[3, Convert.ToInt32(textBox3.Text) - 1].Value = 0;
                    if (Convert.ToInt32(dataGridView2[0, i].Value) == Convert.ToInt32(textBox3.Text))
                    {
                        dataGridView1[3, Convert.ToInt32(textBox3.Text) - 1].Value = Convert.ToDouble(dataGridView1[3, Convert.ToInt32(textBox3.Text) - 1].Value) +
                                                    Convert.ToDouble(dataGridView2[5, i].Value);
                    }
                }
                else
                {
                    if (Convert.ToInt32(dataGridView2[0, i].Value) == Convert.ToInt32(textBox3.Text))
                    {
                        dataGridView1[3, Convert.ToInt32(textBox3.Text) - 1].Value = Convert.ToDouble(dataGridView1[3, Convert.ToInt32(textBox3.Text) - 1].Value) +
                                                    Convert.ToDouble(dataGridView2[5, i].Value);
                    }
                }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            number = 0;
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();
        }

    }
}
