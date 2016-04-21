using System;

namespace Cs_Component
{
	/// <summary>
	/// Summary description for RPFClipboard.
	/// </summary>
	public class RPFClipboard
	{
		static RPFClipboard()
		{
		}

		#region properties
		static private IRPFObject[] m_rpf_objects= new IRPFObject[0];
		static public IRPFObject[] RPFObjects {
			get { 
				if( RPFClipboard.m_rpf_objects== null) {
					return null;
				}
				IRPFObject[] object_array= new IRPFObject[ RPFClipboard.m_rpf_objects.Length];
				for( int i= 0; i< object_array.Length; i++) {
					object_array[ i]= ( IRPFObject)RPFClipboard.m_rpf_objects[ i].Clone();
				}
				return object_array;
			}
			set { 
				if( value== null) {
					RPFClipboard.m_rpf_objects= null;
					return;
				}
				RPFClipboard.m_rpf_objects= new IRPFObject[ value.Length];
				for( int i= 0; i< value.Length; i++) {
					RPFClipboard.m_rpf_objects[ i]= ( IRPFObject)value[ i].Clone();
				}
			}
		}
		#endregion
	}
}
