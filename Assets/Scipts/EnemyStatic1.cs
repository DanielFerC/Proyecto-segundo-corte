using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic1 : MonoBehaviour
{
    [SerializeField] int puntosVida;
    BoxCollider2D myCollider;
    Rigidbody2D myBody;
    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Disparar();
    }
    bool DetectarJugador()
    {
        
        RaycastHit2D colision_player = Physics2D.Raycast(myCollider.bounds.center,Vector2.left,myCollider.bounds.extents.x*25,LayerMask.GetMask("Player"));

        Debug.DrawRay(myCollider.bounds.center,Vector2.left * (myCollider.bounds.extents.x * 25), Color.cyan);
        return colision_player.collider !=null;
        
    }
    public void Disparar()
    {
        if (DetectarJugador())
        {
            Debug.Log("jugador detectado");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Disparo"))
        {
            puntosVida--;
            if (puntosVida <= 0)
            {
                (GameObject.Find("GameManager").GetComponent<GameManager>()).DestroyEnemy();
                Destroy(this.gameObject);
            }
        }
    }
}
