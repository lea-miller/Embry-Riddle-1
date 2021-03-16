using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavPlayerLander : MonoBehaviour
{

    public Transform Target;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //get the agent
        Target = GameObject.FindGameObjectWithTag("Lander").transform;
        agent.isStopped = true;//add this if you don't want to move the agent

    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(Target.position); //create the path
        getPath();
    }

    IEnumerator getPath()
    {
        //wait for the path to generate

        
        if (agent.isOnNavMesh)
        {

            //agent.SetDestination(Target.position); //create the path
            yield return new WaitForEndOfFrame();


            if (agent.path.corners.Length > 0)
            {
                
            }

        }

        yield return null;

    }

    public float getDistanceToTarget()
    {
        if (agent.hasPath)
        {
            //return agent.remainingDistance;

            float lng = 0.0f;
            NavMeshPath path = agent.path;

            if ((path.status != NavMeshPathStatus.PathInvalid) && (path.corners.Length > 1))
            {
                for (int i = 1; i < path.corners.Length; ++i)
                {
                    lng += Vector3.Distance(path.corners[i - 1], path.corners[i]);
                }
            }

            return lng;
        }
        else { return 0; }
    }
}
