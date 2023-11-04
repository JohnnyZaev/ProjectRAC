using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoader sceneLoaderPrefab;

        private SceneLoader _sceneLoader;
        public override void InstallBindings()
        {
            CreateServices();
            BindServices();
            InitServices();
        }

        private void CreateServices()
        {
            var loader = Container.InstantiatePrefab(sceneLoaderPrefab.gameObject);
            _sceneLoader = loader.GetComponent<SceneLoader>();
        }

        private void BindServices()
        {
            Container.Bind<SceneLoader>().FromInstance(_sceneLoader);
        }

        private void InitServices()
        {
            _sceneLoader.Init();
        }
    }
}