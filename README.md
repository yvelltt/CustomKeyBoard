# CustomKeyBoard
Winform

### Start setting ###
Set the keyboard value by using Dictionary.txt
For example:
A,B,C,0.....etc

Important!
please using command to spearate(default)

``` C sharp
 private void Dictionary()
        {
            StreamReader str = new StreamReader(@"C:\Users\Done-02\source\repos\WindowsFormsApp1\WindowsFormsApp1\Dictionary.txt");
            string ReadAll = str.ReadToEnd();
            str.Close();

            string[] words = ReadAll.Split(','); // using command to spearate

            foreach (var item in words)
            {
                word.Add($"{item}");
            }
        }
```

You can change keyboardsize / row / controlkeyboard in App.config
``` 
<appSettings>
		<add key="keysize" value="50"/>
		<add key="keyrow" value="9"/>
		<add key="controlkey" value="67"/>
</appSettings>
```
--------------------------------------- 
### How to use in form ###

KeyBoard Event
``` C sharp
public void SetName(string name, string control)
        {
            //textBox1.Text = name;
            //textBox2.Text = name;

            set.Text = name;  // "set" is using to set which one textbox is focused.

            if (control == "close")
            {
                label1.Focus();
            }
            if (control == "enter")
            {
                // 送出
            }
        }
```
Open KeyBoard Setting and textBox value set 
``` C sharp
private void keyboard(TextBox textBox)
        {
            using (var keyBoard = new KeyBoard(this)) // open form by using then can avoid DI problem
            {
                keyBoard.ShowDialog();
                Global.GlobalVar = "";  // using global value to remember the keyboard send value
                set = textBox; // this is set the textBox

                // 阻止他跳出 I not sure how to stop Dialog Disappear so this magic way(not a good way)
                if (keyBoard.ShowDialog() == DialogResult.OK)
                {
                    //someControlOnForm1.Text = form2.TheValue;
                }
            }
        }
```

``` C sharp
private void textBox1_MouseHover_1(object sender, EventArgs e)
        {
            keyboard(textBox1); // send what you want to set the textbox
        }
```


