using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Tree : MonoBehaviour
{

    [SerializeField] private int treeHealth;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject woodPrefeb;
    [SerializeField] private int maxWood;

    [SerializeField] private ParticleSystem leafs;
    private bool isCut;

    void OnHit()
    {
        treeHealth--;

        anim.SetTrigger("isHit");
        if (treeHealth <= 0)
        {
            //Cria o tronco e instancia os drops 
            anim.SetTrigger("cut");

            for (int i = 0; i < Random.Range(0,maxWood); i++){
                Instantiate(woodPrefeb, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), transform.rotation);
            }
            isCut = true;
            

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe") && !isCut)
        {
            leafs.Play();
            OnHit();
        }
    }
}
