﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhongKhamDaKhoa.Group8
{
    public partial class TinhTrangBenhForm : Form
    {
        public TinhTrangBenhForm()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        public string text { get; set; }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void TinhTrangBenhForm_Load(object sender, EventArgs e)
        {
            if (text != null)
            {
                rtxtTinhtrang.Text = text;
            }
        }
    }
}
