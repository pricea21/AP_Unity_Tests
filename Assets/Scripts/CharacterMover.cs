using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour, ICharacterMover
{
    private CharacterController characterController;

    public int Health { get; set; }

    [SerializeField]
    private bool isPlayer;
    private bool isDead;

    public bool IsPlayer => isPlayer;
    public bool IsDead => isDead;


    private void Start()
    {
        Health = 10;
    }

    /*public void RemoveHealth()
    {
        Health --;
    }*/


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        characterController.Move(new Vector3(horizontal, 0, vertical));
    }
}
