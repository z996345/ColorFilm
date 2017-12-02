using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ColorFilm
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Close_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            Close_btn.Visibility = Visibility.Visible;
            Background_Color_Picker.Visibility = Visibility.Visible;
            Alpha_Controlor.Visibility = Visibility.Visible;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            Close_btn.Visibility = Visibility.Hidden;
            Background_Color_Picker.Visibility = Visibility.Hidden;
            Alpha_Controlor.Visibility = Visibility.Hidden;
        }

        private void Background_Color_Picker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            var color = Background_Color_Picker.SelectedColor.Value;
            if (color.A == 0) {
                color.A = 1;
            }
            ColorFilm.Background = new SolidColorBrush(color);
            Alpha_Controlor.Value = color.A;
        }

        private void Alpha_Controlor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var background = ColorFilm.Background;
            if (background is SolidColorBrush)
            {
                var backgroundColor = ((SolidColorBrush)background).Color;
                backgroundColor.A = (byte)Alpha_Controlor.Value;
                ColorFilm.Background = new SolidColorBrush(backgroundColor);
            }
        }
    }
}