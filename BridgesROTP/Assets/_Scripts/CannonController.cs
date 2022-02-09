using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Rigidbody2D piggyRigid;
    public float power = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //note: we are doing this every frame so the cannon will rotate with mouse position
        //if it were just getting mouse pos for firing direction we would put it in the if statement!

        //step 1: calculation of position of mouse on screen
        Vector3 mouseOnScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);

        //step 2: this calculation translates the mouse position into the world
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(mouseOnScreen);

        //step 3: now that we have mouse position in world we can find the vector between mouse and cannon
        Vector2 directionIn3D = Input.mousePosition - transform.position;

        //to find angle to rotate cannon:
        //Mathf will let you do math calculations - arccos (acos) will give you angle of rotation
        //vector2.dot will get you the dot product of vector2 angle, is cos of angle between 2 vectors
        //make sure you normalize your vectors!
        float dotProduct = Vector2.Dot(Vector2.right, new Vector2(directionIn3D.x, directionIn3D.y).normalized);

        //then find the arccos of the dotProduct, which is what we need for the actual game
        //also, stupidly, you need to turn it from radians to degrees with Mathf
        float angleAroundZAxis = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        //actual cannon rotation:
        if (Input.mousePosition.y - transform.position.y > 0 && angleAroundZAxis < 80 && angleAroundZAxis > 10)
        {
            transform.rotation = Quaternion.Euler(0, 0, angleAroundZAxis);
        }
    
        //if fired, shoot the piggy
        if (Input.GetButtonDown("Fire1"))
        {
            //de-parent the piggy from the cannon
            piggyRigid.transform.parent = null;
            //at the moment of shooting, enable piggy gravity
            piggyRigid.gravityScale = 1;
            //find the piggy, get its rigidbody, and apply force
            piggyRigid.AddForce(directionIn3D * power);
        }
    }
}
