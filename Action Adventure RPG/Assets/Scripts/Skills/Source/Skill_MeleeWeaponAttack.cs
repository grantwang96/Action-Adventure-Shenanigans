using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/MeleeAttack")]
public class Skill_MeleeWeaponAttack : SkillData {

    public GameObject markerPrefab;

    public enum EffectiveRange {
        Single, AOE, Line
    }
    [SerializeField] private EffectiveRange effectiveRange;
    [SerializeField] private float reach;

    public override void OnSkillPressed(Brain brain) {
        switch (effectiveRange) {
            case EffectiveRange.Single:
                SingleDirectionalHit(brain);
                break;
            case EffectiveRange.AOE:
                AreaOfEffectHit(brain);
                break;
            case EffectiveRange.Line:
                LineHit(brain);
                break;
            default:
                Debug.LogWarning("Effective range not defined for skill: " + name);
                break;
        }
        if (preoccupiesCharacter) { brain.PreoccupyCharacter(duration, allowOverride); }
    }

    private void SingleDirectionalHit(Brain brain) {
        Vector2 characterPosition = brain.transform.localPosition;
        Vector2 newPosition = characterPosition + brain.LookVector;

        Destroy(Instantiate(markerPrefab, newPosition, Quaternion.identity), 1f);
    }

    private void AreaOfEffectHit(Brain brain) {

    }

    private void LineHit(Brain brain) {

    }
}
