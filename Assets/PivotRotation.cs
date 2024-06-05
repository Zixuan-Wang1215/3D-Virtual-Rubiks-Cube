using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotRotation : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> activeSide;
    private Vector3 localForward; 
    private Vector3 mouseRef;
    private bool dragging=false;
    private ReadCube readCube;
    private CubeState cubeState;
    private float sensitivity=0.4f;
    private Vector3 rotation;
    private bool autoRotating= false;
    private float speed =300f;

    private Quaternion targetQuaternion;
// Start is called before the first fram
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
          SpinSide(activeSide);
          if(Input.GetMouseButtonUp(0))
          {
            dragging=false;
            RotatetoRightAngle();

          }
        }
        if (autoRotating)
        {
          AutoRotate();
        }
    }
    public void Rotate(List<GameObject> side )
    {
      activeSide=side;
      mouseRef=Input.mousePosition;
      dragging=true;
      localForward=Vector3.zero-side[4].transform.parent.transform.localPosition;

    }
    private void SpinSide(List<GameObject> side)
    {

      rotation = Vector3.zero;
      Vector3 mouseOffset = (Input.mousePosition - mouseRef);
      if (side == cubeState.front)

      {

        rotation. z = (mouseOffset.x + mouseOffset.y) * sensitivity * -1;

      }
      if (side == cubeState.back)

      {

        rotation. z = (mouseOffset.x + mouseOffset.y) * sensitivity * 1;

      }
       if (side == cubeState.up)

      {

        rotation. y = (mouseOffset.x + mouseOffset.y) * sensitivity * 1;

      }
       if (side == cubeState.down)

      {

        rotation. y = (mouseOffset.x + mouseOffset.y) * sensitivity * -1;

      }
       if (side == cubeState.left)

      {

        rotation. x = (mouseOffset.x + mouseOffset.y) * sensitivity * -1;

      }
       if (side == cubeState.right)

      {

        rotation. x= (mouseOffset.x + mouseOffset.y) * sensitivity * 1;

      }
      transform.Rotate(rotation,Space.Self);
      mouseRef=Input.mousePosition;
    }
   public void RotatetoRightAngle()
{
    Vector3 vec = transform.localEulerAngles;
    vec.x = Mathf.Round(vec.x / 90) * 90;
    vec.y = Mathf.Round(vec.y / 90) * 90;
    vec.z = Mathf.Round(vec.z / 90) * 90;

    targetQuaternion.eulerAngles = vec;
    autoRotating = true;
}
    private void AutoRotate()
    {
      dragging = false;
      var step = speed * Time.deltaTime;
      transform. localRotation = Quaternion.RotateTowards(transform. localRotation, targetQuaternion, step);
      if (Quaternion. Angle(transform. localRotation, targetQuaternion) <= 1)
      {
        transform. localRotation = targetQuaternion;
        // unparent the little cubes
        cubeState.PutDown(activeSide, transform.parent);
        readCube. ReadState();

        autoRotating = false;
        dragging = false;
      }
    }
}
