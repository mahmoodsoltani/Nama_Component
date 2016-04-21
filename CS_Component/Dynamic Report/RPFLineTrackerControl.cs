using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cs_Component {
	public class RPFLineTrackerControl : Cs_Component.RPFTrackerBaseControl {
		private System.ComponentModel.IContainer components = null;
		protected Pen m_line_pen= new Pen( Color.Black);

		public RPFLineTrackerControl() {
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		public RPFLineTrackerControl( RPFLine rpf_object): base( rpf_object){
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
		public override void Render(Graphics g) {
			base.Render (g);

			RPFLine rpf_object= ( RPFLine)this.m_rpf_object;
			#region line
			if( rpf_object.Vertical) {
				g.DrawLine( this.m_line_pen, this.Size.Width>> 1, 0, this.Size.Width>> 1, this.Size.Height);
			} else {
				g.DrawLine( this.m_line_pen, 0, this.Size.Height>> 1, this.Size.Width, this.Size.Height>> 1);
			}
			#endregion
		}

		protected override void RPFObjectChanged(object sender, EventArgs e) {
			base.RPFObjectChanged( sender, e);
			RPFLine rpf_object= ( RPFLine)this.m_rpf_object;
			using( Graphics g= this.CreateGraphics()) {
				if( rpf_object.Vertical){
					this.m_tracking_flags= TRACKER_FLAGS.CENTRE| TRACKER_FLAGS.N| TRACKER_FLAGS.S;
					int width= (int)(float)( rpf_object.Width* g.DpiX);
					int height= (int)(float)( rpf_object.Length* g.DpiY);
					if( width< TrackerBaseControl.MIN_SIZE_X)
						width= TrackerBaseControl.MIN_SIZE_X;
					if( height< TrackerBaseControl.MIN_SIZE_Y)
						height= TrackerBaseControl.MIN_SIZE_Y;
					this.Size= new System.Drawing.Size( width, height);
					if( !this.m_line_pen.Color.Equals( rpf_object.Color)||
						this.m_line_pen.Width!= rpf_object.Width) {
						this.m_line_pen.Dispose();
						this.m_line_pen= new Pen( rpf_object.Color, width);
					}
				} else {
					this.m_tracking_flags= TRACKER_FLAGS.CENTRE| TRACKER_FLAGS.W| TRACKER_FLAGS.E;
					int width= (int)(float)( rpf_object.Length* g.DpiX);
					int height= (int)(float)( rpf_object.Width* g.DpiY);
					if( width< TrackerBaseControl.MIN_SIZE_X)
						width= TrackerBaseControl.MIN_SIZE_X;
					if( height< TrackerBaseControl.MIN_SIZE_Y)
						height= TrackerBaseControl.MIN_SIZE_Y;
					this.Size= new System.Drawing.Size( width, height);
					if( !this.m_line_pen.Color.Equals( rpf_object.Color)||
						this.m_line_pen.Width!= rpf_object.Width) {
						this.m_line_pen.Dispose();
						this.m_line_pen= new Pen( rpf_object.Color, height);
					}
				}
			}
			this.Invalidate( false);
		}
	}
}

