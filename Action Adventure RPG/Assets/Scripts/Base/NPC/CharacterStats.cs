using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    // these are the raw stats of the character(without equipment/effect bonuses)
    private int _attack;
    public int Attack { get { return _attack; } }
    private int _defense;
    public int Defend { get { return _defense; } }
    private int _magicAttack;
    public int MagicAttack { get { return _magicAttack; } }
    private int _magicDefense;
    public int MagicDefense { get { return _magicDefense; } }
    private int _speed;
    public int Speed { get { return _speed; } }
    private int _charisma;
    public int Charisma { get { return _charisma; } }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
