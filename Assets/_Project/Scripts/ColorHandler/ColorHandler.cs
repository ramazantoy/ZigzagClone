using LeonBrave.GameManager;
using UnityEngine;

namespace LeonBrave.ColorHandler
{
    public class ColorHandler : MonoBehaviour
    {
        [SerializeField] private ColorHandlerData _properties;

        private Color targetMainColor;
        private Color targetEmissionColor;
        private float colorChangeDuration;

        private void Awake()
        {
            SetTimer();
            SetColor();
        }

        private void SetTimer()
        {
            colorChangeDuration = _properties.UseRandomTime ? _properties.RandomTime.RandomValue : _properties.RegularTime;
        }

        private void SetColor()
        {
            ColorData colorDataTemp = _properties.GetRandomColorData();
            targetMainColor = colorDataTemp.MainColor;
            targetEmissionColor = colorDataTemp.EmissionColor;
        }

        private float _timer = 0;

        private void Update()
        {
            if(GameManager.GameManager.Instance.GameState!=GameState.Playing) return;
            
            _timer += Time.deltaTime;
            
            if (_timer >= colorChangeDuration)
            {
                ChangeColor(1.0f); 
                SetTimer(); 
                SetColor();
                _timer = 0;
            }
            else
            {
                float t = _timer / colorChangeDuration;
                ChangeColor(t);
            }
        }

        private void ChangeColor(float t)
        {
            _properties.CubeMaterial.color = Color.Lerp(_properties.CubeMaterial.color, targetMainColor, t);
            _properties.CubeMaterial.SetColor("_EmissionColor", Color.Lerp(_properties.CubeMaterial.GetColor("_EmissionColor"), targetEmissionColor, t));
        }
    }
}