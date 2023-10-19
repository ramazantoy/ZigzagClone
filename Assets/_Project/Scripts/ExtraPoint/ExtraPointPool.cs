using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class ExtraPointPool : MonoBehaviour
	{
		public static ExtraPointPool Instance;

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;

			
			}
			else if(Instance != this)
			{
				Destroy(gameObject);
			}
		}

		[SerializeField]
		private List<ExtraPoint> _pooledGOList;

		[SerializeField] private ExtraPoint _objectPrefab;
		
		public void AddObject(ExtraPoint poolableGO)
		{
			if (!_pooledGOList.Contains(poolableGO))
			{
				_pooledGOList.Add(poolableGO);
				
				poolableGO.transform.parent = transform;
				poolableGO.transform.localPosition = Vector3.zero;
				
				poolableGO.gameObject.SetActive(false);
			}
		}

		public ExtraPoint TakeObject()
		{
			ExtraPoint poolableGO;
			if (_pooledGOList.Count > 0)
			{
				poolableGO = _pooledGOList[0];
				_pooledGOList.Remove(poolableGO);
			}
			else
			{
				poolableGO = Instantiate(_objectPrefab);
			}
			poolableGO.gameObject.SetActive(true);
			poolableGO.transform.parent = null;
			return poolableGO;
		}
	}

