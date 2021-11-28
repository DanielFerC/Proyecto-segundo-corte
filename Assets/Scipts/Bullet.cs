using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    BoxCollider2D myCollider;
    [SerializeField] int puntosDano;
    [SerializeField] float tiempo;
    private Rigidbody2D MiRigidbody;
    Animator myAnimator;
    public float speed;
    float tiempoExplosion;
    bool choque;
    

    // Start is called before the first frame update
    void Start()
    {
        MiRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        MiRigidbody.velocity = transform.right * speed;
        choque = false;

        /*
        if (Time.time >= tiempoExplosion && choque == true)
        {
            Destroy(this.gameObject);
            choque = false;
            myAnimator.SetBool("Explosion", false);
        }
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myAnimator.SetBool("Explosion", true);
            MiRigidbody.velocity = transform.right * 0;
            tiempoExplosion = Time.time + tiempo;
        }
        */
    }
    public int darPuntosDano()
    {
        return puntosDano;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        choque = true;
        GameObject objeto = collision.gameObject;
        string etiqueta = objeto.tag;
        
        myAnimator.SetTrigger("Explosion");
        StartCoroutine(KillOnAnimationEnd());


    }
    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(0.167f);
        Destroy(this.gameObject);
    }
}
