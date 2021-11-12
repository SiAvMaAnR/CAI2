using CAI2.Models;
using System;
using System.Windows;

namespace CAI2
{
    public partial class MainWindow : Window
    {
        MainViewModel model = new MainViewModel();
        Logic logic = new Logic();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = model;
            model.Code = "double x = x12 * x12 - 28 * 48.33 / 24;";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                model.Lexemes.Clear();
                model.IsCorrect = logic.GetLexemes(model.Lexemes, model.Code);
            }
            catch (Exception ex)
            {
                model.IsCorrect = IsCorrect.InCorrect;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
