﻿public interface ICharacterMover
{
    int Health { get; set; }
    bool IsPlayer { get; }
    bool IsDead { get; }
}