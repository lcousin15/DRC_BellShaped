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
    public partial class Descriptors_General_Options : Form
    {
        MainTab _main_tab;

        public Descriptors_General_Options(MainTab main_tab)
        {
            InitializeComponent();
            _main_tab = main_tab;
        }

        //private double bnd_min_x;
        //private double bnd_max_x;
        //private double bnd_min_y;
        //private double bnd_max_y;

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

        private double window_min_x;
        private double window_max_x;
        private double window_min_y;
        private double window_max_y;

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            double idx = 0;
            double descriptor_number = _main_tab.get_descriptor_list().Count;

            toolStripProgressBar1.Visible = true;

            foreach (string item in _main_tab.get_descriptor_list())
            {
                //-------------------------- Fit Bounds Parameters --------------------------//

                //-------------------------- Window Parameters --------------------------//

                if (this.panel2.Controls.ContainsKey("txt_box_window_min_x_descriptor_" + item))
                {
                    TextBox txt_box = this.panel2.Controls["txt_box_window_min_x_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out window_min_x);
                }

                if (this.panel2.Controls.ContainsKey("txt_box_window_max_x_descriptor_" + item))
                {
                    TextBox txt_box = this.panel2.Controls["txt_box_window_max_x_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out window_max_x);
                }

                if (this.panel2.Controls.ContainsKey("txt_box_window_min_y_descriptor_" + item))
                {
                    TextBox txt_box = this.panel2.Controls["txt_box_window_min_y_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out window_min_y);
                }

                if (this.panel2.Controls.ContainsKey("txt_box_window_max_y_descriptor_" + item))
                {
                    TextBox txt_box = this.panel2.Controls["txt_box_window_max_y_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out window_max_y);
                }

                _main_tab.apply_descritpor_general_scale(item, window_min_x, window_max_x, window_min_y, window_max_y); // item = descriptor name

                idx++;
                toolStripProgressBar1.Value = (int)(100 * idx / descriptor_number);

            }

            toolStripProgressBar1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double idx = 0;
            double descriptor_number = _main_tab.get_descriptor_list().Count;

            toolStripProgressBar1.Visible = true;

            double[] bounds_min = { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
            double[] bounds_max = { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
            bool[] if_bounds_min = { false, false, false, false, false, false, false };
            bool[] if_bounds_max = { false, false, false, false, false, false, false };

            foreach (string item in _main_tab.get_descriptor_list())
            {

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_min_plateau1_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_min_plateau1_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_min_plateau1);
                    bounds_min[0] = bound_min_plateau1;
                    if_bounds_min[0] = is_converted;
                }

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_max_plateau1_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_max_plateau1_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_max_plateau1);
                    bounds_max[0] = bound_max_plateau1;
                    if_bounds_max[0] = is_converted;
                }

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_min_plateau2_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_min_plateau2_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_min_plateau2);
                    bounds_min[1] = bound_min_plateau2;
                    if_bounds_min[1] = is_converted;
                }

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_max_plateau2_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_max_plateau2_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_max_plateau2);
                    bounds_max[1] = bound_max_plateau2;
                    if_bounds_max[1] = is_converted;
                }

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_min_dip_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_min_dip_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_min_dip);
                    bounds_min[2] = bound_min_dip;
                    if_bounds_min[2] = is_converted;
                }

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_max_dip_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_max_dip_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_max_dip);
                    bounds_max[2] = bound_max_dip;
                    if_bounds_max[2] = is_converted;
                }

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_min_ec50_1_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_min_ec50_1_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_min_ec50_1);
                    bounds_min[3] = Math.Log10(bound_min_ec50_1);
                    if_bounds_min[3] = is_converted;
                }

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_max_ec50_1_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_max_ec50_1_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_max_ec50_1);
                    bounds_max[3] = Math.Log10(bound_max_ec50_1);
                    if_bounds_max[3] = is_converted;
                }

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_min_ec50_2_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_min_ec50_2_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_min_ec50_2);
                    bounds_min[4] = Math.Log10(bound_min_ec50_2);
                    if_bounds_min[4] = is_converted;
                }

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_max_ec50_2_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_max_ec50_2_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_max_ec50_2);
                    bounds_max[4] = Math.Log10(bound_max_ec50_2);
                    if_bounds_max[4] = is_converted;
                }

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_min_slope1_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_min_slope1_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_min_slope1);
                    bounds_min[5] = bound_min_slope1;
                    if_bounds_min[5] = is_converted;
                }

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_max_slope1_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_max_slope1_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_max_slope1);
                    bounds_max[5] = bound_max_slope1;
                    if_bounds_max[5] = is_converted;
                }

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_min_slope2_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_min_slope2_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_min_slope2);
                    bounds_min[6] = bound_min_slope2;
                    if_bounds_min[6] = is_converted;
                }

                if (this.panel1.Controls.ContainsKey("txt_box_bnd_max_slope2_descriptor_" + item))
                {
                    TextBox txt_box = this.panel1.Controls["txt_box_bnd_max_slope2_descriptor_" + item] as TextBox;
                    bool is_converted = double.TryParse(txt_box.Text.ToString(), out bound_max_slope2);
                    bounds_max[6] = bound_max_slope2;
                    if_bounds_max[6] = is_converted;
                }

                _main_tab.apply_descritpor_general_bounds(item, bounds_min, bounds_max, if_bounds_min, if_bounds_max); // item = descriptor name

                idx++;
                toolStripProgressBar1.Value = (int)(100 * idx / descriptor_number);
            }

            toolStripProgressBar1.Visible = false;
        }
    };

}
