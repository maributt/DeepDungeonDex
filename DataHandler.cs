﻿using System.Collections.Generic;

namespace DeepDungeonDex
{
    public class DataHandler
    {
        public class MobData
        {
            public bool? IsStunnable { get; set; }
            public bool IsUndead { get; set; } = false;
            public bool IsPatrol { get; set; } = false;
            public string MobNotes { get; set; } = "";
            

            public enum ThreatLevel
            {
                Unspecified,
                Easy,
                Caution,
                Dangerous,
                Vicious
            }
            public ThreatLevel Threat { get; set; }

            public enum AggroType
            {
                Unspecified,
                Sight,
                Sound,
                Proximity,
                Boss
            }
            public AggroType Aggro { get; set; }
            public bool IsBloodAggro { get; set; } = false;
        }

        public static MobData Mobs(int nameID)
        {
            if (mobs.TryGetValue(nameID, out MobData value)) return value;
            else return null;
        }

        private static readonly Dictionary<int, MobData> mobs = new Dictionary<int, MobData>()
            {
                // testing
                // antelope stag
                {4, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsUndead=true, IsPatrol=true, IsBloodAggro=true, MobNotes="" }},


                // // // PALACE OF THE DEAD // // //
                
                // PoTD floors 51-60
                //pudding, buffs their damage
                {4996, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Proximity, MobNotes="Spams Blizzard and buffs their damage, can be interrupted." }},
                //gremlin, vuln up 10s, fire 2, sight
                {5300, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, MobNotes="Auto inflicts Vulnerability Up for 10s." }},
                //deepeye, sight, hypnotize paralysis
                {5299, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, MobNotes="Casts a gaze spell inflicting paralysis." }},

                // PoTD floors 131-140
                //soul
                {5398, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sound, IsUndead=true}},
                //hecteyes
                {5399, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sound}},
                //ogre
                {5400, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight}},
                //mummy
                {5401, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Proximity, IsUndead=true}},
                //ahriman
                {5402, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, MobNotes="Casts Level 5 Petrify, a non-telegraphed conal AOE.\nThis causes 15 seconds of petrification." }},
                //dahak
                {5403, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, MobNotes="Auto inflicts Disease (reduces Max HP and slows movement down)"}},
                //monk
                {5404, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Proximity, MobNotes="Will cast a pull-in spell into a point-blank AoE (can be interrupted and Arm's Lengthed)."}},
                //troubador
                {5405, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Proximity, MobNotes="Spams \"Dark\"\nCan be dodged by moving behind/away from the mob during the cast." }},
                //taurus
                {5406, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight }},
                //guard
                {5407, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight}},
                //catoblepas
                {5408, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsPatrol=true, MobNotes="Casts a fast conal gaze attack (Eye of the Stunted):\nInflicts Minimum reducing your damage and movement speed.\nWill cast telegraphed AoE right after, be careful to bait early if hit by gaze." }},
                //gourmand
                {5409, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Proximity, MobNotes="Uses beatdown, hits a bit harder than an autoattack but nothing too scary."}},

                // PoTD floors 141-150
                //follower
                {5411, new MobData {  }},
                //ked
                {5412, new MobData {  }},
                //demon
                {5413, new MobData {  } },
                //gargoyle
                {5414, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight}},
                //knight
                {5415, new MobData {  Threat=MobData.ThreatLevel.Caution, }},
                //bhoot
                {5416, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Proximity, IsBloodAggro=true }},
                //hellhound
                {5417, new MobData {  }},
                //persona
                {5418, new MobData {  }},
                //succubus
                {5419, new MobData {  }},
                //manticore
                {5421, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsPatrol=true, MobNotes="Opens with a gapcloser into a self damage buff.\nWatch out for \"Ripper Claw\" a frontal conal untelegraphed AoE, move behind/away to avoid." }},
                //wraith
                {5422, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsPatrol=true, IsUndead=true, MobNotes="Watch out for their \"Scream\" cast, can be interrupted but followed by Accursed Pox (191-200)\nLater Floors note:\nCareful to not pull one while fighting a Deep Palace Knight" }},

                // PoTD bosses & misc.
                // mimic
                {2566, new MobData {Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Can be preferrable over killing \"Dangerous\" mobs in higher floors.\nMake sure to interrupt or stun the pox cast!"}},
                // floor 140 boss
                {5410, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Boss, IsUndead=true, MobNotes="Kuribu's cast will deal 30K+ damage to this boss (with Strength).\nIf solo, Steel is recommended (you may have to use 2x Kuribus otherwise to regen HP)\nFast strat is as follows:\n3* Beams, Dodge, 2 Beams, Dodge, 3* Beams, Dodge, 2 Beams\n*The 3rd Beams will have to be slightly slidecast\n(Adds for no fast strat will die in 1 Beam)" }},
                

                // // // HEAVEN ON HIGH // // //

				// HoH floors 1-9
                { 7262, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Auto inflicts Heavy debuff" } },
                { 7263, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Auto applies Physical Vuln Up every 10s" } },
                { 7264, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="AoE applies Paralysis" } },
                { 7265, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Triple auto inflicts Bleed" } },
                { 7266, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Untelegraphed Sleep followed by AoE" } },
                { 7267, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="AoE applies Bleed" } },
                { 7268, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Gaze" } },
                { 7269, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7270, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="AoE inflicts knockback" } },
                { 7271, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Conal AoE inflicts Bleed\nCircle AoE inflicts knockback" } },
                { 7272, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Unavoidable tankbuster-like \"Jaws\"" } },
                { 7273, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Untelegraphed buster inflicts Bleed and knockback" } },
                { 7274, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
				// HoH floors 11-19
                { 7275, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7276, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="" } },
                { 7277, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7278, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7279, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Lite buster \"Scissor Run\" followed by AoE" } },
                { 7280, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7281, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Gaze inflicts Seduce, followed by large AoE that inflicts Minimum" } },
                { 7282, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7283, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7284, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="" } },
                { 7285, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Buster and triple auto" } },
                { 7286, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Roomwide ENRAGE" } },
                { 7287, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
				// HoH floors 21-29
                { 7288, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Gaze inflicts Blind" } },
                { 7289, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Cures self and allies" } },
                { 7290, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Casts AoEs with knockback unaggroed\nLine AoE inflicts Bleed" } },
                { 7291, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Buffs own damage" } },
                { 7292, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Untelegraphed conal AoE with knockback, buster" } },
                { 7293, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="" } },
                { 7294, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7295, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Draw-in followed by cleave" } },
                { 7296, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Gaze" } },
                { 7297, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Line AoE inflicts Bleed" } },
                { 7298, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Cross AoE inflicts Suppuration" } },
                { 7299, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Large AoE inflicts Paralysis" } },
                { 7300, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Circle AoE inflicts Suppuration" } }, 
                //HoH floors 31-39
                { 7301, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7302, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Casts AoEs unaggroed" } },
                { 7303, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Double auto inflicts Bleed\nLow health ENRAGE" } },
                { 7304, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Low health ENRAGE" } },
                { 7305, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Line AoE inflicts Bleed\nLow health ENRAGE" } },
                { 7306, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Cleaves every other auto" } },
                { 7307, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7308, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Weak stack attack" } },
                { 7309, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7310, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Extremely large AoE" } },
                { 7311, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Line AoE inflicts Bleed\nLow health ENRAGE" } },
                { 7312, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Frontal cleave without cast or telegraph" } },
                { 7313, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Gaze inflicts Otter" } },
				// HoH floors 41-49
                { 7314, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Casts AoEs unaggroed" } },
                { 7315, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="" } },
                { 7316, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7317, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7318, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Large line AoE\nEventual ENRAGE" } },
                { 7319, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Casts AoEs unaggroed" } },
                { 7320, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Purple: double auto" } },
                { 7321, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Large cone AoE" } },
                { 7322, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7323, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Green: Casts AoEs unaggroed" } },
                { 7324, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Very wide line AoE" } },
                { 7325, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7326, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sound, IsStunnable=true, MobNotes="Eventual ENRAGE" } },
				//HoH floors 51-59
                { 7327, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Autos inflict stacking vuln up" } },
                { 7328, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Buster inflicts Bleed" } },
                { 7329, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Buffs own damage" } },
                { 7330, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Eventual instant ENRAGE" } },
                { 7331, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Cone AoE inflicts Bleed" } },
                { 7332, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Exclusively fatal line AoEs" } },
                { 7333, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7334, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7335, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Draw-in attack" } },
                { 7336, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Instant AoEs on targeted player unaggroed" } },
                { 7337, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Conal gaze, very quick low health ENRAGE" } },
                { 7338, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="" } },
                { 7339, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="" } },
				// HoH floors 61-69
                { 7340, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Inflicts stacking Poison that lasts 30s" } },
                { 7341, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Inflicts stacking vuln up" } },
                { 7342, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7343, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Fast alternating line AoEs that inflict Paralysis" } },
                { 7344, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sound, IsStunnable=true, MobNotes="Caster, double auto" } },
                { 7345, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Conal AoE inflicts Paralysis" } },
                { 7346, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Cleave and potent Poison" } },
                { 7347, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Large donut AoE, gaze attack inflicts Fear" } },
                { 7348, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Large circular AoE inflicts Bleed" } },
                { 7349, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Buffs own or ally's defense" } },
                { 7350, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="AoE inflicts numerous debuffs at once" } },
                { 7351, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
				// HoH floors 71-79
                { 7352, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7353, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Casts large AoE unaggroed\nExtremely large circular AoE" } },
                { 7354, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Untelegraphed knockback on rear" } },
                { 7355, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Double auto inflicts Bleed" } },
                { 7356, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Casts AoEs unaggroed that inflict Deep Freeze" } },
                { 7357, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Casts roomwide AoEs unaggroed\nLarge conal draw-in attack followed by heavy damage" } },
                { 7358, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Buffs own damage" } },
                { 7359, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Haste, eventual ENRAGE" } },
                { 7360, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Very large AoEs" } },
                { 7361, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Draw-in attack, extremely large AoE, eventual ENRAGE" } },
                { 7362, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Extremely large conal AoE, gaze inflicts Fear" } },
                { 7363, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="" } },
                { 7364, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Double auto and very large AoE" } },
				// HoH floors 81-89
				{ 7365, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Proximity, IsStunnable=false, MobNotes="Ram's Voice - get out\nDragon's Voice - get in\nTelegraphed cleaves" } },
                { 7366, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Buffs own damage unaggroed\nLarge AoE unaggroed that inflicts vuln up and stacks" } },
                { 7367, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Charges on aggro" } },
                { 7368, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Untelegraphed conal AoE on random player, gaze attack" } },
                { 7369, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Casts AoEs unaggroed" } },
                { 7370, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Double autos, very strong rear cleave if behind" } },
                { 7371, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Alternates line and circle AoEs untelegraphed" } },
                { 7372, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Buffs own damage and double autos" } },
                { 7373, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Draw-in attack, tons of bleed, and a stacking poison" } },
                { 7374, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Proximity, IsStunnable=false, MobNotes="Large donut AoE" } },
                { 7375, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Cone AoE, circle AoE, partywide damage" } },
                { 7376, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Charges, buffs own damage, double autos, electricity Bleed" } },
                { 7377, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Charges, buffs own damage, untelegraphed buster \"Ripper Claw\"" } },
				// HoH floors 91-99
                { 7378, new MobData { Threat=MobData.ThreatLevel.Vicious, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="WAR: Triple knockback with heavy damage\nBuffs own attack\nExtremely high damage cleave with knockback" } },
                { 7379, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="MNK: Haste buff, short invuln" } },
                { 7380, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="WHM: double autos\n\"Stone\" can be line of sighted" } },
                { 7381, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Proximity, IsStunnable=false, MobNotes="Cleave\nLarge line AoE that can be line of sighted" } },
                { 7382, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="\"Charybdis\" AoE that leaves tornadoes on random players" } },
                { 7383, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="" } },
                { 7384, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Casts targeted AoEs unaggroed, buffs own defense" } },
                { 7385, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Targeted AoEs, cleaves" } },
                { 7386, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Extremely quick line AoE \"Death's Door\" that instantly kills" } },
                { 7387, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Deals heavy damage to random players" } },
                { 7388, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Charges\nUntelegraphed line AoE \"Swipe\"\nUntelegraphed wide circle AoE \"Swing\"" } },
                { 7389, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Repeatedly cleaves for high damage, lifesteal, buffs own damage, three stacks of damage up casts ENRAGE \"Black Nebula\"" } },
                { 7390, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=true, MobNotes="Rapid double autos and untelegraphed line AoE \"Quasar\"" } },
                { 7391, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Sight, IsStunnable=null, MobNotes="Double autos, cone AoE inflicts Sleep" } },
                { 7584, new MobData { Threat=MobData.ThreatLevel.Dangerous, Aggro=MobData.AggroType.Sight, IsStunnable=false, MobNotes="Permanent stacking damage buff\nMassive enrage on random player\"Allagan Meteor\"\nGaze attack" } }, 
                // HoH bosses and misc.
                { 7392, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Floors 1-30: Bronze chests only\nHigh damage autos and instant kill AoE\n\"Malice\" can be interrupted with silence/stun/knockback/witching/\ninterject" } },
                { 7393, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsStunnable=true, MobNotes="Floors 31-60: Silver chests only\nHigh damage autos and instant kill AoE\n\"Malice\" can be interrupted with silence/stun/interject" } },
                { 7394, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Proximity, IsStunnable=false, MobNotes="Floors 61+: Gold chests only\nHigh damage autos and instant kill AoE\n\"Malice\" can only be interrupted with interject\nCANNOT STUN" } },
                { 7478, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Boss, IsStunnable=false, MobNotes="Summons lightning clouds that inflict stacking vuln up when they explode\nBoss does proximity AoE under itself that knocks players into the air\nGet knocked into a cloud to dispel it and avoid vuln\nHalf-roomwide AoE" } },
                { 7480, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Boss, IsStunnable=false, MobNotes="Goes to center of arena and casts knockback to wall (cannot be knockback invulned)\nFollows immediately with a half-roomwide AoE" } },
                { 7481, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Boss, IsStunnable=false, MobNotes="Summons butterflies on edges of arena\nDoes gaze mechanic that inflicts Fear\nButterflies explode untelegraphed" } },
                { 7483, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Boss, IsStunnable=false, MobNotes="Summons clouds on edge of arena\nDoes to-wall knockback that ignores knockback invulnerary (look for safe spot in clouds!)\nCasts half-roomwide AoE" } },
                { 7485, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Boss, IsStunnable=false, MobNotes="1) Untelegraphed swipe\n2) Untelegraphed line AoE on random player\n3) Gaze mechanic that inflicts Fear\n4) Summons pulsating bombs over arena and does a proximity AoE\n5) Repeats after bombs explode for the last time" } },
                { 7487, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Boss, IsStunnable=false, MobNotes="Summons staffs that do various AoEs\nStaffs then do line AoEs targeting players\nRoomwide AoE" } },
                { 7489, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Boss, IsStunnable=false, MobNotes="1) Untelegraphed frontal cleave\n2) Targets random player with \"Innerspace\" puddle (standing in puddle inflicts Minimum)\n3) Targets random player with \"Hound out of Hell\"\n4) Targeted player must stand in puddle to dodge \"Hound out of Hell\" and \"Devour\" (will instant-kill if not in puddle and give the boss a stack of damage up)\n5) Repeat" } },
                { 7490, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Boss, IsStunnable=false, MobNotes="1) Summons balls of ice\n2) Summons icicle that pierces through room, detonating any ice balls it hits\n3) \"Lunar Cry\" detonates remaining ice balls\n4) Exploding ice balls inflict Deep Freeze if they hit a player\n5) Boss jumps to random player, instantly killing if player is frozen (light damage otherwise)" } },
                { 7493, new MobData { Threat=MobData.ThreatLevel.Caution, Aggro=MobData.AggroType.Boss, IsStunnable=false, MobNotes="1) Heavy roomwide damage \"Ancient Quaga\"\n2) Pulsing rocks appear over arena, causing moderate damage and Heavy debuff if player is hit by one\n3) \"Meteor Impact\" summons proximity AoE at boss's current location\n4) Line AoE \"Aura Cannon\"\n5) Targeted circle AoE \"Burning Rave\"\n6) Point-blank circle AoE \"Knuckle Press\"\n7) Repeat" } },
                { 7610, new MobData { Threat=MobData.ThreatLevel.Easy, Aggro=MobData.AggroType.Proximity, IsStunnable=false, MobNotes="Does not interact, wide stun and immediately dies when attacked" } }
            };
    }
}