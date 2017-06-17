using System.Drawing;
using System.Globalization;

namespace System.Windows.Forms
{
    public enum FarsiDays { Saturday,Sunday,Monday,Tuesday,Wednesday,Thursday,Friday}

    public enum HeaderMode { MonthYear,Year }

    public partial class frm_Calendar : Form
    {
        public delegate void SelectDateHandler(string Date);

        public event SelectDateHandler DateSelected;

        public event EventHandler OpacityFulled;

        private string[] Months = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

        FarsiDays CurDay;
        int int_CurWeek = 1;
        DateTime FirstDay;
        bool bol_SelectYear = false;
        int int_ShowYear;
        int int_ShowMont;
        int int_ShowDay;

        private string str_Date;

        PersianCalendar Pc = new PersianCalendar();

        public string Date
        {
            get 
            {
                if (str_Date == null) return Pc.GetYear(DateTime.Now).ToString() + "/" + Pc.GetMonth(DateTime.Now).ToString().PadLeft(2, '0') + "/" + Pc.GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, '0');
                if (str_Date.Length != 10) return Pc.GetYear(DateTime.Now).ToString() + "/" + Pc.GetMonth(DateTime.Now).ToString().PadLeft(2, '0') + "/" + Pc.GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, '0');
                return str_Date; 
            }
            set 
            { 
                str_Date = value;
                if(str_Date!=null)
                    if (str_Date.Length == 10)
                    {
                        int_ShowYear = int.Parse(Date.Substring(0, 4));
                        int_ShowMont = int.Parse(Date.Substring(5, 2));
                        int_ShowDay = int.Parse(Date.Substring(8, 2));
                    }
                    else
                    {
                        str_Date = Pc.GetYear(DateTime.Now).ToString() + "/" + Pc.GetMonth(DateTime.Now).ToString().PadLeft(2, '0') + "/" + Pc.GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, '0');
                    }
            }
        }

        public frm_Calendar()
        {
            InitializeComponent();
        }

        private void DrawCalendar(string Date)
        {
            for (int i = 0; i <= 31; i++)
            {
                calendar1.Controls.RemoveByKey("B"+i.ToString());
            }
            int_CurWeek = 1;

            PersianCalendar Pc = new PersianCalendar();

            int_ShowYear = int.Parse(Date.Substring(0, 4));

            int_ShowMont = int.Parse(Date.Substring(5, 2));

            int_ShowDay = int.Parse(Date.Substring(8, 2));

            lbl_Month.Text = Months[int_ShowMont - 1];
            lbl_Year.Text = Farsi(int_ShowYear.ToString());

            DateTime CurrentDate = Pc.ToDateTime(int_ShowYear, int_ShowMont, int_ShowDay, 0, 0, 0, 0);

            if (Pc.GetDayOfMonth(CurrentDate) != 1)
            {
                FirstDay = Pc.ToDateTime(int_ShowYear, int_ShowMont, 1, 0, 0, 0, 0);
            }
            else
            {
                FirstDay = CurrentDate;
            }
            int int_Max = Pc.GetDaysInMonth(int_ShowYear, int_ShowMont);
            switch (FirstDay.DayOfWeek)
            {
                case DayOfWeek.Saturday: CurDay = FarsiDays.Saturday;
                    break;
                case DayOfWeek.Sunday: CurDay = FarsiDays.Sunday;
                    break;
                case DayOfWeek.Monday: CurDay = FarsiDays.Monday;
                    break;
                case DayOfWeek.Tuesday: CurDay = FarsiDays.Tuesday;
                    break;
                case DayOfWeek.Wednesday: CurDay = FarsiDays.Wednesday;
                    break;
                case DayOfWeek.Thursday: CurDay = FarsiDays.Thursday;
                    break;
                case DayOfWeek.Friday: CurDay = FarsiDays.Friday;
                    break;
            }

            for (int i = 1; i <= int_Max; i++)
            {
                DrawCalendarDays(CurDay, i, (i == int_ShowDay));
                CurDay = (FarsiDays)(((int)CurDay + 1));
                if (CurDay > FarsiDays.Friday)
                {
                    CurDay = FarsiDays.Saturday;
                }
            }
        }

        private void DrawCalendarDays(FarsiDays CurDay, int i, bool IsToDay)
        {
            Button B = new Button();
            B.Name = "B" + i.ToString();
            B.Size = new Size(36, 19);
            B.Text = Farsi(i.ToString());
            B.Top = (int_CurWeek * 22) + 2;
            B.Left = calendar1.Width - 3 - (((int)CurDay) * 20) - B.Width - ((int)CurDay) * 21;
            if (IsToDay)
                B.BackColor = Color.Wheat;
            B.FlatStyle = FlatStyle.Flat;
            if (CurDay == FarsiDays.Friday)
            {
                //B.BackColor = Color.MistyRose;
                //B.FlatAppearance.MouseOverBackColor = Color.MistyRose;
                //B.FlatAppearance.MouseDownBackColor = Color.MistyRose;
                B.BackColor = Color.Transparent;
                B.FlatAppearance.MouseOverBackColor = Color.Transparent;
                B.FlatAppearance.MouseDownBackColor = Color.Transparent;
            }

            else
            {
                B.BackColor = Color.Transparent;
                B.FlatAppearance.MouseOverBackColor = Color.Transparent;
                B.FlatAppearance.MouseDownBackColor = Color.Transparent;
                //B.BackColor = Color.White;
                //B.FlatAppearance.MouseOverBackColor = Color.White;
                //B.FlatAppearance.MouseDownBackColor = Color.White;
            }
            B.FlatAppearance.BorderSize = 0;
            if (i == int_ShowDay)
            {
                B.BackColor = Color.WhiteSmoke;
            }
            B.Cursor = Cursors.Hand;
            B.Tag = int_ShowYear.ToString() + "/" + int_ShowMont.ToString().PadLeft(2, '0') + "/" + i.ToString().PadLeft(2, '0');
            B.Click += new EventHandler(B_Click);
            calendar1.Controls.Add(B);
            if (CurDay == FarsiDays.Friday)
                int_CurWeek++;
        }

        void B_Click(object sender, EventArgs e)
        {
            if(DateSelected!=null)
                DateSelected(this.Text=((Button)sender).Tag.ToString());
            this.Close();
        }

        private string Farsi(string Input)
        {
            return Input.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
        }

        private void btn_PreviousMonth_Click(object sender, EventArgs e)
        {
            if (!bol_SelectYear)
            {
                int_ShowMont--;
                if (int_ShowMont == 0)
                {
                    int_ShowMont = 12;
                    int_ShowYear--;
                }
            }
            else
            {
                int_ShowYear--;
            }
            try
            {
                DrawCalendar(int_ShowYear.ToString() + "/" + int_ShowMont.ToString().PadLeft(2, '0') + "/" + int_ShowDay.ToString().PadLeft(2, '0'));
            }
            catch { }
        }

        private void btn_NextMonth_Click(object sender, EventArgs e)
        {
            if (!bol_SelectYear)
            {
                int_ShowMont++;
                if (int_ShowMont == 13)
                {
                    int_ShowMont = 1;
                    int_ShowYear++;
                }
            }
            else
            {
                int_ShowYear++;
            }
            try
            {
                DrawCalendar(int_ShowYear.ToString() + "/" + int_ShowMont.ToString().PadLeft(2, '0') + "/" + int_ShowDay.ToString().PadLeft(2, '0'));
            }
            catch { }
        }

        private void lbl_Year_Click(object sender, EventArgs e)
        {
            if (bol_SelectMonth) return;
            bol_SelectYear = !bol_SelectYear;
            if (bol_SelectYear)
            {
                lbl_Year.ForeColor = Color.Red;
                toolTip1.SetToolTip(btn_NextMonth, "سال بعد");
                toolTip1.SetToolTip(btn_PreviousMonth, "سال قبل");
            }
            else
            {
                lbl_Year.ForeColor = Color.Navy;
                toolTip1.SetToolTip(btn_NextMonth, "ماه بعد");
                toolTip1.SetToolTip(btn_PreviousMonth, "ماه قبل");
            }
        }

        private void lbl_Today_Click(object sender, EventArgs e)
        {
            DrawCalendar(Pc.GetYear(DateTime.Now).ToString() + "/" + Pc.GetMonth(DateTime.Now).ToString().PadLeft(2, '0') + "/" + Pc.GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, '0'));
        }

        private void frm_Calendar_Load(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                //((Form)this.Owner).MouseDown += new MouseEventHandler(frm_Calendar_MouseDown);
                //((Form)this.Owner).Move += new EventHandler(frm_Calendar_Move);
                //((Form)this.Owner).Resize += new EventHandler(frm_Calendar_Resize);

            }
            PersianCalendar Pc = new PersianCalendar();
            lbl_Today.Text = Farsi(Pc.GetYear(DateTime.Now).ToString() + "/" + Pc.GetMonth(DateTime.Now).ToString().PadLeft(2, '0') + "/" + Pc.GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, '0'));
            DrawCalendar(Date);
            timer1.Start();
        }

        void frm_Calendar_Resize(object sender, EventArgs e)
        {
            this.Close();
        }

        void frm_Calendar_Move(object sender, EventArgs e)
        {
            this.Close();
        }

        void frm_Calendar_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        public event EventHandler TimerTick;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TimerTick != null)
                TimerTick(this, new EventArgs());
            this.Opacity += 0.05;
            if (this.Opacity == 1)
            {
                timer1.Stop();
                if (OpacityFulled != null)
                    OpacityFulled(this, new EventArgs());
            }
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            Close();
        }

        private bool bol_SelectMonth;

        private void lbl_Month_Click(object sender, EventArgs e)
        {
            bol_SelectMonth = !bol_SelectMonth;
            if (bol_SelectMonth)
            {
                lbl_Month.ForeColor = Color.Red;
                //cld_MonthCalendar.Show();
                cld_MonthCalendar.BringToFront();
            }
            else
            {
                lbl_Month.ForeColor = Color.Navy;
                cld_MonthCalendar.SendToBack();
            }
        }

        private void MonthLabel_Click(object sender, EventArgs e)
        {
            cld_MonthCalendar.SendToBack();
            lbl_Month_Click(sender, e);
            int_ShowMont = int.Parse(((Label)sender).Tag.ToString());
            DrawCalendar(int_ShowYear.ToString() + "/" + int_ShowMont.ToString().PadLeft(2, '0') + "/" + int_ShowDay.ToString().PadLeft(2, '0'));            
        }
    }
}