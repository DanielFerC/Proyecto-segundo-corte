using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic2 : MonoBehaviour
{
    [SerializeField] int puntosVida;
    BoxCollider2D myCollider;
    Rigidbody2D myBody;
    Animator myAnimator;
    [SerializeField] GameObject Bala;
    [SerializeField] GameObject disparador;
    [SerializeField] GameObject disparador2;
    [SerializeField] GameObject Base;
    [SerializeField] float fireRate;
    float nextFire = 0;

    public GameObject SonidoDestruir;

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
    bool DetectarJugadorR()
    {

        RaycastHit2D colision_playerR = Physics2D.Raycast(myCollider.bounds.center,new Vector2(1,1), myCollider.bounds.extents.x * 25, LayerMask.GetMask("Player"));
        Debug.DrawRay(myCollider.bounds.center, new Vector2(1, 1) * (myCollider.bounds.extents.x * 25), Color.cyan);
        return colision_playerR.collider != null;

    }
    bool DetectarJugadorL()
    {
        RaycastHit2D colision_playerL = Physics2D.Raycast(myCollider.bounds.center, new Vector2(-1, 1), myCollider.bounds.extents.x * 25, LayerMask.GetMask("Player"));
        Debug.DrawRay(myCollider.bounds.center, new Vector2(-1, 1) * (myCollider.bounds.extents.x * 25), Color.red);
        return colision_playerL.collider != null;
    }
 public void Disparar()
    {
        if (DetectarJugadorL())
        {
            
            Debug.Log("jugador detectado");
            if (Time.time >= nextFire)
            {
                myAnimator.SetBool("Disparando",true);
                Instantiate(Bala, disparador.transform.position, disparador.transform.rotation);
                Instantiate(Bala, disparador2.transform.position, disparador2.transform.rotation);
                nextFire = Time.time + fireRate;
            }
            else
            {
                myAnimator.SetBool("Disparando", false);
            }

        }
        if (DetectarJugadorR())
        {
            
            Debug.Log("jugador detectado");
            if (Time.time >= nextFire)
            {
                myAnimator.SetBool("Disparando",true);
                Instantiate(Bala, disparador.transform.position, disparador.transform.rotation);
                Instantiate(Bala, disparador2.transform.position, disparador2.transform.rotation);
                nextFire = Time.time + fireRate;
            }
            else
            {
                myAnimator.SetBool("Disparando", false);
            }

        }
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
                Instantiate(SonidoDestruir);
            }
        }
    }
    private IEnumerator Kill()
    {
        (GameObject.Find("GameManager").GetComponent<GameManager>()).DestroyEnemy();
        yield return new WaitForSeconds(0.65f);
        Destroy(this.gameObject);
    }
}

