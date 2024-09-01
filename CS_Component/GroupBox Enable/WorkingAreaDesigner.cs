using System.Windows.Forms.Design;

namespace CS_Component
{
    public class WorkingAreaDesigner : ScrollableControlDesigner
	{
		protected override void PreFilterProperties(System.Collections.IDictionary properties)
		{
			properties.Remove("Dock");

			base.PreFilterProperties(properties);
		}
	}
}
