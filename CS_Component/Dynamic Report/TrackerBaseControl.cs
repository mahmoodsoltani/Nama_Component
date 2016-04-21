using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace Cs_Component {
	/// <summary>
	/// Summary description for TrackerBaseControl.
	/// </summary>
	public class TrackerBaseControl : System.Windows.Forms.UserControl {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Brush m_tracker_brush;
		private Region m_track_region;
		private const int TRACKER_SIZE= 2;
		private const int TRACKER_HIST= 4;
		private const int TRACKER_HIT_SIZE= TRACKER_SIZE+ 1;
		protected TRACKER_MODE m_tracking_mode= TRACKER_MODE.NONE;
		protected TRACKER_FLAGS m_tracking_flags= TRACKER_FLAGS.ALL;
		public const int MIN_SIZE_X= 1;
		public const int MIN_SIZE_Y= 1;
		private Point m_last_track_pos= new Point(0, 0);
		protected bool m_is_tracking= false;

		public TrackerBaseControl() {
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint| ControlStyles.DoubleBuffer| ControlStyles.UserPaint| ControlStyles.SupportsTransparentBackColor, true);
			this.UpdateStyles();

			this.m_tracker_brush= new HatchBrush( HatchStyle.BackwardDiagonal, Color.Black, Color.Red);
			this.m_track_region= new Region( this.ClientRectangle);
			this.m_track_region.Xor( new Rectangle( TRACKER_SIZE, TRACKER_SIZE, this.ClientSize.Width- (TRACKER_SIZE<< 1), this.ClientSize.Height- (TRACKER_SIZE<< 1)));
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			// 
			// TrackerBaseControl
			// 
			this.Name = "TrackerBaseControl";
			this.Size = new System.Drawing.Size(88, 40);

		}
		#endregion

		#region public properties
		protected bool m_selected= false;
		public bool Selected {
			get{ return this.m_selected;}
			set{ 
				if( this.m_selected== value)
					return;
				if(( this.Parent is TrackerBaseControl) && value) {
					(( TrackerBaseControl)this.Parent).Selected= false;
				}
				if( value)
					this.Focus();
				this.m_selected= value;
				this.Cursor= this.m_selected? Cursors.SizeAll: Cursors.Default;
				this.Invalidate( false);
				this.OnSelectedChanged();
			}
		}
		public bool IsTracking{
			get { return this.m_is_tracking;}
		}
		#endregion
		#region public methods
		public virtual void Render( Graphics g) {
			// Draw control bounds
			ControlPaint.DrawBorder( g, this.ClientRectangle, Color.Black, ButtonBorderStyle.Dashed);
		}
		#endregion

		protected virtual void DrawTracker( Graphics g) {
			g.FillRegion( this.m_tracker_brush, this.m_track_region);
		}
		public enum TRACKER_MODE {
			NONE,
			CENTRE,
			W,
			E,
			N,
			S,
			NE,
			NW,
			SE,
			SW
		};
		[FlagsAttribute]
		public enum TRACKER_FLAGS: ushort {
			NONE= 0x0000,
			ALL= 0xffff,
			CENTRE= 0x0001,
			W= 0x0002,
			E= 0x0004,
			N= 0x0008,
			S= 0x0010,
		};
		protected TRACKER_MODE TestTracker( int X, int Y) {
			TRACKER_MODE def_tm= (( this.m_tracking_flags& TRACKER_FLAGS.CENTRE)== TRACKER_FLAGS.CENTRE)? TRACKER_MODE.CENTRE: TRACKER_MODE.NONE;
			if( X< TRACKER_HIT_SIZE){
				// Check vertical
				if(( this.m_tracking_flags& TRACKER_FLAGS.W)== TRACKER_FLAGS.NONE)
					return def_tm;
				if( Y< ( TRACKER_HIT_SIZE<< 1)){
					return ( (this.m_tracking_flags& TRACKER_FLAGS.N)== TRACKER_FLAGS.N)? TRACKER_MODE.NW: TRACKER_MODE.W;
				}
				if( Y> (this.ClientSize.Height- ( TRACKER_HIT_SIZE<< 1))){
					return ( (this.m_tracking_flags& TRACKER_FLAGS.S)== TRACKER_FLAGS.S)? TRACKER_MODE.SW: TRACKER_MODE.W;
				} 
				return TRACKER_MODE.W;
			}
			if( X> ( this.ClientSize.Width- TRACKER_HIT_SIZE)){
				// Check vertical
				if(( this.m_tracking_flags& TRACKER_FLAGS.E)== TRACKER_FLAGS.NONE)
					return def_tm;
				if( Y< ( TRACKER_HIT_SIZE<< 1)){
					return ( (this.m_tracking_flags& TRACKER_FLAGS.N)== TRACKER_FLAGS.N)? TRACKER_MODE.NE: TRACKER_MODE.E;
				}
				if( Y> (this.ClientSize.Height- ( TRACKER_HIT_SIZE<< 1))){
					return ( (this.m_tracking_flags& TRACKER_FLAGS.S)== TRACKER_FLAGS.S)? TRACKER_MODE.SE: TRACKER_MODE.E;
				} 
				return TRACKER_MODE.E;
			} 
			if( Y< TRACKER_HIT_SIZE){
				// Check vertical
				if(( this.m_tracking_flags& TRACKER_FLAGS.N)== TRACKER_FLAGS.NONE)
					return def_tm;
				if( X< ( TRACKER_HIT_SIZE<< 1)){
					return ( (this.m_tracking_flags& TRACKER_FLAGS.W)== TRACKER_FLAGS.W)? TRACKER_MODE.NW: TRACKER_MODE.N;
				}
				if( X> (this.ClientSize.Width- ( TRACKER_HIT_SIZE<< 1))){
					return ( (this.m_tracking_flags& TRACKER_FLAGS.E)== TRACKER_FLAGS.E)? TRACKER_MODE.NE: TRACKER_MODE.N;
				} 
				return TRACKER_MODE.N;
			}
			if( Y> ( this.ClientSize.Height- TRACKER_HIT_SIZE)){
				// Check vertical
				if(( this.m_tracking_flags& TRACKER_FLAGS.S)== TRACKER_FLAGS.NONE)
					return def_tm;
				if( X< ( TRACKER_HIT_SIZE<< 1)){
					return ( (this.m_tracking_flags& TRACKER_FLAGS.W)== TRACKER_FLAGS.W)? TRACKER_MODE.SW: TRACKER_MODE.S;
				}
				if( X> (this.ClientSize.Width- ( TRACKER_HIT_SIZE<< 1))){
					return ( (this.m_tracking_flags& TRACKER_FLAGS.E)== TRACKER_FLAGS.E)? TRACKER_MODE.SE: TRACKER_MODE.S;
				} 
				return TRACKER_MODE.S;
			} 
			return def_tm;
		}
		public void Track( int delta_X, int delta_Y, TRACKER_MODE tracker_mode) {
			if( !this.m_selected)
				return;
			this.DoTrack( delta_X, delta_Y, tracker_mode);
		}
		public void CheckTrack( ) {
			this.DoTrack( 0, 0, TRACKER_MODE.CENTRE);
		}

		protected void DoTrack( int delta_X, int delta_Y, TRACKER_MODE tracker_mode) {
			if( !this.IsHandleCreated)
				return;
			Point new_location= this.Location;
			System.Drawing.Size new_size= this.Size;
			switch( tracker_mode) {
				case TRACKER_MODE.CENTRE:
					// Moving 
					new_location= new Point( this.Location.X+ delta_X, this.Location.Y+ delta_Y);
					break;
				case TRACKER_MODE.W:
					// Resize left side
					new_location= new Point( this.Location.X+ delta_X, this.Location.Y);
					new_size= new System.Drawing.Size( this.Width- delta_X, this.Height);
					break;
				case TRACKER_MODE.E:
					// Resize right side
					new_size= new System.Drawing.Size( this.Width+ delta_X, this.Height);
					break;
				case TRACKER_MODE.N:
					// Resize up side
					new_location= new Point( this.Location.X, this.Location.Y+ delta_Y);
					new_size= new System.Drawing.Size( this.Width, this.Height- delta_Y);
					break;
				case TRACKER_MODE.S:
					// Resize down side
					new_size= new System.Drawing.Size( this.Width, this.Height+ delta_Y);
					break;
				case TRACKER_MODE.NW:
					// Resize left - up side
					new_location= new Point( this.Location.X+ delta_X, this.Location.Y+ delta_Y);
					new_size= new System.Drawing.Size( this.Width- delta_X, this.Height- delta_Y);
					break;
				case TRACKER_MODE.NE:
					// Resize right - up side
					new_location= new Point( this.Location.X, this.Location.Y+ delta_Y);
					new_size= new System.Drawing.Size( this.Width+ delta_X, this.Height- delta_Y);
					break;
				case TRACKER_MODE.SW:
					// Resize left - down side
					new_location= new Point( this.Location.X+ delta_X, this.Location.Y);
					new_size= new System.Drawing.Size( this.Width- delta_X, this.Height+ delta_Y);
					break;
				case TRACKER_MODE.SE:
					// Resize left - down side
					new_size= new System.Drawing.Size( this.Width+ delta_X, this.Height+ delta_Y);
					break;
			}
			if( new_size.Width< MIN_SIZE_X)
				new_size.Width= MIN_SIZE_X;
			if( new_size.Height< MIN_SIZE_Y)
				new_size.Height= MIN_SIZE_Y;
			Rectangle track_bounds= ((ITrackerControlContainer)this.Parent).TrackBounds;

			if( new_location.X< track_bounds.Left)
				new_location.X= track_bounds.Left;
			else if( new_location.X+ new_size.Width> track_bounds.Right)
				new_location.X= track_bounds.Right- new_size.Width;
			if( new_location.Y< track_bounds.Top)
				new_location.Y= track_bounds.Top;
			else if( new_location.Y+ new_size.Height> track_bounds.Bottom)
				new_location.Y= track_bounds.Bottom- new_size.Height;
			
			this.Location= new_location;
			this.Size= new_size;
		}
		#region overrides
		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint( e);
			this.Render( e.Graphics);
			if( this.m_selected) {
				this.DrawTracker( e.Graphics);
			}
		}
	
		protected override void OnSizeChanged(EventArgs e) {
			base.OnSizeChanged (e);
			if( this.m_track_region!= null)
				this.m_track_region.Dispose();
			this.m_track_region= new Region( this.ClientRectangle);
			this.m_track_region.Xor( new Rectangle( TRACKER_SIZE, TRACKER_SIZE, this.ClientSize.Width- (TRACKER_SIZE<< 1), this.ClientSize.Height- (TRACKER_SIZE<< 1)));
			this.Invalidate( false);
		}
		protected override void OnMouseMove(MouseEventArgs e) {
			Point act_pos= PointToScreen( new Point( e.X, e.Y));
			if( this.m_tracking_mode!= TRACKER_MODE.NONE) {
				if( this.m_is_tracking||
					(( Math.Abs( this.m_last_track_pos.X- act_pos.X)> TRACKER_HIST)||
					( Math.Abs( this.m_last_track_pos.Y- act_pos.Y)> TRACKER_HIST))) {
					int delta_X= act_pos.X- m_last_track_pos.X;
					int delta_Y= act_pos.Y- m_last_track_pos.Y;
					this.DoTrack( delta_X, delta_Y, this.m_tracking_mode);
					this.m_last_track_pos= act_pos;
					this.m_is_tracking= true;
					if(( delta_X!= 0)|| ( delta_Y!= 0))
						this.OnTracking( delta_X, delta_Y, this.m_tracking_mode);
				}
				return;
			}
			switch( this.TestTracker( e.X, e.Y)) {
				case TRACKER_MODE.NW:
				case TRACKER_MODE.SE:
					this.Cursor= Cursors.SizeNWSE;
					break;
				case TRACKER_MODE.NE:
				case TRACKER_MODE.SW:
					this.Cursor= Cursors.SizeNESW;
					break;
				case TRACKER_MODE.N:
				case TRACKER_MODE.S:
					this.Cursor= Cursors.SizeNS;
					break;
				case TRACKER_MODE.E:
				case TRACKER_MODE.W:
					this.Cursor= Cursors.SizeWE;
					break;
				case TRACKER_MODE.NONE:
					this.Cursor= Cursors.Default;
					break;
				case TRACKER_MODE.CENTRE:
				default:
					this.Cursor= Cursors.SizeAll;
					break;
			}
			base.OnMouseMove( e);
		}
		protected override void OnMouseDown(MouseEventArgs e) {
			this.m_tracking_mode= this.TestTracker( e.X, e.Y);
			this.m_last_track_pos= PointToScreen( new Point( e.X, e.Y));
			this.Capture= true;
			if(( Control.ModifierKeys& Keys.Shift)!= 0) {
				this.Selected= !this.Selected;
			} else 
				this.Selected= true;
			this.m_is_tracking= false;
			if( this.m_tracking_mode== TRACKER_MODE.NONE)
				base.OnMouseDown( e);
		}
		protected override void OnMouseUp(MouseEventArgs e) {
			if( this.m_tracking_mode== TRACKER_MODE.NONE)
				base.OnMouseUp( e);
			this.m_tracking_mode= TRACKER_MODE.NONE;
			this.Capture= false;
			if( this.m_is_tracking)
				this.OnTracking( 0, 0, this.m_tracking_mode);
			this.m_is_tracking= false;
			this.Focus();			
		}

		#endregion
		#region events
		public delegate void SelectedChangedEventHandler(object sender, EventArgs e);
		public event SelectedChangedEventHandler SelectedChanged;
		protected virtual void OnSelectedChanged( ) {
			if( this.SelectedChanged!= null)
				this.SelectedChanged( this, new EventArgs());
		}

		public delegate void TrackingEventHandler(object sender, TrackingEventArgs e);
		public event TrackingEventHandler Tracking;
		protected virtual void OnTracking( int delta_X, int delta_Y, TRACKER_MODE mode) {
			if( this.Tracking!= null)
				this.Tracking( this, new TrackingEventArgs( delta_X, delta_Y, mode));
		}
		public class TrackingEventArgs: EventArgs{
			public TrackingEventArgs( int delta_X, int delta_Y, TRACKER_MODE mode) {
				this.m_delta_X= delta_X;
				this.m_delta_Y= delta_Y;
				this.m_mode= mode;
			}
			public int m_delta_X;
			public int m_delta_Y;
			public TRACKER_MODE m_mode;
		}
		#endregion
	}
}
