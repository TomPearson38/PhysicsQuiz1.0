using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicsQuiz1._0.GeneralForms
{
    public partial class ViewStats : Form
    {
        public ViewStats()
        {
            InitializeComponent();

            ListViewItem a = new ListViewItem("Question");
            a.SubItems.Add("1");
            a.SubItems.Add("2");
            a.SubItems.Add("3");
            a.SubItems.Add("4");
            a.SubItems.Add("5");

            listView1.Items.Add(a);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
