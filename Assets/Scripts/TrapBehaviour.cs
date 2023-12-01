using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    [SerializeField] 
    private TrapTargetType trapType;
    private Trap trap;

    private void Awake()
    {
        trap = new Trap();
    }

    private void OnTriggerEnter(Collider other)
    {
        var characterMover = other.GetComponent<ICharacterMover>();
        trap.HandleCharacterEntered(characterMover, trapType);
    }
}

public class Trap
{
    public void HandleCharacterEntered(ICharacterMover characterMover, TrapTargetType trapTargetType)
    {
        if (characterMover.IsPlayer)
        {
            if (trapTargetType == TrapTargetType.Player)
                characterMover.Health--;
        }
        else
        {
            if (trapTargetType == TrapTargetType.NPC)
                characterMover.Health--;
        }

        if (characterMover.IsDead)
        {
            if (trapTargetType == TrapTargetType.Dead)
                characterMover.Health = 0;
        }
        else
        {
            if (trapTargetType == TrapTargetType.Ghost)
                characterMover.Health = 0;
        }
    }
}

public enum TrapTargetType { Player, NPC, Dead, Ghost }
