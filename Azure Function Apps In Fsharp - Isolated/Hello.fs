module Azure_Function_Apps_In_Fsharp___Isolated.Hello

open System.Collections.Generic
open System.Net
open Microsoft.Azure.Functions.Worker
open Microsoft.Azure.Functions.Worker.Http
open Microsoft.Extensions.Logging
open Microsoft.Azure.Functions

[<Function("Hello")>]
let Run([<HttpTrigger(AuthorizationLevel.Function, "get", "post")>] req : HttpRequestData,
         executionContext : FunctionContext) =
     let logger = executionContext.GetLogger("Hello")
     logger.LogInformation("F# HTTP trigger function processed a request.")

     let response = req.CreateResponse(HttpStatusCode.OK)
     response.Headers.Add("Content-Type", "text/plain; charset=utf-8")

     response.WriteString("Welcome to Azure Functions!")

     response