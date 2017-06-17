// ******************************************************************
//
//	If this code works it was written by:
//		Henry Minute
//		MamSoft / Manniff Computers
//		© 2008 - 2009...
//
//	if not, I have no idea who wrote it.
//
// ******************************************************************

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
