using C1CollectionView101.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C1CollectionView101
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


        }

        private void menu1_SelectionChanged(object sender, EventArgs e)
        {
            switch(menu1.SelectedSampleViewType)
            {
                case 0:
                    tabControl1.SelectedIndex = 1;
                    sorting1.ShowPage(menu1);
                    break;
                case 1:
                    tabControl1.SelectedIndex = 2;
                    filtering1.ShowPage(menu1);
                    break;
                case 2:
                    tabControl1.SelectedIndex = 3;
                    grouping1.ShowPage(menu1);
                    break;
                default:
                    tabControl1.SelectedIndex = 0;
                    break;
            }
        }
    }
}
