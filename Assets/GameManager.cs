using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text ScoreText;


    // Start is called before the first frame update
    void Start()
    {
      ScoreText.text=  PlayerPrefs.GetInt("Cash").ToString();
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

}
