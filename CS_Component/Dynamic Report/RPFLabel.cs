using System;
using System.ComponentModel;
using System.Drawing;
using GlobalizedPropertyGrid;
using System.Xml.Serialization;
using System.IO;

namespace Cs_Component
{
	/// <summary>
	/// Summary description for RPFLabel.
	/// </summary>
	public class RPFLabel: RPFBaseLabel
	{
		public RPFLabel()
		{
		}
		#region browsable properties
		#region Appearance
		protected string m_label_text= "";
		[DefaultValue( "")]
		public string LabelText
		{
			get{ return this.m_label_text;}
			set{ 
				if( this.m_label_text.Equals( value))
					return;
				this.m_label_text= value;
				this.OnChanged();
			}
		}
		#endregion
		#endregion
		#region XMLSerialization 
		public new bool XMLSerialize( string filename)
		{
			TextWriter writer= null;
			try
			{
				writer = new StreamWriter( filename);
				XmlSerializer serializer = new XmlSerializer(typeof( RPFLabel));
				serializer.Serialize( writer, this);
			}
			catch( Exception excp)
			{
				throw excp;
			}
			finally
			{
				if( writer!= null)
					writer.Close();
			}
			return true;
		}
		public static bool XMLDeserialize( string filename, ref RPFLabel obj)
		{
			TextReader reader= null;
			try
			{
				if( !System.IO.File.Exists( filename))
					return true;
				reader= new StreamReader( filename);
				XmlSerializer deserializer = new XmlSerializer(typeof( RPFLabel));
				obj= ( RPFLabel)deserializer.Deserialize( reader);
			}
			catch( Exception excp)
			{
				throw excp;
			}
			finally
			{
				if( reader!= null)
					reader.Close();
			}
			return true;
		}
		#endregion
		[Browsable(false), XmlIgnore]
		public override string Text
		{
			get
			{
				return this.LabelText;
			}
		}
		public override object Clone() {
			RPFLabel clone= new RPFLabel();
			clone.BackColor= this.BackColor;
			clone.BorderColor= this.BorderColor;
			clone.BorderMargin= new Padding( this.BorderMargin.Left, this.BorderMargin.Top, this.BorderMargin.Right, this.BorderMargin.Bottom);
			clone.BorderPadding= new Padding( this.BorderPadding.Left, this.BorderPadding.Top, this.BorderPadding.Right, this.BorderPadding.Bottom);
			clone.BorderSize= new Padding( this.BorderSize.Left, this.BorderSize.Top, this.BorderSize.Right, this.BorderSize.Bottom);
			clone.Font= (Font)this.Font.Clone();
			clone.ForeColor= this.ForeColor;
			clone.LabelText= this.LabelText;
			clone.Location= new Location( this.Location.X, this.Location.Y);
			clone.Size= new Size( this.Size.Width, this.Size.Height);
			clone.Tag= null;
			clone.TextAlignment= this.TextAlignment;
			clone.HideOnVariable= new HideOnVariable( this.HideOnVariable.Name, this.HideOnVariable.Value);
			clone.HideOnValue= new HideOnValue( this.HideOnValue.Enabled, this.HideOnValue.Value);
			return clone;
		}
	}
}
