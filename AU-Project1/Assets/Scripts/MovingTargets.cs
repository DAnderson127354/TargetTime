using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargets : MonoBehaviour
{
    private bool spawned = false;
    private int spawnNum;
    public int spawnMin;
    public int spawnMax;
    
    private float timer;

    void Start()
    {
        SetTimer();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (spawned == false && timer <= 0)
        {
            spawnNum = Random.Range(0, 30);
            Debug.Log(spawnNum);
            if (spawnNum <= spawnMax && spawnNum >= spawnMin)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                spawned = true;
            }
            else
                SetTimer();
        }

        if (spawned)
        {
            if (gameObject.transform.GetChild(0).gameObject.activeSelf == false)
            {
                spawned = false;
                SetTimer();
            }  
        }
        
    }

    private void SetTimer()
    {
        timer = Random.Range(5, 15);
    }
}
