using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    public List<DraggablePiece> objectsToSave;
    private string savePath;

    private void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "saveData.json");
    }

    public void SaveLayout()
    {
        List<ObjectData> dataList = new List<ObjectData>();
        foreach (var obj in objectsToSave)
        {
            dataList.Add(new ObjectData()
            {
                position = obj.transform.position,
                rotation = obj.transform.rotation.eulerAngles.z
            });
        }
        File.WriteAllText(savePath, JsonUtility.ToJson(new { objects = dataList }, true));
    }

    public void LoadLayout()
    {
        if (!File.Exists(savePath)) return;
        string json = File.ReadAllText(savePath);
        var dataWrapper = JsonUtility.FromJson<DataWrapper>(json);
        for (int i = 0; i < objectsToSave.Count && i < dataWrapper.objects.Count; i++)
        {
            objectsToSave[i].transform.position = dataWrapper.objects[i].position;
            objectsToSave[i].transform.rotation = Quaternion.Euler(0, 0, dataWrapper.objects[i].rotation);
        }
    }
    
    [System.Serializable]
    private class DataWrapper
    {
        public List<ObjectData> objects;
    }
}
