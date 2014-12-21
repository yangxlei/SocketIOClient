using System;
using System.Drawing;

using Foundation;
using UIKit;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestiOS
{
	public partial class TestiOSViewController : UIViewController
	{
		SocketIOClient.Client socket = new SocketIOClient.Client("https://whatsplus.herokuapp.com/");

		public TestiOSViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			socket.On("connect", (fn) => {
				InvokeOnMainThread ( () => {
				
				textOutput.Text += "connect - socket\n";


				socket.On("message", (data) => {
						InvokeOnMainThread ( () => {
							textOutput.Text += data.MessageText + "\n"; });
				});
				Dictionary<string, string> args = new Dictionary<string, string>();
				args.Add("data", "What's up+?!!");
				socket.Emit("my_broadcast_event", args);
				});
			});

			socket.Error += (sender, e) => {
				Debug.WriteLine ("socket Error: " + e.Message.ToString ());
			};
			socket.Connect();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
	}
}

