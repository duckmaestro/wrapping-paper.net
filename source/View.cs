
//    This file is part of Wrapping-Paper.NET.
//    Copyright (c) 2013 Clifford Champion
//
//    Distributed for use only under the MIT license. 
//    See LICENSE file for details.
//


using Awesomium.Core;
using System;

namespace PaperJS
{
    /// <summary>
    /// The View object wraps an HTML element and handles drawing and user 
    /// interaction through mouse and keyboard for it. It offer means to 
    /// scroll the view, find the currently visible bounds in project 
    /// coordinates, or the center, both useful for constructing artwork 
    /// that should appear centered on screen.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/view/
    /// </remarks>
    public class View : BaseWrapper
    {
        public View(JSObject jsView)
            : base(jsView)
        {
        }

        /// <summary>
        /// The underlying native element. Read only.
        /// </summary>
        public object Element
        {
            get
            {
                return _jsObject["element"];
            }
        }

        /// <summary>
        /// The size of the view. Changing the view's size will resize it's 
        /// underlying element.
        /// </summary>
        public Size ViewSize
        {
            get
            {
                JSObject jsViewSize = _jsObject["viewSize"];
                return jsViewSize == null ? null : new Size(jsViewSize);
            }
        }

        /// <summary>
        /// The bounds of the currently visible area in project coordinates. 
        /// Read only.
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                JSObject jsBounds = _jsObject["bounds"];
                return jsBounds == null ? null : new Rectangle(jsBounds);
            }
        }

        /// <summary>
        /// The size of the visible area in project coordinates. Read only.
        /// </summary>
        public Size Size
        {
            get
            {
                JSObject jsSize = _jsObject["size"];
                return jsSize == null ? null : new Size(jsSize);
            }
        }

        /// <summary>
        /// The center of the visible area in project coordinates.
        /// </summary>
        public Point Center
        {
            get
            {
                JSObject jsCenter = _jsObject["center"];
                return jsCenter == null ? null : new Point(jsCenter);
            }
        }

        /// <summary>
        /// The zoom factor by which the project coordinates are magnified.
        /// </summary>
        public double Zoom
        {
            get
            {
                JSValue jsZoom = _jsObject["zoom"];
                return (double)jsZoom;
            }
        }

        /// <summary>
        /// Handler function to be called on each frame of an animation.
        /// The function receives an event object which contains information 
        /// about the frame event
        /// </summary>
        public Action<FrameEvent> OnFrame
        {
            set
            {
                var del = value;
                if (del != null)
                {
                    _jsObject.Bind("onFrame", false, delegate(object sender, JavascriptMethodEventArgs args)
                    {
                        JSObject jsArg0 = args.Arguments[0];
                        FrameEvent frameEventArgs = new FrameEvent(jsArg0);
                        del(frameEventArgs);
                    });
                }
                else
                {
                    _jsObject.RemoveProperty("onFrame");
                }
            }
        }

        /// <summary>
        /// Draws the view.
        /// </summary>
        public void Draw()
        {
            Method("draw");
        }
    }
}
