using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2_TaskBook
{
    public partial class Form1 : Form
    {
        private List<string> tasks; // список задач
        public Form1()
        {
            InitializeComponent();
            tasks = new List<string>();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //здесь вносятся задачи по одной
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string taskName = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(taskName))
            {
                tasks.Add(taskName);
                listBox1.Items.Add(taskName);
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex >= 0)
            {
                string editedTask = textBox1.Text.Trim();
                if (!string.IsNullOrEmpty(editedTask))
                {
                    tasks[selectedIndex] = editedTask;
                    listBox1.Items[selectedIndex] = editedTask;
                    textBox1.Clear();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex >= 0)
            {
                // Получение текущего текста задачи
                string currentTask = listBox1.Items[selectedIndex].ToString();

                // Отображение диалогового окна для редактирования задачи
                string editedTask = ShowEditDialog(currentTask);

                // Если пользователь нажал "OK" в диалоговом окне
                if (!string.IsNullOrEmpty(editedTask))
                {
                    tasks[selectedIndex] = editedTask;
                    listBox1.Items[selectedIndex] = editedTask;
                }
            }
        }
        private string ShowEditDialog(string currentTask)
        {
            using (Form editForm = new Form())
            {
                editForm.Text = "Редактировать задачу";
                editForm.Size = new Size(300, 120);
                editForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                editForm.StartPosition = FormStartPosition.CenterParent;

                TextBox editTextBox = new TextBox();
                editTextBox.Text = currentTask;
                editTextBox.Dock = DockStyle.Top;
                editTextBox.Parent = editForm;

                Button okButton = new Button();
                okButton.Text = "OK";
                okButton.DialogResult = DialogResult.OK;
                okButton.Dock = DockStyle.Left;
                okButton.Parent = editForm;

                Button cancelButton = new Button();
                cancelButton.Text = "Отмена";
                cancelButton.DialogResult = DialogResult.Cancel;
                cancelButton.Dock = DockStyle.Right;
                cancelButton.Parent = editForm;

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    return editTextBox.Text.Trim();
                }
                else
                {
                    return currentTask;
                }
            }
        }
            private void button4_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex >= 0)
            {
                tasks.RemoveAt(selectedIndex);
                listBox1.Items.RemoveAt(selectedIndex);
                textBox1.Clear();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
