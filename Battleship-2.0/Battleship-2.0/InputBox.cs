using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship_2._0
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        // If the user clicks the enter button.
        private void EnterUsername(object sender, EventArgs e)
        {

            // Get the string the user stored.
            string username = txtUsername.Text;

            // If the string is empty, tell the user to enter a value, otherwise, set this form's DialogResult value to OK, signifying to the parent form that the value is ready.
            if (username.Length != 0)
                this.DialogResult = DialogResult.OK;

            else
                MessageBox.Show("Must enter value!");
        }
    }
}
