namespace Monkey.Processing.UI
{
    partial class ParameterWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_generalPropertyGridControl = new Monkey.Processing.UI.GeneralPropertyGridControl();
            this.SuspendLayout();
            // 
            // m_generalPropertyGridControl
            // 
            this.m_generalPropertyGridControl.AutoScroll = true;
            this.m_generalPropertyGridControl.AutoSize = true;
            this.m_generalPropertyGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_generalPropertyGridControl.DynamicSize = true;
            this.m_generalPropertyGridControl.Location = new System.Drawing.Point(0, 0);
            this.m_generalPropertyGridControl.Name = "m_generalPropertyGridControl";
            this.m_generalPropertyGridControl.PropertyGroups = null;
            this.m_generalPropertyGridControl.Propertys = null;
            this.m_generalPropertyGridControl.Size = new System.Drawing.Size(682, 350);
            this.m_generalPropertyGridControl.TabIndex = 0;
            // 
            // ParameterWizard
            // 
            this.Controls.Add(this.m_generalPropertyGridControl);
            this.Name = "ParameterWizard";
            this.Size = new System.Drawing.Size(682, 350);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GeneralPropertyGridControl m_generalPropertyGridControl;
    }
}
