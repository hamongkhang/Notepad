using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myNotepad
{

    public partial class Form1 : Form
    {
        String fileName = "NoName";
        public static string FindText;
        public static string X;
        int d;
        public Form1()
        {
            InitializeComponent();
        }
        private void SaveSetting()
        {
            Properties.Settings.Default.Location = this.Location;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Font = txtVanBan.Font;
            Properties.Settings.Default.WordWrap = txtVanBan.WordWrap;
            Properties.Settings.Default.Save();
        }
        private void LoadSetting()
        {
            this.Location = Properties.Settings.Default.Location;
            this.Height = Properties.Settings.Default.Height;
            this.Width = Properties.Settings.Default.Width;
            searchToolStripMenuItem.Checked= Properties.Settings.Default.Bar;
            txtVanBan.Font = Properties.Settings.Default.Font;
            txtVanBan.WordWrap = Properties.Settings.Default.WordWrap;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSetting();
            this.Text = fileName + " - Notepad";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSetting();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            txtVanBan.SelectionFont = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, fontDialog1.Font.Style);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(fileName, txtVanBan.Text);
                this.Text = fileName + " - Notepad";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == "NoName")
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
            else
            {
                System.IO.File.WriteAllText(fileName, txtVanBan.Text);
                this.Text = fileName + " - Notepad";
            }
        }

        private void txtVanBan_TextChanged(object sender, EventArgs e)
        {
            if (txtVanBan.Modified)
            {
                this.Text = fileName + " - Notepad" + "*";
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtVanBan.Modified)
            {
                if (MessageBox.Show("Bạn có muốn lưu tập tin đang soạn thảo hay không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
            }
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                txtVanBan.Text = System.IO.File.ReadAllText(fileName);
                this.Text = fileName + " - Notepad";
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtVanBan.Modified)
            {
                if (MessageBox.Show("Bạn có muốn lưu tập tin đang soạn thảo hay không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
            }
            fileName = "NoName";
            txtVanBan.Text = "";
            this.Text = fileName + " - Notepad";
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customizeToolStripMenuItem.Checked)
            {
                txtVanBan.WordWrap = true;
            }
            else
            {
                txtVanBan.WordWrap = false;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtVanBan.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtVanBan.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtVanBan.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtVanBan.Copy();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            txtVanBan.SelectedText = "";
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtVanBan.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtVanBan.SelectAll();
        }

        private void highlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            txtVanBan.SelectionBackColor = colorDialog1.Color;
        }

        private void txtVanBan_TextChanged_1(object sender, EventArgs e)
        {
            if (txtVanBan.Text.Length > 0)
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
            }
            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            Form2 r = new Form2();
            r.ShowDialog();
            if (FindText != "")
            {
                d=txtVanBan.Find(FindText);
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (FindText != "")
            {
                d = txtVanBan.Find(FindText, (d + 1), txtVanBan.Text.Length, RichTextBoxFinds.None);
            }
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            txtVanBan.SelectionColor = colorDialog1.Color;
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            txtVanBan.BackColor = colorDialog1.Color;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            if (txtVanBan.Modified)
            {
                if (MessageBox.Show("Bạn có muốn lưu tập tin đang soạn thảo hay không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
            }
            fileName = "NoName";
            txtVanBan.Text = "";
            this.Text = fileName + " - Notepad";
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (txtVanBan.Modified)
            {
                if (MessageBox.Show("Bạn có muốn lưu tập tin đang soạn thảo hay không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
            }
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                txtVanBan.Text = System.IO.File.ReadAllText(fileName);
                this.Text = fileName + " - Notepad";
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (fileName == "NoName")
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
            else
            {
                System.IO.File.WriteAllText(fileName, txtVanBan.Text);
                this.Text = fileName + " - Notepad";
            }
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            txtVanBan.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            txtVanBan.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            txtVanBan.Paste();
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtVanBan.ZoomFactor = txtVanBan.ZoomFactor + 5;
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtVanBan.ZoomFactor = txtVanBan.ZoomFactor - 5;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            txtVanBan.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            txtVanBan.SelectionAlignment = HorizontalAlignment.Right;

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            txtVanBan.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            txtVanBan.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            txtVanBan.SelectionColor = colorDialog1.Color;
            button1.ForeColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            txtVanBan.SelectionBackColor = colorDialog1.Color;
            button2.BackColor = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            txtVanBan.BackColor = colorDialog1.Color;
            button3.BackColor= colorDialog1.Color;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtVanBan.SelectionFont = new Font(txtVanBan.Font, FontStyle.Bold);
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            txtVanBan.SelectionFont = new Font(txtVanBan.Font, FontStyle.Bold);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtVanBan.SelectionFont = new Font(txtVanBan.Font, FontStyle.Italic);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            txtVanBan.SelectionFont = new Font(txtVanBan.Font, FontStyle.Underline);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {           
                statusStrip1.Hide();                
        }
    }
}
