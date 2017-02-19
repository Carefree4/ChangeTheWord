namespace BattleGrounds
{
    partial class Window
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
            this.rtb_output = new System.Windows.Forms.RichTextBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.rtb_top10 = new System.Windows.Forms.RichTextBox();
            this.rtb_replaced = new System.Windows.Forms.RichTextBox();
            this.rtb_th = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb_output
            // 
            this.rtb_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_output.Location = new System.Drawing.Point(13, 52);
            this.rtb_output.Name = "rtb_output";
            this.rtb_output.ReadOnly = true;
            this.rtb_output.Size = new System.Drawing.Size(432, 198);
            this.rtb_output.TabIndex = 0;
            this.rtb_output.Text = "";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(382, 257);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(63, 23);
            this.btn_refresh.TabIndex = 1;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // rtb_top10
            // 
            this.rtb_top10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_top10.Location = new System.Drawing.Point(13, 259);
            this.rtb_top10.Name = "rtb_top10";
            this.rtb_top10.ReadOnly = true;
            this.rtb_top10.Size = new System.Drawing.Size(117, 168);
            this.rtb_top10.TabIndex = 2;
            this.rtb_top10.Text = "";
            // 
            // rtb_replaced
            // 
            this.rtb_replaced.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_replaced.Location = new System.Drawing.Point(136, 259);
            this.rtb_replaced.Name = "rtb_replaced";
            this.rtb_replaced.ReadOnly = true;
            this.rtb_replaced.Size = new System.Drawing.Size(117, 168);
            this.rtb_replaced.TabIndex = 3;
            this.rtb_replaced.Text = "";
            // 
            // rtb_th
            // 
            this.rtb_th.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_th.Location = new System.Drawing.Point(259, 259);
            this.rtb_th.Name = "rtb_th";
            this.rtb_th.ReadOnly = true;
            this.rtb_th.Size = new System.Drawing.Size(117, 168);
            this.rtb_th.TabIndex = 4;
            this.rtb_th.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(433, 43);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "By using this app, you pledge to fight harassment by making sure your tone of voi" +
    "ce and word choice is appropriate for the audience and correctly displays your c" +
    "harecter.";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 439);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.rtb_th);
            this.Controls.Add(this.rtb_replaced);
            this.Controls.Add(this.rtb_top10);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.rtb_output);
            this.Name = "Window";
            this.Text = "Window";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_output;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.RichTextBox rtb_top10;
        private System.Windows.Forms.RichTextBox rtb_replaced;
        private System.Windows.Forms.RichTextBox rtb_th;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}