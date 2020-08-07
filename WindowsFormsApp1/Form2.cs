using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public TextBox set;
        public Form2()
        {
            InitializeComponent();
        }

        public void SetName(string name, string control)
        {
            //textBox1.Text = name;
            //textBox2.Text = name;

            set.Text = name;

            if (control == "close")
            {
                label1.Focus();
            }
            if (control == "enter")
            {
                // 送出
            }
        }

        private void keyboard(TextBox textBox)
        {
            using (var keyBoard = new KeyBoard(this))
            {
                keyBoard.ShowDialog();
                Global.GlobalVar = "";
                set = textBox;

                // 阻止他跳出
                if (keyBoard.ShowDialog() == DialogResult.OK)
                {
                    //someControlOnForm1.Text = form2.TheValue;
                }
            }
        }

        private void textBox1_MouseHover_1(object sender, EventArgs e)
        {
            keyboard(textBox1);
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            keyboard(textBox2);
        }
        
    }
}
