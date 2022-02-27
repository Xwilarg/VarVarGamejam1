﻿using UnityEngine;
using UnityEngine.SceneManagement;
using VarVarGamejam.Translation;

namespace VarVarGamejam.Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadGame()
        {
            SceneManager.LoadScene("Transition");
        }

        public void SetLanguage(string value)
        {
            Translate.Instance.CurrentLanguage = value;
        }
    }
}
