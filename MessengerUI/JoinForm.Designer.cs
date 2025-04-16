namespace MessengerUI
{
    partial class JoinForm
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
            tokenField = new TextBox();
            button = new Button();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label.Location = new Point(29, 75);
            label.Name = "label";
            label.Size = new Size(170, 41);
            label.TabIndex = 0;
            label.Text = "Enter token";
            // 
            // tokenField
            // 
            tokenField.Location = new Point(232, 89);
            tokenField.Name = "tokenField";
            tokenField.Size = new Size(187, 27);
            tokenField.TabIndex = 1;
            // 
            // button
            // 
            button.Location = new Point(333, 173);
            button.Name = "button";
            button.Size = new Size(94, 29);
            button.TabIndex = 2;
            button.Text = "Join";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // JoinForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 223);
            Controls.Add(button);
            Controls.Add(tokenField);
            Controls.Add(label);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "JoinForm";
            Text = "JoinForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label;
        private TextBox tokenField;
        private Button button;
    }
}