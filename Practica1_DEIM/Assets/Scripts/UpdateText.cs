using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public GameManager.GameManagerVariables variables;
    private TMP_Text textcomponent;
    private TextMeshPro TMP;
    // Start is called before the first frame update
    void Start()
    {
        textcomponent = gameObject.GetComponent<TMP_Text>();
        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {
        switch (variables) 
        {
            case GameManager.GameManagerVariables.Score: 
                textcomponent.text = "Score " + GameManager.instance.GetScore();
                break;
            default:
                break;
        }

    }

    IEnumerator FadeOut()
    {
        Color color = TMP.color;
        for(float alpha = 1.0f; alpha >= 0; alpha -= 0.01f)
        {
            color.a = alpha;
            TMP.color = color;
            yield return null;
        }
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        Color color = TMP.color; 
        for(float alpha = 0.0f; alpha <= 1; alpha += 0.01f) 
        {
            color.a = alpha; 
            TMP.color = color;
            yield return null;
        }
        StartCoroutine(FadeOut());
    }
}
