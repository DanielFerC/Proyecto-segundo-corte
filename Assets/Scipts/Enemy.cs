using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] CircleCollider2D Detector;
    [SerializeField] GameObject Megaman;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
         /*if(Detector.IsTouchingLayers(LayerMask.GetMask("player")))
         {
             Debug.Log("Follow player");
         }
         else 
         {
             Debug.Log("Unfollow Player");
         }
         */
        /* forma 2
         * if (Vector2.Distance(transform.position, player.transform.position)  < 10) 
        {
             Debug.Log("Follow player");
        }
         else 
         {
             Debug.Log("Unfollow Player");
         }*/

        Collider2D chocando = Physics2D.OverlapCircle(transform.position, 3, LayerMask.GetMask("Player"));

        if (chocando != null)
        {
            Debug.Log("Follow player");
        }
        else
        {
            Debug.Log("Unfollow Player");

        }
        

    }

    private void OnDrawGizmos()
    {
        // forma 2 //Gizmos.DrawLine(transform.position, player.transform.position);
        Gizmos.DrawWireSphere(transform.position, 10);
    }

}
