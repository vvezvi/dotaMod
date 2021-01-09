using Terraria;
using Terraria.ModLoader;

namespace dotaMod
{
	class DotaMod : Mod
	{
		public DotaMod()
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
