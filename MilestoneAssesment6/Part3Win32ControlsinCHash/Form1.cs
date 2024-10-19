using Microsoft.VisualBasic;

namespace Part3Win32ControlsinCHash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            string itemCode = Interaction.InputBox("Please enter Id", "User input");
            string itemName = Interaction.InputBox("Please enter Name", "User input");
            if (!string.IsNullOrEmpty(itemCode) && !string.IsNullOrEmpty(itemName))
            {
                AddNewItem(itemCode, itemName);
            }
            else
            {
                MessageBox.Show("Please input the item details!");
            }
        }
        private void AddNewItem(string itemCode, string itemName)
        {
            ListViewItem item = new ListViewItem(itemCode.ToString());
            item.SubItems.Add(itemName);
            listView1.Items.Add(item);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            //Check item selected or not
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    listView1.Items.Remove(item);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to remove");
            }
        }
    }
}