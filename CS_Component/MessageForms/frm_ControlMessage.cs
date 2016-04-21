using System;
using System.Windows.Forms;

namespace CS_Component
{
    public partial class frm_ControlMessage : Form
    {
        public frm_ControlMessage()
        {
            InitializeComponent();
        }

        private void label1_Resize(object sender, EventArgs e)
        {
            this.Width = lbl_Message.Width + 21;
        }
    }

    public class ControlMessage
    {
        private static void Control_Enter(object sender, EventArgs e)
        {
            if (((Control)sender).Parent.GetType().ToString() == "DevComponents.DotNetBar.Controls.GroupPanel")
            {
                Control pp=((Control)sender);
                while (pp.Parent != null)
                {
                    foreach (Control C in ((Control)sender).Parent.Controls)
                        if (C is frm_ControlMessage)
                            if (C.Tag.ToString() == ((Control)sender).Name)
                            {
                                ((frm_ControlMessage)C).Close();
                                break;
                            }
                    pp = pp.Parent;
                }
            }
            else
            {
                foreach (Control C in ((Control)sender).FindForm().Controls)
                    if (C is frm_ControlMessage)
                        if (C.Tag.ToString() == ((Control)sender).Name)
                        {
                            ((frm_ControlMessage)C).Close();
                            break;
                        }
            }
        }

        public static void Show(Control Control, string Message)
        {
            Control.Enter += new EventHandler(Control_Enter);
            if (Control.GetType() == Type.GetType("CS_Component.TextBox"))
                Control.TextChanged += new EventHandler(Control_Enter);

            frm_ControlMessage frm = new frm_ControlMessage();
            frm.Tag = Control.Name;
            int int_Left = Control.Left;
            //'Dim int_Top As Integer = Control.Top + Control.Height * 2 
            int int_Top = Control.Top + Control.Height;

            //new added by ali ...the group panel component rise a error  in show yellow box
            frm.lbl_Message.Text = Message;
            frm.TopLevel = false;

            if (Control.Parent.GetType().ToString() == "DevComponents.DotNetBar.Controls.GroupPanel")
            {
                Control p = Control.Parent;
                frm.Top = int_Top;
                frm.Left = int_Left;
                p.Controls.Add(frm);
            }
            else
            {
                Control p = Control.Parent;
                while (p.Parent != null)
                {
                    int_Left += p.Left;
                    int_Top += p.Top;
                    p = p.Parent;
                    if (p == null) break;
                }
                frm.Top = int_Top;
                frm.Left = int_Left;
                Control.FindForm().Controls.Add(frm);
            }

            frm.BringToFront();
            if (frm.Right > Control.FindForm().Width)
                frm.Left = Control.FindForm().Width - frm.Width - 20;
            //'frm.Owner = Control.FindForm()
            if (Control.Parent is TabPage)
                ((TabControl)Control.Parent.Parent).SelectedTab = (TabPage)Control.Parent;
            frm.Show();
        }
    }
}