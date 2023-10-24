using UnityEngine;
using UnityEngine.UI;

public class BaseInputManager : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask detectionLayer;
    private Vector3 foundPosition;
    private Transform foundBase;
    private bool canHit=true;
    private void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, detectionLayer) && canHit)
            {
                foundBase = hit.transform;
                 foundPosition = hit.transform.position;
                spawnUI();
                canHit = false;
            }
        }
    }


    [SerializeField] BaseSelectionUI selectionUI;
    public void spawnUI()
    {
        BaseSelectionUI _selectionUI = Instantiate(selectionUI);
        _selectionUI.inputManager = this;
        /*foreach(Button button in _selectionUI.options)
        {
            button.onClick.AddListener(()=>spawnMachine(1));
        }*/
    }
   

    [SerializeField] GameObject[] machines;
    public void spawnMachine(int option)
    {
        canHit = true;
        if (EconomyManager.Instance.CheckPrice(machines[option].GetComponent<Machine>().price))
        {
        foundBase.gameObject.SetActive(false);
        GameObject machine = Instantiate(machines[option], foundPosition, Quaternion.identity);

        }
        return;
        //machine init
    }
}
