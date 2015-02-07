using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiNET;
using MiNET.API;
using MiNET.PluginSystem.Attributes;
using MiNET.Utils;
using MiNET.Worlds;

namespace SetHome
{
	public class Commands
	{
		[Command("sethome", "sethome.set", "Set your home to your current position", "/sethome")]
		public void SetHome(Player source, string[] arguments)
		{
			if (PluginGlobals.Homes.ContainsKey(source))
			{
				PluginGlobals.Homes.Remove(source);
			}
			PlayerLocation p = source.KnownPosition;
			p.Y += 2; //Do not spawn underground....

			PluginGlobals.Homes.Add(source, p);
			source.SendMessage("[SetHome] Home set!");
		}

		[Command("home", "sethome.home", "Teleport to your home", "/home")]
		public void Home(Player source, string[] arguments)
		{
			if (PluginGlobals.Homes.ContainsKey(source))
			{
				PlayerLocation pos = null;
				PluginGlobals.Homes.TryGetValue(source, out pos);
				if (pos != null)
				{
					source.SendMessage("[SetHome] Teleporting you to your home!");
					source.KnownPosition = pos;
					source.SendMovePlayer();
				}
				else
				{
					source.SendMessage("[SetHome] Something went wrong!");
				}
			}
			else
			{
				source.SendMessage("[SetHome] You don't have a home set!");
				source.SendMessage("[SetHome] Set a home with \"/sethome\" first!");
			}
		}
	}
}
