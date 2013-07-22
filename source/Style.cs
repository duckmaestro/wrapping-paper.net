
using Awesomium.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperJS
{
    /// <summary>
    /// Style is used for changing the visual styles of items contained within 
    /// a Paper.js project and is returned by item.style and 
    /// project.currentStyle.
    /// All properties of Style are also reflected directly in Item, i.e.: 
    /// item.fillColor.
    /// To set multiple style properties in one go, you can pass an object to 
    /// item.style. This is a convenient way to define a style once and apply 
    /// it to a series of items:
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/style/
    /// </remarks>
    public class Style : BaseWrapper
    {
        public Style()
            : base(new JSObject())
        {

        }

        public Style(JSObject jsStyle)
            : base(jsStyle)
        {

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
        /// The font to be used in text content.
        /// </summary>
        public string Font
        {
            get
            {
                JSValue jsFont = _jsObject["font"];
                return (string)jsFont;
            }
            set
            {
                _jsObject["font"] = value;
            }
        }

        /// <summary>
        /// The font size of text content, as {@Number} in pixels, or as 
        /// {@String} with optional units 'px', 'pt' and 'em'.
        /// </summary>
        public double FontSize
        {
            get
            {
                JSValue jsFontSize = _jsObject["fontSize"];
                return (double)jsFontSize;
            }
            set
            {
                _jsObject["fontSize"] = value;
            }
        }

        /// <summary>
        /// The justification of text paragraphs.
        /// </summary>
        public Justification Justification
        {
            get
            {
                JSValue jsJustification = _jsObject["justification"];
                switch ((string)jsJustification)
                {
                    default:
                    case "left":
                        return PaperJS.Justification.Left;
                    case "right":
                        return PaperJS.Justification.Right;
                    case "center":
                        return PaperJS.Justification.Center;
                }
            }
            set
            {
                string valueAsString;
                switch (value)
                {
                    default:
                    case PaperJS.Justification.Left:
                        valueAsString = "left";
                        break;
                    case PaperJS.Justification.Right:
                        valueAsString = "right";
                        break;
                    case PaperJS.Justification.Center:
                        valueAsString = "center";
                        break;
                }
                _jsObject["justification"] = valueAsString;
            }
        }
    }

    public enum Justification
    {
        Left,
        Right,
        Center
    }
}
