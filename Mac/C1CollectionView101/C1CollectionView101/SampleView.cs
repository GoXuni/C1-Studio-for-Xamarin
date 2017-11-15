using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace C1CollectionView101
{
    public partial class SampleView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public SampleView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SampleView(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion
    }
}
