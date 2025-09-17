namespace FunSharp.Blazor.Components

open Bolero.Html
open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web
open Radzen.Blazor

[<RequireQualifiedAccess>]
module Button =
    
    let render parent (onClick: unit -> unit) (disabled: bool) label =
        
        let onClick = fun (_: MouseEventArgs) -> onClick ()
        
        comp<RadzenButton> {
            "Text" => label
            "Disabled" => disabled
            "Click" => EventCallback.Factory.Create<MouseEventArgs>(parent, onClick)
        }
