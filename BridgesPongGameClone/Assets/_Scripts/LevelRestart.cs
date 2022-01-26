using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRestart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if gameObject tagged "ball" touches the top or, call the StartOff function
        if (collision.gameObject.tag == "ball")
        {
            //get the ball physics script's startoff function from the gameObject tagged "ball"
            collision.gameObject.GetComponent<BallPhysics>().StartOff();
        }
    }
}
