using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("ZigZag");
    }
    public void QuitButton()
    {
        Application.Quit();
    }


}
