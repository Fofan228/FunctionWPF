using System;
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

namespace FunctionWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double step = 3;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SizeChange(object sender, RoutedEventArgs e)
        {
            Draw();
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            Draw();
        }
        private void MainCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (step > 100) return;
                else
                    step += 1;
            }
            else if (step - 1 > 0)
            {
                step -= 1;
            }
            else
            {
                return;
            }
            Draw();
        }
        private void Draw()
        {
            canvas.Children.Clear();
            var function = new Function(canvas, input.Text.ToLower());
            try
            {
                function.DrawAxes();
                function.DrowFunction(step);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
