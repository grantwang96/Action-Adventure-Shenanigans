using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerMove : HumanoidMove {

    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable() {
        GameplayController.Instance.JumpPressed += OnJump;
        GameplayController.Instance.DefendPressed += OnDefend;
        GameplayController.Instance.DodgePressed += OnDodge;
        GameplayController.Instance.InteractPressed += OnInteract;
        GameplayController.Instance.AttackPressed += OnAttack;
    }

    private void OnDisable() {
        GameplayController.Instance.JumpPressed -= OnJump;
        GameplayController.Instance.DefendPressed -= OnDefend;
        GameplayController.Instance.DodgePressed -= OnDodge;
        GameplayController.Instance.InteractPressed -= OnInteract;
        GameplayController.Instance.AttackPressed -= OnAttack;
    }

    // Update is called once per frame
    void Update() {

        Look(GameplayController.Instance.LookVector);
        if (!GameplayController.Instance.Preoccupied) {
            Move(GameplayController.Instance.MovementVector);
        }
	}

    protected override void Move(Vector2 move) {
        // do not attempt to move if movement is 0
        if(Mathf.Approximately(move.x, 0f) && Mathf.Approximately(move.y, 0f)) { return; }

        // move the player
        movementVector = move * _speed * Time.deltaTime;
        _rigidbody2D.MovePosition((Vector2)transform.position + movementVector);
    }

    protected override void Look(Vector2 dir) {
        Vector2 look = new Vector2(Mathf.Round(dir.x), Mathf.Round(dir.y));

        // do not attempt to move if movement is 0
        if (Mathf.Approximately(look.x, 0f) && Mathf.Approximately(look.y, 0f)) { return; }

        lookVector = look;
        // TODO: set the appropriate sprite system to reflect animation look vector
    }

    protected override void OnAttack() {
        base.OnAttack();
        Debug.Log("Attack Combo Index: " + GameplayController.Instance.AttackComboIndex);
        SkillData currentAttack = GameplayController.Instance.GetAttackSkillByIndex(GameplayController.Instance.AttackComboIndex);
        currentAttack.OnSkillPressed(GameplayController.Instance);
    }
}
