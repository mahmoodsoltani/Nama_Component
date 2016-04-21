using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace CS_Component
{
    public partial class CustomUIBaseForm : Form
    {
        private bool bol_IsDragged = false;
        private bool bol_IsResize = false;
        private Point pnt_Start;
        PaintEventArgs PaintE;

        private Color _Color = Color.LightPink;

        private FormBorderStyle _Style = FormBorderStyle.Sizable;

        private Padding _Padding;

        public new Padding Padding
        {
            get { return _Padding; }
            set { _Padding = value; }
        }

        public new FormBorderStyle FormBorderStyle
        {
            get { return _Style; }
            set { _Style = value; }
        }

        public Color BorderColor
        {
            get { return _Color; }
            set { _Color = value;
            Refresh();
            }
        }

        public CustomUIBaseForm()
        {
            base.Padding = new Padding(6, 33, 7, 7);
            base.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void PaintFrom()
        {
            PaintEventArgs e = PaintE;
            GraphicsPath Gp = new GraphicsPath();

            if (this.WindowState != FormWindowState.Maximized)
            {
                Gp.AddArc(0, 0, 16, 16, 180, 90);
                Gp.AddArc(this.Width - 17, 0, 16, 16, 270, 90);
                Gp.AddRectangle(new Rectangle(0, 8, this.Width, this.Height - 13));
                Gp.AddArc(0, this.Height - 10, 10, 10, 90, 90);
                Gp.AddArc(this.Width - 11, this.Height - 10, 10, 10, 0, 90);
                Gp.CloseAllFigures();
            }
            else
            {
                Gp.AddRectangle(this.ClientRectangle);
            }
            this.Region = new Region(Gp);
            Gp.Dispose();

            GraphicsPath Titlebar = new GraphicsPath();

            if (this.WindowState != FormWindowState.Maximized)
            {
                Titlebar.AddArc(0, 0, 10, 10, 180, 90);
                Titlebar.AddArc(this.Width - 11, 0, 10, 10, 270, 90);
                Titlebar.AddRectangle(new Rectangle(0, 5, this.Width, 11));
                Titlebar.CloseAllFigures();
            }
            else
            {
                Titlebar.AddRectangle(new Rectangle(0, 0, this.Width, 21));
            }
            Brush B = new LinearGradientBrush(new RectangleF(0, 0, this.Width, 15), Color.White, _Color, LinearGradientMode.Vertical);
            e.Graphics.FillPath(B, Titlebar);
            Brush B2 = new LinearGradientBrush(new RectangleF(0, 0, this.Width, 16), _Color, Color.WhiteSmoke, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(B2, 0, 16, this.Width, 16);

            Brush B3 = new LinearGradientBrush(new RectangleF(0, 0, this.Width, 7), _Color, Color.WhiteSmoke, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(B3, 0, this.Height - 6, this.Width, 6);

            Brush B4 = new LinearGradientBrush(new RectangleF(0, 0, 6, this.Height), Color.WhiteSmoke, _Color, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(B4, 0, 31, 6, this.Height - 37);
            e.Graphics.FillRectangle(B4, this.Width - 6, 31, 6, this.Height - 37);



            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            if (this.WindowState != FormWindowState.Maximized)
            {
                e.Graphics.DrawArc(Pens.Gray, 1, 1, 13, 14, 180, 90);
                Pen Peen = new Pen(Brushes.Gray, 3);
                e.Graphics.DrawArc(Peen, this.Width - 17, 0, 17, 15, 270, 90);
                e.Graphics.DrawArc(Pens.Gray, 0, this.Height - 12, 12, 12, 90, 90);
                e.Graphics.DrawArc(Pens.Gray, this.Width - 12, this.Height - 12, 12, 12, 0, 90);
                e.Graphics.DrawLine(Pens.Gray, 5, this.Height, this.Width - 5, this.Height);
                e.Graphics.DrawLine(Pens.Gray, this.Width, 5, this.Width, this.Height - 5);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawLine(new Pen(Brushes.Gray, 2), 5, 0, this.Width - 5, 0);
                e.Graphics.SmoothingMode = SmoothingMode.Default;
                e.Graphics.DrawLine(Pens.Gray, 1, 5, 1, this.Height - 5);
            }
            e.Graphics.SmoothingMode = SmoothingMode.Default;
            e.Graphics.DrawRectangle(Pens.DarkGray, 6, 33, this.Width - 12, this.Height - 39);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            RectangleF Caption = Titlebar.GetBounds();
            Caption.X = 10;
            Caption.Y = 9;
            Caption.Width = this.Width - 110;
            StringFormat F = new StringFormat();
            F.Alignment = StringAlignment.Near;
            if (this.RightToLeft == RightToLeft.Yes)
                F.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            e.Graphics.DrawString(Text, new Font("Tahoma", 9), Brushes.Black, Caption, F);

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            PaintE = e;
            PaintFrom();
            //G.DrawArc(HighBorder, 0, 0, 6, 6, 180, 90);
            //G.DrawArc(HighBorder, this.Width - 7, 0, 6, 6, 270, 90);

            //G.DrawArc(HighBorder, 0, this.Height - 7, 6, 6, 90, 90);
            //G.DrawArc(HighBorder, this.Width - 7, this.Height - 7, 6, 6, 0, 90);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //if (this.WindowState == FormWindowState.Maximized)
                this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Y <= 33 && e.Button== MouseButtons.Left)
            {
                bol_IsDragged = true;
                pnt_Start = e.Location;                
            }
            else if (e.Y >= this.Height - 10 && e.X >= this.Width - 10)
            {
                bol_IsResize = true;
                pnt_Start = e.Location;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Y >= this.Height - 10 && e.X >= this.Width - 10)
            {
                Cursor = Cursors.SizeNWSE;
                return;
            }

            if (bol_IsDragged && e.Button == MouseButtons.Left)
            {
                this.Top += e.Y - pnt_Start.Y;
                this.Left += e.X - pnt_Start.X;
                return;
            }
            else if (bol_IsResize && e.Button == MouseButtons.Left)
            {
                this.Height =  e.Y;
                this.Width =  e.X;
                return;
            }
            Cursor = Cursors.Default;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {          
            bol_IsDragged = false;
            bol_IsResize = false;
            base.OnMouseUp(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (!this.MaximizeBox) return;
            if (e.Y <= 33 && e.Button== MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Maximized)
                    WindowState = FormWindowState.Normal;
                else
                    WindowState = FormWindowState.Maximized;
            }
        }
    }
}