using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMove : MonoBehaviour {

    [SerializeField] protected float _speed;

    protected Brain _brain;
    protected Rigidbody2D _rigidbody2D;
    protected Collider2D _collider2D;
    
    [SerializeField] protected Vector2 movementVector;
    [SerializeField] protected Vector2 lookVector;

    protected virtual void Awake() {

        // initialize components
        _brain = GetComponent<Brain>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    protected abstract void Move(Vector2 dir);

    protected abstract void Look(Vector2 dir);
    
    protected virtual void OnJump() {
        Debug.Log("Character Move has detected jump has been pressed");
    }

    protected virtual void OnDefend() {
        Debug.Log("Character Move has detected defend has been pressed");
    }

    protected virtual void OnDodge() {
        Debug.Log("Character Move has detected dodge has been pressed");
    }

    protected virtual void OnInteract() {
        Debug.Log("Character Move has detected interact has been pressed");
    }

    protected virtual void OnAttack() {
        Debug.Log("Character Move has detected attack has been pressed");
    }

}
