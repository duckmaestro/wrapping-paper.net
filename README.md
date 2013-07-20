Wrapping-Paper.NET
==================

*Wrapping-Paper.NET* is a .NET-based wrapper for the popular HTML5 graphics library 
[***Paper.js***](https://github.com/paperjs/paper.js). 

The purpose of this library is to enable Awesomium-based native applications to utilize *Paper.js*, 
effectively bringing it into the .NET world. Further, applications which wish to have both native 
and web releases can use this wrapper in combination with other tools such as [JSIL](https://github.com/sq/JSIL)
to author code that
(in theory) is deployable to both worlds without an unreasonable amount of effort.

Requirements
------------

 * Visual Studio 2010 or later

 * [Awesomium SDK for Windows](http://awesomium.com/)
  * Tested on version 1.7.1.0

 * [Paper.js](http://paperjs.org/)
  * Tested on version 0.9.8

Project Status
--------------
Early work-in-progress. Usable, but only about 10% 
of Paper.js is wrapped currently. Pull requests
welcome.

Usage
-----
 1. Ensure that *Awesomium.NET* is added to your build.
 2. Ensure *Paper.js* is included and functioning in your HTML file(s) within Awesomium.
 3. Add *Wrapping-Paper.NET* to your build.
 4. Include [wrapping-paper.js](https://github.com/duckmaestro/wrapping-paper.net/blob/master/source/wrapping-paper.js) 
    as a source script in your HTML file(s).
 5. Use *Wrapper-Paper.NET* by invoking `PaperJS.PaperScope.Get(yourWebView)`.
    This returns a [`PaperScope`](http://paperjs.org/reference/paperscope/), ready for use.
 6. Instantiate other objects in the `PaperJS` namespace as needed.
