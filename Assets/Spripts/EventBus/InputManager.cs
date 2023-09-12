using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            EventBus.Invoke<IQuickSaveHandler>(handler =>
            {
                handler.HandleQuickSave();
            });
        }
    }
}