using System;
using System.Runtime.Serialization;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;
using GlobalizedPropertyGrid;


namespace Cs_Component {
	/// <summary>
	/// Summary description for RPFSection.
	/// </summary>
	public abstract class RPFSection: GlobalizedObject, IRPFObject {
		public RPFSection() {
			this.BorderSize= new Padding( 0, 0, 0, 0);
			this.BorderMargin= new Padding( 0, 0, 0, 0);
			this.ExtMargin= new Padding( 0, 0, 0, 0);
		}

		#region non browsable properties
		[ XmlElement( "BorderColor"), Browsable( false)]
		public string XMLBorderColor {
			get {
				return this.m_border_color.Name;
			}
			set {
				this.m_border_color= Helper.ColorFromString( value);
			}
		}

		[Browsable( false), XmlIgnore()]
		public Cs_Component.Location Location {
			get{ return new Cs_Component.Location();}
			set{ }
		}
		[Browsable( false), XmlIgnore()]
		public Cs_Component.Size Size{
			get{ 
				Cs_Component.Size size= new Cs_Component.Size( 0, this.VerticalSize);
				size.Changed+=new EventHandler(size_Changed);
				return size;
			}
			set{ 
				this.VerticalSize= value.Height;
				this.OnChanged();
			}
		}
		[ XmlElement( "BackColor"), Browsable( false)]
		public string XMLBackColor {
			get {
				return this.m_back_color.Name;
			}
			set {
				this.m_back_color= Helper.ColorFromString( value);
			}
		}

		protected ArrayList m_element_list= new ArrayList();
		[Browsable( false)]
		public ArrayList ElementList {
			get{ return this.m_element_list;}
			set{ this.m_element_list= value;}
		}
		#endregion
		#region browsable properties
		#region Appearance
		protected string m_name= "";
		[DefaultValue( "")]
		public virtual string Name {
			get{ return this.m_name;}
			set{ 
				this.m_name= value;
				this.OnChanged();
			}
		}
		protected Color m_back_color= Color.Transparent;
		[DefaultValue( typeof( Color), "Transparent"), XmlIgnore()]
		public Color BackColor {
			get{ return this.m_back_color;}
			set{
				this.m_back_color= value;
				this.OnChanged();
			}
		}
		protected HideOnVariable m_hide_on_variable= new HideOnVariable();
		[DefaultValue( typeof( HideOnVariable), "")]
		public HideOnVariable HideOnVariable {
			get{ return this.m_hide_on_variable;}
			set{
				this.m_hide_on_variable= value;
				this.OnChanged();
			}
		}
		#endregion
		#region Layout
		protected float m_vertical_size= 1;
		[DefaultValue( 1)]
		public float VerticalSize {
			get{ return this.m_vertical_size;}
			set{ 
				this.m_vertical_size= value;
				this.OnChanged();
			}
		}
		protected Padding m_ext_margin;
		[DefaultValue( typeof( Padding), "0, 0, 0, 0")]
		public Padding ExtMargin {
			get{ return this.m_ext_margin;}
			set{ 
				this.m_ext_margin= value;
				this.m_ext_margin.Changed+=new EventHandler(PropertyChanged);
				this.OnChanged();
			}
		}
		#endregion
		#region Border
		protected Padding m_border_margin;
		[DefaultValue( typeof( Padding), "0, 0, 0, 0")]
		public Padding BorderMargin {
			get{ return this.m_border_margin;}
			set{ 
				this.m_border_margin= value;
				this.m_border_margin.Changed+=new EventHandler(PropertyChanged);
				this.OnChanged();
			}
		}
		protected Padding m_border_size;
		[DefaultValue( typeof( Padding), "0, 0, 0, 0")]
		public Padding BorderSize {
			get{ return this.m_border_size;}
			set{ 
				this.m_border_size= value;
				this.m_border_size.Changed+=new EventHandler(PropertyChanged);
				this.OnChanged();
			}
		}
		protected Color m_border_color= Color.Black;
		[DefaultValue( typeof( Color), "Black"), XmlIgnore()]
		public Color BorderColor {
			get{ return this.m_border_color;}
			set{ 
				this.m_border_color= value;
				this.OnChanged();
			}
		}
		#endregion
		#endregion
		#region XMLSerialization 
//		public bool XMLSerialize( string filename) {
//			TextWriter writer= null;
//			try {
//				writer = new StreamWriter( filename);
//				// TODO : add other type of object to serialize here
//				XmlSerializer serializer = new XmlSerializer(typeof( RPFSection), Helper.XmlTypes );
//				serializer.Serialize( writer, this);
//			}
//			catch( Exception excp) {
//				throw excp;
//			}
//			finally {
//				if( writer!= null)
//					writer.Close();
//			}
//			return true;
//		}
//		public static bool XMLDeserialize( string filename, ref RPFSection obj) {
//			TextReader reader= null;
//			try {
//				if( !System.IO.File.Exists( filename))
//					return true;
//				reader= new StreamReader( filename);
//				XmlSerializer deserializer = new XmlSerializer(typeof( RPFSection), Helper.XmlTypes);
//				obj= ( RPFSection)deserializer.Deserialize( reader);
//			}
//			catch( Exception excp) {
//				throw excp;
//			}
//			finally {
//				if( reader!= null)
//					reader.Close();
//			}
//			return true;
//		}
		#endregion

		#region IRPFObject Members
		public virtual object Clone() {
			return null;
		}
		public virtual RPFSection DoClone( RPFSection clone) {
			clone.BackColor= this.BackColor;
			clone.ExtMargin= new Padding( this.ExtMargin.Left, this.ExtMargin.Top, this.ExtMargin.Right, this.ExtMargin.Bottom);
			clone.BorderColor= this.BorderColor;
			clone.BorderMargin= new Padding( this.BorderMargin.Left, this.BorderMargin.Top, this.BorderMargin.Right, this.BorderMargin.Bottom);
			clone.BorderSize= new Padding( this.BorderSize.Left, this.BorderSize.Top, this.BorderSize.Right, this.BorderSize.Bottom);
			clone.Location= new Location( this.Location.X, this.Location.Y);
			clone.Name= this.Name;
			clone.Size= new Size( this.Size.Width, this.Size.Height);
			clone.Tag= null;
			clone.VerticalSize= this.VerticalSize;
			clone.ElementList= new ArrayList( this.ElementList.Count);
			clone.HideOnVariable= new HideOnVariable( this.HideOnVariable.Name, this.HideOnVariable.Value);
			foreach( IRPFObject rpf_object in this.ElementList) {
				clone.ElementList.Add( rpf_object.Clone());
			}
			return clone;
		}

		public void Synch() {
			this.OnChanged();
		}

		public abstract bool Render(Cs_Component.ReportBuilder builder, PointF offset, Hashtable variables, Hashtable tables);
	
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

		protected void PropertyChanged(object sender, EventArgs e) {
			this.OnChanged();
		}

		private void size_Changed(object sender, EventArgs e) {
			Cs_Component.Size size= ( Cs_Component.Size )sender;
			this.VerticalSize= size.Height;
			this.OnChanged();
		}
		protected bool IsHidden( Hashtable variables, Hashtable tables) {
			// Check for visibility objects
			if( variables.ContainsKey( this.HideOnVariable.Name.Trim())) {
				if( variables[this.HideOnVariable.Name.Trim()].ToString()== this.HideOnVariable.Value){
					return true;
				}
			}
			return false;
		}
	}
}
