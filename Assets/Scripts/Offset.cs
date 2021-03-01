using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offset : MonoBehaviour
{
    //base code created using brackeys tutorial, found here: https://www.youtube.com/watch?v=MFQhpwc6cKE
    [SerializeField] private Transform follow;
    [SerializeField] private float smoothSpeed = 0.875f;
    [SerializeField] private float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 goal = new Vector3(Mathf.Clamp(follow.position.x + offset,0,30), transform.position.y, -10);
        

        Vector3 smoothedGoal = Vector3.Lerp(transform.position, goal, smoothSpeed);
        transform.position = smoothedGoal;
    }
}
