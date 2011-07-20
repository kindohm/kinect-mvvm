using System;

namespace KinectMvvm
{
    public interface IKinectService
    {
        void Initialize();
        void Cleanup();
        event EventHandler<SkeletonEventArgs> SkeletonUpdated;
    }
}
