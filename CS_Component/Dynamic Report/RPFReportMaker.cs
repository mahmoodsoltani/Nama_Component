using System;
using System.Collections;
using System.Drawing;


namespace Cs_Component {
	/// <summary>
	/// Summary description for RPFReportMaker.
	/// </summary>
	public class RPFReportMaker: IReportMaker {
		private RPFDocument m_rpf_document= new RPFDocument();
		public RPFReportMaker() {
		}
		#region IReportMaker Members
		public void MakeDocument(ReportDocument reportDocument) {
			// Always reset the text styles if you have multiple methods that
			// set them
			TextStyle.ResetStyles();

			// Create a ReportBuilder object that assists with building a report
			ReportBuilder builder = new ReportBuilder(reportDocument);
			this.m_rpf_document.Render( builder, new PointF( 0, 0), this.m_variables, this.m_tables);
		}

		#endregion
		public bool Load( string filename) {
			if( !RPFDocument.XMLDeserialize( filename, ref this.m_rpf_document))
				return false;
			this.OnDocumentLoaded();
			return true;
		}
		public bool Save( string filename) {
			return this.m_rpf_document.XMLSerialize( filename);
		}
		#region events
		public event EventHandler DocumentLoaded;
		protected virtual void OnDocumentLoaded( ) {
			if( this.DocumentLoaded!= null)
				this.DocumentLoaded( this, new EventArgs());
		}
		public event EventHandler DynamicObjectChanged;
		protected virtual void OnDynamicObjectChanged( ) {
			if( this.DynamicObjectChanged!= null)
				this.DynamicObjectChanged( this, new EventArgs());
		}

		public delegate void TrackingEventHandler(object sender, TrackingEventArgs e);
		public event TrackingEventHandler Tracking;
		protected virtual void OnTracking( int delta_X, int delta_Y, TrackerBaseControl.TRACKER_MODE mode) {
			if( this.Tracking!= null)
				this.Tracking( this, new TrackingEventArgs( delta_X, delta_Y, mode));
		}
		public class TrackingEventArgs: EventArgs{
			public TrackingEventArgs( int delta_X, int delta_Y, TrackerBaseControl.TRACKER_MODE mode) {
				this.m_delta_X= delta_X;
				this.m_delta_Y= delta_Y;
				this.m_mode= mode;
			}
			public int m_delta_X;
			public int m_delta_Y;
			public TrackerBaseControl.TRACKER_MODE m_mode;
		}
		#endregion

		#region properties
		public RPFDocument RPFDocument {
			get{ return this.m_rpf_document;}
		}
		private Hashtable m_variables= new Hashtable();
		public Hashtable Variables {
			get{ return this.m_variables;}
			set{ 
				this.m_variables= value;
				this.OnDynamicObjectChanged();
			}
		}
		private Hashtable m_tables= new Hashtable();
		public Hashtable Tables {
			get{ return this.m_tables;}
			set{ 
				this.m_tables= value;
				this.OnDynamicObjectChanged();
			}
		}
		
		#endregion
	}
}
