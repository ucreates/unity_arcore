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
public sealed class ARCoreDetectState : ARCoreBaseState {
    private List<DetectedPlane> detectedPlaneList {
        get;
        set;
    }
    public ARCoreDetectState() {
        this.detectedPlaneList = new List<DetectedPlane>();
    }
    public override void Update() {
        base.Update();
        GoogleARCore.Session.GetTrackables<DetectedPlane>(this.detectedPlaneList);
        foreach (DetectedPlane detectedPlane in this.detectedPlaneList) {
            if (detectedPlane.TrackingState != TrackingState.Tracking) {
                continue;
            }
            Parameter parameter = new Parameter();
            parameter.Set<DetectedPlane>("detectedPlane", detectedPlane);
            Notifier notifier = Notifier.GetInstance();
            notifier.Notify(NotifyMessage.OnTrackingFound, parameter);
            this.complete = true;
            break;
        }
        this.detectedPlaneList.Clear();
        return;
    }
}
}
