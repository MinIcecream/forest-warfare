using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    public enum panelType
    {
        pause,
        well,
        compendium
    }
    public panelType thisPanelType;

    public int priority;
}
