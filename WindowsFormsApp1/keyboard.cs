using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class KeyBoard : Form
    {
        // 英文字母陣列
        List<string> word = new List<string>();
        public Form2 form2;

        public KeyBoard(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2;
            Dictionary();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (button.Tag +"" == "close")
                {
                    this.Hide();
                    form2.SetName(Global.GlobalVar, "close");
                }
                else if (button.Tag + "" == "enter")
                {
                    form2.SetName(Global.GlobalVar, "enter");
                }
                else if (button.Tag + "" == "clear")
                {
                    if(Global.GlobalVar.Length != 0)
                    {
                        Global.GlobalVar = Global.GlobalVar.Remove(Global.GlobalVar.Length - 1);
                        form2.SetName(Global.GlobalVar, null);
                    }
                }
                else
                {
                    Global.GlobalVar += button.Tag + "";
                    form2.SetName(Global.GlobalVar, null);
                }
            }
        }

        private void Dictionary()
        {
            StreamReader str = new StreamReader(@"C:\Users\Done-02\source\repos\WindowsFormsApp1\WindowsFormsApp1\Dictionary.txt");
            string ReadAll = str.ReadToEnd();
            str.Close();

            string[] words = ReadAll.Split(',');

            foreach (var item in words)
            {
                word.Add($"{item}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 隱藏上方titleBar
            ControlBox = false;
            Text = String.Empty;

            // 自動調整視窗大小
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            int keysize = Convert.ToInt32(ConfigurationManager.AppSettings["keysize"]);
            int keyrow = Convert.ToInt32(ConfigurationManager.AppSettings["keyrow"]);
            int controlkey = Convert.ToInt32(ConfigurationManager.AppSettings["controlkey"]);

            // 字母鍵盤
            for (int i = 0; i < word.Count; i++)
            {
                Button button = new Button();
                button.Width = keysize;
                button.Height = keysize;
                button.Text = word[i];
                button.Location = new Point(keysize * (i % keyrow), keysize * (i / keyrow));
                button.Click += new EventHandler(ButtonClick);
                button.Tag = word[i];
                this.Controls.Add(button);
            }

            #region 功能鍵
            // Clear btn
            Button clearbtn = new Button();
            clearbtn.Width = controlkey;
            clearbtn.Height = controlkey;
            clearbtn.Text = "清除";
            clearbtn.Location = new Point(keysize * keyrow, controlkey * 0);
            clearbtn.Click += new EventHandler(ButtonClick);
            clearbtn.Tag = "clear";
            this.Controls.Add(clearbtn);

            // Clear btn
            Button enterbtn = new Button();
            enterbtn.Width = controlkey;
            enterbtn.Height = controlkey;
            enterbtn.Text = "送出";
            enterbtn.Location = new Point(keysize * keyrow, controlkey * 1);
            enterbtn.Click += new EventHandler(ButtonClick);
            enterbtn.Tag = "enter";
            this.Controls.Add(enterbtn);

            // Close btn
            Button closebtn = new Button();
            closebtn.Width = controlkey;
            closebtn.Height = controlkey;
            closebtn.Text = "關閉";
            closebtn.Location = new Point(keysize * keyrow, controlkey * 2);
            closebtn.Click += new EventHandler(ButtonClick);
            closebtn.Tag = "close";
            this.Controls.Add(closebtn);
            #endregion
        }
    }
}
