using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms;

namespace Cs_Component {
	/// <summary>
	/// Summary description for RPFDesignerControl.
	/// </summary>
	public class RPFDesignerControl : System.Windows.Forms.UserControl {
		private const float PASTE_DELTA= 0.1f;
		private float m_last_paste_delta= 0;
		private System.Windows.Forms.Panel m_left_panel;
		private System.Windows.Forms.Panel m_right_panel;
		private System.Windows.Forms.Panel m_center_panel;
        private System.Windows.Forms.Panel m_property_panel;
		private System.Windows.Forms.Panel m_available_panel;
		private System.Windows.Forms.Panel m_placed_panel;
		private System.Windows.Forms.Label m_avaliable_header_label;
		private System.Windows.Forms.ImageList m_tree_imageList;
		private System.Windows.Forms.TabControl m_designer_tabControl;
		private System.Windows.Forms.TabPage m_designer_layout_tabPage;
		private System.Windows.Forms.TabPage m_designer_preview_tabPage;
		private System.Windows.Forms.ImageList m_tab_imageList;
        private System.Windows.Forms.Label m_placed_header_label;
        private System.Windows.Forms.TreeView m_allocated_treeView;
		private System.Windows.Forms.Panel m_designer_layout_panel;
		private System.Windows.Forms.ImageList m_toolbar_imageList;
		private Cs_Component.DrawingCanvas m_draw_panel;
		private System.Windows.Forms.Panel m_designer_panel;
		private System.Windows.Forms.ToolBar m_designer_layout_toolBar;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.TreeView m_available_treeView;
		private System.Windows.Forms.Timer m_drag_drop_timer;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolBarButton m_edit_delete_toolBarButton;
		private System.Windows.Forms.ToolBarButton m_edit_cut_toolBarButton;
		private System.Windows.Forms.ToolBarButton m_edit_copy_toolBarButton;
		private System.Windows.Forms.ToolBarButton m_edit_paste_toolBarButton;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton m_format_align_left_toolBarButton;
		private System.Windows.Forms.ToolBarButton m_format_align_vcentre_toolBarButton;
		private System.Windows.Forms.ToolBarButton m_format_align_right_toolBarButton;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton m_format_align_top_toolBarButton;
		private System.Windows.Forms.ToolBarButton m_format_align_hcentre_toolBarButton;
		private System.Windows.Forms.ToolBarButton m_format_align_bottom_toolBarButton;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton m_format_same_width_max_toolBarButton;
		private System.Windows.Forms.ToolBarButton m_format_same_width_min_toolBarButton;
		private System.Windows.Forms.ToolBarButton m_format_same_height_max_toolBarButton;
		private System.Windows.Forms.ToolBarButton m_format_same_height_min_toolBarButton;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.ToolBar m_preview_toolBar;
		private System.Windows.Forms.ToolBarButton m_preview_print_toolBarButton;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ToolBarButton m_preview_zoom_toolBarButton;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ToolBarButton m_preview_next_toolBarButton;
		private System.Windows.Forms.ToolBarButton m_preview_prev_toolBarButton;
		private System.Windows.Forms.PrintPreviewControl m_preview_control;
		private System.Windows.Forms.ContextMenu m_zoom_contextMenu;
		private System.Windows.Forms.MenuItem m_zoom_auto_menuItem;
		private System.Windows.Forms.MenuItem m_zoom_perc_200_menuItem;
		private System.Windows.Forms.MenuItem m_zoom_perc_150_menuItem;
		private System.Windows.Forms.MenuItem m_zoom_perc_100_menuItem;
		private System.Windows.Forms.MenuItem m_zoom_perc_75_menuItem;
		private System.Windows.Forms.MenuItem m_zoom_perc_50_menuItem;
		private System.Windows.Forms.MenuItem m_zoom_perc_25_menuItem;
        private System.Windows.Forms.MenuItem m_zoom_perc_10_menuItem;
        private PropertyGrid m_propertyGrid;
        private Splitter splitter4;
        private Panel panel1;
        private Label label1;
        private Button btn_Load;
        private Button btn_Save;
        private SaveFileDialog saveFileDialog1;
        private Button btn_Saveas;
        private OpenFileDialog openFileDialog1;
        private ContextMenuStrip contextMenu_Design;
        private ToolStripMenuItem toolStripDelete;
        private ToolStripMenuItem toolStripCopy;
        private ToolStripMenuItem toolStripCut;
        private ToolStripMenuItem toolStripPaste;
        private Label m_property_header_label;
		private TreeNode m_drag_drop_sel_node= null;

		public RPFDesignerControl() {
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			this.m_rpf_report_maker.DocumentLoaded+=new EventHandler(m_rpf_report_maker_DocumentLoaded);
			this.m_rpf_report_maker.DynamicObjectChanged+=new EventHandler(m_rpf_report_maker_DynamicObjectChanged);
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPFDesignerControl));
            this.m_toolbar_imageList = new System.Windows.Forms.ImageList(this.components);
            this.m_left_panel = new System.Windows.Forms.Panel();
            this.m_available_panel = new System.Windows.Forms.Panel();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Saveas = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_allocated_treeView = new System.Windows.Forms.TreeView();
            this.m_tree_imageList = new System.Windows.Forms.ImageList(this.components);
            this.m_avaliable_header_label = new System.Windows.Forms.Label();
            this.m_available_treeView = new System.Windows.Forms.TreeView();
            this.m_right_panel = new System.Windows.Forms.Panel();
            this.m_placed_panel = new System.Windows.Forms.Panel();
            this.m_placed_header_label = new System.Windows.Forms.Label();
            this.m_property_panel = new System.Windows.Forms.Panel();
            this.m_propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.m_property_header_label = new System.Windows.Forms.Label();
            this.m_center_panel = new System.Windows.Forms.Panel();
            this.m_designer_tabControl = new System.Windows.Forms.TabControl();
            this.m_designer_layout_tabPage = new System.Windows.Forms.TabPage();
            this.m_designer_panel = new System.Windows.Forms.Panel();
            this.m_designer_layout_panel = new System.Windows.Forms.Panel();
            this.contextMenu_Design = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.m_designer_layout_toolBar = new System.Windows.Forms.ToolBar();
            this.m_edit_cut_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.m_edit_copy_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.m_edit_paste_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.m_edit_delete_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.m_format_align_left_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.m_format_align_vcentre_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.m_format_align_right_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.m_format_align_top_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.m_format_align_hcentre_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.m_format_align_bottom_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.m_format_same_width_max_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.m_format_same_height_max_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.m_format_same_width_min_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.m_format_same_height_min_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_designer_preview_tabPage = new System.Windows.Forms.TabPage();
            this.m_preview_control = new System.Windows.Forms.PrintPreviewControl();
            this.m_preview_toolBar = new System.Windows.Forms.ToolBar();
            this.m_preview_print_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.m_preview_zoom_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.m_zoom_contextMenu = new System.Windows.Forms.ContextMenu();
            this.m_zoom_auto_menuItem = new System.Windows.Forms.MenuItem();
            this.m_zoom_perc_200_menuItem = new System.Windows.Forms.MenuItem();
            this.m_zoom_perc_150_menuItem = new System.Windows.Forms.MenuItem();
            this.m_zoom_perc_100_menuItem = new System.Windows.Forms.MenuItem();
            this.m_zoom_perc_75_menuItem = new System.Windows.Forms.MenuItem();
            this.m_zoom_perc_50_menuItem = new System.Windows.Forms.MenuItem();
            this.m_zoom_perc_25_menuItem = new System.Windows.Forms.MenuItem();
            this.m_zoom_perc_10_menuItem = new System.Windows.Forms.MenuItem();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.m_preview_prev_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.m_preview_next_toolBarButton = new System.Windows.Forms.ToolBarButton();
            this.m_tab_imageList = new System.Windows.Forms.ImageList(this.components);
            this.m_drag_drop_timer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.m_draw_panel = new Cs_Component.DrawingCanvas();
            this.m_left_panel.SuspendLayout();
            this.m_available_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_right_panel.SuspendLayout();
            this.m_placed_panel.SuspendLayout();
            this.m_property_panel.SuspendLayout();
            this.m_center_panel.SuspendLayout();
            this.m_designer_tabControl.SuspendLayout();
            this.m_designer_layout_tabPage.SuspendLayout();
            this.m_designer_panel.SuspendLayout();
            this.m_designer_layout_panel.SuspendLayout();
            this.contextMenu_Design.SuspendLayout();
            this.m_designer_preview_tabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_toolbar_imageList
            // 
            this.m_toolbar_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_toolbar_imageList.ImageStream")));
            this.m_toolbar_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_toolbar_imageList.Images.SetKeyName(0, "");
            this.m_toolbar_imageList.Images.SetKeyName(1, "");
            this.m_toolbar_imageList.Images.SetKeyName(2, "");
            this.m_toolbar_imageList.Images.SetKeyName(3, "cut.png");
            this.m_toolbar_imageList.Images.SetKeyName(4, "copy.png");
            this.m_toolbar_imageList.Images.SetKeyName(5, "paste.png");
            this.m_toolbar_imageList.Images.SetKeyName(6, "no48x48 24-bit.png");
            this.m_toolbar_imageList.Images.SetKeyName(7, "");
            this.m_toolbar_imageList.Images.SetKeyName(8, "");
            this.m_toolbar_imageList.Images.SetKeyName(9, "");
            this.m_toolbar_imageList.Images.SetKeyName(10, "");
            this.m_toolbar_imageList.Images.SetKeyName(11, "");
            this.m_toolbar_imageList.Images.SetKeyName(12, "");
            this.m_toolbar_imageList.Images.SetKeyName(13, "");
            this.m_toolbar_imageList.Images.SetKeyName(14, "");
            this.m_toolbar_imageList.Images.SetKeyName(15, "");
            this.m_toolbar_imageList.Images.SetKeyName(16, "");
            this.m_toolbar_imageList.Images.SetKeyName(17, "");
            this.m_toolbar_imageList.Images.SetKeyName(18, "");
            this.m_toolbar_imageList.Images.SetKeyName(19, "");
            this.m_toolbar_imageList.Images.SetKeyName(20, "print.png");
            this.m_toolbar_imageList.Images.SetKeyName(21, "zoom48x48 24-bit.png");
            this.m_toolbar_imageList.Images.SetKeyName(22, "left48x48 24-bit.png");
            this.m_toolbar_imageList.Images.SetKeyName(23, "rigth48x48 24-bit.png");
            // 
            // m_left_panel
            // 
            this.m_left_panel.Controls.Add(this.m_available_panel);
            this.m_left_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_left_panel.Location = new System.Drawing.Point(0, 0);
            this.m_left_panel.Name = "m_left_panel";
            this.m_left_panel.Size = new System.Drawing.Size(168, 530);
            this.m_left_panel.TabIndex = 0;
            // 
            // m_available_panel
            // 
            this.m_available_panel.Controls.Add(this.splitter4);
            this.m_available_panel.Controls.Add(this.panel1);
            this.m_available_panel.Controls.Add(this.m_allocated_treeView);
            this.m_available_panel.Controls.Add(this.m_avaliable_header_label);
            this.m_available_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_available_panel.Location = new System.Drawing.Point(0, 0);
            this.m_available_panel.Name = "m_available_panel";
            this.m_available_panel.Size = new System.Drawing.Size(168, 530);
            this.m_available_panel.TabIndex = 3;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitter4.Location = new System.Drawing.Point(0, 256);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(168, 3);
            this.splitter4.TabIndex = 4;
            this.splitter4.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_Saveas);
            this.panel1.Controls.Add(this.btn_Load);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 259);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 271);
            this.panel1.TabIndex = 3;
            // 
            // btn_Saveas
            // 
            this.btn_Saveas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Saveas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Saveas.Location = new System.Drawing.Point(19, 132);
            this.btn_Saveas.Name = "btn_Saveas";
            this.btn_Saveas.Size = new System.Drawing.Size(121, 30);
            this.btn_Saveas.TabIndex = 6;
            this.btn_Saveas.Text = "ÐÎíÑå ÈÇ äÇã";
            this.btn_Saveas.UseVisualStyleBackColor = true;
            this.btn_Saveas.Click += new System.EventHandler(this.btn_Saveas_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Load.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Load.Location = new System.Drawing.Point(19, 50);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(121, 30);
            this.btn_Load.TabIndex = 5;
            this.btn_Load.Text = "ÈÇÑ ÒÇÑí ÒÇÑÔ";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Save.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Save.Location = new System.Drawing.Point(19, 91);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(121, 30);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "ÐÎíÑå";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.CadetBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "ÇãßÇäÇÊ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_allocated_treeView
            // 
            this.m_allocated_treeView.AllowDrop = true;
            this.m_allocated_treeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_allocated_treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_allocated_treeView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.m_allocated_treeView.FullRowSelect = true;
            this.m_allocated_treeView.HideSelection = false;
            this.m_allocated_treeView.ImageIndex = 0;
            this.m_allocated_treeView.ImageList = this.m_tree_imageList;
            this.m_allocated_treeView.Indent = 19;
            this.m_allocated_treeView.ItemHeight = 16;
            this.m_allocated_treeView.Location = new System.Drawing.Point(0, 40);
            this.m_allocated_treeView.Name = "m_allocated_treeView";
            this.m_allocated_treeView.RightToLeftLayout = true;
            this.m_allocated_treeView.SelectedImageIndex = 0;
            this.m_allocated_treeView.Size = new System.Drawing.Size(168, 490);
            this.m_allocated_treeView.TabIndex = 2;
            this.m_allocated_treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_allocated_treeView_DragDrop);
            this.m_allocated_treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_allocated_treeView_AfterSelect);
            this.m_allocated_treeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_allocated_treeView_DragEnter);
            this.m_allocated_treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_allocated_treeView_ItemDrag);
            this.m_allocated_treeView.DragOver += new System.Windows.Forms.DragEventHandler(this.m_allocated_treeView_DragOver);
            // 
            // m_tree_imageList
            // 
            this.m_tree_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_tree_imageList.ImageStream")));
            this.m_tree_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_tree_imageList.Images.SetKeyName(0, "");
            this.m_tree_imageList.Images.SetKeyName(1, "folder1.png");
            this.m_tree_imageList.Images.SetKeyName(2, "");
            this.m_tree_imageList.Images.SetKeyName(3, "pictures.png");
            this.m_tree_imageList.Images.SetKeyName(4, "Font.png");
            this.m_tree_imageList.Images.SetKeyName(5, "");
            this.m_tree_imageList.Images.SetKeyName(6, "");
            this.m_tree_imageList.Images.SetKeyName(7, "");
            this.m_tree_imageList.Images.SetKeyName(8, "");
            this.m_tree_imageList.Images.SetKeyName(9, "");
            // 
            // m_avaliable_header_label
            // 
            this.m_avaliable_header_label.BackColor = System.Drawing.Color.CadetBlue;
            this.m_avaliable_header_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_avaliable_header_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_avaliable_header_label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.m_avaliable_header_label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.m_avaliable_header_label.Image = ((System.Drawing.Image)(resources.GetObject("m_avaliable_header_label.Image")));
            this.m_avaliable_header_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_avaliable_header_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_avaliable_header_label.Location = new System.Drawing.Point(0, 0);
            this.m_avaliable_header_label.Name = "m_avaliable_header_label";
            this.m_avaliable_header_label.Size = new System.Drawing.Size(168, 40);
            this.m_avaliable_header_label.TabIndex = 0;
            this.m_avaliable_header_label.Text = "     ÂíÊã åÇí Çíä ÒÇÑÔ";
            this.m_avaliable_header_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_available_treeView
            // 
            this.m_available_treeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_available_treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_available_treeView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.m_available_treeView.FullRowSelect = true;
            this.m_available_treeView.ImageIndex = 0;
            this.m_available_treeView.ImageList = this.m_tree_imageList;
            this.m_available_treeView.Indent = 19;
            this.m_available_treeView.ItemHeight = 16;
            this.m_available_treeView.Location = new System.Drawing.Point(0, 40);
            this.m_available_treeView.Name = "m_available_treeView";
            this.m_available_treeView.RightToLeftLayout = true;
            this.m_available_treeView.SelectedImageIndex = 0;
            this.m_available_treeView.Size = new System.Drawing.Size(224, 124);
            this.m_available_treeView.TabIndex = 2;
            this.m_available_treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_available_treeView_ItemDrag);
            // 
            // m_right_panel
            // 
            this.m_right_panel.Controls.Add(this.m_placed_panel);
            this.m_right_panel.Controls.Add(this.m_property_panel);
            this.m_right_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_right_panel.Location = new System.Drawing.Point(608, 0);
            this.m_right_panel.Name = "m_right_panel";
            this.m_right_panel.Size = new System.Drawing.Size(224, 530);
            this.m_right_panel.TabIndex = 2;
            // 
            // m_placed_panel
            // 
            this.m_placed_panel.Controls.Add(this.m_available_treeView);
            this.m_placed_panel.Controls.Add(this.m_placed_header_label);
            this.m_placed_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_placed_panel.Location = new System.Drawing.Point(0, 0);
            this.m_placed_panel.Name = "m_placed_panel";
            this.m_placed_panel.Size = new System.Drawing.Size(224, 164);
            this.m_placed_panel.TabIndex = 2;
            // 
            // m_placed_header_label
            // 
            this.m_placed_header_label.BackColor = System.Drawing.Color.CadetBlue;
            this.m_placed_header_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_placed_header_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_placed_header_label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.m_placed_header_label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.m_placed_header_label.Image = ((System.Drawing.Image)(resources.GetObject("m_placed_header_label.Image")));
            this.m_placed_header_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_placed_header_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_placed_header_label.Location = new System.Drawing.Point(0, 0);
            this.m_placed_header_label.Name = "m_placed_header_label";
            this.m_placed_header_label.Size = new System.Drawing.Size(224, 40);
            this.m_placed_header_label.TabIndex = 1;
            this.m_placed_header_label.Text = "ÇÈÒÇÑåÇí ÒÇÑÔ ÓÇÒ";
            this.m_placed_header_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_property_panel
            // 
            this.m_property_panel.Controls.Add(this.m_propertyGrid);
            this.m_property_panel.Controls.Add(this.m_property_header_label);
            this.m_property_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_property_panel.Location = new System.Drawing.Point(0, 164);
            this.m_property_panel.Name = "m_property_panel";
            this.m_property_panel.Size = new System.Drawing.Size(224, 366);
            this.m_property_panel.TabIndex = 0;
            // 
            // m_propertyGrid
            // 
            this.m_propertyGrid.CommandsBackColor = System.Drawing.Color.LightSteelBlue;
            this.m_propertyGrid.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.m_propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_propertyGrid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.m_propertyGrid.HelpBackColor = System.Drawing.Color.LightYellow;
            this.m_propertyGrid.HelpForeColor = System.Drawing.SystemColors.ControlLight;
            this.m_propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.m_propertyGrid.Location = new System.Drawing.Point(0, 40);
            this.m_propertyGrid.Name = "m_propertyGrid";
            this.m_propertyGrid.Size = new System.Drawing.Size(224, 326);
            this.m_propertyGrid.TabIndex = 3;
            this.m_propertyGrid.ToolbarVisible = false;
            // 
            // m_property_header_label
            // 
            this.m_property_header_label.BackColor = System.Drawing.Color.CadetBlue;
            this.m_property_header_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_property_header_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_property_header_label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.m_property_header_label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.m_property_header_label.Image = ((System.Drawing.Image)(resources.GetObject("m_property_header_label.Image")));
            this.m_property_header_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_property_header_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_property_header_label.Location = new System.Drawing.Point(0, 0);
            this.m_property_header_label.Name = "m_property_header_label";
            this.m_property_header_label.Size = new System.Drawing.Size(224, 40);
            this.m_property_header_label.TabIndex = 2;
            this.m_property_header_label.Text = "ÎÇÕíÊ åÇ";
            this.m_property_header_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_center_panel
            // 
            this.m_center_panel.Controls.Add(this.m_designer_tabControl);
            this.m_center_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_center_panel.Location = new System.Drawing.Point(0, 0);
            this.m_center_panel.Name = "m_center_panel";
            this.m_center_panel.Size = new System.Drawing.Size(840, 576);
            this.m_center_panel.TabIndex = 4;
            // 
            // m_designer_tabControl
            // 
            this.m_designer_tabControl.Controls.Add(this.m_designer_layout_tabPage);
            this.m_designer_tabControl.Controls.Add(this.m_designer_preview_tabPage);
            this.m_designer_tabControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_designer_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_designer_tabControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.m_designer_tabControl.ImageList = this.m_tab_imageList;
            this.m_designer_tabControl.ItemSize = new System.Drawing.Size(94, 38);
            this.m_designer_tabControl.Location = new System.Drawing.Point(0, 0);
            this.m_designer_tabControl.Name = "m_designer_tabControl";
            this.m_designer_tabControl.RightToLeftLayout = true;
            this.m_designer_tabControl.SelectedIndex = 0;
            this.m_designer_tabControl.ShowToolTips = true;
            this.m_designer_tabControl.Size = new System.Drawing.Size(840, 576);
            this.m_designer_tabControl.TabIndex = 0;
            this.m_designer_tabControl.SelectedIndexChanged += new System.EventHandler(this.m_designer_tabControl_SelectedIndexChanged);
            this.m_designer_tabControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_designer_tabControl_KeyDown);
            // 
            // m_designer_layout_tabPage
            // 
            this.m_designer_layout_tabPage.Controls.Add(this.m_designer_panel);
            this.m_designer_layout_tabPage.Controls.Add(this.m_designer_layout_toolBar);
            this.m_designer_layout_tabPage.Controls.Add(this.splitter2);
            this.m_designer_layout_tabPage.Controls.Add(this.splitter1);
            this.m_designer_layout_tabPage.Controls.Add(this.m_left_panel);
            this.m_designer_layout_tabPage.Controls.Add(this.m_right_panel);
            this.m_designer_layout_tabPage.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_designer_layout_tabPage.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.m_designer_layout_tabPage.ImageKey = "design.png";
            this.m_designer_layout_tabPage.Location = new System.Drawing.Point(4, 42);
            this.m_designer_layout_tabPage.Name = "m_designer_layout_tabPage";
            this.m_designer_layout_tabPage.Size = new System.Drawing.Size(832, 530);
            this.m_designer_layout_tabPage.TabIndex = 0;
            this.m_designer_layout_tabPage.Text = "ØÑÇÍí ÒÇÑÔ";
            this.m_designer_layout_tabPage.UseVisualStyleBackColor = true;
            // 
            // m_designer_panel
            // 
            this.m_designer_panel.AutoScroll = true;
            this.m_designer_panel.Controls.Add(this.m_designer_layout_panel);
            this.m_designer_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_designer_panel.Location = new System.Drawing.Point(171, 32);
            this.m_designer_panel.Name = "m_designer_panel";
            this.m_designer_panel.Padding = new System.Windows.Forms.Padding(10);
            this.m_designer_panel.Size = new System.Drawing.Size(434, 498);
            this.m_designer_panel.TabIndex = 2;
            // 
            // m_designer_layout_panel
            // 
            this.m_designer_layout_panel.AutoScroll = true;
            this.m_designer_layout_panel.BackColor = System.Drawing.SystemColors.Control;
            this.m_designer_layout_panel.Controls.Add(this.m_draw_panel);
            this.m_designer_layout_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_designer_layout_panel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.m_designer_layout_panel.Location = new System.Drawing.Point(10, 10);
            this.m_designer_layout_panel.Name = "m_designer_layout_panel";
            this.m_designer_layout_panel.Padding = new System.Windows.Forms.Padding(10);
            this.m_designer_layout_panel.Size = new System.Drawing.Size(414, 478);
            this.m_designer_layout_panel.TabIndex = 1;
            this.m_designer_layout_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_designer_layout_panel_MouseDown);
            this.m_designer_layout_panel.Resize += new System.EventHandler(this.m_designer_layout_panel_Resize);
            // 
            // contextMenu_Design
            // 
            this.contextMenu_Design.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCopy,
            this.toolStripCut,
            this.toolStripPaste,
            this.toolStripDelete});
            this.contextMenu_Design.Name = "contextMenu_Design";
            this.contextMenu_Design.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenu_Design.Size = new System.Drawing.Size(117, 92);
            // 
            // toolStripCopy
            // 
            this.toolStripCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCopy.Image")));
            this.toolStripCopy.Name = "toolStripCopy";
            this.toolStripCopy.Size = new System.Drawing.Size(116, 22);
            this.toolStripCopy.Text = "ßí";
            this.toolStripCopy.Click += new System.EventHandler(this.toolStripCopy_Click);
            // 
            // toolStripCut
            // 
            this.toolStripCut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCut.Image")));
            this.toolStripCut.Name = "toolStripCut";
            this.toolStripCut.Size = new System.Drawing.Size(116, 22);
            this.toolStripCut.Text = "ÈÑÔ";
            this.toolStripCut.Click += new System.EventHandler(this.toolStripCut_Click);
            // 
            // toolStripPaste
            // 
            this.toolStripPaste.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPaste.Image")));
            this.toolStripPaste.Name = "toolStripPaste";
            this.toolStripPaste.Size = new System.Drawing.Size(116, 22);
            this.toolStripPaste.Text = "ÌÇíÐÇÑí";
            this.toolStripPaste.Click += new System.EventHandler(this.toolStripPaste_Click);
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDelete.Image")));
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(116, 22);
            this.toolStripDelete.Text = "ÍÐÝ";
            this.toolStripDelete.Click += new System.EventHandler(this.toolStripDelete_Click);
            // 
            // m_designer_layout_toolBar
            // 
            this.m_designer_layout_toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.m_designer_layout_toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.m_edit_cut_toolBarButton,
            this.m_edit_copy_toolBarButton,
            this.m_edit_paste_toolBarButton,
            this.toolBarButton1,
            this.m_edit_delete_toolBarButton,
            this.toolBarButton2,
            this.m_format_align_left_toolBarButton,
            this.m_format_align_vcentre_toolBarButton,
            this.m_format_align_right_toolBarButton,
            this.toolBarButton3,
            this.m_format_align_top_toolBarButton,
            this.m_format_align_hcentre_toolBarButton,
            this.m_format_align_bottom_toolBarButton,
            this.toolBarButton4,
            this.m_format_same_width_max_toolBarButton,
            this.m_format_same_height_max_toolBarButton,
            this.m_format_same_width_min_toolBarButton,
            this.m_format_same_height_min_toolBarButton});
            this.m_designer_layout_toolBar.ButtonSize = new System.Drawing.Size(23, 22);
            this.m_designer_layout_toolBar.DropDownArrows = true;
            this.m_designer_layout_toolBar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.m_designer_layout_toolBar.ImageList = this.m_toolbar_imageList;
            this.m_designer_layout_toolBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_designer_layout_toolBar.Location = new System.Drawing.Point(171, 0);
            this.m_designer_layout_toolBar.Name = "m_designer_layout_toolBar";
            this.m_designer_layout_toolBar.ShowToolTips = true;
            this.m_designer_layout_toolBar.Size = new System.Drawing.Size(434, 32);
            this.m_designer_layout_toolBar.TabIndex = 3;
            this.m_designer_layout_toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.m_designer_layout_toolBar_ButtonClick);
            // 
            // m_edit_cut_toolBarButton
            // 
            this.m_edit_cut_toolBarButton.ImageIndex = 3;
            this.m_edit_cut_toolBarButton.Name = "m_edit_cut_toolBarButton";
            this.m_edit_cut_toolBarButton.ToolTipText = "Cut selected items and insert into clipboard ";
            // 
            // m_edit_copy_toolBarButton
            // 
            this.m_edit_copy_toolBarButton.ImageIndex = 4;
            this.m_edit_copy_toolBarButton.Name = "m_edit_copy_toolBarButton";
            this.m_edit_copy_toolBarButton.ToolTipText = "Copy selected items to clipboard ";
            // 
            // m_edit_paste_toolBarButton
            // 
            this.m_edit_paste_toolBarButton.ImageIndex = 5;
            this.m_edit_paste_toolBarButton.Name = "m_edit_paste_toolBarButton";
            this.m_edit_paste_toolBarButton.ToolTipText = "Paste items from clipboard";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // m_edit_delete_toolBarButton
            // 
            this.m_edit_delete_toolBarButton.ImageIndex = 6;
            this.m_edit_delete_toolBarButton.Name = "m_edit_delete_toolBarButton";
            this.m_edit_delete_toolBarButton.ToolTipText = "Delete selected items";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // m_format_align_left_toolBarButton
            // 
            this.m_format_align_left_toolBarButton.ImageIndex = 11;
            this.m_format_align_left_toolBarButton.Name = "m_format_align_left_toolBarButton";
            this.m_format_align_left_toolBarButton.ToolTipText = "Align left";
            // 
            // m_format_align_vcentre_toolBarButton
            // 
            this.m_format_align_vcentre_toolBarButton.ImageIndex = 10;
            this.m_format_align_vcentre_toolBarButton.Name = "m_format_align_vcentre_toolBarButton";
            this.m_format_align_vcentre_toolBarButton.ToolTipText = "Align centers vertically";
            // 
            // m_format_align_right_toolBarButton
            // 
            this.m_format_align_right_toolBarButton.ImageIndex = 12;
            this.m_format_align_right_toolBarButton.Name = "m_format_align_right_toolBarButton";
            this.m_format_align_right_toolBarButton.ToolTipText = "Align right";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // m_format_align_top_toolBarButton
            // 
            this.m_format_align_top_toolBarButton.ImageIndex = 13;
            this.m_format_align_top_toolBarButton.Name = "m_format_align_top_toolBarButton";
            this.m_format_align_top_toolBarButton.ToolTipText = "Align top";
            // 
            // m_format_align_hcentre_toolBarButton
            // 
            this.m_format_align_hcentre_toolBarButton.ImageIndex = 14;
            this.m_format_align_hcentre_toolBarButton.Name = "m_format_align_hcentre_toolBarButton";
            this.m_format_align_hcentre_toolBarButton.ToolTipText = "Align centers horizontally";
            // 
            // m_format_align_bottom_toolBarButton
            // 
            this.m_format_align_bottom_toolBarButton.ImageIndex = 9;
            this.m_format_align_bottom_toolBarButton.Name = "m_format_align_bottom_toolBarButton";
            this.m_format_align_bottom_toolBarButton.ToolTipText = "Align bottom";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // m_format_same_width_max_toolBarButton
            // 
            this.m_format_same_width_max_toolBarButton.ImageIndex = 17;
            this.m_format_same_width_max_toolBarButton.Name = "m_format_same_width_max_toolBarButton";
            this.m_format_same_width_max_toolBarButton.ToolTipText = "Make same width as largest control";
            // 
            // m_format_same_height_max_toolBarButton
            // 
            this.m_format_same_height_max_toolBarButton.ImageIndex = 15;
            this.m_format_same_height_max_toolBarButton.Name = "m_format_same_height_max_toolBarButton";
            this.m_format_same_height_max_toolBarButton.ToolTipText = "Make same height as largest control";
            // 
            // m_format_same_width_min_toolBarButton
            // 
            this.m_format_same_width_min_toolBarButton.ImageIndex = 19;
            this.m_format_same_width_min_toolBarButton.Name = "m_format_same_width_min_toolBarButton";
            this.m_format_same_width_min_toolBarButton.ToolTipText = "Make same width as smallest control";
            // 
            // m_format_same_height_min_toolBarButton
            // 
            this.m_format_same_height_min_toolBarButton.ImageIndex = 18;
            this.m_format_same_height_min_toolBarButton.Name = "m_format_same_height_min_toolBarButton";
            this.m_format_same_height_min_toolBarButton.ToolTipText = "Make same height as smallest control";
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.DarkGray;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitter2.Location = new System.Drawing.Point(605, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 530);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.DarkGray;
            this.splitter1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitter1.Location = new System.Drawing.Point(168, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 530);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // m_designer_preview_tabPage
            // 
            this.m_designer_preview_tabPage.Controls.Add(this.m_preview_control);
            this.m_designer_preview_tabPage.Controls.Add(this.m_preview_toolBar);
            this.m_designer_preview_tabPage.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_designer_preview_tabPage.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.m_designer_preview_tabPage.ImageKey = "print-preview.png";
            this.m_designer_preview_tabPage.Location = new System.Drawing.Point(4, 42);
            this.m_designer_preview_tabPage.Name = "m_designer_preview_tabPage";
            this.m_designer_preview_tabPage.Size = new System.Drawing.Size(832, 530);
            this.m_designer_preview_tabPage.TabIndex = 1;
            this.m_designer_preview_tabPage.Text = "ãÔÇåÏå ÒÑÇÔ";
            this.m_designer_preview_tabPage.UseVisualStyleBackColor = true;
            // 
            // m_preview_control
            // 
            this.m_preview_control.AutoZoom = false;
            this.m_preview_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_preview_control.Location = new System.Drawing.Point(0, 40);
            this.m_preview_control.Name = "m_preview_control";
            this.m_preview_control.Size = new System.Drawing.Size(832, 490);
            this.m_preview_control.TabIndex = 0;
            // 
            // m_preview_toolBar
            // 
            this.m_preview_toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.m_preview_toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.m_preview_print_toolBarButton,
            this.toolBarButton5,
            this.m_preview_zoom_toolBarButton,
            this.toolBarButton6,
            this.m_preview_prev_toolBarButton,
            this.m_preview_next_toolBarButton});
            this.m_preview_toolBar.ButtonSize = new System.Drawing.Size(40, 30);
            this.m_preview_toolBar.DropDownArrows = true;
            this.m_preview_toolBar.ImageList = this.m_toolbar_imageList;
            this.m_preview_toolBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_preview_toolBar.Location = new System.Drawing.Point(0, 0);
            this.m_preview_toolBar.Name = "m_preview_toolBar";
            this.m_preview_toolBar.ShowToolTips = true;
            this.m_preview_toolBar.Size = new System.Drawing.Size(832, 40);
            this.m_preview_toolBar.TabIndex = 1;
            this.m_preview_toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.m_preview_toolBar_ButtonClick);
            // 
            // m_preview_print_toolBarButton
            // 
            this.m_preview_print_toolBarButton.ImageIndex = 20;
            this.m_preview_print_toolBarButton.Name = "m_preview_print_toolBarButton";
            this.m_preview_print_toolBarButton.ToolTipText = "Print this document";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // m_preview_zoom_toolBarButton
            // 
            this.m_preview_zoom_toolBarButton.DropDownMenu = this.m_zoom_contextMenu;
            this.m_preview_zoom_toolBarButton.ImageIndex = 21;
            this.m_preview_zoom_toolBarButton.Name = "m_preview_zoom_toolBarButton";
            this.m_preview_zoom_toolBarButton.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.m_preview_zoom_toolBarButton.ToolTipText = "Zoom";
            // 
            // m_zoom_contextMenu
            // 
            this.m_zoom_contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_zoom_auto_menuItem,
            this.m_zoom_perc_200_menuItem,
            this.m_zoom_perc_150_menuItem,
            this.m_zoom_perc_100_menuItem,
            this.m_zoom_perc_75_menuItem,
            this.m_zoom_perc_50_menuItem,
            this.m_zoom_perc_25_menuItem,
            this.m_zoom_perc_10_menuItem});
            // 
            // m_zoom_auto_menuItem
            // 
            this.m_zoom_auto_menuItem.Checked = true;
            this.m_zoom_auto_menuItem.Index = 0;
            this.m_zoom_auto_menuItem.Text = "&Auto";
            this.m_zoom_auto_menuItem.Click += new System.EventHandler(this.m_zoom_auto_menuItem_Click);
            // 
            // m_zoom_perc_200_menuItem
            // 
            this.m_zoom_perc_200_menuItem.Index = 1;
            this.m_zoom_perc_200_menuItem.Text = "200 %";
            this.m_zoom_perc_200_menuItem.Click += new System.EventHandler(this.m_zoom_perc_200_menuItem_Click);
            // 
            // m_zoom_perc_150_menuItem
            // 
            this.m_zoom_perc_150_menuItem.Index = 2;
            this.m_zoom_perc_150_menuItem.Text = "150 %";
            this.m_zoom_perc_150_menuItem.Click += new System.EventHandler(this.m_zoom_perc_150_menuItem_Click);
            // 
            // m_zoom_perc_100_menuItem
            // 
            this.m_zoom_perc_100_menuItem.Index = 3;
            this.m_zoom_perc_100_menuItem.Text = "100 %";
            this.m_zoom_perc_100_menuItem.Click += new System.EventHandler(this.m_zoom_perc_100_menuItem_Click);
            // 
            // m_zoom_perc_75_menuItem
            // 
            this.m_zoom_perc_75_menuItem.Index = 4;
            this.m_zoom_perc_75_menuItem.Text = "75 %";
            this.m_zoom_perc_75_menuItem.Click += new System.EventHandler(this.m_zoom_perc_75_menuItem_Click);
            // 
            // m_zoom_perc_50_menuItem
            // 
            this.m_zoom_perc_50_menuItem.Index = 5;
            this.m_zoom_perc_50_menuItem.Text = "50 %";
            this.m_zoom_perc_50_menuItem.Click += new System.EventHandler(this.m_zoom_perc_50_menuItem_Click);
            // 
            // m_zoom_perc_25_menuItem
            // 
            this.m_zoom_perc_25_menuItem.Index = 6;
            this.m_zoom_perc_25_menuItem.Text = "25 %";
            this.m_zoom_perc_25_menuItem.Click += new System.EventHandler(this.m_zoom_perc_25_menuItem_Click);
            // 
            // m_zoom_perc_10_menuItem
            // 
            this.m_zoom_perc_10_menuItem.Index = 7;
            this.m_zoom_perc_10_menuItem.Text = "10 %";
            this.m_zoom_perc_10_menuItem.Click += new System.EventHandler(this.m_zoom_perc_10_menuItem_Click);
            // 
            // toolBarButton6
            // 
            this.toolBarButton6.Name = "toolBarButton6";
            this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // m_preview_prev_toolBarButton
            // 
            this.m_preview_prev_toolBarButton.ImageIndex = 22;
            this.m_preview_prev_toolBarButton.Name = "m_preview_prev_toolBarButton";
            this.m_preview_prev_toolBarButton.ToolTipText = "Show previous page";
            // 
            // m_preview_next_toolBarButton
            // 
            this.m_preview_next_toolBarButton.ImageIndex = 23;
            this.m_preview_next_toolBarButton.Name = "m_preview_next_toolBarButton";
            this.m_preview_next_toolBarButton.ToolTipText = "Show next page";
            // 
            // m_tab_imageList
            // 
            this.m_tab_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_tab_imageList.ImageStream")));
            this.m_tab_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_tab_imageList.Images.SetKeyName(0, "design.png");
            this.m_tab_imageList.Images.SetKeyName(1, "print-preview.png");
            // 
            // m_drag_drop_timer
            // 
            this.m_drag_drop_timer.Interval = 1500;
            this.m_drag_drop_timer.Tick += new System.EventHandler(this.m_drag_drop_timer_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Xml File | *.xml";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Xml File | *.xml";
            // 
            // m_draw_panel
            // 
            this.m_draw_panel.BackColor = System.Drawing.Color.White;
            this.m_draw_panel.ContextMenuStrip = this.contextMenu_Design;
            this.m_draw_panel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.m_draw_panel.Location = new System.Drawing.Point(4194176, 16);
            this.m_draw_panel.Name = "m_draw_panel";
            this.m_draw_panel.SelectedObjects = null;
            this.m_draw_panel.Size = new System.Drawing.Size(392, 430);
            this.m_draw_panel.TabIndex = 0;
            this.m_draw_panel.SelectedObjectsChanged += new System.EventHandler(this.m_draw_panel_SelectedObjectsChanged);
            // 
            // RPFDesignerControl
            // 
            this.Controls.Add(this.m_center_panel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "RPFDesignerControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(840, 576);
            this.Load += new System.EventHandler(this.RPFDesignerControl_Load);
            this.m_left_panel.ResumeLayout(false);
            this.m_available_panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.m_right_panel.ResumeLayout(false);
            this.m_placed_panel.ResumeLayout(false);
            this.m_property_panel.ResumeLayout(false);
            this.m_center_panel.ResumeLayout(false);
            this.m_designer_tabControl.ResumeLayout(false);
            this.m_designer_layout_tabPage.ResumeLayout(false);
            this.m_designer_layout_tabPage.PerformLayout();
            this.m_designer_panel.ResumeLayout(false);
            this.m_designer_layout_panel.ResumeLayout(false);
            this.contextMenu_Design.ResumeLayout(false);
            this.m_designer_preview_tabPage.ResumeLayout(false);
            this.m_designer_preview_tabPage.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void DoLayout() {
			try {
				this.SuspendLayout();
				System.Drawing.Size draw_size= this.m_draw_panel.Size;
				System.Drawing.Size designer_size= this.m_designer_layout_panel.Size;
				System.Drawing.Point pos= new System.Drawing.Point( );
				if( designer_size.Width>= draw_size.Width)
					pos.X= ( designer_size.Width- ( draw_size.Width))>> 1;
				if( designer_size.Height>= draw_size.Height)
					pos.Y= ( designer_size.Height- ( draw_size.Height))>> 1;
				this.m_draw_panel.Location= pos;
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
			finally {
				this.ResumeLayout();
			}
		}

		private void m_designer_layout_toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e) {
			if( e.Button== this.m_edit_delete_toolBarButton) {
				this.DoEditDelete( true);
				return;
			}
			if( e.Button== this.m_edit_copy_toolBarButton) {
				this.DoEditCopy( );
				return;
			}
			if( e.Button== this.m_edit_paste_toolBarButton) {
				this.DoEditPaste( );
				return;
			}
			if( e.Button== this.m_edit_cut_toolBarButton) {
				this.DoEditCut( );
				return;
			}
			if( e.Button== this.m_format_align_bottom_toolBarButton) {
				this.DoFormatAlignBottom( );
				return;
			}
			if( e.Button== this.m_format_align_top_toolBarButton) {
				this.DoFormatAlignTop( );
				return;
			}
			if( e.Button== this.m_format_align_left_toolBarButton) {
				this.DoFormatAlignLeft( );
				return;
			}
			if( e.Button== this.m_format_align_right_toolBarButton) {
				this.DoFormatAlignRight( );
				return;
			}
			if( e.Button== this.m_format_align_vcentre_toolBarButton) {
				this.DoFormatAlignVCentre( );
				return;
			}
			if( e.Button== this.m_format_align_hcentre_toolBarButton) {
				this.DoFormatAlignHCentre( );
				return;
			}
			if( e.Button== this.m_format_same_width_max_toolBarButton) {
				this.DoFormatSameWidthMax( );
				return;
			}
			if( e.Button== this.m_format_same_width_min_toolBarButton) {
				this.DoFormatSameWidthMin( );
				return;
			}
			if( e.Button== this.m_format_same_height_max_toolBarButton) {
				this.DoFormatSameHeightMax( );
				return;
			}
			if( e.Button== this.m_format_same_height_min_toolBarButton) {
				this.DoFormatSameHeightMin( );
				return;
			}
		}
		private void DoFormatSameHeightMin() {
			try {
				if( !this.CanFormat)
					return;
				// size to max height
				float height= float.MaxValue;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					float tmp= this.m_draw_panel.SelectedObjects[i].Size.Height;
					if( height> tmp)
						height= tmp;
				}
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					this.m_draw_panel.SelectedObjects[ i].Size.Height= height;
				}
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private void DoFormatSameHeightMax() {
			try {
				if( !this.CanFormat)
					return;
				// size to max height
				float height= float.MinValue;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					float tmp= this.m_draw_panel.SelectedObjects[i].Size.Height;
					if( height< tmp)
						height= tmp;
				}
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					this.m_draw_panel.SelectedObjects[ i].Size.Height= height;
				}
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private void DoFormatSameWidthMin() {
			try {
				if( !this.CanFormat)
					return;
				// size to width min
				float width= float.MaxValue;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					float tmp= this.m_draw_panel.SelectedObjects[i].Size.Width;
					if( width> tmp)
						width= tmp;
				}
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					this.m_draw_panel.SelectedObjects[ i].Size.Width= width;
				}
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private void DoFormatSameWidthMax() {
			try {
				if( !this.CanFormat)
					return;
				// size to width max
				float width= float.MinValue;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					float tmp= this.m_draw_panel.SelectedObjects[i].Size.Width;
					if( width< tmp)
						width= tmp;
				}
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					this.m_draw_panel.SelectedObjects[ i].Size.Width= width;
				}
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private void DoFormatAlignVCentre() {
			try {
				if( !this.CanFormat)
					return;
				// Align to V centre
				float vcentre= 0;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					vcentre+= this.m_draw_panel.SelectedObjects[i].Location.X+ this.m_draw_panel.SelectedObjects[i].Size.Width*0.5f;
				}
				vcentre/= this.m_draw_panel.SelectedObjects.Length;
//				float vcentre= this.m_draw_panel.SelectedObjects[0].Location.X+ this.m_draw_panel.SelectedObjects[0].Size.Width*0.5f;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					this.m_draw_panel.SelectedObjects[ i].Location.X= vcentre- this.m_draw_panel.SelectedObjects[ i].Size.Width* 0.5f;
				}
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private void DoFormatAlignHCentre() {
			try {
				if( !this.CanFormat)
					return;
				// Align to H centre
				float hcentre= 0;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					hcentre+= this.m_draw_panel.SelectedObjects[i].Location.Y+ this.m_draw_panel.SelectedObjects[i].Size.Height*0.5f;
				}
				hcentre/= this.m_draw_panel.SelectedObjects.Length;
//				float hcentre= this.m_draw_panel.SelectedObjects[0].Location.Y+ this.m_draw_panel.SelectedObjects[0].Size.Height*0.5f;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					this.m_draw_panel.SelectedObjects[ i].Location.Y= hcentre- this.m_draw_panel.SelectedObjects[ i].Size.Height* 0.5f;
				}
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private void DoFormatAlignBottom() {
			try {
				if( !this.CanFormat)
					return;
				// Align to bottom
				float bottom= float.MinValue;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					float tmp= this.m_draw_panel.SelectedObjects[i].Location.Y+ this.m_draw_panel.SelectedObjects[i].Size.Height;
					if( bottom< tmp)
						bottom= tmp;
				}
//				float bottom= this.m_draw_panel.SelectedObjects[0].Location.Y+ this.m_draw_panel.SelectedObjects[0].Size.Height;				
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					this.m_draw_panel.SelectedObjects[ i].Location.Y= bottom- this.m_draw_panel.SelectedObjects[ i].Size.Height;
				}
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private void DoFormatAlignTop() {
			try {
				if( !this.CanFormat)
					return;
				// Align to top
				float top= float.MaxValue;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					float tmp= this.m_draw_panel.SelectedObjects[i].Location.Y;
					if( top> tmp)
						top= tmp;
				}
//				float top= this.m_draw_panel.SelectedObjects[0].Location.Y;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					this.m_draw_panel.SelectedObjects[ i].Location.Y= top;
				}
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private void DoFormatAlignLeft() {
			try {
				if( !this.CanFormat)
					return;
				// Align to left
				float left= float.MaxValue;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					float tmp= this.m_draw_panel.SelectedObjects[i].Location.X;
					if( left> tmp)
						left= tmp;
				}
//				float left= this.m_draw_panel.SelectedObjects[0].Location.X;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					this.m_draw_panel.SelectedObjects[ i].Location.X= left;
				}
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private void DoFormatAlignRight() {
			try {
				if( !this.CanFormat)
					return;
				// Align to right
				float right= float.MinValue;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					float tmp= this.m_draw_panel.SelectedObjects[i].Location.X+ this.m_draw_panel.SelectedObjects[i].Size.Width;
					if( right< tmp)
						right= tmp;
				}
//				float right= this.m_draw_panel.SelectedObjects[0].Location.X+ this.m_draw_panel.SelectedObjects[0].Size.Width;
				for( int i= 0; i< this.m_draw_panel.SelectedObjects.Length; i++) {
					this.m_draw_panel.SelectedObjects[ i].Location.X= right- this.m_draw_panel.SelectedObjects[i].Size.Width;
				}
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private void DoEditCut( ) {
			try {
				if( !this.CanEditCopy|| !this.CanEditDelete)
					return;
				this.DoEditCopy();
				this.DoEditDelete( false);
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private void DoEditPaste( ) {
			try {
				if( !this.CanEditPaste)
					return;
				// Paste items to clipboard
				IRPFObject[] pasted_objects= new IRPFObject[ RPFClipboard.RPFObjects.Length];
				IRPFObject rpf_object= this.m_draw_panel.SelectedObjects[0];
				if( rpf_object is RPFDocument) {
					// Add Section to document
					for( int i= 0; i< RPFClipboard.RPFObjects.Length; i++) {
						pasted_objects[ i]= RPFClipboard.RPFObjects[ i];
						((RPFDocument)rpf_object).ElementList.Add( pasted_objects[ i]);
						this.DoAddChildRequest( (( RPFObjectTag)rpf_object.Tag).m_host_control, pasted_objects[ i]);
					}
				} else { 
					for( int i= 0; i< RPFClipboard.RPFObjects.Length; i++) {
						pasted_objects[ i]= RPFClipboard.RPFObjects[ i];
						pasted_objects[ i].Location.X+= this.m_last_paste_delta;
						pasted_objects[ i].Location.Y+= this.m_last_paste_delta;
						this.m_last_paste_delta+= PASTE_DELTA;
						((RPFSection)rpf_object).ElementList.Add( pasted_objects[ i]);
						this.DoAddChildRequest( (( RPFObjectTag)rpf_object.Tag).m_host_control, pasted_objects[ i]);
					}
				}
				this.m_draw_panel.SelectedObjects= pasted_objects;
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private void DoEditCopy( ) {
			try {
				if( !this.CanEditCopy)
					return;
				// Copy items to clipboard
				RPFClipboard.RPFObjects= this.m_draw_panel.SelectedObjects;
				this.UpdateToolbar();
				this.m_last_paste_delta= PASTE_DELTA;
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private void DoEditDelete( bool prompt) {
			try {
				if( !this.CanEditDelete)
					return;
				// Prompt user
				if( prompt) {
					if( MessageBox.Show( this
                        , Helper.GetLocalString( "id_designer_prompt_delete")
                        , "", MessageBoxButtons.OKCancel
                        , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)!= DialogResult.OK)
						return;
                    //MessageBoxFa.Show("ÓáÇã ØæÑí", "", MessageBoxButtons.OK, MessageBoxIcon.Information
                    //, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
				}
				// Delete items
				foreach( IRPFObject rpf_object in this.m_draw_panel.SelectedObjects) {
					// Remove item
					RPFObjectTag object_tag= ( RPFObjectTag) rpf_object.Tag;
					RPFObjectTag container_tag= ( RPFObjectTag) ((IRPFObject)object_tag.m_allocated_tree_node.Parent.Tag).Tag;
					ITrackerControlContainer container= ( ITrackerControlContainer)container_tag.m_host_control;
					object_tag.m_allocated_tree_node.Remove();
					container.RemoveChild( object_tag.m_host_control);
				}
				this.m_propertyGrid.SelectedObjects= null;
			}
			catch( Exception excp) {
				Helper.ShowException( excp);
			}
		}
		private enum TREE_IMAGE_INDEX {
			CONTAINER_NORMAL= 0,
			CONTAINER_SELECTED= 1,
			SECTION_NORMAL= 2,
			SECTION_SELECTED= 2,
			IMAGE_NORMAL= 3,
			IMAGE_SELECTED= 3,
			LABEL_NORMAL= 4,
			LABEL_SELECTED= 4,
			VARIABLE_NORMAL= 5,
			VARIABLE_SELECTED= 5,
			BOX_NORMAL= 6,
			BOX_SELECTED= 6,
			LINE_NORMAL= 7,
			LINE_SELECTED= 7,
			TABLE_ROW_NORMAL= 8,
			TABLE_ROW_SELECTED= 8,
			TABLE_COLUMN_NORMAL= 9,
			TABLE_COLUMN_SELECTED= 9,
		} 
		public struct AVAILABLE_TREE_DATA {
			public enum DATA_TYPE {
				FOLDER,
				SECTION,
				TABLE_ROW_SECTION,
				IMAGE,
				LABEL,
				VARIABLE,
				BOX,
				LINE,
				TABLE_COLUMN
			};
			public DATA_TYPE m_type;
			public object m_data;
		};
		private void FillAvailResourceTree() {
			try {
				this.m_available_treeView.BeginUpdate();
				this.m_available_treeView.Nodes.Clear();
				
				AVAILABLE_TREE_DATA node_data;
				// Root nodes
				TreeNode container_node= new TreeNode( Helper.GetLocalString( "id_designer_container_tree_node"), (int)TREE_IMAGE_INDEX.CONTAINER_NORMAL, (int)TREE_IMAGE_INDEX.CONTAINER_SELECTED);
				TreeNode static_node= new TreeNode( Helper.GetLocalString( "id_designer_static_tree_node"), (int)TREE_IMAGE_INDEX.CONTAINER_NORMAL, (int)TREE_IMAGE_INDEX.CONTAINER_SELECTED);
				TreeNode variable_node= new TreeNode( Helper.GetLocalString( "id_designer_variable_tree_node"), (int)TREE_IMAGE_INDEX.CONTAINER_NORMAL, (int)TREE_IMAGE_INDEX.CONTAINER_SELECTED);

				node_data= new AVAILABLE_TREE_DATA();
				node_data.m_type= AVAILABLE_TREE_DATA.DATA_TYPE.FOLDER;
				node_data.m_data= null;
				container_node.Tag= node_data;
				static_node.Tag= node_data;
				variable_node.Tag= node_data;

				this.m_available_treeView.Nodes.Add( container_node);
				this.m_available_treeView.Nodes.Add( static_node);
				if( this.m_rpf_report_maker.Variables.Keys.Count!= 0) {
					this.m_available_treeView.Nodes.Add( variable_node);
				}

				TreeNode node;
				//
				// Fill Containers nodes
				// Fixed Section 
				node= new TreeNode( Helper.GetLocalString( "id_designer_section_tree_node"), (int)TREE_IMAGE_INDEX.SECTION_NORMAL, (int)TREE_IMAGE_INDEX.SECTION_SELECTED);
				node_data= new AVAILABLE_TREE_DATA();
				node_data.m_type= AVAILABLE_TREE_DATA.DATA_TYPE.SECTION;
				node_data.m_data= null;
				node.Tag= node_data;
				container_node.Nodes.Add( node);

				// TableRow Section
				// Table row
				if( this.m_rpf_report_maker.Tables.Keys.Count!= 0) {
					TreeNode table_node= new TreeNode( Helper.GetLocalString( "id_designer_table_tree_node"), 0, 1);
					node_data= new AVAILABLE_TREE_DATA();
					node_data.m_type= AVAILABLE_TREE_DATA.DATA_TYPE.FOLDER;
					node_data.m_data= null;
					table_node.Tag= node_data;
					container_node.Nodes.Add( table_node);

					foreach( string name in this.m_rpf_report_maker.Tables.Keys) {
						node= new TreeNode( name, (int)TREE_IMAGE_INDEX.TABLE_ROW_NORMAL, (int)TREE_IMAGE_INDEX.TABLE_ROW_SELECTED);
						node_data= new AVAILABLE_TREE_DATA();
						node_data.m_type= AVAILABLE_TREE_DATA.DATA_TYPE.TABLE_ROW_SECTION;
						System.Data.DataTable table= ( System.Data.DataTable)this.m_rpf_report_maker.Tables[ name];
						node_data.m_data= name;
						node.Tag= node_data;
						table_node.Nodes.Add( node);
						for( int i= 0; i< table.Columns.Count; i++) {
							RPFTableColumn column= new RPFTableColumn();
							column.Name= table.Columns[ i].ColumnName;
							column.TableId= name;
							TreeNode col_node= new TreeNode( table.Columns[ i].ColumnName, (int)TREE_IMAGE_INDEX.TABLE_COLUMN_NORMAL, (int)TREE_IMAGE_INDEX.TABLE_COLUMN_SELECTED);
							AVAILABLE_TREE_DATA col_node_data;
							col_node_data= new AVAILABLE_TREE_DATA();
							col_node_data.m_type= AVAILABLE_TREE_DATA.DATA_TYPE.TABLE_COLUMN;
							col_node_data.m_data= column;
							col_node.Tag= col_node_data;
							node.Nodes.Add( col_node);
						}
					}
				}

				//
				// Fill Static nodes
				// Label
				node= new TreeNode( Helper.GetLocalString( "id_designer_label_tree_node"), (int)TREE_IMAGE_INDEX.LABEL_NORMAL, (int)TREE_IMAGE_INDEX.LABEL_SELECTED);
				node_data= new AVAILABLE_TREE_DATA();
				node_data.m_type= AVAILABLE_TREE_DATA.DATA_TYPE.LABEL;
				node_data.m_data= null;
				node.Tag= node_data;
				static_node.Nodes.Add( node);
				// Line
				node= new TreeNode( Helper.GetLocalString( "id_designer_line_tree_node"), (int)TREE_IMAGE_INDEX.LINE_NORMAL, (int)TREE_IMAGE_INDEX.LINE_SELECTED);
				node_data= new AVAILABLE_TREE_DATA();
				node_data.m_type= AVAILABLE_TREE_DATA.DATA_TYPE.LINE;
				node_data.m_data= null;
				node.Tag= node_data;
				static_node.Nodes.Add( node);
				// Box
				node= new TreeNode( Helper.GetLocalString( "id_designer_box_tree_node"), (int)TREE_IMAGE_INDEX.BOX_NORMAL, (int)TREE_IMAGE_INDEX.BOX_SELECTED);
				node_data= new AVAILABLE_TREE_DATA();
				node_data.m_type= AVAILABLE_TREE_DATA.DATA_TYPE.BOX;
				node_data.m_data= null;
				node.Tag= node_data;
				static_node.Nodes.Add( node);
				// Image
				node= new TreeNode( Helper.GetLocalString( "id_designer_image_tree_node"), (int)TREE_IMAGE_INDEX.IMAGE_NORMAL, (int)TREE_IMAGE_INDEX.IMAGE_SELECTED);
				node_data= new AVAILABLE_TREE_DATA();
				node_data.m_type= AVAILABLE_TREE_DATA.DATA_TYPE.IMAGE;
				node_data.m_data= null;
				node.Tag= node_data;
				static_node.Nodes.Add( node);
				
				//
				// Fill Variable nodes
				// Variable
				if( this.m_rpf_report_maker.Variables.Keys.Count!= 0) {
					foreach( string name in this.m_rpf_report_maker.Variables.Keys) {
						node= new TreeNode( name, (int)TREE_IMAGE_INDEX.VARIABLE_NORMAL, (int)TREE_IMAGE_INDEX.VARIABLE_SELECTED);
						node_data= new AVAILABLE_TREE_DATA();
						node_data.m_type= AVAILABLE_TREE_DATA.DATA_TYPE.VARIABLE;
						node_data.m_data= name;
						node.Tag= node_data;
						variable_node.Nodes.Add( node);
					}
				}
			} catch ( Exception excp) {
				Helper.ShowException( excp);
			} finally {
				this.m_available_treeView.EndUpdate();
			}
		}

		private void FillAllocatedResourceTree() {
			try {
				this.m_allocated_treeView.BeginUpdate();
				this.m_allocated_treeView.Nodes.Clear();
				this.m_draw_panel.Controls.Clear();
				if( this.m_rpf_report_maker== null)
					return;

				// Root nodes
				TreeNode document_node= new TreeNode( Helper.GetLocalString( "id_designer_document_tree_node"), (int)TREE_IMAGE_INDEX.CONTAINER_NORMAL, (int)TREE_IMAGE_INDEX.CONTAINER_SELECTED);
				document_node.Tag= this.m_rpf_report_maker.RPFDocument;
				RPFDocumentTrackerControl dtc= new RPFDocumentTrackerControl( this.m_rpf_report_maker.RPFDocument);
				dtc.AddChildRequest+=new AddChildRequestEventHandler(OnAddChildRequest);
				RPFObjectTag document_obj_tag= new RPFObjectTag();
				document_obj_tag.m_allocated_tree_node= document_node;
				document_obj_tag.m_host_control= dtc;
				this.m_rpf_report_maker.RPFDocument.Tag= document_obj_tag;
				this.m_draw_panel.AddChild( dtc);
				this.m_allocated_treeView.Nodes.Add( document_node);

				foreach( RPFSection section in this.m_rpf_report_maker.RPFDocument.ElementList) {
					// Sections nodes
					TreeNode section_node= null;
					RPFSectionTrackerControl stc= null;
					if( section is RPFFixedSection){
						stc= new RPFFixedSectionTrackerControl( ( RPFFixedSection)section);
						section_node= new TreeNode( Helper.GetLocalString( "id_designer_section_tree_node"), (int)TREE_IMAGE_INDEX.CONTAINER_NORMAL, (int)TREE_IMAGE_INDEX.CONTAINER_SELECTED);
					} else if( section is RPFTableRowSection){
						stc= new RPFTableRowSectionTrackerControl( ( RPFTableRowSection)section);
						section_node= new TreeNode( (( RPFTableRowSection)section).Name, (int)TREE_IMAGE_INDEX.TABLE_ROW_NORMAL, (int)TREE_IMAGE_INDEX.TABLE_ROW_SELECTED);
					} else {
						throw new Exception( string.Format( "FillAllocatedResourceTree: Unhandled section type '{0}'", section));
					}
					section_node.Tag= section;
					stc.AddChildRequest+=new AddChildRequestEventHandler(OnAddChildRequest);
					dtc.AddChild( stc);
					RPFObjectTag section_obj_tag= new RPFObjectTag();
					section_obj_tag.m_allocated_tree_node= section_node;
					section_obj_tag.m_host_control= stc;
					section.Tag= section_obj_tag;
					document_node.Nodes.Add( section_node);
					
					foreach( IRPFObject rpf_object in section.ElementList) {
						// RPFObjects
						TreeNode rpf_object_node= null;
						RPFTrackerBaseControl tc= null;
						if( rpf_object is RPFLabel){
							rpf_object_node= new TreeNode( Helper.GetLocalString( "id_designer_label_tree_node"), (int)TREE_IMAGE_INDEX.LABEL_NORMAL, (int)TREE_IMAGE_INDEX.LABEL_SELECTED);
							tc= new RPFLabelTrackerControl( (RPFLabel)rpf_object);
						} else if( rpf_object is RPFLine){
							rpf_object_node= new TreeNode( Helper.GetLocalString( "id_designer_line_tree_node"), (int)TREE_IMAGE_INDEX.LINE_NORMAL, (int)TREE_IMAGE_INDEX.LINE_SELECTED);
							tc= new RPFLineTrackerControl( (RPFLine)rpf_object);
						} else if( rpf_object is RPFBox){
							rpf_object_node= new TreeNode( Helper.GetLocalString( "id_designer_box_tree_node"), (int)TREE_IMAGE_INDEX.BOX_NORMAL, (int)TREE_IMAGE_INDEX.BOX_SELECTED);
							tc= new RPFBoxTrackerControl( (RPFBox)rpf_object);
						} else if( rpf_object is RPFVariable){
							rpf_object_node= new TreeNode( ((RPFVariable)rpf_object).Name, (int)TREE_IMAGE_INDEX.VARIABLE_NORMAL, (int)TREE_IMAGE_INDEX.VARIABLE_SELECTED);
							tc= new RPFVariableTrackerControl( (RPFVariable)rpf_object);
						} else if( rpf_object is RPFImage){
							rpf_object_node= new TreeNode( Helper.GetLocalString( "id_designer_image_tree_node"), (int)TREE_IMAGE_INDEX.IMAGE_NORMAL, (int)TREE_IMAGE_INDEX.IMAGE_SELECTED);
							tc= new RPFImageTrackerControl( (RPFImage)rpf_object);
						} else if( rpf_object is RPFTableColumn){
							rpf_object_node= new TreeNode( ((RPFTableColumn)rpf_object).Name, (int)TREE_IMAGE_INDEX.TABLE_COLUMN_NORMAL, (int)TREE_IMAGE_INDEX.TABLE_COLUMN_SELECTED);
							tc= new RPFTableColumnTrackerControl( (RPFTableColumn)rpf_object);
						} else {
							throw new Exception( string.Format( "FillAllocatedResourceTree: Unhandled object type '{0}'", rpf_object));
						}
						stc.AddChild( tc);
						rpf_object_node.Tag= rpf_object;
						RPFObjectTag obj_tag= new RPFObjectTag();
						obj_tag.m_allocated_tree_node= rpf_object_node;
						obj_tag.m_host_control= tc;
						rpf_object.Tag= obj_tag;
						section_node.Nodes.Add( rpf_object_node);
					}
				}
			} catch ( Exception excp) {
				Helper.ShowException( excp);
			} finally {
				this.m_allocated_treeView.EndUpdate();
			}
		}
		private void RPFDesignerControl_Load(object sender, System.EventArgs e) {
			if( this.DesignMode)
				return;

			this.UpdateToolbar();
			this.m_preview_control.AutoZoom= true;
			if( this.m_filename!= "") {
				this.m_rpf_report_maker.Load( this.m_filename);
			}
			this.FillAvailResourceTree();
			this.FillAllocatedResourceTree();

		}

		private void m_designer_layout_panel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
			try {
				this.m_draw_panel.RemoveSelection( null);
			} catch ( Exception excp) {
				Helper.ShowException( excp);
			}
		}

		#region properties
		private RPFReportMaker m_rpf_report_maker= new RPFReportMaker();
		
		public Hashtable Tables {
			set{ 
				this.m_rpf_report_maker.Tables= value;
				if( this.IsHandleCreated)
					this.FillAvailResourceTree();

			}
		}
		public Hashtable Variables {
			set{ 
				this.m_rpf_report_maker.Variables= value;
				if( this.IsHandleCreated)
					this.FillAvailResourceTree();

			}
		}
		private string m_filename= "";
		public string Filename{
			set{ 
				this.m_filename= value;
				if( this.IsHandleCreated)
					this.m_rpf_report_maker.Load( this.m_filename);

			}
		}

		#endregion
		private void m_allocated_treeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {
			try {
				if( this.m_allocated_treeView.SelectedNode!= null) {
					IRPFObject rpf_object= ( IRPFObject)this.m_allocated_treeView.SelectedNode.Tag;
					this.m_propertyGrid.SelectedObject= rpf_object;
					if( rpf_object.Tag!= null) {
						RPFTrackerBaseControl tc= (( RPFObjectTag )rpf_object.Tag).m_host_control;
						foreach( RPFTrackerBaseControl ctrl in tc.Parent.Controls) {
							if( ctrl!= tc)
								ctrl.Selected= false;
						}
						tc.Selected= true;
					}
				} else {
					this.m_propertyGrid.SelectedObject= null;
				}
			} catch ( Exception excp) {
				Helper.ShowException( excp);
			}
		}

		private void m_draw_panel_SelectedObjectsChanged(object sender, System.EventArgs e) {
			try {
				this.UpdateToolbar();

				this.m_propertyGrid.SelectedObjects= this.m_draw_panel.SelectedObjects;
				this.m_propertyGrid.Refresh();
				if( this.m_draw_panel.SelectedObjects== null) {
					this.m_allocated_treeView.SelectedNode= null;
					return;
				}
				if( this.m_draw_panel.SelectedObjects.Length!= 1) {
					this.m_allocated_treeView.SelectedNode= null;
					return;
				}
				this.m_allocated_treeView.SelectedNode= (( RPFObjectTag)((IRPFObject)this.m_draw_panel.SelectedObjects[0]).Tag).m_allocated_tree_node;
				this.m_allocated_treeView.SelectedNode.EnsureVisible();
			} catch ( Exception excp) {
				Helper.ShowException( excp);
			}
		}

		private void m_available_treeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e) {
			try {
				if( e.Button== MouseButtons.Right)
					return;
				AVAILABLE_TREE_DATA node_data= (AVAILABLE_TREE_DATA)((TreeNode)(e.Item)).Tag;
				if( node_data.m_type== AVAILABLE_TREE_DATA.DATA_TYPE.FOLDER)
					return;
				DoDragDrop( e.Item, DragDropEffects.Move);
			} catch ( Exception excp){
				MessageBox.Show( this, excp.Message);
			}
		}
	
		public struct RPFObjectTag {
			public RPFTrackerBaseControl m_host_control;
			public TreeNode m_allocated_tree_node;
		}
		private void OnAddChildRequest(object sender, AddChildRequestEventArgs e) {
			this.DoAddChildRequest( (RPFTrackerBaseControl)e.m_host_ctrl, e.m_rpf_object);
		}	
		private void DoAddChildRequest( RPFTrackerBaseControl host_ctrl, IRPFObject rpf_object) {
			// Search host control in allocated tree nodes 
			// Just document and sections
			if( host_ctrl is RPFDocumentTrackerControl) {
				// Add object to document
				TreeNode sel_node= this.m_allocated_treeView.Nodes[ 0];
				// Sections nodes
				TreeNode section_node= null;
				RPFSectionTrackerControl stc= null;
				if( rpf_object is RPFFixedSection) {
					stc= new RPFFixedSectionTrackerControl( ( RPFFixedSection)rpf_object);
					section_node= new TreeNode( Helper.GetLocalString( "id_designer_section_tree_node"), (int)TREE_IMAGE_INDEX.CONTAINER_NORMAL, (int)TREE_IMAGE_INDEX.CONTAINER_SELECTED);
				} else if( rpf_object is RPFTableRowSection) {
					stc= new RPFTableRowSectionTrackerControl( ( RPFTableRowSection)rpf_object);
					section_node= new TreeNode( (( RPFTableRowSection)rpf_object).Name, (int)TREE_IMAGE_INDEX.TABLE_ROW_NORMAL, (int)TREE_IMAGE_INDEX.TABLE_ROW_SELECTED);
				} else {
					System.Diagnostics.Debug.Assert( false, string.Format( "RPFDesignerControl.OnAddChildRequest: Unhandled section type '{0}'", rpf_object));
					return;
				}
				section_node.Tag= rpf_object;
				stc.AddChildRequest+=new AddChildRequestEventHandler(OnAddChildRequest);
				((ITrackerControlContainer )host_ctrl).AddChild( stc);
				RPFObjectTag section_obj_tag= new RPFObjectTag();
				section_obj_tag.m_allocated_tree_node= section_node;
				section_obj_tag.m_host_control= stc;
				rpf_object.Tag= section_obj_tag;
				sel_node.Nodes.Add( section_node);
				foreach( IRPFObject child_rpf_object in (( RPFSection)rpf_object).ElementList) {
					this.DoAddChildRequest( stc, child_rpf_object);
				}
			} else if( host_ctrl is RPFSectionTrackerControl) {
				// Add object to section
				TreeNode sel_node= null;
				foreach( TreeNode node in this.m_allocated_treeView.Nodes[ 0].Nodes) {
					if( node.Tag== host_ctrl.RPFObject) {
						sel_node= node;
						break;
					}
				}
				if( sel_node== null) {
					System.Diagnostics.Debug.Assert( false, string.Format( "RPFDesignerControl.OnAddChildRequest: Section not found'{0}'", host_ctrl.RPFObject));
					return;
				}
				// RPFObjects
				TreeNode rpf_object_node= null;
				RPFTrackerBaseControl tc= null;
				if( rpf_object is RPFLabel){
					rpf_object_node= new TreeNode( Helper.GetLocalString( "id_designer_label_tree_node"), (int)TREE_IMAGE_INDEX.LABEL_NORMAL, (int)TREE_IMAGE_INDEX.LABEL_SELECTED);
					tc= new RPFLabelTrackerControl( (RPFLabel)rpf_object);
				} else if( rpf_object is RPFLine){
					rpf_object_node= new TreeNode( Helper.GetLocalString( "id_designer_line_tree_node"), (int)TREE_IMAGE_INDEX.LINE_NORMAL, (int)TREE_IMAGE_INDEX.LINE_SELECTED);
					tc= new RPFLineTrackerControl( (RPFLine)rpf_object);
				} else if( rpf_object is RPFBox){
					rpf_object_node= new TreeNode( Helper.GetLocalString( "id_designer_box_tree_node"), (int)TREE_IMAGE_INDEX.BOX_NORMAL, (int)TREE_IMAGE_INDEX.BOX_SELECTED);
					tc= new RPFBoxTrackerControl( (RPFBox)rpf_object);
				} else if( rpf_object is RPFVariable){
					rpf_object_node= new TreeNode( ((RPFVariable)rpf_object).Name, (int)TREE_IMAGE_INDEX.VARIABLE_NORMAL, (int)TREE_IMAGE_INDEX.VARIABLE_SELECTED);
					tc= new RPFVariableTrackerControl( (RPFVariable)rpf_object);
				} else if( rpf_object is RPFImage){
					rpf_object_node= new TreeNode( Helper.GetLocalString( "id_designer_image_tree_node"), (int)TREE_IMAGE_INDEX.IMAGE_NORMAL, (int)TREE_IMAGE_INDEX.IMAGE_SELECTED);
					tc= new RPFImageTrackerControl( (RPFImage)rpf_object);
				} else if( rpf_object is RPFTableColumn){
					rpf_object_node= new TreeNode( ((RPFTableColumn)rpf_object).Name, (int)TREE_IMAGE_INDEX.TABLE_COLUMN_NORMAL, (int)TREE_IMAGE_INDEX.TABLE_COLUMN_SELECTED);
					tc= new RPFTableColumnTrackerControl( (RPFTableColumn)rpf_object);
				} else {
					throw new Exception( string.Format( "RPFDesignerControl.OnAddChildRequest: Unhandled object type '{0}'", rpf_object));
				}
				((ITrackerControlContainer )host_ctrl).AddChild( tc);
				rpf_object_node.Tag= rpf_object;
				RPFObjectTag obj_tag= new RPFObjectTag();
				obj_tag.m_allocated_tree_node= rpf_object_node;
				obj_tag.m_host_control= tc;
				rpf_object.Tag= obj_tag;
				sel_node.Nodes.Add( rpf_object_node);
			} else {
				System.Diagnostics.Debug.Assert( false, string.Format( "RPFDesignerControl.OnAddChildRequest: Unhandled host container request '{0}'", host_ctrl.GetType()));
			}
		}

		private void m_allocated_treeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e) {
			try {
				if( e.Button== MouseButtons.Right)
					return;
				TreeNode targetNode= (TreeNode)e.Item;
				IRPFObject rpf_object= (IRPFObject)targetNode.Tag;
				if( rpf_object is RPFDocument) {
					return;
				}
				DoDragDrop( e.Item, DragDropEffects.Move);
			} catch ( Exception excp){
				MessageBox.Show( this, excp.Message);
			}	
		}

		private void m_allocated_treeView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e) {
			e.Effect= e.AllowedEffect;
		}

		private void m_allocated_treeView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e) {
			object node= e.Data.GetData( "System.Windows.Forms.TreeNode");
			if( node== null) {
				e.Effect= DragDropEffects.None;
				return;
			}
			Point targetPoint = this.m_allocated_treeView.PointToClient( new Point(e.X, e.Y));
			TreeNode targetNode = this.m_allocated_treeView.GetNodeAt( targetPoint);

			try {
				// Check if AVAILABLE_TREE_DATA
				RPFDesignerControl.AVAILABLE_TREE_DATA node_data= (RPFDesignerControl.AVAILABLE_TREE_DATA)(( TreeNode)node).Tag;
				IRPFObject rpf_object= (IRPFObject)targetNode.Tag;
				if( rpf_object is RPFDocument) {
					// Add Section to document
					RPFSection rpf_child_object= null;
					switch( node_data.m_type) {
						case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.SECTION:
							rpf_child_object= new RPFFixedSection();
							break;
						case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.TABLE_ROW_SECTION:
							rpf_child_object= new RPFTableRowSection();
							rpf_child_object.Name= (string)node_data.m_data;
							break;
						default:
							return;
					}
					((RPFDocument)rpf_object).ElementList.Add( rpf_child_object);
					this.DoAddChildRequest( (( RPFObjectTag)rpf_object.Tag).m_host_control, rpf_child_object);
				} else { 
					if( !( rpf_object is RPFSection)) {
						rpf_object= (IRPFObject)targetNode.Parent.Tag;
					}
					IRPFObject rpf_child_object= null;
					if( rpf_object is RPFFixedSection) {
						switch( node_data.m_type) {
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.BOX:
								rpf_child_object= new RPFBox();
								break;
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.IMAGE:
								rpf_child_object= new RPFImage();
								break;
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.LABEL:
								rpf_child_object= new RPFLabel();
								break;
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.LINE:
								rpf_child_object= new RPFLine();
								break;
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.VARIABLE:
								rpf_child_object= new RPFVariable();
								((RPFVariable)rpf_child_object).Name= (string)node_data.m_data;
								break;
							default:
								return;
						}
					} else if( rpf_object is RPFTableRowSection) {
						switch( node_data.m_type) {
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.TABLE_COLUMN:
								rpf_child_object= ( RPFTableColumn)(( RPFTableColumn)node_data.m_data).Clone();
								break;
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.BOX:
								rpf_child_object= new RPFBox();
								break;
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.IMAGE:
								rpf_child_object= new RPFImage();
								break;
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.LABEL:
								rpf_child_object= new RPFLabel();
								break;
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.LINE:
								rpf_child_object= new RPFLine();
								break;
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.VARIABLE:
								rpf_child_object= new RPFVariable();
								((RPFVariable)rpf_child_object).Name= (string)node_data.m_data;
								break;
							default:
								return;
						}
					}
					((RPFSection)rpf_object).ElementList.Add( rpf_child_object);
					this.DoAddChildRequest( (( RPFObjectTag)rpf_object.Tag).m_host_control, rpf_child_object);
				}
			} catch (InvalidCastException ) {
				// Check if internal object move
				IRPFObject rpf_target_object= (IRPFObject)targetNode.Tag;
				IRPFObject rpf_dragged_object= (IRPFObject)((TreeNode)node).Tag;
				if ( rpf_dragged_object == rpf_target_object)
					return;
				if( rpf_target_object is RPFDocument) {
					// Move section as first Document node 
					((TreeNode)node).Remove();
					targetNode.Nodes.Insert( 0, ((TreeNode)node));
					// Reflect into designer
					((RPFDocument)rpf_target_object).ElementList.Remove( rpf_dragged_object);
					((RPFDocument)rpf_target_object).ElementList.Insert( 0, rpf_dragged_object);
					((RPFObjectTag) rpf_target_object.Tag).m_host_control.Controls.SetChildIndex( ((RPFObjectTag) rpf_dragged_object.Tag).m_host_control, ((RPFObjectTag) rpf_target_object.Tag).m_host_control.Controls.Count- 1);
				} else if( rpf_target_object is RPFSection) {
					if( rpf_dragged_object is RPFSection) {
						// Insert section After target section
						((TreeNode)node).Remove();
						int target_index= targetNode.Index+ 1;
						targetNode.Parent.Nodes.Insert( target_index, ((TreeNode)node));
						// Reflect into designer
						RPFDocument rpf_doc= ( RPFDocument)((TreeNode)node).Parent.Tag;
						rpf_doc.ElementList.Remove( rpf_dragged_object);
						rpf_doc.ElementList.Insert( target_index, rpf_dragged_object);
						((RPFObjectTag) rpf_doc.Tag).m_host_control.Controls.SetChildIndex( ((RPFObjectTag) rpf_dragged_object.Tag).m_host_control, ((RPFObjectTag) rpf_doc.Tag).m_host_control.Controls.Count- target_index- 1);
					} else {
						// Move object to target section: Place as first section object
						RPFSection rpf_dragged_section= ( RPFSection)((TreeNode)node).Parent.Tag;
						((TreeNode)node).Remove();
						targetNode.Nodes.Insert( 0, ((TreeNode)node));
						// Reflect into designer
						rpf_dragged_section.ElementList.Remove( rpf_dragged_object);
						((RPFSection)rpf_target_object).ElementList.Insert( 0, rpf_dragged_object);
						((RPFObjectTag) rpf_dragged_section.Tag).m_host_control.Controls.Remove( ((RPFObjectTag) rpf_dragged_object.Tag).m_host_control);
						((RPFObjectTag) rpf_target_object.Tag).m_host_control.Controls.Add( ((RPFObjectTag) rpf_dragged_object.Tag).m_host_control);
						((RPFObjectTag) rpf_target_object.Tag).m_host_control.Controls.SetChildIndex( ((RPFObjectTag) rpf_dragged_object.Tag).m_host_control, ((RPFObjectTag) rpf_target_object.Tag).m_host_control.Controls.Count);
					}
				} else {
					// Move object inside section (change Z order)
					// Insert dragged object After target object
					RPFSection rpf_dragged_section= ( RPFSection)((TreeNode)node).Parent.Tag;
					RPFSection rpf_target_section= ( RPFSection)targetNode.Parent.Tag;
					((TreeNode)node).Remove();
					int target_index= targetNode.Index+ 1;
					targetNode.Parent.Nodes.Insert( target_index, ((TreeNode)node));
					// Reflect into designer
					rpf_dragged_section.ElementList.Remove( rpf_dragged_object);
					rpf_target_section.ElementList.Insert( target_index, rpf_dragged_object);
					if( rpf_dragged_section!= rpf_target_section) {
						((RPFObjectTag) rpf_dragged_section.Tag).m_host_control.Controls.Remove( ((RPFObjectTag) rpf_dragged_object.Tag).m_host_control);
						((RPFObjectTag) rpf_target_section.Tag).m_host_control.Controls.Add( ((RPFObjectTag) rpf_dragged_object.Tag).m_host_control);
					}
					((RPFObjectTag) rpf_target_section.Tag).m_host_control.Controls.SetChildIndex( ((RPFObjectTag) rpf_dragged_object.Tag).m_host_control, ((RPFObjectTag) rpf_target_section.Tag).m_host_control.Controls.Count- target_index- 1);
				}
			}			
			catch {
			}			
		}

		private void m_allocated_treeView_DragOver(object sender, System.Windows.Forms.DragEventArgs e) {
			object node= e.Data.GetData( "System.Windows.Forms.TreeNode");
			if( node== null) {
				e.Effect= DragDropEffects.None;
				return;
			}
			Point targetPoint = this.m_allocated_treeView.PointToClient( new Point(e.X, e.Y));
			TreeNode targetNode = this.m_allocated_treeView.GetNodeAt( targetPoint);
			this.m_allocated_treeView.SelectedNode= targetNode;
			try {
				// Check if AVAILABLE_TREE_DATA
				RPFDesignerControl.AVAILABLE_TREE_DATA node_data= (RPFDesignerControl.AVAILABLE_TREE_DATA)(( TreeNode)node).Tag;
				IRPFObject rpf_object= (IRPFObject)targetNode.Tag;

				if( rpf_object is RPFDocument) {
					switch( node_data.m_type) {
						case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.SECTION:
						case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.TABLE_ROW_SECTION:
							break;
						default:
							e.Effect= DragDropEffects.None;
							return;
					}
				} else {
					if( !( rpf_object is RPFSection)) {
						rpf_object= (IRPFObject)targetNode.Parent.Tag;
					}
					if( rpf_object is RPFFixedSection) {
						switch( node_data.m_type) {
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.BOX:
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.IMAGE:
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.LABEL:
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.LINE:
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.VARIABLE:
								break;
							default:
								e.Effect= DragDropEffects.None;
								return;
						}
					} else if( rpf_object is RPFTableRowSection) {
						switch( node_data.m_type) {
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.TABLE_COLUMN:
								// Check if Table is correct one
								RPFTableColumn column= ( RPFTableColumn)node_data.m_data;
								if( column.TableId!= ((RPFTableRowSection)rpf_object).Name ){
									e.Effect= DragDropEffects.None;
									return;
								}
								break;
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.BOX:
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.IMAGE:
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.LABEL:
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.LINE:
							case RPFDesignerControl.AVAILABLE_TREE_DATA.DATA_TYPE.VARIABLE:
								break;
							default:
								e.Effect= DragDropEffects.None;
								return;
						}
					}
				}
				e.Effect= DragDropEffects.Move;
			} catch (InvalidCastException ) {
				IRPFObject rpf_target_object= (IRPFObject)targetNode.Tag;
				IRPFObject rpf_dragged_object= (IRPFObject)((TreeNode)node).Tag;
				if( rpf_target_object is RPFDocument) {
					// Only section can be moved into document
					if( !( rpf_dragged_object is RPFSection)) {
						e.Effect= DragDropEffects.None;
						return;
					}
				} else {
					if( !( rpf_target_object is RPFSection)) {
						rpf_target_object= (IRPFObject)targetNode.Parent.Tag;
					}
					if( rpf_target_object is RPFFixedSection) {
						if(	!( rpf_dragged_object is RPFBox)&& 
							!( rpf_dragged_object is RPFImage)&& 
							!( rpf_dragged_object is RPFLabel)&& 
							!( rpf_dragged_object is RPFLine)&& 
							!( rpf_dragged_object is RPFVariable)&&
							!( rpf_dragged_object is RPFSection)){
							e.Effect= DragDropEffects.None;
							return;
						}
					} else if( rpf_target_object is RPFTableRowSection) {
						if(	!( rpf_dragged_object is RPFTableColumn)&& 
							!( rpf_dragged_object is RPFBox)&& 
							!( rpf_dragged_object is RPFImage)&& 
							!( rpf_dragged_object is RPFLabel)&& 
							!( rpf_dragged_object is RPFLine)&& 
							!( rpf_dragged_object is RPFVariable)&&
							!( rpf_dragged_object is RPFSection)){
							e.Effect= DragDropEffects.None;
							return;
						}
						if(	rpf_dragged_object is RPFTableColumn) {
							// Check if Table is correct one
							RPFTableColumn column= ( RPFTableColumn)rpf_dragged_object;
							if( column.TableId!= ((RPFTableRowSection)rpf_target_object).Name ){
								e.Effect= DragDropEffects.None;
								return;
							}
						}
					} else {
						e.Effect= DragDropEffects.None;
						return;
					}
				}
				e.Effect= DragDropEffects.Move;
			} catch {
				e.Effect= DragDropEffects.None;
			} finally {
				if( this.m_drag_drop_sel_node!= targetNode) {
					this.m_drag_drop_sel_node= targetNode;
					this.m_drag_drop_timer.Stop();
					this.m_drag_drop_timer.Start();
				}
			}
		}

		private void m_drag_drop_timer_Tick(object sender, System.EventArgs e) {
			this.m_drag_drop_timer.Stop();
			if( this.m_drag_drop_sel_node== null)
				return;
			TreeNode act_sel_node= this.m_allocated_treeView.SelectedNode;
			if( act_sel_node== null)
				return;
			if( act_sel_node== this.m_drag_drop_sel_node)
				act_sel_node.Expand();
		}

		private bool CanEditDelete {
			get { 
				// Some checks
				if( this.m_draw_panel.SelectedObjects== null)
					return false;
				if( this.m_draw_panel.SelectedObjects.Length== 0)
					return false;
				foreach( IRPFObject rpf_object in this.m_draw_panel.SelectedObjects) {
					if(	rpf_object is RPFDocument){
						// cannot delete object!
						return false;
					} 
				}
				return true;
			}
		}
		private bool CanEditCopy {
			get { 
				// Some checks
				if( this.m_draw_panel.SelectedObjects== null)
					return false;
				if( this.m_draw_panel.SelectedObjects.Length== 0)
					return false;
				foreach( IRPFObject rpf_object in this.m_draw_panel.SelectedObjects) {
					if(	rpf_object is RPFDocument){
						// cannot copy object!
						return false;
					} 
				}
				return true;
			}
		}
		private bool CanEditPaste {
			get { 
				// Some checks
				if( this.m_draw_panel.SelectedObjects== null)
					return false;
				if( this.m_draw_panel.SelectedObjects.Length!= 1)
					return false;
				if( RPFClipboard.RPFObjects== null)
					return false;
				if( RPFClipboard.RPFObjects.Length== 0)
					return false;

				// Check if object is container
				IRPFObject rpf_sel_object= this.m_draw_panel.SelectedObjects[0];
				if ( rpf_sel_object is RPFDocument){ 
					for( int i= 0; i< RPFClipboard.RPFObjects.Length; i++) {
						// Check data type : only Section allowed
						if( !( RPFClipboard.RPFObjects[i] is RPFSection))
							return false;
					}
				} else if ( rpf_sel_object is RPFSection){ 
					for( int i= 0; i< RPFClipboard.RPFObjects.Length; i++) {
						// Check data type : Section & Documents not allowed
						if( ( RPFClipboard.RPFObjects[i] is RPFSection)|| 
							( RPFClipboard.RPFObjects[i] is RPFDocument))
							return false;
						if( RPFClipboard.RPFObjects[i] is RPFTableColumn){
							if( !( rpf_sel_object is RPFTableRowSection))
								return false;
							// Check if table is correct one
							if( (( RPFTableColumn)RPFClipboard.RPFObjects[i]).TableId!= (( RPFTableRowSection)rpf_sel_object).Name)
								return false;
						}
					}
				} else {
					// cannot paste into this object!
					return false;
				}
				return true;
			}
		}
		private bool CanFormat {
			get{ 
				if( this.m_draw_panel.SelectedObjects== null)
					return false;
				if( this.m_draw_panel.SelectedObjects.Length< 2)
					return false;
				return true;
			}
		}
		private void UpdateToolbar() {
			// Checks for edit copy
			toolStripCopy.Enabled=this.m_edit_copy_toolBarButton.Enabled= this.CanEditCopy;
            toolStripPaste.Enabled = this.m_edit_paste_toolBarButton.Enabled = this.CanEditPaste;
            toolStripDelete.Enabled = this.m_edit_delete_toolBarButton.Enabled = this.CanEditDelete;
            toolStripCut.Enabled = this.m_edit_cut_toolBarButton.Enabled = this.m_edit_delete_toolBarButton.Enabled && this.m_edit_copy_toolBarButton.Enabled;

            
			bool enable_format= this.CanFormat;
			this.m_format_align_bottom_toolBarButton.Enabled= enable_format;
			this.m_format_align_hcentre_toolBarButton.Enabled= enable_format;
			this.m_format_align_left_toolBarButton.Enabled= enable_format;
			this.m_format_align_right_toolBarButton.Enabled= enable_format;
			this.m_format_align_top_toolBarButton.Enabled= enable_format;
			this.m_format_align_vcentre_toolBarButton.Enabled= enable_format;
			this.m_format_same_height_max_toolBarButton.Enabled= enable_format;
			this.m_format_same_height_min_toolBarButton.Enabled= enable_format;
			this.m_format_same_width_max_toolBarButton.Enabled= enable_format;
			this.m_format_same_width_min_toolBarButton.Enabled= enable_format;
		}

		private void m_designer_tabControl_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
			switch( e.KeyCode) {
				case Keys.X:
					if( !e.Control)
						return;
					// Edit Cut
					this.DoEditCut();
					e.Handled= true;
					break;
				case Keys.C:
					if( !e.Control)
						return;
					// Edit Copy
					this.DoEditCopy();
					e.Handled= true;
					break;
				case Keys.V:
					if( !e.Control)
						return;
					// Edit Paste
					this.DoEditPaste();
					e.Handled= true;
					break;
				case Keys.Delete:
					// Edit Delete
					this.DoEditDelete( true);
					e.Handled= true;
					break;
			}
		
		}

		private void m_designer_tabControl_SelectedIndexChanged(object sender, System.EventArgs e) {
			if( m_designer_tabControl.SelectedTab== this.m_designer_preview_tabPage) 
            {
                m_designer_preview_tabPage.Controls.Remove(m_preview_control);
                Application.DoEvents();
                this.m_designer_preview_tabPage.SuspendLayout();
                this.SuspendLayout();

                m_preview_control = new PrintPreviewControl();

                this.m_preview_control.AutoZoom = true;
                this.m_preview_control.Location = new System.Drawing.Point(83, 46);
                this.m_preview_control.Name = "m_preview_control";
                this.m_preview_control.Size = new System.Drawing.Size(672, 423);
                this.m_preview_control.TabIndex = 0;
                this.m_preview_control.Dock = System.Windows.Forms.DockStyle.Fill;

                this.m_designer_preview_tabPage.Controls.Add(this.m_preview_control);

                this.m_designer_preview_tabPage.ResumeLayout(false);
                this.m_designer_preview_tabPage.PerformLayout();
                this.ResumeLayout(false);

				this.m_preview_control.Document= this.ReportDocument;
                m_preview_control.Refresh();
			}
		}

		private void m_preview_toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e) {
			if( e.Button== this.m_preview_print_toolBarButton) {
				this.DoPreviewPrint();
				return;
			}
			if( e.Button== this.m_preview_zoom_toolBarButton) {
				this.DoPreviewZoom();
				return;
			}
			if( e.Button== this.m_preview_prev_toolBarButton) {
				this.DoPreviewPrevPage();
				return;
			}
			if( e.Button== this.m_preview_next_toolBarButton) {
				this.DoPreviewNextPage();
				return;
			}
		}
		private void DoPreviewPrint(){
			this.m_preview_control.Document.Print();
		}
		private void DoPreviewZoom(){
			this.m_preview_control.AutoZoom= true;
		}
		private void DoPreviewPrevPage()
        {
            try
            {
                this.m_preview_control.StartPage -= 1;
            }
            catch 
            {
            }
		}
		private void DoPreviewNextPage(){
			this.m_preview_control.StartPage+= 1;
		}

		private void CheckMenuItem( Menu menu, MenuItem item) {
			foreach( MenuItem menu_item in menu.MenuItems) {
				menu_item.Checked= false;
			}
			item.Checked= true;
		}
		private void m_zoom_auto_menuItem_Click(object sender, System.EventArgs e) {
			this.m_preview_control.AutoZoom= true;
			this.CheckMenuItem( this.m_zoom_contextMenu, ((MenuItem)sender));
		}

		private void m_zoom_perc_200_menuItem_Click(object sender, System.EventArgs e) {
			this.m_preview_control.AutoZoom= false;
			this.m_preview_control.Zoom= 2.0;
			this.CheckMenuItem( this.m_zoom_contextMenu, ((MenuItem)sender));
		}

		private void m_zoom_perc_150_menuItem_Click(object sender, System.EventArgs e) {
			this.m_preview_control.AutoZoom= false;
			this.m_preview_control.Zoom= 1.5;
			this.CheckMenuItem( this.m_zoom_contextMenu, ((MenuItem)sender));
		}

		private void m_zoom_perc_100_menuItem_Click(object sender, System.EventArgs e) {
			this.m_preview_control.AutoZoom= false;
			this.m_preview_control.Zoom= 1.0;
			this.CheckMenuItem( this.m_zoom_contextMenu, ((MenuItem)sender));
		}

		private void m_zoom_perc_75_menuItem_Click(object sender, System.EventArgs e) {
			this.m_preview_control.AutoZoom= false;
			this.m_preview_control.Zoom= 0.75;
			this.CheckMenuItem( this.m_zoom_contextMenu, ((MenuItem)sender));
		}

		private void m_zoom_perc_50_menuItem_Click(object sender, System.EventArgs e) {
			this.m_preview_control.AutoZoom= false;
			this.m_preview_control.Zoom= 0.5;
			this.CheckMenuItem( this.m_zoom_contextMenu, ((MenuItem)sender));
		}

		private void m_zoom_perc_25_menuItem_Click(object sender, System.EventArgs e) {
			this.m_preview_control.AutoZoom= false;
			this.m_preview_control.Zoom= 0.25;
			this.CheckMenuItem( this.m_zoom_contextMenu, ((MenuItem)sender));
		}

		private void m_zoom_perc_10_menuItem_Click(object sender, System.EventArgs e) {
			this.m_preview_control.AutoZoom= false;
			this.m_preview_control.Zoom= 0.1;
			this.CheckMenuItem( this.m_zoom_contextMenu, ((MenuItem)sender));
		}
	
		private ReportDocument ReportDocument {
			get {
				try {
					ReportDocument report_document= new ReportDocument();
					report_document.Body = null;
					report_document.PageFooter = null;
					report_document.PageFooterMaxHeight = 0F;
					report_document.PageHeader = null;
					report_document.PageHeaderMaxHeight = 0F;
					report_document.ResetAfterPrint = true;

					report_document.PrinterSettings= this.m_rpf_report_maker.RPFDocument.PrinterSettings;
					report_document.DefaultPageSettings.Landscape= this.m_rpf_report_maker.RPFDocument.Landscape;
					report_document.DefaultPageSettings.Margins= new System.Drawing.Printing.Margins( 
						(int)(float)(this.m_rpf_report_maker.RPFDocument.Margins.Left* 100.0f),
						(int)(float)(this.m_rpf_report_maker.RPFDocument.Margins.Right* 100.0f),
						(int)(float)(this.m_rpf_report_maker.RPFDocument.Margins.Top* 100.0f),
						(int)(float)(this.m_rpf_report_maker.RPFDocument.Margins.Bottom* 100.0f));
					report_document.DefaultPageSettings.PaperSize= GetPaperSize( this.m_rpf_report_maker.RPFDocument.PrinterSettings, ( PaperKind)PaperKind.Parse( typeof( PaperKind), this.m_rpf_report_maker.RPFDocument.PaperKind, true));

					report_document.ReportMaker= this.m_rpf_report_maker;
					return report_document;
				}
				catch( Exception excp) {
					MessageBox.Show( this, excp.ToString());
					return null;
				}
			}
		}
		public static System.Drawing.Printing.PaperSize GetPaperSize( System.Drawing.Printing.PrinterSettings ps, System.Drawing.Printing.PaperKind pk) {
			foreach( System.Drawing.Printing.PaperSize size in ps.PaperSizes) {
				if( size.Kind== pk) {
					return size;
				}
			}
			return null;
		}

		private void m_designer_layout_panel_Resize(object sender, System.EventArgs e) {
			this.DoLayout();
		}

		private void m_rpf_report_maker_DocumentLoaded(object sender, EventArgs e) {
			this.FillAllocatedResourceTree();
		}

		private void m_rpf_report_maker_DynamicObjectChanged(object sender, EventArgs e) {
			this.FillAvailResourceTree();
		}
		public bool SaveAsDocument( string filename) {
			this.m_filename= filename;
			return this.m_rpf_report_maker.Save( this.m_filename);
		}
		public bool SaveDocument( ) {
			if(this.m_filename== "")
				return false;
			return this.m_rpf_report_maker.Save( this.m_filename);
		}
		public bool LoadDocument( string filename) {
			this.m_filename= filename;
			if( this.IsHandleCreated) {
				return this.m_rpf_report_maker.Load( this.m_filename);
			} 
			return true;
		}

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveAsDocument(openFileDialog1.FileName);
            System.Threading.Thread.Sleep(1000);

            LoadDocument(openFileDialog1.FileName);
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            LoadDocument(openFileDialog1.FileName);
        }

        private void btn_Saveas_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            SaveAsDocument(saveFileDialog1.FileName);
        }

        private void toolStripCopy_Click(object sender, EventArgs e)
        {
            DoEditCopy();
        }

        private void toolStripCut_Click(object sender, EventArgs e)
        {
            DoEditCut();
        }

        private void toolStripPaste_Click(object sender, EventArgs e)
        {
            DoEditPaste();
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            DoEditDelete(true);
        }
	}
}
