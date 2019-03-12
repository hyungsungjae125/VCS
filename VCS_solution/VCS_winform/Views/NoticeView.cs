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
using static System.Windows.Forms.ListView;

namespace VCS_winform.Views
{
    class NoticeView
    {
        private Common common;
        private Form parentForm, targetForm;
        private ListView notice_lv;
        private Button noticeadd_btn;
        private Hashtable ht;

        public NoticeView(Form parentForm)
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
            notice_lv = common.GetListView(ht, parentForm);
            notice_lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            notice_lv.Columns.Add("공지제목", 335, HorizontalAlignment.Center);
            notice_lv.Columns.Add("작성자", 150, HorizontalAlignment.Center);
            notice_lv.Columns.Add("작성일", 250, HorizontalAlignment.Center);
            notice_lv.Columns.Add("조회수", 70, HorizontalAlignment.Center);
            notice_lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            notice_lv.ColumnWidthChanging += ListView_ColumnWidthChanging;

            //새모집등록 버튼 추가
            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(200, 60));
            ht.Add("point", new Point(670, 380));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "noticeadd_btn");
            ht.Add("text", "새 공지등록");
            ht.Add("click", (EventHandler)noticeadd_btn_click);
            noticeadd_btn = common.GetButton(ht, parentForm);

            getList();
        }

        private void noticeadd_btn_click(object sender, EventArgs e)
        {
            // form 초기화
            if (targetForm != null) targetForm.Dispose();
            targetForm = new NoticeAddForm();
            targetForm.StartPosition = parentForm.StartPosition;
            // form 호출
            targetForm.ShowDialog();
            getList();
        }

        private void getList()
        {
            WebAPI api = new WebAPI();
            if (!api.GetListView(Program.serverUrl + "api/noticelist", notice_lv))
            {
                MessageBox.Show("리스트 불러오기 실패");
            }
        }

        private void ListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = notice_lv.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void listView_click(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;
            SelectedListViewItemCollection col = listView.SelectedItems;
            ListViewItem item = col[0];
            //MessageBox.Show(item.SubItems[0].Text + "선택");

            // form 초기화
            if (targetForm != null) targetForm.Dispose();
            targetForm = new NoticeEditForm(Convert.ToInt32(item.SubItems[0].Text));
            targetForm.StartPosition = parentForm.StartPosition;
            // form 호출
            targetForm.ShowDialog();
            getList();
        }
    }
}
