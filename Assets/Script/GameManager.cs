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

    private void Awake()
    {
        _gameManager = this;
    }
    void Update()
    {
        count.text = "Zaris: " + opposumCount.ToString();
        if(Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(0);
        }
    }

}
