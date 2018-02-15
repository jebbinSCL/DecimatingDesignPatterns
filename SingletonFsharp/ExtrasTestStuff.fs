module ExtrasTestStuff

module ConstrainedTypes =
    open System

    // ---------------------------------------------
    // Constrained String50 (FP-style)
    // ---------------------------------------------

    /// Type with constraint that value must be non-null
    /// and <= 50 chars.
    type String50 = private String50 of string

    /// Module containing functions related to String50 type
    module String50 =

        // NOTE: these functions can access the internals of the
        // type because they are in the same scope (namespace/module)
        
        /// constructor
        let create str = 
            if String.IsNullOrEmpty(str) then
                None
            elif String.length str > 50 then
                None
            else
                Some (String50 str)

        // function used to extract data since type is private
        let value (String50 str) = str

open ConstrainedTypes

let temp = String50.create "AFWEFWE"