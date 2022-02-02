using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPiggy : MonoBehaviour
{
    public Transform piggy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 34)
        {
            //move the camera all the time with the piggy, but keep the camera's original y and z position
            Vector3 newPositionOfCamera = new Vector3(piggy.position.x, transform.position.y, transform.position.z);

            //use lerp to make the change in position smoother - camera follows on a delay
            //time.deltatime means we're going to get to the new position within a second
            transform.position = Vector3.Lerp(transform.position, newPositionOfCamera, Time.deltaTime * 3f);
        }
    }
}
