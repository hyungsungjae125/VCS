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
    public partial class ApplyEditForm : Form
    {
        public ApplyEditForm()
        {
            InitializeComponent();
            Load load = new Load(this);
            Load += load.GetHandler("applyedit");
        }
        public ApplyEditForm(int vNo)
        {
            InitializeComponent();
            Load load = new Load(this,vNo);
            Load += load.GetHandler("applyedit");
        }
    }
}
