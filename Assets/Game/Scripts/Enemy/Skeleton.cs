using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{

    [Header("Skeleton Settings")]
    public float Health;
    public float CurrentHealth;
    public Image healthBar;
    public bool isDead;

    [Header("Skeleton Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimationControl animationControl;
    
    private Player player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        CurrentHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            agent.SetDestination(player.transform.position);

            if (Vector2.Distance(transform.position, player.transform.position) < agent.stoppingDistance)
            {
                //skeleton para para atacar
                animationControl.PlayAnim(2);
            }
            else{
                //skeleton anda
                animationControl.PlayAnim(1);

            }

            float posx = player.transform.position.x - transform.position.x;

            if (posx>0)
            {
                transform.eulerAngles = new Vector2(0,  0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
    }
}
