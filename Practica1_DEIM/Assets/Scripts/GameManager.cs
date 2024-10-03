using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameManagerVariables {Score};
    private List<string> hours;

    private int score;
    private void Awake()
    {
        if(!instance) 
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
            hours = new List<string>();
        }
        else 
        { 
            Destroy(gameObject);
    }
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

    public void SetHours(List<string> value)    
    { 
        hours = value;  
    }
    public List<string> GetHours() 
    { 
        return hours;
    }


}
