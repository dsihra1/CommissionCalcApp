using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CommissionSalesCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SolidColorBrush errorBrush = new SolidColorBrush(Windows.UI.Colors.Red);

        public MainPage()
        {
            this.InitializeComponent();
        }


        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            txtSalaryInput.Text = "";
            txtSalesQuotaInput.Text = "";
            txtTotalSalesInput.Text = "";
            txtSalesQuotaInput.Focus(FocusState.Programmatic);
            lblcommission.Text = "Commission amount=";
            lblpercent.Text = "Percent of Quota =";
            lblrate.Text = "Commission rate=";
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            decimal salesquota;
            decimal totalsales;
            decimal salary;
            decimal percent = 0;
            decimal rate;
            decimal commission;
            if (String.IsNullOrEmpty(txtSalesQuotaInput.Text))
            {
                txtSalesQuotaInput.Foreground = errorBrush;
                lblerror.Text = "Please Enter Sales Quota";
            }
            else if (String.IsNullOrEmpty(txtTotalSalesInput.Text))
            {
                lblerror.Text = "Please Enter Total Sales";
            }
            else if (String.IsNullOrEmpty(txtSalaryInput.Text))
            {
                lblerror.Text = "Please Enter Salary";
            }
            else
            {
                lblerror.Text = "";
                if (!Decimal.TryParse(txtSalesQuotaInput.Text, out salesquota))
                {
                    lblerror.Text = "Please enter valid input for sales quota";
                }
                else if (!Decimal.TryParse(txtTotalSalesInput.Text, out totalsales))
                {
                    lblerror.Text = "Please enter valid input for sales quota";
                }
                else if (!Decimal.TryParse(txtSalaryInput.Text, out salary))
                {
                    lblerror.Text = "Please input valid salary";
                }
                else
                {
                    lblerror.Text = "";
                    try
                    {
                        percent = SalesCommission.percent_of_quota(totalsales, salesquota);
                        lblpercent.Text += percent.ToString() + "%";
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        lblerror.Text = "Sales Quota cannot be zero or less than zero";
                    }

                    rate = SalesCommission.rate(percent);
                    lblrate.Text += rate.ToString() + "%";
                    commission = salary * rate / 100m;
                    lblcommission.Text += "$" + Math.Round(commission, 2).ToString();

                }


            }
        }
    }
}