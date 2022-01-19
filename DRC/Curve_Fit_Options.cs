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
    public partial class Curve_Fit_Options : Form
    {
        private Chart_DRC chart;

        //private double bound_min_x;
        //private double bound_max_x;
        //private double bound_min_y;
        //private double bound_max_y;

        private double bound_min_plateau1;
        private double bound_max_plateau1;
        private double bound_min_plateau2;
        private double bound_max_plateau2;
        private double bound_min_dip;
        private double bound_max_dip;
        private double bound_min_ec50_1;
        private double bound_max_ec50_1;
        private double bound_min_ec50_2;
        private double bound_max_ec50_2;
        private double bound_min_slope1;
        private double bound_max_slope1;
        private double bound_min_slope2;
        private double bound_max_slope2;

        //private double top_fixed;
        private double plateau1_fixed;
        private double plateau2_fixed;
        private double dip_fixed;
        private double ec50_1_fixed;
        private double ec50_2_fixed;
        private double slope1_fixed;
        private double slope2_fixed;

        public Curve_Fit_Options(Chart_DRC my_chart)
        {
            InitializeComponent();
            chart = my_chart;

            chart.set_manual_bound(true);
            chart.set_bound_status(false);

            txt_min_bound_plateau1.Text = chart.get_min_bound_plateau1().ToString();
            txt_max_bound_plateau1.Text = chart.get_max_bound_plateau1().ToString();
            txt_min_bound_plateau2.Text = chart.get_min_bound_plateau2().ToString();
            txt_max_bound_plateau2.Text = chart.get_max_bound_plateau2().ToString();
            txt_min_bound_dip.Text = chart.get_min_bound_dip().ToString();
            txt_max_bound_dip.Text = chart.get_max_bound_dip().ToString();
            txt_min_bound_ec50_1.Text = Math.Pow(10, chart.get_min_bound_ec50_1()).ToString();
            txt_max_bound_ec50_1.Text = Math.Pow(10, chart.get_max_bound_ec50_1()).ToString();
            txt_min_bound_ec50_2.Text = Math.Pow(10, chart.get_min_bound_ec50_2()).ToString();
            txt_max_bound_ec50_2.Text = Math.Pow(10, chart.get_max_bound_ec50_2()).ToString();
            txt_min_bound_slope1.Text = chart.get_min_bound_slope1().ToString();
            txt_max_bound_slope1.Text = chart.get_max_bound_slope1().ToString();
            txt_min_bound_slope2.Text = chart.get_min_bound_slope2().ToString();
            txt_max_bound_slope2.Text = chart.get_max_bound_slope2().ToString();

            bound_min_plateau1 = chart.get_min_bound_plateau1();
            bound_max_plateau1 = chart.get_max_bound_plateau1();
            bound_min_plateau2 = chart.get_min_bound_plateau2();
            bound_max_plateau2 = chart.get_max_bound_plateau2();
            bound_min_dip = chart.get_min_bound_dip();
            bound_max_dip = chart.get_max_bound_dip();
            bound_min_ec50_1 = chart.get_min_bound_ec50_1();
            bound_max_ec50_1 = chart.get_max_bound_ec50_1();
            bound_min_ec50_2 = chart.get_min_bound_ec50_2();
            bound_max_ec50_2 = chart.get_max_bound_ec50_2();
            bound_min_slope1 = chart.get_min_bound_slope1();
            bound_max_slope1 = chart.get_max_bound_slope1(); 
            bound_min_slope2 = chart.get_min_bound_slope2();
            bound_max_slope2 = chart.get_max_bound_slope2();

            if (chart.plateau1_fixed()) text_box_fix_plateau1.Text = chart.get_plateau1_fixed().ToString();
            if (chart.plateau2_fixed()) text_box_fix_plateau2.Text = chart.get_plateau2_fixed().ToString();
            if (chart.dip_fixed()) text_box_fix_dip.Text = chart.get_dip_fixed().ToString();
            if (chart.ec50_1_fixed()) text_box_fix_ec50_1.Text = chart.get_ec50_1_fixed().ToString();
            if (chart.ec50_2_fixed()) text_box_fix_ec50_2.Text = chart.get_ec50_2_fixed().ToString();
            if (chart.slope1_fixed()) text_box_fix_slope1.Text = chart.get_slope1_fixed().ToString();
            if (chart.slope2_fixed()) text_box_fix_slope2.Text = chart.get_slope2_fixed().ToString();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            chart.set_bound_status(false);
            chart.set_manual_bound(true);
            chart.set_general_params(false);
            chart.set_plateau1_fixed(false);
            chart.set_plateau2_fixed(false);
            chart.set_dip_fixed(false);
            chart.set_ec50_1_fixed(false);
            chart.set_ec50_2_fixed(false);
            chart.set_slope1_fixed(false);
            chart.set_slope2_fixed(false);

            chart.set_data_modified(true);


            bool if_min_plateau1 = Double.TryParse(txt_min_bound_plateau1.Text, out bound_min_plateau1);
            bool if_max_plateau1 = Double.TryParse(txt_max_bound_plateau1.Text, out bound_max_plateau1);
            bool if_min_plateau2 = Double.TryParse(txt_min_bound_plateau2.Text, out bound_min_plateau2);
            bool if_max_plateau2 = Double.TryParse(txt_max_bound_plateau2.Text, out bound_max_plateau2);
            bool if_min_dip = Double.TryParse(txt_min_bound_dip.Text, out bound_min_dip);
            bool if_max_dip = Double.TryParse(txt_max_bound_dip.Text, out bound_max_dip);
            bool if_min_ec50_1 = Double.TryParse(txt_min_bound_ec50_1.Text, out bound_min_ec50_1);
            bool if_max_ec50_1 = Double.TryParse(txt_max_bound_ec50_1.Text, out bound_max_ec50_1);
            bool if_min_ec50_2 = Double.TryParse(txt_min_bound_ec50_2.Text, out bound_min_ec50_2);
            bool if_max_ec50_2 = Double.TryParse(txt_max_bound_ec50_2.Text, out bound_max_ec50_2);
            bool if_min_slope1 = Double.TryParse(txt_min_bound_slope1.Text, out bound_min_slope1);
            bool if_max_slope1 = Double.TryParse(txt_max_bound_slope1.Text, out bound_max_slope1);
            bool if_min_slope2 = Double.TryParse(txt_min_bound_slope2.Text, out bound_min_slope2);
            bool if_max_slope2 = Double.TryParse(txt_max_bound_slope2.Text, out bound_max_slope2);

            //bound_min_x = Math.Log10(Double.Parse(txt_min_bound_x.Text));
            //bound_max_x = Math.Log10(Double.Parse(txt_max_bound_x.Text));
            //bound_min_y = Double.Parse(txt_min_bound_y.Text);
            //bound_max_y = Double.Parse(txt_max_bound_y.Text);

            if(if_min_plateau1) chart.set_min_bound_plateau1(bound_min_plateau1);
            if(if_max_plateau1) chart.set_max_bound_plateau1(bound_max_plateau1);
            if (if_min_plateau2) chart.set_min_bound_plateau2(bound_min_plateau2);
            if (if_max_plateau2) chart.set_max_bound_plateau2(bound_max_plateau2);
            if (if_min_dip) chart.set_min_bound_dip(bound_min_dip);
            if (if_max_dip) chart.set_max_bound_dip(bound_max_dip);
            if (if_min_ec50_1) chart.set_min_bound_ec50_1(Math.Log10(bound_min_ec50_1));
            if (if_max_ec50_1) chart.set_max_bound_ec50_1(Math.Log10(bound_max_ec50_1));
            if (if_min_ec50_2) chart.set_min_bound_ec50_2(Math.Log10(bound_min_ec50_2));
            if (if_max_ec50_2) chart.set_max_bound_ec50_2(Math.Log10(bound_max_ec50_2));
            if (if_min_slope1) chart.set_min_bound_slope1(bound_min_slope1);
            if (if_max_slope1) chart.set_max_bound_slope1(bound_max_slope1);
            if (if_min_slope2) chart.set_min_bound_slope2(bound_min_slope2);
            if (if_max_slope2) chart.set_max_bound_slope2(bound_max_slope2);

            chart.draw_DRC(false, false);
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            chart.set_bound_status(true);
            chart.set_manual_bound(true);
            chart.set_general_params(false);
            chart.set_plateau1_fixed(false);
            chart.set_plateau2_fixed(false);
            chart.set_dip_fixed(false);
            chart.set_ec50_1_fixed(false);
            chart.set_ec50_2_fixed(false);
            chart.set_slope1_fixed(false);
            chart.set_slope2_fixed(false);
            chart.set_data_modified(false);

            chart.draw_DRC(false, false);

            txt_min_bound_plateau1.Text = chart.get_min_bound_plateau1().ToString();
            txt_max_bound_plateau1.Text = chart.get_max_bound_plateau1().ToString();
            txt_min_bound_plateau2.Text = chart.get_min_bound_plateau2().ToString();
            txt_max_bound_plateau2.Text = chart.get_max_bound_plateau2().ToString();
            txt_min_bound_dip.Text = chart.get_min_bound_dip().ToString();
            txt_max_bound_dip.Text = chart.get_max_bound_dip().ToString();
            txt_min_bound_ec50_1.Text = Math.Pow(10, chart.get_min_bound_ec50_1()).ToString();
            txt_max_bound_ec50_1.Text = Math.Pow(10, chart.get_max_bound_ec50_1()).ToString();
            txt_min_bound_ec50_2.Text = Math.Pow(10, chart.get_min_bound_ec50_2()).ToString();
            txt_max_bound_ec50_2.Text = Math.Pow(10, chart.get_max_bound_ec50_2()).ToString();
            txt_min_bound_slope1.Text = chart.get_min_bound_slope1().ToString();
            txt_max_bound_slope1.Text = chart.get_max_bound_slope1().ToString();
            txt_min_bound_slope2.Text = chart.get_min_bound_slope2().ToString();
            txt_max_bound_slope2.Text = chart.get_max_bound_slope2().ToString();

            //bound_min_x = Math.Pow(10, chart.get_min_bound_x());
            //bound_max_x = Math.Pow(10, chart.get_max_bound_x());
            //bound_min_y = chart.get_min_bound_y();
            //bound_max_y = chart.get_max_bound_y();

            bound_min_plateau1 = chart.get_min_bound_plateau1();
            bound_max_plateau1 = chart.get_max_bound_plateau1();
            bound_min_plateau2 = chart.get_min_bound_plateau2();
            bound_max_plateau2 = chart.get_max_bound_plateau2();
            bound_min_dip = chart.get_min_bound_dip();
            bound_max_dip = chart.get_max_bound_dip();
            bound_min_ec50_1 = chart.get_min_bound_ec50_1();
            bound_max_ec50_1 = chart.get_max_bound_ec50_1();
            bound_min_ec50_2 = chart.get_min_bound_ec50_2();
            bound_max_ec50_2 = chart.get_max_bound_ec50_2();
            bound_min_slope1 = chart.get_min_bound_slope1();
            bound_max_slope1 = chart.get_max_bound_slope1();
            bound_min_slope2 = chart.get_min_bound_slope2();
            bound_max_slope2 = chart.get_max_bound_slope2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (text_box_fix_plateau1.Text != "")
            {
                chart.set_plateau1_fixed(true);
                plateau1_fixed = double.Parse(text_box_fix_plateau1.Text.ToString());
                chart.set_plateau1_fixed_value(plateau1_fixed);
            }
            else chart.set_plateau1_fixed(false);

            if (text_box_fix_plateau2.Text != "")
            {
                chart.set_plateau2_fixed(true);
                plateau2_fixed = double.Parse(text_box_fix_plateau2.Text.ToString());
                chart.set_plateau2_fixed_value(plateau2_fixed);
            }
            else chart.set_plateau2_fixed(false);

            if (text_box_fix_dip.Text != "")
            {
                chart.set_dip_fixed(true);
                dip_fixed = double.Parse(text_box_fix_dip.Text.ToString());
                chart.set_dip_fixed_value(dip_fixed);
            }
            else chart.set_dip_fixed(false);

            if (text_box_fix_ec50_1.Text != "")
            {
                chart.set_ec50_1_fixed(true);
                ec50_1_fixed = Math.Log10(double.Parse(text_box_fix_ec50_1.Text.ToString()));
                chart.set_ec50_1_fixed_value(ec50_1_fixed);
            }
            else chart.set_ec50_1_fixed(true);

            if (text_box_fix_ec50_2.Text != "")
            {
                chart.set_ec50_2_fixed(true);
                ec50_2_fixed = Math.Log10(double.Parse(text_box_fix_ec50_2.Text.ToString()));
                chart.set_ec50_2_fixed_value(ec50_2_fixed);
            }
            else chart.set_ec50_2_fixed(false);

            if (text_box_fix_slope1.Text != "")
            {
                chart.set_slope1_fixed(true);
                slope1_fixed = double.Parse(text_box_fix_slope1.Text.ToString());
                chart.set_slope1_fixed_value(slope1_fixed);

            }
            else chart.set_slope1_fixed(false);

            if (text_box_fix_slope2.Text != "")
            {
                chart.set_slope2_fixed(true);
                chart.set_slope2_fixed_value(slope2_fixed);
                slope2_fixed = double.Parse(text_box_fix_slope2.Text.ToString());
            }
            else chart.set_slope2_fixed(false);


            chart.set_bound_status(true);
            chart.set_manual_bound(true);
            chart.set_general_params(false);

            chart.set_data_modified(true);
            chart.draw_DRC(false, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart.set_plateau1_fixed(false);
            chart.set_plateau2_fixed(false);
            chart.set_dip_fixed(false);
            chart.set_ec50_1_fixed(false);
            chart.set_ec50_2_fixed(false);
            chart.set_slope1_fixed(false);
            chart.set_slope2_fixed(false);

            chart.set_data_modified(true);
            chart.draw_DRC(false, false);
        }
    }
}
