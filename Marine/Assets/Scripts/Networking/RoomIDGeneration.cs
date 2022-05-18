using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomIDGeneration
{
    public string ID { get; private set; }

    public void CreateRandomStringID()
    {
        Guid newID = Guid.NewGuid();
        ID = newID.ToString();
    }
}