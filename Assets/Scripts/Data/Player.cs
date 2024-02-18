
using System.Collections.Generic;
using UnityEngine;

namespace v_hero
{
    public class Player
    {
        private static Player instance;

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player();
                }
                return instance;
            }
        }
        public string name { set; get; }
        public float health { set; get; }
        public int level { set; get; }
        public float xpPoints { set; get; }
        public float targetXp { set; get; }
        public int primaryCurrency { set; get; }
        public int secondaryCurrency { set; get; }

        public List<AbilityData> abilities = new List<AbilityData>();
        
        public Player()
        {
            name = "Guest";
            health = 1f;
            level = 1;
            xpPoints = 0f;
            targetXp = 100f;
            primaryCurrency = 250;
            secondaryCurrency = 50;
        }

        public void SaveData()
        {
            PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(this));
            PlayerPrefs.Save();
        }

        public void LoadData()
        {
            if (PlayerPrefs.HasKey("PlayerData"))
            {
                string jsonData = PlayerPrefs.GetString("PlayerData");
                JsonUtility.FromJsonOverwrite(jsonData, this);
            }
        }
    }
}
