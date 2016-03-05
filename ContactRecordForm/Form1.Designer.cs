using System.Data;

namespace ContactRecordForm
{
    partial class RecordDateGridView
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.RecordDataGridView = new System.Windows.Forms.DataGridView();
            this.SearchButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.FormatLabelInstructions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RecordDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(494, 376);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(93, 37);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // RecordDataGridView
            // 
            this.RecordDataGridView.AllowUserToOrderColumns = true;
            this.RecordDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecordDataGridView.Location = new System.Drawing.Point(10, 11);
            this.RecordDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.RecordDataGridView.MultiSelect = false;
            this.RecordDataGridView.Name = "RecordDataGridView";
            this.RecordDataGridView.ReadOnly = true;
            this.RecordDataGridView.RowTemplate.Height = 24;
            this.RecordDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RecordDataGridView.Size = new System.Drawing.Size(579, 251);
            this.RecordDataGridView.TabIndex = 1;
            this.RecordDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RecordDataGridView_CellContentClick);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(10, 316);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(2);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(94, 34);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(108, 317);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(94, 33);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(206, 317);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(94, 33);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(388, 376);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(2);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(101, 37);
            this.RefreshButton.TabIndex = 5;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(10, 292);
            this.InputTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(580, 20);
            this.InputTextBox.TabIndex = 6;
            this.InputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            // 
            // FormatLabelInstructions
            // 
            this.FormatLabelInstructions.AutoSize = true;
            this.FormatLabelInstructions.Location = new System.Drawing.Point(13, 274);
            this.FormatLabelInstructions.Name = "FormatLabelInstructions";
            this.FormatLabelInstructions.Size = new System.Drawing.Size(244, 13);
            this.FormatLabelInstructions.TabIndex = 7;
            this.FormatLabelInstructions.Text = "Format: Name,House Number,Street,City,State,Zip";
            this.FormatLabelInstructions.Click += new System.EventHandler(this.FormatLabelInstructions_Click);
            // 
            // RecordDateGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 424);
            this.Controls.Add(this.FormatLabelInstructions);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.RecordDataGridView);
            this.Controls.Add(this.CloseButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RecordDateGridView";
            this.Text = "Contacts";
            ((System.ComponentModel.ISupportInitialize)(this.RecordDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.DataGridView RecordDataGridView;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Label FormatLabelInstructions;
    }
}

