/*
 * Please note that this plugin does not save anything!
 * This is all cached data, as soon as the server restarts or crashes all homes are gone!
 * This is just an example plugin!
 */
using System;
using MiNET.API;
using MiNET.PluginSystem.Attributes;

namespace SetHome
{
	[Plugin("SetHome", "An example sethome plugin for MiNET", "1.0", "kennyvv")]
    public class Main : MiNETPlugin
    {
		public override void OnEnable()
		{
			Console.WriteLine("[SetHome] Plugin loaded!");
		}
		public override void OnDisable()
		{
			Console.WriteLine("[SetHome] Plugin disabled!");
		}
    }
}
