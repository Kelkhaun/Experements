using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            EventBus.RaiseEvent<IQuickSaveHandler>(handler =>
            {
                handler.HandleQuickSave();
                handler.HandleQuickLoad();
            });
        }
    }
}