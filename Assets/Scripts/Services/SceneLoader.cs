using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Services
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private GameObject loadingCanvas;
        [SerializeField] private Image progressBar;
        
        public enum SceneNames
        {
            Bootstrap,
            MainMenu,
            Game
        }

        public void Init()
        {
            loadingCanvas.SetActive(true);
            LoadScene(SceneNames.MainMenu);
        }

        private void OnDisable()
        {
            loadingCanvas.SetActive(false);
        }

        public async void LoadScene(SceneNames s)
        {
            loadingCanvas.SetActive(true);
            var scene = SceneManager.LoadSceneAsync(s.GetHashCode());
            scene.allowSceneActivation = false;

            do
            {
                await Task.Delay(100);
                progressBar.fillAmount = scene.progress;
            } while (scene.progress < 0.9f);

            progressBar.fillAmount = 1f;
            await Task.Delay(1000);
            
            scene.allowSceneActivation = true;
            progressBar.fillAmount = 0;
            loadingCanvas.SetActive(false);
        }
    }
}
