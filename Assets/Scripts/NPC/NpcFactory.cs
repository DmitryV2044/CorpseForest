using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NpcFactory<T, T1> : IFactory<T> where T : Npc where T1 : NpcConfig
{
    public abstract T Get();
}
