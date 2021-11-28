using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int numeroEnemigos;
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] Text Enemigos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ContadorEnemigos();
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
    public void ContadorEnemigos()
    {
        Enemigos.text = numeroEnemigos.ToString();
    }
    public void CargarEscena()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
