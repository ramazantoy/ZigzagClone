using UnityEngine;

namespace LeonBrave.CubeObjects
{
    [System.Serializable]
    public class CubeObjectData
    {
        [Header("** Cube Objects Settings **")]
        public CubeObjectState CubeObjectState;

        public float BlowTime;
        public float DownSpeed;
    }
}