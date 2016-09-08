open System.Runtime.InteropServices
open System.Text

[<DllImport("libmylib")>]
extern void hello()
[<DllImport("libmylib", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)>]
extern void createString(nativeint& s)

[<EntryPoint>]
let main argv =
    hello()
    let mutable pStr = Marshal.AllocHGlobal(256)
    createString(&pStr)
    let s = Marshal.PtrToStringAnsi(pStr)
    Marshal.FreeHGlobal(pStr)
    printfn "%s" s
    0 // return an integer exit code

