using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCS_winform.Forms;
using VCS_winform.Modules;

namespace VCS_winform.Views
{
    class ApplyView
    {
        private Common common;
        private Form parentForm, targetForm;
        private ListView apply_lv;
        private Button applyadd_btn;
        private Hashtable ht;

        public ApplyView(Form parentForm)
        {
            this.parentForm = parentForm;
            common = new Common();
            getView();
        }

        private void getView()
        {
            ht = new Hashtable();
            ht.Add("color", Color.White);
            ht.Add("name", "listView");
            ht.Add("point", new Point(10, 20));
            ht.Add("size", new Size(860, 340));
            ht.Add("click", (MouseEventHandler)listView_click);
            apply_lv = common.GetListView(ht, parentForm);
            apply_lv.Columns.Add("번호", 55, HorizontalAlignment.Center);
            apply_lv.Columns.Add("제목", 400, HorizontalAlignment.Center);
            apply_lv.Columns.Add("작성자", 200, HorizontalAlignment.Center);
            apply_lv.Columns.Add("작성일", 200, HorizontalAlignment.Center);
            apply_lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            apply_lv.ColumnWidthChanging += ListView_ColumnWidthChanging;

            //새모집등록 버튼 추가
            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(200, 60));
            ht.Add("point", new Point(670, 380));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "answer_btn");
            ht.Add("text", "새 모집등록");
            ht.Add("click", (EventHandler)applyadd_btn_click);
            applyadd_btn = common.GetButton(ht, parentForm);

            getList();
        }

        private void applyadd_btn_click(object sender, EventArgs e)
        {
            // form 초기화
            if (targetForm != null) targetForm.Dispose();
            targetForm = new ApplyAddForm();
            targetForm.StartPosition = parentForm.StartPosition;
            // form 호출
            targetForm.ShowDialog();
        }

        private void getList()
        {
            
        }

        private void ListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = apply_lv.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void listView_click(object sender,EventArgs e)
        {
           
        }
    }
}
