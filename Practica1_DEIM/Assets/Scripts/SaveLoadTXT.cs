using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadTXT : MonoBehaviour
{
    public string filename = "playerPosition.txt";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)) 
        {
            Save();
        }
        else if (Input.GetKeyDown(KeyCode.L)) 
        { 
        
        }
    }

    void Save() 
    {
        StreamWriter streamwriter = new StreamWriter(Application.persistentDataPath + '\\' + filename);
        streamwriter.WriteLine(transform.position.x);
        streamwriter.WriteLine(transform.position.y);
        streamwriter.WriteLine(transform.position.z);

        streamwriter.Close(); // importante cerrar los cambios
    }

    void Load()
    {
        if(File.Exists(Application.persistentDataPath + '\\' + filename)) 
        {
            try
            {

                StreamReader streamReader = new StreamReader(Application.persistentDataPath + '\\' + filename);
                streamReader.ReadLine();

                strea
            }
        }

    }
    
}
