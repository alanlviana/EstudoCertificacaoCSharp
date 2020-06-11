using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace certificacao_csharp_pt11_relogio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        private CancellationTokenSource relogioCancelationToken;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IniciarRelogio();
        }

        private void IniciarRelogio()
        {
            relogioCancelationToken = new CancellationTokenSource();
            stopwatch.Restart();

            var taskRelogio = Task.Factory.StartNew(async () =>
            {
                while (!relogioCancelationToken.IsCancellationRequested)
                {
                    await Task.Delay(100);

                    var elapsedTime = stopwatch.Elapsed;
                    var minutes = elapsedTime.Minutes;
                    var seconds = elapsedTime.Seconds;
                    var miliseconds = elapsedTime.Milliseconds;

                    this.Dispatcher.Invoke(() => txtRelogio.Content = $"{minutes:00}:{seconds:00}:{miliseconds:000}");
                }

            });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            relogioCancelationToken.Cancel();
        }
    }
}
