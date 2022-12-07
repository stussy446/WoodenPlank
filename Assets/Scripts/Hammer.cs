using UnityEngine;

public class Hammer : MonoBehaviour
{
    private Vector3 _plankPosition;
    private Vector3 _plankScale;

    private void OnCollisionEnter(Collision collision)
    {
        _plankPosition = collision.transform.position;
        _plankPosition.y += 0.5f;
        _plankScale = collision.transform.localScale;

        // create overlapbox just above the wooden plank, across the entirety of the plank
        Collider[] hitColliders = Physics.OverlapBox(_plankPosition, collision.transform.localScale / 2, Quaternion.identity);

        ShakeHitObjects(hitColliders);
    }

    /// <summary>
    /// Goes through all the colliders detected by the OverlapBox and calls on them to start shaking
    /// </summary>
    /// <param name="hitColliders">Collider[]</param>
    private void ShakeHitObjects(Collider[] hitColliders)
    {
        int i = 0;
        while (i < hitColliders.Length)
        {
            Shaker hitObjectShaker = hitColliders[i].GetComponent<Shaker>();

            if (hitObjectShaker != null)
            {
                hitObjectShaker.StartShaking();
            }

            i++;
        }

    }
}
