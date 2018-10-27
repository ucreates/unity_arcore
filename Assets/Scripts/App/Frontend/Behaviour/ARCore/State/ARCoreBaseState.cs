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
public abstract class ARCoreBaseState : FiniteState<ARCoreBehaviour> {
    private const int SLEEP_TIMEOUT = 15;
    public override void Update() {
        if (SessionStatus.Tracking != GoogleARCore.Session.Status) {
            Screen.sleepTimeout = ARCoreBaseState.SLEEP_TIMEOUT;
        } else {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
        return;
    }
}
}
