using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menus_Script : MonoBehaviour
{
  public void StartGame()
    {
        StartCoroutine(_StartGame());
    }

    IEnumerator _StartGame()
    {
        AudioSelected.instance.PlayMusic();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game");
    }
}
