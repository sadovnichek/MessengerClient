namespace MessengerUI
{
    partial class SetName
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
            label = new Label();
            nameField = new TextBox();
            button = new Button();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label.Location = new Point(29, 75);
            label.Name = "label";
            label.Size = new Size(158, 38);
            label.TabIndex = 0;
            label.Text = "Enter name";
            // 
            // nameField
            // 
            nameField.Location = new Point(232, 89);
            nameField.Name = "nameField";
            nameField.Size = new Size(195, 27);
            nameField.TabIndex = 1;
            // 
            // button
            // 
            button.Location = new Point(333, 173);
            button.Name = "button";
            button.Size = new Size(94, 29);
            button.TabIndex = 2;
            button.Text = "Set name";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // SetName
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 223);
            Controls.Add(button);
            Controls.Add(nameField);
            Controls.Add(label);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SetName";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label;
        private TextBox nameField;
        private Button button;
    }
}