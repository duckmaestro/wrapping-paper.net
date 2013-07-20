
//    This file is part of Wrapping-Paper.NET.
//    Copyright (c) 2013 Clifford Champion
//
//    Distributed for use only under the MIT license. 
//    See LICENSE file for details.
//


using Awesomium.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaperJS
{
    /// <summary>
    /// The Item type allows you to access and modify the items in Paper.js 
    /// projects. Its functionality is inherited by different project item 
    /// types such as Path, CompoundPath, Group, Layer and Raster. They each 
    /// add a layer of functionality that is unique to their type, but share 
    /// the underlying properties and functions that they inherit from Item.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/item/
    /// </remarks>
    public class Item : BaseWrapper
    {

        public Item(JSObject jsItem)
            : base(jsItem)
        {
        }

        /// <summary>
        /// The unique id of the item.
        /// Read only.
        /// </summary>
        public int Id
        {
            get
            {
                JSValue jsId = _jsObject["id"];
                return (int)jsId;
            }
        }

        /// <summary>
        /// The type of the item as a string.
        /// Read only.
        /// </summary>
        public string Type
        {
            get
            {
                JSValue jsType = _jsObject["type"];
                return jsType.IsString ? (string)jsType : null;
            }
        }

        /// <summary>
        /// The name of the item. If the item has a name, it can be accessed 
        /// by name through its parent's children list.
        /// </summary>
        public string Name
        {
            get
            {
                JSValue jsName = _jsObject["name"];
                return jsName.IsString ? (string)jsName : null;
            }
            set
            {
                _jsObject["name"] = value;
            }
        }

        /// <summary>
        /// The path style of the item.
        /// </summary>
        public object Style
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Specifies whether the item is visible. When set to false, the item 
        /// won't be drawn.
        /// </summary>
        public bool Visible
        {
            get
            {
                JSValue jsVisible = _jsObject["visible"];
                return (bool)jsVisible;
            }
            set
            {
                _jsObject["visible"] = value;
            }
        }

        /// <summary>
        /// Specifies whether an item is selected and will also return
        /// true if the item is partially selected (groups with some
        /// selected or partially selected paths).
        /// 
        /// Paper.js draws the visual outlines of selected items on
        /// top of your project. This can be useful for debugging, as
        /// it allows you to see the construction of paths, position
        /// of path curves, individual segment points and bounding
        /// boxes of symbol and raster items.
        /// </summary>
        public bool Selected
        {
            get
            {
                JSValue jsSelected = _jsObject["selected"];
                return (bool)jsSelected;
            }
            set
            {
                _jsObject["selected"] = value;
            }
        }

        /// <summary>
        /// Specifies whether the item defines a clip mask. This can only be 
        /// set on paths, compound paths, and text frame objects, and only if 
        /// the item is already contained within a clipping group.
        /// </summary>
        public bool ClipMask
        {
            get
            {
                JSValue jsClipMask = _jsObject["clipMask"];
                return (bool)jsClipMask;
            }
            set
            {
                _jsObject["clipMask"] = value;
            }
        }

        /// <summary>
        /// A plain javascript object which can be used to store arbitrary 
        /// data on the item.
        /// </summary>
        public JSObject Data
        {
            get
            {
                JSObject jsData = _jsObject["data"];
                return jsData;
            }
            set
            {
                _jsObject["data"] = value;
            }
        }

        /// <summary>
        /// The item's position within the project. This is the 
        /// rectangle.center of the item's bounds rectangle.
        /// </summary>
        public Point Position
        {
            get
            {
                JSObject jsPosition = _jsObject["position"];
                return jsPosition == null ? null : new Point(jsPosition);
            }
            set
            {
                _jsObject["position"] = value;
            }
        }

        /// <summary>
        /// The item's transformation matrix, defining position and dimensions 
        /// in the document.
        /// </summary>
        public Matrix Matrix
        {
            get
            {
                JSObject jsMatrix = _jsObject["matrix"];
                return jsMatrix == null ? null : new Matrix(jsMatrix);
            }
            set
            {
                _jsObject["matrix"] = value;
            }
        }

        /// <summary>
        /// The bounding rectangle of the item excluding stroke width.
        /// Read only.
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                JSObject jsBounds = _jsObject["bounds"];
                return jsBounds == null ? null : new Rectangle(jsBounds);
            }
            set
            {
                _jsObject["bounds"] = value;
            }
        }

        /// <summary>
        /// The project that this item belongs to.
        /// Read only.
        /// </summary>
        public Project Project
        {
            get
            {
                JSObject jsProject = _jsObject["project"];
                return jsProject == null ? null : new Project(jsProject);
            }
        }

        /// <summary>
        /// The layer that this item is contained within.
        /// Read only.
        /// </summary>
        public Layer Layer
        {
            get
            {
                JSObject jsLayer = _jsObject["layer"];
                return jsLayer == null ? null : new Layer(jsLayer);
            }
        }

        /// <summary>
        /// The item that this item is contained within.
        /// </summary>
        public Item Parent
        {
            get
            {
                JSObject jsParent = _jsObject["parent"];
                return jsParent == null ? null : new Item(jsParent);
            }
            set
            {
                _jsObject["parent"] = value;
            }
        }
        
        /// <summary>
        /// The children items contained within this item. Items that define a 
        /// name can also be accessed by name.
        /// Please note: The children array should not be modified directly 
        /// using array functions. To remove single items from the children 
        /// list, use item.remove(), to remove all items from the children 
        /// list, use item.removeChildren(). To add items to the children 
        /// list, use item.addChild(item) or item.insertChild(index, item).
        /// </summary>
        public IEnumerable<Item> Children
        {
            get
            {
                JSValue[] jsChildren = (JSValue[])_jsObject["children"];
                return jsChildren.Cast<JSObject>().Select(c => new Item(c));
            }
        }

        /// <summary>
        /// The index of this item within the list of its parent's children.
        /// Read only.
        /// </summary>
        public int Index
        {
            get
            {
                JSValue jsIndex = _jsObject["index"];
                return (int)jsIndex;
            }
        }

        /// <summary>
        /// The color of the stroke.
        /// </summary>
        public Color StrokeColor
        {
            get
            {
                JSObject jsStrokeColor = _jsObject["strokeColor"];
                return jsStrokeColor == null ? null : new Color(jsStrokeColor);
            }
            set
            {
                _jsObject["strokeColor"] = value;
            }
        }

        /// <summary>
        /// The width of the stroke.
        /// </summary>
        public double StrokeWidth
        {
            get
            {
                JSValue jsStrokeWidth = _jsObject["strokeWidth"];
                return (double)jsStrokeWidth;
            }
            set
            {
                _jsObject["strokeWidth"] = value;
            }
        }

        /// <summary>
        /// The fill color of the item.
        /// </summary>
        public Color FillColor
        {
            get
            {
                JSObject jsFillColor = _jsObject["fillColor"];
                return jsFillColor == null ? null : new Color(jsFillColor);
            }
            set
            {
                _jsObject["fillColor"] = value;
            }
        }

        /// <summary>
        /// The color the item is highlighted with when selected. If the item 
        /// does not specify its own color, the color defined by its layer is 
        /// used instead.
        /// </summary>
        public Color SelectedColor
        {
            get
            {
                JSObject jsSelectedColor = _jsObject["selectedColor"];
                return jsSelectedColor == null ? null : new Color(jsSelectedColor);
            }
            set
            {
                _jsObject["selectedColor"] = value;
            }
        }

        /// <summary>
        /// Item level handler function to be called on each frame of an 
        /// animation.
        /// The function receives an event object which contains information 
        /// about the frame event:
        /// event.count: the number of times the frame event was fired.
        /// event.time: the total amount of time passed since the first frame 
        /// event in seconds.
        /// event.delta: the time passed in seconds since the last frame event.
        /// </summary>
        public Action<FrameEvent> OnFrame
        {
            set
            {
                if (value != null)
                {
                    _jsObject.Bind("OnFrame", false, delegate(object sender, JavascriptMethodEventArgs args)
                    {
                        JSObject jsArg0 = args.Arguments[0];
                        FrameEvent frameEvent = new FrameEvent(jsArg0);
                        value(frameEvent);
                    });
                }
                else
                {
                    _jsObject.RemoveProperty("OnFrame");
                }
            }
        }

        /// <summary>
        /// The function to be called when the mouse button is pushed down on 
        /// the item. The function receives a MouseEvent object which contains 
        /// information about the mouse event.
        /// </summary>
        public Action<MouseEvent> OnMouseDown
        {
            set
            {
                if (value != null)
                {
                    _jsObject.Bind("onMouseDown", false, delegate(object sender, JavascriptMethodEventArgs args)
                    {
                        JSObject jsArg0 = args.Arguments[0];
                        MouseEvent mouseEvent = new MouseEvent(jsArg0);
                        value(mouseEvent);
                    });
                }
                else
                {
                    _jsObject.RemoveProperty("onMouseDown");
                }
            }
        }

        /// <summary>
        /// The function to be called when the mouse button is released over 
        /// the item. The function receives a MouseEvent object which contains 
        /// information about the mouse event.
        /// </summary>
        public Action<MouseEvent> OnMouseUp
        {
            set
            {
                if (value != null)
                {
                    _jsObject.Bind("onMouseUp", false, delegate(object sender, JavascriptMethodEventArgs args)
                    {
                        JSObject jsArg0 = args.Arguments[0];
                        MouseEvent mouseEvent = new MouseEvent(jsArg0);
                        value(mouseEvent);
                    });
                }
                else
                {
                    _jsObject.RemoveProperty("onMouseUp");
                }
            }
        }

        /// <summary>
        /// The function to be called when the mouse clicks on the item. The 
        /// function receives a MouseEvent object which contains information 
        /// about the mouse event.
        /// </summary>
        public Action<MouseEvent> OnClick
        {
            set
            {
                if (value != null)
                {
                    _jsObject.Bind("onClick", false, delegate(object sender, JavascriptMethodEventArgs args)
                    {
                        JSObject jsArg0 = args.Arguments[0];
                        MouseEvent mouseEvent = new MouseEvent(jsArg0);
                        value(mouseEvent);
                    });
                }
                else
                {
                    _jsObject.RemoveProperty("onClick");
                }
            }
        }

        /// <summary>
        /// The function to be called repeatedly when the mouse moves on top 
        /// of the item. The function receives a MouseEvent object which 
        /// contains information about the mouse event.
        /// </summary>
        public Action<MouseEvent> OnMouseMove
        {
            set
            {
                if (value != null)
                {
                    _jsObject.Bind("onMouseMove", false, delegate(object sender, JavascriptMethodEventArgs args)
                    {
                        JSObject jsArg0 = args.Arguments[0];
                        MouseEvent mouseEvent = new MouseEvent(jsArg0);
                        value(mouseEvent);
                    });
                }
                else
                {
                    _jsObject.RemoveProperty("onMouseMove");
                }
            }
        }

        /// <summary>
        /// Specifies wether the item has any content or not. 
        /// The meaning of what content is differs from type to 
        /// type. For example, a Group with no children, a 
        /// TextItem with no text content and a Path with no 
        /// segments all are considered empty.
        /// </summary>
        public bool IsEmpty()
        {
            return _jsObject.Invoke("isEmpty");
        }

        /// <summary>
        /// Checks wether the item's geometry contains the given point.
        /// </summary>
        public bool Contains(Point point)
        {
            return _jsObject.Invoke("contains", point);
        }

        /// <summary>
        /// Adds the specified item as a child of this item at the end of
        /// the its children list. You can use this function for groups, 
        /// compound paths and layers.
        /// </summary>
        public void AddChild(Item item)
        {
            _jsObject.Invoke("addChild", item);
        }

        /// <summary>
        /// Checks whether the specified item is a child of the item.
        /// </summary>
        public bool IsChild(Item item)
        {
            return _jsObject.Invoke("isChild", item);
        }
    }
}
