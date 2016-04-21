using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Cs_Component
{
	/// <summary>
	/// Summary description for DrawingCanvas.
	/// </summary>
	internal class DrawingCanvas: Panel
	{
		private bool m_is_selecting= false;
		private Point m_start_selection= new Point( 0);
		private System.Drawing.Rectangle m_last_selection_rectangle= new System.Drawing.Rectangle( 0, 0, 0, 0 );
		public DrawingCanvas()
		{
			// Avoid flickering
			this.SetStyle( ControlStyles.ContainerControl| ControlStyles.UserPaint| ControlStyles.AllPaintingInWmPaint| ControlStyles.DoubleBuffer, true);
			this.UpdateStyles();
		}

		#region events
		public event EventHandler SelectedObjectsChanged;
		#endregion
		#region properties
		private IRPFObject[] m_selected_objects= null;
		public IRPFObject[] SelectedObjects {
			get { return this.m_selected_objects;}
			set { 
				if( value== null)
					return;
				try {
					this.m_is_selecting= true;
					foreach( IRPFObject rpf_object in value) {
						RPFDesignerControl.RPFObjectTag tag_obj= ( RPFDesignerControl.RPFObjectTag)rpf_object.Tag;
						tag_obj.m_host_control.Selected= true;
					}
				}
				finally {
					this.m_is_selecting= false;
				}
			}
		}

		#endregion
		public void RemoveSelection(Control sender ) {
			if( this.m_is_selecting)
				return;
			try {
				// Deselect other
				this.m_skip_selection_change= true;
				this.DoRemoveSelection( this, sender);
			} catch ( Exception excp) {
				Helper.ShowException( excp);
			} finally {
				this.m_skip_selection_change= false;
			}


		}
		private bool m_skip_selection_change= false;
		private void DoRemoveSelection( Control container, Control sender) {
			foreach( RPFTrackerBaseControl ctrl in container.Controls) {
				this.DoRemoveSelection( ctrl, sender);
				if( ctrl== sender)
					continue;
				ctrl.Selected= false;
			}
		}
		private void ContainerMouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
			Control container= (Control)sender;
			if(( Control.ModifierKeys& Keys.Shift)== 0) {
				this.RemoveSelection( container);
			}
			this.m_is_selecting= true;
			this.m_start_selection= container.PointToScreen( new Point( e.X, e.Y));
			this.m_last_selection_rectangle= new System.Drawing.Rectangle( this.m_start_selection, new System.Drawing.Size( ));
		}

		private void ContainerMouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
			Control container= (Control)sender;
			if( this.m_is_selecting) {
				// remove last rectangle
				ControlPaint.DrawReversibleFrame( this.m_last_selection_rectangle, Color.DarkBlue, FrameStyle.Dashed);
				Point act_pos= container.PointToScreen( new Point( e.X, e.Y));
				this.m_last_selection_rectangle= new System.Drawing.Rectangle( this.m_start_selection, new System.Drawing.Size( act_pos.X- this.m_start_selection.X, act_pos.Y- this.m_start_selection.Y));
				// draw new rectangle
				ControlPaint.DrawReversibleFrame( this.m_last_selection_rectangle, Color.DarkBlue, FrameStyle.Dashed);
			}
		}

		private void ContainerMouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
			Control container= (Control)sender;
			// remove last rectangle
			ControlPaint.DrawReversibleFrame( this.m_last_selection_rectangle, Color.DarkBlue, FrameStyle.Dashed);
			// Select touched controls
			// Normalize selection rectangle
			if( this.m_last_selection_rectangle.Width< 0) {
				this.m_last_selection_rectangle.X+= this.m_last_selection_rectangle.Width;
				this.m_last_selection_rectangle.Width= -this.m_last_selection_rectangle.Width;
			}
			if( this.m_last_selection_rectangle.Height< 0) {
				this.m_last_selection_rectangle.Y+= this.m_last_selection_rectangle.Height;
				this.m_last_selection_rectangle.Height= -this.m_last_selection_rectangle.Height;
			}
			this.DoMouseUp( container);
			this.m_is_selecting= false;
		}
		private void DoMouseUp( Control container) {
			Rectangle selection_rect= container.RectangleToClient( this.m_last_selection_rectangle);
			foreach( RPFTrackerBaseControl ctrl in container.Controls) {
				if( selection_rect.IntersectsWith( new Rectangle( ctrl.Location, ctrl.Size))) {
					ctrl.Selected= true;
				}
			}
		}

		private void Tracking(object sender, Cs_Component.TrackerBaseControl.TrackingEventArgs e) {
			this.DoTrackControls( (TrackerBaseControl)sender, e.m_delta_X, e.m_delta_Y, e.m_mode);
			if( e.m_mode== TrackerBaseControl.TRACKER_MODE.NONE)
				this.OnSelectedObjectsChanged();
		}
		private void DoTrackControls( TrackerBaseControl sender, int delta_X, int delta_Y, TrackerBaseControl.TRACKER_MODE mode) {
			foreach( RPFTrackerBaseControl ctrl in sender.Parent.Controls) {
				if( ctrl== sender)
					continue;
				ctrl.Track( delta_X, delta_Y, mode);
			}
		}

		private void SelectionChanged(object sender, System.EventArgs e) {
			if( this.m_skip_selection_change) 
				return;
			try {
				RPFTrackerBaseControl tc= ( RPFTrackerBaseControl)sender;
				if(( Control.ModifierKeys& Keys.Shift)== 0) {
					this.RemoveSelection( tc);
				}
				IRPFObject[] selection_array;
				ArrayList selection_list= new ArrayList();
				foreach( RPFTrackerBaseControl ctrl in tc.Parent.Controls) {
					if( ctrl.Selected) {
						selection_list.Add( ctrl.RPFObject);
					}
				}
				selection_array= new IRPFObject[ selection_list.Count];
				selection_list.CopyTo( selection_array);
				this.m_selected_objects= selection_array;
				this.OnSelectedObjectsChanged();
			} catch ( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		protected void OnSelectedObjectsChanged() {
			if( SelectedObjectsChanged != null) {
				this.SelectedObjectsChanged( this, new EventArgs());
			}
		}
		public void AddChild( RPFTrackerBaseControl ctrl) {
			ctrl.MouseDown+=new MouseEventHandler(ContainerMouseDown);
			ctrl.MouseMove+=new MouseEventHandler(ContainerMouseMove);
			ctrl.MouseUp+=new MouseEventHandler(ContainerMouseUp);
			ctrl.SelectedChanged+=new Cs_Component.TrackerBaseControl.SelectedChangedEventHandler(SelectionChanged);
			ctrl.Tracking+=new Cs_Component.TrackerBaseControl.TrackingEventHandler(Tracking);
			if( ctrl is ITrackerControlContainer) {
				((ITrackerControlContainer ) ctrl).ChildMouseDown+=new MouseEventHandler(ContainerMouseDown);
				((ITrackerControlContainer ) ctrl).ChildMouseMove+=new MouseEventHandler(ContainerMouseMove);
				((ITrackerControlContainer ) ctrl).ChildMouseUp+=new MouseEventHandler(ContainerMouseUp);
				((ITrackerControlContainer ) ctrl).ChildSelectedChanged+=new Cs_Component.TrackerBaseControl.SelectedChangedEventHandler(SelectionChanged);
				((ITrackerControlContainer ) ctrl).ChildTracking+=new Cs_Component.TrackerBaseControl.TrackingEventHandler(Tracking);
			}
			ctrl.SizeChanged+=new EventHandler(ChildSizeChanged);
			this.Controls.Add( ctrl);
			if( ctrl.RPFObject!= null)
				ctrl.RPFObject.Synch();
		}

		private void ChildSizeChanged(object sender, EventArgs e) {
			this.Size= ((Control)sender).Size;
		}
	}
}
