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
        public GameObject StoryIntro;
        public GameObject HelpIntro;
        public GameObject SelectGroup;
        public GameObject StartButton;
        public GameObject PowerMenu;
        public GameObject PowerMenuButton;
        void Start()
        {
            GameState.Setup();
            if(GameState.HasCompletedTutorial != 0)
            {
                menuButtons = GameObject.Find("SelectGroup");
                menuButtons.SetActive(true);
                SelectGroup.SetActive(true);
                PowerMenuButton.SetActive(true);
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

        public void ExitStory()
        {
            StoryIntro.SetActive(false);
            HelpIntro.SetActive(true);
        }

        public void ExitHelp()
        {
            HelpIntro.SetActive(false);
            GameState.CompleteTutorial();
            StartButton.SetActive(true);
            SelectGroup.SetActive(true);
            PowerMenuButton.SetActive(true);
        }

        public void EnterPowerMenu()
        {
            StartButton.SetActive(false);
            SelectGroup.SetActive(false);
            PowerMenu.SetActive(true);
            PowerMenuButton.SetActive(false);
        }

        public void ExitPowerMenu()
        {
            StartButton.SetActive(true);
            SelectGroup.SetActive(true);
            PowerMenu.SetActive(false);
            PowerMenuButton.SetActive(true);
        }

    }
}

