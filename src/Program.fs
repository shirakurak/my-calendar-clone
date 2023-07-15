namespace MyCalendar

open System
open Argu

module Program =

  [<EntryPoint>]
  let main args =
    let errorHandler =
      ProcessExiter(
        colorize =
          function
          | ErrorCode.HelpText -> None
          | _ -> Some ConsoleColor.Red
      )

    let parser =
      ArgumentParser.Create<Arguments>(programName = "my-calendar", errorHandler = errorHandler)

    let results = parser.ParseCommandLine args
    let args = results.GetAllResults()

    MainHandler.handler args

    0
