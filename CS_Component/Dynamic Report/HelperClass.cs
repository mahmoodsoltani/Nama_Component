using System;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Xml;
using System.Xml.Serialization;

namespace Cs_Component {
	public class Helper {
		private static System.Resources.ResourceManager g_res_man;
		private static Type[] g_xml_types= null;
		static Helper() {
			Helper.g_xml_types= new Type[] {
											   typeof(RPFSection), 
											   typeof(RPFFixedSection), 
											   typeof(RPFTableRowSection), 
											   typeof(RPFLabel), 
											   typeof(RPFVariable),
											   typeof(RPFTableColumn),
											   typeof(RPFImage),
											   typeof(RPFLine),
											   typeof(RPFBox),
			};
            Helper.g_res_man = new System.Resources.ResourceManager("Cs_Component.Framwork.Strings", System.Reflection.Assembly.GetExecutingAssembly());
		}
		public static Type[] XmlTypes {
			get{ return Helper.g_xml_types;}
		}
		public static Color ColorFromString( string name) {
			Color color= System.Drawing.Color.FromName( name);
			if( color.ToArgb()!= 0)
				return color;
			// Custom color ( not a valid name)
			return System.Drawing.Color.FromArgb( System.Convert.ToInt32( name, 16));
		}
		public static void ShowException( Exception excp) {
			MessageBox.Show( string.Format("{0}\n{1}\n{2}", excp.Source, excp.Message, excp.StackTrace), System.Reflection.Assembly.GetExecutingAssembly().FullName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		static public string GetLocalString( string id) {
			try {
				return g_res_man.GetString( id);
			}
			catch( Exception excp) {
				ShowException( excp);
				return "?????";
			}
		}
	}
	[TypeConverter(typeof(ExpandableObjectConverter)), Serializable()]
	public class Padding: object {
		public Padding( ) {
		}
		public Padding( float left, float top, float right, float bottom) {
			this.m_left= left;
			this.m_top= top;
			this.m_right= right;
			this.m_bottom= bottom;
		}
		#region properties
		protected float m_left= 0;
		[DefaultValue( 0)]
		public float Left {
			get{ return this.m_left;}
			set{ 
				if( this.m_left== value)
					return;
				this.m_left= value;
				this.OnChanged();
			}
		}
		protected float m_top= 0;
		[DefaultValue( 0)]
		public float Top {
			get{ return this.m_top;}
			set{ 
				if( this.m_top== value)
					return;
				this.m_top= value;
				this.OnChanged();
			}
		}
		protected float m_right= 0;
		[DefaultValue( 0)]
		public float Right {
			get{ return this.m_right;}
			set{ 
				if( this.m_right== value)
					return;
				this.m_right= value;
				this.OnChanged();
			}
		}
		protected float m_bottom= 0;
		[DefaultValue( 0)]
		public float Bottom {
			get{ return this.m_bottom;}
			set{ 
				if( this.m_bottom== value)
					return;
				this.m_bottom= value;
				this.OnChanged();
			}
		}
		#endregion
		public override string ToString() {
			return string.Format( "L:{0}; R:{1}; T:{2}; B:{3}", this.m_left, this.m_right, this.m_top, this.m_bottom);
		}
		public event EventHandler Changed;
		protected void OnChanged() {
			if( Changed != null) {
				this.Changed( this, new EventArgs());
			}
		}
	}
	[TypeConverter(typeof(ExpandableObjectConverter)), Serializable()]
	public class Size: object {
		public Size( ) {
		}
		public Size( float width, float height) {
			this.m_width= width;
			this.m_height= height;
		}
		#region properties
		protected float m_width= 0;
		[DefaultValue( 0)]
		public float Width {
			get{ return this.m_width;}
			set{ 
				if( this.m_width== value)
					return;
				this.m_width= value;
				this.OnChanged();
			}
		}
		protected float m_height= 0;
		[DefaultValue( 0)]
		public float Height {
			get{ return this.m_height;}
			set{ 
				if( this.m_height== value)
					return;
				this.m_height= value;
				this.OnChanged();
			}
		}
		#endregion
		public override string ToString() {
			return string.Format( "W:{0}; H:{1}", this.Width, this.Height);
		}
		public event EventHandler Changed;
		protected void OnChanged() {
			if( Changed != null) {
				this.Changed( this, new EventArgs());
			}
		}
	}
	[TypeConverter(typeof(ExpandableObjectConverter)), Serializable()]
	public class Location: object {
		public Location( ) {
		}
		public Location( float x, float y) {
			this.m_x= x;
			this.m_y= y;
		}
		#region properties
		protected float m_x= 0;
		[DefaultValue( 0)]
		public float X {
			get{ return this.m_x;}
			set{ 
				if( this.m_x== value)
					return;
				this.m_x= value;
				this.OnChanged();
			}
		}
		protected float m_y= 0;
		[DefaultValue( 0)]
		public float Y {
			get{ return this.m_y;}
			set{ 
				if( this.m_y== value)
					return;
				this.m_y= value;
				this.OnChanged();
			}
		}
		#endregion
		public override string ToString() {
			return string.Format( "X:{0}; Y:{1}", this.X, this.Y);
		}
		public event EventHandler Changed;
		protected void OnChanged() {
			if( Changed != null) {
				this.Changed( this, new EventArgs());
			}
		}
	}
	[TypeConverter(typeof(ExpandableObjectConverter)), Serializable()]
	public class HideOnVariable: object {
		public HideOnVariable( ) {
		}
		public HideOnVariable( string name, string value) {
			this.m_name= name;
			this.m_value= value;
		}
		#region properties
		protected string m_name= "";
		[DefaultValue( "")]
		public string Name {
			get{ return this.m_name;}
			set{ 
				if( this.m_name== value)
					return;
				this.m_name= value;
				this.OnChanged();
			}
		}
		protected string m_value= "";
		[DefaultValue( "")]
		public string Value {
			get{ return this.m_value;}
			set{ 
				if( this.m_value== value)
					return;
				this.m_value= value;
				this.OnChanged();
			}
		}
		#endregion
		public override string ToString() {
			if( this.Name.Trim().Length!= 0) {
				return string.Format( "'{0}' = '{1}'", this.Name, this.Value);
			} 
			return "";
		}
		public event EventHandler Changed;
		protected void OnChanged() {
			if( Changed != null) {
				this.Changed( this, new EventArgs());
			}
		}
	}


	[TypeConverter(typeof(ExpandableObjectConverter)), Serializable()]
	public class HideOnValue: object {
		public HideOnValue( ) {
		}
		public HideOnValue( bool enabled, string value) {
			this.m_enabled= enabled;
			this.m_value= value;
		}
		#region properties
		protected bool m_enabled= false;
		[DefaultValue( false)]
		public bool Enabled {
			get{ return this.m_enabled;}
			set{ 
				if( this.m_enabled== value)
					return;
				this.m_enabled= value;
				this.OnChanged();
			}
		}
		protected string m_value= "";
		[DefaultValue( "")]
		public string Value {
			get{ return this.m_value;}
			set{ 
				if( this.m_value== value)
					return;
				this.m_value= value;
				this.OnChanged();
			}
		}
		#endregion
		public override string ToString() {
			if( this.Enabled) {
				return string.Format( "'{0}'", this.Value);
			}
			return "";
		}
		public event EventHandler Changed;
		protected void OnChanged() {
			if( Changed != null) {
				this.Changed( this, new EventArgs());
			}
		}
	}
	
	public struct XmlFont {
		public string FontFamily;
		public GraphicsUnit GraphicsUnit;
		public float Size;
		public FontStyle Style;

		public XmlFont(Font f) {
			FontFamily = f.FontFamily.Name;
			GraphicsUnit = f.Unit;
			Size = f.Size;
			Style = f.Style;
		}

		public Font ToFont() {
			return new Font(FontFamily, Size, Style, 
				GraphicsUnit);
		}
	}
	public class PaperKindConverter: StringConverter {
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
			return true;
		}
		public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
			return this.GetStdValues( context);
		}
		private StandardValuesCollection GetStdValues( ITypeDescriptorContext context) {		
			RPFDocument rpf_document= context.Instance as RPFDocument;
			bool printer_found= false;
			foreach( string printer in PrinterSettings.InstalledPrinters){
				if( string.Compare( rpf_document.PrinterSettings.PrinterName, printer, true)== 0){
					printer_found= true;
					break;
				}
			}
			ArrayList kinds= new ArrayList();
			if( printer_found){
				foreach( System.Drawing.Printing.PaperSize size in rpf_document.PrinterSettings.PaperSizes) {
					if( size.Kind!= PaperKind.Custom) {
						kinds.Add( size.Kind.ToString());
					}
				}
			} else {
				foreach( string kind in Enum.GetNames( typeof( PaperKind))) {
					kinds.Add( kind);
				}
			}
			return new StandardValuesCollection( kinds);
		}
	}
	public class InstalledPrinterConverter: StringConverter {
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
			return true;
		}
		public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
			return this.GetStdValues( context);
		}
		private StandardValuesCollection GetStdValues( ITypeDescriptorContext context) {
			return new StandardValuesCollection( PrinterSettings.InstalledPrinters);
		}
	}
}