using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public GameManager.GameManagerVariables variables;
    private TMP_Text textcomponent;
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
                textcomponent.text = "Score " + GameManager.instance.GetScore(); 
                break;
            default:
                break;
        }
    }
}
