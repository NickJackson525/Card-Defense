using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsManager : MonoBehaviour
{
    public GameObject cardInfoButton;
    public GameObject enemyInfoButton;
    public GameObject deckBuilderInfoButton;
    public GameObject playInfoButton;
    public GameObject closeInstructionsButton;
    public GameObject backButton;

    private GameObject currentPanel;

    public void OpenCloseInfoPanel(GameObject panel)
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);

        if(currentPanel && (currentPanel.activeSelf))
        {
            currentPanel.SetActive(false);
            cardInfoButton.SetActive(true);
            enemyInfoButton.SetActive(true);
            deckBuilderInfoButton.SetActive(true);
            playInfoButton.SetActive(true);
            closeInstructionsButton.SetActive(true);
            backButton.SetActive(false);
            currentPanel = null;
        }
        else if(panel.activeSelf)
        {
            panel.SetActive(false);
            cardInfoButton.SetActive(true);
            enemyInfoButton.SetActive(true);
            deckBuilderInfoButton.SetActive(true);
            playInfoButton.SetActive(true);
            closeInstructionsButton.SetActive(true);
            backButton.SetActive(false);
            currentPanel = null;
        }
        else
        {
            currentPanel = panel;
            panel.SetActive(true);
            cardInfoButton.SetActive(false);
            enemyInfoButton.SetActive(false);
            deckBuilderInfoButton.SetActive(false);
            playInfoButton.SetActive(false);
            closeInstructionsButton.SetActive(false);
            backButton.SetActive(true);
        }
    }
}
