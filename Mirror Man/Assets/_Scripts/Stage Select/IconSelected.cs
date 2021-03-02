using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSelected : MonoBehaviour
{
    [SerializeField]
    private GameObject DetailsPanel;
    [SerializeField]
    private int m_stageNumber;
    private StageData m_myStageData;
    public void OnClick()
    {
        m_myStageData = new StageData();
        Stage_Data.GetStageData(m_stageNumber, m_myStageData);
        DetailsPanel.GetComponent<StageDisplay>().Show(m_myStageData);
    }
}
