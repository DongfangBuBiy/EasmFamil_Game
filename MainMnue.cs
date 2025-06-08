using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainMnue : MonoBehaviour
{
    
    public int pcoin;
   
    public Text Coin;


    private void Start()
    {
        Set(MainManger.Instance.PlayerData.PlayerCoin);
        ShowCoin(pcoin);
    }

    
    private void Set(int coin)
    {
        pcoin += coin;
        
    }
    private void ShowCoin(int coin)
    {
        Coin.text = coin.ToString();
    }
    public void StartBTM()
    {
        MainManger.Instance.LoadCoin();
    }
   

    public void Exit()
    {
        MainManger.Instance.SaveCoin();

        

        Application.Quit(); 

    }
    

    // TO DO -Update methond for give coin by tpcell;
}
