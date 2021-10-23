using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaman : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpforce;
    [SerializeField] float fallingThreshold;
    [SerializeField] GameObject disparador;
    [SerializeField] GameObject bala;
    [SerializeField] float fireRate;

    float nextFire = 0;
    Animator myAnimator;
    Rigidbody2D myBody;
    BoxCollider2D myCollider;

    bool IndicadorCaer;
    bool doblesanto = true;
    bool Saltando=false;
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
        Saltar();
        Correr();
        Caer();
        shoot();
    }
    void terminarDeSaltar()
    {
        myAnimator.SetBool("IsFalling", true);
    }
    void Saltar()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myBody.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                myAnimator.SetTrigger("Jump");
                Saltando = true;
              
            }
               
            doblesanto = true;
        }
       
        else 
        {
            if (Input.GetKeyDown(KeyCode.Space) && doblesanto == true && IndicadorCaer == true && Saltando == true)
            {
                myBody.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                myAnimator.SetTrigger("Jump");
                doblesanto = false;

            }
        }

        

    }
    void Correr()
    {
        
        float movH = Input.GetAxis("Horizontal");

        Vector2 movimiento = new Vector2(movH * speed * Time.deltaTime, 0);
        transform.Translate(movimiento);

        if (movH != 0)
        {
            myAnimator.SetBool("IsRunning", true);
            if (movH < 0)
                transform.localScale = new Vector2(-1, 1);
            else
                transform.localScale = new Vector2(1, 1);

        }
        else
        {
            myAnimator.SetBool("IsRunning", false);
        }
    }
    void Caer()
    {
        myBody = GetComponent<Rigidbody2D>();
        if (myBody.velocity.y < fallingThreshold)
        {
            myAnimator.SetBool("IsFalling", true);
            IndicadorCaer = true;
        }
        else
        {
            myAnimator.SetBool("IsFalling", false);
            IndicadorCaer = false;
        }

    }
    void shoot()
    {
        if (Input.GetKey(KeyCode.X))
        {
            myAnimator.SetLayerWeight(1, 1);
            
        }
        else
            myAnimator.SetLayerWeight(1, 0);

        if (Input.GetKey(KeyCode.X) && Time.time >= nextFire)
        {
            Instantiate(bala, disparador.transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
