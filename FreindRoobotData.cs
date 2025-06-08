using System;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class FreindRoobotData
{
    public int AvailableFreezes = 2;           // تعداد فریزهای باقی‌مانده
   
    public List<FreezeItem> FreezeItems = new List<FreezeItem>(); // انواع فریز

    public int AvailableHelps = 3;          // تعداد کمک‌های باقی‌مانده برای استفاده
    public int MaxFreezes = 2;
    public float HelpCooldown = 60f;        // زمان سکون بین استفاده (ثانیه)
    public DateTime LastHelpUsedTime = DateTime.Now;


    public const int MaxHelpCap = 13; // حداکثر مجاز برای کمک
    public const int MaxFreezeCap = 10; // حداکثر فریز مجاز
    public FreindRoobotData()
    {
        if (FreezeItems.Count == 0)
        {
            FreezeItems.Add(new FreezeItem("Simpel",20f,true));

        }


    }
    public void IncreaseMaxHelps(int amount)
    {
        int newMax = AvailableHelps + amount;

        if (newMax > MaxHelpCap)
        {
            newMax = MaxHelpCap;
        }

        int addedAmount = newMax - AvailableHelps;

        AvailableHelps = newMax;
        AvailableHelps = Math.Min(AvailableHelps + addedAmount, AvailableHelps);
    }

    public void IncreaseMaxFrezzItem(int amount)
    {
        int newMax = MaxFreezes + amount;

        if (newMax > MaxFreezeCap)
        {
            newMax = MaxFreezes;
        }

        int addedAmount = newMax - AvailableHelps;

        MaxFreezes = newMax;
        AvailableHelps = Math.Min(AvailableHelps + addedAmount, MaxFreezes);
    }
}

