using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace dotaMod.NPCs.TownNPCs
{
    [AutoloadHead]
    public class Windranger : ModNPC
    {

       public override void SetStaticDefaults()
        {
            //DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
            //DisplayName.SetDefault("Lyralei");
            Main.npcFrameCount[npc.type] = 25;
        } 

        public override void SetDefaults()
        {

            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7; //Maybe
            npc.damage = 80;
            npc.defense = 80;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;           
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;

            //This is the code that I added + 1 below
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 150; //this defines the npc danger detect range
            NPCID.Sets.AttackType[npc.type] = 1; //this is the attack type,  0 (throwing), 1 (shooting), or 2 (magic). 3 (melee)
            NPCID.Sets.AttackTime[npc.type] = 30; //this defines the npc attack speed
            NPCID.Sets.AttackAverageChance[npc.type] = 30;//this defines the npc atack chance
            NPCID.Sets.HatOffsetY[npc.type] = 4; //this defines the party hat position

        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Windranger1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Windranger2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Windranger3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Windranger4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Windranger5"), 1f);
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (player.active)
                {
                    for (int j = 0; j < player.inventory.Length; j++)
                    {
                        if (player.inventory[j].type == mod.ItemType("Phoenix Feather") || player.inventory[j].type == mod.ItemType("Red Hair Strand"))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(2))
            {
                case 0:
                    return "Lyralei";
                default:
                    return "Lyralei";
            }
        }

        public override string GetChat()
        {
            int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
            if (mechanic >= 0 && Main.rand.Next(4) == 0)
            {
                return "I really like " + Main.npc[mechanic].GivenName + "'s hair colour.";
            }
            switch (Main.rand.Next(6))
            {
                case 0:
                    return "You know your parents? Me neither.";
                case 1:
                    return "I can give you archery lessons if you'd like!";
                case 2:
                    return "I once shot an ant off a worm's backside, but only aimed to wound.";
                case 3:
                    return "Windranger at your service!";
                case 4:
                    return "I just kinda blew on into this town.";
                default:
                    return "Ever been to Zaru'Kina? No? Didn't think so..."; 
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("Rainmaker"));
            nextSlot++;
            /*if (Main.LocalPlayer.GetModPlayer<ExamplePlayer>(mod).ZoneExample)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleWings"));
                nextSlot++;
            }
            if (Main.moonPhase < 2)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleSword"));
                nextSlot++;
            }
            else if (Main.moonPhase < 4)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleGun"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleBullet"));
                nextSlot++;
            }
            else if (Main.moonPhase < 6)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleStaff"));
                nextSlot++;
            }
            else
            {
            }
            // Here is an example of how your npc can sell items from other mods.
            if (ModLoader.GetLoadedMods().Contains("SummonersAssociation"))
            {
                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SummonersAssociation").ItemType("BloodTalisman"));
                nextSlot++;
            }*/
        }

        public override void NPCLoot()
        {
            //Item.NewItem(npc.getRect(), mod.ItemType<Materials.WindrangerHair> 5);
            Item.NewItem(npc.getRect(), mod.ItemType("WindrangerHair"), Main.rand.Next(10, 21));
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 80;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 20;
			randExtraCooldown = 10;
		}

        //This is the other part
        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
        {
            scale = 1f;
            item = mod.ItemType("Daedalus");
            closeness = 20;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType("DaedalusArrowProjectile");
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}

    }
}