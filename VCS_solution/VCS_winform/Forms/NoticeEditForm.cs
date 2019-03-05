﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCS_winform.Modules;

namespace VCS_winform.Forms
{
    public partial class NoticeEditForm : Form
    {
        public NoticeEditForm()
        {
            InitializeComponent();
            Load load = new Load(this);
            Load += load.GetHandler("noticeedit");
        }

        public NoticeEditForm(int nNo)
        {
            InitializeComponent();
            Load load = new Load(this,nNo);
            Load += load.GetHandler("noticeedit");
        }
    }
}
