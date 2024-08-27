using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public float speed;
    private int index;
    public List<Transform> paths = new List<Transform>();

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(!DialogueControl.instance.isShowing)
        {
            anim.SetBool("isWalking", true);
            Movement();
            
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }


    void Movement()
    {
        
            transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, paths[index].position) < 0.1f)
            {
                if (index < paths.Count - 1)
                {
                     index = Random.Range(0, paths.Count - 1);// Valores aletaoris para o NPC andar
                }
                else
                {
                    index = 0;
                }
            }

            Vector2 direction = paths[index].position - transform.position;
            if (direction.x > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
                
            }
        }
    
    
}
