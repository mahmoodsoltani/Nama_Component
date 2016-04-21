using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace CS_Component
{
    [DefaultEvent("Click")] //Already built-in
    public partial class BtnPanelSmall : UserControl
    {
        public BtnPanelSmall()
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
            Disabled
        }

        public enum VerticalAlign
        {
            Top,
            Middle,
            Bottom
        }

        //private State state = State.Normal;
        //private int offset = 0;

        private string headerText = "Header Text";

        private Bitmap image;
        private Bitmap grayImage;
        private Size imageSize = new Size(20, 20);
        private VerticalAlign imageAlign = VerticalAlign.Top;

        private Font descriptFont;
        private DialogResult diagResult = DialogResult.None;

        #endregion

        #region Nama_Component2.Properties----------------------------
        [Category("Command Appearance"),
         Browsable(true),
         DefaultValue("Header Text")]
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
         DefaultValue(typeof(Size), "20,20")]
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
            using (GraphicsPath path = new GraphicsPath())
            {
                int num = base.Width - 0;
                int num0 = base.Height - 0;
                Rectangle rectangle2 = new Rectangle(0, 0, 10, 10);
                Rectangle rectangle3 = new Rectangle(num - 10, 0, 10, 10);
                Rectangle rectangle4 = new Rectangle(0, num0 - 10, 10, 10);
                Rectangle rectangle5 = new Rectangle(num - 10, num0 - 10, 10, 10);
                path.AddArc(rectangle2, 180f, 90f);
                path.AddArc(rectangle3, 270f, 90f);
                path.AddArc(rectangle5, 360f, 90f);
                path.AddArc(rectangle4, 90f, 90f);
                path.CloseAllFigures();
                this.Region = new Region(path);
                path.Dispose();
            }

            SizeF headerLayout = e.Graphics.MeasureString(headerText, this.Font);

            if (Focused)
            {
                SolidBrush textBrush = new SolidBrush(Color.Black);
                e.Graphics.DrawString(headerText, this.Font, textBrush, (Width / 2) - (headerLayout.Width / 2), (Height / 2) - (headerLayout.Height / 2));
                e.Graphics.DrawString("<<", this.Font, textBrush, 4, (Height / 2) - (headerLayout.Height / 2));
            }
            else if (mousUp)
            {
                SolidBrush textBrush = new SolidBrush(Color.White);
                e.Graphics.DrawString(headerText, this.Font, textBrush, (Width / 2) - (headerLayout.Width / 2), (Height / 2) - (headerLayout.Height / 2));
                e.Graphics.DrawString("<<", this.Font, textBrush, 4, (Height / 2) - (headerLayout.Height / 2));
            }
            else
            {
                SolidBrush textBrush = new SolidBrush(Color.Black);
                e.Graphics.DrawString(headerText, this.Font, textBrush, (Width / 2) - (headerLayout.Width / 2), (Height / 2) - (headerLayout.Height / 2));
                e.Graphics.DrawString("<<", this.Font, textBrush, 4, (Height / 2) - (headerLayout.Height / 2));
            }

            if (image != null)
            {
                if (this.Enabled)
                    e.Graphics.DrawImage(image, new Rectangle(Width - imageSize.Width, (Height / 2) - (imageSize.Height / 2), imageSize.Width, imageSize.Height));
                else
                {
                    if (grayImage == null)
                        grayImage = GetGrayscale(image); //generate grayscale now

                    e.Graphics.DrawImage(grayImage, new Rectangle(Width - imageSize.Width, (Height / 2) - (imageSize.Height / 2), imageSize.Width, imageSize.Height));
                }
            }

            base.OnPaint(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.BackgroundImage = CS_Component.Properties.Resources.Focu_small1;
            this.Refresh();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.BackgroundImage = null;
            mousUp = false;
            this.Refresh();
            base.OnLostFocus(e);
        }
        Boolean mousUp = false;
        protected override void OnMouseEnter(EventArgs e)
        {
            if (!this.Focused)
            {
                this.BackgroundImage = CS_Component.Properties.Resources.overSmall1;
                mousUp = true;
            }

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (!this.Focused)
            {
                this.BackgroundImage = null;
                mousUp = false;
            }
            base.OnMouseLeave(e);
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

        private void BtnPanelSmall_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnClick(new EventArgs());
            }
        }

    }
}
