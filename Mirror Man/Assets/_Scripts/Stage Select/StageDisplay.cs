using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageDisplay : MonoBehaviour
{
    private StageData DisplayedStageData;
    [SerializeField]
    private Text stageName;
    [SerializeField]
    private Text stageBestTime;
    [SerializeField]
    private Text stageCollectable;
    [SerializeField]
    private Button playButton;

    private Image m_displayWindow;
    private bool m_showDisplay;

    private void Start()
    {
        m_displayWindow = GetComponent<Image>();
        m_showDisplay = false;
        playButton.gameObject.SetActive(false);
        m_displayWindow.color = new Color(1f, 1f, 1f, 0f);
        stageName.color = new Color(1f, 1f, 1f, 0f);
        stageBestTime.color = new Color(1f, 1f, 1f, 0f);
        //stageCollectable.color = new Color(1f, 1f, 1f, 0f);
    }

    private void Update()
    {
        if (m_showDisplay == true)
        {
            if (m_displayWindow.color.a != 1f && m_displayWindow.color.a <= 1f) { m_displayWindow.color = new Color(1f, 1f, 1f, m_displayWindow.color.a + 0.1f); }
            if (stageName.color.a != 1f && stageName.color.a <= 1f) { stageName.color = new Color(0f, 0f, 0f, stageName.color.a + 0.1f); }
            if (stageBestTime.color.a != 1f && stageBestTime.color.a <= 1f) { stageBestTime.color = new Color(0f, 0f, 0f, stageBestTime.color.a + 0.1f); }
        }
    }

    public void Show(StageData a_stageData)
    {
        DisplayedStageData = a_stageData;
        Debug.Log(DisplayedStageData.stageName);
        stageName.text = DisplayedStageData.stageName;
        stageBestTime.text = DisplayedStageData.bestTime.ToString();
        m_showDisplay = true;
        playButton.gameObject.SetActive(true);
    }

    public string GetStage() { return DisplayedStageData.stageBuildName; }
}
