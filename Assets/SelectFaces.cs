using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFaces : MonoBehaviour
{
   
    // Start is called before the first frame update
     public Transform tUp; 
    public Transform tDown; 
    public Transform tLeft; 
    public Transform tRight; 
    public Transform tFront; 

    public Transform tBack; 
    /*
     private GameObject frontRays;   
      private GameObject backRays
    private GameObject leftRays;
    private GameObject rightRays;
    private GameObject upRays;
    private GameObject downRays;*/

    private int layerMask = 1<<8;
    CubeState cubeState;
    ReadCube readCube;
    //public bool clicked=false;
 //   CubeState cubeState;
  //  CubeMap cubeMap;
     void Start()
    
    {
        

        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
        /*
        tUp. localRotation = Quaternion. Euler(new Vector3(90,0,0));
        tDown. localRotation = Quaternion. Euler(new Vector3(270,0,0));
        tLeft. localRotation = Quaternion. Euler(new Vector3(0,90,0));
        tRight. localRotation = Quaternion. Euler(new Vector3(0, 270, 0));
        tFront. localRotation = Quaternion. Euler(new Vector3(0,0,0));
        tBack. localRotation = Quaternion. Euler(new Vector3(0,180,0));
        */
    }

    // Update is called once per frame
    void Update()

    {
        if ((Input.GetMouseButtonDown (0)))
        {
            readCube.ReadState();
            RaycastHit hit;
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                print(1);
                GameObject face=hit.collider.gameObject;
                 List<List<GameObject>> cubeSides = new List<List<GameObject>>()
                {

                    cubeState.up,
                    cubeState.down,
                    cubeState.left,
                    cubeState.right,
                    cubeState.front, 
                    cubeState.back
                };
                 foreach (List<GameObject> cubeSide in cubeSides)
                {
                    if (cubeSide.Contains (face))
                    {
                        //print(blockHit.name);
                        cubeState.PickUp(cubeSide);
                        
                    }

                }
            }
        }
      
    
    }
}

  /*
        //print(2);
        if (Input.GetKeyDown(KeyCode.H))
        {
            clicked=true;
        ReadBlock(tFront);

        }
        if (Input.GetKeyDown(KeyCode.G))


        {
            clicked=true;
        ReadBlock(tFront);

        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            ReadBlock(tUp);

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ReadBlock(tUp);

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ReadBlock(tBack);

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ReadBlock(tBack);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ReadBlock(tLeft);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ReadBlock(tLeft);

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
           // print(1);
            ReadBlock(tRight);

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ReadBlock(tRight);

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ReadBlock(tDown);

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ReadBlock(tDown);

        }*/
        
        
     
   // }
    
   // public void ReadBlock(Transform rayTransform)
  //  {   
        /*
        readCube.ReadState();
        

         Vector3 ray = rayTransform.transform.position;
        RaycastHit hit;
        GameObject blockHit=new GameObject();
       // print(1);
        if (Physics.Raycast(ray, rayTransform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(ray, rayTransform.forward * hit.distance, Color.yellow);
            blockHit=hit.collider.gameObject;
           // print(hit.collider.gameObject.name);


        }
        List<List<GameObject>> cubeSides = new List<List<GameObject>>()
        {

            cubeState.up,
            cubeState.down,
            cubeState.left,
            cubeState.right,
            cubeState.front, 
            cubeState.back
        };
        foreach (List<GameObject> cubeSide in cubeSides)
        {
            if (cubeSide.Contains (blockHit))
            {
                //print(blockHit.name);
                cubeState.PickUp(cubeSide);
                
            }
        }
        

    }*/