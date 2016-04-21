using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Cs_Component {
	public class RPFDocumentTrackerControl : Cs_Component.RPFTrackerBaseControl, ITrackerControlContainer {
		private System.ComponentModel.IContainer components = null;

		public RPFDocumentTrackerControl() {
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			this.AllowDrop= true;
		}
		public RPFDocumentTrackerControl( RPFDocument rpf_object): base( rpf_object){
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			this.AllowDrop= true;
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
		protected override void OnLoad(EventArgs e) {
			base.OnLoad (e);
			this.BackColor= Color.White;
			this.Dock= DockStyle.Fill;
			this.m_tracking_flags= TRACKER_FLAGS.NONE;
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
		
		#region ITrackerControlContainer Members

		Rectangle Cs_Component.ITrackerControlContainer.TrackBounds {
			get {
				return this.ClientRectangle;
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
			this.DoLayout();
		}
		public void RemoveChild( RPFTrackerBaseControl ctrl) {
			if( !this.Controls.Contains( ctrl))
				return;
			this.Controls.Remove( ctrl);
			if( ctrl.RPFObject== null) 
				return;
			RPFDocument rpf_object= ( RPFDocument) this.RPFObject;
			RPFDesignerControl.RPFObjectTag object_tag= ( RPFDesignerControl.RPFObjectTag) ctrl.RPFObject.Tag;
			rpf_object.ElementList.Remove( ctrl.RPFObject);
			this.DoLayout();
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
				if( sender is RPFSectionTrackerControl) {
					this.Refresh( );
				}
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
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.SECTION:
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.TABLE_ROW_SECTION:
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
				RPFDesignerControl.AVAILABLE_TREE_DATA node_data= (RPFDesignerControl.AVAILABLE_TREE_DATA)(( TreeNode)node).Tag;
			switch( node_data.m_type) {
				case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.SECTION:
					// Create new object
					this.OnAddChildRequest( new RPFFixedSection());
					break;
				case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.TABLE_ROW_SECTION:
					// Create new object
					RPFTableRowSection rpf_child_object= new RPFTableRowSection();
					rpf_child_object.Name= (string)node_data.m_data;
					this.OnAddChildRequest( rpf_child_object);
					break;
				default:
					return;
			}
		}
		protected void OnAddChildRequest( IRPFObject rpf_child_object) {
			if( this.AddChildRequest!= null) {
				RPFDocument rpf_object= ( RPFDocument)this.RPFObject;
				rpf_object.ElementList.Add( rpf_child_object);
				this.AddChildRequest( this, new AddChildRequestEventArgs( rpf_child_object, this));
			}
		}
		protected override void RPFObjectChanged(object sender, EventArgs e) {
			this.DoLayout();
		}
		public void DoLayout() {
			RPFDocument rpf_object= ( RPFDocument)this.m_rpf_object;
			using ( Graphics g= this.CreateGraphics()) {
				// Set dock padding as paper margin
				this.DockPadding.Left= (int)(float)( rpf_object.Margins.Left* g.DpiX);
				this.DockPadding.Top= (int)(float)( rpf_object.Margins.Top* g.DpiY);
				this.DockPadding.Right= (int)(float)( rpf_object.Margins.Right* g.DpiX);
				this.DockPadding.Bottom= (int)(float)( rpf_object.Margins.Bottom* g.DpiY);

				System.Drawing.Printing.PaperSize paper_size= RPFDesignerControl.GetPaperSize( rpf_object.PrinterSettings, ( PaperKind)PaperKind.Parse( typeof( PaperKind), rpf_object.PaperKind, true));
				float height= 0;
				float width= 0;
				// Get the child elements height
				foreach( RPFSection section in rpf_object.ElementList) {
					height+= section.Size.Height;
					if( section.Size.Width> width) {
						width= section.Size.Width;
					}
				}
				width+= rpf_object.Margins.Right+ rpf_object.Margins.Left;
				height+= rpf_object.Margins.Top+ rpf_object.Margins.Bottom;
				
				SizeF paper_size_inc= new SizeF( float.MaxValue, float.MaxValue);
				if( paper_size!= null) {
					if( rpf_object.Landscape){
						paper_size_inc= new SizeF( paper_size.Height* 0.01f, paper_size.Width* 0.01f);
					} else {
						paper_size_inc= new SizeF( paper_size.Width* 0.01f, paper_size.Height* 0.01f);
					}
				} else {
					paper_size_inc= new SizeF( width, height);
				}

				// Check if any section needs to be resized:
				// No single section has to overcome the page size, otherwise it never fits in and infinite loop will occurr !
				for( int i= 0; i< rpf_object.ElementList.Count; i++) { 
					RPFSection section = (RPFSection )rpf_object.ElementList[i];
					if( paper_size_inc.Height> section.Size.Height+ rpf_object.Margins.Top+ rpf_object.Margins.Bottom ) {
						continue;
					}
					section.Size= new Cs_Component.Size( section.Size.Width, paper_size_inc.Height- rpf_object.Margins.Top- rpf_object.Margins.Bottom- 0.001f);
					rpf_object.ElementList[i]= section;
				}

				if( height< paper_size_inc.Height) {
					this.Size= new System.Drawing.Size( (int)(float)( paper_size_inc.Width* g.DpiX), (int)(float)( paper_size_inc.Height* g.DpiY));
				} else {
					this.Size= new System.Drawing.Size( (int)(float)( paper_size_inc.Width* g.DpiX), (int)(float)( height* g.DpiY));
				}
			}			
		}
	}
}

