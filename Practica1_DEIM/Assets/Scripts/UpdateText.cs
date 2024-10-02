using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public GameManager.GameManagerVariables variables;
    private TMP_Text textcomponent;
    private int auxScore = 0; // score auxiliar 
    // Start is called before the first frame update
    void Start()
    {
        textcomponent = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (variables) 
        {
            case GameManager.GameManagerVariables.Score: 
                int currentScore = GameManager.instance.GetScore(); // llama al score actual del gameManager
                if(auxScore != currentScore) // si el score auxilar no es igual al score actual, comienza la corrutina 
                                             // y el score auxiliar se convierte en el score
                { 
                    StartCoroutine(FadeOut());
                    auxScore = currentScore;   
                }
                break;
            default:
                break;
        }
    }

    IEnumerator FadeOut()
    {
        Color color = textcomponent.color; // guarda el color del texto
        for(float alpha = 1.0f; alpha >= 0; alpha -= 0.01f) // en cada vuelta del for el color del alfa disminuye 
        {
            color.a = alpha;
            textcomponent.color = color;
            yield return null;
        }
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        textcomponent.text = "Score " + GameManager.instance.GetScore(); // la puntiacion se actualiza al comenzar el fade in
        Color color = textcomponent.color; 
        for(float alpha = 0.0f; alpha <= 1; alpha += 0.01f) 
        {
            color.a = alpha; 
            textcomponent.color = color;
            yield return null;
        }
    }
}
