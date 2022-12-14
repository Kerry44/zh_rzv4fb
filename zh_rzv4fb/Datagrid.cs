using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zh_rzv4fb
{
    public partial class Datagrid : Form
    {

        Models.StudiesContext StudiesContext = new Models.StudiesContext();
        public Datagrid()
        {
            InitializeComponent();
        }

        private void Datagrid_Load(object sender, EventArgs e)
        {
            courseBindingSource.DataSource = StudiesContext.Courses.ToList();
        }
    }
}
