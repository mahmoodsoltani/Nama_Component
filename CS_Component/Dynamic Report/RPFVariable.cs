using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using GlobalizedPropertyGrid;
using System.Xml.Serialization;

namespace Cs_Component
{
	/// <summary>
	/// Summary description for RPFVariable.
	/// </summary>
	public class RPFVariable: RPFBaseLabel
	{
		public RPFVariable()
		{
		}
		#region non browsable properties
		protected object m_value= null;
		#endregion
		#region browsable properties
		#region Appearance
		protected string m_name= "";
		[ReadOnly(true)]
		public string Name
		{
			get{ return this.m_name;}
			set{ 
				this.m_name= value;
				this.OnChanged();
			}
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
		public override string Text
		{
			get
			{
				return this.Name;
			}
		}
		public override bool Render(Cs_Component.ReportBuilder builder, PointF offset, Hashtable variables, Hashtable tables)
		{
			this.m_value= variables[ this.m_name];
			return base.Render (builder, offset, variables, tables);
		}
		public override object Clone() {
			RPFVariable clone= new RPFVariable();
			clone.BackColor= this.BackColor;
			clone.BorderColor= this.BorderColor;
			clone.BorderMargin= new Padding( this.BorderMargin.Left, this.BorderMargin.Top, this.BorderMargin.Right, this.BorderMargin.Bottom);
			clone.BorderPadding= new Padding( this.BorderPadding.Left, this.BorderPadding.Top, this.BorderPadding.Right, this.BorderPadding.Bottom);
			clone.BorderSize= new Padding( this.BorderSize.Left, this.BorderSize.Top, this.BorderSize.Right, this.BorderSize.Bottom);
			clone.Font= (Font)this.Font.Clone();
			clone.ForeColor= this.ForeColor;
			clone.Name= this.Name;
			clone.Location= new Location( this.Location.X, this.Location.Y);
			clone.Name= this.Name;
			clone.Size= new Size( this.Size.Width, this.Size.Height);
			clone.Tag= null;
			clone.TextAlignment= this.TextAlignment;
			clone.HideOnVariable= new HideOnVariable( this.HideOnVariable.Name, this.HideOnVariable.Value);
			clone.HideOnValue= new HideOnValue( this.HideOnValue.Enabled, this.HideOnValue.Value);
			return clone;
		}
	}
}
