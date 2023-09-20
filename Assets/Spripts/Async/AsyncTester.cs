using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class AsyncTester : MonoBehaviour
{
    private CancellationTokenSource _cancellationToken = new();

    private void Start()
    {
        StartWaitAsync();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _cancellationToken?.Cancel();
    }

    private async UniTaskVoid StartWaitAsync()
    {
        var i = StartReturnIntAsync();
        await UniTask.Delay(TimeSpan.FromSeconds(3), cancellationToken: _cancellationToken.Token);
        print("Done! - " + i);}
    
    private async UniTask<int> StartReturnIntAsync()
    {
        return 5;
    }
}