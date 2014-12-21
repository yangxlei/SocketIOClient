SocketIOClient
==============

SocketIOClient is a [Socket.IO](http://socket.io/) C# Client.

This is a fork of [UnitySocketIO-WebSocketSharp](https://github.com/kaistseo/UnitySocketIO-WebSocketSharp).

Why this fork?
  * Keep websocketsharp updated.
  * Port to Xamarin.iOS/Xamarin.Android.
  * Add CI, and NuGet package.
  
Why are you not using PCL?
  * PCL are great, but for this project use different solutions for each platform is enought, PCL doesn't have Timer or the Thread class, we want the use the original code "as-is".
Why websocketsharp is a submodule and not a NuGet package?
  * websocketsharp is awesome, but there is no build for Xamarin.iOS or Xamarin.Android on NuGet.
  
How to install?
-----------

Installing using NuGet:

    PM> Install-Package SocketIOClient
  
Xamarin.iOS:

    PM> Install-Package SocketIOClient_iOS

Xamarin.Android:

    PM> Install-Package SocketIOClient_Android
    

Usage:
-----------

  Creating the SocketClientIO:
  
 ```csharp
      // Client receives the URL with the Socket.IO address.
      SocketIOClient.Client socket = new SocketIOClient.Client("https://localhost:5000/");
 ```

Registering events:

 ```csharp
      socket.On("connect", (fn) => {

				Console.WriteLine ("connect - socket");

				socket.On("message", (data) => {
					Console.WriteLine (data.MessageText);
				});
				Dictionary<string, string> args = new Dictionary<string, string>();
				args.Add("data", "What's up+?!!");
				socket.Emit("my_broadcast_event", args);
			});
 ```
 
Handling errors:

 ```csharp
      socket.Error += (sender, e) => {
				Debug.WriteLine ("socket Error: " + e.Message.ToString ());
			};
 ```
