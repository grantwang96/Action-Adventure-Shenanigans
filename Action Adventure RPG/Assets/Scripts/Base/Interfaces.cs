using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable {
    // TODO: include element type
    void TakeDamage(int damage, Vector2 dir, float force);
}

public interface IInteractable {
    void Interact();
}
