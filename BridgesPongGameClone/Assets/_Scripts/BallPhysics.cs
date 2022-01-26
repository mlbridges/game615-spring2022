using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartOff()
    {
        //defining/storing variables for easier reference
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        //this controls where / how hard it goes
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-5f, 5f);
        Vector3 forceVector = new Vector3(x, y, 0);

        //at start, give the ball a push in a random downward direction
        rigidbody.AddForce(forceVector.normalized * speed);
        rigidbody.transform.position = new Vector3(0, 1, 0);
    }
}
