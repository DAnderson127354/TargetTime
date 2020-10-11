using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
	public GameObject[] targets;
	public int waitTime;
	public int respawnTime;
	private bool display;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float zMin;
    public float zMax;

    public float targetRadius;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        display = true;
    }

    // Update is called once per frame
    void Update()
    {
    	if (display)
        	StartCoroutine(DisplayTargets());
    }

    bool CanSpawnHere()
    {
        bool canSpawn = true;
        float randomX = Random.Range(xMin, xMax);
        float randomY = Random.Range(yMin, yMax);
        float randomZ = Random.Range(zMin, zMax);
        position = new Vector3(randomX, randomY, randomZ);
        Collider[] hitColliders = Physics.OverlapSphere(position, targetRadius);

        foreach(Collider hit in hitColliders)
        {
            canSpawn = false;
        }

        return canSpawn;
    }

    IEnumerator DisplayTargets()
    {
    	display = false;
    	int targetNum = Random.Range(1, targets.Length);
    	int index = -1;
    	int[] indexList = new int[targetNum];

    	//Debug.Log(targetNum);

    	for (int i = 0; i < targetNum; i++)
    	{
    		index = Random.Range(0, targets.Length);
            if (CanSpawnHere())
            {
                targets[index].transform.position = position;
            }
            targets[index].SetActive(true);
    		indexList[i] = index;
    	}

    	yield return new WaitForSeconds(waitTime);

    	for (int j = 0; j < targetNum; j++)
    	{
    		targets[indexList[j]].SetActive(false);
    	}

    	yield return new WaitForSeconds(respawnTime);
    	display = true;
    }
}
