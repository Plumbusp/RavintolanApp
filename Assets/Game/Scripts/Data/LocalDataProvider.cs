using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

public class LocalDataProvider
{
   private PersistantData _persistantData;

    private int _fileCount;
    private const string _fileName = "order";  // Remember about extension!
    private const string _fileCountName = "count";
    private const string _ending = ".txt";

    private string SavePath => Application.persistentDataPath;
    private string CountPath => Path.Combine(SavePath, _fileCountName) + _ending;

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
            _fileCount = int.Parse(File.ReadAllText(CountPath));
            Debug.Log("Sucess");
            return true;
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
    }
    public void Save()
    {
        _fileCount++;
        string orderPath = Path.Combine(SavePath, _fileName) + _fileCount + _ending;

        Debug.Log(orderPath + "        " + CountPath);

        File.WriteAllText(orderPath, _persistantData.OrderDataObject.GetOrderContentText());
        File.WriteAllText(CountPath, _fileCount.ToString());
    }
    private bool IsCountExists() => File.Exists(CountPath);
}
