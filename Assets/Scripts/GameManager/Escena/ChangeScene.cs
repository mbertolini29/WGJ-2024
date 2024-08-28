using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{


    //
    public AudioSource audioSource;
    public AudioClip doorClip;

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("Game");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //public void Change(string sceneName)
    //{
    //    audioSource.Play();
    //    SceneManager.LoadScene(sceneName);
    //    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    //SceneManager.LoadScene("Game");
    //    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    public void ChangeOnly(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Change(string sceneName)
    {
        StartCoroutine(PlaySoundAndChangeScene(sceneName));
    }

    private IEnumerator PlaySoundAndChangeScene(string sceneName)
    {
        audioSource.Play();

        // Espera hasta que el sonido termine de reproducirse
        yield return new WaitForSeconds(audioSource.clip.length);

        SceneManager.LoadScene(sceneName);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
