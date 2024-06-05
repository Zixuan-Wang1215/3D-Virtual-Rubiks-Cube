using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    float speed=1000f;
    Vector2 firstPressPos;

Vector2 secondPressPos;


Vector2 currentSwipe;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swip();
        xrotation();
        zrotation();
        yrotation();
        if (transform.rotation!=target.transform.rotation)
        {
            var step = speed * Time.deltaTime;
           transform. rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
        }
    }
    void Swip()
    {
        if (Input. GetMouseButtonDown (1))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if(Input.GetMouseButtonUp (1))
        {
        // get the 2D poition of the second mouse click
        secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //create a vector from the first an
        currentSwipe=new Vector2 (secondPressPos.x-firstPressPos.x,secondPressPos.y-firstPressPos.y);
        currentSwipe.Normalize();
        if(LeftSwipe(currentSwipe))
        {
              target.transform.Rotate(0,90,0,Space.World);
        }
        else if (RightSwipe(currentSwipe))
        {
              target.transform.Rotate(0,-90,0,Space.World);

        }
        else if (UpLeftSwipe(currentSwipe))
        {
            target. transform. Rotate(90, 0, 0, Space.World);
        }
        else if (UpRightSwipe(currentSwipe))
        {
            target. transform. Rotate(0, 0, -90, Space.World);
        }
        else if (DownLeftSwipe(currentSwipe))
        {
            target. transform. Rotate(0, 0, 90, Space.World);
        }
        else if (DownRightSwipe(currentSwipe))
        {
            target. transform. Rotate(-90, 0, 0, Space.World);
        }
         bool LeftSwipe(Vector2 swipe)
        {
            return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
        }
        bool RightSwipe(Vector2 swipe)
        {
        return currentSwipe.x >0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
        }
        bool UpLeftSwipe(Vector2 swipe)
        {
        return currentSwipe.y >0 && currentSwipe. x< 0f;
        }
        bool UpRightSwipe(Vector2 swipe)
        {
        return currentSwipe.y >0 && currentSwipe. x> 0f;
        }
        bool DownLeftSwipe(Vector2 swipe)
        {
        return currentSwipe.y <0 && currentSwipe. x< 0f;
        }
        bool DownRightSwipe(Vector2 swipe)
        {
        return currentSwipe.y <0 && currentSwipe. x>0f;
        }
        }
    }
   


     void xrotation()
    {
        if (Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.Y))
        {
            
            target.transform.Rotate(90,0,0,Space.World);
        }
        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.N))
        {
            
            target.transform.Rotate(-90,0,0,Space.World);
        }
        
    }
     void zrotation()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            target.transform.Rotate(0,0,-90,Space.World);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            target.transform.Rotate(0,0,90,Space.World);
        }
        
    }
     void yrotation()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
            target.transform.Rotate(0,90,0,Space.World);
        }
        if (Input.GetKeyDown((KeyCode)59))
        {
            
            target.transform.Rotate(0,-90,0,Space.World);
        }
        
    }
}
