namespace FunSharp.Blazor.Components

open Bolero
open Bolero.Html
open Radzen
open Radzen.Blazor

[<RequireQualifiedAccess>]
module Pager =
    
    let render<'T> (total: int) (limit: int) (offset: int) (onPageChanged: int -> unit) (pageItems: 'T array) (renderAction: 'T -> Node) =
        
        let onPageChanged (args: PagerEventArgs) =
            let newPageIndex = args.PageIndex - 1
            printfn $"changing page from {offset / limit} to {newPageIndex}"
            onPageChanged newPageIndex
        
        div {
            [ for item in pageItems do renderAction item ]
            |> Helpers.renderList
            
            printfn $"setting pager PageIndex to: {offset / limit}"
            
            comp<RadzenPager> {
                "Count" => total
                "PageSize" => limit
                "PageIndex" => offset / limit
                
                attr.callback "PageChanged" onPageChanged
            }
        }
