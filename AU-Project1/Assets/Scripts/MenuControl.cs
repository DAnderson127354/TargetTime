using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
	public GameObject TitleScreen;
	public GameObject CustomizationScreen;
    public GameObject HighScoreScreen;

    public Text scoreText;
    public InputField input;

    public SaveLoad saveSystem;

    public void SetFieldActive()
    {
        input.gameObject.SetActive(true);
    }

    public void Load()
    {
        if (input.text != "")
        {
            SceneManager.LoadScene("Main");
        }
        
    }

    public void SavePlayerInput()
    {
        PlayerPrefs.SetString("playerName", input.text);
        PlayerPrefs.Save();
    }

    public void Customize()
    {
    	TitleScreen.SetActive(false);
    	CustomizationScreen.SetActive(true);
    }

    public void Back(string screenName)
    {
        if (screenName == "custom")
    	    CustomizationScreen.SetActive(false);
        else
            HighScoreScreen.SetActive(false);

        TitleScreen.SetActive(true);
    }

    public void View()
    {
        scoreText.text = saveSystem.ShowScoreBoard();

        TitleScreen.SetActive(false);
        HighScoreScreen.SetActive(true);        
    }
}
