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

        private double bound_min_x;
        private double bound_max_x;
        private double bound_min_y;
        private double bound_max_y;

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

            txt_min_bound_x.Text = Math.Pow(10, chart.get_min_bound_x()).ToString();
            txt_max_bound_x.Text = Math.Pow(10, chart.get_max_bound_x()).ToString();
            txt_min_bound_y.Text = chart.get_min_bound_y().ToString();
            txt_max_bound_y.Text = chart.get_max_bound_y().ToString();

            bound_min_x = Math.Pow(10, chart.get_min_bound_x());
            bound_max_x = Math.Pow(10, chart.get_max_bound_x());
            bound_min_y = chart.get_min_bound_y();
            bound_max_y = chart.get_max_bound_y();
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
            //chart.set_plateau1_fixed(false);
            //chart.set_plateau2_fixed(false);
            //chart.set_dip_fixed(false);
            //chart.set_ec50_1_fixed(false);
            //chart.set_ec50_2_fixed(false);
            //chart.set_slope1_fixed(false);
            //chart.set_slope2_fixed(false);

            chart.set_data_modified(true);

            bound_min_x = Math.Log10(Double.Parse(txt_min_bound_x.Text));
            bound_max_x = Math.Log10(Double.Parse(txt_max_bound_x.Text));
            bound_min_y = Double.Parse(txt_min_bound_y.Text);
            bound_max_y = Double.Parse(txt_max_bound_y.Text);

            chart.set_min_bound_x(Math.Log10(Double.Parse(txt_min_bound_x.Text)));
            chart.set_max_bound_x(Math.Log10(Double.Parse(txt_max_bound_x.Text)));
            chart.set_min_bound_y(Double.Parse(txt_min_bound_y.Text));
            chart.set_max_bound_y(Double.Parse(txt_max_bound_y.Text));

            chart.draw_DRC(false, false);
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            chart.set_bound_status(true);
            chart.set_manual_bound(true);
            chart.set_general_params(false);
            //chart.set_plateau1_fixed(false);
            //chart.set_plateau2_fixed(false);
            //chart.set_dip_fixed(false);
            //chart.set_ec50_1_fixed(false);
            //chart.set_ec50_2_fixed(false);
            //chart.set_slope1_fixed(false);
            //chart.set_slope2_fixed(false);
            chart.set_data_modified(false);

            chart.draw_DRC(false, false);

            txt_min_bound_x.Text = Math.Pow(10, chart.get_min_bound_x()).ToString();
            txt_max_bound_x.Text = Math.Pow(10, chart.get_max_bound_x()).ToString();
            txt_min_bound_y.Text = chart.get_min_bound_y().ToString();
            txt_max_bound_y.Text = chart.get_max_bound_y().ToString();

            bound_min_x = Math.Pow(10, chart.get_min_bound_x());
            bound_max_x = Math.Pow(10, chart.get_max_bound_x());
            bound_min_y = chart.get_min_bound_y();
            bound_max_y = chart.get_max_bound_y();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            plateau1_fixed = double.Parse(text_box_fix_plateau1.Text.ToString());
            plateau1_fixed = double.Parse(text_box_fix_plateau1.Text.ToString());
            dip_fixed = double.Parse(text_box_fix_dip.Text.ToString());
            ec50_1_fixed = double.Parse(text_box_fix_ec50_1.Text.ToString());
            ec50_2_fixed = double.Parse(text_box_fix_ec50_2.Text.ToString());
            slope1_fixed = double.Parse(text_box_fix_slope1.Text.ToString());
            slope2_fixed = double.Parse(text_box_fix_slope2.Text.ToString());

            chart.set_bound_status(true);
            chart.set_manual_bound(true);
            chart.set_general_params(false);
            //chart.set_plateau1_fixed(false);
            //chart.set_plateau2_fixed(false);
            //chart.set_dip_fixed(false);
            //chart.set_ec50_1_fixed(false);
            //chart.set_ec50_2_fixed(false);
            //chart.set_slope1_fixed(false);
            //chart.set_slope2_fixed(false);
            chart.set_data_modified(true);

            chart.set_plateau1_fixed_value(plateau1_fixed);
            chart.set_plateau2_fixed_value(plateau2_fixed);
            chart.set_dip_fixed_value(dip_fixed);
            chart.set_ec50_1_fixed_value(ec50_1_fixed);
            chart.set_ec50_2_fixed_value(ec50_2_fixed);
            chart.set_slope1_fixed_value(slope1_fixed);
            chart.set_slope2_fixed_value(slope2_fixed);

            chart.draw_DRC(false, false);
        }
    }
}
