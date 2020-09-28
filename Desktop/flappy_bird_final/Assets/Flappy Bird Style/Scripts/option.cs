using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class option : MonoBehaviour
{
    public IEnumerator easy()
    {
        Debug.Log("easy mode");
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(3);
    }

    public IEnumerator normal()
    {
        Debug.Log("noraml mode");
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(4);
    }

    public IEnumerator hard()
    {
        Debug.Log("hard mode");
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(5);
    }



    public void easy_mode()
    {
        StartCoroutine(easy());
    }

    public void normal_mode()
    {
        StartCoroutine(normal());
    }
    public void hard_mode()
    {
        StartCoroutine(hard());
    }


}
