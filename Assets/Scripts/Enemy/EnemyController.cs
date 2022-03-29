using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(SphereCollider))]
public class EnemyController : MonoBehaviour
{
    #region PRIVATE VARIABLE
    [SerializeField] private GameObject _player;
    [SerializeField] private SwitchSceneManager _switchSM;
    [SerializeField] private string _sceneToLoadOnAttack;

    [SerializeField] private float _minPlayerDistanceToAttack = 0.75f;
    [SerializeField] private float _walkSpeed = 2.5f;
    [SerializeField] private float _runSpeed = 3.5f;

    [SerializeField] private bool _canPatrol = true;
    [SerializeField] private Transform[] _wayPointList;


    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private Transform _currentTarget;
    private SphereCollider _sphereCollider;

    public Transform Target
    {
        get { return _currentTarget; }
    }

    private bool _onPursuit = false;
    private bool _onAttack = false;
    #endregion

    #region BUILTIN METHOD
    void Start()
    {
        _animator = GetComponent<Animator>();
        _sphereCollider = GetComponent<SphereCollider>();
    }

    
    void Update()
    {
        Locomotion();
        Attack();
        UpdateAnimator();
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_player && other.gameObject == _player)
        {
            _onPursuit = true;
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (_player && other.gameObject == _player)
            _onPursuit = false;
    }

    #endregion

    #region CUSTOM METHOD
    private void Locomotion()
    {
        if (_onAttack == false)
        {
            if (_onPursuit && _player && _navMeshAgent)
            {
                // L'ennemi se met à courrir
                _navMeshAgent.speed = _runSpeed;
                // Il va vers le joueur
                _navMeshAgent.destination = _player.transform.position;
            }
            else if(_canPatrol) // Gestion de la ronde
            {
                // si pas de destination ou destination atteinte
                if (_currentTarget == null
                    || (_currentTarget.position.x == transform.position.x && _currentTarget.position.z == transform.position.z))
                {
                    // Choix de la prochaine destination aléatoirement
                    ChooseRandomTarget();
                }
                if (_navMeshAgent)
                {
                    // L'ennemi marche
                    _navMeshAgent.speed = _walkSpeed;
                    // Assignation de la destination
                    _navMeshAgent.destination = _currentTarget.position;
                }
            }
        }
        else
            // L'ennemi de bouge pas losqu'il attaque
            _navMeshAgent.destination = transform.position;

    }

    private void Attack()
    {
        // Calcul la distance du player
        float playerDistance = Vector3.Distance(_player.transform.position, transform.position);
        // Test si le player est à portée
        _onAttack = playerDistance <= _minPlayerDistanceToAttack ? true : false;
        if (_onAttack && _switchSM != null && _sceneToLoadOnAttack != null)
        {
            _switchSM.GotoScene(_sceneToLoadOnAttack);
        }
        
    }

    private void UpdateAnimator()
    {
        // Récupération de la vitesse du point de vue de l'ennemi (et non du monde)
        Vector3 localVelocity = transform.InverseTransformDirection(_navMeshAgent.velocity);
        // Envoi la vitesse au blend tree
        _animator.SetFloat("forwardSpeed", localVelocity.z);

    }

    private void ChooseRandomTarget()
    {
        if (_wayPointList!= null && _wayPointList.Length > 1)
        {
            Transform futurTarget = _wayPointList[Random.Range(0, _wayPointList.Length)];
            if (_currentTarget != null)
            {
                // Recherche aléatoirement une prochaine destination de ronde qui n'est pas celle où l'on est déja
                while (futurTarget == _currentTarget)
                {
                    futurTarget = _wayPointList[Random.Range(0, _wayPointList.Length)];
                }
            }
            _currentTarget = futurTarget;
        }
    }
    #endregion
}
