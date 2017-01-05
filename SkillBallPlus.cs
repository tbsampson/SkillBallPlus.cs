/* SkillBallPlus.cs v2.2 (Complete rewrite) by Ixtabay
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
            this.Resizable=false;
                        m_SkillBallPlus = ball;
						
			
            this.AddPage(0);
			// ----------------- y, x, y, x, id
            this.AddBackground(39, 33, 555, 545, 9380);
            this.AddHtml(67, 41, 1153, 20, "<BASEFONT SIZE=10 FACE=1 COLOR=#001052>Skillball Plus!</BASEFONT>", (bool)false, (bool)false);
			this.AddHtml(67, 555, 1153, 20, "<BASEFONT SIZE=10 FACE=1 COLOR=#001052>Please select " + skillsToBoost + " skills to raise to " + boostValue + "</BASEFONT>", (bool)false, (bool)false);
            this.AddButton(420, 555, 2071, 2072, (int)Buttons.Close, GumpButtonType.Reply, 0);
            this.AddButton(490, 555, 2311, 2312, (int)Buttons.FinishButton, GumpButtonType.Reply, 0);
						
			// Miscellaneous
			AddImage(183, 73, 2101);
			AddImage(200, 73, 2101);
			AddImage(217, 73, 2101);
	
			// Combat
			AddImage(132, 233, 2101);
			AddImage(149, 233, 2101);
			AddImage(166, 233, 2101);
			AddImage(183, 233, 2101);
			AddImage(200, 233, 2101);
			AddImage(217, 233, 2101);
			
			// Trade Skills
			AddImage(356, 73, 2101);			
			AddImage(373, 73, 2101);			
			AddImage(390, 73, 2101);			
			AddImage(407, 73, 2101);			
			
            // Magic
			AddImage(305, 293, 2101);						
			AddImage(322, 293, 2101);			
			AddImage(339, 293, 2101);			
			AddImage(356, 293, 2101);			
			AddImage(373, 293, 2101);			
			AddImage(390, 293, 2101);			
			AddImage(407, 293, 2101);			

			// Wilderness
			AddImage(535, 73, 2101);
			AddImage(552, 73, 2101);

			// Thieving
			AddImage(518, 213, 2101);
			AddImage(535, 213, 2101);
			AddImage(552, 213, 2101);
	
			// Bard
			AddImage(484, 393, 2101);
			AddImage(501, 393, 2101);
			AddImage(518, 393, 2101);
			AddImage(535, 393, 2101);
			AddImage(552, 393, 2101);

			this.AddImage(65, 480, 9811); // Image of backpack
			this.AddHtml(122, 478, 1154, 20,"<BASEFONT SIZE=6 FACE=2 COLOR=#001052>Items added to</BASEFONT>", (bool)false, (bool)false);
			this.AddHtml(122, 491, 1154, 20,"<BASEFONT SIZE=6 FACE=2 COLOR=#001052>backpack based</BASEFONT>", (bool)false, (bool)false);
			this.AddHtml(122, 504, 1154, 20,"<BASEFONT SIZE=6 FACE=2 COLOR=#001052>based on your</BASEFONT>", (bool)false, (bool)false);
			this.AddHtml(122, 517, 1154, 20,"<BASEFONT SIZE=6 FACE=2 COLOR=#001052>selected skills!</BASEFONT>", (bool)false, (bool)false);
	
			// this.AddImage(400, 495, 52); // Signature line image
			this.AddHtml(422, 501, 1154, 20,"<BASEFONT SIZE=10 FACE=2 COLOR=#001052>Choose Carefully</BASEFONT>", (bool)false, (bool)false);			
			this.AddHtml(410, 518, 1154, 20,"<BASEFONT SIZE=10 FACE=2 COLOR=#001052>This cannot be undone!</BASEFONT>", (bool)false, (bool)false);
			
            this.AddPage(1);
    //**************************************************************************************************************** Column 1
            this.AddImage(64, 68, 2086); // ------------------------------------------------------------  Miscellaneous
            this.AddCheck(65, 85, 2510, 2511, false, (int)SkillName.ArmsLore);
            this.AddCheck(65, 105, 2510, 2511, false, (int)SkillName.Begging);
            this.AddCheck(65, 125, 2510, 2511, false, (int)SkillName.Camping);
            this.AddCheck(65, 145, 2510, 2511, false, (int)SkillName.Cartography);
            this.AddCheck(65, 165, 2510, 2511, false, (int)SkillName.Forensics);
            this.AddCheck(65, 185, 2510, 2511, false, (int)SkillName.ItemID);
            this.AddCheck(65, 205, 2510, 2511, false, (int)SkillName.TasteID);
            this.AddImage(64, 228, 2086); // ------------------------------------------------------------ Combat
            this.AddCheck(65, 245, 2510, 2511, false, (int)SkillName.Anatomy);
            this.AddCheck(65, 265, 2510, 2511, false, (int)SkillName.Archery);
            this.AddCheck(65, 285, 2510, 2511, false, (int)SkillName.Fencing);
            this.AddCheck(65, 305, 2510, 2511, false, (int)SkillName.Focus);
            this.AddCheck(65, 325, 2510, 2511, false, (int)SkillName.Healing);
            this.AddCheck(65, 345, 2510, 2511, false, (int)SkillName.Macing);
            this.AddCheck(65, 365, 2510, 2511, false, (int)SkillName.Parry);
            this.AddCheck(65, 385, 2510, 2511, false, (int)SkillName.Swords);
            this.AddCheck(65, 405, 2510, 2511, false, (int)SkillName.Tactics);
            this.AddCheck(65, 425, 2510, 2511, false, (int)SkillName.Throwing);
            this.AddCheck(65, 445, 2510, 2511, false, (int)SkillName.Wrestling);
            this.AddHtml(85, 65, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#001052>Miscellaneous</BASEFONT>", (bool)false, (bool)false); // -----------------------  Miscellaneous
            this.AddHtml(85, 85, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Arms Lore</BASEFONT>", (bool)false, (bool)false);         
            this.AddHtml(85, 105, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Begging</BASEFONT>", (bool)false, (bool)false);   
            this.AddHtml(85, 125, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Camping</BASEFONT>", (bool)false, (bool)false);         
            this.AddHtml(85, 145, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Cartography</BASEFONT>", (bool)false, (bool)false);        
            this.AddHtml(85, 165, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Forensic Evaluation</BASEFONT>", (bool)false, (bool)false);    
            this.AddHtml(85, 185, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Item Identification</BASEFONT>", (bool)false, (bool)false);           
            this.AddHtml(85, 205, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Taste Identification</BASEFONT>", (bool)false, (bool)false);      
            this.AddHtml(85, 225, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#001052>Combat</BASEFONT>", (bool)false, (bool)false); // ----------------------- Combat       
            this.AddHtml(85, 245, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Anatomy</BASEFONT>", (bool)false, (bool)false);     
            this.AddHtml(85, 265, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Archery</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(85, 285, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Fencing</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(85, 305, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Focus</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(85, 325, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Healing</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(85, 345, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Mace Fighting</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(85, 365, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Parrying</BASEFONT>", (bool)false, (bool)false);    
            this.AddHtml(85, 385, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Swordfighting</BASEFONT>", (bool)false, (bool)false);
            this.AddHtml(85, 405, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Tactics</BASEFONT>", (bool)false, (bool)false);			
            this.AddHtml(85, 425, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Throwing</BASEFONT>", (bool)false, (bool)false);            
            this.AddHtml(85, 445, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Wrestling</BASEFONT>", (bool)false, (bool)false);            			
	// **************************************************************************************************************** Column 2
            this.AddImage(239, 68, 2086); // ------------------------------------------------------------  Trade Skills
            this.AddCheck(240, 85, 2510, 2511, false, (int)SkillName.Alchemy);
            this.AddCheck(240, 105, 2510, 2511, false, (int)SkillName.Blacksmith);
            this.AddCheck(240, 125, 2510, 2511, false, (int)SkillName.Fletching);
            this.AddCheck(240, 145, 2510, 2511, false, (int)SkillName.Carpentry);
            this.AddCheck(240, 165, 2510, 2511, false, (int)SkillName.Cooking);
            this.AddCheck(240, 185, 2510, 2511, false, (int)SkillName.Inscribe);
            this.AddCheck(240, 205, 2510, 2511, false, (int)SkillName.Lumberjacking);            
            this.AddCheck(240, 225, 2510, 2511, false, (int)SkillName.Mining);
            this.AddCheck(240, 245, 2510, 2511, false, (int)SkillName.Tailoring);
            this.AddCheck(240, 265, 2510, 2511, false, (int)SkillName.Tinkering);
            this.AddImage(239, 288, 2086); // ------------------------------------------------------------  Magic
			this.AddCheck(240, 305, 2510, 2511, false, (int)SkillName.Bushido);
            this.AddCheck(240, 325, 2510, 2511, false, (int)SkillName.Chivalry);
            this.AddCheck(240, 345, 2510, 2511, false, (int)SkillName.EvalInt);
            this.AddCheck(240, 365, 2510, 2511, false, (int)SkillName.Imbuing);
            this.AddCheck(240, 385, 2510, 2511, false, (int)SkillName.Magery);
            this.AddCheck(240, 405, 2510, 2511, false, (int)SkillName.Meditation);			
            this.AddCheck(240, 425, 2510, 2511, false, (int)SkillName.Mysticism);						
            this.AddCheck(240, 445, 2510, 2511, false, (int)SkillName.Necromancy);									
            this.AddCheck(240, 465, 2510, 2511, false, (int)SkillName.Ninjitsu);												
            this.AddCheck(240, 485, 2510, 2511, false, (int)SkillName.MagicResist);															
            this.AddCheck(240, 505, 2510, 2511, false, (int)SkillName.Spellweaving);																		
            this.AddCheck(240, 525, 2510, 2511, false, (int)SkillName.SpiritSpeak);																					
            this.AddHtml(259, 65, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#001052>Trade Skills</BASEFONT>", (bool)false, (bool)false); // -----------------------  Trade Skills
            this.AddHtml(260, 85, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Alchemy</BASEFONT>", (bool)false, (bool)false);         
            this.AddHtml(260, 105, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Blacksmithy</BASEFONT>", (bool)false, (bool)false);   
            this.AddHtml(260, 125, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Bowcraft/Fletching</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(260, 145, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Carpentry</BASEFONT>", (bool)false, (bool)false);     
            this.AddHtml(260, 165, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Cooking</BASEFONT>", (bool)false, (bool)false);          
            this.AddHtml(260, 185, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Inscription</BASEFONT>", (bool)false, (bool)false);         
            this.AddHtml(260, 205, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Lumberjacking</BASEFONT>", (bool)false, (bool)false);
            this.AddHtml(260, 225, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Mining</BASEFONT>", (bool)false, (bool)false); // Comment if before Stygian Abyss Expansion
            this.AddHtml(260, 245, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Tailoring</BASEFONT>", (bool)false, (bool)false);       
            this.AddHtml(259, 265, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Tinkering</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(260, 285, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#001052>Magic</BASEFONT>", (bool)false, (bool)false); // -----------------------  Magic
            this.AddHtml(260, 305, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Bushido</BASEFONT>", (bool)false, (bool)false);        
            this.AddHtml(260, 325, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Chivalry</BASEFONT>", (bool)false, (bool)false);   
            this.AddHtml(260, 345, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Evaluating Intelligence</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(260, 365, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Imbuing</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(260, 385, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Magery</BASEFONT>", (bool)false, (bool)false);
            this.AddHtml(260, 405, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Meditation</BASEFONT>", (bool)false, (bool)false);
            this.AddHtml(260, 425, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Mysticism</BASEFONT>", (bool)false, (bool)false);
            this.AddHtml(260, 445, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Necromancy</BASEFONT>", (bool)false, (bool)false);
            this.AddHtml(260, 465, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Ninjitsu</BASEFONT>", (bool)false, (bool)false);
            this.AddHtml(260, 485, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Resisting Spells</BASEFONT>", (bool)false, (bool)false);
            this.AddHtml(260, 505, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Spellweaving</BASEFONT>", (bool)false, (bool)false);
            this.AddHtml(260, 525, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Spirit Speak</BASEFONT>", (bool)false, (bool)false);			
	// **************************************************************************************************************** Column 3
            this.AddImage(429, 68, 2086); // ------------------------------------------------------------  Wilderness
            this.AddCheck(430, 85, 2510, 2511, false, (int)SkillName.AnimalLore);
            this.AddCheck(430, 105, 2510, 2511, false, (int)SkillName.AnimalTaming);
            this.AddCheck(430, 125, 2510, 2511, false, (int)SkillName.Fishing);
            this.AddCheck(430, 145, 2510, 2511, false, (int)SkillName.Herding);
            this.AddCheck(430, 165, 2510, 2511, false, (int)SkillName.Tracking);
            this.AddCheck(430, 185, 2510, 2511, false, (int)SkillName.Veterinary);
            this.AddImage(429, 208, 2086); // ------------------------------------------------------------  Thieving
            this.AddCheck(430, 225, 2510, 2511, false, (int)SkillName.DetectHidden);
            this.AddCheck(430, 245, 2510, 2511, false, (int)SkillName.Hiding);
            this.AddCheck(430, 265, 2510, 2511, false, (int)SkillName.Lockpicking);
            this.AddCheck(430, 285, 2510, 2511, false, (int)SkillName.Poisoning);
            this.AddCheck(430, 305, 2510, 2511, false, (int)SkillName.RemoveTrap);
            this.AddCheck(430, 325, 2510, 2511, false, (int)SkillName.Snooping);
            this.AddCheck(430, 345, 2510, 2511, false, (int)SkillName.Stealing);
            this.AddCheck(430, 365, 2510, 2511, false, (int)SkillName.Stealth);
            this.AddImage(429, 388, 2086); // ------------------------------------------------------------  Bard
            this.AddCheck(430, 405, 2510, 2511, false, (int)SkillName.Discordance);
            this.AddCheck(430, 425, 2510, 2511, false, (int)SkillName.Musicianship);
            this.AddCheck(430, 445, 2510, 2511, false, (int)SkillName.Peacemaking);
            this.AddCheck(430, 465, 2510, 2511, false, (int)SkillName.Provocation);
            this.AddHtml(450, 65, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#001052>Wilderness</BASEFONT>", (bool)false, (bool)false); // -----------------------  Wilderness
            this.AddHtml(450, 85, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Animal Lore</BASEFONT>", (bool)false, (bool)false);
            this.AddHtml(450, 105, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Animal Taming</BASEFONT>", (bool)false, (bool)false);     // Comment if before Stygian Abyss Expansion
            this.AddHtml(450, 125, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Fishing</BASEFONT>", (bool)false, (bool)false);         
            this.AddHtml(450, 145, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Herding</BASEFONT>", (bool)false, (bool)false);   
            this.AddHtml(450, 165, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Tracking</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(450, 185, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Veterinary</BASEFONT>", (bool)false, (bool)false);     
			this.AddHtml(450, 205, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#001052>Thieving</BASEFONT>", (bool)false, (bool)false); // -----------------------  Thieving
            this.AddHtml(450, 225, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Detect Hidden</BASEFONT>", (bool)false, (bool)false);         
            this.AddHtml(450, 245, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Hiding</BASEFONT>", (bool)false, (bool)false);       
            this.AddHtml(450, 265, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Lockpicking</BASEFONT>", (bool)false, (bool)false);      
            this.AddHtml(450, 285, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Poisoning</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(450, 305, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Remove Trap</BASEFONT>", (bool)false, (bool)false);       
            this.AddHtml(450, 325, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Snooping</BASEFONT>", (bool)false, (bool)false);        
            this.AddHtml(450, 345, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Stealing</BASEFONT>", (bool)false, (bool)false);   
            this.AddHtml(450, 365, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Stealth</BASEFONT>", (bool)false, (bool)false); 
			this.AddHtml(450, 385, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#001052>Bard</BASEFONT>", (bool)false, (bool)false); // -----------------------  Bard
            this.AddHtml(450, 405, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Discordance</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(450, 425, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Musicianship</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(450, 445, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Peacemaking</BASEFONT>", (bool)false, (bool)false); 
            this.AddHtml(450, 465, 2314, 20, "<BASEFONT SIZE=8 FACE=1 COLOR=#5a4a31>Provocation</BASEFONT>", (bool)false, (bool)false); 			
	//******************************************************************************************************************


	
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
