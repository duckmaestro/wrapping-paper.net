
//    This file is part of Wrapping-Paper.NET.
//    Copyright (c) 2013 Clifford Champion
//
//    Distributed for use only under the MIT license. 
//    See LICENSE file for details.
//


using Awesomium.Core;

namespace PaperJS
{
    public class FrameEvent : BaseWrapper
    {
        public FrameEvent(JSObject jsFrameEventArgs)
            : base(jsFrameEventArgs)
        {
        }

        /// <summary>
        /// the number of times the frame event was fired.
        /// </summary>
        public double Count
        {
            get
            {
                JSValue jsCount = _jsObject["count"];
                return (double)jsCount;
            }
        }

        /// <summary>
        /// the total amount of time passed since the first frame event in seconds.
        /// </summary>
        public double Time
        {
            get
            {
                JSValue jsTime = _jsObject["time"];
                return (double)jsTime;
            }
        }

        /// <summary>
        /// the time passed in seconds since the last frame event.
        /// </summary>
        public double Delta
        {
            get
            {
                JSValue jsDelta = _jsObject["delta"];
                return (double)jsDelta;
            }
        }
    }

}
