using System;
using System.IO;
using System.Windows.Forms;

namespace Properties_Creator
{
    public class File_Helper
    {
        public static int leftWidth = 0;
        public static void Save(Panel panel, string name, bool json)
        {
            string before = "{\n";
            string content = "";

            string right = "";
            for (int a = 0; a < panel.Controls.Count; a++)
            {
                Console.WriteLine(panel.Controls[a].Text + " " + panel.Controls[a].Name);
                TextBox tb = (TextBox)panel.Controls[a];
                if (tb.Name.Contains("Right"))
                    right = tb.Text;
                else if (tb.Name.Contains("Left") && right.Length > 0)
                {
                    if (tb.Text.Length > 0)
                    {
                        if(json)
                            content += "    \"" + tb.Text + "\" : \"" + right + "\",\n";
                        else
                            content += "    " + tb.Text + " : \"" + right + "\",\n";
                    }

                    right = "";
                }
            }
            string end = "}\n";


            File.WriteAllText(name, before + content + end);

        }

        public static void Load(Panel panel, string name)
        {
            panel.Controls.Clear();
            string file_content = File.ReadAllText(name);
            file_content = file_content.Replace("\t", "").Replace("    ", "");
            string[] items = file_content.Split('\n');

            for (int a = 1; a < items.Length - 2; a++)
            {
                string item = items[a];
                Console.WriteLine(item);
                string left = item.Split(new string[] { " : " }, StringSplitOptions.RemoveEmptyEntries)[0];
                if (left.StartsWith("\""))
                    left = left.Substring(1, left.Length - 2);

                string right = item.Split(new string[] { " : " }, StringSplitOptions.RemoveEmptyEntries)[1];
                right = right.Substring(1, right.Length - 3);


                int newY = 4 + (getCurrentRow(panel) * 28);


                int rightWidth = (panel.Width - 12) - leftWidth;

                TextBox tb_left = new TextBox();
                tb_left.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
                tb_left.Location = new System.Drawing.Point(4, newY);
                tb_left.Size = new System.Drawing.Size(leftWidth, 22);
                tb_left.TabIndex = panel.Controls.Count;
                tb_left.Name = "Field_" + getCurrentRow(panel) + "_Left";
                tb_left.Text = left;

                TextBox tb_right = new TextBox();
                tb_right.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                tb_right.Location = new System.Drawing.Point(leftWidth + 8, newY);
                tb_right.Size = new System.Drawing.Size(rightWidth, 22);
                tb_right.TabIndex = panel.Controls.Count + 1;
                tb_right.Name = "Field_" + getCurrentRow(panel) + "_Right";
                tb_right.Text = right;

                panel.Controls.Add(tb_right);
                panel.Controls.Add(tb_left);
            }
        }

        public static int getCurrentRow(Panel panel)
        {
            return panel.Controls.Count / 2;
        }
    }
}
