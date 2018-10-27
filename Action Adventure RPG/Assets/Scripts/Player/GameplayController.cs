using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The input system that handles the main overworld gameplay
/// </summary>
public class GameplayController : HumanoidBrain {

    // allows other classes to access via singleton
    public static GameplayController Instance;

    // saves the horizontal and vertical inputs
    [SerializeField] private Vector2 _movementVector;
    public override Vector2 MovementVector { get { return _movementVector; } }
    [SerializeField] private Vector2 _lookVector = Vector2.down;
    public override Vector2 LookVector { get { return _lookVector; } }

    // events that fire when gameplay buttons are pressed
    public delegate void OnButtonAction();

    public event OnButtonAction JumpPressed;
    public event OnButtonAction DefendPressed;
    public event OnButtonAction DodgePressed;
    public event OnButtonAction InteractPressed;
    public event OnButtonAction AttackPressed;

    // events that listen for skill button presses and releases
    public event OnButtonAction Skill1Pressed;
    public event OnButtonAction Skill1Released;
    public event OnButtonAction Skill2Pressed;
    public event OnButtonAction Skill2Released;
    public event OnButtonAction Skill3Pressed;
    public event OnButtonAction Skill3Released;
    public event OnButtonAction Skill4Pressed;
    public event OnButtonAction Skill4Released;

    // event that listens for the menu button
    public event OnButtonAction MenuPressed;

    protected override void Awake() {
        base.Awake();
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        CoreInputs();
        // SkillInputs();
	}

    private void CoreInputs() {
        // collect the movement input
        _movementVector.x = Input.GetAxis("Horizontal");
        _movementVector.y = Input.GetAxis("Vertical");

        // set look vector
        Vector2 tempLookVector = LookVector;
        _lookVector.x = Input.GetAxisRaw("Horizontal");
        _lookVector.y = Input.GetAxisRaw("Vertical");
        if(Mathf.Approximately(LookVector.x ,0f) && (Mathf.Approximately(LookVector.y, 0f))) { _lookVector = tempLookVector; }

        if (Input.GetButtonDown("Jump")) { Jump(); }
        if (Input.GetButtonDown("Defend")) { Defend(); }
        if (Input.GetButtonDown("Dodge")) { Dodge(); }
        if (Input.GetButtonDown("Interact")) { Interact(); }
        if (Input.GetButtonDown("Attack")) { Attack(); }
    }

    private void SkillInputs() {
        if (Input.GetButtonDown("Skill1")) { Skill1Pressed.Invoke(); }
        else if (Input.GetButtonUp("Skill1")) { Skill1Released.Invoke(); }

        if (Input.GetButtonDown("Skill2")) { Skill2Pressed.Invoke(); }
        else if (Input.GetButtonUp("Skill2")) { Skill2Released.Invoke(); }

        if (Input.GetButtonDown("Skill3")) { Skill3Pressed.Invoke(); }
        else if (Input.GetButtonUp("Skill3")) { Skill3Released.Invoke(); }

        if (Input.GetButtonDown("Skill4")) { Skill4Pressed.Invoke(); }
        else if (Input.GetButtonUp("Skill4")) { Skill4Released.Invoke(); }
    }

    private void Jump() {
        JumpPressed.Invoke();
    }

    private void Defend() {
        DefendPressed.Invoke();
    }

    private void Dodge() {
        DodgePressed.Invoke();
    }

    private void Interact() {
        InteractPressed.Invoke();
    }

    private void Attack() {
        if (Preoccupied) {
            return;
        }
        AttackPressed.Invoke();
        _attackComboIndex++;
        if(_attackComboIndex >= attackCombo.Length) { _attackComboIndex = 0; }
    }
}
