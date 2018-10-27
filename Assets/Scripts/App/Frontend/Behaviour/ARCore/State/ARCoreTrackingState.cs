//======================================================================
// Project Name    : unity_arcore
//
// Copyright © 2018 U-CREATES. All rights reserved.
//
// This source code is the property of U-CREATES.
// If such findings are accepted at any time.
// We hope the tips and helpful in developing.
//======================================================================
using UnityEngine;
using System.Collections.Generic;
using GoogleARCore;
using Frontend.Notify;
using Frontend.Component.State;
using Core.Entity;
using Core.Device.Touch;
namespace Frontend.Behaviour.State {
public sealed class ARCoreTrackingState : ARCoreBaseState {
    public override void Update() {
        base.Update();
        TouchEntity entity = TouchHandler.Pop();
        if (0 == entity.touchPositionList.Count || TouchPhase.Began != entity.touchPhase) {
            return;
        }
        Vector3 touchPosition = entity.touchPositionList[0];
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon | TrackableHitFlags.FeaturePointWithSurfaceNormal;
        if (false == Frame.Raycast(touchPosition.x, touchPosition.y, raycastFilter, out hit)) {
            return;
        }
        Vector3 lhs = UnityEngine.Camera.main.transform.position - hit.Pose.position;
        Vector3 rhs = hit.Pose.rotation * Vector3.up;
        float dot = Vector3.Dot(lhs, rhs);
        if (false == (false != (hit.Trackable is DetectedPlane) && dot < 0)) {
            Notifier notifier = Notifier.GetInstance();
            notifier.Notify(NotifyMessage.OnRaycastHit);
        }
        return;
    }
}
}
