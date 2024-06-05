using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCube : MonoBehaviour
{
    // position of the rays on each faces   

    public Transform tUp; 
    public Transform tDown; 
    public Transform tLeft; 
    public Transform tRight;    
    public Transform tFront; 
    public Transform tBack; 
    private int layerMask = 1<<8;
    CubeState cubeState;
    CubeMap cubeMap;
    public GameObject emptyGO;
    private List<GameObject> frontRays= new List<GameObject>();
    private List<GameObject> backRays= new List<GameObject>();
    private List<GameObject> leftRays= new List<GameObject>();
    private List<GameObject> rightRays= new List<GameObject>();
    private List<GameObject> upRays= new List<GameObject>();
    private List<GameObject> downRays= new List<GameObject>();


    void setRayTransforms()
    {
        upRays = BuildRaysUD(tUp, new Vector3(90,0,0));
        downRays = BuildRaysUD(tDown, new Vector3(270,0,180));
        leftRays = BuildRaysLR(tLeft, new Vector3(0,90,0));
        rightRays = BuildRaysLR(tRight, new Vector3(0, 270, 0));
        frontRays = BuildRaysFB(tFront, new Vector3(0,0,0));
        backRays = BuildRaysFB(tBack, new Vector3(0,180,0));
    }
    void Start()
    
    {
        setRayTransforms();
        cubeState = FindObjectOfType<CubeState>();
        cubeMap=FindObjectOfType<CubeMap>();
        

      
    }

    // Update is called once per frame
    void Update()

    {   
      //  ReadState();
       
            
    
    }
 List<GameObject> BuildRaysFB(Transform rayTransform, Vector3 direction)
  {  
    int rayCount=0;
    List  <GameObject> rays = new List<GameObject>();
    for (int y=1; y>-2; y--)
    {
        for (int x=-1; x<2; x++)
        {
            Vector3 startPos=new Vector3(rayTransform.localPosition.x+x,
                                        rayTransform.localPosition.y+y,
                                        rayTransform.localPosition.z);
           GameObject rayStart=Instantiate(emptyGO,startPos, Quaternion.identity,rayTransform);
            rayStart. name = rayCount. ToString();
            rays. Add (rayStart) ;
            rayCount++;


        }
        

    }
    rayTransform. localRotation = Quaternion. Euler(direction);
    return rays;

    }

 List<GameObject> BuildRaysLR(Transform rayTransform, Vector3 direction)
  {  
    int rayCount=0;
    List  <GameObject> rays = new List<GameObject>();
    for (int y=1; y>-2; y--)
    {
        for (int z=-1; z<2; z++)
        {
            Vector3 startPos=new Vector3(rayTransform.localPosition.x,
                                        rayTransform.localPosition.y+y,
                                        rayTransform.localPosition.z+z);
            GameObject rayStart=Instantiate(emptyGO,startPos, Quaternion.identity,rayTransform);
            rayStart. name = rayCount. ToString();
            rays. Add (rayStart) ;
            rayCount++;


        }
        

    }
    rayTransform. localRotation = Quaternion. Euler(direction);
    return rays;

    }

List<GameObject> BuildRaysUD(Transform rayTransform, Vector3 direction)
  {  
    int rayCount=0;
    List  <GameObject> rays = new List<GameObject>();
    for (int z=1; z>-2; z--)
    {
        for (int x=-1; x<2; x++)
        {
            Vector3 startPos=new Vector3(rayTransform.localPosition.x+x,
                                        rayTransform.localPosition.y,
                                        rayTransform.localPosition.z+z);
            GameObject rayStart=Instantiate(emptyGO,startPos, Quaternion.identity,rayTransform);
            rayStart. name = rayCount. ToString();
            rays. Add (rayStart) ;
            rayCount++;


        }
        

    }
    rayTransform. localRotation = Quaternion. Euler(direction);
    return rays;

    }

public List<GameObject> ReadFace(List<GameObject> RayStarts, Transform rayTransform)
    {
            List<GameObject> facesHit = new List<GameObject>();
            // Vector3 ray = tFront.transform.position;
            //RaycastHit hit;
   
            //int i=0;
            foreach (GameObject rayStart in RayStarts)
            {
                //print(rayStart.transform.position);

                //i++;
                
                    //Transform rayTransform = ;
                    Vector3 ray=rayStart.transform.position;
                    RaycastHit hit;
                    if (Physics.Raycast(ray, rayTransform.forward, out hit, Mathf.Infinity, layerMask) )
                    {
                        Debug.DrawRay(ray, rayTransform.forward * hit.distance, Color.yellow);
                        facesHit.Add (hit.collider.gameObject);
                       // print(hit.collider.gameObject.name);
                    }
                    else
                    {
                        Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
                    }
            }
        
            
            return facesHit;
            //cubeMap.Set();
    }
    public void ReadState()
    {
        cubeState=FindObjectOfType<CubeState>();
       cubeMap=FindObjectOfType<CubeMap>();
       cubeState.up=ReadFace(upRays, tUp);
   cubeState.down=ReadFace(downRays, tDown);
    cubeState.left=ReadFace(leftRays, tLeft);
       cubeState.right=ReadFace(rightRays, tRight);
     cubeState.front=ReadFace(frontRays, tFront);
       cubeState.back=ReadFace(backRays, tBack);

        cubeMap.Set();

    }

}   