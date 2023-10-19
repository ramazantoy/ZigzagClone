using UnityEngine;

namespace LeonBrave.SaveManager
{
    [System.Serializable]
    public class GameSaveState
    {
        [UnityEngine.SerializeField]
        private int _highScore;

        public GameSaveState()
        {
            _highScore = 0;
        }

        private void Save()
        {
            SaveManager.Instance.Save();
        }

        public int HighScore
        {
            get
            {
                return _highScore;
            }
            set
            {
                _highScore = value;
                Save(); 
            }
        }
    }
}