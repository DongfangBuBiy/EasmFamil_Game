using UnityEngine;
using UnityEngine.SceneManagement;

public class SecenLoad : MonoBehaviour
{
 
    public void LoadSeneceWant(string nameOfSence)
    {
        SceneManager.LoadScene(nameOfSence);
    }
}
