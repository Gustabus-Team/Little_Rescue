using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int opposumCount;
    public static GameManager _gameManager;
    public TextMeshProUGUI count;
    public int destroyedObjects; //numero de cosas destruidas en el momento
    public int necessaryToWin = 1; //numero necesario de cosas destruidas para ganar el nivel
    private bool playing = true;

    private void Awake()
    {
        _gameManager = this;
    }
    void Update()
    {
        count.text = opposumCount.ToString();
        if(Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(0);
        }

        if(destroyedObjects >= necessaryToWin && playing)
        {
            playing = false;
            Wintransition();
        }
    }


    public void Wintransition() //funcion usada para hacer el fade
    {

        Invoke("changeLevel", 3); //reemplaza el numero con el tiempo que tomara en realizarce tu transicion
    }

    public void changeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//esto te enviara a la siguiente escena que se encuentre en build settings
    }


}
