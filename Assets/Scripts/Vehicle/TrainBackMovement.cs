using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBackMovement : MonoBehaviour
{
    public TrainFrontMovement trainFrontMovement;
    public float offset = -0.035f;

    // Update is called once per frame
    void Update()
    {
        if (trainFrontMovement == null)
            return;

        var timeTravelled = trainFrontMovement.GetCurrentTimeTravelled() + offset;
        transform.position = trainFrontMovement.pathCreator.path.GetPointAtTime(timeTravelled, trainFrontMovement.endOfPathInstruction);
        transform.rotation = trainFrontMovement.pathCreator.path.GetRotation(timeTravelled, trainFrontMovement.endOfPathInstruction);

    }
}
