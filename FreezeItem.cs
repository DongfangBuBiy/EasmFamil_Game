using UnityEngine;

[System.Serializable]
public class FreezeItem
{
    public string Type;
    public float Duration;
    public bool Owned;

    public FreezeItem(string type, float duration,bool owened)
    {
        this.Type = type;
        this.Duration = duration;
        this.Owned = owened;
    }
}
