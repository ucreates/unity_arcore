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
using Frontend.Notify;
using Frontend.Component.State;
using Frontend.Component.Property;
using Frontend.Behaviour;
using Frontend.Behaviour.State;
using Frontend.Behaviour.Base;
using Core.Entity;
public class ARCoreBehaviour : BaseBehaviour, IStateMachine<ARCoreBehaviour>, INotify {
    public FiniteStateMachine<ARCoreBehaviour> stateMachine {
        get;
        set;
    }
    void Start() {
        this.property = new BaseProperty(this);
        this.stateMachine = new FiniteStateMachine<ARCoreBehaviour>(this);
        this.stateMachine.Add("detect", new ARCoreDetectState());
        this.stateMachine.Add("tracking", new ARCoreTrackingState());
        this.stateMachine.Stop();
        Notifier notifier = Notifier.GetInstance();
        notifier.Add(this, this.property);
        return;
    }
    void Update() {
        this.stateMachine.Update();
        return;
    }
    public void OnNotify(NotifyMessage notifyMessage, Parameter parameter = null) {
        if (NotifyMessage.OnLoadingComplete == notifyMessage) {
            this.stateMachine.Change("detect");
            this.stateMachine.Play();
        } else if (NotifyMessage.OnIconShowComplete == notifyMessage) {
            this.stateMachine.Change("tracking");
            this.stateMachine.Play();
        }
    }
}
