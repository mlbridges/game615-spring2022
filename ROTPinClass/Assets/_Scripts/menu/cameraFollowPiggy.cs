using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPiggy : MonoBehaviour
{
    public Transform piggie;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 17.5 && transform.position.x > -13.4)
        {
            Vector3 newPositionOfCamera = new Vector3(piggie.position.x, transform.position.y, transform.position.z);
            // make the move of camera looks smooth
            // not go to the target position immediately, but reach there after little delay
            // Time.deltaTime can be modified according to the exact speed of moving camera
            // Vector3.Lerp(startPosition, endPosition, speedOfMoving)
            transform.position = Vector3.Lerp(transform.position, newPositionOfCamera, Time.deltaTime * 3f);
        }
    }
}
