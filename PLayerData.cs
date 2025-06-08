using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class PLayerData 
{
    public int DataVersion = 1;
    public int PlayerXP;
    public int PlayerCoin;
    public int PlayerLevel;//برای بخش مرحله ای است
   
    public List<string> PlayeranswerBefor;

    // ⬇️ فیلدهای جدید:
    public string PlayerName = "";
    public string PlayerAvatar = ""; // مثلاً "avatar_1.png" یا شماره آواتار

    public PLayerData()
    {
        PlayerCoin = 200;
        PlayerXP = 100;
        PlayerLevel = 0; // سطح بازیکن از 0 شروع شود منطقی است
        PlayeranswerBefor = new List<string>();
        //اسم و عکس
        PlayerName = "بازیکن جدید";
        PlayerAvatar = "";//TODO set Difalt
    }



}
