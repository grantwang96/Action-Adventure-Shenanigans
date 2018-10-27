using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillData : ScriptableObject {

    [SerializeField] protected bool preoccupiesCharacter;

    [SerializeField] protected float duration;
    [SerializeField] protected bool allowOverride;
    
    public virtual void OnSkillPressed(Brain brain) {

    }

    public virtual void OnSkillReleased(Brain brain) {

    }
}
