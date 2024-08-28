using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimationControl animationControl;

    private Player player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
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
    }
}
