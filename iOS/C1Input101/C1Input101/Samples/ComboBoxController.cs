﻿using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using C1.iOS.Core;

namespace C1Input101
{
    public partial class ComboBoxController : UIViewController
    {
        public ComboBoxController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ComboBoxEdit.DisplayMemberPath = "Name";
            ComboBoxEdit.ItemsSource = Countries.GetDemoDataList();
            ComboBoxEdit.DropDownHeight = 200;
            ComboBoxEdit.Placeholder = NSBundle.MainBundle.LocalizedString("Please Enter...", "optional");

            ComboBoxNonEdit.DisplayMemberPath = "Name";
            ComboBoxNonEdit.ItemsSource = Countries.GetDemoDataList();
            ComboBoxNonEdit.IsEditable = false;
            ComboBoxNonEdit.DropDownBehavior = C1.iOS.Input.DropDownBehavior.HeaderTap;
            ComboBoxNonEdit.DropDownHeight = 200;
        }

        public override void DidReceiveMemoryWarning()
        {
            foreach (var item in ComboBoxEdit.ItemsSource)
            {
                ((NSObject)item).Dispose();
            }
            foreach (var item in ComboBoxNonEdit.ItemsSource)
            {
                ((NSObject)item).Dispose();
            }
            ComboBoxEdit.RemoveFromSuperview();
            ComboBoxNonEdit.RemoveFromSuperview();
            ReleaseDesignerOutlets();
            base.DidReceiveMemoryWarning();

        }

    }

}


