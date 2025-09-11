namespace FunSharp.Blazor.Components

open Bolero.Html
open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web
open Radzen.Blazor

[<RequireQualifiedAccess>]
module TextInput = // TODO: turn into Component because of statefulness
    
    let render (update: string -> unit) (onEnter: string -> unit) placeholder currentValue =
        
        let mutable savedValue = currentValue
        
        let update (newValue: string) =
            if newValue <> currentValue then
                update newValue
                
        let onKeyUp (args: KeyboardEventArgs) =
            if args.Key = "Enter" then
                onEnter savedValue
                
        let onChange (args: ChangeEventArgs) =
            savedValue <- args.Value.ToString()
        
        comp<RadzenTextBox> {
            attr.callback "Change" update
            attr.callback "onkeyup" onKeyUp
            attr.callback "oninput" onChange
            
            "Value" => currentValue
            "Placeholder" => placeholder
        }
