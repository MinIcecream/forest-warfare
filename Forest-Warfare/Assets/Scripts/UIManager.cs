using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PauseManager pauseMan;
    public WellSelectWeapon wellScript;
    public GameObject compendiumObj;

    void Update()
    {
        //Close newest panel
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject[] panels = GameObject.FindGameObjectsWithTag("UIPanel");

            if (panels.Length > 0)
            {

                int highestPrio = 0;
                GameObject highestPrioPanel = null;

                foreach (GameObject panel in panels)
                {
                    if (panel.GetComponent<UIPanel>().priority > highestPrio)
                    {
                        highestPrio = panel.GetComponent<UIPanel>().priority;
                        highestPrioPanel = panel;
                    }
                }

                switch (highestPrioPanel.GetComponent<UIPanel>().thisPanelType)
                {
                    case UIPanel.panelType.well:
                        wellScript.CloseWell();
                        break;
                    case UIPanel.panelType.pause:
                        pauseMan.Unpause();
                        break;
                    case UIPanel.panelType.compendium:
                        compendiumObj.SetActive(false);
                        break;
                }
            }

            //if nothing open pause game
            else
            {
                pauseMan.Pause();
            }
        }
    }
}
