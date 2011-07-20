using System;
using Microsoft.Research.Kinect.Nui;

namespace KinectMvvm
{
    public class SkeletonEventArgs : EventArgs
    {
        public Vector RightHandPosition { get; set; }
    }
}
