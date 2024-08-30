using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]
    [SerializeField] private int digAmount;//Quantidade de vezes que o jogador deve cavar para plantar a cenoura
    [SerializeField] private bool detecting;
    [SerializeField] private float waterAmount;//Quantidade de agua que a cenoura precisa para crescer
    private int InitialDigAmout;
    private float currentWater;
    private bool dugHole;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip holeSFX;
    [SerializeField] private AudioClip carrotSFX;

    private bool canCollect;
    PlayeItems playerItems;

    void Awake()
    {
        playerItems = FindObjectOfType<PlayeItems>();
    }

    void Start()
    {
        InitialDigAmout = digAmount;
    }

    void Update(){

        if (dugHole)
        {
            if (detecting)
            {
                currentWater += 0.1f;
            }

            if (currentWater >= waterAmount && !canCollect)
            {

                canCollect = true;
                audioSource.PlayOneShot(holeSFX);
                spriteRenderer.sprite = carrot;

            }
            OnCollect(); 
        }
      
        
    }

    void OnHit()
    {
        digAmount--;

        if (digAmount <= InitialDigAmout /2)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;

        }

    }

    void OnCollect()
    {
        if (Input.GetKeyDown(KeyCode.E) && canCollect)
        {
            
            if (playerItems.currentCarrots < playerItems.totalCarrotLimit)
            {
                audioSource.PlayOneShot(carrotSFX);
                playerItems.GetCarrot(1);
                spriteRenderer.sprite = hole;
                currentWater = 0;
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dig") )
        {
            OnHit();
        }
        if (collision.CompareTag("Water") )
        {
            detecting = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water") )
        {
            detecting = false;
        }
    }
}
