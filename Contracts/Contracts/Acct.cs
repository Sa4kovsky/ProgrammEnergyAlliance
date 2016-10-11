using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;
using Contracts.Objects;
using Word = Microsoft.Office.Interop.Word;

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

            //dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[1].Name = "Наименование работ";
            dataGridView1.Columns[2].Name = "Стоимость работы";
            dataGridView1.Columns[3].Name = "Стоимость материалов";

            dataGridView2.ColumnCount = 8;
            dataGridView2.Columns[0].Width = 70;
            dataGridView2.Columns[1].Width = 710;
            dataGridView2.Columns[2].Width = 150;
            dataGridView2.Columns[3].Width = 150;
            dataGridView2.Columns[4].Width = 150;
            dataGridView2.Columns[5].Width = 150;
            dataGridView2.Columns[6].Width = 150;
            dataGridView2.Columns[7].Width = 150;

            dataGridView2.RowHeadersVisible = false;

            dataGridView2.Columns[0].Name = "№";
            dataGridView2.Columns[1].Name = "Материалы";
            dataGridView2.Columns[2].Name = "Ед.изм.";
            dataGridView2.Columns[3].Name = "Кол-во";
            dataGridView2.Columns[4].Name = "Стоимость материала за ед.";
            dataGridView2.Columns[5].Name = "Ставка НДС";
            dataGridView2.Columns[6].Name = "Сумма НДС, руб.";
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[6].Visible = false;
            dataGridView2.Columns[7].Name = "Итоговая стоимость материалов";

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
            double maters = Money.Round(Convert.ToDouble(textBox6.Text) * Convert.ToDouble(textBox7.Text),2);
            dataGridView2.Rows.Add(textBox3.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text, "без НДС", "без НДС", maters.ToString());
            for (int i = 0; i < dataGridView2.RowCount; i++)
                if (i < 1)
                {
                    dataGridView1[3, Convert.ToInt32(textBox3.Text) - 1].Value = 0;
                    if (Convert.ToInt32(dataGridView2[0, i].Value) == Convert.ToInt32(textBox3.Text))
                    {
                        dataGridView1[3, Convert.ToInt32(textBox3.Text) - 1].Value = Money.Round(Convert.ToDouble(dataGridView1[3, Convert.ToInt32(textBox3.Text) - 1].Value) +
                                                    Convert.ToDouble(dataGridView2[7, i].Value),2);
                    }
                }
                else
                {
                    if (Convert.ToInt32(dataGridView2[0, i].Value) == Convert.ToInt32(textBox3.Text))
                    {
                        dataGridView1[3, Convert.ToInt32(textBox3.Text) - 1].Value = Money.Round(Convert.ToDouble(dataGridView1[3, Convert.ToInt32(textBox3.Text) - 1].Value) +
                                                    Convert.ToDouble(dataGridView2[7, i].Value),2);
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

        private Microsoft.Office.Interop.Word._Application oWord; // создаем новый экземпляр ворда
        private Word.Paragraph wordparagraph;

        private Word._Document GetDoc(string path)
        {
            Word._Document oDoc = oWord.Documents.Add(path);
            SetTemplate(oDoc);
            return oDoc;
        }

        private void SetTemplate(Word._Document oDoc)
        {
            Object newTemplate = false;
            Object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
            Object visible = true;
            //Таблицу вставляем в начало документа
            Object start = 0;
            Object end = 0;
        //    Word.Range wordrange = oDoc.Range(ref start, ref end);
            Object defaultTableBehavior =
               Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;
            
            Word.Table wordtable1 = oDoc.Tables.Add(oWord.Selection.Range, 1 , 9,
             ref defaultTableBehavior, ref autoFitBehavior);
            //вывод в ячейки шапку
            Word.Range wordrange = oDoc.Tables[1].Cell(1, 1).Range;
      
            wordrange.Columns.Width = 20;
            wordrange.Text = "№";
            wordrange = wordtable1.Cell(1, 2).Range;
            wordrange.Columns.Width = 150;
            wordrange.Text = "Наименование работ";
            wordrange = wordtable1.Cell(1, 3).Range;
            wordrange.Columns.Width = 50;
            wordrange.Text = "Цена работ, руб.";
            wordrange = wordtable1.Cell(1, 4).Range;
            wordrange.Columns.Width = 50;
            wordrange.Text = "Ед. изм.";
            wordrange = wordtable1.Cell(1, 5).Range;
            wordrange.Columns.Width = 50;
            wordrange.Text = "Кол-во";
            wordrange = wordtable1.Cell(1, 6).Range;
            wordrange.Columns.Width = 50;
            wordrange.Text = "Стоимость, руб.";
            wordrange = wordtable1.Cell(1, 7).Range;
            wordrange.Columns.Width = 50;
            wordrange.Text = "Ставка НДС";
            wordrange = wordtable1.Cell(1, 8).Range;
            wordrange.Columns.Width = 50;
            wordrange.Text = "Сумма НДС, руб.";
            wordrange = wordtable1.Cell(1, 9).Range;
            wordrange.Columns.Width = 50;
            wordrange.Text = "Всего с НДС, руб.";

            wordrange.Columns.AutoFit(); 
       
            for (Int32 countObj = 0; countObj < dataGridView1.RowCount; countObj++)
            {

                object unit;
                object extend;
                unit = Word.WdUnits.wdStory;
                extend = Word.WdMovementType.wdMove;
                oWord.Selection.EndKey(ref unit, ref extend);
                Int32 countMater;
                Int32 count = 0;
                Int32 countMaters = 0;
                for (countMater = 0; countMater < dataGridView2.RowCount; countMater++)
                {
                    if (Convert.ToInt32(dataGridView1[0, countObj].Value) ==
                        Convert.ToInt32(dataGridView2[0, countMater].Value))
                    {
                        count++;
                    }
                }
                Word.Table wordtable = oDoc.Tables.Add(oWord.Selection.Range, 3 + count, 9,
                    ref defaultTableBehavior, ref autoFitBehavior);
                
                wordtable.Cell(1, 1).Range.Text = dataGridView1[0,countObj].Value.ToString();
                wordtable.Cell(1, 2).Range.Text = dataGridView1[1,countObj].Value.ToString();
                wordtable.Cell(1, 3).Range.Text = dataGridView1[2, countObj].Value.ToString();
                wordtable.Cell(1, 4).Range.Text = "шт";
                wordtable.Cell(1, 5).Range.Text = "1";
                wordtable.Cell(1, 6).Range.Text = dataGridView1[2,countObj].Value.ToString();
                wordtable.Cell(1, 7).Range.Text = "Без НДС";
                wordtable.Cell(1, 8).Range.Text = "Без НДС";
                wordtable.Cell(1, 9).Range.Text = dataGridView1[2,countObj].Value.ToString();

                wordtable.Cell(2, 2).Range.Text = "В том числе материалы ИСПОЛНИТЕЛЯ";
                wordtable.Cell(2, 2).Range.Font.Size = 10;
                wordtable.Cell(2, 3).Range.Text = "Наименование";
                wordtable.Cell(2, 3).Range.Font.Size = 10;
                wordtable.Cell(2, 4).Range.Text = "Ед.изм.";
                wordtable.Cell(2, 4).Range.Font.Size = 10;
                wordtable.Cell(2, 5).Range.Text = "Кол-во";
                wordtable.Cell(2, 5).Range.Font.Size = 10;
                wordtable.Cell(2, 6).Range.Text = "Стоимость";
                wordtable.Cell(2, 6).Range.Font.Size = 10;
                wordtable.Cell(2, 7).Range.Text = "Стака НДС";
                wordtable.Cell(2, 7).Range.Font.Size = 10;
                wordtable.Cell(2, 8).Range.Text = "Сумма НДС, руб.";
                wordtable.Cell(2, 8).Range.Font.Size = 10;
                wordtable.Cell(2, 9).Range.Text = "Всего с НДС, руб.";
                wordtable.Cell(2, 9).Range.Font.Size = 10;

             /*   wordtable.Cell(2, 1).Range.Columns.Width = 20;
                wordtable.Cell(2, 2).Range.Columns.Width = 150;
                wordtable.Cell(2, 3).Range.Columns.Width = 50;
                wordtable.Cell(2, 4).Range.Columns.Width = 50;
                wordtable.Cell(2, 5).Range.Columns.Width = 50;
                wordtable.Cell(2, 6).Range.Columns.Width = 50;
                wordtable.Cell(2, 7).Range.Columns.Width = 50;
                wordtable.Cell(2, 8).Range.Columns.Width = 50;*/

                object begCell = wordtable.Cell(1, 1).Range.Start;
                object endCell = wordtable.Cell(count+3, 1).Range.End;
                Word.Range wordcellrange = oDoc.Range(ref begCell, ref endCell);
                wordcellrange.Select();
                oWord.Selection.Cells.Merge();
                for (countMater = 0; countMater < dataGridView2.RowCount; countMater++)
                {
                    if (Convert.ToInt32(dataGridView1[0, countObj].Value) ==
                        Convert.ToInt32(dataGridView2[0, countMater].Value))
                    {
                        countMaters++;
                        begCell = wordtable.Cell(countMaters + 2, 2).Range.Start;
                        endCell = wordtable.Cell(countMaters + 2, 3).Range.End;
                        wordcellrange = oDoc.Range(ref begCell, ref endCell);
                        wordcellrange.Select();
                        oWord.Selection.Cells.Merge();
                        for (Int32 jCellTable = 0; jCellTable < 7; jCellTable++)
                        {
                            wordtable.Cell(countMaters + 2, jCellTable + 2).Range.Text =
                                dataGridView2[jCellTable + 1, countMater].Value.ToString();
                            wordcellrange = wordtable.Cell(countMaters + 2, jCellTable + 2).Range;
                            wordcellrange.Font.Size = 9;
                        }
                    }
                }

                begCell = wordtable.Cell(count + 3, 2).Range.Start;
                endCell = wordtable.Cell(count + 3, 8).Range.End;
                wordcellrange = oDoc.Range(ref begCell, ref endCell);
                wordcellrange.Select();
                oWord.Selection.Cells.Merge();
                oWord.Selection.Text = "Итого материалов 'Исполнителя'";
                wordtable.Cell(count + 3, 3).Range.Text =
                                dataGridView1[3, countObj].Value.ToString();
            }
        }

        private void excelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            oWord = new Microsoft.Office.Interop.Word.Application();
            oWord.Visible = true;
            Microsoft.Office.Interop.Word._Document oDoc =
                    GetDoc("e:\\Заказ\\GomelEnergyAlliance\\Shablon\\Счет.docx");
        }

    }
}
