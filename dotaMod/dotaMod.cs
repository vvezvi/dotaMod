using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace dotaMod
{
	class dotaMod : Mod
	{
		public dotaMod()
		{

		}

		public override void Load()
        {
			if (!Main.dedServ)
            {
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Docking"), ItemType("StackOfLatex"), TileType("DockingMusicBox"));
            }
        }
	}
}
