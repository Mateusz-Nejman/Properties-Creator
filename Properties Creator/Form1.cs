using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Properties_Creator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            File_Helper.leftWidth = (this.panel1.Width - 12) / 3;


        }

        private void ButtonAddElement_Click(object sender, EventArgs e)
        {
            int newY = 4 + (File_Helper.getCurrentRow(this.panel1) * 28);


            int rightWidth = (this.panel1.Width - 12) - File_Helper.leftWidth;

            TextBox tb_left = new TextBox();
            tb_left.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
            tb_left.Location = new System.Drawing.Point(4, newY);
            tb_left.Size = new System.Drawing.Size(File_Helper.leftWidth, 22);
            tb_left.TabIndex = this.panel1.Controls.Count;
            tb_left.Name = "Field_" + File_Helper.getCurrentRow(this.panel1) + "_Left";

            TextBox tb_right = new TextBox();
            tb_right.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            tb_right.Location = new System.Drawing.Point(File_Helper.leftWidth + 8, newY);
            tb_right.Size = new System.Drawing.Size(rightWidth, 22);
            tb_right.TabIndex = this.panel1.Controls.Count + 1;
            tb_right.Name = "Field_" + File_Helper.getCurrentRow(this.panel1) + "_Right";

            this.panel1.Controls.Add(tb_right);
            this.panel1.Controls.Add(tb_left);





        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Title = "Save json or javascript object file(*.json)";
            SaveFileDialog1.DefaultExt = "json";
            SaveFileDialog1.Filter = "json files (*.json)|*.json";

            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                File_Helper.Save(this.panel1, SaveFileDialog1.FileName,this.checkBox1.Checked);
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.DefaultExt = "json";
            openFileDialog1.Title = "Open json or javascript object file(*.json)";
            openFileDialog1.Filter = "json files (*.json)|*.json";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                File_Helper.Load(this.panel1, openFileDialog1.FileName);
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
        }
    }
}
