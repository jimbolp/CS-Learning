﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Threading;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CollectedOrders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string connectionString = @"data source=DENU00CL0076\CYRGEN;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;";
        DbContext db = new DbContext(connectionString);
        public CollectionViewSource collection { get; set; }
        private object lockObj { get; set; } = new object();
        ObservableCollection<LatestOrderTime> result = new ObservableCollection<LatestOrderTime>();
        BackgroundWorker WorkInBackGround = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            collection = (CollectionViewSource)(FindResource("ItemsCollectionViewSource"));
            WorkInBackGround.DoWork += WorkInBackGround_DoWork;
            WorkInBackGround.ProgressChanged += WorkInBackGround_ProgressChanged;
            WorkInBackGround.RunWorkerCompleted += WorkInBackGround_RunWorkerCompleted;
            WorkInBackGround.WorkerReportsProgress = true;
            WorkInBackGround.WorkerSupportsCancellation = true;
        }

        private void WorkInBackGround_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                txtBlock_Result.Text = "Canceled!";
            else if (e.Error != null)
                txtBlock_Result.Text = "Exception cought in RunWorkerCompleted event => " + e.Error.ToString();
            progressBar.Value = progressBar.Maximum;
        }

        private void WorkInBackGround_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void WorkInBackGround_DoWork(object sender, DoWorkEventArgs e)
        {
            //var worker = sender as BackgroundWorker;
            var defaultCursor = Application.Current.Dispatcher.Invoke(() => Application.Current.MainWindow.Cursor);
            Application.Current.Dispatcher.Invoke(() => Application.Current.MainWindow.Cursor = Cursors.Wait);
            StartQuery(sender as BackgroundWorker);
            Application.Current.Dispatcher.Invoke(() => Application.Current.MainWindow.Cursor = defaultCursor);
        }

        private void StartQuery(BackgroundWorker worker)
        {
            string[] customersNo = txtBox_CustomerNo.Dispatcher.Invoke(() => txtBox_CustomerNo.Text.Trim().Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries));

            int count = 0;
            try
            {
                foreach (string cust in customersNo)
                {
                    var customer = Helper.GetBranch(cust);

                    if (customer.isFound)
                    {
                        var queryResult = Helper.GetResultFromDb(customer.dbName, customer.customerNo);

                        foreach (var res in queryResult)
                        {
                            count += 100 / (queryResult.Count() * customersNo.Count());
                            worker.ReportProgress(count, count.ToString());
                            Application.Current.Dispatcher.Invoke(() => (Application.Current.MainWindow as MainWindow).result.Add(res));
                        }
                        collection.Dispatcher.Invoke(() => collection.Source = result);
                    }
                }
            }
            catch (Exception ex)
            {
                txtBlock_Result.Dispatcher.Invoke(() => txtBlock_Result.Text = "Exception inside worker => " + ex.ToString());
            }
            finally
            {
                txtBlock_Result.Dispatcher.Invoke(() => txtBlock_Result.Text = "Done!");
                
            }
        }

        private void Btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (!WorkInBackGround.IsBusy)
            {
                result = new ObservableCollection<LatestOrderTime>();
                collection.Source = result;
                WorkInBackGround.RunWorkerAsync();
            }
            else
                txtBlock_Result.Text = "Task is already running";
            //503782;503779;208183;208177
        }

        private void btn_CalculateManual_Click(object sender, RoutedEventArgs e)
        {
            txtBlock_ManualResult.Text = "";
            if (int.TryParse(txtBox_CustomerMan.Text, out int customerID))
            {
                var toursAsStr = result.Where(r => r.CustomerNo == customerID).Select(r => r.TourIDs).FirstOrDefault();
                string[] tours = toursAsStr.Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (txtBox_Tour.Text.Length >= 4)
                {
                    string tourTime = txtBox_Tour.Text.Substring(txtBox_Tour.Text.Length - 4);
                    txtBlock_ManualResult.Text += "Избран маршрут: " + tourTime + " ->  ";
                    Calc(tourTime);
                }
                else
                {
                    txtBox_Tour.Text += "Маршрути от базата: " + Environment.NewLine;
                    foreach (var tour in tours)
                    {
                        Calc(tour);
                    }
                }
            }
        }

        private void Calc(string tour)
        {
            int maxTimeInMinutes = 0;
            int tourMinutes = 0;
            if (tour.Length >= 6)
            {
                if (int.TryParse(tour.Substring(2, 4), out int tourTime))
                {
                    tourMinutes = (tourTime % 100) + (((tourTime % 10000) / 100) * 60);
                    if (int.TryParse(txtBox_MaxTime.Text, out int maxTime))
                    {
                        maxTimeInMinutes = (maxTime % 100) + (((maxTime % 10000) / 100) * 60);
                    }
                }
            }
            else
            {
                if (int.TryParse(tour, out int tourTime))
                {
                    tourMinutes = (tourTime % 100) + (((tourTime % 10000) / 100) * 60);
                    if (int.TryParse(txtBox_MaxTime.Text, out int maxTime))
                    {
                        maxTimeInMinutes = (maxTime % 100) + (((maxTime % 10000) / 100) * 60);
                    }
                }
            }
            if (tourMinutes > maxTimeInMinutes)
                txtBlock_ManualResult.Text += tour + " => " + (tourMinutes - maxTimeInMinutes) + "; ";
        }
    }
}
