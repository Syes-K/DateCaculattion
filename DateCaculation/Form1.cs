using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DateCalculation
{
    public partial class Form1 : Form
    {
        object[] grantRemandDateItems = new object[] {
            "-7天",
            "-15天",
            "-1月"};
        object[] yearFeeItems = new object[] {
            "-7天",
            "-1月",
            "-3月"};

        object[] oAItems = new object[] {
            "-7天",
            "-15天"
            };
        object[] oADebugItems = new object[] {
            "-7天",
            "-15天",
            "-1月"
            };

        private void DateChanged(Panel p, DateTimePicker startDtp)
        {
            ComboBox cbo = p.Controls[1] as ComboBox;
            DateTimePicker dtp = p.Controls[0] as DateTimePicker;

            DateTime startDate = startDtp.Value;


            string date = cbo.SelectedItem.ToString();
            string type = date.Substring(date.Length - 1, 1);
            int changedValue = Convert.ToInt32(date.Replace(type, ""));
            switch (type)
            {
                case "天":
                    dtp.Value = startDate.AddDays(changedValue);
                    break;
                case "月":
                    dtp.Value = startDate.AddMonths(changedValue);
                    break;
                case "年":
                    dtp.Value = startDate.AddYears(changedValue);
                    break;


            }

        }
        public Form1()
        {
            InitializeComponent();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int index = 0; index < gbGrantRemandDate.Controls.Count; index++)
            {
                Panel p = gbGrantRemandDate.Controls[index] as Panel;
                ComboBox cbo = p.Controls[1] as ComboBox;
                cbo.Items.AddRange(grantRemandDateItems);
                cbo.SelectedIndex = index;
            }

            for (int index = 0; index < gbYearFee.Controls.Count; index++)
            {
                Panel p = gbYearFee.Controls[index] as Panel;
                ComboBox cbo = p.Controls[1] as ComboBox;
                cbo.Items.AddRange(yearFeeItems);
                cbo.SelectedIndex = index;
            }
            for (int index = 0; index < gbOA1.Controls.Count; index++)
            {
                Panel p = gbOA1.Controls[index] as Panel;
                ComboBox cbo = p.Controls[1] as ComboBox;
                cbo.Items.AddRange(oAItems);
                cbo.SelectedIndex = index;
            }
      
            
            for (int index = 0; index < gbOA2.Controls.Count; index++)
            {
                Panel p = gbOA2.Controls[index] as Panel;
                ComboBox cbo = p.Controls[1] as ComboBox;
                cbo.Items.AddRange(oAItems);
                cbo.SelectedIndex = index;
            }
            for (int index = 0; index < gbOADebug.Controls.Count; index++)
            {
                Panel p = gbOADebug.Controls[index] as Panel;
                ComboBox cbo = p.Controls[1] as ComboBox;
                cbo.Items.AddRange(oADebugItems);
                cbo.SelectedIndex = index;
            }
            for (int index = 0; index < gbAddedDate.Controls.Count; index++)
            {
                Panel p = gbAddedDate.Controls[index] as Panel;
                ComboBox cbo = p.Controls[0] as ComboBox;
                cbo.SelectedIndex = index;
            }
            dtpGrantStartDate.Value = DateTime.Now;
            dtpYearFee.Value = DateTime.Now;
            dtppublic1.Value = DateTime.Now;
            dtppublic2.Value = DateTime.Now;
            dtpOADebug.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now;
        }


        private void dtpGrantStartDate_ValueChanged(object sender, EventArgs e)
        {

            for (int index = 0; index < gbGrantRemandDate.Controls.Count; index++)
            {
                DateChanged(gbGrantRemandDate.Controls[index] as Panel, dtpGrantStartDate);
            }

        }



        private void dtpYearFee_ValueChanged(object sender, EventArgs e)
        {
            for (int index = 0; index < gbYearFee.Controls.Count; index++)
            {
                DateChanged(gbYearFee.Controls[index] as Panel, dtpYearFee);
            }
        }

        private void dtppublic1_ValueChanged(object sender, EventArgs e)
        {
            dtpsended1.Value = dtppublic1.Value.AddDays(20);
            dtpEnded1.Value = dtppublic1.Value.AddDays(15).AddMonths(4);
        }

        private void dtpEnded1_ValueChanged(object sender, EventArgs e)
        {
            for (int index = 0; index < gbOA1.Controls.Count; index++)
            {
                DateChanged(gbOA1.Controls[index] as Panel, dtpEnded1);
            }
            
        }

        private void dtppublic2_ValueChanged(object sender, EventArgs e)
        {
            dtpsended2.Value = dtppublic2.Value.AddDays(15);
            dtpEnded2.Value = dtppublic2.Value.AddDays(15).AddMonths(2);
        }
        private void dtpOADebug_ValueChanged(object sender, EventArgs e)
        {
            for (int index = 0; index < gbOADebug.Controls.Count; index++)
            {
                DateChanged(gbOADebug.Controls[index] as Panel, dtpOADebug);
            }
        }
        private void dtpEnded2_ValueChanged(object sender, EventArgs e)
        {
            for (int index = 0; index < gbOA2.Controls.Count; index++)
            {
                DateChanged(gbOA2.Controls[index] as Panel, dtpEnded2);
            }
        }

        private void btncaculate_Click(object sender, EventArgs e)
        {
            DateTime dt = dtpStartDate.Value;
            for (int index = 0; index < gbAddedDate.Controls.Count; index++)
            {
                Panel p = gbAddedDate.Controls[index] as Panel;
                ComboBox cbo = p.Controls[0] as ComboBox;
                TextBox txt = p.Controls[1] as TextBox;
                if (!String.IsNullOrEmpty(txt.Text))
                {
                    int changedValue = 0;
                    try
                    {
                        changedValue = Convert.ToInt32(txt.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("请输入正确的数字！");
                    }
                    
                    switch (cbo.SelectedItem.ToString())
                    {
                        case "天":
                            dt = dt.AddDays(changedValue);
                            break;
                        case "月":
                            dt = dt.AddMonths(changedValue);
                            break;
                        case "年":
                            dt = dt.AddYears(changedValue);
                            break;


                    } 
                }
            }
            dtpEndDate.Value = dt;

        }

     





    }
}
