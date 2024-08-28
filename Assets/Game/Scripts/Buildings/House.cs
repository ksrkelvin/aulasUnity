using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{

    [Header("House Settings")]
    [SerializeField] private float woodNeeded;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float duration;

    [Header("House Components")]
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Transform pointer;
    [SerializeField] private GameObject houseCol;

    private bool detectingPlayer;
    private float timer;
    private Player player;
    private PlayeItems playerItems;
    private PlayerAnim playerAnim;
    private bool building;
    

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
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E)&& playerItems.currentWood >= woodNeeded)
        {
            //Inicio da construção
            building = true;
            playerAnim.OnHammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = pointer.position;
            playerItems.currentWood -= woodNeeded;
        }

        if (building)
        {
            timer += Time.deltaTime;
            if(timer >= duration)
            {
                playerAnim.OnHammeringEnd();
                houseSprite.color = endColor;
                houseCol.SetActive(true);
            }

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
