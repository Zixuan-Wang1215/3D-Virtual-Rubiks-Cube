using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{
    // Start is called before the first frame update
    CubeState cubeState;
    public Transform up;

public Transform down;

public Transform left;

public Transform right;

public Transform front;

public Transform back;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    public void Set()

    {
    cubeState = FindObjectOfType<CubeState>();
    UpdateMap(cubeState.front, front);
    
    UpdateMap(cubeState.back, back);
    UpdateMap(cubeState.left, left);
    UpdateMap(cubeState.right, right);
    UpdateMap(cubeState.up, up);
    UpdateMap(cubeState.down, down);
    

    }

    void UpdateMap(List<GameObject> face, Transform side)
    {
        int i = 0;
        
        foreach (Transform map in side)

        {
        //    print(face[0].name);
            if (face[i].name [0] == 'f'   )
            {
               // print(1);
                map.GetComponent<Image>().color = new Color (0,0,1,1);

            }
           
            if (face[i].name [0] == 'b')
            {
                map.GetComponent<Image>().color = new Color (0,1,0,1);

            }
            if (face[i].name [0] == 'l')
            {
                map.GetComponent<Image>().color = new Color (1,0.64f, 0,1);

            }
            if (face[i].name [0] == 'r')
            {
                map.GetComponent<Image>().color = new Color (1,0,0,1);

            }
            if (face[i].name [0] == 'd')
            {
                map.GetComponent<Image>().color = new Color (1,1,1,1);

            }
            if (face[i].name [0] == 'u')
            {
                map.GetComponent<Image>().color = new Color (1,1,0,1);

            }
           
            i++;  
        }
    }
}
