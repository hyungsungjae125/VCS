using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCS_winform.Modules;

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

            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(40, 40));
            ht.Add("point", new Point(700, 70));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "file_delete_btn");
            ht.Add("text", "");
            ht.Add("click", (EventHandler)file_delete_btn_click);
            file_delete_btn = common.GetButton(ht, parentForm);
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
            ht.Add("text", "모집등록");
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
        }

        private void delete_btn_click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void file_delete_btn_click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void file_add_btn_click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cancel_btn_click(object sender, EventArgs e)
        {
            parentForm.Close();
        }

        private void ok_btn_click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
