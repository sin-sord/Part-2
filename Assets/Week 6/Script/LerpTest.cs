using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public Transform startPosition;
    public Transform endPosition;
    public float lerpTimer;
    public float interpolation;
    public Color cola;
    public Color colb;
    public SpriteRenderer sr;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interpolation = animationCurve.Evaluate(lerpTimer);  // Defining that interpolation is the animation curve and help define the time it takes
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, interpolation);  // Vecotr3 is saying: start at the startPosition and go to endPosition and have the timer is 0.
        lerpTimer = lerpTimer + Time.deltaTime;  // lerp time
        sr.color = Color.Lerp(cola, colb, interpolation);  // changes the color of the GameObject as it moves.
    }
}
