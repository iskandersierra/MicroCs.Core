; Unshipped analyzer release
; https://github.com/dotnet/roslyn-analyzers/blob/main/src/Microsoft.CodeAnalysis.Analyzers/ReleaseTrackingAnalyzers.Help.md

### New Rules

Rule ID | Category | Severity | Notes
--------|----------|----------|-------
MC0001 | MicroCs.Generators | Error | Unexpected type on symbol
MCAOP0001 | MicroCs.Generators.Aop | Warning | Generated proxy has no interfaces
MCAOP0002 | MicroCs.Generators.Aop | Error | Generated proxy has no interceptor
MCAOP0003 | MicroCs.Generators.Aop | Error | Generated proxy has multiple interceptors
MCAOP0004 | MicroCs.Generators.Aop | Error | Generated proxy interceptor is not named type
