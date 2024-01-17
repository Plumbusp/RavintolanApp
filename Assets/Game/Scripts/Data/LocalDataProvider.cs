using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

public class LocalDataProvider
{
   private PersistantData _persistantData;

    private int _fileCount;
    private const string _fileName = "/order";  // Remember about extension!
    private const string _fileCountName = "/count";
    private const string _ending = ".json";

    private string SavePath = Application.persistentDataPath;
    private string CountPath => SavePath + _fileCountName + _ending;

    public LocalDataProvider(PersistantData persistantData)
    {
        _persistantData = persistantData;
    }

    public bool TryLoadCount()
    {
        if (IsCountExists() == false)
            return false;
        try
        {
            string jsonString = File.ReadAllText(CountPath);
            _fileCount = JsonConvert.DeserializeObject<int>(jsonString);
            return true;
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }
    public void Save()
    {
        _fileCount++;
        File.WriteAllText(SavePath + _fileName + _fileCount.ToString() + _ending, JsonConvert.SerializeObject(_persistantData, Formatting.Indented));
        File.WriteAllText(SavePath + _fileCountName  + _ending, JsonConvert.SerializeObject(_persistantData, Formatting.Indented));
        Debug.Log(SavePath + _fileName + _fileCount.ToString() + _ending + "        " + SavePath + _fileCountName + _ending);
    }
    private bool IsCountExists() => File.Exists(CountPath);
}
