using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic1 : MonoBehaviour
{
    BoxCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool ColisionEnemy()
    {
        RaycastHit2D colision_suelo = Physics2D.Raycast(myCollider.bounds.center, Vector2.down, myCollider.bounds.extents.y + 0.1f, LayerMask.GetMask("Ground"));
        //Debug.Log("Colisionando con piso?" + colision_suelo.collider != null);
        Debug.DrawRay(myCollider.bounds.center,Vector2.down * (myCollider.bounds.extents.y + 0.1f), Color.cyan);
        return colision_suelo.collider != null;
    }
}
