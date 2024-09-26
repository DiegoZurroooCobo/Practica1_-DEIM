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
            Load();
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
                streamReader.ReadLine(); // se leen las primeras lineas aunque la informacion no sea relevante
                float x = float.Parse(streamReader.ReadLine()); //Pasar de un string a un tipo concreto
                float y = float.Parse(streamReader.ReadLine()); //Pasar de un string a un tipo concreto
                float z = float.Parse(streamReader.ReadLine()); //Pasar de un string a un tipo concreto

                streamReader.Close();
                transform.position = new Vector3(x, y, z); // establecemos la posicion del gameobject 
            }
            catch (System.Exception e) //como no guardamos info en ningun servidor, lo guardamos en LOCAL,
                                       //no tenemos control sobre los archivos del usuario. Nos guardamos de que si 
                                       //algo va mal, este todo controlado
            {
                    Debug.Log(e.Message);
            }
        }

    }
    
}
