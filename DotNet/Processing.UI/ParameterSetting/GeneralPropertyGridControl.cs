using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monkey.Processing.UI
{
    using Monkey.Processing;

    public partial class GeneralPropertyGridControl : UserControl
    {
        public GeneralPropertyGridControl()
        {
            InitializeComponent();

            InitializeUserControl();

            this._gridWnd.DrawFlatToolbar = false;

            InitializeGrid();
        }



        #region Propertys

        public Boolean DynamicSize
        {
            get
            {
                return _dynamicSize;
            }
            set
            {
                _dynamicSize = value;

                //if (null != _controlWnd)
                //{
                //    _controlWnd.DynamicSize = _dynamicSize;
                //}
            }
        }

        private Boolean _isGroup = false;
        private List<PropertyGroup> _propertyGroups = null;
        /// <summary>
        /// 如果属性分组，使用PropertyGroups；如果不分组，使用Propertys
        /// </summary>
        public List<PropertyGroup> PropertyGroups
        {
            get
            {
                return _propertyGroups;
            }
            set
            {
                _isGroup = true;
                _propertyGroups = value;

                //if (null != _controlWnd)
                //{
                //    _controlWnd.DynamicSize = _dynamicSize;
                //}
            }
        }

        private List<PropertyItem> _propertys = null;
        /// <summary>
        /// 如果属性分组，使用PropertyGroups；如果不分组，使用Propertys
        /// </summary>
        public List<PropertyItem> Propertys
        {
            get
            {
                return _propertys;
            }
            set
            {
                _isGroup = false;
                _propertys = value;

                //if (null != _controlWnd)
                //{
                //    _controlWnd.DynamicSize = _dynamicSize;
                //}
            }
        }

        #endregion


        #region public Methods

        public void FillGrids()
        {
            if (_isGroup)
            {
                FillGridsPropertyGroups();
            }
            else
            {
                FillGridsPropertys();
            }
        }

        #endregion

        public event PropertyItemValueChangedEventHandler PropertyValueChanged;

        #region private Methods

        private void InitializeUserControl()
        {
            this.AutoSize = true;
            this.AutoScroll = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this._gridWnd = new PropertyGridEx();
            this.SuspendLayout();
            

            // 
            // controlWnd
            // 
            //this._gridWnd.AutoScaleMode = AutoScaleMode.Inherit;
            this._gridWnd.AutoSizeProperties = true;
            this._gridWnd.AutoSize = true;
            this._gridWnd.BackColor = System.Drawing.Color.Transparent;
            this._gridWnd.ForeColor = System.Drawing.Color.White;
            this._gridWnd.Cursor = System.Windows.Forms.Cursors.Default;
            this._gridWnd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this._gridWnd.Location = new System.Drawing.Point(0, 0);
            this._gridWnd.Name = "_gridWnd";
            this._gridWnd.SelectedObject = this._gridWnd.Item;
            this._gridWnd.ShowCustomProperties = true;
            this._gridWnd.Size = new System.Drawing.Size(337, 324);
            this._gridWnd.TabIndex = 2;

            // 
            // 
            // 
            this._gridWnd.DocCommentDescription.AccessibleName = "";
            this._gridWnd.DocCommentDescription.AutoEllipsis = true;
            this._gridWnd.DocCommentDescription.BackColor = System.Drawing.Color.Transparent;
            this._gridWnd.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this._gridWnd.DocCommentDescription.ForeColor = System.Drawing.Color.White;
            this._gridWnd.DocCommentDescription.Location = new System.Drawing.Point(0, 0);
            this._gridWnd.DocCommentDescription.Name = "";
            this._gridWnd.DocCommentDescription.Size = new System.Drawing.Size(331, 36);
            this._gridWnd.DocCommentDescription.TabIndex = 1;
            //this._gridWnd.DocCommentImage = ((System.Drawing.Image)(resources.GetObject("_gridWnd.DocCommentImage")));
            // 
            // 
            // 
            this._gridWnd.DocCommentTitle.AutoSize = true;
            this._gridWnd.DocCommentTitle.BackColor = System.Drawing.Color.Transparent;
            this._gridWnd.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this._gridWnd.DocCommentTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this._gridWnd.DocCommentTitle.ForeColor = System.Drawing.Color.White;
            this._gridWnd.DocCommentTitle.Location = new System.Drawing.Point(0, 0);
            this._gridWnd.DocCommentTitle.Name = "";
            this._gridWnd.DocCommentTitle.Size = new System.Drawing.Size(0, 13);
            this._gridWnd.DocCommentTitle.TabIndex = 0;
            this._gridWnd.DocCommentTitle.UseMnemonic = false;
            //this._gridWnd.Dock = System.Windows.Forms.DockStyle.Bottom;// .Fill;
           
            // 
            // 
            // 
            this._gridWnd.ToolStrip.AccessibleName = "ToolBar";
            this._gridWnd.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this._gridWnd.ToolStrip.AllowMerge = false;
            this._gridWnd.ToolStrip.AutoSize = false;
            this._gridWnd.ToolStrip.CanOverflow = false;
            this._gridWnd.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._gridWnd.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._gridWnd.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {});
            this._gridWnd.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this._gridWnd.ToolStrip.Location = new System.Drawing.Point(0, 1);
            this._gridWnd.ToolStrip.Name = "";
            this._gridWnd.ToolStrip.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this._gridWnd.ToolStrip.Size = new System.Drawing.Size(337, 25);
            this._gridWnd.ToolStrip.TabIndex = 1;
            this._gridWnd.ToolStrip.TabStop = true;
            this._gridWnd.ToolStrip.Text = "PropertyGridToolBar";            
            this._gridWnd.ToolStrip.Visible = false;
//            this._gridWnd.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this._gridWnd_PropertyValueChanged);

            this._gridWnd.SizeChanged += new EventHandler(_gridWnd_SizeChanged);

            this.Controls.Add(this._gridWnd);
            // 

            this._gridWnd.ResumeLayout(false);
            this._gridWnd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeGrid()
        {
            this.SuspendLayout();
            this._gridWnd.ShowCustomProperties = true;
            this._gridWnd.Item.Clear();

            this._gridWnd.PropertyValueChanged += new PropertyValueChangedEventHandler(OnPropertyGridExPropertyValueChanged);


            this._gridWnd.ResumeLayout(false);
            this._gridWnd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            this._gridWnd.Refresh();
            this.Refresh();
             
        }

        private void _gridWnd_SizeChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();

//            this._ppfSearch.Size = new Size(this._gridWnd.Size.Width, this._ppfSearch.Size.Height);

//            this.btnOK.Location = new System.Drawing.Point(this._gridWnd.Location.X, this._gridWnd.Location.Y + this._gridWnd.Size.Height);

            this.ResumeLayout(false);
            this.PerformLayout();

            
        }

        //private void btnOK_Click(object sender, EventArgs e)
        //{
        //    IProcessManager manager = ProcessManager.Instance;
        //    IProcessModel model = manager.GetProcessModelBykey(_modelName);

        //    CustomProperty property = null;
        //    for (Int32 i = 0; i < this._gridWnd.Item.Count; ++i)
        //    {
        //        property = this._gridWnd.Item[i];
        //        if (null == property)   //不应该为null，说明发生了异常
        //        {
        //            //throw;
        //        }

        //        model.ImportValue(property.Name, property.Value);
                
        //    }
        //    //List<Object> values = _controlWnd.Values;

            

        //    //for (Int32 i = 0; i < _paraKeys.Count; ++i)
        //    //{
        //    //    model.ImportValue(_paraKeys[i], values[i]);
        //    //}

        //    model.Execute();            
        //}

        //private void searchKeyChanged(Object sender, SearchEventArgs e)
        //{
        //    try
        //    {
        //        _processName = e.SearchKey;

        //        //IContext context = SuperMap.SpatialModel.Context.Instance;
        //        //if (null == context)
        //        //{
        //        //}

        //        //IParaListEngine paraListEngine = context.GetVariable("ParaListEngine") as IParaListEngine;
        //        //if (null == paraListEngine)
        //        //{
        //        //}

        //        this.SuspendLayout();
        //        this._gridWnd.ShowCustomProperties = true;
        //        this._gridWnd.Item.Clear();
        //        //List<PropertyItem> controlList = new List<PropertyItem>();
        //        CustomPropertysManager manager = CustomPropertysManager.Instance;
        //        //ICustomPropertyMaker maker = null;
        //        //paraListEngine.ParaBegin();
        //        //while (!paraListEngine.ParaIsEnd())
        //        //{
        //        //    paraListEngine.ParaMoveNext();
        //        //    //test
        //        //    String str;
        //        //    str = paraListEngine.ParaCaption;
        //        //    str = paraListEngine.ParaName;
        //        //    str = paraListEngine.ControlType;
        //        //    str = paraListEngine.ParaType;


        //        //    //获取参数
        //        //    PropertyItem define = new PropertyItem();
        //        //    define.Name = paraListEngine.ParaName;
        //        //    define.Caption = paraListEngine.ParaCaption;
        //        //    define.Type = paraListEngine.ControlType;
        //        //    define.Propertys = paraListEngine.ParaPropertys;
        //        //    _paraKeys.Add(paraListEngine.ParaName);
        //        //    define["ItemType"] = CovertoItemType(paraListEngine.ParaType);

        //        //    //property           
        //        //    CustomProperty property = manager.Make(define);

        //        //    if (null == property)
        //        //    {
        //        //        Console.WriteLine("CustomProperty is null");
        //        //    }
        //        //    //property.CustomEditor = maker.TypeEdit;
        //        //    //property.CustomTypeConverter = maker.TypeConverter;

        //        //    this._gridWnd.Item.Add(property);
        //        //}
        //        this._gridWnd.ResumeLayout(false);
        //        this._gridWnd.PerformLayout();
        //        this.ResumeLayout(false);
        //        this.PerformLayout();
        //        this._gridWnd.Refresh();
        //        this.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        private String CovertoItemType(String type)
        {
            switch (type)
            {
                case "Array.Int":
                    {
                        return "Int32";
                    }
                    break;
                case "Array.String":
                    {
                        return "String";
                    }
                    break;
                case "Array.Single":
                    {
                        return "Single";
                    }
                    break;
            }

            return "";
        }

        private void ApplyCommentsStyle()
        {
            // Apply new style to DocComment
            this._gridWnd.DocCommentTitle.Font = new Font("Tahoma", 14, FontStyle.Bold);
            this._gridWnd.DocCommentDescription.Location = new Point(3, (5 + this._gridWnd.DocCommentTitle.Font.Height));

            this._gridWnd.Text = "Grid Text";
        }



        private void ControlPan_Load(object sender, EventArgs e)
        {
            // Remove the FromId Pages button
            this._gridWnd.ToolStrip.Items.Clear();

            // Apply style to DocComment object
            ApplyCommentsStyle();
        }

        private void FillGridsPropertyGroups()
        {
            try
            {
                this.SuspendLayout();
                this._gridWnd.ShowCustomProperties = true;
                this._gridWnd.ItemSet.Clear();

                CustomPropertysManager manager = CustomPropertysManager.Instance;
                ICustomPropertyMaker maker = null;
                CustomPropertyCollection collection = null;
                CustomProperty property = null;

                foreach (PropertyGroup group in _propertyGroups)
                {
                    collection = new CustomPropertyCollection();

                    foreach (PropertyItem item in group)
                    {
                        property = manager.Make(item);
                        if (null != property)
                        {
                            collection.Add(property);
                        }                        
                    }

                    this._gridWnd.ItemSet.Add(collection);

                    collection = null;
                }

                this._gridWnd.ResumeLayout(false);
                this._gridWnd.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();
                this._gridWnd.Refresh();
                this.Refresh();
            }
            catch (Exception ex)
            {
                Toolkit.DEBUG_TRACE("Monkey.Processing.UI.GeneralPropertyGridControl.FillGridsPropertyGroups Exception:" + ex.Message + "\n");
                return;
            }
        }

        private void FillGridsPropertys()
        {
            try
            {
                this.SuspendLayout();
                this._gridWnd.ShowCustomProperties = true;
                this._gridWnd.Item.Clear();

                CustomPropertysManager manager = CustomPropertysManager.Instance;
                ICustomPropertyMaker maker = null;
                CustomProperty property = null;

                foreach (PropertyItem item in _propertys)
                {
                    //property           
                    property = manager.Make(item);

                    if (null != property)
                    {
                        this._gridWnd.Item.Add(property);
                    }

                    property = null;
                }

                this._gridWnd.ResumeLayout(false);
                this._gridWnd.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();
                this._gridWnd.Refresh();
                this.Refresh();
            }
            catch (Exception ex)
            {
                Toolkit.DEBUG_TRACE("Monkey.Processing.UI.GeneralPropertyGridControl.FillGridsPropertys Exception:" + ex.Message + "\n");
                return;
            }
        }

        #endregion

        #region private Events

        private void OnPropertyGridExPropertyValueChanged(Object s, PropertyValueChangedEventArgs e)
        {
            try
            {

                if (null != PropertyValueChanged)
                {
                    GridItem item = e.ChangedItem;
                    PropertyValueChanged(this, new PropertyItemValueChangedEventArgs(item.Label, item.Value));
                }

                //Toolkit.DEBUG_TRACE("Monkey.Processing.UI.GeneralPropertyGridControl.OnPropertyGridExPropertyValueChanged PropertyValueChangedEventArgs Label:" + item.Label + "\n");
                //Toolkit.DEBUG_TRACE("Monkey.Processing.UI.GeneralPropertyGridControl.OnPropertyGridExPropertyValueChanged PropertyValueChangedEventArgs item.ToString():" + item.ToString() + "\n");

                //item.

                //this._gridWnd.Item.

                Toolkit.DEBUG_TRACE("Monkey.Processing.UI.GeneralPropertyGridControl.OnPropertyGridExPropertyValueChanged PropertyValueChangedEventArgs:" + e.ToString() + "\n");
            }
            catch (Exception ex)
            {
                Toolkit.DEBUG_TRACE("Monkey.Processing.UI.GeneralPropertyGridControl.OnPropertyGridExPropertyValueChanged Exception:" + ex.Message + "\n");
                return;
            }
        }
           
    

        #endregion

        //protected PPFSearch _ppfSearch;
        //protected IntelligentControlWindow _controlWnd;
        protected PropertyGridEx _gridWnd;
        protected List<String> _paraKeys = new List<String>();
        protected String _processName;
        protected Boolean _dynamicSize = true;

        protected Int32 count = 0;
    }
}
