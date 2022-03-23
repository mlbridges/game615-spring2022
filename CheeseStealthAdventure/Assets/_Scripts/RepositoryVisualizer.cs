using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepositoryVisualizer : MonoBehaviour
{
    public Sprite currentSprite;
    public Sprite defaultSprite;
    public Sprite cheeseSprite;
    public Sprite burgerSprite;
    Image[] images;

    public GameObject inventoryPrefab;

    //public void Awake()
    //{
    //    //step 1: make list of images from number of images in elements group
    //    images = gameObject.GetComponentsInChildren<Image>();
    //    Debug.Log(images.Length);

    //    //step 2: hide images from UI until we need them
    //    foreach (Image im in images)
    //    {
    //        im.gameObject.SetActive(false);
    //    }
    //}

    public void UpdateRepository()
    {
        //step 3: make an int which tells us which cheese/burger we are on and put it in corresponding box
        int i = 0;
        currentSprite = defaultSprite;

        //looking through the dictionary, seeing what kind of element it is and assigning it correct sprite
        //need to figure out if there is already an image for the element so there are no doubles
        foreach(string key in Repository.repositoryDictionary.Keys)
        {
            //this instantiate function removes the need for the image list in start function
            GameObject inventoryElement = GameObject.FindGameObjectWithTag(key);

            if(inventoryElement == null)
            {
                inventoryElement = Instantiate(inventoryPrefab, gameObject.transform);
                inventoryElement.tag = key;
                //inventoryElement.transform.SetParent(gameObject.transform, false);
            }

            //assign sprite to key
            switch (key)
            {
                case "cheese": currentSprite = cheeseSprite; break;
                case "burger": currentSprite = burgerSprite; break;
                default: currentSprite = defaultSprite; break;
            }
            //if (key == "cheese") currentSprite = cheeseSprite;
            //if (key == "burger") currentSprite = burgerSprite;

            //whatever kind of sprite it is, make that the current sprite
            Debug.Log(inventoryElement);
            inventoryElement.GetComponent<Image>().sprite = currentSprite;
            //make it active so we can see it
            //images[i].gameObject.SetActive(true);

            //make a new temporary list to get the text out of the keys we found
            List<Transform> list;
            //get the list out of the repository
            Repository.repositoryDictionary.TryGetValue(key, out list);
            //change the text representing the number of elements
            inventoryElement.GetComponentInChildren<Text>().text = list.Count.ToString();
            //increase index of images
            //i++;
        }
    }

    public void Update()
    {
        UpdateRepository();
    }
}
