using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickLogButton()
    {
        SceneManager.LoadScene("LogScene");
    }

    public void OnClickThanksButton()
    {
        SceneManager.LoadScene("ThanksScene");
    }

    public void OnClickOrderButton()
    {
        SceneManager.LoadScene("OrderScene");
    }

    public void OnClickRegisterButton()
    {
        SceneManager.LoadScene("RegisterScene");
    }

    public void OnClickAllButton()
    {
        SceneManager.LoadScene("All");
    }

    public void OnClickCaculater(GameObject gameObject)
    {
        gameObject.SetActive (true);
    }

    public void OnClickLogButton2()
    {
        SceneManager.LoadScene("LogScene2");
    }

}