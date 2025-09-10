namespace FunSharp.Blazor.Components

open System
open Bolero.Html
open Radzen.Blazor

[<RequireQualifiedAccess>]
module Link =
    
    let render (text: string option) (url: Uri) =
        
        let text = match text with | Some x -> x | None -> url.ToString()
        
        comp<RadzenLink> {
            "Path" => $"{url}"
            "Text" => text
            "Target" => "_blank"
        }
