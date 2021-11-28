using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] CircleCollider2D Detector;
    [SerializeField] GameObject Megaman;
    [SerializeField] int puntosVida;

    public GameObject SonidoDestrucción;

    Animator myAnimator;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
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
            
            
        }
        else
        {
           

        }
        

    }

    private void OnDrawGizmos()
    {
        // forma 2 //Gizmos.DrawLine(transform.position, player.transform.position);
        Gizmos.DrawWireSphere(transform.position, 10);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Disparo"))
        {
            puntosVida--;
            if (puntosVida == 0)
            {
                Debug.Log("se murio");
                myAnimator.SetTrigger("Moricion");

                StartCoroutine(Kill());

            }
        }
    }
    private IEnumerator Kill()
    {
        (GameObject.Find("GameManager").GetComponent<GameManager>()).DestroyEnemy();
        yield return new WaitForSeconds(0.65f);
        Destroy(this.gameObject);
        Instantiate(SonidoDestrucción);
    }

}
