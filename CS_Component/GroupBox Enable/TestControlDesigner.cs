using System.Windows.Forms.Design;

namespace CS_Component
{
    public class TestControlDesigner : ParentControlDesigner
	{
		public override void Initialize(System.ComponentModel.IComponent component)
		{
			base.Initialize(component);

            if (this.Control is GroupBoxEnable)
			{
                this.EnableDesignMode(((GroupBoxEnable)this.Control).WorkingArea, "WorkingArea");
			}
		}

		public override bool CanParent(System.Windows.Forms.Control control)
		{
			return control is System.Windows.Forms.Control;
		}

		public override bool CanParent(System.Windows.Forms.Design.ControlDesigner controlDesigner)
		{
			if (controlDesigner != null && controlDesigner.Control is System.Windows.Forms.Control)
			{
				return true;
			}
			return false;
		}

	}
}
