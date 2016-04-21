using System;
using System.Runtime.Serialization;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using GlobalizedPropertyGrid;
using System.Xml.Serialization;
using System.IO;


namespace Cs_Component {
	/// <summary>
	/// Summary description for RPFFixedSection.
	/// </summary>
	public class RPFFixedSection: RPFSection {
		public RPFFixedSection() {
		}
		#region non browsable properties
		#endregion
		#region browsable properties
		#endregion
		#region XMLSerialization 
		public bool XMLSerialize( string filename) {
			TextWriter writer= null;
			try {
				writer = new StreamWriter( filename);
				// TODO : add other type of object to serialize here
				XmlSerializer serializer = new XmlSerializer(typeof( RPFFixedSection), Helper.XmlTypes );
				serializer.Serialize( writer, this);
			}
			catch( Exception excp) {
				throw excp;
			}
			finally {
				if( writer!= null)
					writer.Close();
			}
			return true;
		}
		public static bool XMLDeserialize( string filename, ref RPFSection obj) {
			TextReader reader= null;
			try {
				if( !System.IO.File.Exists( filename))
					return true;
				reader= new StreamReader( filename);
				XmlSerializer deserializer = new XmlSerializer(typeof( RPFFixedSection), Helper.XmlTypes);
				obj= ( RPFSection)deserializer.Deserialize( reader);
			}
			catch( Exception excp) {
				throw excp;
			}
			finally {
				if( reader!= null)
					reader.Close();
			}
			return true;
		}
		#endregion

		#region IRPFObject Members
		public override bool Render(Cs_Component.ReportBuilder builder, PointF offset, Hashtable variables, Hashtable tables) {
			if( this.IsHidden( variables, tables)) {
				return true;
			}
			#region helper objects
			SectionBox sb;
			LayeredSections ll;
			#endregion

			sb= builder.StartBox( );

			sb.MarginBottom= this.ExtMargin.Bottom;
			sb.MarginLeft= this.ExtMargin.Left;
			sb.MarginRight= this.ExtMargin.Right;
			sb.MarginTop= this.ExtMargin.Top;

			// Background
			sb.Background= new SolidBrush( this.BackColor);

			// Size
			// Setting sb.WidthPercent= 100 seems to be buggy when Left Margin is setted ...
			//			sb.WidthPercent= 100;
			//  ... so let's set a fixed width
			if( builder.CurrentDocument.DefaultPageSettings.Landscape) {
				sb.Width= ( builder.CurrentDocument.DefaultPageSettings.PaperSize.Height- builder.CurrentDocument.DefaultPageSettings.Margins.Left- builder.CurrentDocument.DefaultPageSettings.Margins.Right)* 0.01f;
			} else {
				sb.Width= ( builder.CurrentDocument.DefaultPageSettings.PaperSize.Width- builder.CurrentDocument.DefaultPageSettings.Margins.Left- builder.CurrentDocument.DefaultPageSettings.Margins.Right)* 0.01f;
			}
			sb.Height= this.m_vertical_size;

			ll= builder.StartLayeredLayout( false, false);
			// Inner Box
			sb= builder.StartBox( );

			// Border
			sb.BorderBottom= new Pen( this.BorderColor, this.BorderSize.Bottom);
			sb.BorderLeft= new Pen( this.BorderColor, this.BorderSize.Left);
			sb.BorderRight= new Pen( this.BorderColor, this.BorderSize.Right);
			sb.BorderTop= new Pen( this.BorderColor, this.BorderSize.Top);
			
			sb.MarginBottom= this.BorderMargin.Bottom;
			sb.MarginLeft= this.BorderMargin.Left;
			sb.MarginRight= this.BorderMargin.Right;
			sb.MarginTop= this.BorderMargin.Top;

			// Size
			// Setting sb.WidthPercent= 100 seems to be buggy when Left Margin is setted ...
//			sb.WidthPercent= 100;
			//  ... so let's set a fixed width
			if( builder.CurrentDocument.DefaultPageSettings.Landscape) {
				sb.Width= ( builder.CurrentDocument.DefaultPageSettings.PaperSize.Height- builder.CurrentDocument.DefaultPageSettings.Margins.Left- builder.CurrentDocument.DefaultPageSettings.Margins.Right)* 0.01f;
			} else {
				sb.Width= ( builder.CurrentDocument.DefaultPageSettings.PaperSize.Width- builder.CurrentDocument.DefaultPageSettings.Margins.Left- builder.CurrentDocument.DefaultPageSettings.Margins.Right)* 0.01f;
			}
			sb.Height= this.m_vertical_size- this.ExtMargin.Top- this.ExtMargin.Bottom;
			
			PointF child_offset= new PointF( -( this.BorderSize.Left+ this.BorderMargin.Left+ this.ExtMargin.Left), -( this.BorderSize.Top+ this.BorderMargin.Top+ this.ExtMargin.Top));

			ll= builder.StartLayeredLayout( true, false );
			// Loop elements
			foreach( IRPFObject rpf_object in this.ElementList) {
				if( !rpf_object.Render( builder, child_offset, variables, tables))
					return false;
			}
			
			builder.FinishLayeredLayout();
			// Inner Box
			builder.FinishBox();
			builder.FinishLayeredLayout();

			builder.FinishBox();

			return true;
		}
		public override object Clone() {
			RPFFixedSection clone= new RPFFixedSection();
			return this.DoClone( clone);
		}
		#endregion
	}
}
