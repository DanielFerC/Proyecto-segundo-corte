using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaman : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpforce;
    [SerializeField] float fallingThreshold;
    [SerializeField] GameObject disparador;
    [SerializeField] float fireRate;
    [SerializeField] float DashForce;
    [SerializeField] GameObject Bala;
    public Rigidbody2D MiRigidbody;
    float nextFire = 0;
    Animator myAnimator;
    Rigidbody2D myBody;
    BoxCollider2D myCollider;
    int EstadoDash;

    public bool moveRight;
    public bool moveLeft;
    bool IndicadorCaer;
    bool doblesanto = true;
    bool Saltando=false;
    bool HaberSaltado=false;
    bool HaciendoDash=false;
    float LayerTimer;
    [SerializeField] float Delay;
    [SerializeField] float tiempoDash;
    float contador;
    int casosSalto;
    
    public Vector2 GuardarVelocidad;
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
        Dash();
    }
    void Dash()
    {
        float movH = Input.GetAxis("Horizontal");
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && IndicadorCaer == false)
        {
            if(Time.time >= (contador-1))
            {
                Saltando = true;
                HaciendoDash = false;
                myAnimator.SetBool("Dash", false);
            }
            

            if (Input.GetKeyDown(KeyCode.X) && Time.time >= contador)
            {
                
                if (moveLeft)
                {
                    myBody.AddForce(new Vector2(DashForce, 0), ForceMode2D.Impulse);
                    Saltando = false;
                    HaciendoDash = true;
                    
                    myAnimator.SetBool("Dash",true);

                }
                else if (moveRight)
                {
                    myBody.AddForce(new Vector2(-DashForce, 0), ForceMode2D.Impulse);
                    Saltando = false;
                    HaciendoDash = true;
                    
                    myAnimator.SetBool("Dash", true);
                }
                   


                contador = Time.time + tiempoDash;

                
            }

        }
        
        /*
        switch (EstadoDash)
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.X))
                {
                    myBody.AddForce(new Vector2(DashForce, 0), ForceMode2D.Impulse);
                }

                    break;
            case 2:

                break;
            case 3:

                break;
        }
        */

    }
    void terminarDeSaltar()
    {
        myAnimator.SetBool("IsFalling", true);
    }
    void EmpiezaASaltar()
    {

    }
    void Saltar()
    {
        /*
        switch (casosSalto)
        {
            case 1:
                if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
                {

                    if (Input.GetKeyDown(KeyCode.Space) && Saltando == true)
                    {
                        myBody.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                        myAnimator.SetTrigger("Jump");
                        HaberSaltado = true;

                    }






                    doblesanto = true;
                }
                else
                {
                    casosSalto = 2;
                }

                break;
            case 2:


                break;
            case 3:

                break;
        


    }
    */

        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            
            if (Input.GetKeyDown(KeyCode.Space) && Saltando==true)
            {
                myBody.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                myAnimator.SetTrigger("Jump");
                HaberSaltado = true;
              
            }
            
           

            
               
            
            doblesanto = true;
        }
        else 
        {

            

            if (Input.GetKeyDown(KeyCode.Space) && doblesanto == true && IndicadorCaer == true && Saltando==true)
            {
                
                myBody.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                myAnimator.SetTrigger("Jump");
                doblesanto = false;
                
            }
        }


        

    }
    void Correr()
    {
        if (HaciendoDash==false)
        {
            float movH = Input.GetAxis("Horizontal");
 
            //PERSONAJE MIRANDO A LA DERECHA
            if (movH > 0.1f)
            {
                Vector2 movimiento = new Vector2(movH * Time.deltaTime * speed, 0);
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.Translate(movimiento);
                moveLeft = true;
                moveRight = false;
                myAnimator.SetBool("IsRunning", true);
            }

            //PERSONAJE MIRANDO A LA IZQUIERDA
            if (movH < -0.1f)
            {
                Vector2 movimiento = new Vector2(-movH * Time.deltaTime * speed, 0);
                transform.eulerAngles = new Vector3(0, 180, 0);
                transform.Translate(movimiento);
                moveRight = true;
                moveLeft = false;
                myAnimator.SetBool("IsRunning", true);
            }

            //PERSONAJE QUIETO
            if (movH == 0)
            {
                Vector2 movimiento = new Vector2(0f, 0f);
                transform.Translate(movimiento);
                myAnimator.SetBool("IsRunning", false);
            }
            /*
            float movH = Input.GetAxis("Horizontal");

            Vector2 movimiento = new Vector2(movH * speed * Time.deltaTime, 0);
            transform.Translate(movimiento);

            if (movH != 0)
            {

                myAnimator.SetBool("IsRunning", true);
                if (movH < 0)
                {
                    moveLeft = true;
                    moveRight = false;
                    transform.localScale = new Vector2(-1, 1);
                    
                }
                else
                {
                    moveRight = true;
                    moveLeft = false;
                    transform.localScale = new Vector2(1, 1);
                    
                }


            }
            else
            {
                myAnimator.SetBool("IsRunning", false);
            }
            */
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            myAnimator.SetLayerWeight(1, 1);
            LayerTimer = Time.time + Delay;
        }
        else
        {
                
            if (Time.time >= LayerTimer)
            {
                myAnimator.SetLayerWeight(1, 0);
            }
        }
            

        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= nextFire)
        {
            Instantiate(Bala, disparador.transform.position, disparador.transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
