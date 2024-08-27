using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
   
    [SerializeField] private bool detectingPlayer;
    [SerializeField] private int percentage;
    [SerializeField] private Object fishPrefeb;

    private PlayeItems playerItems;
    private Player player;
    private PlayerAnim playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        playerItems = player.GetComponent<PlayeItems>();
        playerAnim = player.GetComponent<PlayerAnim>();

    }

    // Update is called once per frame
    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnCastingStarted();
        }
    }

    public void OnCasting()
    {
        int randomValue = Random.Range(0, 100);

        if (randomValue <= percentage)
        {
            // player.GetFish(fishValue);
            Instantiate(fishPrefeb, player.transform.position +new Vector3(Random.Range(-2,2),1,0), Quaternion.identity);
        }
        else
        {
            Debug.Log("No fish");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            detectingPlayer = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            detectingPlayer = false;
        }
    }
}
