using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    private PlayeItems playerItems;

    void Awake()
    {
        playerItems = FindObjectOfType<PlayeItems>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerItems.currentFishes < playerItems.totalFishLimit)
            {
                playerItems.GetFish(1);
                Destroy(gameObject);
            }
            
        }
    }
}
