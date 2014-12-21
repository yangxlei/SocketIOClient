// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;

namespace TestiOS
{
	[Register ("TestiOSViewController")]
	partial class TestiOSViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView textOutput { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (textOutput != null) {
				textOutput.Dispose ();
				textOutput = null;
			}
		}
	}
}
