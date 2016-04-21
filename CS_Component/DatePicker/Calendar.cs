using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace System.Windows.Forms
{
    public class Calendar : Panel 
    {
        int int_Columns = 7;
        int int_Rows = 7;
        bool bol_DrawHeader = true;

        public Calendar()
        {
        }

        public bool DrawHeader
        {
            get { return bol_DrawHeader; }
            set { bol_DrawHeader = value; Refresh(); }
        }
        
        public int Columns
        {
            get { return int_Columns; }
            set { int_Columns = value; Refresh(); }
        }

        public int Rows
        {
            get { return int_Rows; }
            set { int_Rows = value; Refresh(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawTable(e.Graphics);
        }

        private void DrawTable(Graphics G)
        {

            Brush B = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.LightSteelBlue, Color.Lavender, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
            G.FillRectangle(B,this.ClientRectangle);
            if(bol_DrawHeader)
                G.FillRectangle(Brushes.LemonChiffon, 1, 1, this.Width - 2, this.Height / int_Rows - 1);

            //G.FillRectangle(Brushes.MistyRose, 1, this.Height / int_Rows + 1, this.Width / int_Columns - 1, this.Height - 2);
            G.DrawRectangle(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);            

            for (int i = 1; i <= int_Columns; i++)
            {
                Point P1 = new Point(i * this.Width / int_Columns, 0);
                Point P2 = new Point(i * this.Width / int_Columns, this.Height);
                G.DrawLine(Pens.Black, P1, P2);
            }

            for (int i = 1; i <= int_Rows; i++)
            {
                Point P1 = new Point(0, i * this.Height / int_Rows);
                Point P2 = new Point(this.Width , i * this.Height / int_Rows);                
                G.DrawLine(Pens.Black, P1, P2);
            }
        }
    }
}
