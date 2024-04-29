using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMN.Global;
using TMPro;
using UnityEngine.SceneManagement;
using Polytope;

namespace GMN.Local
{
    public class MenuManager : MonoBehaviour
    {
        // Start is called before the first frame update

        private int currentlySelectedLevel;
        private GameObject menuButtons;
        public GameObject StoryIntro;

        public TMP_Text LevelTextMenu;
        public GameObject HelpIntro;
        
        public GameObject IntroGroup;
        public GameObject SelectGroup;
        public GameObject StartButton;
        public GameObject PowerMenu;
        public GameObject PowerMenuButton;

        private readonly static string[] stageNames = {"Stage 1", "Stage 2", "Stage 3"};
        void Start()
        {
            GameState.Setup();
            if(GameState.HasCompletedTutorial != 0)
            {
                menuButtons = GameObject.Find("SelectGroup");
                menuButtons.SetActive(true);
                SelectGroup.SetActive(true);
                IntroGroup.SetActive(false);
                PowerMenuButton.SetActive(true);
            }
        }

        public void PreviousButton()
        {
            if(currentlySelectedLevel - 1 > 0)
            {
                currentlySelectedLevel--;
                LevelTextMenu.text = "Level " + currentlySelectedLevel;
            }
        }

        public void NextButton()
        {
            if(currentlySelectedLevel < PlayerPrefs.GetInt(GameState.levelsCompletedString) + 1 && currentlySelectedLevel < stageNames.Length)
            {
                currentlySelectedLevel++;
                LevelTextMenu.text = "Level " + currentlySelectedLevel;
            }
        }

        public void ExitStory()
        {
            StoryIntro.SetActive(false);
            HelpIntro.SetActive(true);
        }

        public void ExitHelp()
        {
            GameState.CompleteTutorial();
            IntroGroup.SetActive(false);
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

        public void PlayGame()
        {
            if(PlayerPrefs.GetInt(GameState.HasCompletedTutorialString, 0) == 0)
            {
                StartButton.SetActive(false);
                StoryIntro.SetActive(true);
            } else if (currentlySelectedLevel > 0) {
                SceneManager.LoadScene(stageNames[currentlySelectedLevel - 1]);
                Debug.Log("Entered " + stageNames[currentlySelectedLevel - 1]);
            }
        }

    }
}

