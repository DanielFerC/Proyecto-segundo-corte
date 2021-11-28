using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balae2 : MonoBehaviour
{

    [SerializeField] int puntosDano;
    private Rigidbody2D MiRigidbody;
    [SerializeField] float speed;


    // Start is called before the first frame update
    void Start()
    {
        MiRigidbody = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        MiRigidbody.velocity = transform.right * speed;

    }
    public int darPuntosDano()
    {
        return puntosDano;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        Destroy(this.gameObject);



    }
}
