using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Gamemaneger : MonoBehaviour
{
    public int lifes = 1;
    public int coins = 0;
    public TextMeshProUGUI textcoins;
    public TextMeshProUGUI textlifes;
    public GameObject losepanel;
    public GameObject winpanel;




    public void UpdateGui()
    {
        textcoins.text = "coins: " + coins.ToString();
        textlifes.text = "lifes: " + lifes.ToString();
    }


    private void Start()
    {
        UpdateGui();
        losepanel.gameObject.SetActive(false);
        winpanel.gameObject.SetActive(false);
        
    }

    public void Restart()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

    public void LoseGame()
    {
        losepanel.gameObject.SetActive(true);
        Time.timeScale = 0f;

    }

    public void WinGame()
    {
        winpanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }


}
