using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Canvas cs;
    private void OnTriggerEnter(Collider other)
    {
            End();
    }

    public void End()
    {
        Time.timeScale = 0;
        cs.transform.GetChild(2).gameObject.SetActive(true);
        cs.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        User›nterface.point = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
