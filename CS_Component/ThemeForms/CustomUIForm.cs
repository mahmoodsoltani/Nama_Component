using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS_Component
{
    public partial class CustomUIForm : CustomUIBaseForm
    {
        public CustomUIForm()
        {
            InitializeComponent();
        }

        private void CloseButton11981_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Maximize9213_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_Minimize2321_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Restore31231_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (btn_Maximize9213 != null)
            {
                CloseButton11981.Left = this.Width - 35;
                btn_Maximize9213.Left = btn_Restore31231.Left = this.Width - 66;
                btn_Minimize2321.Left = this.Width - 97;

                btn_Maximize9213.Visible = WindowState == FormWindowState.Normal;
                btn_Restore31231.Visible = !btn_Maximize9213.Visible;
            }
        }

        private void CustomUIForm_Load(object sender, EventArgs e)
        {
            btn_Maximize9213.Enabled = this.MaximizeBox;
            btn_Minimize2321.Enabled = this.MinimizeBox;
        }
    }
}