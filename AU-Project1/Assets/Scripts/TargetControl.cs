using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{
	public GameManager manager;
    public SoundManager soundManager;
	public int point;

    void Update()
    {
        transform.Rotate(new Vector3(0,0,1) * 40 * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("hi");
    	if (col.gameObject.tag == "Bullet")
    	{
    		gameObject.SetActive(false);
    		Destroy(col.gameObject);
    		Debug.Log("hit!");
    		manager.AddPoints(point);
            soundManager.Hit();
    	}
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Howdy");
        if (col.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
            Destroy(col.gameObject);
            Debug.Log("hit!");
            manager.AddPoints(point);
            soundManager.Hit();
        }
        if (col.gameObject.tag == "Boundary")
        {
            gameObject.SetActive(false);
        }
    }
}
