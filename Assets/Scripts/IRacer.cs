using UnityEngine;

public interface IRacer {

    // Control how the racer should handle movement.
    void Move();

    // Control what happens when the racer dies.
    void Die();

    // Control what happens when the racer wins.
    void Win();
}