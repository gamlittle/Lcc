﻿using LccModel;

namespace LccHotfix
{
    public class Init
    {
        public static void Start()
        {
            Loader.Instance.FixedUpdate += FixedUpdate;
            Loader.Instance.Update += Update;
            Loader.Instance.LateUpdate += LateUpdate;
            Loader.Instance.OnApplicationQuit += OnApplicationQuit;


            Game.AddSingleton<EventSystem>();
            Game.AddSingleton<Root>();


            Game.Scene.AddComponent<Manager>();

            Game.Scene.AddComponent<ArchiveManager>();
            Game.Scene.AddComponent<AudioManager>();
            Game.Scene.AddComponent<CommandManager>();
            Game.Scene.AddComponent<ConfigManager>();
            Game.Scene.AddComponent<EventManager>();
            Game.Scene.AddComponent<GameSettingManager>();
            Game.Scene.AddComponent<GlobalManager>();
            Game.Scene.AddComponent<LanguageManager>();
            Game.Scene.AddComponent<PanelManager>();
            Game.Scene.AddComponent<SceneStateManager>();
            Game.Scene.AddComponent<UIEventManager>();
            Game.Scene.AddComponent<VideoManager>();

            EventManager.Instance.Publish(new Start()).Coroutine();
        }
        private static void FixedUpdate()
        {
            Game.FixedUpdate();
        }
        private static void Update()
        {
            Game.Update();
        }
        private static void LateUpdate()
        {
            Game.LateUpdate();
        }
        private static void OnApplicationQuit()
        {
            Loader.Instance.FixedUpdate -= FixedUpdate;
            Loader.Instance.Update -= Update;
            Loader.Instance.LateUpdate -= LateUpdate;
            Loader.Instance.OnApplicationQuit -= OnApplicationQuit;
            Game.Close();
        }
    }
}