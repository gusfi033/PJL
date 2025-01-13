using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    public string nextLevel;
    public float bombTime = 5f;

    public float defuseTime = 2f;


    private void Awake()
    {
        current = this;
    }




    public void PlayerDeath()
    {
        PlayerMovement.current.Resspawn();
    }

    public void FallCube()
    {
        FallingCube.current.Resspawn();
    }



    public void GameOver()
    {
        StartCoroutine(GameOver_Routine());
    }

    IEnumerator GameOver_Routine()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void GameWin()
    {
        StartCoroutine(GameWin_Routine());
    }
    IEnumerator GameWin_Routine()
    {
        Bomb.current.StopBomb();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(nextLevel);
    }



}
