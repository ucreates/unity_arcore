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
using UnityEngine.UI;
namespace Core.Scene {
public class Runtime {
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void OnLoad() {
        UnityEngine.Screen.SetResolution(640, 1136, true);
        return;
    }
}
}
