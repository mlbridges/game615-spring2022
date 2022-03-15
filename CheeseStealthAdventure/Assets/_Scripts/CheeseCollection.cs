using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            scoreStorage.PlayerCollectibles += 1;
            Destroy(gameObject);
            Debug.Log("The score is " + scoreStorage.PlayerCollectibles);
            if (scoreStorage.PlayerCollectibles == winCount)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(7);
            }
        }
    }
}
