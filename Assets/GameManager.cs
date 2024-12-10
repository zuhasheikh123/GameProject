using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text ScoreText;
    public GameObject activePlayer;
    public Transform[] CollectableCoins; 


    // Start is called before the first frame update
    void Start()
    {
      ScoreText.text=  PlayerPrefs.GetInt("Cash").ToString();
        PlayerPrefs.SetInt("Coins", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
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


}
