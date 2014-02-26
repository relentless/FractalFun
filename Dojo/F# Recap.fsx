// F# Recap
//
// Work through this to remind/introduce yourself to F#

(*** Running the Code ***)

// This is a script.  It's not an executable program.  To run some (or all) of it
// in the F# Interactive (FSI) window, highlight it and press ALT-ENTER

// NOTE: ReSharper!!
// If you use ReSharper prior to version 8.0.10.1959, Alt+Enter won't work.
// There are 3 solutions:
// - Install the resharper-fsi-friendly plugin included in the folder
// - Map it to a different keyboard shortcut 
//   (tools -> customize -> commands -> keyboard -> EditorContextMenus.CodeWindow.ExecuteInInteractive)
//   (alt+i might be a good choice)
// - Highlight code, right-click, 'Execute in Interactive'.  But that will send you insane.

// You can also type code straight into FSI.  Just remember to finish the line with ;;.


(*** Working with Values ***)

// Define a value with 'let'
let i = 10

// YOUR TURN - Define a value:

// Types get inferred, like with 'var' in C#.  Hover your mouse over the symbol to see 
// the type (or run it in FSI)
let f = 2.5
let b = 13I

// YOUR TURN - find out what type b is

// If you want to, you can specify the type
let (s:string) = "hi mum"

// YOUR TURN - declare a float with a type annotation

// You can't (by default) change a value once it's been set!
s <- "hi dad"

// There's NO automatic type casting!
let (f2:float) = 5

// But there are some handy conversion functions, with the same names as the types
let (f3:float) = float 5

// YOUR TURN - create a float, and cast it to an int

(*** Printing ***)

// printfn lets you print stuff.  Escape characters like %d are strongly typed.
printfn "Integer: %d, Float: %f, Anything: %A" 5 9.9 [1;2;3]

(*** Tuples ***)

// Tuples let you store things in groups
let t = (1.0,2,"hi mum")

// You can get the values out with pattern matching
let t1, t2, t3 = t

// YOUR TURN - create a tuple containing three integers, then extract the contents into three values

(*** Functions ***)

// Also declare functions using 'let'
let square x = x * x

// YOUR TURN - create a function to add two numbers.
// To test it, highlight it and load it into FSI, and you can call it from there like 'add 5 7;;'

// We don't use braces.  Indentation is used to define scope.
let cube x =
    x * x * x

(*** Evaluation ***)

// Things are evaluated STRICTLY left-to-right
let result = square 10 + 2 //102

let failure = square cube 2 // doesn't even compile - you're trying to pass the unapplied 'cube' 
// function as a parameter to the 'square' function

// Use parenthesis to define different evaluation order
let result2 = square (10+2) // 144
let success = square (cube 2)

// YOUR TURN - call the 'cube' function, passing 2*5

(*** Recursion ***)

// If we want a function which calls itself (recursive), we need to also use 'rec'.
// This one multiplies all of the numbers up to the passed number (e.g. factorial 5 = 1*2*3*4*5)
let rec factorial n =
    if n > 0 then // the bit that stops it continuing forever!
        n * factorial (n - 1) // the recursive bit!
    else
        1

// YOUR TURN - create a recursive function which takes a number and adds up all numbers up to that.
// e.g. addAll 5, which should equal 1+2+3+4+5 (15)

