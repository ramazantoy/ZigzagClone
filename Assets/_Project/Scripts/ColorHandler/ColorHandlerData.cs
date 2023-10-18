using System.Collections.Generic;
using UnityEngine;

namespace LeonBrave.ColorHandler
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ColorHandlerData", order = 1)]
    public class ColorHandlerData : ScriptableObject
    {
        public Material CubeMaterial;
        [Header("**Settings **")] public bool UseRandomTime;
        public ClampVal RandomTime;
        public float RegularTime;
        public float ColorSetTime;
        [Header("** Colors **")] public List<ColorData> ColorDatas;


        public ColorData GetRandomColorData()
        {
            if (ColorDatas == null || ColorDatas.Count <= 0) return null;
            
            int randomIndex = UnityEngine.Random.Range(0, ColorDatas.Count);
            
            return ColorDatas[randomIndex];

        }
    }
}