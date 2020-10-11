using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customization : MonoBehaviour
{
	public Slider slider;
	public Text valueText;
	public string sliderName;

	void Start()
	{
		if (PlayerPrefs.GetFloat(sliderName, 0) != 0)
        {
            valueText.text = PlayerPrefs.GetFloat(sliderName).ToString();
            slider.value = PlayerPrefs.GetFloat(sliderName);
        }
		else
			valueText.text = slider.minValue.ToString();

        if (sliderName == "Time")
        {
            ChangeTime();
        }
	}

    public void ChangeGoal()
    {
    	valueText.text = slider.value.ToString();
    	PlayerPrefs.SetFloat("Goal", slider.value);
    }

    public void ChangeTime()
    {
    	string minutes = Mathf.Floor(slider.value / 60).ToString("00");
     	string seconds = (slider.value % 60).ToString("00");
     	string display = string.Format("{0}:{1}", minutes, seconds);

     	valueText.text = display;
     	PlayerPrefs.SetFloat("Time", slider.value);
    }

    public void ChangeSensitivity()
    {
        valueText.text = slider.value.ToString();
        PlayerPrefs.SetFloat("Sensitivity", slider.value);
    }
}
