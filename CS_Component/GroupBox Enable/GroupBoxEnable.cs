using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CS_Component
{
    [Designer(typeof(CS_Component.TestControlDesigner))]
    public partial class GroupBoxEnable : UserControl
    {
        public string Caption
        {
            get
            {
                return this.chk_Enable.Text;
            }

            set
            {
                this.chk_Enable.Text = value;
            }
        }

        public bool Check
        {
            get
            {
                return this.chk_Enable.Checked;
            }

            set
            {
                this.chk_Enable.Checked = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GroupBox WorkingArea
        {
            get
            {
                return this.groupBox1;
            }
        }
        public GroupBoxEnable()
        {
            InitializeComponent();
        }

        private void chk_Enable_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = chk_Enable.Checked;
        }

        private void GroupBoxEnable_Load(object sender, EventArgs e)
        {
            this.chk_Enable.Location = new System.Drawing.Point(this.Width - 50, 0);
        }
    }
}
