using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuickSaveHandler : IGlobalSubscriber
{
   void HandleQuickSave();
   void HandleQuickLoad();}