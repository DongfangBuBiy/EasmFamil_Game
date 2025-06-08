using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_bloack : MonoBehaviour
{
    public List<Button> LevelButton;
    public int PLayerLevel;
    private void  Start()
    {
        if(MainManger.Instance != null)
        {
            Level(MainManger.Instance.PlayerData.PlayerLevel);
        }
       
       
    }
    private void Update()
    {
        ShowButton();
    }

    public void Level(int level)
    {
        PLayerLevel = level;
    }
    public void ShowButton()
    {
        
            foreach (Button button in LevelButton)
            {
                if (LevelButton.IndexOf(button) <= PLayerLevel)
                {
                    button.interactable = true;


                }
            else
            {
                button.interactable= false;
            }

            }
            
        
    }
}
