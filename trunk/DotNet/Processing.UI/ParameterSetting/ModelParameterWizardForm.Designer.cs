namespace Monkey.Processing.UI
{
    partial class ModelParameterWizardForm
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
            this.m_wizard = new Monkey.Processing.UI.WizardForm();
            this.SuspendLayout();
            // 
            // m_wizard
            // 
            this.m_wizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wizard.Location = new System.Drawing.Point(0, 0);
            this.m_wizard.Name = "WizardForm";
            this.m_wizard.PageIndex = 0;
            this.m_wizard.Size = new System.Drawing.Size(492, 416);
            this.m_wizard.TabIndex = 0;
            this.m_wizard.Finish += new Monkey.Processing.UI.WizardForm.WizardNextEventHandler(this.m_wizard_Finish);
            // 
            // ModelParameterWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 416);
            this.ControlBox = false;
            this.Controls.Add(this.m_wizard);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModelParameterWizardForm";
            this.Text = "ModelParameterWizardForm";
            this.ResumeLayout(false);

        }

        #endregion

        private WizardForm m_wizard;
    }
}