using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;  // Texto do countdown
    [SerializeField] float remainingTime;            // Tempo restante
    [SerializeField] List<ParticleSystem> particleSystems;  // Lista de sistemas de partículas
    [SerializeField] List<GameObject> particleObjects; // Lista de objetos que contêm os sistemas de partículas

    private bool timerFinished = false;  // Variável para controlar se o timer terminou

    private void Start()
    {
        // Desativa todos os GameObjects dos sistemas de partículas no início
        foreach (var particleObject in particleObjects)
        {
            if (particleObject != null)
            {
                particleObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        // Decrementa o tempo se ele ainda for maior que zero
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (!timerFinished)  // Ativa as partículas apenas quando o timer chega a zero pela primeira vez
        {
            remainingTime = 0;
            countdownText.color = Color.red;

            // Ativa todos os objetos dos sistemas de partículas
            foreach (var particleObject in particleObjects)
            {
                if (particleObject != null)
                {
                    particleObject.SetActive(true);  // Ativa o GameObject
                }
            }

            // Reproduz todos os sistemas de partículas
            foreach (var particleSystem in particleSystems)
            {
                if (particleSystem != null && !particleSystem.isPlaying)
                {
                    particleSystem.Play();  // Inicia a animação do Particle System
                }
            }

            timerFinished = true;  // Marca que o timer já acabou
        }

        // Calcula os minutos e segundos restantes
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
