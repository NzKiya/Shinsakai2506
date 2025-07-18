using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToScene : MonoBehaviour
{
    public void MoveToPlay2Scene()
    {
        SceneManager.LoadScene("Play2Scene");
    }

    public void MoveToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
