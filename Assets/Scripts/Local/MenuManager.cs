using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMN.Global;

namespace GMN.Local
{
    public class MenuManager : MonoBehaviour
    {
        // Start is called before the first frame update

        private int currentlySelectedLevel;
        private GameObject menuButtons; 
        void Start()
        {
            GameState.Setup();
            if(GameState.HasCompletedTutorial != 0)
            {
                menuButtons = GameObject.Find("SelectGroup");
                menuButtons.SetActive(true);
            }
        }

        public void PreviousButton()
        {
            Debug.Log("Previous button works");
        }

        public void NextButton()
        {
            Debug.Log("Next button works");
        }

    }
}

