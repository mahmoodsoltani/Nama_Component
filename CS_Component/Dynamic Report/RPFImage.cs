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
	/// Summary description for RPFImage.
	/// </summary>
	public class RPFImage: GlobalizedObject, IRPFObject {
		public RPFImage() {
			this.Location= new Location( 0, 0);
			this.Size= new Size( 0.5f, 0.5f);
			this.BorderMargin= new Padding( 0, 0, 0, 0);
			this.BorderPadding= new Padding( 0, 0, 0, 0);
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
		[XmlElementAttribute("Image"), Browsable( false)]
		public byte[] ImageByteArray {
			get { 
				if (this.m_image != null) {
					TypeConverter BitmapConverter= TypeDescriptor.GetConverter( this.m_image.GetType());
					return (byte[]) BitmapConverter.ConvertTo( this.m_image, typeof(byte[]));
				}
				else
					return null;
			}
        
			set { 
				if( value!= null)
					this.m_image= new Bitmap(new MemoryStream(value)); 
				else
					this.m_image= null; 
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
		private Bitmap m_image= null;
		[XmlIgnoreAttribute()]
		public Bitmap Image {
			get { return this.m_image; }
			set { 
				this.m_image= value; 
				this.OnChanged();
			}
		}
		protected int m_transparency= 0;
		[DefaultValue( 0)]
		public int Transparency {
			get{ return this.m_transparency;}
			set { 
				this.m_transparency= value;
				if( this.m_transparency< 0)
					this.m_transparency= 0;
				else if( this.m_transparency> 100)
					this.m_transparency= 100;
				this.OnChanged();
			}
		}
		private bool m_preserve_aspect_ratio= true;
		[DefaultValue( true)]
		public bool PreserveAspectRatio {
			get{ return this.m_preserve_aspect_ratio;}
			set{ 
				this.m_preserve_aspect_ratio= value;
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
		protected Padding m_border_padding;
		[DefaultValue( typeof( Padding), "0, 0, 0, 0")]
		public Padding BorderPadding {
			get{ return this.m_border_padding;}
			set{ 
				this.m_border_padding= value;
				this.m_border_padding.Changed+=new EventHandler(PropertyChanged);
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
				XmlSerializer serializer = new XmlSerializer(typeof( RPFImage));
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
		public static bool XMLDeserialize( string filename, ref RPFImage obj) {
			TextReader reader= null;
			try {
				if( !System.IO.File.Exists( filename))
					return true;
				reader= new StreamReader( filename);
				XmlSerializer deserializer = new XmlSerializer(typeof( RPFImage));
				obj= ( RPFImage)deserializer.Deserialize( reader);
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
			RPFImage clone= new RPFImage();
			clone.BackColor= this.BackColor;
			clone.BorderColor= this.BorderColor;
			clone.BorderMargin= new Padding( this.BorderMargin.Left, this.BorderMargin.Top, this.BorderMargin.Right, this.BorderMargin.Bottom);
			clone.BorderPadding= new Padding( this.BorderPadding.Left, this.BorderPadding.Top, this.BorderPadding.Right, this.BorderPadding.Bottom);
			clone.BorderSize= new Padding( this.BorderSize.Left, this.BorderSize.Top, this.BorderSize.Right, this.BorderSize.Bottom);
			if( this.Image!= null) 
				clone.Image= (Bitmap)this.Image.Clone();
			clone.Location= new Location( this.Location.X, this.Location.Y);
			clone.Size= new Size( this.Size.Width, this.Size.Height);
			clone.Tag= null;
			clone.Transparency= this.Transparency;
			clone.HideOnVariable= new HideOnVariable( this.HideOnVariable.Name, this.HideOnVariable.Value);
			return clone;
		}

		public void Synch() {
			this.OnChanged();
		}

		public bool Render(ReportBuilder builder, PointF offset, System.Collections.Hashtable variables, System.Collections.Hashtable tables) {
			if( this.IsHidden( variables, tables)) {
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
			
			sb.PaddingBottom= this.BorderPadding.Bottom;
			sb.PaddingLeft= this.BorderPadding.Left;
			sb.PaddingRight= this.BorderPadding.Right;
			sb.PaddingTop= this.BorderPadding.Top;

			sb.MarginBottom= this.BorderMargin.Bottom;
			sb.MarginLeft= this.BorderMargin.Left;
			sb.MarginRight= this.BorderMargin.Right;
			sb.MarginTop= this.BorderMargin.Top;

			// Size
			sb.Width= this.m_size.Width;
			sb.Height= this.m_size.Height;

			if( this.Image!= null) {
				SectionImage image = new SectionImage ( this.Image);
				image.Transparency = this.m_transparency; 
				image.HorizontalAlignment= Cs_Component.HorizontalAlignment.Center;
				image.VerticalAlignment= Cs_Component.VerticalAlignment.Middle;
				image.PreserveAspectRatio= this.PreserveAspectRatio;
				sb.AddSection( image);
			}

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
