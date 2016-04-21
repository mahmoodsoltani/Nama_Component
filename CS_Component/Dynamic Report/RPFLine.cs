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
	/// Summary description for RPFLine.
	/// </summary>
	[DefaultProperty("Width")]	
	public class RPFLine: GlobalizedObject, IRPFObject {
		public RPFLine() {
			this.Location= new Location( 0, 0);
		}
		#region non browsable properties
		[Browsable( false), XmlIgnore()]
		public Cs_Component.Size Size{
			get{
				Cs_Component.Size size= 
					this.Vertical? 
					new Cs_Component.Size( this.Width, this.Length ):
					new Cs_Component.Size( this.Length, this.Width );
				size.Changed+=new EventHandler(size_Changed);
				return size;
			}
			set{ 
				this.Width= this.Vertical? value.Width: value.Height;
				this.Length= this.Vertical? value.Height: value.Width;
				this.OnChanged();
			}
		}
		[ XmlElement( "Color"), Browsable( false)]
		public string XMLColor {
			get {
				return this.m_color.Name;
			}
			set {
				this.m_color= Helper.ColorFromString( value);
			}
		}
		#endregion
		#region browsable properties
		#region Appearance
		protected Color m_color= Color.Black;
		[DefaultValue( typeof( Color), "Black"), XmlIgnore()]
		public Color Color {
			get{ return this.m_color;}
			set{ 
				this.m_color= value;
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

		protected float m_length= 1;
		[DefaultValue( 1)]
		public float Length {
			get{ return this.m_length;}
			set{ 
				this.m_length= value;
				if( this.m_length< 0.005f)
					this.m_length= 0.005f;
				this.OnChanged();
			}
		}

		protected float m_width= 0.02f;
		[DefaultValue( 0.02f)]
		public float Width {
			get{ return this.m_width;}
			set{ 
				this.m_width= value;
				if( this.m_width< 0.005f)
					this.m_width= 0.005f;
				this.OnChanged();
			}
		}

		protected bool m_vertical= false;
		[DefaultValue( false)]
		public bool Vertical {
			get{ return this.m_vertical;}
			set{ 
				this.m_vertical= value;
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
				XmlSerializer serializer = new XmlSerializer(typeof( RPFLine));
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
		public static bool XMLDeserialize( string filename, ref RPFLine obj) {
			TextReader reader= null;
			try {
				if( !System.IO.File.Exists( filename))
					return true;
				reader= new StreamReader( filename);
				XmlSerializer deserializer = new XmlSerializer(typeof( RPFLine));
				obj= ( RPFLine)deserializer.Deserialize( reader);
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
			RPFLine clone= new RPFLine();
			clone.Color= this.Color;
			clone.Length= this.Length;
			clone.Location= new Location( this.Location.X, this.Location.Y);
			clone.Tag= null;
			clone.Vertical= this.Vertical;
			clone.Width= this.Width;
			clone.HideOnVariable= new HideOnVariable( this.HideOnVariable.Name, this.HideOnVariable.Value);
			return clone;
		}

		public void Synch() {
			this.OnChanged();
		}

		public bool Render(ReportBuilder builder, PointF offset, Hashtable variables, Hashtable tables) {
			if( this.IsHidden( variables, tables) ) {
				return true;
			}

			#region helper objects
			SectionBox sb;
			#endregion

			sb= builder.StartBox( );


			// Location
			sb.OffsetLeft= this.Location.X+ offset.X;
			sb.OffsetTop= this.Location.Y+ offset.Y;

			SectionLine line= new SectionLine( this.Vertical? Direction.Vertical :Direction.Horizontal);
			line.Length= this.Length;
			line.Pen= new Pen( new SolidBrush( this.Color), this.Width);
			builder.AddSection( line);

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

		private void size_Changed(object sender, EventArgs e) {
			Cs_Component.Size size= ( Cs_Component.Size )sender;
			this.Width= this.Vertical? size.Width: size.Height;
			this.Length= this.Vertical? size.Height: size.Width;
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
