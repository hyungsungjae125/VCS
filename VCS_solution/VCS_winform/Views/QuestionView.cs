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
    class QuestionView
    {
        private Common common;
        private Form parentForm, targetForm;
        private ListView question_lv;
        private Hashtable ht;

        public QuestionView(Form parentForm)
        {
            this.parentForm = parentForm;
            common = new Common();
            getView();
        }

        private void getView()
        {
            ht = new Hashtable();
            ht.Add("color", Color.White);
            ht.Add("name", "question_lv");
            ht.Add("point", new Point(10, 20));
            ht.Add("size", new Size(860, 340));
            ht.Add("click", (MouseEventHandler)listView_click);
            question_lv = common.GetListView(ht, parentForm);
            question_lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            question_lv.Columns.Add("제목", 335, HorizontalAlignment.Center);
            question_lv.Columns.Add("작성자", 150, HorizontalAlignment.Center);
            question_lv.Columns.Add("작성일", 250, HorizontalAlignment.Center);
            question_lv.Columns.Add("조회수", 70, HorizontalAlignment.Center);
            question_lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            question_lv.ColumnWidthChanging += ListView_ColumnWidthChanging;
            
            getList();
        }
        

        private void getList()
        {
            WebAPI api = new WebAPI();
            if (!api.GetListView(Program.serverUrl + "api/questionlist", question_lv))
            {
                MessageBox.Show("리스트 불러오기 실패");
            }
        }

        private void ListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = question_lv.Columns[e.ColumnIndex].Width;
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
            targetForm = new AnswerForm(Convert.ToInt32(item.SubItems[0].Text));
            targetForm.StartPosition = parentForm.StartPosition;
            // form 호출
            targetForm.ShowDialog();
            getList();
        }
    }
}
