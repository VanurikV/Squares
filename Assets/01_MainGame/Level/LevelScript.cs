using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace squares
{
    public class LevelScript : MonoBehaviour
    {
        public List<Sprite> LeveList;
        public GameObject LevelImage;


        public void SetLevel()
        {
            int l = PlayerPrefs.GetInt(PPString.CurrentLevel.ToString());
            LevelImage.GetComponent<Image>().sprite = LeveList[l];
        }
        
    }
}
