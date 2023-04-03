using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _menu, _mod;
    private int niveau = 1;

    public void PlayButton()
    {
       _menu.SetActive(false);
        _mod.SetActive(true);
    }
    public void RetourButton()
    {
        _menu.SetActive(true);
        _mod.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void NormalButton()
    {
       
        SceneManager.LoadScene("Niveau1");
    }
    public void RandomButton()
    {
        int index = Random.Range(1, 5);
        SceneManager.LoadScene(index);
      
    }
    public void NextButton(int _niveau)
    {
        this.niveau = _niveau;
        SceneManager.LoadScene("Niveau" + _niveau);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Option()
    {
        SceneManager.LoadScene("Options");
    }
}

