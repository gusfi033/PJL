using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public static Bomb current;
    [SerializeField] List<ParticleSystem> particleSystems;  // Lista de sistemas de partículas
    [SerializeField] List<GameObject> particleObjects; // Lista de objetos que contêm os sistemas de partículas

    private bool timerFinished = false;  // Variável para controlar se o timer terminou

    float remainingTime;            // Tempo restante

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        remainingTime = GameManager.current.bombTime;

    }

    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.F2))
        {
            Explode();
        }


        // Decrementa o tempo se ele ainda for maior que zero
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UiManager.current.UpdateBombCountDown(remainingTime);
        }
        else if (!timerFinished)  // Ativa as partículas apenas quando o timer chega a zero pela primeira vez
        {
            Explode();
        }


    }

    public float SubtractTime(float time)
    {
        var removedTime = time;
        if(remainingTime < time)
        {
            removedTime = remainingTime;    
        }
        remainingTime -= removedTime;
     
        if (remainingTime < 0)
            remainingTime = 0;

        return removedTime;
    }
    void Explode()
    {
        remainingTime = 0;
        UiManager.current.ShowBombCountDownExplode();

        CameraShaker.current.Shake(5, 0.5f, 20);


        // Reproduz todos os sistemas de partículas
        foreach (var particleSystem in particleSystems)
        {
            if (particleSystem != null && !particleSystem.isPlaying)
            {
                particleSystem.Play();  // Inicia a animação do Particle System
            }
        }

        timerFinished = true;  // Marca que o timer já acabou

        GameManager.current.GameOver();
    }

    public void StopBomb()
    {
        remainingTime = 0;
        UiManager.current.ShowBombCountDownDefuse();

        timerFinished = true;  // Marca que o timer já acabou
    }
}
