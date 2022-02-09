using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    public PointCounter scoreStorage;
    bool enabled = false;
    int time = 0;
    public float value = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time > 50) enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("the speed is " + GetComponent<Rigidbody2D>().velocity.magnitude);
        //if the box is hit with anything that is not grass, destroy after (x) seconds
        if (collision.gameObject.tag != "grass" && enabled && GetComponent<Rigidbody2D>().velocity.magnitude > 1)
        {
            //destroy the box
            Destroy(gameObject, 3);
            //add to the score - get the public float "score" from ScoreStorage class, and change its value to score + however much box is worth
            scoreStorage.scoreValue += value;
            Debug.Log("the score is " + scoreStorage.scoreValue);
        }
        
        //step 2: add to the score, which is stored in another script
    }
}
