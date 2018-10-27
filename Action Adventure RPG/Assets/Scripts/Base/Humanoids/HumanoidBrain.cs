using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidBrain : Brain {

    protected CharacterEquipment characterEquipment;

    public override Vector2 MovementVector {
        get {
            return new Vector2();
        }
    }

    public override Vector2 LookVector {
        get {
            return new Vector2();
        }
    }

    protected override void Awake() {
        base.Awake();

        characterEquipment = GetComponent<CharacterEquipment>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
