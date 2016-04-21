using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Cs_Component {
	/// <summary>
	/// Summary description for RPFSectionTrackerControl.
	/// </summary>
	public abstract class RPFSectionTrackerControl: RPFTrackerBaseControl, ITrackerControlContainer {
		private System.ComponentModel.IContainer components = null;
		protected Rectangle m_track_bounds= new Rectangle( 0, 0, 0, 0);
		protected Brush m_back_brush;
		private System.Windows.Forms.Timer m_update_timer;
		protected Color m_back_color;
		public RPFSectionTrackerControl( ) {
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			this.AllowDrop= true;

			this.m_back_color= this.BackColor;
			this.m_back_brush= new SolidBrush( this.m_back_color);
		}
		public RPFSectionTrackerControl( RPFSection rpf_object): base( rpf_object){
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			this.AllowDrop= true;
		
			this.m_back_color= this.BackColor;
			this.m_back_brush= new SolidBrush( this.m_back_color);
		}
		protected override void OnLoad(EventArgs e) {
			base.OnLoad (e);
			this.BackColor= Color.White;
			this.Dock= DockStyle.Top;
			// Vertical Size
			using ( Graphics g= this.CreateGraphics()) {
				this.Size= new System.Drawing.Size( this.Size.Width, (int)(float)((( RPFSection)this.m_rpf_object).VerticalSize* g.DpiY));
			}
			this.m_tracking_flags= TRACKER_FLAGS.N| TRACKER_FLAGS.S;
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
		public override Color BackColor {
			get {
				return Color.Transparent;
			}
			set {
//				base.BackColor = value;
				this.m_back_color= value;
				this.m_back_brush.Dispose();
				this.m_back_brush= new SolidBrush( value);
			}
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.m_update_timer = new System.Windows.Forms.Timer(this.components);
			// 
			// m_update_timer
			// 
			this.m_update_timer.Tick += new System.EventHandler(this.m_update_timer_Tick);
			// 
			// RPFSectionTrackerControl
			// 
			this.Name = "RPFSectionTrackerControl";

		}
		#endregion
		#region public methods
		public override void Render(System.Drawing.Graphics g) {
			RPFSection rpf_object= ( RPFSection)this.m_rpf_object;
			#region Border			
			int border_pix_left= (int)( rpf_object.BorderSize.Left* g.DpiX);
			int border_pix_right= (int)( rpf_object.BorderSize.Right* g.DpiX);
			int border_pix_top= (int)( rpf_object.BorderSize.Top* g.DpiY);
			int border_pix_bottom= (int)( rpf_object.BorderSize.Bottom* g.DpiY);
			Rectangle inner_rect= new Rectangle( 
				(int)(float) ( ( rpf_object.ExtMargin.Left)* g.DpiX),
				(int)(float) ( ( rpf_object.ExtMargin.Top)* g.DpiY),
				(int)(float) (this.ClientSize.Width- 1- ( rpf_object.ExtMargin.Right+ rpf_object.ExtMargin.Left)* g.DpiX),
				(int)(float) (this.ClientSize.Height- 1- ( rpf_object.ExtMargin.Top+ rpf_object.ExtMargin.Bottom)* g.DpiY));
			// Draw inner background
			g.FillRectangle( this.m_back_brush, inner_rect);
			
			Rectangle border_draw_rect= new Rectangle( 
				(int)(float) ( ( rpf_object.BorderMargin.Left+ rpf_object.ExtMargin.Left)* g.DpiX),
				(int)(float) ( ( rpf_object.BorderMargin.Top+ rpf_object.ExtMargin.Top)* g.DpiY),
				(int)(float) (this.ClientSize.Width- 1- ( rpf_object.BorderMargin.Right+ rpf_object.BorderMargin.Left+ rpf_object.ExtMargin.Right+ rpf_object.ExtMargin.Left)* g.DpiX),
				(int)(float) (this.ClientSize.Height- 1- ( rpf_object.BorderMargin.Top+ rpf_object.BorderMargin.Bottom+ rpf_object.ExtMargin.Top+ rpf_object.ExtMargin.Bottom)* g.DpiY));

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
			base.Render (g);
		}
		#endregion
		#region ITrackerControlContainer Members

		Rectangle Cs_Component.ITrackerControlContainer.TrackBounds {
			get {
				return this.m_track_bounds;
			}
		}
		public void AddChild( RPFTrackerBaseControl ctrl) {
			ctrl.MouseDown+=new MouseEventHandler(ctrl_MouseDown);
			ctrl.MouseMove+=new MouseEventHandler(ctrl_MouseMove);
			ctrl.MouseUp+=new MouseEventHandler(ctrl_MouseUp);
			ctrl.SelectedChanged+=new Cs_Component.TrackerBaseControl.SelectedChangedEventHandler(ctrl_SelectedChanged);
			ctrl.Tracking+=new Cs_Component.TrackerBaseControl.TrackingEventHandler(ctrl_Tracking);
			if( ctrl is ITrackerControlContainer) {
				((ITrackerControlContainer ) ctrl).ChildMouseDown+=new MouseEventHandler(ctrl_MouseDown);
				((ITrackerControlContainer ) ctrl).ChildMouseMove+=new MouseEventHandler(ctrl_MouseMove);
				((ITrackerControlContainer ) ctrl).ChildMouseUp+=new MouseEventHandler(ctrl_MouseUp);
				((ITrackerControlContainer ) ctrl).ChildSelectedChanged+=new Cs_Component.TrackerBaseControl.SelectedChangedEventHandler(ctrl_SelectedChanged);
				((ITrackerControlContainer ) ctrl).ChildTracking+=new Cs_Component.TrackerBaseControl.TrackingEventHandler(ctrl_Tracking);
			}
			this.Controls.Add( ctrl);
			this.Controls.SetChildIndex( ctrl, 0);
			if( ctrl.RPFObject!= null)
				ctrl.RPFObject.Synch();
			ctrl.CheckTrack();
		}
		public void RemoveChild( RPFTrackerBaseControl ctrl) {
			if( !this.Controls.Contains( ctrl))
				return;
			this.Controls.Remove( ctrl);
			if( ctrl.RPFObject== null) 
				return;
			RPFSection rpf_object= ( RPFSection) this.RPFObject;
			RPFDesignerControl.RPFObjectTag object_tag= ( RPFDesignerControl.RPFObjectTag) ctrl.RPFObject.Tag;
			rpf_object.ElementList.Remove( ctrl.RPFObject);
		}
		public event MouseEventHandler ChildMouseMove;
		public event MouseEventHandler ChildMouseDown;
		public event MouseEventHandler ChildMouseUp;
		public event Cs_Component.TrackerBaseControl.SelectedChangedEventHandler ChildSelectedChanged;
		public event Cs_Component.TrackerBaseControl.TrackingEventHandler ChildTracking;
		public event Cs_Component.AddChildRequestEventHandler AddChildRequest;

		#endregion

		private void ctrl_MouseDown(object sender, MouseEventArgs e) {
			if( this.ChildMouseDown!= null) {
				this.ChildMouseDown( sender, e);
			}
		}

		private void ctrl_MouseMove(object sender, MouseEventArgs e) {
			if( this.ChildMouseMove!= null) {
				this.ChildMouseMove( sender, e);
			}
		}

		private void ctrl_MouseUp(object sender, MouseEventArgs e) {
			if( this.ChildMouseUp!= null) {
				this.ChildMouseUp( sender, e);
			}
		}

		private void ctrl_SelectedChanged(object sender, EventArgs e) {
			if( this.ChildSelectedChanged!= null) {
				this.ChildSelectedChanged( sender, e);
			}
		}

		private void ctrl_Tracking(object sender, Cs_Component.TrackerBaseControl.TrackingEventArgs e) {
			if( this.ChildTracking!= null) {
				this.ChildTracking( sender, e);
			}
		}

		protected override void OnDragEnter(DragEventArgs drgevent) {
			base.OnDragEnter (drgevent);
			object node= drgevent.Data.GetData( "System.Windows.Forms.TreeNode");
			if( node== null) {
				drgevent.Effect= DragDropEffects.None;
				return;
			}
			try {
				RPFDesignerControl.AVAILABLE_TREE_DATA node_data= (RPFDesignerControl.AVAILABLE_TREE_DATA)(( TreeNode)node).Tag;
				switch( node_data.m_type) {
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.BOX:
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.IMAGE:
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.LABEL:
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.LINE:
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.VARIABLE:
						break;
					default:
						drgevent.Effect= DragDropEffects.None;
						return;
				}
				drgevent.Effect= DragDropEffects.Move;
				this.Selected= true;
			} catch {
				drgevent.Effect= DragDropEffects.None;
			}
		}
		protected override void OnDragLeave(EventArgs e) {
			base.OnDragLeave (e);
			this.Selected= false;
		}

		protected override void OnDragDrop(DragEventArgs drgevent) {
			base.OnDragDrop (drgevent);

			object node= drgevent.Data.GetData( "System.Windows.Forms.TreeNode");
			if( node== null) {
				return;
			}
			try {
				Point client_pos= this.PointToClient( new Point( drgevent.X, drgevent.Y));
				RPFDesignerControl.AVAILABLE_TREE_DATA node_data= (RPFDesignerControl.AVAILABLE_TREE_DATA)(( TreeNode)node).Tag;
				// Create new object here
				IRPFObject new_obj= null;
				switch( node_data.m_type) {
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.BOX:
						new_obj= new RPFBox();
						break;
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.IMAGE:
						new_obj= new RPFImage();
						break;
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.LABEL:
						new_obj= new RPFLabel();
						break;
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.LINE:
						new_obj= new RPFLine();
						break;
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.VARIABLE: {
						new_obj= new RPFVariable();
						(( RPFVariable)new_obj).Name= (string)node_data.m_data;
					}
						break;
					default:
						return;
				}
				using ( Graphics g = this.CreateGraphics()) {
					new_obj.Location= new Location( (float)client_pos.X/ g.DpiX, (float)client_pos.Y/ g.DpiY);
				}
				this.OnAddChildRequest( new_obj);
			} catch {
			}
		}
		protected override void RPFObjectChanged(object sender, EventArgs e) {
			Rectangle new_track_bounds;
			using ( Graphics g= this.CreateGraphics()) {
				RPFSection rpf_object= ( RPFSection)this.m_rpf_object;
				this.BackColor= rpf_object.BackColor;
				this.Size = new System.Drawing.Size( this.Size.Width, (int)( float)( rpf_object.VerticalSize* g.DpiY));
				int border_pix_left= (int)( rpf_object.BorderSize.Left* g.DpiX);
				int border_pix_right= (int)( rpf_object.BorderSize.Right* g.DpiX);
				int border_pix_top= (int)( rpf_object.BorderSize.Top* g.DpiY);
				int border_pix_bottom= (int)( rpf_object.BorderSize.Bottom* g.DpiY);
				Rectangle border_draw_rect= new Rectangle( 
					(int)(float) ( ( rpf_object.BorderMargin.Left+ rpf_object.ExtMargin.Left)* g.DpiX),
					(int)(float) ( ( rpf_object.BorderMargin.Top+ rpf_object.ExtMargin.Top)* g.DpiY),
					(int)(float) (this.ClientSize.Width- 1- ( rpf_object.BorderMargin.Right+ rpf_object.BorderMargin.Left+ rpf_object.ExtMargin.Right+ rpf_object.ExtMargin.Left)* g.DpiX),
					(int)(float) (this.ClientSize.Height- 1- ( rpf_object.BorderMargin.Top+ rpf_object.BorderMargin.Bottom+ rpf_object.ExtMargin.Top+ rpf_object.ExtMargin.Bottom)* g.DpiY));
				new_track_bounds= new Rectangle( border_draw_rect.X+ border_pix_left, border_draw_rect.Y+ border_pix_top, border_draw_rect.Width- ( border_pix_right+ border_pix_left), border_draw_rect.Height- ( border_pix_bottom+ border_pix_top));
			}
			if( !this.m_track_bounds.Equals( new_track_bounds)) {
				this.m_track_bounds= new_track_bounds;
				foreach( RPFTrackerBaseControl ctrl in this.Controls) {
					ctrl.CheckTrack( );
				}
				this.m_update_timer.Start();
			}
			this.Invalidate( false);
		}
		protected void OnAddChildRequest( IRPFObject rpf_child_object) {
			if( this.AddChildRequest!= null) {
				RPFSection rpf_object= ( RPFSection)this.RPFObject;
				rpf_object.ElementList.Add( rpf_child_object);
				this.AddChildRequest( this, new AddChildRequestEventArgs( rpf_child_object, this));
			}
		}

		private void m_update_timer_Tick(object sender, System.EventArgs e) {
			this.m_update_timer.Enabled= false;
			if( this.Parent is RPFDocumentTrackerControl) {
				((RPFDocumentTrackerControl) this.Parent).DoLayout();
			}
		}
	}
}
