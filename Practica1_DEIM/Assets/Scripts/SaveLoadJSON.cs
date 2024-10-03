using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
struct PlayerData   // estructura de datos especifica de json
{
    public Vector3 position;
    public int score;
    //public string time;
    public List<string> Hours;
}
public class SaveLoadJSON : MonoBehaviour
{
    public string fileName = "playerposition.json";
    // Start is called before the first frame update
    void Start()
    {
        fileName = Application.persistentDataPath + '\\' + fileName; // el archivo de guardado se guarda donde nosotros indicamos 
        Load();
    }
    private void OnApplicationQuit() // al cerrarse la aplicacion, la informacion se guarda de manera automatica 
    {
        Save();
    }

    void Save()
    {
        StreamWriter streamwriter = new StreamWriter(fileName);

        PlayerData playerdata = new PlayerData(); // instancio objeto que vamos a guardar 
        playerdata.position = transform.position; 
        playerdata.score = GameManager.instance.GetScore();
        //playerdata.time = DateTime.Now.ToString();
        List<string> hours = GameManager.instance.GetHours();
        hours.Add(DateTime.Now.ToString("HH.mm.ss"));
        playerdata.Hours = hours;
        // se rellena el playerdata de info 

        string json = JsonUtility.ToJson(playerdata);   // pasar de un objeto serializable a un formato JSON con un formato string
        streamwriter.WriteLine(json); //escribe toda la informacion almacenada en el playerdata


        streamwriter.Close(); // cerramos el guardado
    }

    void Load()
    {
        if (File.Exists(fileName))
        {
            StreamReader streamReader = new StreamReader(fileName);
            try
            {                                                                                       // de formato JSON a objeto serializable
                PlayerData playerdata = JsonUtility.FromJson<PlayerData>(streamReader.ReadToEnd()); // el streamReader lee el json entero y lo pasa a objeto serializable
                transform.position = playerdata.position;
                GameManager.instance.SetScore(playerdata.score);
                GameManager.instance.SetHours(playerdata.Hours);
            }
            catch (System.Exception e)
            {
                // sale el topo
                Debug.Log(e.Message);
            }
            streamReader.Close();
        }
    }
}
