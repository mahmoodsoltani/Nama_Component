using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cs_Component {
	public class RPFBaseLabelTrackerControl : Cs_Component.RPFTrackerBaseControl {
		private System.ComponentModel.IContainer components = null;
		protected Brush m_fore_brush;
		protected StringFormat m_string_format= new StringFormat();

		public RPFBaseLabelTrackerControl() {
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			this.m_fore_brush= new SolidBrush( this.ForeColor);
		}
		public RPFBaseLabelTrackerControl( RPFBaseLabel rpf_object): base( rpf_object){
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			this.m_fore_brush= new SolidBrush( this.ForeColor);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
		}
		#endregion
	
		#region public methods
		public override void Render(System.Drawing.Graphics g) {
			base.Render (g);
			if( this.DesignMode)
				return;
			RPFBaseLabel rpf_object= ( RPFBaseLabel)this.m_rpf_object;

			#region Border
			int border_pix_left= (int)( rpf_object.BorderSize.Left* g.DpiX);
			int border_pix_right= (int)( rpf_object.BorderSize.Right* g.DpiX);
			int border_pix_top= (int)( rpf_object.BorderSize.Top* g.DpiY);
			int border_pix_bottom= (int)( rpf_object.BorderSize.Bottom* g.DpiY);
			Rectangle border_draw_rect= new Rectangle( 
				(int)(float) ( rpf_object.BorderMargin.Left* g.DpiX),
				(int)(float) ( rpf_object.BorderMargin.Top* g.DpiY),
				(int)(float) (this.ClientSize.Width- 1- ( rpf_object.BorderMargin.Right+ rpf_object.BorderMargin.Left)* g.DpiX),
				(int)(float) (this.ClientSize.Height- 1- ( rpf_object.BorderMargin.Top+ rpf_object.BorderMargin.Bottom)* g.DpiY));
			if( rpf_object.BorderSize.Top!= 0) {
				using( Pen border_pen= new Pen( rpf_object.BorderColor, border_pix_top)) { 
					g.DrawLine( border_pen, border_draw_rect.X, border_draw_rect.Y+ ( border_pix_top>> 1), border_draw_rect.X+ border_draw_rect.Width, border_draw_rect.Y+ ( border_pix_top>> 1));
				} 
			}
			if( rpf_object.BorderSize.Bottom!= 0) {
				using( Pen border_pen= new Pen( rpf_object.BorderColor, border_pix_bottom)) { 
					g.DrawLine( border_pen, border_draw_rect.X, border_draw_rect.Y+ border_draw_rect.Height- ( border_pix_bottom>> 1), border_draw_rect.X+ border_draw_rect.Width, border_draw_rect.Y+ border_draw_rect.Height- ( border_pix_bottom>> 1));
				}
			}
			if( rpf_object.BorderSize.Left!= 0) {
				using( Pen border_pen= new Pen( rpf_object.BorderColor, border_pix_left)) { 
					g.DrawLine( border_pen, border_draw_rect.X+ ( border_pix_left>> 1), border_draw_rect.Y, border_draw_rect.X+ ( border_pix_left>> 1), border_draw_rect.Y+ border_draw_rect.Height);
				}
			}
			if( rpf_object.BorderSize.Right!= 0) {
				using( Pen border_pen= new Pen( rpf_object.BorderColor, border_pix_right)) { 
					g.DrawLine( border_pen, border_draw_rect.X+ border_draw_rect.Width- ( border_pix_right>> 1), border_draw_rect.Y, border_draw_rect.X+ border_draw_rect.Width- ( border_pix_right>> 1), border_draw_rect.Y+ border_draw_rect.Height);
				}
			}
			#endregion
		
			#region Text
			g.DrawString( rpf_object.Text, rpf_object.Font, this.m_fore_brush, this.ClientRectangle, this.m_string_format);
			#endregion
		}
		#endregion
		protected void UpdateStringFormat() {
			if( this.m_rpf_object== null)
				return;
			RPFBaseLabel rpf_object= ( RPFBaseLabel)this.m_rpf_object;

			this.m_string_format= new StringFormat();
			this.m_string_format.FormatFlags= StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
			this.m_string_format.Trimming= StringTrimming.Word;
			switch( rpf_object.TextAlignment) {
				case ContentAlignment.BottomCenter:
					this.m_string_format.LineAlignment= StringAlignment.Far;
					this.m_string_format.Alignment= StringAlignment.Center;
					break;
				case ContentAlignment.BottomLeft:
					this.m_string_format.LineAlignment= StringAlignment.Far;
					this.m_string_format.Alignment= StringAlignment.Near;
					break;
				case ContentAlignment.BottomRight:
					this.m_string_format.LineAlignment= StringAlignment.Far;
					this.m_string_format.Alignment= StringAlignment.Far;
					break;
				case ContentAlignment.MiddleCenter:
					this.m_string_format.LineAlignment= StringAlignment.Center;
					this.m_string_format.Alignment= StringAlignment.Center;
					break;
				case ContentAlignment.MiddleLeft:
					this.m_string_format.LineAlignment= StringAlignment.Center;
					this.m_string_format.Alignment= StringAlignment.Near;
					break;
				case ContentAlignment.MiddleRight:
					this.m_string_format.LineAlignment= StringAlignment.Center;
					this.m_string_format.Alignment= StringAlignment.Far;
					break;
				case ContentAlignment.TopCenter:
					this.m_string_format.LineAlignment= StringAlignment.Near;
					this.m_string_format.Alignment= StringAlignment.Center;
					break;
				case ContentAlignment.TopLeft:
					this.m_string_format.LineAlignment= StringAlignment.Near;
					this.m_string_format.Alignment= StringAlignment.Near;
					break;
				case ContentAlignment.TopRight:
					this.m_string_format.LineAlignment= StringAlignment.Near;
					this.m_string_format.Alignment= StringAlignment.Far;
					break;
			}
		}
		protected override void RPFObjectChanged(object sender, EventArgs e) {
			base.RPFObjectChanged( sender, e);
			RPFBaseLabel rpf_object= ( RPFBaseLabel)this.m_rpf_object;
			this.BackColor= rpf_object.BackColor;
			this.ForeColor= rpf_object.ForeColor;
			if( this.m_fore_brush!= null)
				this.m_fore_brush.Dispose();
			this.m_fore_brush= new SolidBrush( rpf_object.ForeColor);
			this.Font= rpf_object.Font;
			this.UpdateStringFormat();

			this.Invalidate( true);
		}
	}
}

