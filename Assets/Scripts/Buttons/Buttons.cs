using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;

    public void PlayButton()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenPanel()
    {
        settingPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        settingPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitPlayButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
