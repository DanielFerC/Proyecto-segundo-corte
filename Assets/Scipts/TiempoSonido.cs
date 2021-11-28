using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoSonido : MonoBehaviour
{
    public float TiempoDeSonido;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TiempoDeSonido);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
