using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseGame : MonoBehaviour
{
    public List<StageData> GameStages;

    private void Start()
    {
        //Load save game date
        /* if (somthing exists with stage data saved within)
         * {
         *      Load stage data
         *      gameStages = //Loaded data
         * }
       */

        Stage_Data.Initialise(GameStages);
        Stage_Loader.InitialiseStageManager();
        Stage_Loader.LoadSceneSafe("DebugLevelSelect");
    }
}
