using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LevelMaze
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] Text keyText;
        [SerializeField] GameObject winText;

        void Start()
        {
            
            Player.onPlayerCollectKey += OnKeyCollected;
            WinController.onPlayerWin += OnPlayerWon;
        }

        void OnKeyCollected() => keyText.text = $"{4-Player.keys} keys left";

        void OnPlayerWon() => winText.SetActive(true);

        public void OnPlayerClicked()
        {
            Player.onPlayerCollectKey -= OnKeyCollected;
            WinController.onPlayerWin -= OnPlayerWon;
            SceneManager.LoadScene(0);
        }
    }
}