using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeonBrave.CubeHandler
{
    [CreateAssetMenu(fileName = "CubeHandlerData", menuName = "ScriptableObjects/CubeHandlerData", order = 2)]
    public class CubeHandlerData : ScriptableObject
    {
        public int StartCubeCount;
        public VectorClamp CubePositionClamp;
        public Vector3 StartPos;
        [Header("** Right Left **")] public float ChangeDirectionRate;
        [Header("** If dont used Group")] public int PerGivedCubeCount;
        [Header("** GroupUsedRandomCount")] public ClampVal CubeGroupCount;
        [Header("** Other Settings **")] 
        public Offset RightOffset;
        public Offset LeftOffset;
    }

    [System.Serializable]
    public class Offset
    {
        public float X;
        public float Z;
    }
}