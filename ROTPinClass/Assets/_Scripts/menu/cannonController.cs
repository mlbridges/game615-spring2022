using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonController : MonoBehaviour
{
    public Rigidbody2D piggyRigid;
    public float power = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // for give piggy a force to shoot according to mouse
        Vector3 mouseOnScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouseOnScreen);
        Vector3 direction3D = mousePosition - transform.position;

        // for calculate the angle in which cannon will rotate according to mouse
        // to get the angle between direction of mouse and that of cannon
        float dotProduct = Vector2.Dot(Vector2.right, new Vector2(direction3D.x, direction3D.y).normalized);
        // Rad2Deg -> Rad to Degree
        float angleAroundZAxis = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        if ((mousePosition.y - transform.position.y) > 0 && angleAroundZAxis >= 10 && angleAroundZAxis <= 80)
        {
            transform.rotation = Quaternion.Euler(0, 0, angleAroundZAxis);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            piggyRigid.transform.parent = null;
            piggyRigid.gravityScale = 1;
            piggyRigid.AddForce(direction3D * power);
        }
        
    }
}
