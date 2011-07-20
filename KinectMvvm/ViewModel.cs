using System.ComponentModel;

namespace KinectMvvm
{
    public class ViewModel : INotifyPropertyChanged
    {
        IKinectService kinectService;

        public ViewModel(IKinectService kinectService)
        {
            this.HandOffsetX = 100;
            this.HandOffsetY = 100;
            this.kinectService = kinectService;

            this.kinectService.SkeletonUpdated += new System.EventHandler<SkeletonEventArgs>(kinectService_SkeletonUpdated);
        }

        void kinectService_SkeletonUpdated(object sender, SkeletonEventArgs e)
        {
            if (App.Current.MainWindow != null)
            {
                var midpointX = App.Current.MainWindow.Width / 2;
                var midpointY = App.Current.MainWindow.Height / 2;

                this.HandOffsetX = midpointX + (e.RightHandPosition.X * 500);
                this.HandOffsetY = midpointY - (e.RightHandPosition.Y * 500);
            }
        }

        double handOffsetX;
        public double HandOffsetX
        {
            get { return this.handOffsetX; }
            set
            {
                this.handOffsetX = value;
                this.OnPropertyChanged("HandOffsetX");
            }
        }

        double handOffsetY;
        public double HandOffsetY
        {
            get { return this.handOffsetY; }
            set
            {
                this.handOffsetY = value;
                this.OnPropertyChanged("HandOffsetY");
            }
        }

        void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void Cleanup()
        {
            this.kinectService.SkeletonUpdated -= kinectService_SkeletonUpdated;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
