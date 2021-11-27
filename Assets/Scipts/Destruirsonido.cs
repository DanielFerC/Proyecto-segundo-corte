using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruirsonido : MonoBehaviour
{
    public float TiempoDelSonido;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TiempoDelSonido);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
