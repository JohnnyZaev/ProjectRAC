#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Reflection.Emit;
using Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button exitButton;

        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            startButton.onClick.AddListener(StartGame);
            // settingsButton.onClick.AddListener(SettingsManager.Instance.OpenSettings);
            exitButton.onClick.AddListener(ExitGame);
        }

        private void StartGame()
        {
            _sceneLoader.LoadScene(SceneLoader.SceneNames.Game);
        }

        private void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
