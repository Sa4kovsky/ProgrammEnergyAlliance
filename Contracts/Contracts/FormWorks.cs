using System;
using System.Collections.Generic;

using System.Windows.Forms;
using Contracts.Objects;

namespace Contracts
{
    public partial class FormWorks : Form
    {
        public FormWorks()
        {
            InitializeComponent();
            InitTable();
        }

        public void InitTable()
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 334;
          
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[1].Name = "Вид работ";
        }

        public void OutputTable(List<Works> executors)
        {
            dataGridView1.RowCount = executors.Count;
            for (int i = 0; i < executors.Count; i++)
            {
                dataGridView1[0, i].Value = executors[i].IdWorks;
                dataGridView1[1, i].Value = executors[i].WorksType;
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
            }
        }

        Connects connects = new Connects();
        private int id;
        private string worksType;
        private void InsertExecutor_Click(object sender, EventArgs e)
        {
            connects.Works.Clear();
            worksType = textBox1.Text;
            connects.InsertToTableWorks(worksType);
            connects.ShowFieldsWorks();
            OutputTable(connects.Works);
            Close();
        }

        private void UpdateExecutor_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                connects.Works.Clear();
                id = Convert.ToInt32(Id.Text);
                worksType = textBox1.Text;
                connects.UpdateFromTableWorks(id, worksType);
                connects.ShowFieldsWorks();
                OutputTable(connects.Works);
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
                connects.Works.Clear();
                id = Convert.ToInt32(Id.Text);
                connects.DeleteFromTableWorks(id);
                connects.ShowFieldsWorks();
                OutputTable(connects.Works);
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


        private int flag;
        private void button1_Click(object sender, EventArgs e)
        {

            flag++;
            if (flag == 1)
            {
                this.textBox1.Size = new System.Drawing.Size(484, 113);
                this.textBox1.Location = new System.Drawing.Point(322, 6);
                flag++;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanSouth;
            }
            else
            {
                this.textBox1.Size = new System.Drawing.Size(284, 23);
                this.textBox1.Location = new System.Drawing.Point(522, 96);
                flag = 0;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanNorth;
            }
        }
    }
}
