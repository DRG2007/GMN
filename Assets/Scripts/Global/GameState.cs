using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace GMN.Global
{
    public static class GameState
    {
        private static int level;

        private static int hasCompletedTutorial;

        private static int levelsCompleted;

        private static int firstTimeRun;

        public const string FirstTimeRunString = "FirstTimeRun";

        public const string LevelString = "Level";

        public const string HasCompletedTutorialString = "TutorialCompleted";

        public const string levelsCompletedString = "LevelsCompleted";

        public static int HasCompletedTutorial { get => hasCompletedTutorial;}
        public static int FirstTimeRun { get => firstTimeRun;}
        public static int LevelsCompleted { get => levelsCompleted;}
        public static int Level { get => level;}

        public static void Setup()
        {
            if(PlayerPrefs.GetInt(FirstTimeRunString, 0) == 0)
            {
                firstTimeRun = 1;
                hasCompletedTutorial = 0;
                levelsCompleted = 0;
                PlayerPrefs.SetInt(HasCompletedTutorialString, hasCompletedTutorial);
                PlayerPrefs.SetInt(levelsCompletedString, levelsCompleted);
                PlayerPrefs.SetInt(FirstTimeRunString, FirstTimeRun);
                PlayerPrefs.Save();
                
            }
        }

        public static void CompleteTutorial()
        {
            if(PlayerPrefs.GetInt(FirstTimeRunString, 0) == 1)
            {
                hasCompletedTutorial = 1;
                PlayerPrefs.SetInt(HasCompletedTutorialString, hasCompletedTutorial);
                PlayerPrefs.Save();
            }
        }

        public static void CompleteLevel()
        {
            if(PlayerPrefs.GetInt(levelsCompletedString, 0) == level - 1)
            {
                levelsCompleted++;
                PlayerPrefs.SetInt(levelsCompletedString, levelsCompleted);
                PlayerPrefs.Save();
            }
        }


    }
}
