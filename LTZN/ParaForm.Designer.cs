﻿namespace LTZN
{
    partial class ParaForm
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
            this.txtLeader = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtActor1 = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtActor2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLeader
            // 
            this.txtLeader.Location = new System.Drawing.Point(75, 22);
            this.txtLeader.Name = "txtLeader";
            this.txtLeader.Size = new System.Drawing.Size(100, 21);
            this.txtLeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "负责人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "日报制表人";
            // 
            // txtActor1
            // 
            this.txtActor1.Location = new System.Drawing.Point(75, 49);
            this.txtActor1.Name = "txtActor1";
            this.txtActor1.Size = new System.Drawing.Size(100, 21);
            this.txtActor1.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(138, 132);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(62, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(221, 132);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "月报制表人";
            // 
            // txtActor2
            // 
            this.txtActor2.Location = new System.Drawing.Point(75, 76);
            this.txtActor2.Name = "txtActor2";
            this.txtActor2.Size = new System.Drawing.Size(100, 21);
            this.txtActor2.TabIndex = 6;
            // 
            // ParaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 167);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtActor2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtActor1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLeader);
            this.Name = "ParaForm";
            this.Text = "报表设置";
            this.Load += new System.EventHandler(this.ParaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtActor1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtActor2;
    }
}