using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CS_Component
{
    [DefaultEvent("Click")] //Already built-in
    public partial class Btn : UserControl
    {
        public Btn()
        {
            InitializeComponent();
            this.DoubleBuffered = true; //Smooth redrawing
        }

        #region Fields---------------------------------
        public enum State
        {
            Normal,
            Hover,
            Pushed,
            Disabled,
            Focused
        }

        public enum VerticalAlign
        {
            Top,
            Middle,
            Bottom
        }

        private State state = State.Normal;
        private int offset = 0;

        private string headerText = "Button1";

        private Bitmap image;
        private Bitmap grayImage;
        private Size imageSize = new Size(32, 32);
        private VerticalAlign imageAlign = VerticalAlign.Top;

        private Font descriptFont;
        private DialogResult diagResult = DialogResult.None;

        #endregion

        #region Nama_Component2.Properties----------------------------
        [Category("Command Appearance"),
         Browsable(true),
         DefaultValue("Button1")]
        public string HeaderText
        {
            get
            {
                return headerText;
            }
            set
            {
                headerText = value;
                this.Refresh();
            }
        }

        [Category("Command Appearance"),
         Browsable(true),
         DefaultValue(null)]
        public Bitmap Image
        {
            get
            {
                return image;
            }
            set
            {
                //Clean up
                if (image != null)
                    image.Dispose();

                if (grayImage != null)
                    grayImage.Dispose();

                image = value;
                if (image != null)
                    grayImage = GetGrayscale(image); //generate image for disabled state
                else
                    grayImage = null;
                this.Refresh();
            }
        }

        [Category("Command Appearance"),
         Browsable(true),
         DefaultValue(typeof(Size), "32,32")]
        public Size ImageScalingSize
        {
            get
            {
                return imageSize;
            }
            set
            {
                imageSize = value;
                this.Refresh();
            }
        }

        [Category("Command Appearance"),
         Browsable(true),
         DefaultValue(VerticalAlign.Top)]
        public VerticalAlign ImageVerticalAlign
        {
            get
            {
                return imageAlign;
            }
            set
            {
                imageAlign = value;
                this.Refresh();
            }
        }

        [Category("Command Appearance")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;

                //Clean up
                if (descriptFont != null)
                    descriptFont.Dispose();

                //Update the description font, which is the same just 3 sizes smaller
                descriptFont = new Font(this.Font.FontFamily, this.Font.Size - 3);
            }
        }

        [Category("Behavior"),
         DefaultValue(DialogResult.None)]
        public DialogResult DialogResult
        {
            get
            {
                return diagResult;
            }
            set
            {
                diagResult = value;
            }
        }

        #endregion

        #region Events-----------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); //draws the regular background stuff

            //if (this.Focused && state == State.Normal)
            //    DrawHighlight(e.Graphics);

            switch (state)
            {
                case State.Normal:
                    DrawNormalState(e.Graphics);
                    //DrawHoverState(e.Graphics);
                    break;
                case State.Hover:
                    DrawHoverState(e.Graphics);
                    break;
                case State.Pushed:
                    DrawPushedState(e.Graphics);
                    break;
                case State.Disabled:
                    DrawNormalState(e.Graphics); //DrawForeground takes care of drawing the disabled state
                    break;
                default:
                    break;
            }
        }

        //protected override void OnClick(EventArgs e)
        //{
        //    base.OnClick(e);
        //    if (diagResult != DialogResult.None)
        //    {
        //        this.ParentForm.DialogResult = diagResult;
        //        this.ParentForm.Close();
        //    }
        //}

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                this.OnClick(e);
        }

        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    base.OnKeyPress(e);

        //    if (e.KeyChar == Convert.ToChar(Keys.Enter))
        //        this.PerformClick();
        //}

        protected override void OnGotFocus(EventArgs e)
        {
            this.Refresh();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.Refresh();
            base.OnLostFocus(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (this.Enabled)
                state = State.Hover;
            this.Refresh();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.Enabled)
                state = State.Normal;
            this.Refresh();

            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.Enabled)
                state = State.Pushed;
            this.Refresh();

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            try
            {
                if (this.Enabled)
                {
                    if (this.RectangleToScreen(this.ClientRectangle).Contains(Cursor.Position))
                        state = State.Hover;
                    else
                        state = State.Normal;
                }
                this.Refresh();
            }
            catch 
            {
            }

            base.OnMouseUp(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (this.Enabled)
                state = State.Normal;
            else
                state = State.Disabled;

            this.Refresh();

            base.OnEnabledChanged(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (image != null)
                    image.Dispose();
                if (grayImage != null)
                    grayImage.Dispose();
                if (descriptFont != null)
                    descriptFont.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Drawing Methods-------------------------

        //Draws the light-blue rectangle around the button when it is focused (by Tab for example)
        private void DrawHighlight(Graphics g)
        {
            //The outline is drawn inside the button
            GraphicsPath innerRegion = RoundedRect(this.Width - 3, this.Height - 3, 3);

            //----Shift the inner region inwards
            Matrix translate = new Matrix();
            translate.Translate(1, 1);
            innerRegion.Transform(translate);
            translate.Dispose();
            //-----

            //Pen inlinePen = new Pen(Color.FromArgb(192, 233, 243)); //Light-blue
            Pen inlinePen = new Pen(Color.FromArgb(192, 233, 243));  //Light-blue

            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawPath(inlinePen, innerRegion);

            //Clean-up
            inlinePen.Dispose();
            innerRegion.Dispose();
        }

        //Draws the button when the mouse is over it
        private void DrawHoverState(Graphics g)
        {
            GraphicsPath outerRegion = RoundedRect(this.Width - 1, this.Height - 1, 3);
            GraphicsPath innerRegion = RoundedRect(this.Width - 3, this.Height - 3, 2);
            //----Shift the inner region inwards
            Matrix translate = new Matrix();
            translate.Translate(1, 1);
            innerRegion.Transform(translate);
            translate.Dispose();
            //-----
            Rectangle backgroundRect = new Rectangle(1, 1, this.Width - 2, (int)(this.Height * 0.75f) - 2);

            Pen outlinePen = new Pen(Color.FromArgb(189, 189, 189)); //SystemColors.ControlDark
            Pen inlinePen = new Pen(Color.FromArgb(245, 255, 255, 255)); //Slightly transparent white

            //Gradient brush for the background, goes from white to transparent 75% of the way down
            LinearGradientBrush backBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, backgroundRect.Height), Color.WhiteSmoke, Color.Transparent);
            backBrush.WrapMode = WrapMode.TileFlipX; //keeps the gradient smooth in case of the glitch where there's an extra gradient line

            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.FillRectangle(backBrush, backgroundRect);
            g.DrawPath(inlinePen, innerRegion);
            g.DrawPath(outlinePen, outerRegion);

            //Text/Image
            offset = 0; //Text/Image doesn't move
            DrawForeground(g, State.Hover);

            //Clean up
            outlinePen.Dispose();
            inlinePen.Dispose();
            outerRegion.Dispose();
            innerRegion.Dispose();
        }

        //Draws the button when it's clicked down
        private void DrawPushedState(Graphics g)
        {
            GraphicsPath outerRegion = RoundedRect(this.Width - 1, this.Height - 1, 3);
            GraphicsPath innerRegion = RoundedRect(this.Width - 3, this.Height - 3, 2);
            //----Shift the inner region inwards
            Matrix translate = new Matrix();
            translate.Translate(1, 1);
            innerRegion.Transform(translate);
            translate.Dispose();
            //-----
            Rectangle backgroundRect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);

            Pen outlinePen = new Pen(Color.FromArgb(167, 167, 167)); //Outline is darker than normal
            Pen inlinePen = new Pen(Color.FromArgb(227, 227, 227)); //Darker white
            SolidBrush backBrush = new SolidBrush(Color.FromArgb(234, 234, 234)); //SystemColors.ControlLight

            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.FillRectangle(backBrush, backgroundRect);
            g.DrawPath(inlinePen, innerRegion);
            g.DrawPath(outlinePen, outerRegion);

            //Text/Image
            offset = 1; //moves image inwards 1 pixel (x and y) to create the illusion that the button was pushed
            DrawForeground(g, State.Pushed);

            //Clean up
            outlinePen.Dispose();
            inlinePen.Dispose();
            outerRegion.Dispose();
            innerRegion.Dispose();
        }

        //Draws the button in it's regular state
        private void DrawNormalState(Graphics g)
        {
            //Nothing needs to be drawn but the text and image

            //Text/Image
            offset = 0; //Text/Image doesn't move
            DrawForeground(g, State.Normal);
        }

        //Draws Text and Image
        private void DrawForeground(Graphics g, State btnStat)
        {
            //Make sure drawing is of good quality
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            //Image Coordinates-------------------------------
            int imageLeft = 9;
            int imageTop = 0;

            //Text Layout--------------------------------
            //Gets the width/height of the text once it's drawn out
            SizeF headerLayout = g.MeasureString(headerText, this.Font);

            //Merge the two sizes into one big rectangle
            Rectangle totalRect = new Rectangle(0, 0, (int)Math.Max(headerLayout.Width, 0), (int)(headerLayout.Height + 0) - 4);

            //Align the total rectangle-------------------------
            if (image != null)
                totalRect.X = imageLeft + imageSize.Width + 5; //consider the image is there
            else
                totalRect.X = 20;

            totalRect.Y = (this.Height / 2) - (totalRect.Height / 2); //center vertically  
            //---------------------------------------------------

            //Align the top of the image---------------------
            if (image != null)
            {
                switch (imageAlign)
                {
                    case VerticalAlign.Top:
                        imageTop = totalRect.Y;
                        break;
                    case VerticalAlign.Middle:
                        imageTop = totalRect.Y + (totalRect.Height / 2) - (imageSize.Height / 2);
                        break;
                    case VerticalAlign.Bottom:
                        imageTop = totalRect.Y + totalRect.Height - imageSize.Height;
                        break;
                    default:
                        break;
                }
            }

            //Brushes--------------------------------
            // Determine text color depending on whether the control is enabled or not
            Color textColor = this.ForeColor;
            if (!this.Enabled)
                textColor = SystemColors.GrayText;

            SolidBrush textBrush = new SolidBrush(textColor);

            if (Focused && btnStat == State.Normal)
                g.DrawImage(CS_Component.Properties.Resources.Foc1, new Rectangle(0, 0, Width, Height));
            else if (btnStat == State.Pushed)
                g.DrawImage(CS_Component.Properties.Resources.press, new Rectangle(0, 0, Width, Height));
            else if ((Focused && btnStat == State.Hover) || btnStat == State.Hover)
                g.DrawImage(CS_Component.Properties.Resources.over1, new Rectangle(0, 0, Width, Height));
            else if (btnStat == State.Normal)
                g.DrawImage(CS_Component.Properties.Resources.nor1, new Rectangle(0, 0, Width, Height));
           

            if (image == null)
                g.DrawString(headerText, this.Font, textBrush, (Width / 2) - (headerLayout.Width / 2), totalRect.Top + offset - 3);
            else
                g.DrawString(headerText, this.Font, textBrush, Width - headerLayout.Width - imageSize.Width - 10, totalRect.Top + offset - 3);

            if (image != null)
            {
                if (this.Enabled)
                {
                    switch (btnStat)
                    {
                        case State.Pushed:
                            g.DrawImage(image, new Rectangle(Width - imageSize.Width - 5, (Height / 2) - (imageSize.Height / 2) + 1, imageSize.Width, imageSize.Height));
                            break;
                        default:
                            g.DrawImage(image, new Rectangle(Width - imageSize.Width - 5, (Height / 2) - (imageSize.Height / 2), imageSize.Width, imageSize.Height));
                            break;
                    }
                }
                else
                {
                    if (grayImage == null)
                        grayImage = GetGrayscale(image); //generate grayscale now

                    g.DrawImage(grayImage, new Rectangle(Width - imageSize.Width, (Height / 2) - (imageSize.Height / 2), imageSize.Width, imageSize.Height));
                }
            }

            //Clean-up
            textBrush.Dispose();
        }
        #endregion

        #region Helper Methods--------------------------
        private static GraphicsPath RoundedRect(int width, int height, int radius)
        {
            RectangleF baseRect = new RectangleF(0, 0, width, height);
            float diameter = radius * 2.0f;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(baseRect.Location, sizeF);
            GraphicsPath path = new GraphicsPath();

            // top left arc 
            path.AddArc(arc, 180, 90);

            // top right arc 
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc 
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private static Bitmap GetGrayscale(Image original)
        {
            //Set up the drawing surface
            Bitmap grayscale = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(grayscale);

            //Grayscale Color Matrix
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                                                      {
                                                         new float[] {0.3f, 0.3f, 0.3f, 0, 0},
                                                         new float[] {0.59f, 0.59f, 0.59f, 0, 0},
                                                         new float[] {0.11f, 0.11f, 0.11f, 0, 0},
                                                         new float[] {0, 0, 0, 1, 0},
                                                         new float[] {0, 0, 0, 0, 1}
                                                      });

            //Create attributes
            ImageAttributes att = new ImageAttributes();
            att.SetColorMatrix(colorMatrix);

            //Draw the image with the new attributes
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, att);

            //Clean up
            g.Dispose();

            return grayscale;
        }

        public void PerformClick()
        {
            this.OnClick(null);
        }
        #endregion
    }
}
