using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class CheeseCollection : MonoBehaviour
{
    public PlayerStats scoreStorage;
    public int winCount = 10;

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
        //on collision, needs to destroy item cheese + add point to point total
        if (collision.gameObject.tag == "Player")
        {
            //adds to the score
            if (transform.tag == "cheese")
            {
                scoreStorage.PlayerCollectibles += 1;
            }

            //adds cheese to cheese dictionary
            //make a new list
            List<Transform> list;

            //call up dictionary from repository script
            Repository.repositoryDictionary.TryGetValue(transform.tag, out list);

            //if there is no list, then make one
            if(list == null)
            {
                list = new List<Transform>();
            }

            //add the wood to the list
            list.Add(transform);

            //adds the list to the repository dictionary
            Repository.repositoryDictionary.Remove(transform.tag);
            Repository.repositoryDictionary.Add(transform.tag, list);

            //make the cheese follow the player
            Vector3 itemPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            itemPosition = collision.gameObject.transform.position - (list.Count * collision.gameObject.transform.forward);
            transform.position = itemPosition;

            //turn off cheese baby rigidbody
            Destroy(gameObject.GetComponent<Rigidbody>());
            //gameObject.GetComponent<Rigidbody>();
            //rigidbody.detectionCollision = false;

            //now that we have collected cheese, ethically, we must adopt cheese
            transform.parent = collision.transform;

            //send to cheese void
            //enabled = false;


            Debug.Log("The score is " + scoreStorage.PlayerCollectibles);

            //win if all cheese collected
            if (scoreStorage.PlayerCollectibles == winCount)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(7);
            }
        }
    }
}
