using System;
using System.Runtime.Serialization;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;
using GlobalizedPropertyGrid;


namespace Cs_Component
{
	/// <summary>
	/// Summary description for RPFBaseLabel.
	/// </summary>
	[DefaultProperty("Name")]
	public abstract class RPFBaseLabel: GlobalizedObject, IRPFObject
	{
		public RPFBaseLabel()
		{
			this.BorderMargin= new Padding( 0, 0, 0, 0);
			this.BorderSize= new Padding( 0, 0, 0, 0);
			this.BorderPadding= new Padding( 0, 0, 0, 0);
			this.Size= new Size( 0.6f, 0.2f);
			this.Location= new Location( 0, 0);
		}
		#region non browsable properties
		[ Browsable( false), XmlIgnore()]
		protected virtual string Value {
			get{ return this.Text;}
		}
		[ XmlElement( "BackColor"), Browsable( false)]
		public string XMLBackColor
		{
			get
			{
				return this.m_back_color.Name;
			}
			set
			{
				this.m_back_color= Helper.ColorFromString( value);
			}
		}
		[ XmlElement( "ForeColor"), Browsable( false)]
		public string XMLForeColor
		{
			get
			{
				return this.m_fore_color.Name;
			}
			set
			{
				this.m_fore_color= Helper.ColorFromString( value);
			}
		}

		[ XmlElement( "BorderColor"), Browsable( false)]
		public string XMLBorderColor
		{
			get
			{
				return this.m_border_color.Name;
			}
			set
			{
				this.m_border_color= Helper.ColorFromString( value);
			}
		}

		[ XmlElement( "Font"), Browsable( false)]
		public XmlFont XmlFont
		{
			get
			{
				return new XmlFont( this.m_font);
			}
			set
			{
				this.m_font= value.ToFont();
			}
		}
		
		
		#endregion

		#region browsable properties
		#region Appearance
		protected Color m_back_color= Color.Transparent;
		[DefaultValue( typeof( Color), "Transparent"), XmlIgnore()]
		public Color BackColor
		{
			get{ return this.m_back_color;}
			set{
				this.m_back_color= value;
				this.OnChanged();
			}
		}
		protected Color m_fore_color= Color.Black;
		[DefaultValue( typeof( Color), "Black"), XmlIgnore()]
		public Color ForeColor
		{
			get{ return this.m_fore_color;}
			set{
				this.m_fore_color= value;
				this.OnChanged();
			}
		}
		protected Font m_font= new Font( "Tahoma", 8);
		[DefaultValue( typeof( Font), "Tahoma, 8"), XmlIgnore()]
		public Font Font
		{
			get{ return this.m_font;}
			set{ 
				this.m_font= value;
				this.OnChanged();
			}
		}
		protected System.Drawing.ContentAlignment m_text_alignment= System.Drawing.ContentAlignment.MiddleCenter;
		[DefaultValue( typeof( System.Drawing.ContentAlignment), "MiddleCenter")]
		public System.Drawing.ContentAlignment TextAlignment
		{
			get{ return this.m_text_alignment;}
			set{ 
				this.m_text_alignment= value;
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
		protected HideOnValue m_hide_on_value= new HideOnValue();
		[DefaultValue( typeof( HideOnValue), "")]
		public HideOnValue HideOnValue {
			get{ return this.m_hide_on_value;}
			set{
				this.m_hide_on_value= value;
				this.OnChanged();
			}
		}

		#endregion
		#region Layout
		protected Location m_location;
		[DefaultValue( typeof( Location), "0, 0")]
		public Location Location
		{
			get{ return this.m_location;}
			set{ 
				this.m_location= value;
				this.m_location.Changed+=new EventHandler(PropertyChanged);
				this.OnChanged();
			}
		}
		protected Size m_size;
		[DefaultValue( typeof( Size), "0, 0")]
		public Size Size
		{
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
		public Padding BorderSize
		{
			get{ return this.m_border_size;}
			set{ 
				this.m_border_size= value;
				this.m_border_size.Changed+=new EventHandler(PropertyChanged);
				this.OnChanged();
			}
		}
		protected Padding m_border_padding;
		[DefaultValue( typeof( Padding), "0, 0, 0, 0")]
		public Padding BorderPadding
		{
			get{ return this.m_border_padding;}
			set{ 
				this.m_border_padding= value;
				this.m_border_padding.Changed+=new EventHandler(PropertyChanged);
				this.OnChanged();
			}
		}
		protected Padding m_border_margin;
		[DefaultValue( typeof( Padding), "0, 0, 0, 0")]
		public Padding BorderMargin
		{
			get{ return this.m_border_margin;}
			set{ 
				this.m_border_margin= value;
				this.m_border_margin.Changed+=new EventHandler(PropertyChanged);
				this.OnChanged();
			}
		}
		protected Color m_border_color= Color.Black;
		[DefaultValue( typeof( Color), "Black"), XmlIgnore()]
		public Color BorderColor
		{
			get{ return this.m_border_color;}
			set{ 
				this.m_border_color= value;
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
				XmlSerializer serializer = new XmlSerializer(typeof( RPFBaseLabel));
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
		public static bool XMLDeserialize( string filename, ref RPFBaseLabel obj)
		{
			TextReader reader= null;
			try
			{
				if( !System.IO.File.Exists( filename))
					return true;
				reader= new StreamReader( filename);
				XmlSerializer deserializer = new XmlSerializer(typeof( RPFBaseLabel));
				obj= ( RPFBaseLabel)deserializer.Deserialize( reader);
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

		public void Synch() {
			this.OnChanged();
		}
		public virtual bool Render(Cs_Component.ReportBuilder builder, PointF offset, Hashtable variables, Hashtable tables)
		{
			if( this.IsHidden( variables, tables)) {
				return true;
			}

			#region helper objects
			SectionBox sb;
			SectionText st;
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

			Cs_Component.TextStyle ts= new Cs_Component.TextStyle( Cs_Component.TextStyle.Normal);
			ts.SetFromFont( this.Font);
			ts.Brush= new SolidBrush( this.ForeColor);
			st= builder.AddText( this.Value, ts);
			#region TextAlignment
			switch( this.TextAlignment)
			{
				case ContentAlignment.BottomCenter:
					st.HorizontalAlignment= HorizontalAlignment.Center;
					st.VerticalAlignment= VerticalAlignment.Bottom;
					break;
				case ContentAlignment.BottomLeft:
					st.HorizontalAlignment= HorizontalAlignment.Left;
					st.VerticalAlignment= VerticalAlignment.Bottom;
					break;
				case ContentAlignment.BottomRight:
					st.HorizontalAlignment= HorizontalAlignment.Right;
					st.VerticalAlignment= VerticalAlignment.Bottom;
					break;
				case ContentAlignment.MiddleCenter:
					st.HorizontalAlignment= HorizontalAlignment.Center;
					st.VerticalAlignment= VerticalAlignment.Middle;
					break;
				case ContentAlignment.MiddleLeft:
					st.HorizontalAlignment= HorizontalAlignment.Left;
					st.VerticalAlignment= VerticalAlignment.Middle;
					break;
				case ContentAlignment.MiddleRight:
					st.HorizontalAlignment= HorizontalAlignment.Right;
					st.VerticalAlignment= VerticalAlignment.Middle;
					break;
				case ContentAlignment.TopCenter:
					st.HorizontalAlignment= HorizontalAlignment.Center;
					st.VerticalAlignment= VerticalAlignment.Top;
					break;
				case ContentAlignment.TopLeft:
					st.HorizontalAlignment= HorizontalAlignment.Left;
					st.VerticalAlignment= VerticalAlignment.Top;
					break;
				case ContentAlignment.TopRight:
					st.HorizontalAlignment= HorizontalAlignment.Right;
					st.VerticalAlignment= VerticalAlignment.Top;
					break;
			}
			#endregion

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
		#region abstracts
		public abstract string Text
		{
			get;
		}
		public abstract object Clone();
		#endregion

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
			if( this.HideOnValue.Enabled&& ( this.Value== this.HideOnValue.Value)) {
				return true;
			}
			return false;
		}
	}	
}
