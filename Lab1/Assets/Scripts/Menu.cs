using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : PersistentSingleton<Menu>
{
    [SerializeField] private Button saveBtn;
    [SerializeField] private Button loadBtn;

    private void Start()
    {
        saveBtn.onClick.AddListener(() =>
        {
            SaveLoadSystem.instance.gameData.fileName = "Menu";//Be able to use UI Input Fields to save the file name
            SaveLoadSystem.Instance.gameData.sceneName = "SampleScene";
            SaveLoadSystem.Instance.SaveGame();
        });

        loadBtn.onClick.AddListener(() =>
        {
            SaveLoadSystem.Instance.LoadGame("Menu");

        });
    }
}