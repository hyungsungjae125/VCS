﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCS_winform.Views;

namespace VCS_winform.Modules
{
    class Load
    {
        private Form target;//MDI부분에서 타겟폼/현재 띄워주고 싶은 폼
        private Form parent;//MDI부분에서 부모폼
        private int No;

        public Load(Form target)
        {
            this.target = target;
        }
        public Load(Form target,int No)
        {
            this.target = target;
            this.No = No;
        }
        public EventHandler GetHandler(string viewName)
        {
            switch (viewName)
            {
                case "main":
                    return GetMainLoad;
                case "login":
                    return GetLoginLoad;
                case "apply":
                    return GetApplyLoad;
                case "applyadd":
                    return GetApplyAddLoad;
                case "applyedit":
                    return GetApplyEditLoad;
                case "certification":
                    return GetCertificationLoad;
                case "certificationdetail":
                    return GetCertificationDetailLoad;
                case "notice":
                    return GetNoticeLoad;
                case "noticeadd":
                    return GetNoticeAddLoad;
                case "noticeedit":
                    return GetNoticeEditLoad;
                case "question":
                    return GetQuestionLoad;
                case "answer":
                    return GetAnswerLoad;
                default:
                    return null;
            }
        }
        //--------------------메인화면---------------------------
        private void GetMainLoad(object sender, EventArgs e)
        {
            target.Size = new Size(900, 600);
            target.FormBorderStyle = FormBorderStyle.FixedSingle;
            target.MaximizeBox = false;
            target.MinimizeBox = false;
            target.Text = "관리자메인화면";
            new MainView(target);
        }
        //--------------------로그인화면---------------------------
        private void GetLoginLoad(object sender, EventArgs e)
        {
            target.Size = new Size(900, 600);
            target.FormBorderStyle = FormBorderStyle.FixedSingle;
            target.MaximizeBox = false;
            target.MinimizeBox = false;
            target.Text = "관리자로그인";
            new LoginView(target);
        }
        //--------------------모집화면---------------------------
        private void GetApplyLoad(object sender, EventArgs e)
        {
            target.Size = new Size(900, 490);
            target.FormBorderStyle = FormBorderStyle.None;
            target.MaximizeBox = false;
            target.MinimizeBox = false;
            target.Text = "봉사모집";
            new ApplyView(target);
        }
        //--------------------모집추가화면---------------------------
        private void GetApplyAddLoad(object sender, EventArgs e)
        {
            target.Size = new Size(800, 700);
            target.FormBorderStyle = FormBorderStyle.FixedSingle;
            target.MaximizeBox = false;
            target.MinimizeBox = false;
            target.Text = "봉사모집추가";
            new ApplyAddView(target);
        }
        //--------------------모집수정화면---------------------------
        private void GetApplyEditLoad(object sender, EventArgs e)
        {
            target.Size = new Size(800, 700);
            target.FormBorderStyle = FormBorderStyle.FixedSingle;
            target.MaximizeBox = false;
            target.MinimizeBox = false;
            target.Text = "봉사모집수정";
            new ApplyEditView(target,No);
        }
        //--------------------봉사인증화면---------------------------
        private void GetCertificationLoad(object sender, EventArgs e)
        {
            target.Size = new Size(900, 490);
            target.FormBorderStyle = FormBorderStyle.None;
            target.MaximizeBox = false;
            target.MinimizeBox = false;
            target.Text = "외부봉사인증";
            new CertificationView(target);
        }
        //--------------------봉사인증상세화면---------------------------
        private void GetCertificationDetailLoad(object sender, EventArgs e)
        {
            target.Size = new Size(800, 700);
            target.FormBorderStyle = FormBorderStyle.FixedSingle;
            target.MaximizeBox = false;
            target.MinimizeBox = false;
            target.Text = "외부봉사인증상세";
            new CertificationDetailView(target,No);
        }
        //--------------------공지화면---------------------------
        private void GetNoticeLoad(object sender, EventArgs e)
        {
            target.Size = new Size(900, 490);
            target.FormBorderStyle = FormBorderStyle.None;
            target.MaximizeBox = false;
            target.MinimizeBox = false;
            target.Text = "공지";
            new NoticeView(target);
        }
        //--------------------공지추가화면---------------------------
        private void GetNoticeAddLoad(object sender, EventArgs e)
        {
            target.Size = new Size(800, 700);
            target.FormBorderStyle = FormBorderStyle.FixedSingle;
            target.MaximizeBox = false;
            target.MinimizeBox = false;
            target.Text = "공지추가";
            new NoticeAddView(target);
        }
        //--------------------공지수정화면---------------------------
        private void GetNoticeEditLoad(object sender, EventArgs e)
        {
            target.Size = new Size(800, 700);
            target.FormBorderStyle = FormBorderStyle.FixedSingle;
            target.MaximizeBox = false;
            target.MinimizeBox = false;
            target.Text = "공지수정";
            new NoticeEditView(target,No);
        }
        //--------------------질문화면---------------------------
        private void GetQuestionLoad(object sender, EventArgs e)
        {
            target.Size = new Size(900, 490);
            target.FormBorderStyle = FormBorderStyle.None;
            target.MaximizeBox = false;
            target.MinimizeBox = false;
            target.Text = "질문목록";
            new QuestionView(target);
        }
        //--------------------답변화면---------------------------
        private void GetAnswerLoad(object sender, EventArgs e)
        {
            target.Size = new Size(800, 700);
            target.FormBorderStyle = FormBorderStyle.FixedSingle;
            target.MaximizeBox = false;
            target.MinimizeBox = false;
            target.Text = "답변하기";
            new AnswerView(target,No);
        }
    }
}
