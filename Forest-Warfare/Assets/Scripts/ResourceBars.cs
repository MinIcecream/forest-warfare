using UnityEngine.UI;
using UnityEngine;

public class ResourceBars : MonoBehaviour
{
    public Slider slider;
    public float gas = 100;
    public float health;
 
    public void SetGas(float currentGas)
    {
        slider.value = gas;
    }
}
