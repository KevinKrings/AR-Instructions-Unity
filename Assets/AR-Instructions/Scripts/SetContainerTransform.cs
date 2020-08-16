﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetContainerTransform : MonoBehaviour
{
    public StabilizedTracking StabilizedTracking;

    private AnchorObject anchor;
    public void Start()
    {
        StabilizedTracking.MarkerScanned += StabilizedTracking_MarkerScanned;
        StabilizedTracking.MarkerReset += StabilizedTracking_MarkerReset;

        anchor = GetComponent<AnchorObject>();
    }

    private void StabilizedTracking_MarkerReset(object sender, System.EventArgs e)
    {
        transform.SetPositionAndRotation(new Vector3(0, -5, 0), Quaternion.identity);
    }

    private void StabilizedTracking_MarkerScanned(object sender, MarkerScannedEventArgs args)
    {
        transform.SetPositionAndRotation(args.Position, args.Rotation);

        anchor.AttachAnchor();
    }
}
