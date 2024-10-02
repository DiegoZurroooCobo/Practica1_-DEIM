using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadTXT : MonoBehaviour
{
    public string filename = "playerPosition.txt";
    List <DateTime> Times = new List<DateTime>(); // Creamos una lista que almacena el tiempo 
    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            Load();
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }
    void Save() // metodo que escribe la informacion de guardado 
    {
        StreamWriter streamwriter = new StreamWriter(Application.persistentDataPath + '\\' + filename); // crea el streamwriter que nos permite escribir y lo almacena donde nosotros indicamos
        streamwriter.WriteLine(transform.position.x);
        streamwriter.WriteLine(transform.position.y);
        streamwriter.WriteLine(transform.position.z);
        streamwriter.WriteLine(GameManager.instance.GetScore());
        // escribimos la informacion de la posicion y de la puntuacion

        if(Times !=  null ) // si la lista de tiempos no es null se crea un foreach 
        { 
            foreach (DateTime date in Times) // el foreach recorre la lista 
            { 
                streamwriter.WriteLine(date.ToString());  // por cada "date" que hay en la lista Times, se escribe la informacion del tiempo
            }
            streamwriter.WriteLine(DateTime.Now.ToString()); // escribe el tiempo actual
        }
        else 
        {
            streamwriter.WriteLine(DateTime.Now.ToString()); // si no es null, tambien escribe la informacion del tiempo 
        }

        streamwriter.Close(); // importante cerrar los cambios
    }

    void Load()
    {
        if(File.Exists(Application.persistentDataPath + '\\' + filename))  // cargamos la informacion guardada
        {
            try
            {
                StreamReader streamReader = new StreamReader(Application.persistentDataPath + '\\' + filename); // lee la informacion almacenada 
                float x = float.Parse(streamReader.ReadLine()); //Pasar de un string a un tipo concreto
                float y = float.Parse(streamReader.ReadLine()); //Pasar de un string a un tipo concreto
                float z = float.Parse(streamReader.ReadLine()); //Pasar de un string a un tipo concreto
                int score = int.Parse(streamReader.ReadLine()); 
                DateTime times = DateTime.Parse(streamReader.ReadLine());
                // pasa la informcion de un tipo a string para que sea visible en el documento de guardado

                streamReader.Close(); // cerramos el lector 
                transform.position = new Vector3(x, y, z); // establecemos la posicion del gameobject 
                GameManager.instance.SetScore(score);

            }
            catch (System.Exception e) //como no guardamos info en ningun servidor, lo guardamos en LOCAL,
                                       //no tenemos control sobre los archivos del usuario. Nos guardamos de que si 
                                       //algo va mal, este todo controlado
            {
                    Debug.Log(e.Message);
            }
            // hacemos un try catch para evitar que si ocurre un problema al cargar la informacion, la aplicacion colapse 
        }
    }
}
