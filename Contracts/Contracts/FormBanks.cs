using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Contracts.Objects;

namespace Contracts
{
    public partial class FormBanks : Form
    {
        public FormBanks()
        {
            InitializeComponent();
            InitTable();
        }

        public void InitTable()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 150;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Name = "Банк";
            dataGridView1.Columns[2].Name = "МФО";
        }

        public void OutputTable(List<Banks> executors)
        {
            dataGridView1.RowCount = executors.Count;
            for (int i = 0; i < executors.Count; i++)
            {
                dataGridView1[0, i].Value = executors[i].IdBank;
                dataGridView1[1, i].Value = executors[i].NameBank;
                dataGridView1[2, i].Value = executors[i].Address;
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
            }
        }

        Connects connects = new Connects();

        private string nameBank;
        private string address;
        private int id;

        private void InsertExecutor_Click(object sender, System.EventArgs e)
        {
            connects.Bankses.Clear();
            nameBank = textBox1.Text;
            address = textBox2.Text;
            connects.InsertToTableBank(nameBank, address);
            connects.ShowFieldsBank();
            OutputTable(connects.Bankses);
        }

        private void UpdateExecutor_Click(object sender, System.EventArgs e)
        {
            if (Id.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                if (textBox2.TextLength > 9)
                {
                    MessageBox.Show("А по рукам!!! Объяснительную мигом !!! Не больше 9 знаков, пожалуйста.");
                    textBox2.BackColor = Color.DarkRed;
                }
                else
                {
                    textBox2.BackColor = Color.White;
                    DialogResult result =
                        MessageBox.Show("Редактирование наименованиия банка приведет к смене наименования" +
                                        "банка у всех заказчиков. ВЫ ТОЧНО ХОТИТЕ ЭТО СДЕЛАТЬ?",
                            "ОСТОРОЖНО", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        DialogResult results =
                            MessageBox.Show("Данную процедуру нельзя будет отменить. ВЫ ТОЧНО ХОТИТЕ ЭТО СДЕЛАТЬ?",
                                "ОСТОРОЖНО", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (results == DialogResult.Yes)
                        {
                            DialogResult resultss =
                                MessageBox.Show(
                                    "Вы измените название данного банка у ВСЕХ заказчиков. ВЫ ТОЧНО ХОТИТЕ ЭТО СДЕЛАТЬ",
                                    "ОСТОРОЖНО", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (results == DialogResult.Yes)
                            {
                                connects.Bankses.Clear();
                            }
                            id = Convert.ToInt32(Id.Text);
                            nameBank = textBox1.Text;
                            address = textBox2.Text;
                            connects.UpdateFromTableBank(id, nameBank, address);
                            connects.ShowFieldsBank();
                            OutputTable(connects.Bankses);
                        }
                    }
                }
            }
        }

        private void DeleteExecutor_Click(object sender, System.EventArgs e)
        {
            if (Id.Text == "")
            {
                MessageBox.Show("Проверьте №");
            }
            else
            {
                 DialogResult result =
                        MessageBox.Show("Удалить банк невозможно, так как это приведет к удалению данного банка у всех заказчиков.",
                            "ОСТОРОЖНО", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    connects.Bankses.Clear();
                    id = Convert.ToInt32(Id.Text);
                    connects.DeleteFromTableBank(id);
                    connects.ShowFieldsBank();
                    OutputTable(connects.Bankses);
                }
            }
        }

        private void textSearch_TextChanged_1(object sender, EventArgs e)
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
                this.textBox1.Size = new System.Drawing.Size(579, 113);
                this.textBox1.Location = new System.Drawing.Point(324, 6);
                flag++;

                this.button1.Cursor = System.Windows.Forms.Cursors.PanSouth;
            }
            else
            {
                this.textBox1.Location = new System.Drawing.Point(524, 96);
                this.textBox1.Size = new System.Drawing.Size(379, 23);
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
    }
}
