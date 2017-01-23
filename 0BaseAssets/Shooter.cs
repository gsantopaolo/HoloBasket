using UnityEngine;
using System.Collections;
using UnityEngine.VR.WSA.Input;

public class Shooter : MonoBehaviour
{
    public Rigidbody prefab;
    public float speed = 10.0f;

    private GestureRecognizer gestureRecognizer;

    void Start()
    {
        //Create a new GestureRecognizer.Sign up for tapped events.

      gestureRecognizer = new GestureRecognizer();
      gestureRecognizer.SetRecognizableGestures(GestureSettings.Tap);

        gestureRecognizer.TappedEvent += GestureRecognizer_TappedEvent;

        // Start looking for gestures.
        gestureRecognizer.StartCapturingGestures();
    }

    private void GestureRecognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        var obj = (Rigidbody)Instantiate(prefab, Camera.main.transform.position, Camera.main.transform.rotation);
        obj.velocity = (Camera.main.transform.forward) * speed;
    }

    void OnDestroy()
    {
        gestureRecognizer.StopCapturingGestures();
        gestureRecognizer.TappedEvent -= GestureRecognizer_TappedEvent;
    }
}
