using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cs_Component {
	public class RPFVariableTrackerControl : Cs_Component.RPFBaseLabelTrackerControl {
		private System.ComponentModel.IContainer components = null;

		public RPFVariableTrackerControl() {
			// This call is required by the Windows Form Designer.
			InitializeComponent();

		}
		public RPFVariableTrackerControl( RPFVariable rpf_object): base( rpf_object){
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
		#region public methods
		#endregion
	}
}

