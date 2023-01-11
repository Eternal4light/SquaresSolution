using SquaresApp.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace SquaresApp.Views
{
    public partial class QuickPickView : Window
    {
        private const double DECELERATION = 1.00;

        private double startPos = 0;
        private double zeroStartPos = 0;

        private DateTime startTime = DateTime.MinValue;
        private DateTime endTime = DateTime.MinValue;

        private bool isCaptured = false;
        public QuickPickView()
        {
            InitializeComponent();
            DataContext = new QuickPickViewModel();
        }

        private void ScrollViewer_PreviewStylusDown(object sender, MouseEventArgs e)
        {
            startTime = DateTime.Now;
            startPos = e.GetPosition(MainScrollViewer).X;
            zeroStartPos = startPos;
            isCaptured = true;
        }

        private void ScrollViewer_PreviewStylusUp(object sender, MouseEventArgs e)
        {
            endTime = DateTime.Now;
            startPos = e.GetPosition(MainScrollViewer).X;
            isCaptured = false;

            double path = startPos - zeroStartPos;
            double additionalPath = path / 2;
            double deltaTime = (endTime - startTime).TotalSeconds;
            double inertialPath = additionalPath / deltaTime;

            DoubleAnimation dAnimation = new DoubleAnimation();
            dAnimation.From = MainScrollViewer.HorizontalOffset;
            dAnimation.To = MainScrollViewer.HorizontalOffset - inertialPath;
            dAnimation.Duration = TimeSpan.FromSeconds(1);
            dAnimation.DecelerationRatio = DECELERATION;

            Storyboard storyboard = new Storyboard();

            storyboard.Children.Add(dAnimation);
            Storyboard.SetTarget(dAnimation, MainScrollViewer);
            Storyboard.SetTargetProperty(dAnimation, new PropertyPath(ScrollAnimationBehavior.HorizontalOffsetProperty)); // Attached dependency property
            storyboard.Begin();
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