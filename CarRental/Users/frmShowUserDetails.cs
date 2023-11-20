using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Users
{
    public partial class frmShowUserDetails : Form
    {
        public frmShowUserDetails(int UserID, bool EditEnabled = true)
        {
            InitializeComponent();

            ucUserCard1.LoadUserInfo(UserID);

            ucUserCard1.EditEnabled = EditEnabled;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
