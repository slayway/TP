using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project
{
    public partial class Documents : Form
    {
        private BindingSource bs = new BindingSource();
        private DBHelper db = new DBHelper();
        private OpenFileDialog openFile = new OpenFileDialog();       
        DialogResult result = new DialogResult();
        int taskId;
        /// <summary>
        /// скрывает компоненты для добавления
        /// </summary>
        public void visibleFalse()
        {
            label1.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            buttonOkAdd.Visible = false;
            buttonOpenFile.Visible = false;
        }
        /// <summary>
        /// показывает компоненты для добавления
        /// </summary>
        public void visibleTrue()
        {
            label1.Visible = true;
            label3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            buttonOkAdd.Visible = true;
            buttonOpenFile.Visible = true;
        }
        /// <summary>
        /// отображение документов в DataGridView
        /// </summary>
        public void showDocs(int id)
        {
            dataGridView1.Refresh();
            bs = db.showDocuments(id);
            dataGridView1.DataSource = bs;
        }
        /// <summary>
        /// конструкторы
        /// </summary>
        public Documents()
        {
            InitializeComponent();
            visibleFalse();
        }
        public Documents(int id)
        {
            InitializeComponent();
            visibleFalse();
            showDocs(id);
            taskId = id;
        }
        /// <summary>
        /// добавить
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            visibleTrue();
        }
        /// <summary>
        /// выбрать файл
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            result = openFile.ShowDialog(this);
                
        }
        /// <summary>
        /// добавить документ
        /// </summary>
        private void buttonOkAdd_Click(object sender, EventArgs e)
        {          
            String tittle;
            String description;
            byte[] fileData;
            

            if (textBox1.TextLength != 0 && textBox2.TextLength != 0)
            {
                if (result == DialogResult.OK || openFile.FileNames.Length != 0)
                {
                    visibleFalse();
                    FileStream fs = new FileStream(openFile.FileName, FileMode.Open);
                    fileData = new byte[fs.Length];
                    fs.Read(fileData, 0, fileData.Length);
                    fs.Close();
                    tittle = textBox1.Text;
                    description = textBox2.Text; 
                    
                    Document doc = new Document(tittle, description, taskId, fileData);
                    if (db.addDocument(doc))
                    {
                        showDocs(taskId);
                        MessageBox.Show("Документ успешно добавлен", "Сообщение");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка добавления", "Ошибка");
                    }
                }
                else
                    MessageBox.Show("Выберите файл", "Ошибка");
            }
            else
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
        }
        /// <summary>
        /// сохранить документ
        /// </summary>

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int docId = 0;
            try
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    int index = dataGridView1.SelectedRows[0].Index;


                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out docId);
                    if (!converted)
                        return;             
                }
                else
                {
                    MessageBox.Show("Ошибка! Вы не можете выбрать больше одной строки.", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(docId.ToString(), "Ошибка");
            }

            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Все файлы(*.*)|*.*";
            result = sf.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                db.saveDoc(docId, sf.FileName);
            }         
        }
    }
}
