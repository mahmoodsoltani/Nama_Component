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
	/// Summary description for RPFBox.
	/// </summary>
	public class RPFBox: GlobalizedObject, IRPFObject {
		public RPFBox() {
			this.Location= new Location( 0, 0);
			this.Size= new Size( 0.5f, 0.5f);
			this.BorderMargin= new Padding( 0, 0, 0, 0);
			this.BorderSize= new Padding( 0, 0, 0, 0);
		}
		#region non browsable properties
		[ XmlElement( "BackColor"), Browsable( false)]
		public string XMLBackColor {
			get {
				return this.m_back_color.Name;
			}
			set {
				this.m_back_color= Helper.ColorFromString( value);
			}
		}
		[ XmlElement( "BorderColor"), Browsable( false)]
		public string XMLBorderColor {
			get {
				return this.m_border_color.Name;
			}
			set {
				this.m_border_color= Helper.ColorFromString( value);
			}
		}		
		
		#endregion
		#region browsable properties
		#region Appearance
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
		protected Location m_location;
		[DefaultValue( typeof( Location), "0, 0")]
		public Location Location {
			get{ return this.m_location;}
			set{ 
				this.m_location= value;
				this.m_location.Changed+=new EventHandler(PropertyChanged);
				this.OnChanged();
			}
		}
		protected Size m_size;
		[DefaultValue( typeof( Size), "0, 0")]
		public Size Size {
			get{ return this.m_size;}
			set{ 
				this.m_size= value;
				this.m_size.Changed+=new EventHandler(PropertyChanged);
				this.OnChanged();
			}
		}
		#endregion
		#region Border
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
		public bool XMLSerialize( string filename) {
			TextWriter writer= null;
			try {
				writer = new StreamWriter( filename);
				XmlSerializer serializer = new XmlSerializer(typeof( RPFBox));
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
		public static bool XMLDeserialize( string filename, ref RPFBox obj) {
			TextReader reader= null;
			try {
				if( !System.IO.File.Exists( filename))
					return true;
				reader= new StreamReader( filename);
				XmlSerializer deserializer = new XmlSerializer(typeof( RPFBox));
				obj= ( RPFBox)deserializer.Deserialize( reader);
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
		public object Clone() {
			RPFBox clone= new RPFBox();
			clone.BackColor= this.BackColor;
			clone.BorderColor= this.BorderColor;
			clone.BorderMargin= new Padding( this.BorderMargin.Left, this.BorderMargin.Top, this.BorderMargin.Right, this.BorderMargin.Bottom);
			clone.BorderSize= new Padding( this.BorderSize.Left, this.BorderSize.Top, this.BorderSize.Right, this.BorderSize.Bottom);
			clone.Location= new Location( this.Location.X, this.Location.Y);
			clone.Size= new Size( this.Size.Width, this.Size.Height);
			clone.Tag= null;
			clone.HideOnVariable= new HideOnVariable( this.HideOnVariable.Name, this.HideOnVariable.Value);
			return clone;
		}

		public void Synch() {
			this.OnChanged();
		}

		public virtual bool Render(Cs_Component.ReportBuilder builder, PointF offset, Hashtable variables, Hashtable tables) {
			if( this.IsHidden( variables, tables) ) {
				return true;
			}
			#region helper objects
			SectionBox sb;
			LayeredSections ll;
			#endregion

			sb= builder.StartBox( );

			// Location
			sb.OffsetLeft= this.Location.X+ offset.X;
			sb.OffsetTop= this.Location.Y+ offset.Y;

			// Background
			sb.Background= new SolidBrush( this.BackColor);

			ll= builder.StartLayeredLayout( false, false);

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
			sb.Width= this.m_size.Width;
			sb.Height= this.m_size.Height;

			builder.FinishBox();
			builder.FinishLayeredLayout();
			builder.FinishBox();
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
