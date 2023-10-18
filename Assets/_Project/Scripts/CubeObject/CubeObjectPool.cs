using System.Collections.Generic;
using UnityEngine;

namespace LeonBrave.CubeObjects
{
    public class CubeObjectPool : MonoBehaviour
    {
        public static CubeObjectPool Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                foreach (Transform child in transform)
                {
                    _pooledGOList.Add(child.gameObject);
                }
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private List<GameObject> _pooledGOList = new List<GameObject>();

        [SerializeField] private GameObject _objectPrefab;

        public void AddObject(GameObject poolableGO)
        {
            if (!_pooledGOList.Contains(poolableGO))
            {
                _pooledGOList.Add(poolableGO);

                poolableGO.transform.parent = transform;
                poolableGO.transform.localPosition = Vector3.zero;

                poolableGO.SetActive(false);
            }
        }

        public GameObject TakeObject()
        {
            GameObject poolableGO;
            if (_pooledGOList.Count > 0)
            {
                poolableGO = _pooledGOList[0];
                _pooledGOList.Remove(poolableGO);
            }
            else
            {
                poolableGO = Instantiate(_objectPrefab);
            }

            poolableGO.SetActive(true);
            poolableGO.transform.parent = null;
            return poolableGO;
        }
    }
}