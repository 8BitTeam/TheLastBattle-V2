using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedModel
{
    private MainModel main;
    private List<CreepModel> creeps;

    public SavedModel()
    {
        main = new MainModel();
        creeps = new List<CreepModel>();
    }

    public MainModel Main { get { return main; } }
    public List<CreepModel> Creeps { get { return creeps; } }
}
