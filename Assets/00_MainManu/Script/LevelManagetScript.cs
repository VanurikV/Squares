using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace squares
{
    public class LevelManagetScript : MonoBehaviour
    {

        public GameObject ButtonContainer;

        private List<Button> levelButtons;

        
        void Start()
        {

            levelButtons= ButtonContainer.GetComponentsInChildren<Button>(true).ToList();
            levelButtons.Sort((a, b) => a.name.CompareTo(b.name));

            
            foreach (Button button in levelButtons)
                button.interactable = false;


            int MaxLevel = PlayerPrefs.GetInt(PPString.MaxCompleteLevel.ToString());

            for (int i = 0; i <= MaxLevel; i++)
            {
                levelButtons[i].interactable = true;
            }

        }

       public void onButtonClick(int level)
        {
            PlayerPrefs.SetInt(PPString.CurrentLevel.ToString(), level);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);
        }

    }
}
