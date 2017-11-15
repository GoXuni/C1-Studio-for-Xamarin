// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace C1CollectionView101
{
    [Register ("SampleViewController")]
    partial class SampleViewController
    {
        [Outlet]
        C1CollectionView101.SourceListView SourceList { get; set; }
        
        void ReleaseDesignerOutlets ()
        {
            if (SourceList != null) {
                SourceList.Dispose ();
                SourceList = null;
            }
        }
    }
}
