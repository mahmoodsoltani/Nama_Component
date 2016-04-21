using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cs_Component {
	public class RPFTableRowSectionTrackerControl : Cs_Component.RPFSectionTrackerControl {
		private System.ComponentModel.IContainer components = null;

		public RPFTableRowSectionTrackerControl() {
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		public RPFTableRowSectionTrackerControl( RPFTableRowSection rpf_object): base( rpf_object){
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
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.TABLE_COLUMN:
						RPFTableColumn column= ( RPFTableColumn)node_data.m_data;
						if( column.TableId!= ((RPFTableRowSection)this.RPFObject).Name) {
							break;
						}
						drgevent.Effect= DragDropEffects.Move;
						this.Selected= true;
						break;
				}
			} catch {
				drgevent.Effect= DragDropEffects.None;
			}
		}
		protected override void OnDragDrop(DragEventArgs drgevent) {
			base.OnDragDrop (drgevent);

			object node= drgevent.Data.GetData( "System.Windows.Forms.TreeNode");
			if( node== null) {
				return;
			}
			try {
				RPFDesignerControl.AVAILABLE_TREE_DATA node_data= (RPFDesignerControl.AVAILABLE_TREE_DATA)(( TreeNode)node).Tag;
				Point client_pos= this.PointToClient( new Point( drgevent.X, drgevent.Y));
				// Create new object here
				switch( node_data.m_type) {
					case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.TABLE_COLUMN:
						RPFTableColumn rpf_column= new RPFTableColumn();
						RPFTableColumn column= ( RPFTableColumn)node_data.m_data;
						rpf_column.Name= column.Name;
						rpf_column.TableId= column.TableId;
						using ( Graphics g = this.CreateGraphics()) {
							rpf_column.Location= new Location( (float)client_pos.X/ g.DpiX, (float)client_pos.Y/ g.DpiY);
						}
						this.OnAddChildRequest( rpf_column);
						break;
					default:
						return;
				}
			} catch {
			}
		}
	}
}
