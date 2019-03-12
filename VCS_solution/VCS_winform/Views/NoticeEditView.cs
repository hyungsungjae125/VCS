using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCS_winform.Modules;
using VCS_winform.Properties;

namespace VCS_winform.Views
{
    class NoticeEditView
    {
        private Common common;
        private Form parentForm, targetForm;
        private Button delete_btn,ok_btn, cancel_btn, file_add_btn, file_delete_btn;
        private TextBox name_tb, file_tb, contents_tb;
        private Hashtable ht;
        private Label name_lb, file_lb, contents_lb;
        private Image file;
        private string fileName="", fileData="";
        private string ext;
        private int nNo = 0;

        public NoticeEditView(Form parentForm)
        {
            this.parentForm = parentForm;
            common = new Common();
            getView();
        }

        public NoticeEditView(Form parentForm,int nNo)
        {
            this.parentForm = parentForm;
            this.nNo = nNo;
            common = new Common();
            getView();
        }

        private void getView()
        {
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 30));
            ht.Add("color", Color.Black);
            ht.Add("name", "name_lb");
            ht.Add("text", "공지 제목");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            name_lb = common.GetLabel(ht, parentForm);
            name_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 630);
            ht.Add("point", new Point(110, 25));
            ht.Add("name", "name_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            name_tb = common.GetTextBoxf(ht, parentForm);
            //-----------------------------------------------------------------
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 80));
            ht.Add("color", Color.Black);
            ht.Add("name", "file_lb");
            ht.Add("text", "파일 첨부");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            file_lb = common.GetLabel(ht, parentForm);
            file_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 530);
            ht.Add("point", new Point(110, 75));
            ht.Add("name", "file_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            file_tb = common.GetTextBoxf(ht, parentForm);
            file_tb.Enabled = false;

            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(40, 40));
            ht.Add("point", new Point(650, 70));
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
            ht.Add("point", new Point(700, 70));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "file_delete_btn");
            ht.Add("text", "");
            ht.Add("click", (EventHandler)file_delete_btn_click);
            file_delete_btn = common.GetButton(ht, parentForm);
            file_delete_btn.BackgroundImage = Resources.x;
            file_delete_btn.BackgroundImageLayout = ImageLayout.Stretch;
            //-----------------------------------------------------------------
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 130));
            ht.Add("color", Color.Black);
            ht.Add("name", "contents_lb");
            ht.Add("text", "공지 내용");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            contents_lb = common.GetLabel(ht, parentForm);
            contents_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 630);
            ht.Add("point", new Point(110, 125));
            ht.Add("name", "contents_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            contents_tb = common.GetTextBoxf(ht, parentForm);
            contents_tb.Multiline = true;
            contents_tb.Height = 400;
            //-----------------------------------------------------------------
            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(150, 80));
            ht.Add("point", new Point(250, 560));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "delete_btn");
            ht.Add("text", "삭제");
            ht.Add("click", (EventHandler)delete_btn_click);
            delete_btn = common.GetButton(ht, parentForm);

            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(150, 80));
            ht.Add("point", new Point(420, 560));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "ok_btn");
            ht.Add("text", "수정");
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

            Getnotice();
        }

        private void Getnotice()
        {
            WebAPI api = new WebAPI();

            ht = new Hashtable();
            ht.Add("nno", nNo);
            string result = api.Post(Program.serverUrl + "api/noticedetail", ht);

            ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);

            JObject jo = (JObject)list[0];
            if (Convert.ToInt32(jo["mNo"]) != Program.userInfo.MNo)
            {
                name_tb.Enabled = false;
                contents_tb.Enabled = false;
                file_add_btn.Enabled = false;
                file_delete_btn.Enabled = false;
                delete_btn.Enabled = false;
                ok_btn.Enabled = false;
            }
            name_tb.Text = jo["nTitle"].ToString();
            file_tb.Text = jo["nUrl"].ToString();
            contents_tb.Text = jo["nContents"].ToString();
        }

        private void delete_btn_click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("정말 삭제하시겠습니까?","공지삭제여부",MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                WebAPI api = new WebAPI();

                ht = new Hashtable();
                ht.Add("nno", nNo);
                ht.Add("nurl", file_tb.Text);
                string resultStr = api.Post(Program.serverUrl + "api/noticedelete", ht);
                //MessageBox.Show("삭제함");
            }
            else
            {
                //MessageBox.Show("취소함");
            }
            return;

        }

        private void file_delete_btn_click(object sender, EventArgs e)
        {
            if(file!=null)
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

        private void cancel_btn_click(object sender, EventArgs e)
        {
            parentForm.Close();
        }

        private void ok_btn_click(object sender, EventArgs e)
        {
            WebAPI api = new WebAPI();

            ht = new Hashtable();
            ht.Add("nNo", nNo);
            ht.Add("mNo", Program.userInfo.MNo);
            ht.Add("nTitle", name_tb.Text);
            ht.Add("nContents", contents_tb.Text);
            ht.Add("fileName", fileName);
            MessageBox.Show("/" + fileName + "/");
            if (fileName != "")
            {
                MemoryStream ms = new MemoryStream();
                file.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imgData = ms.ToArray();

                fileData = Convert.ToBase64String(imgData);
            }
            MessageBox.Show("/" + fileData + "/");
            ht.Add("fileData", fileData);

            string result = api.Post(Program.serverUrl + "api/noticeupdate", ht);
            if (result == "1")
            {
                MessageBox.Show("공지등록!!");
            }
            parentForm.Close();
        }
    }
}
