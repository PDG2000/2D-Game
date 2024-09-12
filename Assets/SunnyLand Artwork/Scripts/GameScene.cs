using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public void GameScnesCtrl()
    {
        SceneManager.LoadScene("Stage");
    }
}
