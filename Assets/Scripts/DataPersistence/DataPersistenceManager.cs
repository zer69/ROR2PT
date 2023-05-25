using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager: MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private ClientData clientData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one dataPersistenceManager detected");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadClient();
    }

    public void NewClient()
    {
        this.clientData = new ClientData();
    }

    public void LoadClient()
    {
        this.clientData = dataHandler.Load();

        if (this.clientData == null)
        {
            Debug.LogWarning("No data, starting fresh");
            NewClient();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(clientData);
        }
    }

    public void SaveClient()
    {

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref clientData);
        }

        dataHandler.Save(clientData);
    }

    private void OnApplicationQuit()
    {
        SaveClient();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistanceObjects);
    }
}
