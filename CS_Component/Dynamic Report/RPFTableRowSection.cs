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
	/// Summary description for RPFTableRowSection.
	/// </summary>
	public class RPFTableRowSection: RPFSection {
		public RPFTableRowSection() {
		}
		#region browsable properties
		#region Appearance
		[DefaultValue( ""), ReadOnly( true)]
		public override string Name {
			get{ return base.Name;}
			set{ base.Name= value;}
		}
		#endregion
		#endregion
		#region IRPFObject Members
		public override bool Render(ReportBuilder builder, PointF offset, Hashtable variables, Hashtable tables) {
			if( this.IsHidden( variables, tables)) {
				return true;
			}
			#region helper objects
			SectionBox sb;
			LayeredSections ll;
			LinearSections ls;
			#endregion

			PointF child_offset= new PointF( -( this.BorderSize.Left+ this.BorderMargin.Left+ this.ExtMargin.Left), -( this.BorderSize.Top+ this.BorderMargin.Top+ this.ExtMargin.Top));
			if( !tables.ContainsKey( this.m_name))
				return false;
			System.Data.DataTable table= ((System.Data.DataTable)tables[ this.m_name]);
			if( table.Rows.Count<= 0)
				return true;

			ls= builder.StartLinearLayout( Cs_Component.Direction.Vertical);				

			// loop rows
			for( int row= 0; row< table.Rows.Count; row++) {

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
				//					sb.WidthPercent= 100;
				//  ... so let's set a fixed width
				if( builder.CurrentDocument.DefaultPageSettings.Landscape) {
					sb.Width= ( builder.CurrentDocument.DefaultPageSettings.PaperSize.Height- builder.CurrentDocument.DefaultPageSettings.Margins.Left- builder.CurrentDocument.DefaultPageSettings.Margins.Right)* 0.01f;
				} else {
					sb.Width= ( builder.CurrentDocument.DefaultPageSettings.PaperSize.Width- builder.CurrentDocument.DefaultPageSettings.Margins.Left- builder.CurrentDocument.DefaultPageSettings.Margins.Right)* 0.01f;
				}
				sb.Height= this.m_vertical_size- this.ExtMargin.Top- this.ExtMargin.Bottom;

				ll= builder.StartLayeredLayout( true, false );
				for( int i= 0; i< this.ElementList.Count; i++) {
					if( this.ElementList[i].GetType()== typeof( RPFTableColumn)) {
						RPFTableColumn column= ( RPFTableColumn)this.ElementList[ i];
						column.RowIndex= row;
					}
					if( !((IRPFObject)this.ElementList[ i]).Render( builder, child_offset, variables, tables))
						return false;
				}
				builder.FinishLayeredLayout();
				builder.FinishBox();

				builder.FinishLayeredLayout();
				builder.FinishBox();
			}

			builder.FinishLinearLayout();
			return true;
		}

		public override object Clone() {
			RPFTableRowSection clone= new RPFTableRowSection();
			return this.DoClone( clone);
		}
		#endregion
	}
}