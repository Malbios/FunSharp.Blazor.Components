namespace FunSharp.Blazor.Components

open Bolero
open Bolero.Html
open Microsoft.JSInterop

[<RequireQualifiedAccess>]
module Helpers =
    
    let renderArray (nodes: Node array) =
        concat {
            for node in nodes do node
        }
    
    let renderList (nodes: Node list) =
        concat {
            for node in nodes do node
        }
        
    let copyToClipboard (jsRuntime: IJSRuntime) (text: string) =
        
        jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", [| box text |]) |> ignore
        
    let readClipboard (js: IJSRuntime) =
        
        js.InvokeAsync<string>("readClipboardText").AsTask() |> Async.AwaitTask
