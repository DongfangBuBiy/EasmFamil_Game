using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myket_Scoor : MonoBehaviour
{
    public string URL = "myket://comment?id=Atom_Tecnology.e3mfam1l";
   public void tick()
    {
        Application.OpenURL(URL);
       
    }
}
