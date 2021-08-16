using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heathbar : MonoBehaviour {

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text healthcount;
    public int savemaxhealth;


    public void SetHeath(int heath)
    {
        slider.value = heath;
        healthcount.text = (heath.ToString()+"/"+savemaxhealth.ToString());
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHeath(int maxheath)
    {
        slider.maxValue = maxheath;
        slider.value = maxheath;
        savemaxhealth = maxheath;
        healthcount.text = (maxheath.ToString() + "/" + maxheath.ToString());
        fill.color = gradient.Evaluate(1f);
    }
	
}
