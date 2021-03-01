using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    [SerializeField] private Transform cam;
    private bool shaking = false;
    private bool colliding = false;
    private GameObject painting;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!colliding && collision.gameObject.name.Equals("painting"))
        {
            painting = collision.gameObject;
            colliding = true;
            StartCoroutine(shake(Vector3.Distance(transform.position, painting.transform.position)));
            //Debug.Log(cam.localEulerAngles + ", " + cam.eulerAngles);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        colliding = false;
    }

    private void Update()
    {
        if (colliding && !shaking)
        {
            StartCoroutine(shake(Vector3.Distance(transform.position, painting.transform.position)));
        }
    }


    IEnumerator shake(float distance)
    {
        shaking = true;
        float shakeSpeed = 1.5f*distance/(1.5f*distance+1);
        float timeElapsed = 0f;

        float startZ = cam.eulerAngles.z;
        //float dif = 0;
       // Debug.Log(1);
        while(timeElapsed < shakeSpeed)
        {
            float endZ;
            float t;
            if (timeElapsed < shakeSpeed * .25f)
            {
                endZ = 3;
                Debug.Log(1);
                t = timeElapsed / (shakeSpeed * .25f);
            }
            else if(timeElapsed < shakeSpeed * .5f)
            {
                startZ = 3;
                endZ = 0;
                Debug.Log(2);
                t = (timeElapsed-(shakeSpeed*.25f)) / (shakeSpeed * .25f);
            }
            else if (timeElapsed < shakeSpeed * .75f)
            {
                startZ = 0;
                endZ = -3;
                t = (timeElapsed - (shakeSpeed * .5f)) / (shakeSpeed * .25f);
                Debug.Log(3);
            }
            else
            {
                startZ = -3;
                endZ = 0;
                t = (timeElapsed - (shakeSpeed * .75f)) / (shakeSpeed * .25f);
                Debug.Log(4);
            }
            changeAngle(startZ, endZ, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        cam.eulerAngles = Vector3.zero;

        shaking = false;
    }

    void changeAngle(float startAngle, float endAngle, float t)
    {
        Debug.Log(t);
        Vector3 rotation = new Vector3(0, 0, Mathf.LerpAngle(startAngle, endAngle, t));

        //Debug.Log(rotation);
        cam.eulerAngles = rotation;
    }
}
