using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public IEnumerator play_game()
    {
        Debug.Log("play_game");
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(2);
    }
    public IEnumerator quit()
    {
        Debug.Log("quit");
        // SceneManager.LoadScene(1);
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
    public void PlayGame() {
        StartCoroutine(play_game());
    }

    public void Quit_game()
    {
        StartCoroutine(quit());
    }


}
