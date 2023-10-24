using System.Runtime.CompilerServices;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public int price=10;
    public float detectionRadius = 10f;
    public LayerMask targetLayer;
    public float rotationSpeed = 5f;
    private Weapon weapon;
    private void Start()
    {
        weapon= GetComponent<Weapon>(); 
    }
    void FixedUpdate()
    {
        Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectionRadius, targetLayer);

        if (detectedObjects.Length > 0)
        {
            Transform targetTransform = detectedObjects[0].transform;
            RotateTowards(targetTransform.position);
            weapon.canShoot = true;
        }
        else
        {
            weapon.canShoot = false;

        }
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - transform.position;
        directionToTarget.y = 0; // Ensure only rotation on the Y-axis

        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
