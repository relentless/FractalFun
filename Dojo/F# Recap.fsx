// F# Recap
//
// Work through this to remind/introduce yourself to F#
// Try typing out some examples for yourself - it's the best way to learn!

(*** Running the Code ***)

// This is a script.  It's not an executable program.  To run some (or all) of it
// in the F Sharp Interactive (FSI) window, highlight it and press ALT-ENTER

// You can also type code straight into FSI.  Just remember to finish the line with ;;.

(*** Working with Values ***)

// Define a value with 'let'
let i = 10

// Types get inferred, like with 'var' in C#.  Hover your mouse over the symbol to see 
// the type (or run it in FSI)
let f = 2.5

// If you want to, you can specify the type
let (s:string) = "hi mum"

// You can't (by default) change a value once it's been set!
s <- "hi dad"

// There's NO automatic type casting!
let (f2:float) = 5

// But there are some handy conversion functions, with the same names as the types
let (f3:float) = float 5

(*** Functions ***)

// Also declare functions using 'let'
let square x = x * x
// (Remember to try it out in FSI!)

// We don't use braces.  Indentation is used to define scope.
let cube x =
    x * x * x

// If we want a function which calls itself (recursive), we need to also use 'rec'.
let rec factorial n =
    if n > 0 then
        n * factorial (n - 1)
    else
        1

(*** Printing ***)

// printfn lets you print stuff.  Escape characters like %d are strongly typed.
printfn "Integer: %d, Float: %f, Anything: %A" 5 9.9 [1;2;3]

(*** Evaluation ***)

// Things are evaluated STRICTLY left-to-right
let result = square 10 + 2 //102

let failure = square cube 2 // doesn't even compile - you're trying to pass the unapplied 'cube' 
// function as a parameter to the 'square' function

// Use parenthesis to define different evaluation order
let result2 = square (10+2) // 144
let success = square (cube 2)

(*** Tuples ***)

// Tuples let you store things in groups
let t = (1,2,"hi mum")