using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomGeneration
{
    public static string CreateRandomStringID()
    {
        Guid ID = Guid.NewGuid();
        return ID.ToString();
    }
}