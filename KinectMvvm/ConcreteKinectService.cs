using System;
using System.Linq;
using Microsoft.Research.Kinect.Nui;

namespace KinectMvvm
{
    public class ConcreteKinectService : IKinectService
    {
        Runtime runtime;

        public void Initialize()
        {
            runtime = new Runtime();
            runtime.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(runtime_SkeletonFrameReady);
            runtime.Initialize(RuntimeOptions.UseSkeletalTracking);
        }

        void runtime_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            var skeleton =
                           e.SkeletonFrame.Skeletons
                           .Where(s => s.TrackingState == SkeletonTrackingState.Tracked)
                           .FirstOrDefault();

            if (skeleton == null)
            {
                return;
            }

            var position = skeleton.Joints[JointID.HandRight].Position;
            if (this.SkeletonUpdated != null)
            {
                this.SkeletonUpdated(this, new SkeletonEventArgs() { RightHandPosition = position });
            }
        }

        public void Cleanup()
        {
            if (runtime != null)
            {
                runtime.Uninitialize();
            }
        }

        public event EventHandler<SkeletonEventArgs> SkeletonUpdated;
    }
}
