using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    public class ImageButton : PictureBox
    {
        private Image img_Image;

        private Image img_ImageOver;

        private Image img_ImageClick;

        private bool bol_Checkable;

        public bool Checkable
        {
            get { return bol_Checkable; }
            set { bol_Checkable = value; }
        }

        private bool bol_Checked;

        public bool Checked
        {
            get { return bol_Checked; }
            set
            {
                bol_Checked = value;
                if (bol_Checked)
                {
                    Image = img_ImageClick;
                }
            }
        }

        public Image ImageOver
        {
            get { return img_ImageOver; }
            set { img_ImageOver = value; }
        }

        public Image ImageClick
        {
            get { return img_ImageClick; }
            set { img_ImageClick = value; }
        }

        public ImageButton()
        {
            this.MouseEnter += new EventHandler(ImageButton_MouseEnter);
            this.MouseLeave += new EventHandler(ImageButton_MouseLeave);
            this.MouseClick += new MouseEventHandler(ImageButton_MouseClick);
            this.MouseUp += new MouseEventHandler(ImageButton_MouseUp);
            this.MouseDown += new MouseEventHandler(ImageButton_MouseDown);
        }

        void ImageButton_MouseDown(object sender, MouseEventArgs e)
        {
            Image = img_ImageClick;
        }

        void ImageButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Checkable)
            {
                Image = img_Image;
            }
            else
            { 
            
            }
        }

        void ImageButton_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        void ImageButton_MouseLeave(object sender, EventArgs e)
        {
            Image = img_Image;
        }

        void ImageButton_MouseEnter(object sender, EventArgs e)
        {
            img_Image = Image;
            Image = img_ImageOver;
        }
    }
}
