using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VCS_winform.Modules
{
    class Common
    {
        // MDI구현하기 위한 모듈
        public Form GetMdiForm(Form parentForm, Form tagetForm, Control parentDomain)
        {
            parentForm.IsMdiContainer = true;
            tagetForm.MdiParent = parentForm;
            tagetForm.WindowState = FormWindowState.Maximized;
            tagetForm.FormBorderStyle = FormBorderStyle.None;
            tagetForm.Dock = DockStyle.Fill;
            parentDomain.Controls.Add(tagetForm);
            return tagetForm;
        }
        // Panel 모듈
        public Panel GetPanel(Hashtable hashtable, Control parentDomain)
        {
            Panel panel = new Panel();
            panel.Size = (Size)hashtable["size"];
            panel.Location = (Point)hashtable["point"];
            panel.BackColor = (Color)hashtable["color"];
            panel.Name = hashtable["name"].ToString();
            parentDomain.Controls.Add(panel);
            return panel;
        }
        // Label 모듈
        public Label GetLabel(Hashtable hashtable, Control parentDomain)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Location = (Point)hashtable["point"];
            label.Name = hashtable["name"].ToString();
            label.Text = hashtable["text"].ToString();
            label.Font = (Font)hashtable["font"];
            parentDomain.Controls.Add(label);
            return label;
        }
        // Button 모듈
        public Button GetButton(Hashtable hashtable, Control parentDomain)
        {
            Button button = new Button();
            button.TabStop = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Size = (Size)hashtable["size"];
            button.Location = (Point)hashtable["point"];
            button.BackColor = (Color)hashtable["color"];
            button.Name = hashtable["name"].ToString();
            button.Text = hashtable["text"].ToString();
            button.Font = (Font)hashtable["font"];
            button.Click += (EventHandler)hashtable["click"];
            button.Cursor = Cursors.Hand;
            parentDomain.Controls.Add(button);
            return button;
        }
        // Textbox 모듈
        public TextBox GetTextBox(Hashtable hashtable, Control parentDomain)
        {
            TextBox textBox = new TextBox();
            textBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            textBox.Location = (Point)hashtable["point"];
            textBox.Name = hashtable["name"].ToString();
            parentDomain.Controls.Add(textBox);
            return textBox;
        }
        // Textbox 모듈 - font 추가
        public TextBox GetTextBoxf(Hashtable hashtable, Control parentDomain)
        {
            TextBox textBox = new TextBox();
            textBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            textBox.Location = (Point)hashtable["point"];
            textBox.Name = hashtable["name"].ToString();
            textBox.Font = (Font)hashtable["font"];
            parentDomain.Controls.Add(textBox);
            return textBox;
        }
        // Combobox 모듈
        public ComboBox GetComboBox(Hashtable hashtable, Control parentDomain)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.DropDownWidth = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.Location = (Point)hashtable["point"];
            comboBox.Font = (Font)hashtable["font"];
            comboBox.Name = hashtable["name"].ToString();
            parentDomain.Controls.Add(comboBox);
            return comboBox;
        }
        // ListView 모듈
        public ListView GetListView(Hashtable hashtable, Control parentDomain)
        {
            ListView listView = new ListView();
            listView.View = View.Details;
            listView.GridLines = true;
            listView.Location = (Point)hashtable["point"];
            listView.Size = (Size)hashtable["size"];
            listView.BackColor = (Color)hashtable["color"];
            listView.Name = hashtable["name"].ToString();
            listView.CheckBoxes = true;
            listView.MouseClick += (MouseEventHandler)hashtable["click"];
            listView.Font = new Font("맑은 고딕", 14, FontStyle.Bold);
            parentDomain.Controls.Add(listView);
            return listView;
        }
        // Checkbox 모듈
        public CheckBox GetCheckBox(Hashtable hashtable, Control parentDomain)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.AutoSize = true;
            checkBox.Location = (Point)hashtable["point"];
            checkBox.Name = hashtable["name"].ToString();
            checkBox.Text = hashtable["text"].ToString();
            checkBox.Font = new Font("고딕", 15, FontStyle.Bold);
            parentDomain.Controls.Add(checkBox);
            return checkBox;
        }
        // Picturebox 모듈
        public PictureBox GetPictureBox(Hashtable hashtable, Control parentDomain)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.BackgroundImage = (Image)hashtable["image"];
            pictureBox.Location = (Point)hashtable["point"];
            pictureBox.Size = (Size)hashtable["size"];
            pictureBox.BackColor = (Color)hashtable["color"];
            parentDomain.Controls.Add(pictureBox);
            return pictureBox;
        }
        // Datatimepicker 모듈
        public DateTimePicker GetDateTimePicker(Hashtable hashtable, Control parentDomain)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Font = new Font("맑은 고딕", 11);
            dateTimePicker.Location = (Point)hashtable["point"];
            dateTimePicker.Name = hashtable["name"].ToString();
            dateTimePicker.Size = (Size)hashtable["size"];
            dateTimePicker.TabIndex = 0;
            parentDomain.Controls.Add(dateTimePicker);
            return dateTimePicker;
        }
    }
}
