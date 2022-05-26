using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Input;

namespace Calculator_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in GroupButton.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string textWindow = ((Button)e.OriginalSource).Content.ToString();

                if (textWindow == "AC")
                {
                    textLabel.Clear();
                }
                else if (textWindow == "DEL")
                {
                    textLabel.Text = textLabel.Text.Remove(textLabel.Text.Length - 1, 1);
                    //textLabel.Text = textLabel.Text.Substring(0, textLabel.Text.Length - 1);    // (эта залупа криво работает.) Потому что Потерял первый арг ( 0 ).
                }
                else if (textWindow == "=")
                {
                    textLabel.Text = new DataTable().Compute(textLabel.Text, null).ToString();

                }
                else textLabel.Text += textWindow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_KeyDownPreview(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                    Zero.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad1:
                    One.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad2:
                    Two.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad3:
                    Three.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad4:
                    Four.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad5:
                    Five.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad6:
                    Six.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad7:
                    Seven.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad8:
                    Eight.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad9:
                    Nine.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Add:
                    Plus.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Subtract:
                    Minus.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Multiply:
                    Multiply.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Divide:
                    Divide.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Enter:
                    Equals.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Back:
                    Delete_el.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break ;
                case Key.Delete:
                    AllClear.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
            }
        }
    }
}
