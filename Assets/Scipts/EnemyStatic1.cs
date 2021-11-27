using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic1 : MonoBehaviour
{
    [SerializeField] int puntosVida;
    BoxCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool DetectarJugador()
    {
        //return myCollider.IsTouchingLayers(LayerMask.GetMask("Player"));
        RaycastHit2D colision_player = Physics2D.Raycast(myCollider.bounds.center,Vector2.left,myCollider.bounds.extents.x*10,LayerMask.GetMask("Player"));

        Debug.DrawRay(myCollider.bounds.center, Vector2.left, Color.green);
        return colision_player.collider !=null;
        /*
        RaycastHit2D colision_suelo = Physics2D.Raycast(myCollider.bounds.center, Vector2.down, myCollider.bounds.extents.y + 0.1f, LayerMask.GetMask("Ground"));
        //Debug.Log("Colisionando con piso?" + colision_suelo.collider != null);
        Debug.DrawRay(myCollider.bounds.center,Vector2.down * (myCollider.bounds.extents.y + 0.1f), Color.cyan);
        return colision_suelo.collider != null;
        */
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
