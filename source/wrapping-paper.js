
//    This file is part of Wrapping-Paper.NET.
//    Copyright (c) 2013 Clifford Champion
//
//    Distributed for use only under the MIT license. 
//    See LICENSE file for details.
//

/// <summary> 
/// Javascript-hosted facilities and utilities,
/// invoked by Wrapping-Paper.NET via Awesomium
/// interop.
/// </summary>
var wrappingpaper = {
    outbox: null,
    log: function (message) {
        console.log(message);
    },
    createObjectByName: function (typeName, args) {
        this.outbox = null;
        try {
            var constructor = eval(typeName);
            if (typeof (constructor) !== "function") {
                var error = "Provided typename '" + typeName + "' not a function. (" + (typeof constructor) + ").";
                this.log(error);
                return error;
            }
            var obj = Object.create(constructor.prototype);
            constructor.apply(obj, args);
            this.outbox = obj;
            return true;
        }
        catch (exc) {
            this.log(exc);
            return exc.toString();
        }
    },
    createObjectByMethod: function (methodName, args) {
        this.outbox = null;
        try {
            var method = eval(methodName);
            if (typeof method !== "function") {
                var error = "Provided method name '"
                            + methodName + "' not a function. (" + (typeof method) + ").";
                this.log(error);
                return error;
            }
               
            var obj = method.apply(null, args);
            this.outbox = obj;
            return true;
        }
        catch (exc) {
            this.log(exc);
            return exc.toString();
        }
    }
};