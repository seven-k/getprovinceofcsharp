using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace getProvinceByCity
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK) {
                lblFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (lblFilePath.Text.Equals("文件路径")) {
                MessageBox.Show("请先选择Excel文件！", "文件路径错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            ConnectionDb.initDb(dataGridView1);
        }

       
    }
}
