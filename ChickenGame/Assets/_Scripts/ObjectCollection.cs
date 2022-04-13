using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for object collection, attached to gems which the player collects
public class ObjectCollection : MonoBehaviour
{
    //creating an event handler for the inventory dictionary to subscribe to
    //the dictionary will receive the tags of the collectables, which it uses to name the keys in the dictionary
    public delegate void Placeholder(string _tag);
    public static event Placeholder OnPlayerColl;

    public CharacterController playerController;

    //value to be used if we want to move or hide the objects instead of destroying them
    //int y = -100;
    private void OnCollisionEnter(Collision collision)
    {
        //checking to see what collided with the collectable
        if (collision.gameObject == playerController)
        {
            //Debug.Log("this happened");

            //sending the message out to the dictionary
            OnPlayerColl?.Invoke(gameObject.tag);

            //keeping this line in case we want to hide the objects instead of destroying them
            //transform.position = new Vector3(0, y, 0);

            //destroying the objects on collection
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}