namespace FunSharp.Blazor.Components

open Bolero.Html
open Radzen.Blazor

[<RequireQualifiedAccess>]
module TextAreaInput =
    
    let render (update: string -> unit) placeholder (rows: int) (columns: int) currentValue =
        
        let update (newValue: string) =
            if currentValue <> newValue then
                update newValue
        
        comp<RadzenTextArea> {
            attr.callback "Change" update
            
            // TODO: maybe needs this, maybe not
            // attr.callback "oninput" (fun (args: ChangeEventArgs) -> args.Value.ToString() |> update)
            
            "Value" => currentValue
            "Placeholder" => placeholder
            "Rows" => rows
            "Cols" => columns
        }
