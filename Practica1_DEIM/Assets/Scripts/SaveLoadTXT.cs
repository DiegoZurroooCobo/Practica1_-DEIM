using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadTXT : MonoBehaviour
{
    public string filename = "playerPosition.txt";
    List <DateTime> Times = new List<DateTime>(); // Creamos una lista que almacena el tiempo 
    private void Start()
    {
        Load();
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
        List<string> hours_ = GameManager.instance.GetHours();
        hours_.Add(DateTime.Now.ToString("HH:mm:ss"));
        // escribimos la informacion de la posicion y de la puntuacion

        foreach(string hour in hours_) 
        { 
            streamwriter.WriteLine(hour);
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
                List<string> hoursAux = new List<string>();

                // como las horas es lo ultimo qu ese guarda
                while(!streamReader.EndOfStream) 
                { 
                    hoursAux.Add(streamReader.ReadLine());
                }
                GameManager.instance.SetHours(hoursAux);
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
            // 
        }
    }
}
