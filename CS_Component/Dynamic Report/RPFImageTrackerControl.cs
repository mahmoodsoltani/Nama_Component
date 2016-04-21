using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Cs_Component {
	public class RPFImageTrackerControl : Cs_Component.RPFTrackerBaseControl {
		private System.ComponentModel.IContainer components = null;
		protected Rectangle m_draw_rectangle;
		protected ImageAttributes m_image_attributes = new ImageAttributes();


		public RPFImageTrackerControl() {
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		public RPFImageTrackerControl( RPFImage rpf_object): base( rpf_object){
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
		}
		#endregion
		#region public methods
		public override void Render(Graphics g) {
			base.Render (g);
			if( this.DesignMode)
				return;
			RPFImage rpf_object= ( RPFImage)this.m_rpf_object;

			#region Border
			int border_pix_left= (int)( rpf_object.BorderSize.Left* g.DpiX);
			int border_pix_right= (int)( rpf_object.BorderSize.Right* g.DpiX);
			int border_pix_top= (int)( rpf_object.BorderSize.Top* g.DpiY);
			int border_pix_bottom= (int)( rpf_object.BorderSize.Bottom* g.DpiY);
			Rectangle border_draw_rect= new Rectangle( 
				(int)(float) ( rpf_object.BorderMargin.Left* g.DpiX),
				(int)(float) ( rpf_object.BorderMargin.Top* g.DpiY),
				(int)(float) (this.ClientSize.Width- 1- ( rpf_object.BorderMargin.Right+ rpf_object.BorderMargin.Left)* g.DpiX),
				(int)(float) (this.ClientSize.Height- 1- ( rpf_object.BorderMargin.Top+ rpf_object.BorderMargin.Bottom)* g.DpiY));
			if( rpf_object.BorderSize.Top!= 0) {
				using( Pen border_pen= new Pen( rpf_object.BorderColor, border_pix_top)) { 
					g.DrawLine( border_pen, border_draw_rect.X, border_draw_rect.Y+ ( border_pix_top>> 1), border_draw_rect.X+ border_draw_rect.Width, border_draw_rect.Y+ ( border_pix_top>> 1));
				} 
			}
			if( rpf_object.BorderSize.Bottom!= 0) {
				using( Pen border_pen= new Pen( rpf_object.BorderColor, border_pix_bottom)) { 
					g.DrawLine( border_pen, border_draw_rect.X, border_draw_rect.Y+ border_draw_rect.Height- ( border_pix_bottom>> 1), border_draw_rect.X+ border_draw_rect.Width, border_draw_rect.Y+ border_draw_rect.Height- ( border_pix_bottom>> 1));
				}
			}
			if( rpf_object.BorderSize.Left!= 0) {
				using( Pen border_pen= new Pen( rpf_object.BorderColor, border_pix_left)) { 
					g.DrawLine( border_pen, border_draw_rect.X+ ( border_pix_left>> 1), border_draw_rect.Y, border_draw_rect.X+ ( border_pix_left>> 1), border_draw_rect.Y+ border_draw_rect.Height);
				}
			}
			if( rpf_object.BorderSize.Right!= 0) {
				using( Pen border_pen= new Pen( rpf_object.BorderColor, border_pix_right)) { 
					g.DrawLine( border_pen, border_draw_rect.X+ border_draw_rect.Width- ( border_pix_right>> 1), border_draw_rect.Y, border_draw_rect.X+ border_draw_rect.Width- ( border_pix_right>> 1), border_draw_rect.Y+ border_draw_rect.Height);
				}
			}
			#endregion

			#region Image
			if( rpf_object.Image!= null) {
				g.DrawImage( rpf_object.Image, this.m_draw_rectangle, 0, 0, rpf_object.Image.Width, rpf_object.Image.Height, GraphicsUnit.Pixel, this.m_image_attributes);
			}
			#endregion
		}

		#endregion
		protected void UpdateDrawRectangle() {
			if( this.m_rpf_object== null)
				return;
			RPFImage rpf_object= ( RPFImage)this.m_rpf_object;
			using( Graphics g= this.CreateGraphics()) {
				int left= (int)(float)(( rpf_object.BorderSize.Left+ rpf_object.BorderMargin.Left+ rpf_object.BorderPadding.Left)* g.DpiX);
				int top= (int)(float)(( rpf_object.BorderSize.Top+ rpf_object.BorderMargin.Top+ rpf_object.BorderPadding.Top)* g.DpiY);
				int right= (int)(float)((float)this.Size.Width- ( rpf_object.BorderSize.Right+ rpf_object.BorderMargin.Right+ rpf_object.BorderPadding.Right)*g.DpiX);
				int bottom= (int)(float)((float)this.Size.Height- ( rpf_object.BorderSize.Bottom+ rpf_object.BorderMargin.Bottom+ rpf_object.BorderPadding.Bottom)*g.DpiY);
				if( !rpf_object.PreserveAspectRatio|| 
					( rpf_object.Image== null)) {
					this.m_draw_rectangle= new Rectangle( 
						left,
						top,
						right- left, 
						bottom- top); 
					return;
				}
				// Keep image aspect ration
				int new_width= right- left;
				int new_height= (int)(float)( (float)new_width* (float)rpf_object.Image.Size.Height/ (float)rpf_object.Image.Size.Width); 
				if( new_height<= bottom- top) {
					this.m_draw_rectangle= new Rectangle( 
						left,
						top+ (((bottom- top)- new_height)>> 1),
						new_width, 
						new_height); 
					return;
				}
				new_height= bottom- top;
				new_width= (int)(float)( (float)new_height* (float)rpf_object.Image.Size.Width/ (float)rpf_object.Image.Size.Height); 
				this.m_draw_rectangle= new Rectangle( 
					left+ (((right- left)- new_width)>> 1),
					top,
					new_width, 
					new_height); 
			}
		}
		protected override void RPFObjectChanged(object sender, EventArgs e) {
			base.RPFObjectChanged( sender, e);
			RPFImage rpf_object= ( RPFImage)this.m_rpf_object;
			this.BackColor= rpf_object.BackColor;
			ColorMatrix myColorMatrix = new ColorMatrix();
			myColorMatrix.Matrix00 = 1.00f; // Red
			myColorMatrix.Matrix11 = 1.00f; // Green
			myColorMatrix.Matrix22 = 1.00f; // Blue
			myColorMatrix.Matrix33 = (100.0f- (float)rpf_object.Transparency)* 0.01f; // alpha
			myColorMatrix.Matrix44 = 1.00f;        // w
			this.m_image_attributes.ClearColorMatrix();
			this.m_image_attributes.SetColorMatrix ( myColorMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap);
			this.UpdateDrawRectangle();

			this.Invalidate( false);
		}
		protected override void OnSizeChanged(EventArgs e) {
			base.OnSizeChanged (e);
			this.UpdateDrawRectangle();
		}

	}
}

