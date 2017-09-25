using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        bool isTypingNumber = false;

        enum PhepToan { Cong, Tru, Nhan, Chia };
        PhepToan pheptoan;

        double nho;
        private void NhapSo (object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            NhapSo(btn.Text);
        }
        private void NhapSo(string so)
        {
            if (isTypingNumber)
                lblDisplay.Text = lblDisplay.Text + so;
            else
            {
                lblDisplay.Text = so;
                isTypingNumber = true;
            }
        }

        private void NhapPhepToan(object sender, EventArgs e)
        {
            TinhKetQua();
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "+" : pheptoan = PhepToan.Cong; break;
                case"-": pheptoan = PhepToan.Tru; break;
                case"*" : pheptoan =PhepToan.Nhan; break;
                case"/": pheptoan = PhepToan.Chia; break;

            }

            nho = double.Parse(lblDisplay.Text);

            isTypingNumber = false;
        }

        private void TinhKetQua()
        {
            // tinh toan dua tren: nho, pheptoan, lblDisplay.Text
            double tam = double.Parse(lblDisplay.Text);
            double ketqua = 0.0;
            switch (pheptoan)
            {
                case PhepToan.Cong: ketqua = nho + tam; break;
                case PhepToan.Tru: ketqua = nho - tam; break;
                case PhepToan.Nhan: ketqua = nho * tam; break;
                case PhepToan.Chia: ketqua = nho / tam; break;
            }

            // gan ket qua tinh duoc len lblDisplay
            lblDisplay.Text = ketqua.ToString();
        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            TinhKetQua();
            isTypingNumber = false;
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case '0':
                case'1':
                case'2':
                case'3':
                case'4':
                case'5':
                case'6':
                case'7':
                case'8':
                case'9':
                    if (!lblDisplay.Text.Equals("0"))
                        NhapSo("" + e.KeyChar);
                    break;
                case '+':
                    btnCong.PerformClick();
                    break;
                case '-':
                    btnTru.PerformClick();
                    break;
                case '*':
                    btnNhan.PerformClick();
                    break;
                case '/':
                    btnChia.PerformClick();
                    break;
                case '=':
                    btnBang.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (Math.Sqrt(Double.Parse(lblDisplay.Text))).ToString();
        }

        private void btnDoiDau_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (-1 * (double.Parse(lblDisplay.Text))).ToString();
        }

        private void btnPhanTram_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = ((double.Parse(lblDisplay.Text) / 100)).ToString();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 0)
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1, 1);
        }
        private void btnNho_Click(object sender, EventArgs e)
        {
            nho = 0;
            lblDisplay.ResetText();
        }
    }

}
