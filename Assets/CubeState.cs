using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeState : MonoBehaviour
{
    // These variables record the colors on each faces
    public List<GameObject> front = new List<GameObject>();
    public List<GameObject> back = new List<GameObject>();
    public List<GameObject> up = new List<GameObject>();
    public List<GameObject> down = new List<GameObject>();
    public List<GameObject> left = new List<GameObject>();
    public List<GameObject> right = new List<GameObject>();
    

    public void PickUp(List<GameObject> cubeSide)
    {
       
        foreach (GameObject face in cubeSide)
        {
           
            if (face != cubeSide[4])
            {
            face. transform.parent.transform.parent = cubeSide[4].transform.parent;
            }
        }
      cubeSide[4].transform.parent.GetComponent<PivotRotation>().Rotate(cubeSide);
    }
    public void PutDown (List<GameObject > littleCubes, Transform pivot)
    {
        foreach (GameObject littleCube in littleCubes)
        {
            if (littleCube != littleCubes [4])
            {
                littleCube.transform.parent.transform.parent = pivot;
            }
        }
    }

  //  void RotateSide(List<GameObject> side)
   // {
   //     side.transform.Rotate(0,90,0);
   // }

    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
       
    }
}
