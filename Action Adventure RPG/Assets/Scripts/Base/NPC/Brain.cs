using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores SkillData, processes AI States, connects to other components of character
/// </summary>
public abstract class Brain : MonoBehaviour {

    protected CharacterStats characterStats; // if it has a brain, it has stats
    protected CharacterMove characterMove; // if it has a brain, it can DO things

    public abstract Vector2 MovementVector { get; }
    public abstract Vector2 LookVector { get; }

    [SerializeField] protected bool _preoccupied;
    public bool Preoccupied { get { return _preoccupied; } }
    private Coroutine characterBusyProcess;

    [SerializeField] protected int _attackComboIndex = 0;
    public int AttackComboIndex { get { return _attackComboIndex; } }

    [SerializeField] protected SkillData[] attackCombo; // the list of combos that the character will use to attack
    public SkillData GetAttackSkillByIndex(int index) { return attackCombo[index]; }
    public SkillData GetCurrentAttackSkill() { return attackCombo[AttackComboIndex]; }
    public delegate void OnSkillUpdate(SkillData newSkill);
    public event OnSkillUpdate UpdateAttackCombo;

    protected virtual void Awake() {
        characterStats = GetComponent<CharacterStats>();
        characterMove = GetComponent<CharacterMove>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void ChangeAttackCombo(SkillData[] newAttackCombo) {
        attackCombo = newAttackCombo;
        // TODO: invoke update attack combo event
    }

    public virtual void PreoccupyCharacter(float duration, bool allowOverride) {
        if (_preoccupied) {
            if (allowOverride) { StopCoroutine(characterBusyProcess); }
            else { return; }
        } 
        characterBusyProcess = StartCoroutine(CharacterBusyRoutine(duration));
    }

    private IEnumerator CharacterBusyRoutine(float duration) {
        _preoccupied = true;
        float time = 0f;
        while(time < duration) {
            time += Time.deltaTime;
            yield return null;
        }
        _preoccupied = false;
        characterBusyProcess = null;
    }
}
