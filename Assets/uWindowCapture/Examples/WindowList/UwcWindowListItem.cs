﻿using UnityEngine;
using UnityEngine.UI;

namespace uWindowCapture
{

public class UwcWindowListItem : MonoBehaviour 
{
    public UwcWindow window { get; set; }
    public UwcWindowList list { get; set; }
    public UwcWindowObject windowObject { get; set; }
    
    [SerializeField] RawImage icon;
    [SerializeField] Text title;
    [SerializeField] Text x;
    [SerializeField] Text y;
    [SerializeField] Text z;
    [SerializeField] Text width;
    [SerializeField] Text height;
    [SerializeField] Text status;

    void Update()
    {
        if (window == null) return;

        if (!window.hasIconTexture && !window.isIconic) {
            icon.texture = window.texture;
        } else {
            icon.texture = window.iconTexture;
        }

        var windowTitle = window.title;
        title.text = string.IsNullOrEmpty(windowTitle) ? "-No Name-" : windowTitle;

        x.text = window.x.ToString();
        y.text = window.y.ToString();
        z.text = window.zOrder.ToString();

        width.text = window.width.ToString();
        height.text = window.height.ToString();

        status.text = 
            window.isIconic ? "Iconic" :
            window.isZoomed ? "Zoomed" :
            "-";
    }

    public void OnClick()
    {
        var manager = list.windowObjectManager;
        if (windowObject == null) {
            windowObject = manager.AddWindowObject(window);
        } else {
            manager.RemoveWindowObject(window);
            windowObject = null;
        }
    }
}

}