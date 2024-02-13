namespace DesignPattern
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_FactoryMethod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_FactoryMethod
            // 
            this.btn_FactoryMethod.Location = new System.Drawing.Point(25, 31);
            this.btn_FactoryMethod.Name = "btn_FactoryMethod";
            this.btn_FactoryMethod.Size = new System.Drawing.Size(166, 23);
            this.btn_FactoryMethod.TabIndex = 0;
            this.btn_FactoryMethod.Text = "팩토리 메서드 패턴";
            this.btn_FactoryMethod.UseVisualStyleBackColor = true;
            this.btn_FactoryMethod.Click += new System.EventHandler(this.btn_FactoryMethod_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 450);
            this.Controls.Add(this.btn_FactoryMethod);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_FactoryMethod;
    }
}