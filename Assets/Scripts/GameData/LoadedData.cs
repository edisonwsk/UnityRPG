﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityRPG
{
    //easy grouping of all data dictionaries
    public class GameDataSet
    {
        public Dictionary<long, ItemData> itemDataDictionary { get; set; }
        public Dictionary<long, UsableItemData> usableItemDataDictionary { get; set; }
        public Dictionary<long, WeaponData> weaponDataDictionary { get; set; }
        public Dictionary<long, RangedWeaponData> rangedWeaponDataDictionary { get; set; }
        public Dictionary<long, AmmoData> ammoDataDictionary { get; set; }
        public Dictionary<long, ArmorData> armorDataDictionary { get; set; }

        public Dictionary<long, EffectData> effectDataDictionary { get; set; }
        public Dictionary<long, AbilityData> abilityDataDictionary { get; set; }

        public Dictionary<long, GameCharacterData> gameCharacterDataDictionary { get; set; }
        public Dictionary<long, TalentTreeData> talentTreeDataDictionary { get; set; }
    }

    public class EffectData
    {
        public long ID { get; set; }
        public string name { get; set; }
        public StatType statType { get; set; }

        public int minAmount { get; set; }
        public int maxAmount { get; set; }

        public int duration { get; set; } // -1 for passive effect

        public TempEffectType effectType { get; set; }
        public string spritesheetName { get; set; }
        public int spritesheetIndex { get; set; }
    }

    public class AbilityData
    {
        public long ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int ap { get; set; }
        public int cooldown { get; set; }

        public int range { get; set; }

        public AbilityTargetType targetType { get; set; }
        public TilePatternType tilePatternType { get; set; } //only used for AOE abilities

        public List<long> activeEffects { get; set; }
        public List<long> passiveEffects { get; set; }

        public string sheetname { get; set; }
        public int spriteindex { get; set; }
    }

    //View Model object used for displaying the talen tree - combines talent Tree, ability data, and player's owned abilities
    public class TalentTreeDisplayData
    {
        public long ID { get; set; }
        public long AbilityID { get; set; }
        public string AbilityName { get; set; }
        public string AbilityDescription { get; set; }
        public string SpriteSheetName { get; set; }
        public int SpriteSheetIndex { get; set; }
        
        public int AP { get; set; }
        public int uses { get; set; }
        public int range { get; set; }
        public AbilityTargetType targetType { get; set; }
        public TilePatternType tilePatternType { get; set; }
        public List<string> effectDescriptionList { get; set; }

        public bool unlocked { get; set; }
        public bool owned { get; set; }

        public int tier { get; set; }
        public string tag { get; set; }
        public int levelReq { get; set; }
        public List<string> abilityReqNameList { get; set; }

        public string getDescription()
        {
            string desc = "";
            desc += AbilityDescription + "\n";
            desc += "AP: " + AP + ", Uses: " + uses;
            if (range > 1)
            {
                desc += ", range: " + range;
            }
            desc += ", Target: " + targetType.ToString() + ", Pattern: " + tilePatternType;

            return desc;
        }

        public string getRequirements()
        {
            string req = "";
            if (!unlocked)
            {
                req += "Lvl: " + levelReq + ". ";
                if(abilityReqNameList.Count > 0){
                    req += "Req: ";
                    foreach (var a in abilityReqNameList)
                    {
                        req += a + ", ";
                    }
                }
            }
            return req;

        }
    }

    public class TalentTreeData
    {
        public long ID { get; set; }
        public long AbilityID { get; set; }
        public int tier { get; set; }
        public string tag { get; set; }
        public int levelReq {get;set;}
        public List<long> abilityReqs { get; set; }

       
    }

    public class GameCharacterData
    {
        public long ID { get; set; }

        public string name { get; set; }
        public char displayChar { get; set; }
        public CharacterType type { get; set; }
        public EnemyType enemyType { get; set; }

        public string characterSpritesheetName { get; set; }
        public int characterSpriteIndex { get; set; }

        public string portraitSpritesheetName { get; set; }
        public int portraitSpriteIndex { get; set; }

        public int level { get; set; }

        public int ac { get; set; }

        public int hp { get; set; }

        public int attack { get; set; }

        public int ap { get; set; }

        public int strength { get; set; }
        public int agility { get; set; }
        public int endurance { get; set; }
        public int spirit { get; set; }

        public List<long> inventory { get; set; } //list of Item IDs
        public List<long> equippedArmor { get; set; } //list of ArmorIds
        public long weapon { get; set; } //weaponId (Ranged or Melee)

        public List<long> activeEffects { get; set; } //list of EffectIds
        public List<long> passiveEffects { get; set; } //list of EffectIds

        public List<long> abilityList { get; set; } //list of AbilityIds
    }

    public class ItemData
    {
        public long ID { get; set; }
        public string name { get; set; }
        public ItemType type { get; set; }
        public List<long> passiveEffects { get; set; }
        public List<long> activeEffects { get; set; }

        public string sheetname { get; set; }
        public int spriteindex { get; set; }

        public long price { get; set; }

    }

    public class UsableItemData : ItemData
    {
        public int actionPoints { get; set; }
        public int uses { get; set; }
        public List<long> itemAbility { get; set; } //Reference to Ability ID
    }


    public class WeaponData : ItemData
    {
        public int minDamage { get; set; }
        public int maxDamage { get; set; }
        public int AP { get; set; }
        public WeaponType weaponType { get; set; }
    }

    public class RangedWeaponData : WeaponData
    {
        public int range { get; set; }
        public AmmoType ammoType { get; set; }

    }

    public class AmmoData : ItemData
    {
        public int bonusDamage { get; set; }
        public AmmoType ammoType { get; set; }

    }

    public class ArmorData : ItemData
    {
        public int armor { get; set; }
        public ArmorType armorType { get; set; }

    }

}
