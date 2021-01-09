using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace dotaMod.NPCs.TownNPCs
{
    [AutoloadHead]
    public class Windranger : ModNPC
    { 
        public override void SetStaticDefaults(){
                DisplayName.SetDefault("Lyralei");
                Main.npcFrameCount[npc.type] = 25; 
        } 

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7; //TODO Look into aiStyles, possible damage changes and sound changes
            npc.damage = 80;
            npc.defense = 80;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;           
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
            
            //NPC custom changes
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 150; //Target Range
            NPCID.Sets.AttackType[npc.type] = 1; //this is the attack type,  0 (throwing), 1 (shooting), or 2 (magic). 3 (melee)
            //TODO Attack Type Enumeration
            NPCID.Sets.AttackTime[npc.type] = 30; //Attack Speed
            NPCID.Sets.AttackAverageChance[npc.type] = 30; //Attack Chance
            NPCID.Sets.HatOffsetY[npc.type] = 4; //Party Hat Offset
        }

        public override void HitEffect(int hitDirection, double damage){
            if (npc.life < 0) return;
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Windranger1"));
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Windranger2"));
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Windranger3"));
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Windranger4"));
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Windranger5"));
        }

        public override bool CanTownNPCSpawn(int numTownNpCs, int money){
            for (var k = 0; k < 255; k++){ //Iterate through all active players and return true if the spawn item is found
                var player = Main.player[k];
                if (!player.active) return false;
                if (player.inventory.Any(item => item.type == mod.ItemType("Phoenix Feather") 
                                          || item.type == mod.ItemType("Red Hair Strand"))) return true;
            }
            return false;
        }

        public override string TownNPCName(){
            return DisplayName.GetDefault();
        }

        public override string GetChat()
        {
            var mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
            if (mechanic >= 0 && Main.rand.Next(4) == 0){
                return "I really like " + Main.npc[mechanic].GivenName + "'s hair colour.";
            }
            return Main.rand.Next(5) switch{
                0 => "You know your parents? Me neither.",
                1 => "I can give you archery lessons if you'd like!",
                2 => "I once shot an ant off a worm's backside, but only aimed to wound.",
                3 => "Windranger at your service!",
                4 => "I just kinda blew on into this town.",
                _ => "Ever been to Zaru'Kina? No? Didn't think so..."
            };
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