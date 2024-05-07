﻿using Repositories.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp4;

namespace PhongKhamDaKhoa.Group8
{
    public partial class AddLeTanForm : Form
    {
        public AddLeTanForm()
        {
            InitializeComponent();
        }

        private LeTanService _service = new LeTanService();

        private void btnSaveLT_Click(object sender, EventArgs e)
        {
            string LTId = _service.GenerateLeTanID();
            string name = txtNameLT.Texts;
            DateOnly birthday = new DateOnly(dtpBirthdayLT.Value.Year, dtpBirthdayLT.Value.Month, dtpBirthdayLT.Value.Day);
            DateOnly dayWorking = new DateOnly(dtpDateWorkingLT.Value.Year, dtpDateWorkingLT.Value.Month, dtpDateWorkingLT.Value.Day);
            string phoneNumber = txtPhoneLT.Texts;
            string gender = chkMaleLT.Checked ? "Nam" : "Nữ";
            
            if (name == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thêm Lễ tân", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!chkMaleLT.Checked && !chkFemaleLT.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Thêm Lễ tân", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Letan letan;
            if (phoneNumber == "")
            {
                letan = new()
                {
                    MaLt = LTId,
                    Hoten = name,
                    Ngaysinh = birthday,
                    Ngaylamviec = dayWorking,
                    Gioitinh = gender
                };
            }
            else
            {
                letan = new()
                {
                    MaLt = LTId,
                    Hoten = name,
                    Ngaysinh = birthday,
                    Ngaylamviec = dayWorking,
                    Sdt = phoneNumber,
                    Gioitinh = gender
                };
            }

            _service.AddLeTan( letan );

            this.Close();
        }

        private void chkMaleLT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaleLT.Checked)
            {
                chkFemaleLT.Checked = false;
            }
        }

        private void chkFemaleLT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFemaleLT.Checked) {
                chkMaleLT.Checked = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button_MouseEnter(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.FromArgb(171, 39, 28);
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.Transparent;
        }
    }
}
