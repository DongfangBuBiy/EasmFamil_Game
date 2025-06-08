using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class GameManger_Level26 : MonoBehaviour
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
    public List<GameObject> HelpPlayer;
    public int LevelPlayed;
    // Sound
    public AudioSource winsound;
    public AudioSource Wirting;
    //win
    public bool win_Player;
    public Text Text;
    public Slider slider;
    public GameObject Plane;
    public Text coin;
    // Show Farsi Leter
    public Text Farsi;
    public string PlayerLeter;
    //checkplayerlevel
    public int PLayerLevel;
    //Help UI
    public List<GameObject> Help_panel;
    public int PanelNumber = 0;
    public int WinCoin= 120;
    // Start is called before the first frame update
    void Start()
    {
        if (MainManger.Instance != null)
        {
            SetCoin();
            SetLevel();
            anwnserBefor(MainManger.Instance.PlayerData.PlayeranswerBefor);
        }
        ListGra(Answer_List);
    }

    // Update is called once per frame
    void Update()
    {
        Game();
        win();
        Show();
        SetCoin();
        farsi();
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
    private List<string> ListGra(List<string> list)
    {
        return Help_Answer = list;
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
        coin.text = MainManger.Instance.PlayerData.PlayerCoin.ToString();
    }
    // Two func for get farsi and En Player Answer
    public void GePlayerAnswer(string Get)
    {
        PlayerAnswer += Get.ToString();

    }
    public void GetFarsi(string far)
    {
        PlayerLeter += far;
        far = "";
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
                CleanFarsi();
                wiritingsoude();
            }


        }
    }
    // Main Win Functions
    private void win()
    {
        if (Answer_List.Count == PlayerAnswerCount && win_Player)
        {

            
            win_Player = false;
            if (PLayerLevel ==24)
            {
                AddCoinInEndOfGame(120);
                LevelPlus();
                MainManger.Instance.CleanAnswerBefor();
            }
            Plane.SetActive(true);
            coin_show_win();
            CoinBar();

            WinSound();


        }

    }
    // Check PlayerAmswer is repeted or not
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
    // Two function for cilen Player answer
    public void clen(string cls)
    {
        PlayerAnswer = cls.ToString();
    }
    public void CleanFarsi()
    {
        PlayerLeter = "";

    }
    // Minus Player Coin
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
    // Main Progrm func 
    private void Game()
    {
        AnswerRipit();
        if (Answer_repet == false)
        {
            check();
        }
    }
    // Help func
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
    // Show Player correct answer after check
    public void ShowAnswer(string PlayerAnswer)
    {
        switch (PlayerAnswer)
        {

            case "aihf":
                GameObjects.ElementAt(0).SetActive(true);
                HelpPlayer.ElementAt(0).SetActive(false);
                break;
            case "a2dfh":
                GameObjects.ElementAt(10).SetActive(true);
                HelpPlayer.ElementAt(10).SetActive(false);
                break;

            case "ahiv5n":
                GameObjects.ElementAt(3).SetActive(true);
                HelpPlayer.ElementAt(3).SetActive(false);
                break;




            case "ag5hv":
                GameObjects.ElementAt(4).SetActive(true);
                HelpPlayer.ElementAt(4).SetActive(false);
                break;
            case "adgd":
                GameObjects.ElementAt(3).SetActive(true);
                HelpPlayer.ElementAt(3).SetActive(false);
                break;
            case "agdg":
                GameObjects.ElementAt(12).SetActive(true);
                HelpPlayer.ElementAt(12).SetActive(false);
                break;
            case "ajv":
                GameObjects.ElementAt(7).SetActive(true);
                HelpPlayer.ElementAt(7).SetActive(false);
                break;


            case "a2ghjd":
                GameObjects.ElementAt(14).SetActive(true);
                HelpPlayer.ElementAt(14).SetActive(false);
                break;
            case "advfvk6":
                GameObjects.ElementAt(6).SetActive(true);
                HelpPlayer.ElementAt(6).SetActive(false);
                break;

            case "aa":
                GameObjects.ElementAt(2).SetActive(true);
                HelpPlayer.ElementAt(2).SetActive(false);
                break;
            case "ahxv":
                GameObjects.ElementAt(13).SetActive(true);
                HelpPlayer.ElementAt(13).SetActive(false);
                break;
            case "arhdr":
                GameObjects.ElementAt(11).SetActive(true);
                HelpPlayer.ElementAt(11).SetActive(false);
                break;
            case "axvk6":
                GameObjects.ElementAt(8).SetActive(true);
                HelpPlayer.ElementAt(8).SetActive(false);
                break;
            case "ahidk":
                GameObjects.ElementAt(9).SetActive(true);
                HelpPlayer.ElementAt(9).SetActive(false);
                break;
            case "ahl15":
                GameObjects.ElementAt(1).SetActive(true);
                HelpPlayer.ElementAt(1).SetActive(false);
                break;


        }
    }
    // UI func
    public void coin_show_win()
    {
        Text.text = WinCoin.ToString();

    }
    public void CoinBar()
    {
        if (slider.value < 1)
        {
            slider.value = 1f;
        }


    }
    // Type farsi
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
