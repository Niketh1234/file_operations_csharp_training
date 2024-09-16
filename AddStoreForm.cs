using CustomPad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomPad
{
    public partial class AddStoreForm : Form
    {
        public AddStoreForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Store s = new Store();
            s.Id = Convert.ToInt32(textBox1.Text);
            s.Name = textBox2.Text;
            s.Price = textBox3.Text;
            string store = JsonSerializer.Serialize(s);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            File.WriteAllText(saveFileDialog.FileName, store);

        }

        private void btnShowStore_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(this);
            string s = File.ReadAllText(openFileDialog.FileName);
            Store ss = JsonSerializer.Deserialize<Store>(s);
            textBox1.Text = ss.Id.ToString();
            textBox2.Text = ss.Name;
            textBox3.Text = ss.Price;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
