using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace LeonBrave.SaveManager
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance;

        [SerializeField] private GameSaveState _gameSaveState;
        private string savePath;


        public GameSaveState GameSaveState
        {
            get
            {
                return _gameSaveState;
            }
        }
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                savePath = PlayerPrefs.GetString("SavePath");
                if (string.IsNullOrEmpty(savePath))
                {
                  
                    savePath = Application.persistentDataPath+"/gameSave.json";
                    PlayerPrefs.SetString("SavePath", savePath);
                }

                Load();
                Debug.Log(_gameSaveState.HighScore);
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void Save()
        {
            string json = JsonUtility.ToJson(_gameSaveState);
            File.WriteAllText(savePath, json);
        }

        private void Load()
        {
            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath);
                _gameSaveState = JsonUtility.FromJson<GameSaveState>(json);
            }
            else
            {
                _gameSaveState = new GameSaveState();
                
                string defaultJson = JsonUtility.ToJson(_gameSaveState);
                File.WriteAllText(savePath, defaultJson);
            
            }
        }
    }
}