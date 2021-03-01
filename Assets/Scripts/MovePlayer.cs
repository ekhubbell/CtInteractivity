using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A)))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (transform.position.y<1.18f&& (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (transform.position.y > -3.2f && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
    private void LateUpdate()
    {
        if(transform.position.x<=-11)
        {
            transform.position = new Vector3(40.9f, transform.position.y, transform.position.z);
        }
        else if(transform.position.x>=41 )
        {
            transform.position = new Vector3(-10.9f, transform.position.y, transform.position.z);
        }
    }
}
