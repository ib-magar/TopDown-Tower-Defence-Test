using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : LivingEntity
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform targetDestination;
    private Player House;
    [SerializeField] private float stoppingDistance = 1.5f;
    [SerializeField] private float moveSpeed=3.5f;
    private bool hasReachedDestination = false;

    [Header("damage")]
    [SerializeField] private float damageAmount=1;

    protected override void Awake()
    {
        //base.Awake();
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null) return;
        targetDestination = GameObject.FindGameObjectWithTag("House").transform;
        House=targetDestination.GetComponent<Player>();
        if(House==null) return;
        OnDamage.AddListener(House.TakeDamage);
        navMeshAgent.speed = moveSpeed;
    }

    private void Start()
    {
        //OnDeath.AddListener(EconomyManager.Instance.GainCoins);
    }

    private void Update()
    {
        if (targetDestination != null && !hasReachedDestination)
        {
            MoveToTarget();
            CheckIfReachedDestination();
        }
    }

    public void SetSpeed(float speed)
    {
        
        //navMeshAgent.speed = speed;
    }

    public void SetHealth(float health)
    {
       //set health
    }

    private void MoveToTarget()
    {
        navMeshAgent.SetDestination(targetDestination.position);
    }

    private void CheckIfReachedDestination()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= stoppingDistance)
        {
            hasReachedDestination = true;
            OnReachDestination();
        }
    }

    private void OnReachDestination()
    {
        navMeshAgent.isStopped = true; // Stops the NavMeshAgent
       
        PerformActionOnArrival();
    }

    protected virtual void PerformActionOnArrival()
    {

        //Debug.Log("Enemy has reached its destination!");
        OnDamage?.Invoke(damageAmount);
        Die();
    }
    public delegate void EnemyDeathHandler();
    public  UnityEvent OnDeath;
    public  UnityEvent<float> OnDamage;

    public GameObject dieEffect;
    protected override void Die()
    {
        EconomyManager.Instance.GainCoins();
        //Debug.Log("Enemy has been defeated!");
        OnDeath?.Invoke(); // Trigger the death event
        if(dieEffect) Instantiate(dieEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);    
    }
}
