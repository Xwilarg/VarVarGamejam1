﻿using UnityEngine;
using UnityEngine.UI;
using VarVarGamejam.SO;

namespace VarVarGamejam.Tablet
{
    public class TabletManager : MonoBehaviour
    {
        public static TabletManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        [SerializeField]
        private MinimapCamera[] _minimapCameras;

        [SerializeField]
        private GameObject _tabletObj;

        [SerializeField]
        private TabletInfo _info;

        [SerializeField]
        private Image _batteryImage;

        private float _remainingBattery;

        private float _blinkTimer;

        public void SetPlayerLight(Light light)
        {
            foreach (var cam in _minimapCameras)
            {
                cam.PlayerLight = light;
            }
        }

        public void SetMinimapCamera(float x, float y, float size)
        {
            foreach (var cam in _minimapCameras)
            {
                cam.transform.position = new Vector3(x, 10f, y);
                cam.GetComponent<Camera>().orthographicSize = size;
            }
        }

        private void Start()
        {
            _remainingBattery = _info.BatteryDuration;
            _blinkTimer = _info.BlinkRate;
        }

        public void Toggle()
        {
            if (_remainingBattery > 0f)
            {
                _tabletObj.SetActive(!_tabletObj.activeInHierarchy);
            }
        }

        private void Update()
        {
            if (_tabletObj.activeInHierarchy)
            {
                _remainingBattery -= Time.deltaTime;
                if (_remainingBattery <= 0f) // We are out of battery
                {
                    _tabletObj.SetActive(false);
                }
                else
                {
                    var pos = Mathf.RoundToInt(_remainingBattery * (_info.BatteryImages.Length - 1) / _info.BatteryDuration);
                    _batteryImage.sprite = _info.BatteryImages[(_info.BatteryImages.Length - 1) - pos];
                    if (pos == 0) // Blink effect on battery
                    {
                        _blinkTimer -= Time.deltaTime;
                        if (_blinkTimer <= 0f)
                        {
                            _batteryImage.enabled = !_batteryImage.enabled;
                            _blinkTimer = _info.BlinkRate;
                        }
                    }
                }
            }
        }
    }
}
