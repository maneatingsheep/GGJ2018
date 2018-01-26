
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DressCategory {
    public List<DressContainer> Containers;
}

[Serializable]
public class DressContainer {

    public SpriteRenderer Container;
    public List<Sprite> Contents;
}
