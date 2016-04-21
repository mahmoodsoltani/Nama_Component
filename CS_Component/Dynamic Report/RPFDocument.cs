using System;
using System.Runtime.Serialization;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using GlobalizedPropertyGrid;
using System.Xml.Serialization;
using System.IO;


namespace Cs_Component
{
	/// <summary>
	/// Summary description for RPFDocument.
	/// </summary>
	public class RPFDocument: GlobalizedObject, IRPFObject
	{
		public RPFDocument()
		{
			this.Margins= new Padding( 1, 1, 1, 1);
			this.PaperKind= "A4";
		}
		#region non browsable properties
		private System.Drawing.Printing.PrinterSettings m_printer_settings= new System.Drawing.Printing.PrinterSettings();
		[Browsable( false), XmlIgnore()]
		public System.Drawing.Printing.PrinterSettings PrinterSettings {
			get { return this.m_printer_settings;}
		}
		[Browsable( false), XmlIgnore()]
		public Cs_Component.Location Location {
			get{ return new Cs_Component.Location();}
			set{ }
		}
		[Browsable( false), XmlIgnore()]
		public Cs_Component.Size Size{
			get{ return new Cs_Component.Size();}
			set{ }
		}
		protected ArrayList m_element_list= new ArrayList();
		[Browsable( false)]
		public ArrayList ElementList
		{
			get{ return this.m_element_list;}
			set{ this.m_element_list= value;}
		}
		#endregion
		#region browsable properties
		#region Page Settings
		protected string m_paper_kind;
		[TypeConverter( typeof( PaperKindConverter)), DefaultValue( "A4")]
		public string PaperKind {	
			get{ return this.m_paper_kind;}
			set{ 
				this.m_paper_kind= value;
				this.OnChanged();
			}
		}

		protected Padding m_margins;
		[DefaultValue( typeof( Padding), "1,1,1,1")]
		public Padding Margins {	
			get{ return this.m_margins;}
			set{ 
				this.m_margins= value;
				this.m_margins.Changed+=new EventHandler(this.PropertyChanged);
				this.OnChanged();
			}
		}
		protected bool m_landscape= false;
		[DefaultValue( false)]
		public bool Landscape {	
			get{ return this.m_landscape;}
			set{ 
				this.m_landscape= value;
				this.OnChanged();
			}
		}
		#endregion
		#region Printer
		protected string m_printer;
		[TypeConverter( typeof( InstalledPrinterConverter)), DefaultValue( "")]
		public string Printer{	
			get{ return this.m_printer;}
			set{
				this.m_printer = value.Trim();
				if (!string.IsNullOrEmpty(value.Trim())) {
					this.m_printer_settings.PrinterName = value;
				} else {
					this.m_printer_settings.PrinterName = null;
				}
				this.OnChanged();
			}
		}
		#endregion
		#endregion
		#region XMLSerialization 
		public bool XMLSerialize( string filename)
		{
			TextWriter writer= null;
			try
			{
				writer = new StreamWriter( filename);
				XmlSerializer serializer = new XmlSerializer(typeof( RPFDocument), Helper.XmlTypes );
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
		public static bool XMLDeserialize( string filename, ref RPFDocument obj)
		{
			TextReader reader= null;
			try
			{
				if( !System.IO.File.Exists( filename))
					return true;
				reader= new StreamReader( filename);
				XmlSerializer deserializer = new XmlSerializer(typeof( RPFDocument), Helper.XmlTypes);
				obj= ( RPFDocument)deserializer.Deserialize( reader);
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

		#region IRPFObject Members
		public object Clone() {
			RPFDocument clone= new RPFDocument();
			clone.Location= new Location( this.Location.X, this.Location.Y);
			clone.Size= new Size( this.Size.Width, this.Size.Height);
			clone.Tag= null;
			clone.ElementList= new ArrayList( this.ElementList.Count);
			foreach( IRPFObject rpf_object in this.ElementList) {
				clone.ElementList.Add( rpf_object.Clone());
			}
			return clone;
		}
		public void Synch() {
			this.OnChanged();
		}

		public bool Render(Cs_Component.ReportBuilder builder, PointF offset, Hashtable variables, Hashtable tables)
		{
			#region helper objects
			LinearSections ls;
			#endregion

			ls= builder.StartLinearLayout( Direction.Vertical);
			ls.UseFullWidth= true;
			ls.UseFullHeight= true;
			
			// Loop elements
			foreach( IRPFObject rpf_object in this.ElementList)
			{
				if( !rpf_object.Render( builder, new PointF( 0, 0), variables, tables))
					return false;
			}

			builder.FinishLinearLayout();
			return true;
		}
		public event EventHandler Changed;
		protected object m_tag;
		[Browsable( false), XmlIgnore()]
		public object Tag {
			get{ return this.m_tag;}
			set{ this.m_tag= value;}
		}
		#endregion

		protected void OnChanged() {
			if( Changed != null) {
				this.Changed( this, new EventArgs());
			}
		}
		private void PropertyChanged(object sender, EventArgs e) {
			this.OnChanged();
		}
	}
}
