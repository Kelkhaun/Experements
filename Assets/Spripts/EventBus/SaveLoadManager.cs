using UnityEngine;

public class SaveLoadManager : MonoBehaviour, IQuickSaveHandler
{
    private void OnEnable()
    {
        EventBus.Subscribe(this);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    public void HandleQuickSave()
    {
        print("вызов сохранения");
    }

    public void HandleQuickLoad()
    {
        print("вызов загрузки");
    }
}