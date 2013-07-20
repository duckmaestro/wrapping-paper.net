
//    This file is part of Wrapping-Paper.NET.
//    Copyright (c) 2013 Clifford Champion
//
//    Distributed for use only under the MIT license. 
//    See LICENSE file for details.
//


using Awesomium.Core;

namespace PaperJS
{
    /// <summary>
    /// The MouseEvent object is received by the Item's mouse event handlers 
    /// item.onMouseDown, Item#onMouseDrag, item.onMouseMove, item.onMouseUp, 
    /// item.onClick, item.onDoubleClick, item.onMouseEnter and 
    /// item.onMouseLeave. The MouseEvent object is the only parameter passed 
    /// to these functions and contains information about the mouse event.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/mouseevent/
    /// </remarks>
    public class MouseEvent : BaseWrapper
    {
        public MouseEvent(JSObject jsMouseEvent)
            : base(jsMouseEvent)
        {
        }

        /// <summary>
        /// The type of mouse event.
        /// </summary>
        public string Type
        {
            get
            {
                JSValue jsType = _jsObject["type"];
                return (string)jsType;
            }
        }

        /// <summary>
        /// The position of the mouse in project coordinates when the event was fired.
        /// </summary>
        public Point Point
        {
            get
            {
                JSObject jsPoint = _jsObject["point"];
                return jsPoint == null ? null : new Point(jsPoint);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Item Target
        {
            get
            {
                JSObject jsTarget = _jsObject["target"];
                return jsTarget == null ? null : new Item(jsTarget);
            }
        }
    }
}
