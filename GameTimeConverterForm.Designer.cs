namespace GameTimeConverter
{
    partial class GameTimeConverterForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelGameTime = new System.Windows.Forms.Label();
            this.textBoxGameTime = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.labelTaipeiTime = new System.Windows.Forms.Label();
            this.labelNewYorkTime = new System.Windows.Forms.Label();
            this.labelTaipeiTimeResult = new System.Windows.Forms.Label();
            this.labelNewYorkTimeResult = new System.Windows.Forms.Label();
            this.buttonConvertTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelGameTime
            // 
            this.labelGameTime.AutoSize = true;
            this.labelGameTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameTime.ForeColor = System.Drawing.Color.PeachPuff;
            this.labelGameTime.Location = new System.Drawing.Point(200, 101);
            this.labelGameTime.Name = "labelGameTime";
            this.labelGameTime.Size = new System.Drawing.Size(78, 21);
            this.labelGameTime.TabIndex = 0;
            this.labelGameTime.Text = "末日時間";
            // 
            // textBoxGameTime
            // 
            this.textBoxGameTime.BackColor = System.Drawing.Color.LightGray;
            this.textBoxGameTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxGameTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGameTime.Location = new System.Drawing.Point(304, 93);
            this.textBoxGameTime.Name = "textBoxGameTime";
            this.textBoxGameTime.Size = new System.Drawing.Size(176, 29);
            this.textBoxGameTime.TabIndex = 1;
            this.textBoxGameTime.Text = "yyyy-MM-dd HH:mm";
            this.textBoxGameTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxGameTime.Click += new System.EventHandler(this.textBoxGameTime_Click);
            this.textBoxGameTime.TextChanged += new System.EventHandler(this.textBoxGameTime_TextChanged);
            this.textBoxGameTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxGameTime_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // labelTaipeiTime
            // 
            this.labelTaipeiTime.AutoSize = true;
            this.labelTaipeiTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaipeiTime.ForeColor = System.Drawing.Color.Beige;
            this.labelTaipeiTime.Location = new System.Drawing.Point(200, 198);
            this.labelTaipeiTime.Name = "labelTaipeiTime";
            this.labelTaipeiTime.Size = new System.Drawing.Size(78, 21);
            this.labelTaipeiTime.TabIndex = 3;
            this.labelTaipeiTime.Text = "台北時間";
            this.labelTaipeiTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNewYorkTime
            // 
            this.labelNewYorkTime.AutoSize = true;
            this.labelNewYorkTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewYorkTime.ForeColor = System.Drawing.Color.Beige;
            this.labelNewYorkTime.Location = new System.Drawing.Point(200, 242);
            this.labelNewYorkTime.Name = "labelNewYorkTime";
            this.labelNewYorkTime.Size = new System.Drawing.Size(78, 21);
            this.labelNewYorkTime.TabIndex = 4;
            this.labelNewYorkTime.Text = "紐約時間";
            this.labelNewYorkTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTaipeiTimeResult
            // 
            this.labelTaipeiTimeResult.AutoSize = true;
            this.labelTaipeiTimeResult.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaipeiTimeResult.Location = new System.Drawing.Point(304, 198);
            this.labelTaipeiTimeResult.Name = "labelTaipeiTimeResult";
            this.labelTaipeiTimeResult.Size = new System.Drawing.Size(73, 21);
            this.labelTaipeiTimeResult.TabIndex = 5;
            this.labelTaipeiTimeResult.Text = "等候中...";
            this.labelTaipeiTimeResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNewYorkTimeResult
            // 
            this.labelNewYorkTimeResult.AutoSize = true;
            this.labelNewYorkTimeResult.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewYorkTimeResult.Location = new System.Drawing.Point(304, 242);
            this.labelNewYorkTimeResult.Name = "labelNewYorkTimeResult";
            this.labelNewYorkTimeResult.Size = new System.Drawing.Size(73, 21);
            this.labelNewYorkTimeResult.TabIndex = 6;
            this.labelNewYorkTimeResult.Text = "等候中...";
            this.labelNewYorkTimeResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConvertTime
            // 
            this.buttonConvertTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonConvertTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConvertTime.Location = new System.Drawing.Point(405, 139);
            this.buttonConvertTime.Name = "buttonConvertTime";
            this.buttonConvertTime.Size = new System.Drawing.Size(75, 29);
            this.buttonConvertTime.TabIndex = 7;
            this.buttonConvertTime.Text = "轉換";
            this.buttonConvertTime.UseVisualStyleBackColor = true;
            // 
            // GameTimeConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonConvertTime);
            this.Controls.Add(this.labelNewYorkTimeResult);
            this.Controls.Add(this.labelTaipeiTimeResult);
            this.Controls.Add(this.labelNewYorkTime);
            this.Controls.Add(this.labelTaipeiTime);
            this.Controls.Add(this.textBoxGameTime);
            this.Controls.Add(this.labelGameTime);
            this.Name = "GameTimeConverterForm";
            this.Text = "Game Time Converter for Last Z: Survival Shooter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGameTime;
        private System.Windows.Forms.TextBox textBoxGameTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label labelTaipeiTime;
        private System.Windows.Forms.Label labelNewYorkTime;
        private System.Windows.Forms.Label labelTaipeiTimeResult;
        private System.Windows.Forms.Label labelNewYorkTimeResult;
        private System.Windows.Forms.Button buttonConvertTime;
    }
}

