﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManagable {
    void Initialize();
    void PostInitialize();
    void Refresh(float dt);
    void PhysicsRefresh(float fdt);
}
