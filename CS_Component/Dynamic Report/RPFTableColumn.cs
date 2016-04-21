using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using GlobalizedPropertyGrid;
using System.Xml.Serialization;
using System.IO;


namespace Cs_Component {
	/// <summary>
	/// Summary description for RPFTableColumn.
	/// </summary>
	[TypeConverter(typeof(ExpandableObjectConverter)), DefaultProperty( "Name")]
	public class RPFTableColumn: RPFBaseLabel {
		public RPFTableColumn() {
		}
		#region non browsable properties
		protected object m_value= null;
		protected int m_row_index= 0;
		[Browsable(false), XmlIgnore()]
		public int RowIndex {
			get{ return this.m_row_index;}
			set{ this.m_row_index= value;}
		}
		#endregion
		#region browsable properties
		#region Appearance
		protected string m_name= "";
		[ReadOnly(true)]
		public string Name {
			get{ return this.m_name;}
			set{ 
				this.m_name= value;
				this.OnChanged();
			}
		}
		protected string m_table_id= "";
		[ReadOnly( true)]
		public string TableId {
			get{ return this.m_table_id;}
			set{ this.m_table_id= value;}
		}
		#endregion
		#endregion
		[Browsable(false), XmlIgnore]
		protected override string Value {
			get {
				if( this.m_value== null)
					return "";
				return this.m_value.ToString();
			}
		}
		[Browsable(false), XmlIgnore]
		public override string Text {
			get {
				return this.Name;
			}
		}

		public override string ToString() {
			return this.Name;
		}
		public override bool Render(Cs_Component.ReportBuilder builder, PointF offset, System.Collections.Hashtable variables, Hashtable tables) {
			this.m_value= null;
			if( tables.ContainsKey( this.m_table_id))
				this.m_value= ((System.Data.DataTable)tables[ this.m_table_id]).Rows[ this.m_row_index][ this.Name];
			return base.Render (builder, offset, variables, tables);
		}
		public override object Clone() {
			RPFTableColumn clone= new RPFTableColumn();
			clone.BackColor= this.BackColor;
			clone.BorderColor= this.BorderColor;
			clone.BorderMargin= new Padding( this.BorderMargin.Left, this.BorderMargin.Top, this.BorderMargin.Right, this.BorderMargin.Bottom);
			clone.BorderPadding= new Padding( this.BorderPadding.Left, this.BorderPadding.Top, this.BorderPadding.Right, this.BorderPadding.Bottom);
			clone.BorderSize= new Padding( this.BorderSize.Left, this.BorderSize.Top, this.BorderSize.Right, this.BorderSize.Bottom);
			clone.Font= (Font)this.Font.Clone();
			clone.ForeColor= this.ForeColor;
			clone.Location= new Location( this.Location.X, this.Location.Y);
			clone.Name= this.Name;
			clone.RowIndex= this.RowIndex;
			clone.Size= new Size( this.Size.Width, this.Size.Height);
			clone.Tag= null;
			clone.TableId= this.TableId;
			clone.TextAlignment= this.TextAlignment;
			clone.HideOnVariable= new HideOnVariable( this.HideOnVariable.Name, this.HideOnVariable.Value);
			clone.HideOnValue= new HideOnValue( this.HideOnValue.Enabled, this.HideOnValue.Value);
			return clone;
		}
	}
}
