using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using UnityEditor.AI;


public class NavPlayer : MonoBehaviour
{
    private Transform Torso;
    private Transform TorsoHeading;

    public Transform Target;
    public Transform Map;
    public Camera cam;
    public NavMeshSurface surface;

    private NavMeshAgent agent;
    private NavMeshAgent landerAgent;
    private LineRenderer line;
    private GameObject calCube;
    private GameObject floorCalCube;
   

    public float miniMapZoom = 10;
    float smoothTime = 0.7f;
    float Velocity = 0.0f;
    bool cal = false;



    // Start is called before the first frame update
    void Start()
    {

        Torso = GameObject.FindGameObjectWithTag("Torso").transform;
        TorsoHeading = GameObject.FindGameObjectWithTag("TorsoHeading").transform;
        line = GetComponent<LineRenderer>(); //get the line renderer
        agent = GetComponent<NavMeshAgent>(); //get the agent
        landerAgent = GameObject.FindGameObjectWithTag("NavPlayerLander").GetComponent<NavMeshAgent>();
        calCube = GameObject.FindGameObjectWithTag("CalCube");
        floorCalCube = GameObject.FindGameObjectWithTag("FloorCalCube");
        calCube.GetComponent<Renderer>().material.color = Color.gray;
        CalibrateRotation();
        //getPath();

    }

    private void Update()
    {
        
        
        Vector3 TempTorso = Torso.position;
        TempTorso.y = Map.position.y;
        transform.position = TempTorso;
        transform.localRotation = Quaternion.Euler(90, 0, 0);

        if (cal)
        {
            CalibrateRotation();

        }

        
        if (Target != null)
        {
            StartCoroutine(getPath());
            cameraZoom();
        }
        else
        {
            line.enabled =false;
            float newPosition = Mathf.SmoothDamp(cam.orthographicSize, miniMapZoom, ref Velocity, smoothTime);
            cam.orthographicSize = newPosition;
        }
       
    }

    void cameraZoom()
    {
        if (agent.isOnNavMesh && agent.path.corners.Length >1)
        { 
            float dist = Vector3.Distance(transform.position, agent.path.corners[1]);
            float endDist = Vector3.Distance(transform.position, agent.pathEndPosition);
            if (dist < 4 || endDist < 8)
            {
                float newPosition = Mathf.SmoothDamp(cam.orthographicSize, miniMapZoom, ref Velocity, smoothTime);
                cam.orthographicSize = newPosition;
            }
            else
            {
                float newPosition = Mathf.SmoothDamp(cam.orthographicSize, miniMapZoom/2, ref Velocity, smoothTime);
                cam.orthographicSize = newPosition;
            }
        }
        
    }
    
    IEnumerator getPath()
    {
        //wait for the path to generate

        
        if (agent.isOnNavMesh)
        {
            
            agent.SetDestination(Target.position); //create the path
            landerAgent.SetDestination(GameObject.FindGameObjectWithTag("Lander").transform.position);
            yield return new WaitForEndOfFrame();
            
            line.enabled = true;
            if (agent.path.corners.Length >0 )
            {
                Vector3 pathPos = agent.path.corners[0];
                pathPos.y += .05f;
                line.SetPosition(0, pathPos); //set the line's origin

                DrawPath(agent.path);
               
                agent.isStopped = true;//add this if you don't want to move the agent
            }
            
        }

        yield return null;

    }

    void DrawPath(NavMeshPath path)
    {
       
        if (path.corners.Length < 2) //if the path has 1 or no corners, there is no need
            return;

        line.positionCount =path.corners.Length; //set the array of positions to the amount of corners

        for (var i = 1; i < path.corners.Length; i++)
        {
            Vector3 pathPos = path.corners[i];
            pathPos.y += .05f;
            line.SetPosition(i, pathPos); //go through each corner and set that to the line renderer's position
        }
    }

    public void CalibrateMap()
    {
        if (cal==false)
        {
            calCube.GetComponent<Renderer>().material.color = Color.green;
            StopCoroutine("getPath");
            agent.path.ClearCorners();
            agent.enabled = false;
            landerAgent.ResetPath();
            landerAgent.enabled = false;
            cal = true;
            
        }
        else if(cal==true)
        {
            cal = false;
            calCube.GetComponent<Renderer>().material.color = Color.gray;
            //UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
            Debug.Log("Bake NavMesh");
            surface.BuildNavMesh();
            agent.enabled = true;
            landerAgent.enabled = true;

            
        }
       

        //surface.transform.localEulerAngles = new Vector3(0, angle, 0);


    }

    private void CalibrateRotation()
    {
        //Move Entire Map centered on lander to player position and torso rotation
        Vector3 torsoPos = Torso.transform.position;
        Vector3 torsoRot = Torso.transform.rotation.eulerAngles;
        Vector3 TorsoHeadingPos = TorsoHeading.position;
        torsoPos.y = 0f;
        TorsoHeadingPos.y = 0;
        Vector3 heading = (TorsoHeadingPos - torsoPos).normalized;
        Vector3 axis = Vector3.down;
        //Debug.DrawRay(Torso.position, axis, Color.blue);
        //float angle = (Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg) % 360;
        float angle = Vector3.SignedAngle(heading, Vector3.forward, axis);

        Map.transform.localEulerAngles = new Vector3(0, angle, 0);
        torsoPos.y = floorCalCube.transform.position.y;
        Map.transform.position = torsoPos;
        transform.position = Map.transform.position;

        
    }

    public void setTarget(Transform target)
    {
        Target = target;
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
