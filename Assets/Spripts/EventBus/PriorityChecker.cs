using UnityEngine;

public class PriorityChecker : MonoBehaviour, IQuickSaveHandler
{
    private void OnEnable()
    {
        EventBus.Subscribe(this, 7);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    public void HandleQuickSave()
    {
        print("вызов сохранения Priority Checker");
    }

    public void HandleQuickLoad()
    {
        print("вызов загрузки");
    }
}