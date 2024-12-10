using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text ScoreText;
    public GameObject activePlayer;
    public Transform[] CollectableCoins;


    public float GameTimer;
    float gTime;

    public Text Timer;

    public GameObject Failpanel;


    // Start is called before the first frame update
    void Start()
    {

      ScoreText.text=  PlayerPrefs.GetInt("Cash").ToString();
        PlayerPrefs.SetInt("Coins", 0);
        gTime = GameTimer;
    }

 

    public void UpdtateCoins()
    {
        PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 5);
        ScoreText.text = PlayerPrefs.GetInt("Cash").ToString();
    }

    public void Revive()
    {
        int CoinIndex = PlayerPrefs.GetInt("Coins");
       
        
            Transform revivePosition = CollectableCoins[CoinIndex];
            activePlayer.transform.position=(revivePosition.position);
            activePlayer.GetComponent<Rigidbody>().velocity = Vector3.zero; 
           
        
    }


     public void Retry()
    {
        SceneManager.LoadScene("GamePlay");

    }


    private void Update()
    {
        GameTimer -= Time.deltaTime;
        Timer.text = ((int)(GameTimer)).ToString();
        if (GameTimer <= 0)
        {
            Failpanel.SetActive(true);
        }
        else
        {
            return;
        }
    }



}
