﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManger_Level2 : MonoBehaviour
{
    public List<string> Answer_List;
    public List<string> Help_Answer;
    bool Answer_repet = false;
    string HelpCheck;
    public int PlayerAnswerCount;
    public string PlayerAnswer;
    public int PlayerCoin;
    public int Help_coin = 50;
    public List<string> AnswerBefor;
    private string cls = "";
    public List<GameObject> GameObjects;
    public GameObject Plane;
    public bool win_Player;
    private float sohw;
    public Slider Slider;
    public Text Text;
    public Text coin;
    public List<GameObject> Helpanswer;
    //sound
    public AudioSource winsound;
    public AudioSource Wirting;
    // Show Farsi Leter
    public Text Farsi;
    public string PlayerLeter;
    public int PLayerLevel;
    public int WinCoin = 120;
    // Start is called before the first frame update

    private void Start()
    {
        if (MainManger.Instance != null)
        {
            SetCoin();
            SetLevel();
            anwnserBefor(MainManger.Instance.PlayerData.PlayeranswerBefor);

        }
    }
    // Update is called once per frame
    void Update()
    {
        Game();
        win();
        Show();
        farsi();
        SetCoin();
        PlayerAnswerBefor();
    }
    private void anwnserBefor(List<string> answerList)
    {
        if (answerList.Count > 0)
        {
            AnswerBefor = answerList;
            PlayerAnswerCount += answerList.Count;
            foreach (string answer in AnswerBefor)
            {
                Help_Answer.Remove(answer);
                ShowAnswer(answer);

            }
        }

    }
    
    public void GetFarsi(string far)
    {
        PlayerLeter += far;
        far = "";
    }
    public void CleanFarsi()
    {
        PlayerLeter = "";

    }
    // این تابع مقداری که از قبل سکه ها بود را به سینس اضافه میکند
    private void SetCoin()
    {
        PlayerCoin = MainManger.Instance.PlayerData.PlayerCoin;
    }
    //این تابع عدد مرحله که بازیکن در انم قرار دارد را بازمیگرداند
    public void SetLevel()
    {
        PLayerLevel = MainManger.Instance.PlayerData.PlayerLevel;
    }
    //این تابع به سکه های بازیکن اضافه میکند
    public void AddCoinInEndOfGame(int playercoin)
    {
        MainManger.Instance.AddCoin(playercoin);

    }
    public void LevelPlus()
    {
        MainManger.Instance.IncreaseLevel();
    }
    public int returncoin()
    {
        return PlayerCoin;
    }
    private void Show()
    {
        coin.text = PlayerCoin.ToString();
    }
    public void GePlayerAnswer(string Get)
    {
        PlayerAnswer += Get.ToString();

    }
    private void check()
    {
        if (Answer_List.Contains(PlayerAnswer))
        {
            PlayerAnswerCount += 1;
            if (PlayerAnswer.Contains(PlayerAnswer.ToString()))
            {
                AnswerBefor.Add(PlayerAnswer);
                Help_Answer.Remove(PlayerAnswer);
                ShowAnswer(PlayerAnswer);
                clen(cls);
                wiritingsoude();
                CleanFarsi();
            }


        }
    }
    private void win()
    {
        if (Answer_List.Count == PlayerAnswerCount && win_Player)
        {
            

            
            win_Player = false;
            if (PLayerLevel < 2)
            {
                AddCoinInEndOfGame(120);
                LevelPlus();
                MainManger.Instance.CleanAnswerBefor();
            }
            Plane.SetActive(true);
            Coin_Show();
            coin_number();
            WinSound();

        }

    }
    private bool AnswerRipit()
    {
        if (AnswerBefor.Contains(PlayerAnswer))
        {
            return Answer_repet = true;
        }
        else
        {
            return Answer_repet = false;
        }
    }
    public void clen(string cls)
    {
        PlayerAnswer = cls.ToString();
    }
    public bool CanCoinMinus(int Coin_Want_Cash)
    {
        if (PlayerCoin > 0 && PlayerCoin >= Coin_Want_Cash)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public string HelpAnswerCheck(List<string> HelpList)
    {
        foreach (string str in HelpList)
        {
            if (AnswerBefor.Contains(str.ToString()))
            {
                return HelpCheck = str.ToString();
            }
            else
            {
                return HelpCheck = str.ToString();

            }

        }
        return HelpCheck;
    }
    private void Game()
    {
        AnswerRipit();
        if (Answer_repet == false)
        {
            check();
        }
    }
    public void Help()
    {
        bool can1 = CanCoinMinus(Help_coin);
        if (can1 == true && Help_Answer.Count != 0)
        {
            MainManger.Instance.SpendCoins(Help_coin);//کم کردن مقدار سکه ها بعد استفاده از راهنما
            string add = Help_Answer.First().ToString();
            AnswerBefor.Add(add);
            Help_Answer.Remove(add);
            ShowAnswer(add);
            wiritingsoude();
            PlayerAnswerCount++;
        }

    }
    public void ShowAnswer(string PlayerAnswer)
    {
        switch (PlayerAnswer)
        {

            case "hva":
                GameObjects.ElementAt(0).SetActive(true);
                Helpanswer.ElementAt(0).SetActive(false);
                break;
            case "hlhld":
                GameObjects.ElementAt(1).SetActive(true);
                Helpanswer.ElementAt(1).SetActive(false);
                break;

            case "hkwqv":
                GameObjects.ElementAt(3).SetActive(true);
                Helpanswer.ElementAt(3).SetActive(false);
                break;


            case "hvnfdg":
                GameObjects.ElementAt(11).SetActive(true);
                Helpanswer.ElementAt(10).SetActive(false);
                break;
            case "hvyqhk":
                GameObjects.ElementAt(4).SetActive(true);
                Helpanswer.ElementAt(4).SetActive(false);
                break;
            case "hvlksjhk":
                GameObjects.ElementAt(6).SetActive(true);
                Helpanswer.ElementAt(6).SetActive(false);
                break;
            case "hghgi":
                GameObjects.ElementAt(9).SetActive(true);
                Helpanswer.ElementAt(8).SetActive(false);
                break;
            case "hkfv":
                GameObjects.ElementAt(7).SetActive(true);
                Helpanswer.ElementAt(7).SetActive(false);
                break;
            case "hiq":
                GameObjects.ElementAt(5).SetActive(true);
                Helpanswer.ElementAt(5).SetActive(false);
                break;
            case "ha":
                GameObjects.ElementAt(2).SetActive(true);
                Helpanswer.ElementAt(2).SetActive(false);
                break;
            case "hikfv":
                GameObjects.ElementAt(8).SetActive(true);
                Helpanswer.ElementAt(11).SetActive(false);
                break;
            
            
            case "hikwv":
                GameObjects.ElementAt(10).SetActive(true);
                Helpanswer.ElementAt(9).SetActive(false);
                break;





        }
    }
    public void Coin_Show()
    {
        if(PlayerCoin >= sohw)
        {
            sohw += 1f;
            Slider.value = sohw;

        }
    }
    public void coin_number()
    {
        Text.text = WinCoin.ToString();
    }
    //Farsi Type
    public void farsi()
    {
        Farsi.text = revert(PlayerLeter);
    }
    public string revert(string farsi)
    {
        char[] faarsiarry = farsi.ToCharArray();
        Array.Reverse(faarsiarry);
        return new string(faarsiarry);
    }
    // Sounds funces
    public void wiritingsoude()
    {
        Wirting.Play();
    }
    private void WinSound()
    {
        winsound.Play();
    }
    public void PlayerAnswerBefor()
    {
        if (Answer_List.Count > AnswerBefor.Count)
        {
            MainManger.Instance.SetAnsewrbefor(AnswerBefor);
        }


    }
    public void AdsCoin()
    {
        MainManger.Instance.AddCoin(50);
    }
}
