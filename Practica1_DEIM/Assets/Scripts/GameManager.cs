using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameManagerVariables {Score};

    private int score;
    private void Awake()
    {
        if(!instance) 
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        { 
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScore()   
    { 
        return score;
    }
    public void SetScore(int value)
    { 
        score = value;
    }
}
