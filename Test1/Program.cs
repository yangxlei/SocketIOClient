using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Test1
{
	class MainClass
	{
		public static void Main (string[] argsx)
		{
			var socket = new SocketIOClient.Client("https://whatsplus.herokuapp.com/");
			socket.On("connect", (fn) => {

				Console.WriteLine ("connect - socket");

				socket.On("message", (data) => {
					Console.WriteLine (data.MessageText);
				});
				Dictionary<string, string> args = new Dictionary<string, string>();
				args.Add("data", "What's up+?!!");
				socket.Emit("my_broadcast_event", args);
			});

			socket.Error += (sender, e) => {
				Debug.WriteLine ("socket Error: " + e.Message.ToString ());
			};
			socket.Connect();
			Console.ReadLine ();
		}
	}
}
