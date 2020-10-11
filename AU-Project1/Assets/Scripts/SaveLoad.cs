using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //Allows for Saving/Loading (Input/Output)
//using JsonUtility;

public class SaveLoad : MonoBehaviour
{
    public string pName;
    public int score;
    public float time;
    public float hitsPerSec;
    private List<HighScoreEntry> sc;
   	private ScoreBoard scoreBoard;

    private void Awake()
    {        
        if (!(File.Exists(Application.dataPath + "/save.txt")))
        {
        	sc = new List<HighScoreEntry>();
            
            HighScoreEntry entry1 = new HighScoreEntry { pName = "---", score = 0, time = 0.0f, hitsPerSec = 0.0f, };
            HighScoreEntry entry2 = new HighScoreEntry { pName = "---", score = 0, time = 0.0f, hitsPerSec = 0.0f, };
            HighScoreEntry entry3 = new HighScoreEntry { pName = "---", score = 0, time = 0.0f, hitsPerSec = 0.0f, };
            sc.Add(entry1);
            sc.Add(entry2);
            sc.Add(entry3);
            Debug.Log(sc[0]);
          	scoreBoard = new ScoreBoard {sc = sc};
          	Debug.Log(scoreBoard.sc[0].pName);
            Save();
        }
        else
        	LoadGame();

    }

    public bool AddHighScore(string name, int score, float time, float hitsSec)
    {
        int i = CompareScores(hitsSec);

        if (i != -1)
        {
            HighScoreEntry newEntry = new HighScoreEntry
            {
                pName = name,
                score = score,
                time = time,
                hitsPerSec = hitsSec,
            };
            scoreBoard.sc[i] = newEntry;
            Save();
            return true;
        }

        return false;
    }

    public int CompareScores(float hitsSec)
    {
        int index = -1;
        LoadGame();

        if (hitsSec > scoreBoard.sc[0] .hitsPerSec)
        {
            index = 0;
            scoreBoard.sc[2] = scoreBoard.sc[1];
            scoreBoard.sc[1] = scoreBoard.sc[0];
        }
        else if (hitsSec > scoreBoard.sc[1].hitsPerSec)
        {
            index = 1;
            scoreBoard.sc[2] = scoreBoard.sc[1];
        }
        else if (hitsSec > scoreBoard.sc[2].hitsPerSec)
            index = 2;

        return index;
    }

    public string ShowScoreBoard()
    {
        LoadGame();
        string boardText = "";
        for (int index = 0; index < scoreBoard.sc.Count; index++)
        {
            string minutes = Mathf.Floor(scoreBoard.sc[index].time / 60).ToString("00");
            string seconds = (scoreBoard.sc[index].time % 60).ToString("00");

            string display = scoreBoard.sc[index].pName + " " + scoreBoard.sc[index].score.ToString() + " " + string.Format("{0}:{1}", minutes, seconds) + " " + scoreBoard.sc[index].hitsPerSec.ToString("F2") + " hits/sec";
            boardText += (index + 1).ToString() + " " + display + "\n";
        }
        return boardText;
    }

    private void Save()
    {
        Debug.Log("saving " + scoreBoard.sc[0].pName);
        string json = JsonUtility.ToJson(scoreBoard);
        File.WriteAllText(Application.dataPath + "/save.txt", json);  //Actually writes the text to a file.
    }

    private void LoadGame()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/save.txt");   //Actually reads the text from a file.
        //Debug.Log("before " + scoreBoard);
        scoreBoard = JsonUtility.FromJson<ScoreBoard>(saveString);
        //Debug.Log("after " + scoreBoard);
        //Debug.Log(scoreBoard.Length);
    }

    [System.Serializable]
    private class ScoreBoard
    {
    	public List<HighScoreEntry> sc;
    }

    [System.Serializable]
    private class HighScoreEntry
    {
        public string pName;
        public int score;
        public float time;
        public float hitsPerSec;
    }
}
