using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoScene : MonoBehaviour
{
    public void GotoScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void GotoScene2()
    {
        SceneManager.LoadScene("Scene2");
    }
}
