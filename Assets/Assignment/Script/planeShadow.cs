using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeShadow : MonoBehaviour
{
    public AnimationCurve planeCurve;
    public Transform StartPos;
    public Transform EndPos;
    public float interpolation;
    public float planeTime;

     void Update()
    {
        interpolation = planeCurve.Evaluate(planeTime);  // defining the interpolation
        planeTime = planeTime + Time.deltaTime;  //  defining the plane to move
        transform.position = Vector3.Lerp(StartPos.position, EndPos.position, interpolation);  // where the plane starts, where it ends, and how long it takes
        
    }


}
