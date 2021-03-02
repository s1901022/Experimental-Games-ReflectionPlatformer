using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageData
{
    public int stageNumber;
    public string stageName;
    public string stageBuildName;
    public bool collectableGot;
    public float bestTime;
    public int numberOfFlips;
    public int targetnumberOfFlips;
}

public static class Stage_Data
{
    static List<StageData> stageDatas = new List<StageData>();

    public static void Initialise(List<StageData> a_loadedStageData)
    {
        for (int i = 0; i < a_loadedStageData.Count; i++)
        {
            stageDatas.Add(a_loadedStageData[i]);
            Debug.LogError(a_loadedStageData[i].stageNumber);
            Debug.LogError(stageDatas[i].stageNumber);
        }

    }

    public static void GetStageData(int stageNumber, StageData a_stageData)
    {
        for (int i = 0; i < stageDatas.Count; i++)
        {
            if (stageNumber == stageDatas[i].stageNumber)
            {
                a_stageData.stageNumber = stageDatas[i].stageNumber;
                a_stageData.stageName = stageDatas[i].stageName;
                a_stageData.stageBuildName = stageDatas[i].stageBuildName;
                a_stageData.bestTime = stageDatas[i].bestTime;
                a_stageData.collectableGot = stageDatas[i].collectableGot;
                a_stageData.targetnumberOfFlips = stageDatas[i].targetnumberOfFlips;
                a_stageData.numberOfFlips = stageDatas[i].numberOfFlips;
            }
            return;
        }
        Debug.LogError("Stage does not exist");

    }

    public static void SetStageData(StageData a_stageData)
    {
        for (int i = 0; i < stageDatas.Count; i++)
        {
            if (a_stageData.stageNumber == stageDatas[i].stageNumber)
            {
                stageDatas[i] = a_stageData;
            }
            return;
        }
        Debug.LogError("Stage does not exist");
    }
}
