using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abilitySlot : MonoBehaviour
{
    public bool CooldownOn = false;
    public List<Image> CooldownImage;
    public List<Button> buttonImage;
    public List<Text> buttonText;
    public List<float> cooldownTimer;
    public List<AbilityScriptable> Ab;
    public Controls controller;
    public List<bool> Active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Active[0])
        {
            
            cooldownTimer[0] -= Time.deltaTime;
            if (cooldownTimer[0] <= 0)
            {
                Active[0] = false;
                CooldownImage[0].fillAmount = 0;
            }
            else
            {
                CooldownImage[0].fillAmount = (cooldownTimer[0] / Ab[0].cooldownTimer);
                buttonText[0].text = (Mathf.Round(cooldownTimer[0])).ToString();
            }
        }
        if (Active[1])
        {
            cooldownTimer[1] -= Time.deltaTime;
            if (cooldownTimer[1] <= 0)
            {
                Active[1] = false;
                CooldownImage[1].fillAmount = 0;
            }
            else
            {
                CooldownImage[1].fillAmount = (cooldownTimer[1] / Ab[1].cooldownTimer);
                buttonText[1].text = (Mathf.Round(cooldownTimer[1])).ToString();
            }
        }
        if (Active[2])
        {
            cooldownTimer[2] -= Time.deltaTime;
            if (cooldownTimer[2] <= 0)
            {
                Active[2] = false;
                CooldownImage[2].fillAmount = 0;
            }
            else
            {
                CooldownImage[2].fillAmount = (cooldownTimer[2] / Ab[2].cooldownTimer);
                buttonText[2].text = (Mathf.Round(cooldownTimer[2])).ToString();
            }
        }
        if (Active[3])
        {
            cooldownTimer[3] -= Time.deltaTime;
            if (cooldownTimer[3] <= 0)
            {
                Active[3] = false;
                CooldownImage[3].fillAmount = 0;
            }
            else
            {
                CooldownImage[3].fillAmount = (cooldownTimer[3] / Ab[3].cooldownTimer);
                buttonText[3].text = (Mathf.Round(cooldownTimer[3])).ToString();
            }
        }
        if (Active[4])
        {
            cooldownTimer[4] -= Time.deltaTime;
            if (cooldownTimer[4] <= 0)
            {
                Active[4] = false;
                CooldownImage[4].fillAmount = 0;
            }
            else
            {
                CooldownImage[4].fillAmount = (cooldownTimer[4] / Ab[4].cooldownTimer);
                buttonText[4].text = (Mathf.Round(cooldownTimer[4])).ToString();
            }
        }
        if (Active[5])
        {
            cooldownTimer[5] -= Time.deltaTime;
            if (cooldownTimer[5] <= 0)
            {
                Active[5] = false;
                CooldownImage[5].fillAmount = 0;
            }
            else
            {
                CooldownImage[5].fillAmount = (cooldownTimer[5] / Ab[5].cooldownTimer);
                buttonText[5].text = (Mathf.Round(cooldownTimer[5])).ToString();
            }
        }
        if (Active[6])
        {
            cooldownTimer[6] -= Time.deltaTime;
            if (cooldownTimer[6] <= 0)
            {
                Active[6] = false;
                CooldownImage[6].fillAmount = 0;
            }
            else
            {
                CooldownImage[6].fillAmount = (cooldownTimer[6] / Ab[6].cooldownTimer);
                buttonText[6].text = (Mathf.Round(cooldownTimer[6])).ToString();
            }
        }
        if (Active[7])
        {
            cooldownTimer[7] -= Time.deltaTime;
            if (cooldownTimer[7] <= 0)
            {
                Active[7] = false;
                CooldownImage[7].fillAmount = 0;
            }
            else
            {
                CooldownImage[7].fillAmount = (cooldownTimer[7] / Ab[7].cooldownTimer);
                buttonText[7].text = (Mathf.Round(cooldownTimer[7])).ToString();
            }
        }
        if (Active[8])
        {
            cooldownTimer[8] -= Time.deltaTime;
            if (cooldownTimer[8] <= 0)
            {
                Active[8] = false;
                CooldownImage[8].fillAmount = 0;
            }
            else
            {
                CooldownImage[8].fillAmount = (cooldownTimer[8] / Ab[8].cooldownTimer);
                buttonText[8].text = (Mathf.Round(cooldownTimer[8])).ToString();
            }
        }
        if (Input.GetKeyDown(controller.ab1)){
            if (Ab[0] != null && Active[0] == false)
            {
                cooldownTimer[0] = Ab[0].cooldownTimer;
                CooldownImage[0].fillAmount = cooldownTimer[0];
                buttonText[0].text = Ab[0].cooldownTimer.ToString();
                Active[0] = true;
            }
        }
        if (Input.GetKeyDown(controller.ab2))
        {
            if (Ab[1] != null && Active[1] == false)
            {
                cooldownTimer[1] = Ab[1].cooldownTimer;
                CooldownImage[1].fillAmount = cooldownTimer[1];
                buttonText[1].text = Ab[1].cooldownTimer.ToString();
                Active[1] = true;
            }
        }
        if (Input.GetKeyDown(controller.ab3))
        {
            if (Ab[2] != null && Active[2] == false)
            {
                cooldownTimer[2] = Ab[2].cooldownTimer;
                CooldownImage[2].fillAmount = cooldownTimer[2];
                buttonText[2].text = Ab[2].cooldownTimer.ToString();
                Active[2] = true;
            }
        }
        if (Input.GetKeyDown(controller.ab4))
        {
            if (Ab[3] != null && Active[3] == false)
            {
                cooldownTimer[3] = Ab[3].cooldownTimer;
                CooldownImage[3].fillAmount = cooldownTimer[3];
                buttonText[3].text = Ab[3].cooldownTimer.ToString();
                Active[3] = true;
            }
        }
        if (Input.GetKeyDown(controller.ab5))
        {
            if (Ab[4] != null && Active[4] == false)
            {
                cooldownTimer[4] = Ab[4].cooldownTimer;
                CooldownImage[4].fillAmount = cooldownTimer[4];
                buttonText[4].text = Ab[4].cooldownTimer.ToString();
                Active[4] = true;
            }
        }
        if (Input.GetKeyDown(controller.ab6))
        {
            if (Ab[5] != null && Active[5] == false)
            {
                cooldownTimer[5] = Ab[5].cooldownTimer;
                CooldownImage[5].fillAmount = cooldownTimer[5];
                buttonText[5].text = Ab[5].cooldownTimer.ToString();
                Active[5] = true;
            }
        }
        if (Input.GetKeyDown(controller.ab7))
        {
            if (Ab[6] != null && Active[6] == false)
            {
                cooldownTimer[6] = Ab[6].cooldownTimer;
                CooldownImage[6].fillAmount = cooldownTimer[6];
                buttonText[6].text = Ab[6].cooldownTimer.ToString();
                Active[6] = true;
            }
        }
        if (Input.GetKeyDown(controller.ab8))
        {
            if (Ab[7] != null && Active[7] == false)
            {
                cooldownTimer[7] = Ab[7].cooldownTimer;
                CooldownImage[7].fillAmount = cooldownTimer[7];
                buttonText[7].text = Ab[7].cooldownTimer.ToString();
                Active[7] = true;
            }
        }
        if (Input.GetKeyDown(controller.ab9))
        {
            if (Ab[8] != null && Active[8] == false)
            {
                cooldownTimer[8] = Ab[8].cooldownTimer;
                CooldownImage[8].fillAmount = cooldownTimer[8];
                buttonText[8].text = Ab[8].cooldownTimer.ToString();
                Active[8] = true;
            }
        }
    }
}
