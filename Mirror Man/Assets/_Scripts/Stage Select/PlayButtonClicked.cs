using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonClicked : MonoBehaviour
{
    public void GotoStage()
    {
        string stage = GetComponentInParent<StageDisplay>().GetStage();
        Stage_Loader.LoadSceneSafe(stage);
    }
}
