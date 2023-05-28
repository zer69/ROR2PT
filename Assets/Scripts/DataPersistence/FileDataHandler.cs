using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";

    private string dataFileName = "";

    private bool useEncryption = false;
    private readonly string encryptionCodeWord = "ligma";

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public ClientData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        ClientData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                if (useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                //loadedData = JsonUtility.FromJson<ClientData>(dataToLoad);
                loadedData = JsonConvert.DeserializeObject<ClientData>(dataToLoad);

            }
            catch (Exception e)
            {
                Debug.LogError("Caught exception when trying to load data to file: " + fullPath + "\n" + e);
            }
        }

        return loadedData;
    }

    public void Save(ClientData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {

            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //string dataToStore = JsonUtility.ToJson(data, true);
            string dataToStore = JsonConvert.SerializeObject(data, Formatting.Indented);

            if (useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }

        }
        catch (Exception e)
        {
            Debug.LogError("Caught exception when trying to save data to file: " + fullPath + "\n" + e);
        }
    }

    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }

        return modifiedData;
    }
}
