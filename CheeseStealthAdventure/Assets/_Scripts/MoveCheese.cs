using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCheese : MonoBehaviour
{
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W)) 
        {
            gameObject.transform.forward = new Vector3(1,0,0);
        }
    }
}
