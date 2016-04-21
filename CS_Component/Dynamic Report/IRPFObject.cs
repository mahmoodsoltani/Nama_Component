using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;


namespace Cs_Component
{
	/// <summary>
	/// Summary description for IRPFObject.
	/// </summary>
	public interface IRPFObject: ICloneable
	{
		bool Render( ReportBuilder builder, PointF offset, Hashtable variables, Hashtable tables);
		void Synch();
		event EventHandler Changed;
		Cs_Component.Location Location {
			get;
			set;
		}
		Cs_Component.Size Size {
			get;
			set;
		}

		object Tag{
			get;
			set;
		}
	}
}
