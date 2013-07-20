
//    This file is part of Wrapping-Paper.NET.
//    Copyright (c) 2013 Clifford Champion
//
//    Distributed for use only under the MIT license. 
//    See LICENSE file for details.
//


using Awesomium.Core;

namespace PaperJS
{
    public class Color : BaseWrapper
    {
        public Color(JSObject jsColor)
            : base(jsColor)
        {
        }

        public Color(double red, double green, double blue, double alpha = 1.0)
            : base(CreateObjectByTypeName("paper.Color", new object[] {  red, green, blue, alpha }))
        {
        }

        /// <summary>
        /// The amount of red in the color as a value between 0 and 1.
        /// </summary>
        public double Red
        {
            get
            {
                JSValue jsRed = _jsObject["red"];
                return (double)jsRed;
            }
            set
            {
                _jsObject["red"] = value;
            }
        }

        /// <summary>
        /// The amount of green in the color as a value between 0 and 1.
        /// </summary>
        public double Green
        {
            get
            {
                JSValue jsGreen = _jsObject["green"];
                return (double)jsGreen;
            }
            set
            {
                _jsObject["green"] = value;
            }
        }


        /// <summary>
        /// The amount of blue in the color as a value between 0 and 1.
        /// </summary>
        public double Blue
        {
            get
            {
                JSValue jsBlue = _jsObject["blue"];
                return (double)jsBlue;
            }
            set
            {
                _jsObject["blue"] = value;
            }
        }

    }
}
