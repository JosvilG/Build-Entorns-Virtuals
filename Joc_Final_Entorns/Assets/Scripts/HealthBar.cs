using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int maxHP)
    {

        slider.maxValue = maxHP;
        slider.value = maxHP;
        //Debug.Log("Value slider " + slider.maxValue + " maxhp " + maxHP);

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int HP)
    {
        slider.value = HP;
        //Debug.Log("Vida actual: " + slider.value);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}