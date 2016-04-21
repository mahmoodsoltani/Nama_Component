using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CS_Component
{
	[Designer(typeof(CS_Component.WorkingAreaDesigner))]
	public partial class WorkingAreaControl : GroupBox
	{
		public WorkingAreaControl()
		{
			InitializeComponent();
		}
	}
}
