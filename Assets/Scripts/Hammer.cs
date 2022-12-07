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

        Debug.Log($"plankposition is {_plankPosition} and plankscale is {_plankScale}");

        Collider[] hitColliders = Physics.OverlapBox(_plankPosition, collision.transform.localScale / 2, Quaternion.identity);

        int i = 0;

        while (i < hitColliders.Length)
        {
            Debug.Log("Hit : " + hitColliders[i].name + i);
            
            // TODO: call Shake method on each object found and only procecss object if it has shake script on it

            i++;
        }
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
     
        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
         Gizmos.DrawWireCube(_plankPosition, _plankScale);
    }
}
