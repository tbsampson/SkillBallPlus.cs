/* SkillBallPlus.cs v2.2 by Ixtabay for ServUO 
Based on original SkillBall from Romanthebrain
Updates by Hawthornetr, ntony, JamzeMcC, MrNice, Ixtabay, and others since 2010
*/
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;
using Server.Misc;
 
namespace Server
{
    public class SkillPickGump : Gump
    {
			public static int skillsToBoost = 5;  // How many skills to boost
            private SkillBallPlus  m_SkillBallPlus;
            public static double boostValue = 85;  // How high to boost each selected skill
        private static Item MakeNewbie( Item item )
        {
            if ( !Core.AOS )
                item.LootType = LootType.Newbied;
 
            return item;
        }
        public SkillPickGump( SkillBallPlus ball )
            : base( 0, 0 )
        {
            this.Closable=true;
            this.Disposable=true;
            this.Dragable=true;
            this.Resizable=true;
                        m_SkillBallPlus = ball;
 
            this.AddPage(0);
            this.AddBackground(39, 33, 750, 500, 5120);
            this.AddLabel(67, 41, 1153, @"Please select " + skillsToBoost + " skills to raise to " + boostValue + ". - WARNING: Doing so will erase all other trained skills and is irreversible!");
            this.AddButton(80, 500, 2071, 2072, (int)Buttons.Close, GumpButtonType.Reply, 0);
            this.AddBackground(52, 60, 720, 430, 9350);
            this.AddImage(610, 338, 9000);
            this.AddPage(1);
            this.AddButton(690, 500, 2311, 2312, (int)Buttons.FinishButton, GumpButtonType.Reply, 0);
 
    //********************************************************
            this.AddCheck(55, 65, 210, 211, false, (int)SkillName.Alchemy);
            this.AddCheck(55, 90, 210, 211, false, (int)SkillName.Anatomy);
            this.AddCheck(55, 115, 210, 211, false, (int)SkillName.AnimalLore);
            this.AddCheck(55, 140, 210, 211, false, (int)SkillName.AnimalTaming);
            this.AddCheck(55, 165, 210, 211, false, (int)SkillName.Archery);
            this.AddCheck(55, 190, 210, 211, false, (int)SkillName.ArmsLore);
            this.AddCheck(55, 215, 210, 211, false, (int)SkillName.Begging);
            this.AddCheck(55, 240, 210, 211, false, (int)SkillName.Blacksmith);
            this.AddCheck(55, 265, 210, 211, false, (int)SkillName.Bushido);
            this.AddCheck(55, 290, 210, 211, false, (int)SkillName.Camping);
            this.AddCheck(55, 315, 210, 211, false, (int)SkillName.Carpentry);
            this.AddCheck(55, 340, 210, 211, false, (int)SkillName.Cartography);
            this.AddCheck(55, 365, 210, 211, false, (int)SkillName.Chivalry);
            this.AddCheck(55, 390, 210, 211, false, (int)SkillName.Cooking);
            this.AddCheck(55, 415, 210, 211, false, (int)SkillName.DetectHidden);
            this.AddCheck(55, 440, 210, 211, false, (int)SkillName.Discordance);
            this.AddCheck(55, 465, 210, 211, false, (int)SkillName.EvalInt);
            this.AddLabel(80, 65, 0, SkillName.Alchemy.ToString());         
            this.AddLabel(80, 90, 0, SkillName.Anatomy.ToString());         
            this.AddLabel(80, 115, 0, SkillName.AnimalLore.ToString());   
            this.AddLabel(80, 140, 0, SkillName.AnimalTaming.ToString());         
            this.AddLabel(80, 165, 0, SkillName.Archery.ToString());        
            this.AddLabel(80, 190, 0, SkillName.ArmsLore.ToString());    
            this.AddLabel(80, 215, 0, SkillName.Begging.ToString());           
            this.AddLabel(80, 240, 0, SkillName.Blacksmith.ToString());      
            this.AddLabel(80, 265, 0, SkillName.Bushido.ToString());       
            this.AddLabel(80, 290, 0, SkillName.Camping.ToString());     
            this.AddLabel(80, 315, 0, SkillName.Carpentry.ToString()); 
            this.AddLabel(80, 340, 0, SkillName.Cartography.ToString()); 
            this.AddLabel(80, 365, 0, SkillName.Chivalry.ToString()); 
            this.AddLabel(80, 390, 0, SkillName.Cooking.ToString()); 
            this.AddLabel(80, 415, 0, SkillName.DetectHidden.ToString()); 
            this.AddLabel(80, 440, 0, SkillName.Discordance.ToString());    
            this.AddLabel(80, 465, 0, SkillName.EvalInt.ToString());
            
	// ********************************************************
            
            this.AddCheck(240, 65, 210, 211, false, (int)SkillName.Fencing);
            this.AddCheck(240, 90, 210, 211, false, (int)SkillName.Fishing);
            this.AddCheck(240, 115, 210, 211, false, (int)SkillName.Fletching);
            this.AddCheck(240, 140, 210, 211, false, (int)SkillName.Focus);
            this.AddCheck(240, 165, 210, 211, false, (int)SkillName.Forensics);
            this.AddCheck(240, 190, 210, 211, false, (int)SkillName.Healing);
            this.AddCheck(240, 215, 210, 211, false, (int)SkillName.Herding);
            this.AddCheck(240, 240, 210, 211, false, (int)SkillName.Hiding);            
          //  this.AddCheck(240, 265, 210, 211, false, (int)SkillName.Imbuing); // Comment if before Stygian Abyss Expansion
            this.AddCheck(240, 290, 210, 211, false, (int)SkillName.Inscribe);
            this.AddCheck(240, 315, 210, 211, false, (int)SkillName.ItemID);
            this.AddCheck(240, 340, 210, 211, false, (int)SkillName.Lockpicking);
            this.AddCheck(240, 365, 210, 211, false, (int)SkillName.Lumberjacking);
            this.AddCheck(240, 390, 210, 211, false, (int)SkillName.Macing);
            this.AddCheck(240, 415, 210, 211, false, (int)SkillName.Magery);
            this.AddCheck(240, 440, 210, 211, false, (int)SkillName.MagicResist);
            this.AddCheck(240, 465, 210, 211, false, (int)SkillName.Meditation);
            this.AddLabel(265, 65, 0, SkillName.Fencing.ToString());     
            this.AddLabel(265, 90, 0, SkillName.Fishing.ToString());         
            this.AddLabel(265, 115, 0, SkillName.Fletching.ToString());   
            this.AddLabel(265, 140, 0, SkillName.Focus.ToString()); 
            this.AddLabel(265, 165, 0, SkillName.Forensics.ToString());     
            this.AddLabel(265, 190, 0, SkillName.Healing.ToString());          
            this.AddLabel(265, 215, 0, SkillName.Herding.ToString());         
            this.AddLabel(265, 240, 0, SkillName.Hiding.ToString());
          //  this.AddLabel(265, 265, 0, SkillName.Imbuing.ToString()); // Comment if before Stygian Abyss Expansion
            this.AddLabel(265, 290, 0, SkillName.Inscribe.ToString());       
            this.AddLabel(265, 315, 0, SkillName.ItemID.ToString()); 
            this.AddLabel(265, 340, 0, SkillName.Lockpicking.ToString());        
            this.AddLabel(265, 365, 0, SkillName.Lumberjacking.ToString());        
            this.AddLabel(265, 390, 0, SkillName.Macing.ToString());   
            this.AddLabel(265, 415, 0, SkillName.Magery.ToString()); 
            this.AddLabel(265, 440, 0, SkillName.MagicResist.ToString()); 
            this.AddLabel(265, 465, 0, SkillName.Meditation.ToString());
            
	// ********************************************************
            
            this.AddCheck(425, 65, 210, 211, false, (int)SkillName.Mining);
            this.AddCheck(425, 90, 210, 211, false, (int)SkillName.Musicianship);
          //  this.AddCheck(425, 115, 210, 211, false, (int)SkillName.Mysticism);  // Comment if before Stygian Abyss Expansion
            this.AddCheck(425, 140, 210, 211, false, (int)SkillName.Necromancy);
            this.AddCheck(425, 165, 210, 211, false, (int)SkillName.Ninjitsu);
            this.AddCheck(425, 190, 210, 211, false, (int)SkillName.Parry);
            this.AddCheck(425, 215, 210, 211, false, (int)SkillName.Peacemaking);
            this.AddCheck(425, 240, 210, 211, false, (int)SkillName.Poisoning);
            this.AddCheck(425, 265, 210, 211, false, (int)SkillName.Provocation);
            this.AddCheck(425, 290, 210, 211, false, (int)SkillName.RemoveTrap);
            this.AddCheck(425, 315, 210, 211, false, (int)SkillName.Snooping);
            this.AddCheck(425, 340, 210, 211, false, (int)SkillName.Spellweaving);
            this.AddCheck(425, 365, 210, 211, false, (int)SkillName.SpiritSpeak);
            this.AddCheck(425, 390, 210, 211, false, (int)SkillName.Stealing);
            this.AddCheck(425, 415, 210, 211, false, (int)SkillName.Stealth);
            this.AddCheck(425, 440, 210, 211, false, (int)SkillName.Swords);
            this.AddCheck(425, 465, 210, 211, false, (int)SkillName.Tactics);
            this.AddLabel(450, 65, 0, SkillName.Mining.ToString());
            this.AddLabel(450, 90, 0, SkillName.Musicianship.ToString());
          //  this.AddLabel(450, 115, 0, SkillName.Mysticism.ToString());     // Comment if before Stygian Abyss Expansion
            this.AddLabel(450, 140, 0, SkillName.Necromancy.ToString());         
            this.AddLabel(450, 165, 0, SkillName.Ninjitsu.ToString());   
            this.AddLabel(450, 190, 0, SkillName.Parry.ToString()); 
            this.AddLabel(450, 215, 0, SkillName.Peacemaking.ToString());     
            this.AddLabel(450, 240, 0, SkillName.Poisoning.ToString());         
            this.AddLabel(450, 265, 0, SkillName.Provocation.ToString());         
            this.AddLabel(450, 290, 0, SkillName.RemoveTrap.ToString());       
            this.AddLabel(450, 315, 0, SkillName.Snooping.ToString());      
            this.AddLabel(450, 340, 0, SkillName.Spellweaving.ToString()); 
            this.AddLabel(450, 365, 0, SkillName.SpiritSpeak.ToString());       
            this.AddLabel(450, 390, 0, SkillName.Stealing.ToString());        
            this.AddLabel(450, 415, 0, SkillName.Stealth.ToString());   
            this.AddLabel(450, 440, 0, SkillName.Swords.ToString()); 
            this.AddLabel(450, 465, 0, SkillName.Tactics.ToString()); 
 
	//**********************************************************
 
            this.AddCheck(610, 65, 210, 211, false, (int)SkillName.Tailoring);            
            this.AddCheck(610, 90, 210, 211, false, (int)SkillName.TasteID);           
         //   this.AddCheck(610, 115, 210, 211, false, (int)SkillName.Throwing); // Comment if before Stygian Abyss Expansion
            this.AddCheck(610, 140, 210, 211, false, (int)SkillName.Tinkering);
            this.AddCheck(610, 165, 210, 211, false, (int)SkillName.Tracking);
            this.AddCheck(610, 190, 210, 211, false, (int)SkillName.Veterinary);
            this.AddCheck(610, 215, 210, 211, false, (int)SkillName.Wrestling); 
            this.AddLabel(635, 65, 0, SkillName.Tailoring.ToString());
            this.AddLabel(635, 90, 0, SkillName.TasteID.ToString());
          //  this.AddLabel(635, 115, 0, SkillName.Throwing.ToString());  // Comment if before Stygian Abyss Expansion
            this.AddLabel(635, 140, 0, SkillName.Tinkering.ToString());     
            this.AddLabel(635, 165, 0, SkillName.Tracking.ToString());         
            this.AddLabel(635, 190, 0, SkillName.Veterinary.ToString());   
            this.AddLabel(635, 215, 0, SkillName.Wrestling.ToString());
            
	//**********************************************************
           
        }
       
            public enum Buttons
            {
                Close,
                FinishButton,
            }
 
        public override void OnResponse( NetState state, RelayInfo info )
        {
            Mobile m = state.Mobile;
           
            switch( info.ButtonID )
            {
                case 0: {break;}
                case 1:
                {
                   
                if ( info.Switches.Length < skillsToBoost )
                    {
                        m.SendGump( new SkillPickGump(m_SkillBallPlus) );
                        m.SendMessage( 0, "Please try again.  You must pick {0} more skills for a total of "+ skillsToBoost +".", skillsToBoost - info.Switches.Length );
                        break;
                    }
                    else if ( info.Switches.Length > skillsToBoost )
                    {
                        m.SendGump( new SkillPickGump(m_SkillBallPlus) );
                        m.SendMessage( 0, "Please try again.  You choose {0} more skills than the "+ skillsToBoost +" allowed.", info.Switches.Length - skillsToBoost);
                        break;
                                }
 
                    else
                    {
                        Server.Skills skills = m.Skills;
 
                         //for (int i = 0; i < skills.Length; ++i) // If you want to set all skills to zero uncomment this
            // skills[i].Base = 0;
		
			if (info.IsSwitched((int)SkillName.Alchemy)) // ------------------------------------------------ Alchemy
                        {
            m.Skills[SkillName.Alchemy].Base = boostValue;
            Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Bottle( 3 ) );
                    pack.DropItem( new MortarPestle() );
                    pack.DropItem( new BagOfReagents( 10) );
                }
            }
			if (info.IsSwitched((int)SkillName.Anatomy)) // ------------------------------------------------ Anatomy
            {
            m.Skills[SkillName.Anatomy].Base = boostValue;
            Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Bandage( 10 ) );
                }
            }
			if (info.IsSwitched((int)SkillName.AnimalLore)) // ------------------------------------------------ AnimalLore
            {
            m.Skills[SkillName.AnimalLore].Base = boostValue;
            Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new ShepherdsCrook() );
                }
            }
			if (info.IsSwitched((int)SkillName.AnimalTaming)) // ------------------------------------------------ AnimalTaming
                        {
            m.Skills[SkillName.AnimalTaming].Base = boostValue;
            Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Apple( 5 ) );
                }
            }
			if (info.IsSwitched((int)SkillName.Archery)) // ------------------------------------------------ Archery
            {
            m.Skills[SkillName.Archery].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Arrow( 50 ) );
                    pack.DropItem( new Bow( ) );
 
                }
            }
            if (info.IsSwitched((int)SkillName.ArmsLore)) // ------------------------------------------------ ArmsLore
            {
            m.Skills[SkillName.ArmsLore].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new IronIngot( 10 ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Begging)) // ------------------------------------------------ Begging
            {
            m.Skills[SkillName.Begging].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new BankCheck( 10000 ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Blacksmith)) // ------------------------------------------------ Blacksmith
            {
            m.Skills[SkillName.Blacksmith].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new IronIngot( 10 ) );
                    pack.DropItem( new Tongs() );
                }
            }
            if (info.IsSwitched((int)SkillName.Camping)) // ------------------------------------------------ Camping
            {
            m.Skills[SkillName.Camping].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Bedroll() );
                    pack.DropItem( new Kindling( 3 ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Carpentry)) // ------------------------------------------------ Carpentry
            {
            m.Skills[SkillName.Carpentry].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Saw() );
                    pack.DropItem( new Board(10) );
                }
            }
            if (info.IsSwitched((int)SkillName.Cooking)) // ------------------------------------------------ Cooking
            {
            m.Skills[SkillName.Cooking].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Kindling( 3 ) );
                    pack.DropItem( new RawFishSteak(10) );
                }
            }
            if (info.IsSwitched((int)SkillName.Fishing)) // ------------------------------------------------ Fishing
            {
            m.Skills[SkillName.Fishing].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new FishingPole() );
                    pack.DropItem( new FloppyHat( Utility.RandomYellowHue() ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Healing)) // ------------------------------------------------ Healing
            {
            m.Skills[SkillName.Healing].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Bandage( 10 ) );
                    pack.DropItem( new Scissors() );
                }
            }
            if (info.IsSwitched((int)SkillName.Herding)) // ------------------------------------------------ Herding
            {
            m.Skills[SkillName.Herding].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new ShepherdsCrook() );
                }
            }
            if (info.IsSwitched((int)SkillName.Lockpicking)) // ------------------------------------------------ Lockpicking
            {
            m.Skills[SkillName.Lockpicking].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Lockpick( 10 ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Lumberjacking)) // ------------------------------------------------ Lumberjacking
            {
            m.Skills[SkillName.Lumberjacking].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Hatchet() );
                    pack.DropItem( new FullApron( Utility.RandomYellowHue() ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Magery)) // ------------------------------------------------ Magery
                        {
            m.Skills[SkillName.Magery].Base = boostValue;
            Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Spellbook( UInt64.MaxValue ) );
                    pack.DropItem( new BagOfReagents( 10 ) );
                }
                        }
            if (info.IsSwitched((int)SkillName.Meditation)) // ------------------------------------------------ Meditation
            {
            m.Skills[SkillName.Meditation].Base = boostValue;
            }

            if (info.IsSwitched((int)SkillName.Mining)) // ------------------------------------------------ Mining
            {
            m.Skills[SkillName.Mining].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Pickaxe() );
                    pack.DropItem( new Shovel() );
 
                }
            }
            if (info.IsSwitched((int)SkillName.Musicianship)) // ------------------------------------------------ Musicianship
            {
            m.Skills[SkillName.Musicianship].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Lute() );
                    pack.DropItem( new TambourineTassel() );
                    pack.DropItem( new Drums() );
                }
            }
            if (info.IsSwitched((int)SkillName.RemoveTrap)) // ------------------------------------------------ RemoveTrap
            {
            m.Skills[SkillName.RemoveTrap].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new GreaterHealPotion( 3 ) );
                }
            }
            if (info.IsSwitched((int)SkillName.MagicResist)) // ------------------------------------------------ MagicResist
            {
            m.Skills[SkillName.MagicResist].Base = boostValue;
            }

            if (info.IsSwitched((int)SkillName.Snooping)) // ------------------------------------------------ Snooping
            {
            m.Skills[SkillName.Snooping].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new BankCheck ( 1000 ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Stealing)) // ------------------------------------------------ Stealing
            {
            m.Skills[SkillName.Stealing].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new BankCheck ( 1000 ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Stealth)) // ------------------------------------------------ Stealth
            {
            m.Skills[SkillName.Stealth].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new BurglarsBandana() );
                }
            }
            if (info.IsSwitched((int)SkillName.Tailoring)) // ------------------------------------------------ Tailoring
            {
            m.Skills[SkillName.Tailoring].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Cloth( 10 ) );
                    pack.DropItem( new SewingKit( ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Tinkering)) // ------------------------------------------------ Tinkering
            {
            m.Skills[SkillName.Tinkering].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new TinkerTools () );
                    pack.DropItem( new IronIngot ( 10 ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Veterinary)) // ------------------------------------------------ Veterinary
            {
            m.Skills[SkillName.Veterinary].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Bandage( 10 ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Fencing)) // ------------------------------------------------ Fencing
            {
            m.Skills[SkillName.Fencing].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Kryss() );
                }
            }
            if (info.IsSwitched((int)SkillName.Macing)) // ------------------------------------------------ Macing
            {
            m.Skills[SkillName.Macing].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Mace() );
                }
            }
            if (info.IsSwitched((int)SkillName.Parry)) // ------------------------------------------------ Parry
            {
            m.Skills[SkillName.Parry].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new MetalKiteShield() );
                }
            }
            if (info.IsSwitched((int)SkillName.Swords)) // ------------------------------------------------ Swords
            {
            m.Skills[SkillName.Swords].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Longsword() );
                }
            }
            if (info.IsSwitched((int)SkillName.Tactics)) // ------------------------------------------------ Tactics
            {
            m.Skills[SkillName.Tactics].Base = boostValue;
            }

            if (info.IsSwitched((int)SkillName.Wrestling)) // ------------------------------------------------ Wrestling
            {
            m.Skills[SkillName.Wrestling].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new LeatherGloves() );
                }
            }
            if (info.IsSwitched((int)SkillName.Cartography)) // ------------------------------------------------ Cartography
            {
            m.Skills[SkillName.Cartography].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new BlankMap() );
                    pack.DropItem( new Sextant() );
                }
            }
            if (info.IsSwitched((int)SkillName.DetectHidden)) // ------------------------------------------------ DetectHidden
            {
            m.Skills[SkillName.DetectHidden].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Cloak( 0x455 ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Inscribe)) // ------------------------------------------------ Inscribe
            {
            m.Skills[SkillName.Inscribe].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new BlankScroll( 5 ) );
                    pack.DropItem( new BlueBook( ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Peacemaking)) // ------------------------------------------------ Peacemaking
            {
            m.Skills[SkillName.Peacemaking].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Tambourine() );
                }
            }
            if (info.IsSwitched((int)SkillName.Poisoning)) // ------------------------------------------------ Poisoning
            {
            m.Skills[SkillName.Poisoning].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new LesserPoisonPotion() );
                    pack.DropItem( new LesserPoisonPotion() );
                    pack.DropItem( new LesserPoisonPotion() );
                }
            }
            if (info.IsSwitched((int)SkillName.Provocation)) // ------------------------------------------------ Provocation
            {
            m.Skills[SkillName.Provocation].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new BambooFlute() );
                }
            }
            if (info.IsSwitched((int)SkillName.SpiritSpeak)) // ------------------------------------------------ SpiritSpeak
            {
            m.Skills[SkillName.SpiritSpeak].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new BagOfNecroReagents(10) );
                }
            }
            if (info.IsSwitched((int)SkillName.Tracking)) // ------------------------------------------------ Tracking
            {
            m.Skills[SkillName.Tracking].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new BearMask(0x1545) );
                }
            }
            if (info.IsSwitched((int)SkillName.EvalInt)) // ------------------------------------------------ EvalInt
            {
            m.Skills[SkillName.EvalInt].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new BagOfReagents(10) );
 
                }
            }
            if (info.IsSwitched((int)SkillName.Forensics)) // ------------------------------------------------ Forensics
            {
            m.Skills[SkillName.Forensics].Base = boostValue;
            }

            if (info.IsSwitched((int)SkillName.ItemID)) // ------------------------------------------------ ItemID
            {
            m.Skills[SkillName.ItemID].Base = boostValue;
            }

            if (info.IsSwitched((int)SkillName.TasteID)) // ------------------------------------------------ TasteID
            {
            m.Skills[SkillName.TasteID].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new GreaterHealPotion( 1 ) );
                    pack.DropItem( new GreaterAgilityPotion( 1 ) );
                    pack.DropItem( new GreaterStrengthPotion( 1 ) );
                }
            }
            if (info.IsSwitched((int)SkillName.Hiding)) // ------------------------------------------------ Hiding
            {
            m.Skills[SkillName.Hiding].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Robe(0x497) );
                }
            }
            if (info.IsSwitched((int)SkillName.Fletching)) // ------------------------------------------------ Fletching
            {
            m.Skills[SkillName.Fletching].Base = boostValue;
            Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new FletcherTools(0x1022) );
                    pack.DropItem( new Shaft(10) );
                    pack.DropItem( new Feather(10) );
                   
                }
            }
            if (info.IsSwitched((int)SkillName.Focus)) // ------------------------------------------------ Focus
            {
            m.Skills[SkillName.Focus].Base = boostValue;
            }

            if (info.IsSwitched((int)SkillName.Throwing)) // ------------------------------------------------ Throwing
            {
            m.Skills[SkillName.Throwing].Base = boostValue;
            Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new ThrowingDagger() );
                }
                        }
			if (info.IsSwitched((int)SkillName.Bushido)) // ------------------------------------------------ Bushido
                        {
            m.Skills[SkillName.Bushido].Base = boostValue;
            Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new BookOfBushido() );
                }
                        }
			if (info.IsSwitched((int)SkillName.Chivalry)) // ------------------------------------------------ Chivalry
                        {
            m.Skills[SkillName.Chivalry].Base = boostValue;
            Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new BookOfChivalry( (UInt64)0x3FF ) );
                }
                        }
            if (info.IsSwitched((int)SkillName.Imbuing)) // ------------------------------------------------ Imbuing
            {
            m.Skills[SkillName.Imbuing].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new RunicHammer (CraftResource.Valorite) );
                }
            }
            if (info.IsSwitched((int)SkillName.Mysticism)) // ------------------------------------------------ Mysticism
            {
            m.Skills[SkillName.Mysticism].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Bone(10) );
                    pack.DropItem( new DaemonBone(10) );
                    pack.DropItem( new FertileDirt(10) );
                   
                }
            }
            if (info.IsSwitched((int)SkillName.Necromancy)) // ------------------------------------------------ Necromancy
                        {
            m.Skills[SkillName.Necromancy].Base = boostValue;
            Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new NecromancerSpellbook( (UInt64)0xFFFF ) );
                    pack.DropItem( new BagOfNecroReagents(10) );                   
                }
                        }
			if (info.IsSwitched((int)SkillName.Ninjitsu)) // ------------------------------------------------ Ninjitsu
                        {
            m.Skills[SkillName.Ninjitsu].Base = boostValue;
            Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new BookOfNinjitsu() );
                }
                        }
 
            if (info.IsSwitched((int)SkillName.Spellweaving)) // ------------------------------------------------ Spellweaving
            {
            m.Skills[SkillName.Spellweaving].Base = boostValue;
                        Container pack = m.Backpack;
                if (pack != null)
                {
                    new SpellweavingBook((Int64)0xFFFF );
                }
            }
            if (info.IsSwitched((int)SkillName.Discordance)) // ------------------------------------------------ Discordance
            {
            m.Skills[SkillName.Discordance].Base = boostValue;
            Container pack = m.Backpack;
                if (pack != null)
                {
                    pack.DropItem( new Harp() );
                }
            }
           
                        m_SkillBallPlus.Delete();
 
                    }
                   
                    break;
                }
               
            }
        }
       
    }
 
    public class SkillBallPlus : Item
    {
        [Constructable]
        public SkillBallPlus() :  base( 0xE73 )
        {
            Weight = 1.0;
            Hue = 1287;
            Name = ""+ Server.SkillPickGump.skillsToBoost + "/" + Server.SkillPickGump.boostValue + " Skill Booster with Items";
            Movable =  false;
        }
        public override void OnDoubleClick( Mobile m )
        {
 
            if (m.Backpack != null && m.Backpack.GetAmount(typeof(SkillBallPlus)) > 0)
            {
                m.SendMessage("Please choose " + Server.SkillPickGump.skillsToBoost + " skills to set to " + Server.SkillPickGump.boostValue + ".");
                m.CloseGump(typeof(SkillPickGump));
                m.SendGump(new SkillPickGump(this));
            }
            else
                m.SendMessage(" This must be in your backpack to function.");
           
        }
 
        public SkillBallPlus( Serial serial ) : base( serial )
        {
        }
 
    public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 1 ); // version
        }
 
    public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
            }
     
    }
 
             
}
