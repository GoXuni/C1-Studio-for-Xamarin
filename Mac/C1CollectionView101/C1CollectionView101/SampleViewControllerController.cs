using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace C1CollectionView101
{
    public partial class SampleViewControllerController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public SampleViewControllerController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SampleViewControllerController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public SampleViewControllerController() : base("SampleViewController", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new SampleViewController View
        {
            get
            {
                return (SampleViewController)base.View;
            }
        }
    }
}
