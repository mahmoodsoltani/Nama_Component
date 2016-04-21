using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cs_Component
{
	/// <summary>
	/// Summary description for ITrackerControlContainer.
	/// </summary>
	public interface ITrackerControlContainer
	{
		Rectangle TrackBounds {
			get ;
		}
		void AddChild( RPFTrackerBaseControl ctrl);
		void RemoveChild( RPFTrackerBaseControl ctrl);
		event MouseEventHandler ChildMouseMove;
		event MouseEventHandler ChildMouseDown;
		event MouseEventHandler ChildMouseUp;
		event Cs_Component.TrackerBaseControl.SelectedChangedEventHandler ChildSelectedChanged;
		event Cs_Component.TrackerBaseControl.TrackingEventHandler ChildTracking;
		event Cs_Component.AddChildRequestEventHandler AddChildRequest;
	}
	public delegate void AddChildRequestEventHandler(object sender, AddChildRequestEventArgs e);
	public class AddChildRequestEventArgs: EventArgs{
		public AddChildRequestEventArgs( IRPFObject rpf_object, ITrackerControlContainer host_ctrl) {
			this.m_rpf_object= rpf_object;
			this.m_host_ctrl= host_ctrl;
		}
		public IRPFObject m_rpf_object;
		public ITrackerControlContainer m_host_ctrl;
	}
}
