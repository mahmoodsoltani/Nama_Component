using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cs_Component {
	public class RPFBoxTrackerControl : Cs_Component.RPFTrackerBaseControl {
		private System.ComponentModel.IContainer components = null;

		public RPFBoxTrackerControl() {
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		public RPFBoxTrackerControl( RPFBox rpf_object): base( rpf_object){
			// This call is required by the Windows Form Designer.
			InitializeComponent();
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
			RPFBox rpf_object= ( RPFBox)this.m_rpf_object;

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
		}
		#endregion
		protected override void RPFObjectChanged(object sender, EventArgs e) {
			base.RPFObjectChanged( sender, e);
			RPFBox rpf_object= ( RPFBox)this.m_rpf_object;
			this.BackColor= rpf_object.BackColor;

			this.Invalidate( true);
		}
	}
}

