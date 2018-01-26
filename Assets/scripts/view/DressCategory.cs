
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DressCategory {
    public List<DressContainer> Containers;
}

[Serializable]
public class DressContainer {

    public SpriteRenderer FixedContainer;
    public SpriteRenderer ChangingContainer;
    public Sprite FixedContent;
    public List<Sprite> Contents;
}
