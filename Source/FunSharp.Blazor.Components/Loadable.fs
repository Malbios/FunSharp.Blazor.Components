namespace FunSharp.Blazor.Components

open Bolero
open Bolero.Html

type Loadable<'T> =
    | NotLoaded
    | Loading
    | Loaded of 'T
    | LoadingFailed of exn

[<RequireQualifiedAccess>]
module Loadable =
    
    let render<'T> (item: Loadable<'T>) (renderAction: 'T -> Node) =
        
        match item with
        | Loaded data ->
            renderAction data
        
        | LoadingFailed error ->
            concat {
                p { error.Message }
                p { error.StackTrace }
            }
            
        | _ ->
            LoadingWidget.render ()
