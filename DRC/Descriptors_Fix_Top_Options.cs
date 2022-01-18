using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRC
{
    public partial class Descriptors_Fix_Top_Options : Form
    {
        MainTab _main_tab;

        public Descriptors_Fix_Top_Options(MainTab main_tab)
        {
            InitializeComponent();

            _main_tab = main_tab;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            foreach (string descriptor_name in _main_tab.get_descriptor_list())
            {
                foreach (KeyValuePair<string, List<Chart_DRC>> elem in _main_tab.get_descriptors_chart())
                {
                    string BATCH_ID = elem.Key;
                    List<Chart_DRC> cpd_charts = elem.Value;

                    foreach (Chart_DRC current_chart in cpd_charts)
                    {
                        if (current_chart.get_Descriptor_Name() == descriptor_name)
                        {
                            current_chart.set_plateau1_fixed(false);
                            current_chart.set_plateau2_fixed(false);
                            current_chart.set_dip_fixed(false);
                            current_chart.set_ec50_1_fixed(false);
                            current_chart.set_ec50_2_fixed(false);
                            current_chart.set_slope1_fixed(false);
                            current_chart.set_slope2_fixed(false);

                            current_chart.set_data_modified(true);
                            current_chart.draw_DRC(false, false);
                        }
                    }
                }
            }
        }
    }
}
