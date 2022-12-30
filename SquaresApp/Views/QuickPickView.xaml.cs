using SquaresApp.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace SquaresApp.Views
{
    public partial class QuickPickView : Window
    {
        double startPos = 0;
        bool isCaptured= false;
        public QuickPickView()
        {
            InitializeComponent();
            DataContext = new QuickPickViewModel();
        }

        private void ScrollViewer_PreviewStylusDown(object sender, MouseEventArgs e)
        {
            startPos = e.GetPosition(MainScrollViewer).X;
            isCaptured = true;
        }

        private void ScrollViewer_PreviewStylusUp(object sender, MouseEventArgs e)
        {
            startPos = e.GetPosition(MainScrollViewer).X;
            isCaptured = false;
        }

        private void ScrollViewer_PreviewStylusMove(object sender, MouseEventArgs e)
        {
            if (!isCaptured)
                return;

            try
            {
                var offset = (e.GetPosition(MainScrollViewer).X - startPos);
                if (offset < 10 && offset > -10)
                    return;

                var res = (MainScrollViewer.ContentHorizontalOffset - offset);

                MainScrollViewer.ScrollToHorizontalOffset(res);
                startPos = e.GetPosition(MainScrollViewer).X;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}