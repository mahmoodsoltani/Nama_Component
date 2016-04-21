using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace CS_Component
{
    [DefaultEvent("Click")]
    [DefaultProperty("Icon")]
    public partial class AnimBtn : UserControl
    {
        #region varible
        Bitmap[] bmp;
        int flag;
        bool enter;
        Graphics g, g2;
        int imwidth, imheight;
        double curwidth, curheight;
        double addx, addy;
        Bitmap dblbuffer;
        bool blur = true;
#endregion

        #region  Property
        [Category("Alis Config"), Browsable(true), Description("The bitmap resource name")]
        public Bitmap Icon
        {
            get { return bmp[0]; }
            set
            {
                for (int i = 0; i < 4; i++)
                    bmp[i] = new Bitmap(Width, Height);
                dblbuffer = new Bitmap(Width, Height);

                bmp[0] = value;
                bmp[1] = returnAlpha(bmp[0], 60);
                bmp[2] = returnAlpha(bmp[0], 120);
                bmp[3] = returnAlpha(bmp[0], 180);
                draw(0);
            }
        }
        [Category("Alis Config"), Browsable(true), Description("")]
        public new Size Size
        {
            get { return new Size(Width, Height); }
            set
            {
                Width = ((Size)value).Width;
                Height = ((Size)value).Height;
                if (Width > 160)
                {
                    //MessageBox.Show("Width cannot exceed 160 :p");
                    Width = 160;
                }
                if (Height > 128)
                {
                    //MessageBox.Show("Height cannot exceed 128 :p");
                    Height = 128;
                }
                calc();
            }
        }
        [Category("Alis Config"), Browsable(true), Description("")]
        public Size IconSize
        {
            get { return new Size(imwidth, imheight); }
            set
            {
                imwidth = ((Size)value).Width;
                imheight = ((Size)value).Height;
                if (imwidth > Width) imwidth = Width;
                if (imheight > Height) imheight = Height;
                calc();
            }
        }
        [Category("Alis Config"), Browsable(true), Description("")]
        public bool Blur
        {
            get { return blur; }
            set
            {
                blur = value;
                if (!blur)
                {
                    bmp[1].Dispose();
                    bmp[2].Dispose();
                    bmp[3].Dispose();
                }
                else
                {
                    bmp[1] = returnAlpha(bmp[0], 60);
                    bmp[2] = returnAlpha(bmp[0], 120);
                    bmp[3] = returnAlpha(bmp[0], 180);
                }
            }
        }
        [Category("Alis Config"), Browsable(true), Description("")]
        public string TooltipText
        {
            get { return toolTip1.GetToolTip(this); }
            set
            {
                toolTip1.SetToolTip(this, value);
            }
        }
#endregion
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
                OnClick(new EventArgs());
        }
        protected override void OnGotFocus(EventArgs e)
        {
            AnimBtn_MouseEnter(new object(),e);
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            AnimBtn_MouseLeave(new object(), e);
            base.OnLostFocus(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            base.OnPaint(e);
        }
        public AnimBtn()
        {
            InitializeComponent();
            bmp = new Bitmap[4];
            for (int i = 0; i < 4; i++)
                bmp[i] = new Bitmap(Width, Height);
            dblbuffer = new Bitmap(Width, Height);
            IconSize = new Size(Width / 2, Height / 2);

            g = this.CreateGraphics();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (enter)
            {
                if (curwidth < Width)
                    curwidth += addx;

                if (curheight < Height)
                    curheight += addy;

                if (curwidth >= Width && curheight >= Height) timer1.Stop();

                flag++;
            }
            else
            {
                if (curwidth > imwidth)
                    curwidth -= addx;

                if (curheight > imheight)
                    curheight -= addy;

                if (curwidth <= imwidth && curheight <= imheight)
                    timer1.Stop();

                flag--;
            }

            if (flag > 9) draw(0);
            else if (flag > 6) draw(1);
            else if (flag > 3) draw(2);
            else draw(3);
        }
        private void AnimBtn_MouseEnter(object sender, EventArgs e)
        {
            enter = true;
            timer1.Start();
        }
        private void AnimBtn_MouseLeave(object sender, EventArgs e)
        {
            enter = false;
            timer1.Start();
        }
        private void AnimBtn_Paint(object sender, PaintEventArgs e)
        {
            draw(3);
        }
        private void calc()
        {
            curwidth = imwidth;
            curheight = imheight;

            addx = (double)(Width - imwidth) / 10;
            addy = (double)(Height - imheight) / 10;
        }
        private void draw(int state)
        {
            int st;

            if (blur)
                st = state;
            else
                st = 0;

            g2 = Graphics.FromImage(dblbuffer);
            g2.Clear(this.BackColor);
            g2.DrawImage(bmp[st], (int)((double)Width - curwidth) / 2, (int)((double)Height - curheight) / 2, (int)curwidth, (int)curheight);

            g.DrawImageUnscaled(dblbuffer, 0, 0);
        }
        private int min(int val)
        {
            return (val < 0 ? 0 : val);
        }
        public void setAlpha(Bitmap bmp, int alpha)
        {
            Color col;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    col = bmp.GetPixel(i, j);
                    if (col.A > 0)
                        bmp.SetPixel(i, j, Color.FromArgb(min(col.A - alpha), col.R, col.G, col.B));
                }
        }
        public Bitmap returnAlpha(Bitmap bmp, int alpha)
        {
            Color col;
            Bitmap bmp2 = new Bitmap(bmp);

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    col = bmp.GetPixel(i, j);
                    if (col.A > 0)
                        bmp2.SetPixel(i, j, Color.FromArgb(min(col.A - alpha), col.R, col.G, col.B));
                }
            return bmp2;
        }
    }
}
