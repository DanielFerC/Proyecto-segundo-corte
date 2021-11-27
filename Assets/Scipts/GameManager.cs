using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int numeroEnemigos;
    [SerializeField] GameObject GameOverMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void DestroyEnemy()
    {
        numeroEnemigos--;
        if (numeroEnemigos <= 0)
        {
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
        }
    }
}
