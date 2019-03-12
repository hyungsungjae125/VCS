using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCS_winform.Modules;
using VCS_winform.Properties;

namespace VCS_winform.Views
{
    class AnswerView
    {
        private Common common;
        private Form parentForm, targetForm;
        private int qNo;
        private Panel contents;
        private Hashtable ht;
        private Label file_lb, contents_lb,atitle_lb, qcontents_lb, qfile_lb, qtitle_lb, writer_lb, writeday_lb;
        private TextBox file_tb, contents_tb,atitle_tb, qcontents_tb, qfile_tb, writer_tb, writeday_tb;
        private Button file_add_btn, file_delete_btn, ok_btn, cancel_btn,filewatch_btn;
        private Image file;
        private string fileName;
        private string ext;
        private TextBox qtitle_tb;
        private string fileData;

        public AnswerView(Form parentForm,int qNo)
        {
            this.parentForm = parentForm;
            this.qNo = qNo;
            common = new Common();
            getView();
        }

        private void getView()
        {
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 30));
            ht.Add("color", Color.Black);
            ht.Add("name", "qtitle_lb");
            ht.Add("text", "      제목");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            qtitle_lb = common.GetLabel(ht, parentForm);
            qtitle_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 630);
            ht.Add("point", new Point(110, 25));
            ht.Add("name", "qtitle_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            qtitle_tb = common.GetTextBoxf(ht, parentForm);
            qtitle_tb.Enabled = false;
            qtitle_tb.BackColor = Color.White;

            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 60));
            ht.Add("color", Color.Black);
            ht.Add("name", "writer_lb");
            ht.Add("text", "   작성자");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            writer_lb = common.GetLabel(ht, parentForm);
            writer_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 250);
            ht.Add("point", new Point(110, 55));
            ht.Add("name", "writer_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            writer_tb = common.GetTextBoxf(ht, parentForm);
            writer_tb.Enabled = false;
            writer_tb.BackColor = Color.White;

            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(390, 60));
            ht.Add("color", Color.Black);
            ht.Add("name", "writeday_lb");
            ht.Add("text", " 작성일");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            writeday_lb = common.GetLabel(ht, parentForm);
            writeday_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 250);
            ht.Add("point", new Point(490, 55));
            ht.Add("name", "writeday_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            writeday_tb = common.GetTextBoxf(ht, parentForm);
            writeday_tb.Enabled = false;
            writeday_tb.BackColor = Color.White;

            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 90));
            ht.Add("color", Color.Black);
            ht.Add("name", "qfile_lb");
            ht.Add("text", "첨부 파일");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            qfile_lb = common.GetLabel(ht, parentForm);
            qfile_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 590);
            ht.Add("point", new Point(110, 85));
            ht.Add("name", "qfile_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            qfile_tb = common.GetTextBoxf(ht, parentForm);
            qfile_tb.Enabled = false;
            qfile_tb.BackColor = Color.White;

            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(40, 30));
            ht.Add("point", new Point(700, 85));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "filewatch_btn");
            ht.Add("text", "");
            ht.Add("click", (EventHandler)filewatch_btn_click);
            filewatch_btn = common.GetButton(ht, parentForm);
            filewatch_btn.BackgroundImage = Resources.picture;
            filewatch_btn.BackgroundImageLayout = ImageLayout.Stretch;

            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 125));
            ht.Add("color", Color.Black);
            ht.Add("name", "qcontents_lb");
            ht.Add("text", "질문 내용");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            qcontents_lb = common.GetLabel(ht, parentForm);
            qcontents_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 630);
            ht.Add("point", new Point(110, 120));
            ht.Add("name", "qcontents_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            qcontents_tb = common.GetTextBoxf(ht, parentForm);
            qcontents_tb.Multiline = true;
            qcontents_tb.Height = 170;
            qcontents_tb.Enabled = false;
            qcontents_tb.BackColor = Color.White;
            //----------------------------------------------------------
            ht = new Hashtable();
            ht.Add("point", new Point(0, 310   ));
            ht.Add("size", new Size(900, 1));
            ht.Add("color", Color.Black);
            ht.Add("name", "contents");
            contents = common.GetPanel(ht, parentForm);
            //-----------------------------------------------------------
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 330));
            ht.Add("color", Color.Black);
            ht.Add("name", "atitle_lb");
            ht.Add("text", "답변 제목");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            atitle_lb = common.GetLabel(ht, parentForm);
            atitle_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 630);
            ht.Add("point", new Point(110, 325));
            ht.Add("name", "atitle_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            atitle_tb = common.GetTextBoxf(ht, parentForm);           

            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 365));
            ht.Add("color", Color.Black);
            ht.Add("name", "contents_lb");
            ht.Add("text", "답변 내용");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            contents_lb = common.GetLabel(ht, parentForm);
            contents_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 630);
            ht.Add("point", new Point(110, 360));
            ht.Add("name", "contents_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            contents_tb = common.GetTextBoxf(ht, parentForm);
            contents_tb.Multiline = true;
            contents_tb.Height = 145;

            //--------------------------------------------------------------
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 520));
            ht.Add("color", Color.Black);
            ht.Add("name", "file_lb");
            ht.Add("text", "파일 첨부");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            file_lb = common.GetLabel(ht, parentForm);
            file_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 430);
            ht.Add("point", new Point(110, 515));
            ht.Add("name", "file_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            file_tb = common.GetTextBoxf(ht, parentForm);
            file_tb.Enabled = false;
            file_tb.BackColor = Color.White;

            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(40, 40));
            ht.Add("point", new Point(550, 510));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "file_add_btn");
            ht.Add("text", "");
            ht.Add("click", (EventHandler)file_add_btn_click);
            file_add_btn = common.GetButton(ht, parentForm);
            file_add_btn.BackgroundImage = Resources.folder;
            file_add_btn.BackgroundImageLayout = ImageLayout.Stretch;

            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(40, 40));
            ht.Add("point", new Point(600, 510));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "file_delete_btn");
            ht.Add("text", "");
            ht.Add("click", (EventHandler)file_delete_btn_click);
            file_delete_btn = common.GetButton(ht, parentForm);
            file_delete_btn.BackgroundImage = Resources.x;
            file_delete_btn.BackgroundImageLayout = ImageLayout.Stretch;

            //---------------------------------------------------------
            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(150, 80));
            ht.Add("point", new Point(420, 560));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "ok_btn");
            ht.Add("text", "답변등록");
            ht.Add("click", (EventHandler)ok_btn_click);
            ok_btn = common.GetButton(ht, parentForm);

            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(150, 80));
            ht.Add("point", new Point(590, 560));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "cancel_btn");
            ht.Add("text", "취소");
            ht.Add("click", (EventHandler)cancel_btn_click);
            cancel_btn = common.GetButton(ht, parentForm);

            getDetail();
        }

        private void filewatch_btn_click(object sender, EventArgs e)
        {
            // 차후 구현 해야 할 부분
            WebClient wc = new WebClient();
            Image fileimage = Image.FromStream(wc.OpenRead(Program.serverUrl + file_tb.Text));
            MessageBox.Show("이미지 보여주기");
        }

        private void getDetail()
        {
            WebAPI api = new WebAPI();

            ht = new Hashtable();
            ht.Add("qNo", qNo);
            string result = api.Post(Program.serverUrl + "api/questiondetail", ht);

            ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);

            JObject jo = (JObject)list[0];
            if (Program.userInfo.DNo!=3)
            {
                contents_tb.Enabled = false;
                file_add_btn.Enabled = false;
                file_delete_btn.Enabled = false;
                ok_btn.Enabled = false;
            }
            qtitle_tb.Text = jo["qTitle"].ToString();
            qfile_tb.Text = jo["qUrl"].ToString();
            qcontents_tb.Text = jo["qContents"].ToString();
            writer_tb.Text = jo["mName"].ToString();
            writeday_tb.Text = jo["regdate"].ToString();
        }

        private void cancel_btn_click(object sender, EventArgs e)
        {
            parentForm.Close();
        }

        private void ok_btn_click(object sender, EventArgs e)
        {
            WebAPI api = new WebAPI();

            ht = new Hashtable();
            ht.Add("qNo", qNo);
            ht.Add("dNo", Program.userInfo.DNo);
            ht.Add("aTitle", atitle_tb.Text);
            ht.Add("aContents", contents_tb.Text);
            ht.Add("fileName", fileName);

            //MessageBox.Show("/" + fileName + "/");
            if (fileName != "")
            {
                MemoryStream ms = new MemoryStream();
                file.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imgData = ms.ToArray();

                fileData = Convert.ToBase64String(imgData);
            }
            //MessageBox.Show("/" + fileData + "/");
            ht.Add("fileData", fileData);

            string result = api.Post(Program.serverUrl + "api/answerinsert", ht);
            if (result == "1")
            {
                MessageBox.Show("답변등록!!");
            }
            parentForm.Close();
        }

        private void file_delete_btn_click(object sender, EventArgs e)
        {
            if (file != null)
                file.Dispose();

            file_tb.Text = "";
        }

        private void file_add_btn_click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Images only. |*.png; *.jpg; *.jpeg; *.gif;";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName;

                file = Image.FromFile(filePath);

                fileName = openFile.SafeFileName;
                file_tb.Text = fileName;
                ext = fileName.Substring(fileName.LastIndexOf("."));

            }
            else { }
        }
    }
}
