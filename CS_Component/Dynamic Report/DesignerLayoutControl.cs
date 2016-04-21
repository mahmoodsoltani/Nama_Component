using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cs_Component {
	/// <summary>
	/// Summary description for DesignerLayoutControl.
	/// </summary>
	internal class DesignerLayoutControl : System.Windows.Forms.Panel {
		public DesignerLayoutControl() {
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
			}
			base.Dispose( disposing );
		}
		protected override void OnLayout(LayoutEventArgs levent) {
			base.OnLayout (levent);
			AdjustFormScrollbars( true);
		}
	}
}
