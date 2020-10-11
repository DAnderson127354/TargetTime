using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Animator timerAnim;
	public Text timerText;
	public Text pointText;
	public Text plusText;

	public Text goalText;
	public Text totalText;
	public Text winText;
	public GameObject GameOverScreen;

	private float Timer;
	public bool GameOver;
    private string playerInitials;
	private int points;
    private float goal;
    private float highscore; //hits per second

    public SaveLoad saveSystem;

    // Start is called before the first frame update
    void Start()
    {
        Timer = PlayerPrefs.GetFloat("Time", 120);
        goal = PlayerPrefs.GetFloat("Goal", 25);
        playerInitials = PlayerPrefs.GetString("playerName");
        timerAnim.Play("TimerAnim");
        float s = PlayerPrefs.GetFloat("Time", 120)/10;
        timerAnim.speed = 1/s;
        GameOver = false;
        points = 0;
        highscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
    	if (GameOver)
        {
            if (Input.GetKeyDown(KeyCode.M))
                Exit();
            return;
        }
    		

        Timer -= Time.deltaTime;

        string minutes = Mathf.Floor(Timer / 60).ToString("00");
     	string seconds = (Timer % 60).ToString("00");
     	string display = string.Format("{0}:{1}", minutes, seconds);
     	timerText.text = display;

        if (Timer <= 0)
        	EndGame();
    }

    void EndGame()
    {
    	GameOver = true;
    	timerText.text = "00:00";
    	GameOverScreen.SetActive(true);
    	goalText.text = "Goal: " + goal;
    	totalText.text = "Total points: " + points;
        float sec = PlayerPrefs.GetFloat("Time", 120);
        highscore = points / sec;
        Cursor.lockState = CursorLockMode.None;

        if (points >= goal)
        {
            winText.text = "You passed!";
            bool entryAdded = saveSystem.AddHighScore(playerInitials, points, PlayerPrefs.GetFloat("Time"), highscore);

            if (entryAdded)
                winText.text = "New Highscore!";
        }
    	else
    		winText.text = "You didn't get enough points...";

    	Debug.Log("Game Over");
    }

    public void Exit()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void AddPoints(int point)
    {
    	points += point;
    	pointText.text = points + " pts.";
    	StartCoroutine(PlusPoints(point));
    }

    IEnumerator PlusPoints(int points)
    {
    	plusText.text = "+"+ points;

    	yield return new WaitForSeconds(3);

    	plusText.text = "";
    }
}
