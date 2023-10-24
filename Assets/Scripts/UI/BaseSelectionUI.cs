
using UnityEngine;
using UnityEngine.UI;

public class BaseSelectionUI : MonoBehaviour
{

    public Button[] options;

    [HideInInspector] public BaseInputManager inputManager;
    public void spawnMachine(int machineIndex)
    {
        
        inputManager.spawnMachine(machineIndex);    
        Destroy(gameObject);    
       
    }

}
