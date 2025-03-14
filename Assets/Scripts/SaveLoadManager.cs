using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour
{
    public List<DraggablePiece> objectsToSave;
        public GameObject loadButtonPrefab; // Prefab for dynamic load buttons
        public Transform loadButtonParent; // Parent where load buttons will be displayed
        public Button loadButton; // Main button to show saved scenes
    
        private string saveDirectory;
    
        private void Start()
        {
            saveDirectory = Path.Combine(Application.persistentDataPath, "SavedScenes");
    
            if (!Directory.Exists(saveDirectory))
                Directory.CreateDirectory(saveDirectory);
    
            loadButton.onClick.AddListener(DisplaySavedScenes); // Show saved scenes when clicked
        }
    
        public void SaveLayout()
        {
            int saveIndex = GetNextSaveIndex(); // Get the next available slot (Scene 1, 2, etc.)
            string savePath = Path.Combine(saveDirectory, $"Scene{saveIndex}.json");
    
            List<ObjectData> dataList = new List<ObjectData>();
            foreach (var obj in objectsToSave)
            {
                LightObject light = obj.GetComponent<LightObject>(); // Get light if present
                dataList.Add(new ObjectData()
                {
                    position = obj.transform.position,
                    rotation = obj.transform.rotation.eulerAngles.z,
                    lightIntensity = light ? light.lightIntensity : 0, // Save light intensity
                    lightColor = light ? light.lightColor : Color.white // Save light color
                });
            }
    
            File.WriteAllText(savePath, JsonUtility.ToJson(new DataWrapper() { objects = dataList }, true));
    
            Debug.Log($"Saved as {savePath}");
        }
    
        public void LoadLayout(string sceneName)
        {
            string savePath = Path.Combine(saveDirectory, sceneName + ".json");
    
            if (!File.Exists(savePath)) return;
            string json = File.ReadAllText(savePath);
            var dataWrapper = JsonUtility.FromJson<DataWrapper>(json);
    
            for (int i = 0; i < objectsToSave.Count && i < dataWrapper.objects.Count; i++)
            {
                objectsToSave[i].transform.position = dataWrapper.objects[i].position;
                objectsToSave[i].transform.rotation = Quaternion.Euler(0, 0, dataWrapper.objects[i].rotation);
    
                LightObject light = objectsToSave[i].GetComponent<LightObject>();
                if (light != null)
                {
                    light.lightIntensity = dataWrapper.objects[i].lightIntensity;
                    light.lightColor = dataWrapper.objects[i].lightColor;
                }
            }
    
            Debug.Log($"Loaded {sceneName}");
        }
    
        private int GetNextSaveIndex()
        {
            string[] existingFiles = Directory.GetFiles(saveDirectory, "Scene*.json");
            return existingFiles.Length + 1;
        }
    
        public void DisplaySavedScenes()
        {
            foreach (Transform child in loadButtonParent)
            {
                Destroy(child.gameObject); // Clear old buttons
            }
    
            string[] existingFiles = Directory.GetFiles(saveDirectory, "Scene*.json");
            foreach (string file in existingFiles)
            {
                string sceneName = Path.GetFileNameWithoutExtension(file);
                GameObject buttonGO = Instantiate(loadButtonPrefab, loadButtonParent);
                buttonGO.GetComponentInChildren<Text>().text = sceneName;
                buttonGO.GetComponent<Button>().onClick.AddListener(() => LoadLayout(sceneName));
            }
        }
    
        [System.Serializable]
        private class DataWrapper
        {
            public List<ObjectData> objects;
        }
    
        [System.Serializable]
        private class ObjectData
        {
            public Vector3 position;
            public float rotation;
            public float lightIntensity;
            public Color lightColor;
        }
}
