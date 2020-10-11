// MoveTo.cs
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform goal;
    public Transform goal1;
    public Transform goal2;
    NavMeshAgent agent;
    private int nextSpot;
    public Vector3 startPos;

    private void OnEnable()
    {
        transform.position = startPos;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
        nextSpot = 0;
    }

    private void FixedUpdate()
    {
        //Debug.Log(Vector3.Distance(transform.position, goal2.position));
        if (Vector3.Distance(transform.position, goal.position) < 2 && nextSpot == 0)
        {
            agent.destination = goal1.position;
            nextSpot++;
        }

        if (Vector3.Distance(transform.position, goal1.position) < 3 && nextSpot == 1)
        {
            agent.destination = goal2.position;
            nextSpot++;
            //Debug.Log(nextSpot);
        }

        if (Vector3.Distance(transform.position, goal2.position) < 3 && nextSpot == 2)
        {
            gameObject.SetActive(false);
        }
    }
}
