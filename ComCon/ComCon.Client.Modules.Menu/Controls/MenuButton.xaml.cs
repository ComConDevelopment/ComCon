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

namespace ComCon.Client.Modules.Menu.Controls
{
    /// <summary>
    /// Interaktionslogik für MenuButton.xaml
    /// </summary>
    public partial class MenuButton : UserControl
    {
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Brush), typeof(MenuButton), new PropertyMetadata(null, new PropertyChangedCallback(OnColorPropertyChanged)));
        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        private static void OnColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as MenuButton).Color = e.NewValue as Brush;
        }

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(MenuButton), new PropertyMetadata(null, new PropertyChangedCallback(OnLabelPropertyChanged)));
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        private static void OnLabelPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as MenuButton).Label = e.NewValue as string;
        }

        public static readonly DependencyProperty PathProperty = DependencyProperty.Register("Path", typeof(Geometry), typeof(MenuButton), new PropertyMetadata(null, new PropertyChangedCallback(OnPathPropertyChanged)));
        public Geometry Path
        {
            get { return (Geometry)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }

        private static void OnPathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as MenuButton).Path = e.NewValue as Geometry;
        }


        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(MenuButton), new PropertyMetadata(null, new PropertyChangedCallback(OnImageSourcePropertyChanged)));
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        private static void OnImageSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as MenuButton).ImageSource = e.NewValue as ImageSource;
        }

        public bool HasPath
        {
            get { return Path != null; }
        }

        public bool HasImage
        {
            get { return ImageSource != null; }
        }


        public MenuButton()
        {
            InitializeComponent();
        }
    }
}
