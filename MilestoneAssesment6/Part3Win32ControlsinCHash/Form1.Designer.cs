namespace Part3Win32ControlsinCHash
{
    partial class Form1
    {
        
        private System.ComponentModel.IContainer components = null;

         protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

       private void InitializeComponent()
        {
            listView1 = new ListView();
            Id = new ColumnHeader();
            Name = new ColumnHeader();
            Insert = new Button();
            Remove = new Button();
            SuspendLayout();
            
            listView1.Columns.AddRange(new ColumnHeader[] { Id, Name });
            listView1.Location = new Point(32, 50);
            listView1.Name = "listView1";
            listView1.Size = new Size(528, 342);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
           
            Id.Text = "Id Number";
            Id.Width = 100;
           
            Name.Text = "Name";
            Name.Width = 200;
             
            Insert.BackColor = SystemColors.ActiveCaption;
            Insert.Location = new Point(319, 398);
            Insert.Name = "Insert";
            Insert.Size = new Size(75, 23);
            Insert.TabIndex = 1;
            Insert.Text = "Insert";
            Insert.UseVisualStyleBackColor = false;
            Insert.Click += Insert_Click;
             
            Remove.BackColor = Color.IndianRed;
            Remove.Location = new Point(430, 400);
            Remove.Name = "Remove";
            Remove.Size = new Size(75, 23);
            Remove.TabIndex = 2;
            Remove.Text = "Remove";
            Remove.UseVisualStyleBackColor = false;
            Remove.Click += Remove_Click;
           
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Remove);
            Controls.Add(Insert);
            Controls.Add(listView1);            
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader Id;
        private ColumnHeader Name;
        private Button Insert;
        private Button Remove;
    }
}