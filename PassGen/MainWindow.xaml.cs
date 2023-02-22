using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PassGen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        PasswordGenerator generator = new();
        StringBuilder allowedCharacters = new();
        public MainWindow()
        {
            InitializeComponent();
            small_letters.IsChecked = true;
            capital_letters.IsChecked = true;
            numbers.IsChecked = true;
            
        }

        public static async Task AddDelayExample()
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (small_letters.IsChecked == true) allowedCharacters.Append("abcdefghijklmnoprstuwxyz");
            if (capital_letters.IsChecked == true) allowedCharacters.Append("ABCDEFGHIJKLMNOPRSTUWXYZ");
            if (numbers.IsChecked == true) allowedCharacters.Append("1234567890");
            if (special_characters.IsChecked == true) allowedCharacters.Append("!@#$%^&*_+-=<>?");
            output_text_block.Text = generator.generatePassword(Convert.ToInt16(slValue.Value), allowedCharacters.ToString());
            allowedCharacters.Clear();

        }

        private void copy_btn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(output_text_block.Text);
        }

        private void Lock_Option_If_Only_Active()
        {
            if (small_letters.IsChecked == true && capital_letters.IsChecked == false && numbers.IsChecked == false && special_characters.IsChecked == false)
            {
                small_letters.IsEnabled = false;
            }
            else small_letters.IsEnabled = true;
            if (small_letters.IsChecked == false && capital_letters.IsChecked == true && numbers.IsChecked == false && special_characters.IsChecked == false)
            {
                capital_letters.IsEnabled = false;
            }
            else capital_letters.IsEnabled = true;
            if (small_letters.IsChecked == false && capital_letters.IsChecked == false && numbers.IsChecked == true && special_characters.IsChecked == false)
            {
                numbers.IsEnabled = false;
            }
            else numbers.IsEnabled = true;
            if (small_letters.IsChecked == false && capital_letters.IsChecked == false && numbers.IsChecked == false && special_characters.IsChecked == true)
            {
                special_characters.IsEnabled = false;
            }
            else special_characters.IsEnabled = true;
        }

        private void capital_letters_Checked(object sender, RoutedEventArgs e)
        {
            Lock_Option_If_Only_Active();
        }

        private void small_letters_Checked(object sender, RoutedEventArgs e)
        {
            Lock_Option_If_Only_Active();
        }

        private void numbers_Checked(object sender, RoutedEventArgs e)
        {
            Lock_Option_If_Only_Active();
        }

        private void special_characters_Checked(object sender, RoutedEventArgs e)
        {
            Lock_Option_If_Only_Active();
        }
    }
}
