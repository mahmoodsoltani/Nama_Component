using System;
using System.Windows.Forms;
using System.Drawing;

namespace Cs_Component {
	/// <summary>
	/// Summary description for RPFTrackerBaseControl.
	/// </summary>
	public class RPFTrackerBaseControl: TrackerBaseControl {
		public RPFTrackerBaseControl( ) {
		}
		public RPFTrackerBaseControl( IRPFObject rpf_object) {
			this.RPFObject= rpf_object;
		}
		#region properties
		protected IRPFObject m_rpf_object;
		public virtual IRPFObject RPFObject {
			get { return this.m_rpf_object;}
			set { 
				this.m_rpf_object= value;
				if( this.m_rpf_object!= null)
					this.m_rpf_object.Changed+=new EventHandler(RPFObjectChanged);
			}
		}
		#endregion

		private bool m_skip_update= false;
		protected override void OnSizeChanged(EventArgs e) {
			base.OnSizeChanged (e);
			if( this.RPFObject!= null) {
				using ( Graphics g= this.CreateGraphics()) {
					try {
						this.m_skip_update= true;
						float new_width= this.RPFObject.Size.Width;
						float new_height= this.RPFObject.Size.Height;
						if(( this.m_tracking_flags& ( TRACKER_FLAGS.E| TRACKER_FLAGS.W))!= 0)
							new_width= this.Width/ g.DpiX;
						if(( this.m_tracking_flags& ( TRACKER_FLAGS.N| TRACKER_FLAGS.S))!= 0)
							new_height= this.Height/ g.DpiY;
						this.RPFObject.Size= new Size( new_width, new_height);
					} finally {
						this.m_skip_update= false;
					}
				}
			}
		}
		protected override void OnLocationChanged(EventArgs e) {
			base.OnLocationChanged (e);
			if( this.RPFObject!= null) {
				using ( Graphics g= this.CreateGraphics()) {
					try {
						this.m_skip_update= true;
						this.RPFObject.Location= new Location( this.Location.X/ g.DpiX, this.Location.Y/ g.DpiY);
					} finally {
						this.m_skip_update= false;
					}
				}
			}
		}
		protected virtual void RPFObjectChanged(object sender, EventArgs e) {
			using ( Graphics g= this.CreateGraphics()) {
				if( !this.m_skip_update) {
					this.Location= new Point( (int)( float)( this.m_rpf_object.Location.X* g.DpiX), (int)( float)( this.m_rpf_object.Location.Y* g.DpiY));
					int width= (int)( float)( this.m_rpf_object.Size.Width* g.DpiX);
					int height= (int)( float)( this.m_rpf_object.Size.Height* g.DpiY);
					if( width< TrackerBaseControl.MIN_SIZE_X)
						width= TrackerBaseControl.MIN_SIZE_X;
					if( height< TrackerBaseControl.MIN_SIZE_Y)
						height= TrackerBaseControl.MIN_SIZE_Y;
					this.Size = new System.Drawing.Size( width, height);
				}
			}
		}
	}
}
